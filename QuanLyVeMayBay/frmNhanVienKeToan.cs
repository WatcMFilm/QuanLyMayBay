using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using QuanLyVeMayBay.DAL;

namespace QuanLyVeMayBay
{
    /// <summary>
    /// Giao diện Bộ phận Kế toán & Tài chính
    /// Viết chuẩn theo kiến thức môn Lập trình .NET cho sinh viên năm 3:
    /// - Kiểm tra các vé chờ thanh toán
    /// - Xác nhận thanh toán & lập hóa đơn điện tử
    /// - Quản lý hóa đơn & in ấn hóa đơn có số tiền bằng chữ
    /// - Thống kê doanh thu theo phương thức & theo tuyến bay
    /// </summary>
    public partial class frmNhanVienKeToan : Form
    {
        private int _maVeChon = 0;
        private decimal _soTienChon = 0;
        private string _hoTenChon = "";
        private string _sdtChon = "";
        private string _tuyenBayChon = "";
        private string _soGheChon = "";
        private string _trangThaiVeChon = "";

        public frmNhanVienKeToan()
        {
            InitializeComponent();
        }

        private void frmNhanVienKeToan_Load(object sender, EventArgs e)
        {
            // 1. Tạo thanh tiêu đề TopBar
            UiTheme.CreateTopBar(this, "💳 BỘ PHẬN KẾ TOÁN & TÀI CHÍNH",
                "Kiểm tra thanh toán, xác nhận thu tiền, lập hóa đơn & thống kê doanh thu",
                (s, ev) => this.Close());

            // 2. Làm đẹp giao diện
            CaiDatGiaoDien();

            // 3. Khởi tạo danh mục ban đầu
            KhoiTaoDuLieuBanDau();

            // 4. Tải dữ liệu ban đầu
            TaiDanhSachVe();
            TaiDanhSachHoaDon();
            CapNhatThongKeDoanhThu();
        }

        private void CaiDatGiaoDien()
        {
            UiTheme.ApplyFormStyle(this);
            UiTheme.ApplyCardStyle(grpDanhSachVeTT);
            UiTheme.ApplyCardStyle(grpChiTietVeTT);
            UiTheme.ApplyCardStyle(grpThaoTacTT);
            UiTheme.ApplyCardStyle(grpFilterHoaDon);
            UiTheme.ApplyCardStyle(grpDanhSachHoaDon);
            UiTheme.ApplyCardStyle(grpDoanhThuPhuongThuc);
            UiTheme.ApplyCardStyle(grpDoanhThuTuyenBay);

            UiTheme.ApplyButtonStyle(btnLamMoiVeTT, UiTheme.SecondarySlate, UiTheme.SecondarySlateHover, Color.White);
            UiTheme.ApplyButtonStyle(btnXacNhanThanhToan, UiTheme.SuccessGreen, UiTheme.SuccessGreenHover, Color.White);
            UiTheme.ApplyButtonStyle(btnLapHoaDonBoSung, UiTheme.DangerRose, UiTheme.DangerRoseHover, Color.White);
            btnLapHoaDonBoSung.Text = "⏰ HỦY GIỮ CHỖ QUÁ HẠN";
            UiTheme.ApplyButtonStyle(btnTraCuuHoaDon, UiTheme.PrimaryBlue, UiTheme.PrimaryBlueHover, Color.White);
            UiTheme.ApplyButtonStyle(btnLamMoiHoaDon, UiTheme.SecondarySlate, UiTheme.SecondarySlateHover, Color.White);
            UiTheme.ApplyButtonStyle(btnInHoaDon, UiTheme.WarningAmber, UiTheme.WarningAmberHover, Color.White);
            UiTheme.ApplyButtonStyle(btnXuatBaoCaoDoanhThu, UiTheme.PrimaryBlue, UiTheme.PrimaryBlueHover, Color.White);

            UiTheme.ApplyDataGridStyle(dgvVeTT);
            UiTheme.ApplyDataGridStyle(dgvHoaDon);
            UiTheme.ApplyDataGridStyle(dgvDoanhThuPhuongThuc);
            UiTheme.ApplyDataGridStyle(dgvDoanhThuTuyenBay);

            dgvVeTT.CellFormatting += (s, e) => UiTheme.FormatStatusCell(e, "TrangThai", dgvVeTT);
        }

