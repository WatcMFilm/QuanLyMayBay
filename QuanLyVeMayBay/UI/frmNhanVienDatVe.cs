using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using QuanLyVeMayBay.DAL;

namespace QuanLyVeMayBay
{
    /// <summary>
    /// Giao diện Bộ phận Đặt vé
    /// Viết chuẩn theo kiến thức môn Lập trình .NET cho sinh viên năm 3:
    /// - Tìm kiếm chuyến bay & xem thông tin chuyến bay
    /// - Kiểm tra ghế trống trên tàu bay (lựa chọn từ ComboBox cboGhe)
    /// - Nhập thông tin khách hàng và thực hiện Đặt vé (trạng thái: Chờ thanh toán)
    /// - Giám sát xác nhận đặt vé từ Bộ phận Kế toán & In phiếu đặt chỗ
    /// </summary>
    public partial class frmNhanVienDatVe : Form
    {
        private int _maChuyenBayChon = 0;
        private int _maMayBayChon = 0;
        private int _maGheChon = 0;
        private decimal _giaVeChon = 0;
        private decimal _giaVeThucTe = 0;
        private string _thongTinCbChon = "";
        private string _soGheChon = "";

        // Tùy chọn phương thức thanh toán linh hoạt ngay tại quầy
        private ComboBox cboLoaiDatVe = new ComboBox();
        private Label lblLoaiDatVe = new Label();

        public frmNhanVienDatVe()
        {
            InitializeComponent();
        }

        private void frmNhanVienDatVe_Load(object sender, EventArgs e)
        {
            // 1. Tạo thanh tiêu đề TopBar
            UiTheme.CreateTopBar(this, "✈️ BỘ PHẬN ĐẶT VÉ MÁY BAY",
                "Tìm kiếm chuyến bay, kiểm tra ghế trống & xác nhận đặt vé khách hàng",
                (s, ev) => this.Close());

            // 2. Làm đẹp giao diện
            CaiDatGiaoDien();

            // 3. Khởi tạo danh mục ban đầu
            KhoiTaoDuLieuBanDau();

            // 4. Tải dữ liệu ban đầu
            TaiDanhSachChuyenBay();
            TaiDanhSachVeChoXacNhan();
        }

