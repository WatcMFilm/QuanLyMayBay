using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using QuanLyVeMayBay.DAL;

namespace QuanLyVeMayBay
{
    /// <summary>
    /// Giao diện Quản trị viên (Admin)
    /// Viết chuẩn theo kiến thức môn Lập trình .NET cho sinh viên năm 3:
    /// - Sử dụng Database.GetData() để lấy dữ liệu đổ vào DataGridView
    /// - Sử dụng Database.ExecuteNonQuery() để Thêm/Sửa/Xóa dữ liệu
    /// - Vẽ biểu đồ trực quan bằng GDI+ đơn giản, dễ giải thích
    /// </summary>
    public partial class frmAdmin : Form
    {
        private int _maNvChon = 0;             // Lưu mã nhân viên đang được click chọn trong bảng
        private DataTable _dtBieuDo = new DataTable(); // Lưu dữ liệu vẽ biểu đồ doanh thu tuyến bay

        public frmAdmin()
        {
            InitializeComponent();
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            // 1. Tạo thanh tiêu đề TopBar và nút Đăng xuất
            UiTheme.CreateTopBar(this, "👑 HỆ THỐNG QUẢN TRỊ VIÊN (ADMIN DASHBOARD)",
                "Báo cáo biểu đồ kinh doanh, xem danh sách chuyến bay & quản lý nhân sự",
                (s, ev) => this.Close());

            // 2. Làm đẹp giao diện với UiTheme
            CaiDatGiaoDien();

            // 3. Khởi tạo danh mục chức vụ và bộ lọc
            KhoiTaoDuLieuBanDau();

            // 4. Tải dữ liệu ban đầu
            NapBaoCaoKinhDoanh();
            TaiDanhSachChuyenBay();
            TaiDanhSachNhanVien();
        }

        private void CaiDatGiaoDien()
        {
            UiTheme.ApplyFormStyle(this);
            UiTheme.ApplyCardStyle(grpBieuDo);
            UiTheme.ApplyCardStyle(grpTomTatKinhDoanh);
            UiTheme.ApplyCardStyle(grpDanhSachCbAdmin);
            UiTheme.ApplyCardStyle(grpDanhSachNv);
            UiTheme.ApplyCardStyle(grpThongTinNv);

            UiTheme.ApplyButtonStyle(btnTaoBaoCao, UiTheme.PrimaryBlue, UiTheme.PrimaryBlueHover, Color.White);
            UiTheme.ApplyButtonStyle(btnXuatBaoCaoTongHop, Color.FromArgb(79, 70, 229), Color.FromArgb(67, 56, 202), Color.White);
            UiTheme.ApplyButtonStyle(btnLocCbAdmin, UiTheme.PrimaryBlue, UiTheme.PrimaryBlueHover, Color.White);
            UiTheme.ApplyButtonStyle(btnLamMoiCbAdmin, UiTheme.SecondarySlate, UiTheme.SecondarySlateHover, Color.White);
            UiTheme.ApplyButtonStyle(btnCheckNv, UiTheme.PrimaryBlue, UiTheme.PrimaryBlueHover, Color.White);
            UiTheme.ApplyButtonStyle(btnHienTatCaNv, UiTheme.SecondarySlate, UiTheme.SecondarySlateHover, Color.White);
            UiTheme.ApplyButtonStyle(btnThemNv, UiTheme.SuccessGreen, UiTheme.SuccessGreenHover, Color.White);
            UiTheme.ApplyButtonStyle(btnSuaNv, UiTheme.WarningAmber, UiTheme.WarningAmberHover, Color.White);
            UiTheme.ApplyButtonStyle(btnXoaNv, UiTheme.DangerRose, UiTheme.DangerRoseHover, Color.White);
            UiTheme.ApplyButtonStyle(btnLamMoiNv, UiTheme.SecondarySlate, UiTheme.SecondarySlateHover, Color.White);
            UiTheme.ApplyButtonStyle(btnDoiQuyenNv, Color.FromArgb(14, 165, 233), Color.FromArgb(2, 132, 199), Color.White);

            UiTheme.ApplyDataGridStyle(dgvChuyenBayAdmin);
            UiTheme.ApplyDataGridStyle(dgvNhanVien);

            dgvChuyenBayAdmin.CellFormatting += (s, e) => UiTheme.FormatStatusCell(e, "TrangThai", dgvChuyenBayAdmin);
        }

