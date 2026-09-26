using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using QuanLyVeMayBay.DAL;

namespace QuanLyVeMayBay
{
    public partial class frmDatVe : Form
    {
        private Database db = new Database();
        private int _maChuyenBayChon = 0;
        private int _maMayBayChon = 0;
        private decimal _giaVeChuyenBay = 0;
        private string _trangThaiChuyenBay = "";
        private DateTime _thoiGianDi = DateTime.MinValue;
        private DateTime _thoiGianDen = DateTime.MinValue;

        // Khởi tạo Form đặt vé
        public frmDatVe()
        {
            InitializeComponent();
        }

        // Xử lý khi Form được tải
        private void frmDatVe_Load(object sender, EventArgs e)
        {
            CaiDatGiaoDien();
            SeedGheMauNeuTrong();
            LoadSanBay();
            DinhDangBang();
        }

        // Cài đặt giao diện chuẩn Doanh nghiệp
        private void CaiDatGiaoDien()
        {
            UiTheme.ApplyFormStyle(this);
            UiTheme.ApplyCardStyle(grpTimKiem);
            UiTheme.ApplyCardStyle(grpDanhSach);
            UiTheme.ApplyCalloutStyle(grpChuyenBayChon);
            UiTheme.ApplyCardStyle(grpKhachHang);
            UiTheme.ApplyCardStyle(grpGhe);

            UiTheme.ApplyButtonStyle(btnTimKiem, UiTheme.PrimaryBlue, UiTheme.PrimaryBlueHover, Color.White);
            UiTheme.ApplyButtonStyle(btnDatVe, UiTheme.SuccessGreen, UiTheme.SuccessGreenHover, Color.White);

            dgvChuyenBay.CellFormatting += dgvChuyenBay_CellFormatting;
        }

        // Định dạng màu sắc trạng thái chuyến bay
        private void dgvChuyenBay_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            UiTheme.FormatStatusCell(e, "TrangThai", dgvChuyenBay);
        }

        // Thêm ghế mẫu nếu bảng GHE đang rỗng
        private void SeedGheMauNeuTrong()
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    using (MySqlCommand cmdCount = new MySqlCommand("SELECT COUNT(*) FROM GHE;", conn))
                    {
                        long soGhe = (long)cmdCount.ExecuteScalar();
                        if (soGhe > 0) return;
                    }