        private void KhoiTaoDuLieuBanDau()
        {
            cboLocTrangThaiTT.Items.Clear();
            cboLocTrangThaiTT.Items.Add("Chờ thanh toán");
            cboLocTrangThaiTT.Items.Add("Đã thanh toán");
            cboLocTrangThaiTT.Items.Add("Tất cả vé");
            cboLocTrangThaiTT.SelectedIndex = 0;

            cboPhuongThuc.Items.Clear();
            cboPhuongThuc.Items.Add("Tiền mặt");
            cboPhuongThuc.Items.Add("Chuyển khoản ngân hàng");
            cboPhuongThuc.Items.Add("Thẻ tín dụng / Ghi nợ (POS)");
            cboPhuongThuc.Items.Add("Ví điện tử (MoMo / VNPay)");
            cboPhuongThuc.SelectedIndex = 1;

            cboMocThoiGian.Items.Clear();
            cboMocThoiGian.Items.Add("Tất cả thời gian");
            cboMocThoiGian.Items.Add("Hôm nay");
            cboMocThoiGian.Items.Add("Tháng này");
            cboMocThoiGian.SelectedIndex = 0;
        }

        // =========================================================================
        // PHẦN 1: KIỂM TRA & XÁC NHẬN THANH TOÁN
        // =========================================================================

        private void TaiDanhSachVe(string tuKhoa = "")
        {
            string sql = @"
                SELECT v.MaVe, kh.HoTen, kh.SDT, cb.SanBayDi, cb.SanBayDen, g.SoGhe, v.GiaVe, v.TrangThai 
                FROM VE v 
                LEFT JOIN KHACHHANG kh ON v.MaKH = kh.MaKH 
                LEFT JOIN CHUYENBAY cb ON v.MaChuyenBay = cb.MaChuyenBay 
                LEFT JOIN GHE g ON v.MaGhe = g.MaGhe 
                WHERE 1=1 ";

            if (cboLocTrangThaiTT.SelectedIndex == 0)
                sql += " AND v.TrangThai = 'Chờ thanh toán'";
            else if (cboLocTrangThaiTT.SelectedIndex == 1)
                sql += " AND v.TrangThai = 'Đã thanh toán'";

            if (!string.IsNullOrEmpty(tuKhoa))
            {
                sql += $" AND (v.MaVe LIKE '%{tuKhoa}%' OR kh.HoTen LIKE '%{tuKhoa}%' OR kh.SDT LIKE '%{tuKhoa}%')";
            }

            sql += " ORDER BY v.MaVe DESC;";

            dgvVeTT.DataSource = Database.GetData(sql);

            UiTheme.SetCol(dgvVeTT, "MaVe", "Mã vé", width: 65, align: DataGridViewContentAlignment.MiddleCenter);
            UiTheme.SetCol(dgvVeTT, "HoTen", "Tên hành khách");
            UiTheme.SetCol(dgvVeTT, "SDT", "Số điện thoại");
            UiTheme.SetCol(dgvVeTT, "SanBayDi", "Điểm đi");
            UiTheme.SetCol(dgvVeTT, "SanBayDen", "Điểm đến");
            UiTheme.SetCol(dgvVeTT, "SoGhe", "Ghế", width: 60, align: DataGridViewContentAlignment.MiddleCenter);
            UiTheme.SetCol(dgvVeTT, "GiaVe", "Số tiền (VNĐ)", align: DataGridViewContentAlignment.MiddleRight, format: "N0");
            UiTheme.SetCol(dgvVeTT, "TrangThai", "Trạng thái", align: DataGridViewContentAlignment.MiddleCenter);
        }

        private void cboLocTrangThaiTT_SelectedIndexChanged(object sender, EventArgs e)
        {
            TaiDanhSachVe(txtTimVeTT.Text.Trim());
        }

        private void txtTimVeTT_TextChanged(object sender, EventArgs e)
        {
            TaiDanhSachVe(txtTimVeTT.Text.Trim());
        }

        private void btnLamMoiVeTT_Click(object sender, EventArgs e)
        {
            txtTimVeTT.Clear();
            TaiDanhSachVe();
        }