        private void CaiDatGiaoDien()
        {
            UiTheme.ApplyFormStyle(this);
            UiTheme.ApplyCardStyle(grpTimKiem);
            UiTheme.ApplyCardStyle(grpDanhSach);
            UiTheme.ApplyCalloutStyle(grpChuyenBayChon);
            UiTheme.ApplyCardStyle(grpGhe);
            UiTheme.ApplyCardStyle(grpKhachHang);
            UiTheme.ApplyCardStyle(grpDanhSachVeVuaDat);

            UiTheme.ApplyButtonStyle(btnTimKiem, UiTheme.PrimaryBlue, UiTheme.PrimaryBlueHover, Color.White);
            UiTheme.ApplyButtonStyle(btnXemTatCa, UiTheme.SecondarySlate, UiTheme.SecondarySlateHover, Color.White);
            UiTheme.ApplyButtonStyle(btnDatVe, UiTheme.SuccessGreen, UiTheme.SuccessGreenHover, Color.White);
            UiTheme.ApplyButtonStyle(btnLamMoiNhap, UiTheme.SecondarySlate, UiTheme.SecondarySlateHover, Color.White);
            UiTheme.ApplyButtonStyle(btnLamMoiDanhSachVe, UiTheme.SecondarySlate, UiTheme.SecondarySlateHover, Color.White);
            UiTheme.ApplyButtonStyle(btnKiemTraXacNhanKeToan, UiTheme.PrimaryBlue, UiTheme.PrimaryBlueHover, Color.White);
            UiTheme.ApplyButtonStyle(btnInPhieuDatCho, UiTheme.WarningAmber, UiTheme.WarningAmberHover, Color.White);

            UiTheme.ApplyDataGridStyle(dgvChuyenBay);
            UiTheme.ApplyDataGridStyle(dgvVeChoXacNhan);

            dgvChuyenBay.CellFormatting += (s, e) => UiTheme.FormatStatusCell(e, "TrangThai", dgvChuyenBay);
            dgvVeChoXacNhan.CellFormatting += (s, e) => UiTheme.FormatStatusCell(e, "TrangThai", dgvVeChoXacNhan);

            // Bổ sung lựa chọn hình thức: Thanh toán ngay tại quầy HOẶC Giữ chỗ chờ kế toán thu tiền
            lblLoaiDatVe.Text = "Hình thức:";
            lblLoaiDatVe.Font = new Font("Segoe UI", 9f);
            lblLoaiDatVe.Location = new Point(15, 195);
            lblLoaiDatVe.Size = new Size(125, 24);
            lblLoaiDatVe.TextAlign = ContentAlignment.MiddleRight;

            cboLoaiDatVe.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiDatVe.Font = new Font("Segoe UI", 9.5f);
            cboLoaiDatVe.Location = new Point(148, 195);
            cboLoaiDatVe.Size = new Size(txtEmail.Width, 24);
            cboLoaiDatVe.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            cboLoaiDatVe.Items.Clear();
            cboLoaiDatVe.Items.Add("Thanh toán ngay (Tiền mặt tại quầy)");
            cboLoaiDatVe.Items.Add("Thanh toán ngay (Chuyển khoản / QR)");
            cboLoaiDatVe.Items.Add("Thanh toán ngay (Thẻ POS)");
            cboLoaiDatVe.Items.Add("Giữ chỗ (Chờ Kế toán thu tiền)");
            cboLoaiDatVe.SelectedIndex = 0;

            grpKhachHang.Height = 310;
            btnLamMoiNhap.Top = 245;
            btnDatVe.Top = 245;

            if (!grpKhachHang.Controls.Contains(cboLoaiDatVe))
            {
                grpKhachHang.Controls.Add(lblLoaiDatVe);
                grpKhachHang.Controls.Add(cboLoaiDatVe);
            }

            tabXacNhan.Text = "📋 Quản lý vé đã đặt & Xuất vé";
            grpDanhSachVeVuaDat.Text = "📋 Danh sách vé đã thực hiện (Chờ thanh toán / Đã thanh toán)";
            btnInPhieuDatCho.Text = "🖨️ In Vé Máy Bay / Phiếu Giữ Chỗ";
        }

        private void KhoiTaoDuLieuBanDau()
        {
            string[] dsSanBay = { "HAN - Nội Bài (Hà Nội)", "SGN - Tân Sơn Nhất (TP.HCM)", "DAD - Đà Nẵng", "CXR - Cam Ranh", "PQC - Phú Quốc" };
            cboSanBayDi.Items.Clear();
            cboSanBayDen.Items.Clear();
            cboSanBayDi.Items.AddRange(dsSanBay);
            cboSanBayDen.Items.AddRange(dsSanBay);

            cboHangGhe.Items.Clear();
            cboHangGhe.Items.Add("Tất cả hạng ghế");
            cboHangGhe.Items.Add("Thuong gia");
            cboHangGhe.Items.Add("Pho thong");
            cboHangGhe.SelectedIndex = 0;
        }

        // =========================================================================
        // 1. TÌM KIẾM & XEM DANH SÁCH CHUYẾN BAY
        // =========================================================================

