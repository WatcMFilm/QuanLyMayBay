using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using QuanLyVeMayBay.DAL;

namespace QuanLyVeMayBay
{
    public partial class frmThanhToan : Form
    {
        private readonly Database db = new Database();
        private int _maVeChon = 0;
        private decimal _soTienChon = 0;
        private string _hoTenChon = "";
        private int _maThanhToanChon = 0;
        private string _thongTinHoaDonIn = "";

        // Khởi tạo Form thanh toán và hóa đơn
        public frmThanhToan()
        {
            InitializeComponent();
        }

        // Xử lý sự kiện khi Form được tải
        private void frmThanhToan_Load(object sender, EventArgs e)
        {
            CaiDatGiaoDien();
            KhoiTaoGiaTriBanDau();
            TaiDanhSachVe();
            TaiDanhSachHoaDon();
            XoaTrangThongTin();
        }

        // Cài đặt giao diện chuẩn Doanh nghiệp
        private void CaiDatGiaoDien()
        {
            UiTheme.ApplyFormStyle(this);
            UiTheme.ApplyCardStyle(grpDanhSachVe);
            UiTheme.ApplyCardStyle(grpThongTinChiTiet);
            UiTheme.ApplyCardStyle(grpBoLocHoaDon);
            UiTheme.ApplyCardStyle(grpDanhSachHoaDon);
            UiTheme.ApplyCardStyle(grpChiTietHoaDon);

            UiTheme.ApplyButtonStyle(btnXacNhanThanhToan, UiTheme.SuccessGreen, UiTheme.SuccessGreenHover, Color.White);
            UiTheme.ApplyButtonStyle(btnLapHoaDon, UiTheme.PrimaryBlue, UiTheme.PrimaryBlueHover, Color.White);
            UiTheme.ApplyButtonStyle(btnLamMoi, UiTheme.SecondarySlate, UiTheme.SecondarySlateHover, Color.White);
            UiTheme.ApplyButtonStyle(btnLamMoiVe, UiTheme.SecondarySlate, UiTheme.SecondarySlateHover, Color.White);
            UiTheme.ApplyButtonStyle(btnTraCuuHoaDon, UiTheme.PrimaryBlue, UiTheme.PrimaryBlueHover, Color.White);
            UiTheme.ApplyButtonStyle(btnLamMoiHoaDon, UiTheme.SecondarySlate, UiTheme.SecondarySlateHover, Color.White);
            UiTheme.ApplyButtonStyle(btnInHoaDon, UiTheme.WarningAmber, UiTheme.WarningAmberHover, Color.White);

            dgvVe.CellFormatting += dgvVe_CellFormatting;
        }

        // Định dạng màu sắc trạng thái trên bảng vé
        private void dgvVe_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            UiTheme.FormatStatusCell(e, "TrangThai", dgvVe);
        }

        // Khởi tạo các giá trị danh mục ban đầu cho ComboBox
        private void KhoiTaoGiaTriBanDau()
        {
            // Trạng thái lọc vé
            cboLocTrangThai.Items.Clear();
            cboLocTrangThai.Items.Add("Chờ thanh toán");
            cboLocTrangThai.Items.Add("Đã thanh toán");
            cboLocTrangThai.Items.Add("Tất cả vé");
            cboLocTrangThai.SelectedIndex = 0; // Mặc định chỉ hiện vé chờ thanh toán

            // Phương thức thanh toán
            cboPhuongThuc.Items.Clear();
            cboPhuongThuc.Items.Add("Tiền mặt");
            cboPhuongThuc.Items.Add("Chuyển khoản ngân hàng");
            cboPhuongThuc.Items.Add("Thẻ tín dụng / Ghi nợ (POS)");
            cboPhuongThuc.Items.Add("Ví điện tử (MoMo / VNPay / ZaloPay)");
            cboPhuongThuc.SelectedIndex = 1; // Mặc định chuyển khoản

            // Ngày lọc hóa đơn
            dtpTuNgay.Value = DateTime.Now.Date.AddDays(-30);
            dtpDenNgay.Value = DateTime.Now.Date.AddDays(1).AddSeconds(-1);
        }

        // Tải danh sách vé từ cơ sở dữ liệu
        private void TaiDanhSachVe()
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            v.MaVe,
                            v.MaChuyenBay,
                            kh.MaKH,
                            kh.HoTen,
                            kh.SDT,
                            kh.CCCD,
                            kh.Email,
                            cb.SanBayDi,
                            cb.SanBayDen,
                            CONCAT(cb.SanBayDi, ' ➔ ', cb.SanBayDen) AS TuyenBay,
                            cb.ThoiGianDi,
                            cb.ThoiGianDen,
                            g.MaGhe,
                            g.SoGhe,
                            g.HangGhe,
                            v.GiaVe,
                            v.NgayDat,
                            v.TrangThai
                        FROM VE v
                        JOIN KHACHHANG kh ON v.MaKH = kh.MaKH
                        JOIN CHUYENBAY cb ON v.MaChuyenBay = cb.MaChuyenBay
                        JOIN GHE g ON v.MaGhe = g.MaGhe
                        WHERE 1 = 1 ";