                    using (MySqlCommand cmdMayBay = new MySqlCommand("SELECT MaMayBay FROM MAYBAY;", conn))
                    using (MySqlDataReader reader = cmdMayBay.ExecuteReader())
                    {
                        var dsMaMayBay = new System.Collections.Generic.List<int>();
                        while (reader.Read())
                            dsMaMayBay.Add(reader.GetInt32(0));
                        reader.Close();

                        string[] hangThuongGia = new string[] { "A1", "A2", "B1", "B2", "C1", "C2", "D1", "D2" };
                        string[] hangPhoThong   = new string[] { "E1", "E2", "E3", "F1", "F2", "F3", "G1", "G2", "G3", "H1", "H2", "H3" };

                        string sqlInsert = "INSERT INTO GHE (MaMayBay, SoGhe, HangGhe, TrangThai) VALUES (@mb, @so, @hang, 'Trong');";
                        foreach (int maMayBay in dsMaMayBay)
                        {
                            foreach (string so in hangThuongGia)
                            {
                                using var cmd = new MySqlCommand(sqlInsert, conn);
                                cmd.Parameters.AddWithValue("@mb", maMayBay);
                                cmd.Parameters.AddWithValue("@so", so);
                                cmd.Parameters.AddWithValue("@hang", "Thuong gia");
                                cmd.ExecuteNonQuery();
                            }
                            foreach (string so in hangPhoThong)
                            {
                                using var cmd = new MySqlCommand(sqlInsert, conn);
                                cmd.Parameters.AddWithValue("@mb", maMayBay);
                                cmd.Parameters.AddWithValue("@so", so);
                                cmd.Parameters.AddWithValue("@hang", "Pho thong");
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi khởi tạo dữ liệu ghế: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Tải danh sách sân bay vào ComboBox
        private void LoadSanBay()
        {
            DataTable dtDi  = TaoBangSanBay();
            cboSanBayDi.DataSource = dtDi;
            cboSanBayDi.DisplayMember = "HienThi";
            cboSanBayDi.ValueMember   = "MaSanBay";
            cboSanBayDi.SelectedIndex = -1;

            DataTable dtDen = TaoBangSanBay();
            cboSanBayDen.DataSource = dtDen;
            cboSanBayDen.DisplayMember = "HienThi";
            cboSanBayDen.ValueMember   = "MaSanBay";
            cboSanBayDen.SelectedIndex = -1;
        }

        // Tạo bảng sân bay cố định
        private DataTable TaoBangSanBay()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MaSanBay", typeof(string));
            dt.Columns.Add("HienThi",  typeof(string));

            void Them(string ma, string ten)
            {
                dt.Rows.Add(ma, $"{ma} - {ten}");
            }

            Them("HAN", "Nội Bài (Hà Nội)");
            Them("SGN", "Tân Sơn Nhất (TP.HCM)");
            Them("DAD", "Đà Nẵng");
            Them("CXR", "Cam Ranh");
            Them("PQC", "Phú Quốc");
            Them("HPH", "Cát Bi (Hải Phòng)");
            Them("VDO", "Vân Đồn");
            Them("VII", "Vinh");
            Them("HUI", "Phú Bài (Huế)");
            Them("UIH", "Phù Cát (Quy Nhơn)");
            Them("BKK", "Suvarnabhumi (BKK)");
            Them("NRT", "Narita (NRT)");

            return dt;
        }

        // Định dạng bảng danh sách chuyến bay
        private void DinhDangBang()
        {
            UiTheme.ApplyDataGridStyle(dgvChuyenBay);
        }

        // Tìm kiếm chuyến bay theo sân bay và ngày
        private void TimKiemChuyenBay()
        {
            if (cboSanBayDi.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn sân bay đi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboSanBayDi.Focus();
                return;
            }
            if (cboSanBayDen.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn sân bay đến!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboSanBayDen.Focus();
                return;
            }

            string maDi  = cboSanBayDi.SelectedValue.ToString()!;
            string maDen = cboSanBayDen.SelectedValue.ToString()!;
            DateTime ngayDi = dtpNgayDi.Value.Date;

            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT MaChuyenBay, MaMayBay, SanBayDi, SanBayDen,
                               ThoiGianDi, ThoiGianDen, GiaVe, TrangThai
                        FROM chuyenbay
                        WHERE SanBayDi LIKE CONCAT('%', @MaDi, '%')
                          AND SanBayDen LIKE CONCAT('%', @MaDen, '%')
                          AND DATE(ThoiGianDi) = @NgayDi
                          AND TrangThai NOT IN ('Đã hủy', 'Da huy')
                        ORDER BY ThoiGianDi;";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@MaDi",  maDi);
                        adapter.SelectCommand.Parameters.AddWithValue("@MaDen", maDen);
                        adapter.SelectCommand.Parameters.AddWithValue("@NgayDi", ngayDi.ToString("yyyy-MM-dd"));

                        DataTable dtKetQua = new DataTable();
                        adapter.Fill(dtKetQua);
                        dgvChuyenBay.DataSource = dtKetQua;

                        DatTieuDeCot();

                        if (dtKetQua.Rows.Count == 0)
                        {
                            MessageBox.Show("Không tìm thấy chuyến bay phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm chuyến bay: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            XoaThongTinChuyenBayChon();
        }

        // Đặt tiêu đề cột cho bảng chuyến bay
        private void DatTieuDeCot()
        {
            if (dgvChuyenBay.Columns.Count == 0) return;
            if (dgvChuyenBay.Columns.Contains("MaChuyenBay") && dgvChuyenBay.Columns["MaChuyenBay"] is DataGridViewColumn cMa)
            {
                cMa.HeaderText = "Mã chuyến bay";
                cMa.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgvChuyenBay.Columns.Contains("MaMayBay") && dgvChuyenBay.Columns["MaMayBay"] is DataGridViewColumn cMB)
            {
                cMB.HeaderText = "Máy bay";
                cMB.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgvChuyenBay.Columns.Contains("SanBayDi") && dgvChuyenBay.Columns["SanBayDi"] is DataGridViewColumn cDi)
                cDi.HeaderText = "Sân bay đi";
            if (dgvChuyenBay.Columns.Contains("SanBayDen") && dgvChuyenBay.Columns["SanBayDen"] is DataGridViewColumn cDen)
                cDen.HeaderText = "Sân bay đến";
            if (dgvChuyenBay.Columns.Contains("ThoiGianDi") && dgvChuyenBay.Columns["ThoiGianDi"] is DataGridViewColumn cTGDi)
            {
                cTGDi.HeaderText = "Giờ đi";
                cTGDi.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }
            if (dgvChuyenBay.Columns.Contains("ThoiGianDen") && dgvChuyenBay.Columns["ThoiGianDen"] is DataGridViewColumn cTGDen)
            {
                cTGDen.HeaderText = "Giờ đến";
                cTGDen.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }
            if (dgvChuyenBay.Columns.Contains("GiaVe") && dgvChuyenBay.Columns["GiaVe"] is DataGridViewColumn cGia)
            {
                cGia.HeaderText = "Giá vé (VNĐ)";
                cGia.DefaultCellStyle.Format = "N0";
                cGia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            if (dgvChuyenBay.Columns.Contains("TrangThai") && dgvChuyenBay.Columns["TrangThai"] is DataGridViewColumn cTT)
            {
                cTT.HeaderText = "Trạng thái";
                cTT.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        // Xử lý khi chọn một chuyến bay từ bảng
        private void HienThiThongTinChuyenBay(DataGridViewRow dong)
        {
            string layO(string tenCot, int viTri)
            {
                if (dgvChuyenBay.Columns.Contains(tenCot) && dong.Cells[tenCot].Value != null)
                    return dong.Cells[tenCot].Value?.ToString() ?? "";
                if (viTri < dong.Cells.Count && dong.Cells[viTri].Value != null)
                    return dong.Cells[viTri].Value?.ToString() ?? "";
                return "";
            }

            if (!int.TryParse(layO("MaChuyenBay", 0), out _maChuyenBayChon)) return;
            if (!int.TryParse(layO("MaMayBay", 1), out _maMayBayChon)) return;

            string sanBayDi    = layO("SanBayDi",  2);
            string sanBayDen   = layO("SanBayDen", 3);
            string thoiGianDi  = layO("ThoiGianDi",  4);
            string thoiGianDen = layO("ThoiGianDen", 5);
            string giaVeChuoi  = layO("GiaVe", 6);
            _trangThaiChuyenBay = layO("TrangThai", 7);

            if (decimal.TryParse(giaVeChuoi, out decimal giaVe))
                _giaVeChuyenBay = giaVe;

            DateTime.TryParse(thoiGianDi, out _thoiGianDi);
            DateTime.TryParse(thoiGianDen, out _thoiGianDen);

            lblChiTietChuyenBay.Text =
                $"Mã chuyến bay: {_maChuyenBayChon}  |  {sanBayDi}  =>  {sanBayDen}  |  " +
                $"Giờ đi: {_thoiGianDi:dd/MM/yyyy HH:mm}  |  Giờ đến: {_thoiGianDen:dd/MM/yyyy HH:mm}  |  " +
                $"Giá vé: {_giaVeChuyenBay:N0} VNĐ  |  Trạng thái: {_trangThaiChuyenBay}";

            txtGiaVe.Text = _giaVeChuyenBay.ToString("N0") + " VNĐ";

            LoadGheTrong();
        }

        // Xóa thông tin chuyến bay đã chọn
        private void XoaThongTinChuyenBayChon()
        {
            _maChuyenBayChon    = 0;
            _maMayBayChon       = 0;
            _giaVeChuyenBay     = 0;
            _trangThaiChuyenBay = "";
            _thoiGianDi         = DateTime.MinValue;
            _thoiGianDen        = DateTime.MinValue;
            lblChiTietChuyenBay.Text = "(Chưa chọn chuyến bay)";
            cboGhe.DataSource   = null;
            cboGhe.Items.Clear();
            txtGiaVe.Clear();
        }

        // Tải danh sách ghế trống của chuyến bay đã chọn
        private void LoadGheTrong()
        {
            cboGhe.DataSource = null;
            cboGhe.Items.Clear();

            if (_maChuyenBayChon <= 0 || _maMayBayChon <= 0) return;

            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT g.MaGhe, g.SoGhe, g.HangGhe
                        FROM GHE g
                        WHERE g.MaMayBay = @MaMayBay
                          AND (g.TrangThai = 'Trong' OR g.TrangThai = 'Trống')
                          AND NOT EXISTS (
                              SELECT 1 FROM VE v
                              WHERE v.MaChuyenBay = @MaChuyenBay
                                AND v.MaGhe = g.MaGhe
                                AND v.TrangThai NOT IN ('Đã hủy', 'Da huy')
                          )
                        ORDER BY g.HangGhe, g.SoGhe;";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@MaMayBay",    _maMayBayChon);
                        adapter.SelectCommand.Parameters.AddWithValue("@MaChuyenBay", _maChuyenBayChon);

                        DataTable dtGhe = new DataTable();
                        adapter.Fill(dtGhe);

                        dtGhe.Columns.Add("HienThi", typeof(string));
                        foreach (DataRow r in dtGhe.Rows)
                        {
                            string hangGhe = r["HangGhe"]?.ToString() ?? "";
                            if (hangGhe.Equals("Thuong gia", StringComparison.OrdinalIgnoreCase)) hangGhe = "Thương gia";
                            if (hangGhe.Equals("Pho thong", StringComparison.OrdinalIgnoreCase)) hangGhe = "Phổ thông";
                            r["HienThi"] = $"{r["SoGhe"]} ({hangGhe})";
                        }

                        cboGhe.DataSource     = dtGhe;
                        cboGhe.DisplayMember  = "HienThi";
                        cboGhe.ValueMember    = "MaGhe";
                        cboGhe.SelectedIndex  = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách ghế: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Kiểm tra ghế còn trống trong cơ sở dữ liệu
        private bool KiemTraGheTrongDB(MySqlConnection conn, MySqlTransaction tran)
        {
            if (cboGhe.SelectedValue == null) return false;
            if (!int.TryParse(cboGhe.SelectedValue.ToString(), out int maGhe)) return false;

            string query = @"
                SELECT COUNT(*) FROM VE
                WHERE MaChuyenBay = @MaChuyenBay
                  AND MaGhe = @MaGhe
                  AND TrangThai NOT IN ('Đã hủy', 'Da huy');";

            using (MySqlCommand cmd = new MySqlCommand(query, conn, tran))
            {
                cmd.Parameters.AddWithValue("@MaChuyenBay", _maChuyenBayChon);
                cmd.Parameters.AddWithValue("@MaGhe", maGhe);
                long soVe = (long)cmd.ExecuteScalar();
                return soVe == 0;
            }
        }

        // Lưu thông tin khách hàng
        private int LuuKhachHang(MySqlConnection conn, MySqlTransaction tran, string hoTen, string cccd, string sdt, string email)
        {
            if (!string.IsNullOrWhiteSpace(cccd))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT MaKH FROM KHACHHANG WHERE CCCD = @CCCD LIMIT 1;", conn, tran))
                {
                    cmd.Parameters.AddWithValue("@CCCD", cccd.Trim());
                    object? ket = cmd.ExecuteScalar();
                    if (ket != null) return Convert.ToInt32(ket);
                }
            }

            using (MySqlCommand cmd = new MySqlCommand("SELECT MaKH FROM KHACHHANG WHERE SDT = @SDT LIMIT 1;", conn, tran))
            {
                cmd.Parameters.AddWithValue("@SDT", sdt.Trim());
                object? ket = cmd.ExecuteScalar();
                if (ket != null) return Convert.ToInt32(ket);
            }

            string sqlInsert = @"
                INSERT INTO KHACHHANG (HoTen, CCCD, SDT, Email)
                VALUES (@HoTen, @CCCD, @SDT, @Email);
                SELECT LAST_INSERT_ID();";
            using (MySqlCommand cmd = new MySqlCommand(sqlInsert, conn, tran))
            {
                cmd.Parameters.AddWithValue("@HoTen", hoTen.Trim());
                cmd.Parameters.AddWithValue("@CCCD",  string.IsNullOrWhiteSpace(cccd)  ? (object)DBNull.Value : cccd.Trim());
                cmd.Parameters.AddWithValue("@SDT",   sdt.Trim());
                cmd.Parameters.AddWithValue("@Email", string.IsNullOrWhiteSpace(email) ? (object)DBNull.Value : email.Trim());
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // Đặt vé máy bay
        private void TaoVe(int maKH, int maGhe)
        {
            string sqlVe = @"
                INSERT INTO VE (MaChuyenBay, MaKH, MaGhe, NgayDat, GiaVe, TrangThai)
                VALUES (@MaChuyenBay, @MaKH, @MaGhe, NOW(), @GiaVe, 'Chờ thanh toán');
                SELECT LAST_INSERT_ID();";

            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();
                MySqlTransaction tran = conn.BeginTransaction();
                try
                {
                    if (!KiemTraGheTrongDB(conn, tran))
                    {
                        tran.Rollback();
                        MessageBox.Show("Ghế này đã được đặt. Vui lòng chọn ghế khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        LoadGheTrong();
                        return;
                    }

                    string hoTen = txtHoTen.Text.Trim();
                    string cccd  = txtCCCD.Text.Trim();
                    string sdt   = txtSDT.Text.Trim();
                    string email = txtEmail.Text.Trim();

                    int maKHDaDung = LuuKhachHang(conn, tran, hoTen, cccd, sdt, email);

                    int maVe;
                    using (MySqlCommand cmd = new MySqlCommand(sqlVe, conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@MaChuyenBay", _maChuyenBayChon);
                        cmd.Parameters.AddWithValue("@MaKH",   maKHDaDung);
                        cmd.Parameters.AddWithValue("@MaGhe",  maGhe);
                        cmd.Parameters.AddWithValue("@GiaVe",  _giaVeChuyenBay);
                        maVe = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    tran.Commit();

                    string soGheChon = cboGhe.Text;
                    MessageBox.Show(
                        $"Đặt vé thành công! Vé đang chờ thanh toán.\n\n" +
                        $"Mã vé: {maVe}\n" +
                        $"Khách hàng: {hoTen}\n" +
                        $"Chuyến bay: {_maChuyenBayChon}\n" +
                        $"Ghế: {soGheChon}\n" +
                        $"Giá vé: {_giaVeChuyenBay:N0} VNĐ\n" +
                        $"Trạng thái: Chờ thanh toán",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoadGheTrong();
                    XoaThongTinKhachHang();
                }
                catch (MySqlException ex)
                {
                    tran.Rollback();
                    MessageBox.Show("Lỗi MySQL khi đặt vé: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("Lỗi khi đặt vé: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Kiểm tra họ và tên
        private bool KiemTraHoTen(string hoTen)
        {
            if (string.IsNullOrWhiteSpace(hoTen))
                return false;

            return Regex.IsMatch(hoTen.Trim(), @"^[\p{L}\s]+$");
        }

        // Kiểm tra CCCD
        private bool KiemTraCCCD(string cccd)
        {
            if (string.IsNullOrWhiteSpace(cccd))
                return false;

            return Regex.IsMatch(cccd.Trim(), @"^\d{12}$");
        }

        // Kiểm tra số điện thoại
        private bool KiemTraSoDienThoai(string sdt)
        {
            if (string.IsNullOrWhiteSpace(sdt))
                return false;

            return Regex.IsMatch(sdt.Trim(), @"^\d{10}$");
        }

        // Kiểm tra email
        private bool KiemTraEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            return Regex.IsMatch(email.Trim(), @"^[^\s@]+@[^\s@]+\.[^\s@]+$");
        }

        // Kiểm tra dữ liệu trước khi đặt vé
        private bool KiemTraTruocKhiDat(out int maGhe)
        {
            maGhe = 0;

            if (_maChuyenBayChon <= 0)
            {
                MessageBox.Show("Vui lòng chọn chuyến bay!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (_trangThaiChuyenBay == "Đã hủy" || _trangThaiChuyenBay == "Da huy")
            {
                MessageBox.Show("Chuyến bay này đã bị hủy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (_trangThaiChuyenBay == "Đã cất cánh" || _trangThaiChuyenBay == "Da cat canh" || _trangThaiChuyenBay == "Hoàn tất" || _trangThaiChuyenBay == "Hoan tat")
            {
                MessageBox.Show("Chuyến bay này đã khởi hành, không thể đặt vé.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (_thoiGianDen != DateTime.MinValue && _thoiGianDi != DateTime.MinValue)
            {
                if (_thoiGianDen <= _thoiGianDi)
                {
                    MessageBox.Show("Thời gian đến phải sau thời gian đi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (_thoiGianDi <= DateTime.Now)
                {
                    MessageBox.Show("Không thể đặt chuyến bay đã quá thời gian khởi hành.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            if (cboGhe.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn ghế!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboGhe.Focus();
                return false;
            }

            if (!int.TryParse(cboGhe.SelectedValue.ToString(), out maGhe) || maGhe <= 0)
            {
                MessageBox.Show("Ghế không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!KiemTraHoTen(txtHoTen.Text))
            {
                MessageBox.Show("Họ và tên không hợp lệ. Vui lòng nhập họ và tên bằng chữ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return false;
            }

            if (!KiemTraCCCD(txtCCCD.Text))
            {
                MessageBox.Show("CCCD phải gồm đúng 12 chữ số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCCCD.Focus();
                return false;
            }

            if (!KiemTraSoDienThoai(txtSDT.Text))
            {
                MessageBox.Show("Số điện thoại phải gồm đúng 10 chữ số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return false;
            }

            if (!KiemTraEmail(txtEmail.Text))
            {
                MessageBox.Show("Email không đúng định dạng. Vui lòng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            return true;
        }

        // Xóa thông tin khách hàng trên form
        private void XoaThongTinKhachHang()
        {
            txtHoTen.Clear();
            txtCCCD.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
        }

        // Xử lý khi nhấn nút Tìm kiếm
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            TimKiemChuyenBay();
        }

        // Xử lý khi chọn một dòng trong bảng chuyến bay
        private void dgvChuyenBay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvChuyenBay.Rows.Count)
            {
                HienThiThongTinChuyenBay(dgvChuyenBay.Rows[e.RowIndex]);
            }
        }

        // Xử lý khi nhấn nút Đặt vé
        private void btnDatVe_Click(object sender, EventArgs e)
        {
            if (!KiemTraTruocKhiDat(out int maGhe)) return;
            TaoVe(0, maGhe);
        }
    }
}