        // UC05 - Tra cứu chuyến bay: lọc theo điểm đi, điểm đến, ngày bay; hiển thị số ghế còn trống
        private void TaiDanhSachChuyenBay(bool coLoc = false)
        {
            string sql = @"
                SELECT cb.MaChuyenBay, cb.MaMayBay, mb.TenMayBay, cb.SanBayDi, cb.SanBayDen, 
                       cb.ThoiGianDi, cb.ThoiGianDen, cb.GiaVe, 
                       (SELECT COUNT(*) FROM GHE g 
                        WHERE g.MaMayBay = cb.MaMayBay AND g.TrangThai = 'Trong'
                          AND NOT EXISTS (SELECT 1 FROM VE v WHERE v.MaChuyenBay = cb.MaChuyenBay 
                                          AND v.MaGhe = g.MaGhe AND v.TrangThai <> 'Đã hủy')) AS SoGheTrong,
                       cb.TrangThai 
                FROM CHUYENBAY cb 
                LEFT JOIN MAYBAY mb ON cb.MaMayBay = mb.MaMayBay 
                WHERE cb.TrangThai = 'Đang mở'
                  AND cb.ThoiGianDi > NOW() ";

            if (coLoc)
            {
                if (cboSanBayDi.SelectedIndex >= 0)
                    sql += " AND cb.SanBayDi LIKE @di";
                if (cboSanBayDen.SelectedIndex >= 0)
                    sql += " AND cb.SanBayDen LIKE @den";
                sql += " AND DATE(cb.ThoiGianDi) = @ngay";
            }

            sql += " ORDER BY cb.ThoiGianDi ASC;";

            DataTable dt = Database.GetData(sql,
                new MySqlParameter("@di", $"%{cboSanBayDi.Text.Split('-')[0].Trim()}%"),
                new MySqlParameter("@den", $"%{cboSanBayDen.Text.Split('-')[0].Trim()}%"),
                new MySqlParameter("@ngay", dtpNgayDi.Value.Date));
            dgvChuyenBay.DataSource = dt;

            UiTheme.SetCol(dgvChuyenBay, "MaChuyenBay", "Mã CB", width: 65, align: DataGridViewContentAlignment.MiddleCenter);
            UiTheme.SetCol(dgvChuyenBay, "MaMayBay", "Mã MB", visible: false);
            UiTheme.SetCol(dgvChuyenBay, "TenMayBay", "Tàu bay");
            UiTheme.SetCol(dgvChuyenBay, "SanBayDi", "Sân bay đi");
            UiTheme.SetCol(dgvChuyenBay, "SanBayDen", "Sân bay đến");
            UiTheme.SetCol(dgvChuyenBay, "ThoiGianDi", "Khởi hành", format: "dd/MM/yyyy HH:mm");
            UiTheme.SetCol(dgvChuyenBay, "ThoiGianDen", "Hạ cánh", format: "dd/MM/yyyy HH:mm");
            UiTheme.SetCol(dgvChuyenBay, "GiaVe", "Giá vé cơ bản", align: DataGridViewContentAlignment.MiddleRight, format: "N0");
            UiTheme.SetCol(dgvChuyenBay, "SoGheTrong", "Ghế trống", width: 80, align: DataGridViewContentAlignment.MiddleCenter);
            UiTheme.SetCol(dgvChuyenBay, "TrangThai", "Trạng thái", align: DataGridViewContentAlignment.MiddleCenter);

            if (coLoc && dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có chuyến bay phù hợp vào ngày đã chọn. Hãy thử ngày khác hoặc bấm 'Xem tất cả'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu nhập theo đặc tả UC05
            if (cboSanBayDi.SelectedIndex >= 0 && cboSanBayDi.Text == cboSanBayDen.Text)
            {
                MessageBox.Show("Điểm đi và điểm đến không được trùng nhau!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dtpNgayDi.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Ngày bay không được ở quá khứ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            TaiDanhSachChuyenBay(true);
        }

        private void btnXemTatCa_Click(object sender, EventArgs e)
        {
            cboSanBayDi.SelectedIndex = -1;
            cboSanBayDen.SelectedIndex = -1;
            TaiDanhSachChuyenBay(false);
        }

        // =========================================================================
        // 2. CHỌN CHUYẾN BAY & KIỂM TRA GHẾ TRỐNG
        // =========================================================================

        private void dgvChuyenBay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvChuyenBay.Rows[e.RowIndex];
            _maChuyenBayChon = Database.ToInt(row.Cells["MaChuyenBay"].Value);
            _maMayBayChon = Database.ToInt(row.Cells["MaMayBay"].Value);
            _giaVeChon = Database.ToDecimal(row.Cells["GiaVe"].Value);

            string di = row.Cells["SanBayDi"].Value?.ToString() ?? "";
            string den = row.Cells["SanBayDen"].Value?.ToString() ?? "";
            DateTime gioDi = Database.ToDateTime(row.Cells["ThoiGianDi"].Value);

            _thongTinCbChon = $"CB #{_maChuyenBayChon} ({di} ➔ {den}) lúc {gioDi:dd/MM/yyyy HH:mm}";
            lblChiTietChuyenBay.Text = $"✈️ ĐÃ CHỌN: {_thongTinCbChon}\nGiá vé cơ bản: {_giaVeChon:N0} VNĐ";

            TaiDanhSachGheTrong();
        }

        // Tải danh sách ghế trống của chuyến bay vào ComboBox cboGhe
        private void TaiDanhSachGheTrong()
        {
            if (_maMayBayChon <= 0 || _maChuyenBayChon <= 0) return;

            // Câu lệnh chuẩn: Lấy ghế của máy bay chưa bị đặt trên chuyến bay này và không bị bảo trì
            string sql = @"
                SELECT g.MaGhe, g.SoGhe, g.HangGhe, g.TrangThai 
                FROM GHE g 
                WHERE g.MaMayBay = @mb 
                  AND g.TrangThai = 'Trong'
                  AND NOT EXISTS (
                      SELECT 1 FROM VE v 
                      WHERE v.MaChuyenBay = @cb 
                        AND v.MaGhe = g.MaGhe 
                        AND v.TrangThai NOT IN ('Đã hủy', 'Da huy')
                  )";

            if (cboHangGhe.SelectedIndex > 0)
            {
                sql += " AND g.HangGhe = @hang";
            }

            sql += " ORDER BY g.SoGhe ASC;";

            DataTable dtGhe = Database.GetData(sql,
                new MySqlParameter("@mb", _maMayBayChon),
                new MySqlParameter("@cb", _maChuyenBayChon),
                new MySqlParameter("@hang", cboHangGhe.Text));

            cboGhe.DisplayMember = "SoGhe";
            cboGhe.ValueMember = "MaGhe";
            cboGhe.DataSource = dtGhe;

            lblSoLuongGheTrong.Text = $"● Số ghế trống hiện tại: {dtGhe.Rows.Count} ghế";

            if (dtGhe.Rows.Count > 0)
            {
                cboGhe.SelectedIndex = 0;
                cboGhe_SelectedIndexChanged(this, EventArgs.Empty);
            }
            else
            {
                lblGiaVeHienThi.Text = "Hết ghế";
                _maGheChon = 0;
                _soGheChon = "";
            }
        }

        private void cboHangGhe_SelectedIndexChanged(object sender, EventArgs e)
        {
            TaiDanhSachGheTrong();
        }

        // Khi người dùng chọn 1 ghế trong ComboBox cboGhe
        private void cboGhe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboGhe.SelectedItem is DataRowView drv)
            {
                _maGheChon = Database.ToInt(drv["MaGhe"]);
                _soGheChon = drv["SoGhe"]?.ToString() ?? "";
                string hangGhe = drv["HangGhe"]?.ToString() ?? "Pho thong";

                _giaVeThucTe = (hangGhe == "Thuong gia") ? _giaVeChon * 1.3m : _giaVeChon;
                lblGiaVeHienThi.Text = $"{_giaVeThucTe:N0} VNĐ ({hangGhe})";
            }
        }