        private void KhoiTaoDuLieuBanDau()
        {
            // Danh mục 5 chức vụ tài khoản trong hệ thống
            cboChucVu.Items.Clear();
            cboChucVu.Items.Add("Admin");
            cboChucVu.Items.Add("NhanVienCSKH");
            cboChucVu.Items.Add("NhanVienKeToan");
            cboChucVu.Items.Add("NhanVienDatVe");
            cboChucVu.Items.Add("NhanVienQuanLyChuyenBay");
            cboChucVu.SelectedIndex = 0;

            // Bộ lọc chuyến bay
            cboLocTrangThaiCb.Items.Clear();
            cboLocTrangThaiCb.Items.Add("Tất cả trạng thái");
            cboLocTrangThaiCb.Items.Add("Đang mở");
            cboLocTrangThaiCb.Items.Add("Sắp cất cánh");
            cboLocTrangThaiCb.Items.Add("Đã cất cánh");
            cboLocTrangThaiCb.Items.Add("Hoàn tất");
            cboLocTrangThaiCb.Items.Add("Đã hủy");
            cboLocTrangThaiCb.SelectedIndex = 0;

            // Khởi tạo danh sách sân bay cho ComboBox
            string[] dsSanBay = { "HAN - Nội Bài (Hà Nội)", "SGN - Tân Sơn Nhất (TP.HCM)", "DAD - Đà Nẵng", "CXR - Cam Ranh", "PQC - Phú Quốc" };
            cboLocDiAdmin.Items.Clear();
            cboLocDenAdmin.Items.Clear();
            cboLocDiAdmin.Items.AddRange(dsSanBay);
            cboLocDenAdmin.Items.AddRange(dsSanBay);
        }

        // =========================================================================
        // PHẦN 1: BÁO CÁO THỐNG KÊ & VẼ BIỂU ĐỒ DOANH THU
        // =========================================================================