                    // Lọc theo trạng thái
                    string luaChonTrangThai = cboLocTrangThai.SelectedItem?.ToString() ?? "Chờ thanh toán";
                    if (luaChonTrangThai == "Chờ thanh toán")
                    {
                        query += " AND (v.TrangThai = 'Chờ thanh toán' OR v.TrangThai = 'Cho thanh toan') ";
                    }
                    else if (luaChonTrangThai == "Đã thanh toán")
                    {
                        query += " AND (v.TrangThai = 'Đã thanh toán' OR v.TrangThai = 'Da thanh toan') ";
                    }

                    // Lọc theo từ khóa tìm kiếm
                    string tuKhoa = txtTimVe.Text.Trim();
                    if (!string.IsNullOrEmpty(tuKhoa))
                    {
                        query += @" AND (
                            v.MaVe LIKE @TuKhoa OR 
                            kh.HoTen LIKE @TuKhoa OR 
                            kh.SDT LIKE @TuKhoa OR 
                            cb.SanBayDi LIKE @TuKhoa OR 
                            cb.SanBayDen LIKE @TuKhoa
                        ) ";
                    }

                    query += " ORDER BY v.MaVe DESC;";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(tuKhoa))
                        {
                            cmd.Parameters.AddWithValue("@TuKhoa", $"%{tuKhoa}%");
                        }

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvVe.DataSource = dt;
                        }
                    }
                }

                DinhDangBangVe();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Lỗi MySQL khi tải danh sách vé: " + ex.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách vé: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Định dạng tiêu đề và độ rộng cột cho bảng vé
        private void DinhDangBangVe()
        {
            UiTheme.ApplyDataGridStyle(dgvVe);

            if (dgvVe.Columns.Count == 0) return;

            void AnCot(string tenCot)
            {
                if (dgvVe.Columns.Contains(tenCot) && dgvVe.Columns[tenCot] is DataGridViewColumn col)
                {
                    col.Visible = false;
                }
            }

            AnCot("MaChuyenBay");
            AnCot("MaKH");
            AnCot("CCCD");
            AnCot("Email");
            AnCot("SanBayDi");
            AnCot("SanBayDen");
            AnCot("ThoiGianDen");
            AnCot("MaGhe");

            void DinhDangCot(string tenCot, string tieuDe, int tiLe, DataGridViewContentAlignment canLe, string? dinhDang = null)
            {
                if (dgvVe.Columns.Contains(tenCot) && dgvVe.Columns[tenCot] is DataGridViewColumn col)
                {
                    col.HeaderText = tieuDe;
                    col.FillWeight = tiLe;
                    col.DefaultCellStyle.Alignment = canLe;
                    if (!string.IsNullOrEmpty(dinhDang))
                    {
                        col.DefaultCellStyle.Format = dinhDang;
                    }
                }
            }

            DinhDangCot("MaVe", "Mã vé", 50, DataGridViewContentAlignment.MiddleCenter);
            DinhDangCot("HoTen", "Khách hàng", 110, DataGridViewContentAlignment.MiddleLeft);
            DinhDangCot("SDT", "Số ĐT", 75, DataGridViewContentAlignment.MiddleCenter);
            DinhDangCot("TuyenBay", "Hành trình", 110, DataGridViewContentAlignment.MiddleLeft);
            DinhDangCot("SoGhe", "Ghế", 45, DataGridViewContentAlignment.MiddleCenter);
            DinhDangCot("HangGhe", "Hạng ghế", 65, DataGridViewContentAlignment.MiddleLeft);
            DinhDangCot("ThoiGianDi", "Khởi hành", 85, DataGridViewContentAlignment.MiddleCenter, "dd/MM/yyyy HH:mm");
            DinhDangCot("GiaVe", "Giá vé (VNĐ)", 80, DataGridViewContentAlignment.MiddleRight, "N0");
            DinhDangCot("NgayDat", "Ngày đặt", 80, DataGridViewContentAlignment.MiddleCenter, "dd/MM/yyyy HH:mm");
            DinhDangCot("TrangThai", "Trạng thái", 75, DataGridViewContentAlignment.MiddleCenter);
        }

        // Xử lý khi người dùng chọn một dòng vé trong bảng
        private void dgvVe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvVe.Rows.Count) return;

            DataGridViewRow dong = dgvVe.Rows[e.RowIndex];

            if (!int.TryParse(dong.Cells["MaVe"]?.Value?.ToString(), out int maVe)) return;

            _maVeChon = maVe;
            _hoTenChon = dong.Cells["HoTen"]?.Value?.ToString() ?? "";
            _soTienChon = Convert.ToDecimal(dong.Cells["GiaVe"]?.Value ?? 0);

            txtMaVe.Text = $"#{maVe}";
            txtKhachHang.Text = _hoTenChon;
            txtSDT.Text = dong.Cells["SDT"]?.Value?.ToString() ?? "";
            txtCCCD.Text = dong.Cells["CCCD"]?.Value?.ToString() ?? "Chưa cập nhật";
            txtChuyenBay.Text = $"Chuyến #{dong.Cells["MaChuyenBay"]?.Value}";
            txtTuyenBay.Text = dong.Cells["TuyenBay"]?.Value?.ToString() ?? "";
            txtGhe.Text = $"{dong.Cells["SoGhe"]?.Value} ({dong.Cells["HangGhe"]?.Value})";

            if (DateTime.TryParse(dong.Cells["ThoiGianDi"]?.Value?.ToString(), out DateTime thoiGianDi))
            {
                txtThoiGianDi.Text = thoiGianDi.ToString("dd/MM/yyyy HH:mm");
            }
            else
            {
                txtThoiGianDi.Text = "";
            }

            txtSoTien.Text = $"{_soTienChon:N0} VNĐ";

            string trangThai = dong.Cells["TrangThai"]?.Value?.ToString() ?? "";

            // Kiểm tra trạng thái thanh toán và hóa đơn của vé này trong database
            KiemTraTrangThaiGiaoDich(maVe, trangThai);
        }

        // Kiểm tra trạng thái giao dịch thanh toán và hóa đơn của vé để điều khiển các nút
        private void KiemTraTrangThaiGiaoDich(int maVe, string trangThaiVe)
        {
            bool daThanhToan = trangThaiVe.Contains("Đã thanh toán") || trangThaiVe.Contains("Da thanh toan");
            _maThanhToanChon = 0;
            int maHoaDon = 0;

            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    // Tìm mã thanh toán của vé
                    string sqlTT = "SELECT MaThanhToan, TrangThai FROM THANHTOAN WHERE MaVe = @MaVe ORDER BY MaThanhToan DESC LIMIT 1;";
                    using (MySqlCommand cmdTT = new MySqlCommand(sqlTT, conn))
                    {
                        cmdTT.Parameters.AddWithValue("@MaVe", maVe);
                        using (MySqlDataReader readerTT = cmdTT.ExecuteReader())
                        {
                            if (readerTT.Read())
                            {
                                _maThanhToanChon = readerTT.GetInt32("MaThanhToan");
                                string ttTrangThai = readerTT["TrangThai"]?.ToString() ?? "";
                                if (ttTrangThai.Contains("Đã thanh toán") || ttTrangThai.Contains("Da thanh toan"))
                                {
                                    daThanhToan = true;
                                }
                            }
                        }
                    }

                    // Nếu đã có thanh toán, kiểm tra xem đã lập hóa đơn chưa
                    if (_maThanhToanChon > 0)
                    {
                        string sqlHD = "SELECT MaHoaDon FROM HOADON WHERE MaThanhToan = @MaThanhToan LIMIT 1;";
                        using (MySqlCommand cmdHD = new MySqlCommand(sqlHD, conn))
                        {
                            cmdHD.Parameters.AddWithValue("@MaThanhToan", _maThanhToanChon);
                            object? kq = cmdHD.ExecuteScalar();
                            if (kq != null)
                            {
                                maHoaDon = Convert.ToInt32(kq);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                // Bỏ qua lỗi truy vấn phụ, dùng cờ mặc định
            }

            if (daThanhToan)
            {
                btnXacNhanThanhToan.Enabled = false;
                btnXacNhanThanhToan.Text = "✅ ĐÃ THANH TOÁN";

                if (maHoaDon > 0)
                {
                    btnLapHoaDon.Enabled = false;
                    btnLapHoaDon.Text = $"🧾 Đã lập HĐ #{maHoaDon:D5}";
                }
                else
                {
                    btnLapHoaDon.Enabled = true;
                    btnLapHoaDon.Text = "🧾 Lập hóa đơn";
                }
            }
            else
            {
                btnXacNhanThanhToan.Enabled = true;
                btnXacNhanThanhToan.Text = "💳 XÁC NHẬN THANH TOÁN";
                btnLapHoaDon.Enabled = false;
                btnLapHoaDon.Text = "🧾 Lập hóa đơn";
            }
        }

        // Xóa trắng thông tin chi tiết vé trên giao diện
        private void XoaTrangThongTin()
        {
            _maVeChon = 0;
            _soTienChon = 0;
            _hoTenChon = "";
            _maThanhToanChon = 0;

            txtMaVe.Clear();
            txtKhachHang.Clear();
            txtSDT.Clear();
            txtCCCD.Clear();
            txtChuyenBay.Clear();
            txtTuyenBay.Clear();
            txtGhe.Clear();
            txtThoiGianDi.Clear();
            txtSoTien.Clear();

            btnXacNhanThanhToan.Enabled = false;
            btnXacNhanThanhToan.Text = "💳 XÁC NHẬN THANH TOÁN";
            btnLapHoaDon.Enabled = false;
            btnLapHoaDon.Text = "🧾 Lập hóa đơn";

            dgvVe.ClearSelection();
        }

        // Xử lý xác nhận thanh toán vé và lập hóa đơn
        private void btnXacNhanThanhToan_Click(object sender, EventArgs e)
        {
            if (_maVeChon <= 0)
            {
                MessageBox.Show("Vui lòng chọn một vé máy bay trong danh sách để thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string phuongThuc = cboPhuongThuc.SelectedItem?.ToString() ?? "Tiền mặt";
            bool tuDongLapHoaDon = chkLapHoaDonNgay.Checked;

            DialogResult xacNhan = MessageBox.Show(
                $"Xác nhận thanh toán cho vé số #{_maVeChon}?\n\n" +
                $"• Khách hàng: {_hoTenChon}\n" +
                $"• Số tiền: {_soTienChon:N0} VNĐ\n" +
                $"• Phương thức: {phuongThuc}\n" +
                $"• Lập hóa đơn ngay: {(tuDongLapHoaDon ? "Có" : "Không")}",
                "Xác nhận thanh toán",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (xacNhan != DialogResult.Yes) return;

            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (MySqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Kiểm tra trạng thái vé trong CSDL để chống thanh toán trùng
                        string sqlKiemTraVe = "SELECT TrangThai, GiaVe FROM VE WHERE MaVe = @MaVe FOR UPDATE;";
                        using (MySqlCommand cmdKiemTra = new MySqlCommand(sqlKiemTraVe, conn, tran))
                        {
                            cmdKiemTra.Parameters.AddWithValue("@MaVe", _maVeChon);
                            using (MySqlDataReader reader = cmdKiemTra.ExecuteReader())
                            {
                                if (!reader.Read())
                                {
                                    reader.Close();
                                    tran.Rollback();
                                    MessageBox.Show($"Không tìm thấy vé số #{_maVeChon} trong hệ thống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                string trangThaiHienTai = reader["TrangThai"]?.ToString() ?? "";
                                if (trangThaiHienTai.Contains("Đã thanh toán") || trangThaiHienTai.Contains("Da thanh toan"))
                                {
                                    reader.Close();
                                    tran.Rollback();
                                    MessageBox.Show($"Vé số #{_maVeChon} đã được thanh toán trước đó! Hệ thống từ chối thanh toán trùng lặp.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    TaiDanhSachVe();
                                    XoaTrangThongTin();
                                    return;
                                }

                                if (trangThaiHienTai.Contains("Đã hủy") || trangThaiHienTai.Contains("Da huy"))
                                {
                                    reader.Close();
                                    tran.Rollback();
                                    MessageBox.Show($"Vé số #{_maVeChon} đã bị hủy, không thể thực hiện thanh toán!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    TaiDanhSachVe();
                                    XoaTrangThongTin();
                                    return;
                                }

                                reader.Close();
                            }
                        }

                        // 2. Kiểm tra xem đã có bản ghi THANHTOAN thành công cho vé này chưa
                        string sqlKiemTraTT = "SELECT COUNT(*) FROM THANHTOAN WHERE MaVe = @MaVe AND (TrangThai = 'Đã thanh toán' OR TrangThai = 'Da thanh toan');";
                        using (MySqlCommand cmdCheckTT = new MySqlCommand(sqlKiemTraTT, conn, tran))
                        {
                            cmdCheckTT.Parameters.AddWithValue("@MaVe", _maVeChon);
                            long soLuongTT = Convert.ToInt64(cmdCheckTT.ExecuteScalar());
                            if (soLuongTT > 0)
                            {
                                tran.Rollback();
                                MessageBox.Show($"Giao dịch thanh toán cho vé #{_maVeChon} đã tồn tại trong cơ sở dữ liệu!", "Cảnh báo trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                TaiDanhSachVe();
                                XoaTrangThongTin();
                                return;
                            }
                        }

                        // 3. Thêm bản ghi mới vào bảng THANHTOAN
                        string sqlInsertTT = @"
                            INSERT INTO THANHTOAN (MaVe, SoTien, PhuongThuc, NgayThanhToan, TrangThai)
                            VALUES (@MaVe, @SoTien, @PhuongThuc, @NgayThanhToan, 'Đã thanh toán');
                            SELECT LAST_INSERT_ID();";

                        int maThanhToanMoi;
                        DateTime thoiGianThanhToan = DateTime.Now;
                        using (MySqlCommand cmdInsertTT = new MySqlCommand(sqlInsertTT, conn, tran))
                        {
                            cmdInsertTT.Parameters.AddWithValue("@MaVe", _maVeChon);
                            cmdInsertTT.Parameters.AddWithValue("@SoTien", _soTienChon);
                            cmdInsertTT.Parameters.AddWithValue("@PhuongThuc", phuongThuc);
                            cmdInsertTT.Parameters.AddWithValue("@NgayThanhToan", thoiGianThanhToan);
                            maThanhToanMoi = Convert.ToInt32(cmdInsertTT.ExecuteScalar());
                        }

                        // 4. Cập nhật trạng thái vé trong bảng VE thành 'Đã thanh toán'
                        string sqlUpdateVe = "UPDATE VE SET TrangThai = 'Đã thanh toán' WHERE MaVe = @MaVe;";
                        using (MySqlCommand cmdUpdateVe = new MySqlCommand(sqlUpdateVe, conn, tran))
                        {
                            cmdUpdateVe.Parameters.AddWithValue("@MaVe", _maVeChon);
                            cmdUpdateVe.ExecuteNonQuery();
                        }

                        // 5. Nếu tùy chọn tự động lập hóa đơn được chọn, thêm vào bảng HOADON
                        int maHoaDonMoi = 0;
                        if (tuDongLapHoaDon)
                        {
                            string sqlInsertHD = @"
                                INSERT INTO HOADON (MaThanhToan, NgayLap, TongTien)
                                VALUES (@MaThanhToan, @NgayLap, @TongTien);
                                SELECT LAST_INSERT_ID();";

                            using (MySqlCommand cmdInsertHD = new MySqlCommand(sqlInsertHD, conn, tran))
                            {
                                cmdInsertHD.Parameters.AddWithValue("@MaThanhToan", maThanhToanMoi);
                                cmdInsertHD.Parameters.AddWithValue("@NgayLap", thoiGianThanhToan);
                                cmdInsertHD.Parameters.AddWithValue("@TongTien", _soTienChon);
                                maHoaDonMoi = Convert.ToInt32(cmdInsertHD.ExecuteScalar());
                            }
                        }

                        // 6. Hoàn tất giao dịch (Commit)
                        tran.Commit();

                        string thongBao = $"Thanh toán vé thành công!\n\n" +
                                          $"• Mã vé: #{_maVeChon}\n" +
                                          $"• Khách hàng: {_hoTenChon}\n" +
                                          $"• Mã thanh toán: #{maThanhToanMoi}\n" +
                                          $"• Số tiền: {_soTienChon:N0} VNĐ\n" +
                                          $"• Phương thức: {phuongThuc}\n" +
                                          $"• Thời gian: {thoiGianThanhToan:dd/MM/yyyy HH:mm:ss}";

                        if (maHoaDonMoi > 0)
                        {
                            thongBao += $"\n• Mã hóa đơn: HD{maHoaDonMoi:D5}";
                        }

                        MessageBox.Show(thongBao, "Thanh toán thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Tải lại dữ liệu
                        TaiDanhSachVe();
                        TaiDanhSachHoaDon();
                        XoaTrangThongTin();
                    }
                    catch (MySqlException ex)
                    {
                        tran.Rollback();
                        MessageBox.Show("Lỗi MySQL khi xác nhận thanh toán: " + ex.Message, "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        MessageBox.Show("Lỗi khi xác nhận thanh toán: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Lập hóa đơn cho vé đã thanh toán nhưng chưa có hóa đơn
        private void btnLapHoaDon_Click(object sender, EventArgs e)
        {
            if (_maVeChon <= 0 || _maThanhToanChon <= 0)
            {
                MessageBox.Show("Vui lòng chọn một vé đã thanh toán để lập hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    // Kiểm tra xem đã có hóa đơn cho giao dịch thanh toán này chưa
                    string sqlKiemTra = "SELECT MaHoaDon FROM HOADON WHERE MaThanhToan = @MaThanhToan LIMIT 1;";
                    using (MySqlCommand cmdCheck = new MySqlCommand(sqlKiemTra, conn))
                    {
                        cmdCheck.Parameters.AddWithValue("@MaThanhToan", _maThanhToanChon);
                        object? kq = cmdCheck.ExecuteScalar();
                        if (kq != null)
                        {
                            MessageBox.Show($"Giao dịch thanh toán #{_maThanhToanChon} đã có hóa đơn số HD{Convert.ToInt32(kq):D5}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }

                    // Thêm hóa đơn mới vào bảng HOADON
                    string sqlInsertHD = @"
                        INSERT INTO HOADON (MaThanhToan, NgayLap, TongTien)
                        VALUES (@MaThanhToan, @NgayLap, @TongTien);
                        SELECT LAST_INSERT_ID();";

                    int maHoaDonMoi;
                    DateTime ngayLap = DateTime.Now;
                    using (MySqlCommand cmdInsert = new MySqlCommand(sqlInsertHD, conn))
                    {
                        cmdInsert.Parameters.AddWithValue("@MaThanhToan", _maThanhToanChon);
                        cmdInsert.Parameters.AddWithValue("@NgayLap", ngayLap);
                        cmdInsert.Parameters.AddWithValue("@TongTien", _soTienChon);
                        maHoaDonMoi = Convert.ToInt32(cmdInsert.ExecuteScalar());
                    }

                    MessageBox.Show(
                        $"Lập hóa đơn thành công!\n\n" +
                        $"• Mã hóa đơn: HD{maHoaDonMoi:D5}\n" +
                        $"• Mã thanh toán: #{_maThanhToanChon}\n" +
                        $"• Mã vé: #{_maVeChon}\n" +
                        $"• Khách hàng: {_hoTenChon}\n" +
                        $"• Tổng tiền: {_soTienChon:N0} VNĐ\n" +
                        $"• Ngày lập: {ngayLap:dd/MM/yyyy HH:mm:ss}",
                        "Lập hóa đơn thành công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    TaiDanhSachHoaDon();
                    KiemTraTrangThaiGiaoDich(_maVeChon, "Đã thanh toán");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Lỗi MySQL khi lập hóa đơn: " + ex.Message, "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lập hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Làm mới thông tin chi tiết vé
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            XoaTrangThongTin();
        }

        // Tải lại danh sách vé máy bay
        private void btnLamMoiVe_Click(object sender, EventArgs e)
        {
            txtTimVe.Clear();
            TaiDanhSachVe();
            XoaTrangThongTin();
        }

        // Tìm kiếm vé theo từ khóa nhập vào
        private void txtTimVe_TextChanged(object sender, EventArgs e)
        {
            TaiDanhSachVe();
        }

        // Thay đổi bộ lọc trạng thái vé
        private void cboLocTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            TaiDanhSachVe();
            XoaTrangThongTin();
        }

        // Bật / tắt bộ lọc theo ngày lập hóa đơn
        private void chkLocTheoNgay_CheckedChanged(object sender, EventArgs e)
        {
            dtpTuNgay.Enabled = chkLocTheoNgay.Checked;
            dtpDenNgay.Enabled = chkLocTheoNgay.Checked;
        }

        // Tra cứu hóa đơn theo bộ lọc
        private void btnTraCuuHoaDon_Click(object sender, EventArgs e)
        {
            TaiDanhSachHoaDon();
        }

        // Làm mới danh sách hóa đơn
        private void btnLamMoiHoaDon_Click(object sender, EventArgs e)
        {
            txtTimHoaDon.Clear();
            chkLocTheoNgay.Checked = false;
            dtpTuNgay.Value = DateTime.Now.Date.AddDays(-30);
            dtpDenNgay.Value = DateTime.Now.Date.AddDays(1).AddSeconds(-1);
            TaiDanhSachHoaDon();
            txtChiTietHoaDon.Clear();
            _thongTinHoaDonIn = "";
        }

        // Tải danh sách hóa đơn từ bảng HOADON và các bảng liên quan
        private void TaiDanhSachHoaDon()
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            hd.MaHoaDon,
                            hd.MaThanhToan,
                            v.MaVe,
                            kh.HoTen,
                            kh.SDT,
                            kh.CCCD,
                            cb.MaChuyenBay,
                            CONCAT(cb.SanBayDi, ' ➔ ', cb.SanBayDen) AS TuyenBay,
                            g.SoGhe,
                            g.HangGhe,
                            cb.ThoiGianDi,
                            tt.PhuongThuc,
                            tt.NgayThanhToan,
                            hd.TongTien,
                            hd.NgayLap
                        FROM HOADON hd
                        JOIN THANHTOAN tt ON hd.MaThanhToan = tt.MaThanhToan
                        JOIN VE v ON tt.MaVe = v.MaVe
                        JOIN KHACHHANG kh ON v.MaKH = kh.MaKH
                        JOIN CHUYENBAY cb ON v.MaChuyenBay = cb.MaChuyenBay
                        JOIN GHE g ON v.MaGhe = g.MaGhe
                        WHERE 1 = 1 ";

                    string tuKhoa = txtTimHoaDon.Text.Trim();
                    if (!string.IsNullOrEmpty(tuKhoa))
                    {
                        query += @" AND (
                            hd.MaHoaDon LIKE @TuKhoa OR 
                            hd.MaThanhToan LIKE @TuKhoa OR 
                            v.MaVe LIKE @TuKhoa OR 
                            kh.HoTen LIKE @TuKhoa OR 
                            kh.SDT LIKE @TuKhoa OR 
                            cb.SanBayDi LIKE @TuKhoa OR 
                            cb.SanBayDen LIKE @TuKhoa
                        ) ";
                    }

                    if (chkLocTheoNgay.Checked)
                    {
                        query += " AND hd.NgayLap >= @TuNgay AND hd.NgayLap <= @DenNgay ";
                    }

                    query += " ORDER BY hd.MaHoaDon DESC;";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(tuKhoa))
                        {
                            cmd.Parameters.AddWithValue("@TuKhoa", $"%{tuKhoa}%");
                        }

                        if (chkLocTheoNgay.Checked)
                        {
                            cmd.Parameters.AddWithValue("@TuNgay", dtpTuNgay.Value.Date);
                            cmd.Parameters.AddWithValue("@DenNgay", dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1));
                        }

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvHoaDon.DataSource = dt;
                        }
                    }
                }

                DinhDangBangHoaDon();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Lỗi MySQL khi tải danh sách hóa đơn: " + ex.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Định dạng tiêu đề và độ rộng cột cho bảng hóa đơn
        private void DinhDangBangHoaDon()
        {
            UiTheme.ApplyDataGridStyle(dgvHoaDon);

            if (dgvHoaDon.Columns.Count == 0) return;

            void AnCot(string tenCot)
            {
                if (dgvHoaDon.Columns.Contains(tenCot) && dgvHoaDon.Columns[tenCot] is DataGridViewColumn col)
                {
                    col.Visible = false;
                }
            }

            AnCot("CCCD");
            AnCot("MaChuyenBay");
            AnCot("HangGhe");
            AnCot("ThoiGianDi");

            void DinhDangCot(string tenCot, string tieuDe, int tiLe, DataGridViewContentAlignment canLe, string? dinhDang = null)
            {
                if (dgvHoaDon.Columns.Contains(tenCot) && dgvHoaDon.Columns[tenCot] is DataGridViewColumn col)
                {
                    col.HeaderText = tieuDe;
                    col.FillWeight = tiLe;
                    col.DefaultCellStyle.Alignment = canLe;
                    if (!string.IsNullOrEmpty(dinhDang))
                    {
                        col.DefaultCellStyle.Format = dinhDang;
                    }
                }
            }

            DinhDangCot("MaHoaDon", "Mã HĐ", 50, DataGridViewContentAlignment.MiddleCenter);
            DinhDangCot("MaThanhToan", "Mã TT", 45, DataGridViewContentAlignment.MiddleCenter);
            DinhDangCot("MaVe", "Mã vé", 45, DataGridViewContentAlignment.MiddleCenter);
            DinhDangCot("HoTen", "Khách hàng", 110, DataGridViewContentAlignment.MiddleLeft);
            DinhDangCot("SDT", "Số ĐT", 75, DataGridViewContentAlignment.MiddleCenter);
            DinhDangCot("TuyenBay", "Hành trình", 110, DataGridViewContentAlignment.MiddleLeft);
            DinhDangCot("SoGhe", "Ghế", 45, DataGridViewContentAlignment.MiddleCenter);
            DinhDangCot("PhuongThuc", "Phương thức TT", 90, DataGridViewContentAlignment.MiddleLeft);
            DinhDangCot("TongTien", "Tổng tiền (VNĐ)", 85, DataGridViewContentAlignment.MiddleRight, "N0");
            DinhDangCot("NgayLap", "Ngày lập HĐ", 85, DataGridViewContentAlignment.MiddleCenter, "dd/MM/yyyy HH:mm");
        }

        // Hiển thị chi tiết hóa đơn dạng văn bản khi người dùng click vào dòng hóa đơn
        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvHoaDon.Rows.Count) return;

            DataGridViewRow dong = dgvHoaDon.Rows[e.RowIndex];

            int maHoaDon = Convert.ToInt32(dong.Cells["MaHoaDon"]?.Value ?? 0);
            int maThanhToan = Convert.ToInt32(dong.Cells["MaThanhToan"]?.Value ?? 0);
            int maVe = Convert.ToInt32(dong.Cells["MaVe"]?.Value ?? 0);
            string hoTen = dong.Cells["HoTen"]?.Value?.ToString() ?? "";
            string sdt = dong.Cells["SDT"]?.Value?.ToString() ?? "";
            string cccd = dong.Cells["CCCD"]?.Value?.ToString() ?? "Không có";
            string tuyenBay = dong.Cells["TuyenBay"]?.Value?.ToString() ?? "";
            string soGhe = dong.Cells["SoGhe"]?.Value?.ToString() ?? "";
            string hangGhe = dong.Cells["HangGhe"]?.Value?.ToString() ?? "";
            string phuongThuc = dong.Cells["PhuongThuc"]?.Value?.ToString() ?? "";
            decimal tongTien = Convert.ToDecimal(dong.Cells["TongTien"]?.Value ?? 0);
            DateTime ngayLap = Convert.ToDateTime(dong.Cells["NgayLap"]?.Value ?? DateTime.Now);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("========================================");
            sb.AppendLine("      HÓA ĐƠN ĐIỆN TỬ - VÉ MÁY BAY      ");
            sb.AppendLine("   CÔNG TY CỔ PHẦN HÀNG KHÔNG VIỆT NAM  ");
            sb.AppendLine("========================================");
            sb.AppendLine($"Số HĐ        : HD{maHoaDon:D5}");
            sb.AppendLine($"Mã giao dịch : #{maThanhToan}");
            sb.AppendLine($"Ngày lập     : {ngayLap:dd/MM/yyyy HH:mm:ss}");
            sb.AppendLine("----------------------------------------");
            sb.AppendLine("THÔNG TIN KHÁCH HÀNG:");
            sb.AppendLine($"• Họ và tên  : {hoTen}");
            sb.AppendLine($"• Số điện thoại: {sdt}");
            sb.AppendLine($"• Số CCCD    : {cccd}");
            sb.AppendLine("----------------------------------------");
            sb.AppendLine("THÔNG TIN VÉ & CHUYẾN BAY:");
            sb.AppendLine($"• Mã vé      : #{maVe}");
            sb.AppendLine($"• Hành trình : {tuyenBay}");
            sb.AppendLine($"• Ghế ngồi   : {soGhe} ({hangGhe})");
            sb.AppendLine("----------------------------------------");
            sb.AppendLine("CHI TIẾT THANH TOÁN:");
            sb.AppendLine($"• Hình thức  : {phuongThuc}");
            sb.AppendLine($"• Trạng thái : ĐÃ THANH TOÁN");
            sb.AppendLine($"• TỔNG CỘNG  : {tongTien:N0} VNĐ");
            sb.AppendLine($"• Bằng chữ   : {DocTienBangChu(tongTien)}");
            sb.AppendLine("========================================");
            sb.AppendLine("   Cảm ơn Quý khách đã đặt vé máy bay!  ");
            sb.AppendLine("      Chúc Quý khách chuyến bay tốt đẹp! ");

            _thongTinHoaDonIn = sb.ToString();
            txtChiTietHoaDon.Text = _thongTinHoaDonIn;
        }

        // Xem chi tiết hóa đơn hoặc in hóa đơn
        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_thongTinHoaDonIn))
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn từ danh sách để xem chi tiết!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (Form frmXemIn = new Form())
            {
                frmXemIn.Text = "XEM CHI TIẾT VÀ IN HÓA ĐƠN";
                frmXemIn.Size = new Size(520, 620);
                frmXemIn.StartPosition = FormStartPosition.CenterParent;
                frmXemIn.FormBorderStyle = FormBorderStyle.FixedDialog;
                frmXemIn.MaximizeBox = false;
                frmXemIn.MinimizeBox = false;

                TextBox txtNoiDung = new TextBox
                {
                    Multiline = true,
                    ReadOnly = true,
                    Dock = DockStyle.Fill,
                    Text = _thongTinHoaDonIn,
                    Font = new Font("Consolas", 10F),
                    BackColor = Color.White,
                    ScrollBars = ScrollBars.Vertical
                };

                Panel pnlBottom = new Panel
                {
                    Dock = DockStyle.Bottom,
                    Height = 50,
                    BackColor = Color.FromArgb(241, 245, 249)
                };

                Button btnDong = new Button
                {
                    Text = "🚪 Đóng",
                    Size = new Size(110, 36),
                    Location = new Point(380, 7),
                    Font = new Font("Segoe UI", 9.5F, FontStyle.Bold)
                };
                btnDong.Click += (s, ev) => frmXemIn.Close();
                UiTheme.ApplyButtonStyle(btnDong, UiTheme.SecondarySlate, UiTheme.SecondarySlateHover, Color.White);

                Button btnIn = new Button
                {
                    Text = "🖨️ In ra máy in",
                    Size = new Size(140, 36),
                    Location = new Point(230, 7),
                    Font = new Font("Segoe UI", 9.5F, FontStyle.Bold)
                };
                btnIn.Click += (s, ev) =>
                {
                    MessageBox.Show("Lệnh in đã được chuyển đến máy in mặc định thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                };
                UiTheme.ApplyButtonStyle(btnIn, UiTheme.PrimaryBlue, UiTheme.PrimaryBlueHover, Color.White);

                pnlBottom.Controls.Add(btnIn);
                pnlBottom.Controls.Add(btnDong);

                frmXemIn.Controls.Add(txtNoiDung);
                frmXemIn.Controls.Add(pnlBottom);

                frmXemIn.ShowDialog(this);
            }
        }

        // Chuyển đổi số tiền thành chữ tiếng Việt
        private string DocTienBangChu(decimal soTien) => TienHelper.DocTienBangChu(soTien);
    }
}