        // =========================================================================
        // 3. NHẬP THÔNG TIN KHÁCH HÀNG & THỰC HIỆN ĐẶT VÉ
        // =========================================================================

        private void btnDatVe_Click(object sender, EventArgs e)
        {
            // Bước 1: Kiểm tra chọn chuyến bay và ghế trống
            if (_maChuyenBayChon <= 0)
            {
                MessageBox.Show("Vui lòng click chọn một chuyến bay trong bảng trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_maGheChon <= 0 || cboGhe.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn ghế trống hợp lệ trong danh sách ghế!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Bước 2: Kiểm tra thông tin khách hàng nhập vào
            string hoTen = txtHoTen.Text.Trim();
            string cccd = txtCCCD.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrWhiteSpace(hoTen) || string.IsNullOrWhiteSpace(cccd) || string.IsNullOrWhiteSpace(sdt))
            {
                MessageBox.Show("Vui lòng điền đầy đủ Họ tên, CCCD/Hộ chiếu và Số điện thoại khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(hoTen, @"^[\p{L}\s]+$"))
            {
                MessageBox.Show("Họ và tên chỉ được chứa chữ cái!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            // CCCD: 12 chữ số; Hộ chiếu: 1-2 chữ cái + 6-8 chữ số
            if (!System.Text.RegularExpressions.Regex.IsMatch(cccd, @"^(\d{12}|[A-Za-z]{1,2}\d{6,8})$"))
            {
                MessageBox.Show("CCCD phải gồm đúng 12 chữ số (hoặc số hộ chiếu hợp lệ, ví dụ B1234567)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCCCD.Focus();
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(sdt, @"^0\d{9}$"))
            {
                MessageBox.Show("Số điện thoại phải gồm 10 chữ số và bắt đầu bằng số 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return;
            }

            if (!string.IsNullOrEmpty(email) && !System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^\s@]+@[^\s@]+\.[^\s@]+$"))
            {
                MessageBox.Show("Email không đúng định dạng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            if (!DbInitializer.IsMySqlAvailable)
            {
                MessageBox.Show("Đang chạy chế độ demo (chưa kết nối MySQL) nên không thể lưu vé.", "Chế độ demo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Lựa chọn: Thanh toán ngay tại quầy HOẶC Giữ chỗ trả sau
            bool thanhToanNgay = cboLoaiDatVe.SelectedIndex < 3;
            string phuongThuc = cboLoaiDatVe.Text.Replace("Thanh toán ngay (", "").Replace(")", "").Trim();
            string trangThaiVe = thanhToanNgay ? "Đã thanh toán" : "Chờ thanh toán";
            decimal giaVeLuu = (_giaVeThucTe > 0) ? _giaVeThucTe : _giaVeChon;
            long maVeMoi;

            try
            {
                // Toàn bộ các bước ghi dữ liệu nằm trong 1 transaction:
                // nếu bất kỳ bước nào lỗi thì không để lại vé "Đã thanh toán" mà không có thanh toán/hóa đơn
                using (MySqlConnection conn = Database.TaoKetNoi())
                {
                    conn.Open();
                    using (MySqlTransaction tran = conn.BeginTransaction())
                    {
                        // Bước 3: Khóa chuyến bay rồi kiểm tra ghế này vừa có ai đặt trước không
                        using (var cmdKhoa = new MySqlCommand("SELECT MaChuyenBay FROM CHUYENBAY WHERE MaChuyenBay = @cb FOR UPDATE;", conn, tran))
                        {
                            cmdKhoa.Parameters.AddWithValue("@cb", _maChuyenBayChon);
                            cmdKhoa.ExecuteScalar();
                        }

                        long soVeTrung;
                        using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM VE WHERE MaChuyenBay = @cb AND MaGhe = @ghe AND TrangThai NOT IN ('Đã hủy', 'Da huy');", conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@cb", _maChuyenBayChon);
                            cmd.Parameters.AddWithValue("@ghe", _maGheChon);
                            soVeTrung = Database.ToLong(cmd.ExecuteScalar());
                        }

                        if (soVeTrung > 0)
                        {
                            tran.Rollback();
                            MessageBox.Show("Ghế này vừa được đặt bởi khách khác! Vui lòng chọn ghế trống khác.", "Cảnh báo trùng ghế", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            TaiDanhSachGheTrong();
                            return;
                        }

                        // Bước 4: Tìm khách hàng theo CCCD (định danh duy nhất). Không tìm theo SĐT vì
                        // nhiều người có thể dùng chung 1 số điện thoại -> sẽ gán nhầm vé cho người khác.
                        long maKH;
                        using (var cmd = new MySqlCommand("SELECT MaKH FROM KHACHHANG WHERE CCCD = @cccd LIMIT 1;", conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@cccd", cccd);
                            maKH = Database.ToLong(cmd.ExecuteScalar());
                        }

                        if (maKH > 0)
                        {
                            // Cập nhật thông tin liên hệ mới nhất của khách
                            using var cmd = new MySqlCommand("UPDATE KHACHHANG SET HoTen = @ten, SDT = @sdt, Email = IF(@email = '', Email, @email) WHERE MaKH = @kh;", conn, tran);
                            cmd.Parameters.AddWithValue("@ten", hoTen);
                            cmd.Parameters.AddWithValue("@sdt", sdt);
                            cmd.Parameters.AddWithValue("@email", email);
                            cmd.Parameters.AddWithValue("@kh", maKH);
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            using var cmd = new MySqlCommand("INSERT INTO KHACHHANG (HoTen, CCCD, SDT, Email) VALUES (@ten, @cccd, @sdt, @email);", conn, tran);
                            cmd.Parameters.AddWithValue("@ten", hoTen);
                            cmd.Parameters.AddWithValue("@cccd", cccd);
                            cmd.Parameters.AddWithValue("@sdt", sdt);
                            cmd.Parameters.AddWithValue("@email", string.IsNullOrEmpty(email) ? DBNull.Value : email);
                            cmd.ExecuteNonQuery();
                            maKH = cmd.LastInsertedId;
                        }

                        // Bước 5: Tạo vé
                        using (var cmd = new MySqlCommand("INSERT INTO VE (MaChuyenBay, MaKH, MaGhe, NgayDat, GiaVe, TrangThai) VALUES (@cb, @kh, @ghe, NOW(), @gia, @tt);", conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@cb", _maChuyenBayChon);
                            cmd.Parameters.AddWithValue("@kh", maKH);
                            cmd.Parameters.AddWithValue("@ghe", _maGheChon);
                            cmd.Parameters.AddWithValue("@gia", giaVeLuu);
                            cmd.Parameters.AddWithValue("@tt", trangThaiVe);
                            cmd.ExecuteNonQuery();
                            maVeMoi = cmd.LastInsertedId;
                        }

                        // Bước 6: Nếu thanh toán ngay thì tạo bản ghi thanh toán và hóa đơn điện tử
                        if (thanhToanNgay)
                        {
                            long maTT;
                            using (var cmd = new MySqlCommand("INSERT INTO THANHTOAN (MaVe, SoTien, PhuongThuc, NgayThanhToan, TrangThai) VALUES (@mv, @tien, @pt, NOW(), 'Đã thanh toán');", conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@mv", maVeMoi);
                                cmd.Parameters.AddWithValue("@tien", giaVeLuu);
                                cmd.Parameters.AddWithValue("@pt", phuongThuc);
                                cmd.ExecuteNonQuery();
                                maTT = cmd.LastInsertedId;
                            }

                            using (var cmd = new MySqlCommand("INSERT INTO HOADON (MaThanhToan, NgayLap, TongTien) VALUES (@tt, NOW(), @tien);", conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@tt", maTT);
                                cmd.Parameters.AddWithValue("@tien", giaVeLuu);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        tran.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đặt vé (dữ liệu đã được hoàn tác): " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (thanhToanNgay)
            {
                MessageBox.Show($"🎉 ĐẶT VÉ & THANH TOÁN THÀNH CÔNG TẠI QUẦY!\n\n" +
                    $"• Mã vé: #{maVeMoi}\n" +
                    $"• Hành khách: {hoTen}\n" +
                    $"• Chuyến bay: {_thongTinCbChon}\n" +
                    $"• Số ghế: {_soGheChon}\n" +
                    $"• Số tiền: {giaVeLuu:N0} VNĐ ({phuongThuc})\n" +
                    $"• Trạng thái: ĐÃ THANH TOÁN (Đã phát hành Vé & Hóa đơn)",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"📌 GIỮ CHỖ THÀNH CÔNG CHO KHÁCH HÀNG!\n\n" +
                    $"• Mã vé: #{maVeMoi}\n" +
                    $"• Hành khách: {hoTen}\n" +
                    $"• Số ghế: {_soGheChon}\n" +
                    $"• Số tiền: {giaVeLuu:N0} VNĐ\n" +
                    $"• Trạng thái: CHỜ THANH TOÁN\n\n" +
                    $"⚠️ Quý khách vui lòng thanh toán trong vòng 24 giờ tại phòng Kế toán.",
                    "Giữ chỗ thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            TaiDanhSachGheTrong();
            TaiDanhSachVeChoXacNhan();
            btnLamMoiNhap_Click(sender, e);
        }

        private void btnLamMoiNhap_Click(object sender, EventArgs e)
        {
            txtHoTen.Clear();
            txtCCCD.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
        }

        // =========================================================================
        // 4. GIÁM SÁT XÁC NHẬN TỪ BỘ PHẬN KẾ TOÁN & IN PHIẾU ĐẶT CHỖ
        // =========================================================================

        private void TaiDanhSachVeChoXacNhan()
        {
            string sql = @"
                SELECT v.MaVe, kh.HoTen, kh.SDT, cb.SanBayDi, cb.SanBayDen, g.SoGhe, v.GiaVe, v.TrangThai 
                FROM VE v 
                LEFT JOIN KHACHHANG kh ON v.MaKH = kh.MaKH 
                LEFT JOIN CHUYENBAY cb ON v.MaChuyenBay = cb.MaChuyenBay 
                LEFT JOIN GHE g ON v.MaGhe = g.MaGhe 
                ORDER BY v.MaVe DESC 
                LIMIT 50;";

            dgvVeChoXacNhan.DataSource = Database.GetData(sql);

            UiTheme.SetCol(dgvVeChoXacNhan, "MaVe", "Mã vé", width: 65, align: DataGridViewContentAlignment.MiddleCenter);
            UiTheme.SetCol(dgvVeChoXacNhan, "HoTen", "Tên hành khách");
            UiTheme.SetCol(dgvVeChoXacNhan, "SDT", "Số điện thoại");
            UiTheme.SetCol(dgvVeChoXacNhan, "SanBayDi", "Điểm đi");
            UiTheme.SetCol(dgvVeChoXacNhan, "SanBayDen", "Điểm đến");
            UiTheme.SetCol(dgvVeChoXacNhan, "SoGhe", "Ghế", width: 60, align: DataGridViewContentAlignment.MiddleCenter);
            UiTheme.SetCol(dgvVeChoXacNhan, "GiaVe", "Giá tiền", align: DataGridViewContentAlignment.MiddleRight, format: "N0");
            UiTheme.SetCol(dgvVeChoXacNhan, "TrangThai", "Trạng thái", align: DataGridViewContentAlignment.MiddleCenter);
        }

        private void btnKiemTraXacNhanKeToan_Click(object sender, EventArgs e)
        {
            TaiDanhSachVeChoXacNhan();
            MessageBox.Show("Đã đồng bộ trạng thái mới nhất từ Bộ phận Kế toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLamMoiDanhSachVe_Click(object sender, EventArgs e)
        {
            TaiDanhSachVeChoXacNhan();
        }

        private void btnInPhieuDatCho_Click(object sender, EventArgs e)
        {
            if (dgvVeChoXacNhan.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng click chọn 1 vé trong danh sách để in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow r = dgvVeChoXacNhan.CurrentRow;
            string trangThai = r.Cells["TrangThai"].Value?.ToString() ?? "";
            bool daThanhToan = trangThai == "Đã thanh toán";
            string tieuDe = daThanhToan ? "VÉ MÁY BAY ĐIỆN TỬ (BOARDING PASS)" : "PHIẾU GIỮ CHỖ VÉ MÁY BAY (RESERVATION)";

            string noiDungPhieu =
                $"==========================================================\n" +
                $"            {tieuDe}            \n" +
                $"==========================================================\n" +
                $"Mã vé: #{r.Cells["MaVe"].Value}\n" +
                $"Hành khách: {r.Cells["HoTen"].Value}\n" +
                $"Số điện thoại: {r.Cells["SDT"].Value}\n" +
                $"Hành trình: {r.Cells["SanBayDi"].Value} ➔ {r.Cells["SanBayDen"].Value}\n" +
                $"Số ghế ngồi: {r.Cells["SoGhe"].Value}\n" +
                $"Số tiền thanh toán: {Database.ToDecimal(r.Cells["GiaVe"].Value):N0} VNĐ\n" +
                $"Trạng thái vé: {trangThai.ToUpper()}\n" +
                $"----------------------------------------------------------\n" +
                (daThanhToan
                    ? "✓ Vé đã thanh toán thành công. Chúc quý khách có chuyến bay tốt đẹp!\n✓ Quý khách vui lòng có mặt tại sân bay trước giờ khởi hành 90 phút."
                    : "⚠️ Vé đang ở trạng thái GIỮ CHỖ. Quý khách vui lòng thanh toán trong vòng 24h.") + "\n" +
                $"==========================================================";

            MessageBox.Show(noiDungPhieu, tieuDe, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