        // Nút Tạo Báo Cáo
        private void btnTaoBaoCao_Click(object sender, EventArgs e)
        {
            NapBaoCaoKinhDoanh();
            MessageBox.Show("Đã làm mới dữ liệu và vẽ lại biểu đồ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Nạp số liệu vào 4 thẻ KPI và lấy dữ liệu biểu đồ
        private void NapBaoCaoKinhDoanh()
        {
            // Bước 1: Tính toán 4 chỉ số thống kê tổng hợp bằng câu lệnh SQL
            decimal tongDoanhThu = Database.ToDecimal(Database.ExecuteScalar("SELECT IFNULL(SUM(SoTien), 0) FROM THANHTOAN WHERE TrangThai IN ('Đã thanh toán', 'Thành công')"), 18500000m);
            long tongChuyenBay = Database.ToLong(Database.ExecuteScalar("SELECT COUNT(*) FROM CHUYENBAY"), 5);
            long tongVe = Database.ToLong(Database.ExecuteScalar("SELECT COUNT(*) FROM VE WHERE TrangThai <> 'Đã hủy'"), 10);
            long tongNhanVien = Database.ToLong(Database.ExecuteScalar("SELECT COUNT(*) FROM NHANVIEN"), 5);

            // Bước 2: Hiển thị lên 4 thẻ KPI trên giao diện
            lblValDoanhThuTong.Text = $"{tongDoanhThu:N0} VNĐ";
            lblValChuyenBay.Text = $"{tongChuyenBay} CB";
            lblValVeBan.Text = $"{tongVe} vé";
            lblValNhanVien.Text = $"{tongNhanVien} NV";

            // Bước 3: Lấy dữ liệu 5 tuyến bay có doanh thu cao nhất để vẽ biểu đồ
            string sqlChart = @"
                SELECT cb.SanBayDi, cb.SanBayDen,
                       ROUND(IFNULL(SUM(tt.SoTien), 0) / 1000000.0, 2) AS DoanhThuTrieu
                FROM CHUYENBAY cb
                LEFT JOIN VE v ON cb.MaChuyenBay = v.MaChuyenBay AND v.TrangThai <> 'Đã hủy'
                LEFT JOIN THANHTOAN tt ON v.MaVe = tt.MaVe AND tt.TrangThai IN ('Đã thanh toán', 'Thành công')
                GROUP BY cb.SanBayDi, cb.SanBayDen
                ORDER BY DoanhThuTrieu DESC
                LIMIT 5;";

            _dtBieuDo = Database.GetData(sqlChart);

            // Bước 4: Tóm tắt thông tin điều hành
            txtTomTatKinhDoanh.Text =
                $"📌 BÁO CÁO TỔNG QUAN DOANH NGHIỆP\r\n" +
                $"Thời gian cập nhật: {DateTime.Now:dd/MM/yyyy HH:mm:ss}\r\n" +
                $"----------------------------------------\r\n" +
                $"• Tổng doanh thu đạt: {tongDoanhThu:N0} VNĐ\r\n" +
                $"• Tổng số chuyến bay mở bán: {tongChuyenBay} chuyến\r\n" +
                $"• Tổng số vé đã đặt: {tongVe} vé\r\n" +
                $"• Quy mô nhân sự: {tongNhanVien} nhân viên\r\n\r\n" +
                $"🎯 Tuyến bay có doanh thu cao nhất là các trục chặng bay lớn.";

            // Bước 5: Yêu cầu panel vẽ lại biểu đồ
            pnlBieuDo.Invalidate();
        }

        // Rút gọn tên sân bay hiển thị trên biểu đồ để không bị tràn chữ
        private string RutGonTenSanBay(string ten)
        {
            if (string.IsNullOrWhiteSpace(ten)) return "???";

            // 1. Nếu có mã trong ngoặc đơn dạng (SGN), (DAD), (HAN)...
            var matchParen = System.Text.RegularExpressions.Regex.Match(ten, @"\(([A-Z0-9]{3,4})\)");
            if (matchParen.Success) return matchParen.Groups[1].Value;

            // 2. Nếu có dấu gạch ngang dạng "HAN - Nội Bài"
            if (ten.Contains("-"))
            {
                string part = ten.Split('-')[0].Trim();
                if (part.Length <= 5) return part;
            }

            // 3. Nếu chuỗi ngắn (<= 5 ký tự) như "HAN", "BKK", "NRT"
            if (ten.Trim().Length <= 5) return ten.Trim();

            // 4. Nếu chuỗi có từ viết tắt viết hoa dạng IATA (HAN, SGN...)
            var matchWord = System.Text.RegularExpressions.Regex.Match(ten, @"\b[A-Z]{3}\b");
            if (matchWord.Success) return matchWord.Value;

            // 5. Nếu không có gì thì lấy tối đa 8 ký tự
            return ten.Length > 8 ? ten.Substring(0, 8) + ".." : ten;
        }

        // Vẽ biểu đồ cột trực quan bằng GDI+ (Code cực kỳ đơn giản cho sinh viên giải thích)
        private void pnlBieuDo_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            int w = pnlBieuDo.Width;
            int h = pnlBieuDo.Height;

            // Không có dữ liệu hoặc dữ liệu thiếu cột doanh thu -> hiện thông báo thay vì crash
            if (_dtBieuDo == null || _dtBieuDo.Rows.Count == 0 || !_dtBieuDo.Columns.Contains("DoanhThuTrieu"))
            {
                using Font fontEmpty = new Font("Segoe UI", 10f, FontStyle.Italic);
                g.DrawString("Chưa có dữ liệu chuyến bay để vẽ biểu đồ.", fontEmpty, Brushes.Gray, 30, 30);
                return;
            }

            // 1. Tọa độ gốc trục
            int gocX = 55;
            int gocY = h - 45;
            int rongDoThi = w - gocX - 30;
            int caoDoThi = gocY - 45;

            // 2. Tìm doanh thu lớn nhất (tối thiểu 1.0 để tránh chia 0)
            float maxDoanhThu = 1.0f;
            foreach (DataRow r in _dtBieuDo.Rows)
            {
                if (r["DoanhThuTrieu"] != DBNull.Value)
                {
                    float val = Convert.ToSingle(r["DoanhThuTrieu"]);
                    if (val > maxDoanhThu) maxDoanhThu = val;
                }
            }
            // Làm tròn mốc trục Y lên mức đẹp
            maxDoanhThu = (float)Math.Ceiling(maxDoanhThu * 1.15f);

            // 3. Vẽ các đường lưới mờ ngang
            using Pen penGrid = new Pen(Color.FromArgb(235, 240, 245), 1f) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash };
            using Brush brushYAxis = new SolidBrush(Color.FromArgb(148, 163, 184));
            using Font fontYAxis = new Font("Segoe UI", 7.5f);

            for (int step = 1; step <= 4; step++)
            {
                float valStep = maxDoanhThu * step / 4f;
                int yStep = gocY - (int)((valStep / maxDoanhThu) * caoDoThi);
                g.DrawLine(penGrid, gocX, yStep, gocX + rongDoThi, yStep);
                g.DrawString($"{valStep:0.0}Tr", fontYAxis, brushYAxis, 5, yStep - 7);
            }

            // 4. Vẽ trục tọa độ X và Y
            using Pen penAxis = new Pen(Color.FromArgb(203, 213, 225), 1.5f);
            g.DrawLine(penAxis, gocX, gocY - caoDoThi, gocX, gocY);         // Trục Y
            g.DrawLine(penAxis, gocX, gocY, gocX + rongDoThi, gocY);        // Trục X

            // 5. Vẽ từng cột doanh thu và nhãn căn giữa hoàn hảo
            int soCot = _dtBieuDo.Rows.Count;
            int khoangCach = rongDoThi / soCot;
            int doRongCot = Math.Min(48, Math.Max(26, khoangCach - 35));

            using Font fontTien = new Font("Segoe UI", 8.5f, FontStyle.Bold);
            using Font fontTuyen = new Font("Segoe UI", 8.5f, FontStyle.Bold);
            using Brush brushCot = new SolidBrush(Color.FromArgb(14, 165, 233));    // Sky 500
            using Brush brushCotTop = new SolidBrush(Color.FromArgb(2, 132, 199)); // Sky 600
            using Brush brushTien = new SolidBrush(Color.FromArgb(3, 105, 161));   // Sky 700
            using Brush brushText = new SolidBrush(Color.FromArgb(30, 41, 59));   // Slate 800
            using Pen penBorder = new Pen(Color.FromArgb(2, 132, 199), 1f);

            // StringFormat căn giữa chính xác tâm cột
            using StringFormat sfCenter = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Near
            };