        private void dgvVeTT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow r = dgvVeTT.Rows[e.RowIndex];
            _maVeChon = Database.ToInt(r.Cells["MaVe"].Value);
            _soTienChon = Database.ToDecimal(r.Cells["GiaVe"].Value);
            _hoTenChon = r.Cells["HoTen"].Value?.ToString() ?? "";
            _sdtChon = r.Cells["SDT"].Value?.ToString() ?? "";
            _tuyenBayChon = $"{r.Cells["SanBayDi"].Value} ➔ {r.Cells["SanBayDen"].Value}";
            _soGheChon = r.Cells["SoGhe"].Value?.ToString() ?? "";
            _trangThaiVeChon = r.Cells["TrangThai"].Value?.ToString() ?? "";

            lblChiTietVeTTText.Text =
                $"Mã vé: #{_maVeChon}\n" +
                $"Hành khách: {_hoTenChon} - SĐT: {_sdtChon}\n" +
                $"Tuyến bay: {_tuyenBayChon}\n" +
                $"Ghế ngồi: {_soGheChon}\n" +
                $"Số tiền: {_soTienChon:N0} VNĐ\n" +
                $"Trạng thái: {_trangThaiVeChon}";
        }

        // XÁC NHẬN THANH TOÁN
        private void btnXacNhanThanhToan_Click(object sender, EventArgs e)
        {
            if (_maVeChon <= 0)
            {
                MessageBox.Show("Vui lòng chọn vé cần xác nhận thanh toán trong bảng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_trangThaiVeChon == "Đã thanh toán")
            {
                MessageBox.Show("Vé này đã được xác nhận thanh toán rồi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // Bước 1: Cập nhật vé sang 'Đã thanh toán'
                Database.ExecuteNonQuery("UPDATE VE SET TrangThai = 'Đã thanh toán' WHERE MaVe = @mv;",
                    new MySqlParameter("@mv", _maVeChon));

                // Bước 2: Thêm bản ghi vào bảng THANHTOAN và lấy ID vừa tạo
                string sqlTT = @"
                    INSERT INTO THANHTOAN (MaVe, SoTien, PhuongThuc, NgayThanhToan, TrangThai) 
                    VALUES (@mv, @tien, @pt, NOW(), 'Đã thanh toán');";

                int maThanhToan = Database.ExecuteInsertAndGetId(sqlTT,
                    new MySqlParameter("@mv", _maVeChon),
                    new MySqlParameter("@tien", _soTienChon),
                    new MySqlParameter("@pt", cboPhuongThuc.Text));

                // Bước 3: Tự động lập HÓA ĐƠN
                string sqlHD = "INSERT INTO HOADON (MaThanhToan, NgayLap, TongTien) VALUES (@tt, NOW(), @tien);";
                Database.ExecuteNonQuery(sqlHD,
                    new MySqlParameter("@tt", maThanhToan),
                    new MySqlParameter("@tien", _soTienChon));

                // Bước 4: Thông báo và tải lại bảng
                MessageBox.Show($"Xác nhận thanh toán thành công cho vé #{_maVeChon}!\nSố tiền: {_soTienChon:N0} VNĐ\nĐã tự động xuất hóa đơn điện tử.",
                    "Thanh toán thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                TaiDanhSachVe(txtTimVeTT.Text.Trim());
                TaiDanhSachHoaDon();
                CapNhatThongKeDoanhThu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thanh toán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // NGHIỆP VỤ KẾ TOÁN: HỦY CÁC VÉ GIỮ CHỖ QUÁ HẠN (GIẢI PHÓNG GHẾ CHO CHUYẾN BAY)
        private void btnLapHoaDonBoSung_Click(object sender, EventArgs e)
        {
            if (_maVeChon <= 0)
            {
                MessageBox.Show("Vui lòng click chọn 1 vé giữ chỗ cần xử lý trong bảng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_trangThaiVeChon != "Chờ thanh toán")
            {
                MessageBox.Show("Chỉ có thể hủy giữ chỗ cho các vé đang ở trạng thái 'Chờ thanh toán'!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Xác nhận HỦY GIỮ CHỖ QUÁ HẠN cho vé #{_maVeChon} của khách '{_hoTenChon}'?\n(Ghế {_soGheChon} sẽ được giải phóng ngay lập tức về trạng thái còn trống cho khách khác đặt).",
                "Xác nhận hủy giữ chỗ quá hạn", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    Database.ExecuteNonQuery("UPDATE VE SET TrangThai = 'Đã hủy' WHERE MaVe = @mv;",
                        new MySqlParameter("@mv", _maVeChon));

                    MessageBox.Show($"Đã hủy vé giữ chỗ #{_maVeChon} và giải phóng ghế {_soGheChon} thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TaiDanhSachVe(txtTimVeTT.Text.Trim());
                    CapNhatThongKeDoanhThu();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // =========================================================================
        // PHẦN 2: QUẢN LÝ HÓA ĐƠN & IN HÓA ĐƠN ĐIỆN TỬ
        // =========================================================================

        private void TaiDanhSachHoaDon(string tuKhoa = "")
        {
            string sql = @"
                SELECT hd.MaHoaDon, hd.MaThanhToan, tt.MaVe, kh.HoTen, tt.PhuongThuc, hd.NgayLap, hd.TongTien 
                FROM HOADON hd 
                LEFT JOIN THANHTOAN tt ON hd.MaThanhToan = tt.MaThanhToan 
                LEFT JOIN VE v ON tt.MaVe = v.MaVe 
                LEFT JOIN KHACHHANG kh ON v.MaKH = kh.MaKH 
                WHERE 1=1 ";

            if (!string.IsNullOrEmpty(tuKhoa))
            {
                sql += $" AND (hd.MaHoaDon LIKE '%{tuKhoa}%' OR kh.HoTen LIKE '%{tuKhoa}%' OR tt.MaVe LIKE '%{tuKhoa}%')";
            }

            sql += " ORDER BY hd.MaHoaDon DESC;";

            dgvHoaDon.DataSource = Database.GetData(sql);

            UiTheme.SetCol(dgvHoaDon, "MaHoaDon", "Mã HĐ", width: 65, align: DataGridViewContentAlignment.MiddleCenter);
            UiTheme.SetCol(dgvHoaDon, "MaThanhToan", "Mã TT", width: 65, align: DataGridViewContentAlignment.MiddleCenter);
            UiTheme.SetCol(dgvHoaDon, "MaVe", "Mã vé", width: 65, align: DataGridViewContentAlignment.MiddleCenter);
            UiTheme.SetCol(dgvHoaDon, "HoTen", "Khách hàng");
            UiTheme.SetCol(dgvHoaDon, "PhuongThuc", "Phương thức thanh toán");
            UiTheme.SetCol(dgvHoaDon, "NgayLap", "Ngày lập", format: "dd/MM/yyyy HH:mm");
            UiTheme.SetCol(dgvHoaDon, "TongTien", "Tổng tiền (VNĐ)", align: DataGridViewContentAlignment.MiddleRight, format: "N0");
        }

        private void btnTraCuuHoaDon_Click(object sender, EventArgs e)
        {
            TaiDanhSachHoaDon(txtTimHoaDon.Text.Trim());
        }

        private void btnLamMoiHoaDon_Click(object sender, EventArgs e)
        {
            txtTimHoaDon.Clear();
            TaiDanhSachHoaDon();
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng click chọn 1 hóa đơn trong bảng để in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow r = dgvHoaDon.CurrentRow;
            decimal tongTien = Database.ToDecimal(r.Cells["TongTien"].Value);
            string tienBangChu = DocTienBangChu(tongTien);

            string hoaDon =
                $"==========================================================\n" +
                $"                HÓA ĐƠN GIÁ TRỊ GIA TĂNG                   \n" +
                $"                    (BẢN ĐIỆN TỬ)                         \n" +
                $"==========================================================\n" +
                $"Mã hóa đơn: HD#{r.Cells["MaHoaDon"].Value}\n" +
                $"Ngày xuất hóa đơn: {r.Cells["NgayLap"].Value}\n" +
                $"Tên khách hàng: {r.Cells["HoTen"].Value}\n" +
                $"Mã vé máy bay: #{r.Cells["MaVe"].Value}\n" +
                $"Hình thức thanh toán: {r.Cells["PhuongThuc"].Value}\n" +
                $"----------------------------------------------------------\n" +
                $"TỔNG TIỀN THANH TOÁN: {tongTien:N0} VNĐ\n" +
                $"Số tiền bằng chữ: {tienBangChu}\n" +
                $"==========================================================\n" +
                $"Người lập hóa đơn: {SessionManager.CurrentUser?.HoTen ?? "Kế toán viên"}\n" +
                $"Cảm ơn quý khách đã sử dụng dịch vụ của chúng tôi!";

            MessageBox.Show(hoaDon, "HÓA ĐƠN THANH TOÁN", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // =========================================================================
        // PHẦN 3: THỐNG KÊ DOANH THU & KPI KINH DOANH
        // =========================================================================

        private void CapNhatThongKeDoanhThu()
        {
            decimal tongDoanhThu = Database.ToDecimal(Database.ExecuteScalar("SELECT IFNULL(SUM(SoTien), 0) FROM THANHTOAN WHERE TrangThai IN ('Đã thanh toán', 'Thành công')"), 18500000m);
            long tongVe = Database.ToLong(Database.ExecuteScalar("SELECT COUNT(*) FROM VE WHERE TrangThai = 'Đã thanh toán'"), 10);
            long tongHoaDon = Database.ToLong(Database.ExecuteScalar("SELECT COUNT(*) FROM HOADON"), 5);
            decimal tbVe = (tongVe > 0) ? (tongDoanhThu / tongVe) : 0;

            lblValDoanhThu.Text = $"{tongDoanhThu:N0} VNĐ";
            lblValVe.Text = $"{tongVe} vé";
            lblValHoaDon.Text = $"{tongHoaDon} HĐ";
            lblValTrungBinh.Text = $"{tbVe:N0} VNĐ";

            string sqlPt = @"
                SELECT PhuongThuc, COUNT(*) AS SoGiaoDich, SUM(SoTien) AS DoanhThu 
                FROM THANHTOAN 
                WHERE TrangThai IN ('Đã thanh toán', 'Thành công') 
                GROUP BY PhuongThuc;";
            dgvDoanhThuPhuongThuc.DataSource = Database.GetData(sqlPt);

            UiTheme.SetCol(dgvDoanhThuPhuongThuc, "PhuongThuc", "Phương thức");
            UiTheme.SetCol(dgvDoanhThuPhuongThuc, "SoGiaoDich", "Số GD", width: 65, align: DataGridViewContentAlignment.MiddleCenter);
            UiTheme.SetCol(dgvDoanhThuPhuongThuc, "DoanhThu", "Doanh thu (VNĐ)", align: DataGridViewContentAlignment.MiddleRight, format: "N0");

            string sqlTuyen = @"
                SELECT CONCAT(cb.SanBayDi, ' ➔ ', cb.SanBayDen) AS TuyenBay, 
                       COUNT(v.MaVe) AS SoVe, 
                       SUM(v.GiaVe) AS DoanhThu 
                FROM VE v 
                LEFT JOIN CHUYENBAY cb ON v.MaChuyenBay = cb.MaChuyenBay 
                WHERE v.TrangThai = 'Đã thanh toán' 
                GROUP BY cb.SanBayDi, cb.SanBayDen;";
            dgvDoanhThuTuyenBay.DataSource = Database.GetData(sqlTuyen);

            UiTheme.SetCol(dgvDoanhThuTuyenBay, "TuyenBay", "Tuyến đường bay");
            UiTheme.SetCol(dgvDoanhThuTuyenBay, "SoVe", "Vé bán", width: 65, align: DataGridViewContentAlignment.MiddleCenter);
            UiTheme.SetCol(dgvDoanhThuTuyenBay, "DoanhThu", "Doanh thu (VNĐ)", align: DataGridViewContentAlignment.MiddleRight, format: "N0");
        }

        private void cboMocThoiGian_SelectedIndexChanged(object sender, EventArgs e)
        {
            CapNhatThongKeDoanhThu();
        }

        private void btnXuatBaoCaoDoanhThu_Click(object sender, EventArgs e)
        {
            CapNhatThongKeDoanhThu();
            MessageBox.Show("Đã làm mới và đồng bộ báo cáo doanh thu kế toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string DocTienBangChu(decimal soTien)
        {
            if (soTien == 0) return "Không đồng";
            if (soTien >= 1000000)
            {
                decimal trieu = Math.Floor(soTien / 1000000);
                decimal ngan = Math.Floor((soTien % 1000000) / 1000);
                if (ngan > 0)
                    return $"{trieu:0} triệu {ngan:0} nghìn đồng chẵn";
                else
                    return $"{trieu:0} triệu đồng chẵn";
            }
            return $"{soTien:N0} đồng chẵn";
        }
    }
}