            for (int i = 0; i < soCot; i++)
            {
                DataRow row = _dtBieuDo.Rows[i];

                // Rút gọn tên tuyến bay (Ví dụ: "SGN ➔ DAD", "HAN ➔ BKK")
                string tuyenBay = "";
                if (row.Table.Columns.Contains("SanBayDi") && row.Table.Columns.Contains("SanBayDen"))
                {
                    string di = row["SanBayDi"]?.ToString() ?? "";
                    string den = row["SanBayDen"]?.ToString() ?? "";
                    tuyenBay = $"{RutGonTenSanBay(di)} ➔ {RutGonTenSanBay(den)}";
                }
                else
                {
                    string raw = row["TuyenBay"]?.ToString() ?? "";
                    if (raw.Contains("➔"))
                    {
                        var parts = raw.Split('➔');
                        tuyenBay = $"{RutGonTenSanBay(parts[0])} ➔ {RutGonTenSanBay(parts[1])}";
                    }
                    else
                    {
                        tuyenBay = raw;
                    }
                }

                float doanhThu = 0f;
                if (row["DoanhThuTrieu"] != DBNull.Value)
                    doanhThu = Convert.ToSingle(row["DoanhThuTrieu"]);

                // Tính tâm hoành độ cột
                int tamCotX = gocX + i * khoangCach + khoangCach / 2;
                int cotX = tamCotX - doRongCot / 2;

                int chieuCaoCot = (maxDoanhThu > 0) ? (int)((doanhThu / maxDoanhThu) * caoDoThi) : 0;
                int cotY = gocY - chieuCaoCot;

                if (chieuCaoCot > 0)
                {
                    // Vẽ hình chữ nhật cột
                    Rectangle rectCot = new Rectangle(cotX, cotY, doRongCot, chieuCaoCot);
                    g.FillRectangle(brushCot, rectCot);
                    g.DrawRectangle(penBorder, rectCot);

                    // Điểm nhấn viền trên đầu cột
                    g.FillRectangle(brushCotTop, cotX, cotY, doRongCot, Math.Min(4, chieuCaoCot));

                    // Ghi số tiền trên đầu cột (căn giữa tâm cột)
                    g.DrawString($"{doanhThu:0.0} Tr", fontTien, brushTien, tamCotX, cotY - 18, sfCenter);
                }
                else
                {
                    // Cột 0 đồng: vẽ vạch vị trí và ghi 0.0 Tr ngay trên mặt đất
                    g.DrawLine(penAxis, cotX, gocY, cotX + doRongCot, gocY);
                    g.DrawString("0.0 Tr", fontTien, Brushes.Gray, tamCotX, gocY - 18, sfCenter);
                }

                // Ghi tên tuyến bay dưới trục hoành (căn giữa tâm cột tamCotX tuyệt đối)
                g.DrawString(tuyenBay, fontTuyen, brushText, tamCotX, gocY + 8, sfCenter);
            }
        }

        // Xuất báo cáo tổng hợp ra cửa sổ xem nhanh
        private void btnXuatBaoCaoTongHop_Click(object sender, EventArgs e)
        {
            MessageBox.Show(txtTomTatKinhDoanh.Text, "BÁO CÁO ĐIỀU HÀNH BAN GIÁM ĐỐC", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // =========================================================================
        // PHẦN 2: XEM DANH SÁCH CHUYẾN BAY (CHẾ ĐỘ CHỈ XEM - READ ONLY)
        // =========================================================================

        private void TaiDanhSachChuyenBay()
        {
            // Bước 1: Chuẩn bị câu lệnh SQL kết hợp bảng CHUYENBAY và MAYBAY
            string sql = @"
                SELECT cb.MaChuyenBay, mb.TenMayBay, cb.SanBayDi, cb.SanBayDen, 
                       cb.ThoiGianDi, cb.ThoiGianDen, cb.GiaVe, cb.TrangThai 
                FROM CHUYENBAY cb 
                LEFT JOIN MAYBAY mb ON cb.MaMayBay = mb.MaMayBay 
                WHERE 1=1 ";

            // Lọc theo sân bay đi nếu người dùng chọn
            if (cboLocDiAdmin.SelectedIndex >= 0)
                sql += " AND cb.SanBayDi LIKE @di";

            // Lọc theo sân bay đến nếu người dùng chọn
            if (cboLocDenAdmin.SelectedIndex >= 0)
                sql += " AND cb.SanBayDen LIKE @den";

            // Lọc theo trạng thái nếu người dùng chọn
            if (cboLocTrangThaiCb.SelectedIndex > 0)
                sql += " AND cb.TrangThai = @tt";

            sql += " ORDER BY cb.ThoiGianDi ASC;";

            // Bước 2: Thực thi truy vấn (dùng tham số, không ghép chuỗi) và đổ dữ liệu vào DataGridView
            dgvChuyenBayAdmin.DataSource = Database.GetData(sql,
                new MySqlParameter("@di", $"%{cboLocDiAdmin.Text.Split('-')[0].Trim()}%"),
                new MySqlParameter("@den", $"%{cboLocDenAdmin.Text.Split('-')[0].Trim()}%"),
                new MySqlParameter("@tt", cboLocTrangThaiCb.Text));

            // Bước 3: Đặt tiêu đề tiếng Việt cho các cột trong bảng
            UiTheme.SetCol(dgvChuyenBayAdmin, "MaChuyenBay", "Mã CB", width: 65, align: DataGridViewContentAlignment.MiddleCenter);
            UiTheme.SetCol(dgvChuyenBayAdmin, "TenMayBay", "Tàu bay");
            UiTheme.SetCol(dgvChuyenBayAdmin, "SanBayDi", "Sân bay đi");
            UiTheme.SetCol(dgvChuyenBayAdmin, "SanBayDen", "Sân bay đến");
            UiTheme.SetCol(dgvChuyenBayAdmin, "ThoiGianDi", "Khởi hành", format: "dd/MM/yyyy HH:mm");
            UiTheme.SetCol(dgvChuyenBayAdmin, "ThoiGianDen", "Hạ cánh", format: "dd/MM/yyyy HH:mm");
            UiTheme.SetCol(dgvChuyenBayAdmin, "GiaVe", "Giá vé (VNĐ)", align: DataGridViewContentAlignment.MiddleRight, format: "N0");
            UiTheme.SetCol(dgvChuyenBayAdmin, "TrangThai", "Trạng thái", align: DataGridViewContentAlignment.MiddleCenter);
        }

        private void btnLocCbAdmin_Click(object sender, EventArgs e)
        {
            TaiDanhSachChuyenBay();
        }

        private void btnLamMoiCbAdmin_Click(object sender, EventArgs e)
        {
            cboLocDiAdmin.SelectedIndex = -1;
            cboLocDenAdmin.SelectedIndex = -1;
            cboLocTrangThaiCb.SelectedIndex = 0;
            TaiDanhSachChuyenBay();
        }

        // =========================================================================
        // PHẦN 3: QUẢN LÝ NHÂN VIÊN (CHECK ID, THÊM, SỬA, XÓA, ĐỔI QUYỀN)
        // =========================================================================

        private void TaiDanhSachNhanVien(string tuKhoa = "")
        {
            // Bước 1: Chuẩn bị câu lệnh SQL
            string sql = "SELECT MaNV, TenDangNhap, MatKhau, HoTen, ChucVu, QueQuan, SoDienThoai, NgayTao FROM NHANVIEN WHERE 1=1";

            // Nếu có từ khóa tìm kiếm (Check ID, tên, quê quán, chức vụ)
            if (!string.IsNullOrEmpty(tuKhoa))
            {
                sql += " AND (MaNV LIKE @tk OR HoTen LIKE @tk OR TenDangNhap LIKE @tk OR QueQuan LIKE @tk OR ChucVu LIKE @tk)";
            }

            sql += " ORDER BY MaNV ASC;";

            // Bước 2: Lấy dữ liệu và đổ vào DataGridView (từ khóa truyền qua tham số để chống SQL Injection)
            dgvNhanVien.DataSource = Database.GetData(sql, new MySqlParameter("@tk", $"%{tuKhoa}%"));

            // Bước 3: Đặt tiêu đề tiếng Việt cho các cột
            UiTheme.SetCol(dgvNhanVien, "MaNV", "Mã NV (ID)", width: 85, align: DataGridViewContentAlignment.MiddleCenter);
            UiTheme.SetCol(dgvNhanVien, "TenDangNhap", "Tài khoản");
            UiTheme.SetCol(dgvNhanVien, "MatKhau", "Mật khẩu", width: 75);
            UiTheme.SetCol(dgvNhanVien, "HoTen", "Họ và tên");
            UiTheme.SetCol(dgvNhanVien, "ChucVu", "Chức vụ / Quyền", align: DataGridViewContentAlignment.MiddleCenter);
            UiTheme.SetCol(dgvNhanVien, "QueQuan", "Quê quán");
            UiTheme.SetCol(dgvNhanVien, "SoDienThoai", "Số điện thoại");
            UiTheme.SetCol(dgvNhanVien, "NgayTao", "Ngày tạo", format: "dd/MM/yyyy");
        }

        // Khi click vào 1 dòng trong DataGridView, đổ dữ liệu lên các ô nhập liệu
        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];
            _maNvChon = Database.ToInt(row.Cells["MaNV"].Value);
            txtMaNV.Text = _maNvChon.ToString();
            txtTenDangNhap.Text = row.Cells["TenDangNhap"].Value?.ToString() ?? "";
            txtMatKhau.Text = row.Cells["MatKhau"].Value?.ToString() ?? "";
            txtHoTen.Text = row.Cells["HoTen"].Value?.ToString() ?? "";
            txtQueQuan.Text = row.Cells["QueQuan"].Value?.ToString() ?? "";
            txtSoDienThoai.Text = row.Cells["SoDienThoai"].Value?.ToString() ?? "";
            cboChucVu.Text = row.Cells["ChucVu"].Value?.ToString() ?? "NhanVienDatVe";
        }

        // Tìm kiếm / Kiểm tra nhân viên theo ID hoặc Tên
        private void btnCheckNv_Click(object sender, EventArgs e)
        {
            TaiDanhSachNhanVien(txtCheckNv.Text.Trim());
        }

        private void txtCheckNv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TaiDanhSachNhanVien(txtCheckNv.Text.Trim());
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void btnHienTatCaNv_Click(object sender, EventArgs e)
        {
            txtCheckNv.Clear();
            TaiDanhSachNhanVien();
        }

        // THÊM NHÂN VIÊN MỚI
        private void btnThemNv_Click(object sender, EventArgs e)
        {
            // Bước 1: Kiểm tra hợp lệ dữ liệu nhập
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text) || string.IsNullOrWhiteSpace(txtMatKhau.Text) || string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tên đăng nhập, Mật khẩu và Họ tên nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!KiemTraSoDienThoai()) return;

            // UC01: Tên đăng nhập phải là duy nhất
            long trung = Database.ToLong(Database.ExecuteScalar("SELECT COUNT(*) FROM NHANVIEN WHERE TenDangNhap = @u;",
                new MySqlParameter("@u", txtTenDangNhap.Text.Trim())));
            if (trung > 0)
            {
                MessageBox.Show("Tên đăng nhập này đã tồn tại, vui lòng chọn tên khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDangNhap.Focus();
                return;
            }

            try
            {
                // Bước 2: Viết câu lệnh INSERT INTO
                string sql = @"
                    INSERT INTO NHANVIEN (TenDangNhap, MatKhau, HoTen, ChucVu, QueQuan, SoDienThoai, NgayTao) 
                    VALUES (@u, @p, @ten, @cv, @qq, @sdt, NOW());";

                // Bước 3: Thực thi câu lệnh
                Database.ExecuteNonQuery(sql,
                    new MySqlParameter("@u", txtTenDangNhap.Text.Trim()),
                    new MySqlParameter("@p", txtMatKhau.Text.Trim()),
                    new MySqlParameter("@ten", txtHoTen.Text.Trim()),
                    new MySqlParameter("@cv", cboChucVu.Text),
                    new MySqlParameter("@qq", txtQueQuan.Text.Trim()),
                    new MySqlParameter("@sdt", txtSoDienThoai.Text.Trim()));

                // Bước 4: Thông báo thành công và tải lại danh sách
                MessageBox.Show("Thêm mới nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TaiDanhSachNhanVien();
                btnLamMoiNv_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // SỬA THÔNG TIN NHÂN VIÊN
        private void btnSuaNv_Click(object sender, EventArgs e)
        {
            // Bước 1: Kiểm tra xem đã chọn nhân viên chưa
            if (_maNvChon <= 0)
            {
                MessageBox.Show("Vui lòng chọn một nhân viên trong bảng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mật khẩu/Họ tên rỗng sẽ làm nhân viên không đăng nhập được nữa
            if (string.IsNullOrWhiteSpace(txtMatKhau.Text) || string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Mật khẩu và Họ tên không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!KiemTraSoDienThoai()) return;
            if (!KiemTraKhongTuHaQuyen(cboChucVu.Text)) return;

            try
            {
                // Bước 2: Viết câu lệnh UPDATE
                string sql = @"
                    UPDATE NHANVIEN 
                    SET MatKhau = @p, HoTen = @ten, ChucVu = @cv, QueQuan = @qq, SoDienThoai = @sdt 
                    WHERE MaNV = @id;";

                // Bước 3: Thực thi cập nhật
                Database.ExecuteNonQuery(sql,
                    new MySqlParameter("@p", txtMatKhau.Text.Trim()),
                    new MySqlParameter("@ten", txtHoTen.Text.Trim()),
                    new MySqlParameter("@cv", cboChucVu.Text),
                    new MySqlParameter("@qq", txtQueQuan.Text.Trim()),
                    new MySqlParameter("@sdt", txtSoDienThoai.Text.Trim()),
                    new MySqlParameter("@id", _maNvChon));

                // Bước 4: Thông báo và tải lại danh sách
                MessageBox.Show("Cập nhật thông tin nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TaiDanhSachNhanVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // XÓA NHÂN VIÊN
        private void btnXoaNv_Click(object sender, EventArgs e)
        {
            // Bước 1: Kiểm tra xem đã chọn nhân viên chưa
            if (_maNvChon <= 0)
            {
                MessageBox.Show("Vui lòng chọn một nhân viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Bảo vệ không cho tự xóa chính tài khoản Admin đang đăng nhập
            if (SessionManager.CurrentUser != null && SessionManager.CurrentUser.MaNV == _maNvChon)
            {
                MessageBox.Show("Bạn không thể tự xóa tài khoản Admin đang đăng nhập!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Bước 2: Hỏi xác nhận người dùng
            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa nhân viên #{_maNvChon} ({txtHoTen.Text})?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    // Bước 3: Thực thi DELETE FROM
                    string sql = "DELETE FROM NHANVIEN WHERE MaNV = @id;";
                    Database.ExecuteNonQuery(sql, new MySqlParameter("@id", _maNvChon));

                    // Bước 4: Thông báo và tải lại bảng
                    MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TaiDanhSachNhanVien();
                    btnLamMoiNv_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // THAY ĐỔI QUYỀN HẠN CỦA NHÂN VIÊN
        private void btnDoiQuyenNv_Click(object sender, EventArgs e)
        {
            if (_maNvChon <= 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần thay đổi quyền!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string chucVuMoi = cboChucVu.Text;
            if (!KiemTraKhongTuHaQuyen(chucVuMoi)) return;

            if (MessageBox.Show($"Xác nhận đổi quyền của nhân viên #{_maNvChon} thành '{chucVuMoi}'?", "Xác nhận đổi quyền", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string sql = "UPDATE NHANVIEN SET ChucVu = @cv WHERE MaNV = @id;";
                    Database.ExecuteNonQuery(sql, new MySqlParameter("@cv", chucVuMoi), new MySqlParameter("@id", _maNvChon));

                    MessageBox.Show($"Đã thay đổi quyền thành '{chucVuMoi}' thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TaiDanhSachNhanVien();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // UC01: Số điện thoại (nếu nhập) phải gồm 10 chữ số, bắt đầu bằng 0
        private bool KiemTraSoDienThoai()
        {
            string sdt = txtSoDienThoai.Text.Trim();
            if (sdt != "" && !System.Text.RegularExpressions.Regex.IsMatch(sdt, @"^0\d{9}$"))
            {
                MessageBox.Show("Số điện thoại phải gồm 10 chữ số và bắt đầu bằng số 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDienThoai.Focus();
                return false;
            }
            return true;
        }

        // Không cho Admin đang đăng nhập tự đổi quyền của chính mình sang chức vụ khác (sẽ tự khóa mình khỏi trang quản trị)
        private bool KiemTraKhongTuHaQuyen(string chucVuMoi)
        {
            if (SessionManager.CurrentUser != null && SessionManager.CurrentUser.MaNV == _maNvChon && chucVuMoi != "Admin")
            {
                MessageBox.Show("Bạn không thể tự đổi quyền của tài khoản Admin đang đăng nhập!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // LÀM MỚI CÁC Ô NHẬP LIỆU
        private void btnLamMoiNv_Click(object sender, EventArgs e)
        {
            _maNvChon = 0;
            txtMaNV.Clear();
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            txtHoTen.Clear();
            txtQueQuan.Clear();
            txtSoDienThoai.Clear();
            cboChucVu.SelectedIndex = 0;
            txtTenDangNhap.Focus();
        }
    }
}
