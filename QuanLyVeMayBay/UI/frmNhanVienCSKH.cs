using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using QuanLyVeMayBay.DAL;

namespace QuanLyVeMayBay
{
    /// <summary>
    /// Giao diện Bộ phận Chăm sóc khách hàng (CSKH)
    /// Viết chuẩn theo kiến thức môn Lập trình .NET cho sinh viên năm 3:
    /// - Tra cứu thông tin vé hành khách (mã vé, họ tên, chuyến bay, ghế)
    /// - Thay đổi vé (đổi ghế trên chuyến bay, đổi chuyến bay)
    /// - Hủy vé (hoàn trả ghế trống về hệ thống, đổi vé sang 'Đã hủy')
    /// - Tiếp nhận & xử lý yêu cầu phản ánh của khách hàng
    /// </summary>
    public partial class frmNhanVienCSKH : Form
    {
        private int _maVeChon = 0;
        private int _maChuyenBayChon = 0;
        private int _maGheChon = 0;
        private string _tenKhachChon = "";
        private string _sdtChon = "";
        private string _soGheChon = "";
        private string _trangThaiVeChon = "";

        public frmNhanVienCSKH()
        {
            InitializeComponent();
        }

        private void frmNhanVienCSKH_Load(object sender, EventArgs e)
        {
            // 1. Tạo thanh tiêu đề TopBar
            UiTheme.CreateTopBar(this, "🎧 BỘ PHẬN CHĂM SÓC KHÁCH HÀNG (CSKH)",
                "Tra cứu thông tin vé, tiếp nhận yêu cầu, thay đổi vé & xử lý hủy vé",
                (s, ev) => this.Close());

            // 2. Làm đẹp giao diện
            CaiDatGiaoDien();

            // 3. Khởi tạo danh mục ban đầu
            KhoiTaoDuLieuBanDau();

            // 4. Tải dữ liệu ban đầu
            TaiDanhSachVe();
            TaiDanhSachYeuCau();

            // 5. Thêm tab "Quản lý khách hàng": nhúng form frmKhachHang vào trong tab
            TabPage tabKhachHang = new TabPage("👤 Quản lý khách hàng");
            frmKhachHang frm = new frmKhachHang
            {
                TopLevel = false,                        // Cho phép đặt form vào trong control khác
                FormBorderStyle = FormBorderStyle.None,  // Bỏ viền và thanh tiêu đề
                Dock = DockStyle.Fill
            };
            tabKhachHang.Controls.Add(frm);
            tabCtrlCSKH.TabPages.Add(tabKhachHang);
            frm.Show();

            // Mỗi lần mở tab khách hàng thì tải lại để thấy khách mới đặt vé
            tabCtrlCSKH.SelectedIndexChanged += (s, ev) =>
            {
                if (tabCtrlCSKH.SelectedTab == tabKhachHang) frm.TaiDanhSach();
            };
        }

        private void CaiDatGiaoDien()
        {
            UiTheme.ApplyFormStyle(this);
            UiTheme.ApplyCardStyle(grpDanhSachVe);
            UiTheme.ApplyCardStyle(grpChiTietVe);
            UiTheme.ApplyCardStyle(grpThaoTacVe);
            UiTheme.ApplyCardStyle(grpTiepNhanMoi);
            UiTheme.ApplyCardStyle(grpDanhSachYeuCau);

            UiTheme.ApplyButtonStyle(btnTimKiemVe, UiTheme.PrimaryBlue, UiTheme.PrimaryBlueHover, Color.White);
            UiTheme.ApplyButtonStyle(btnLamMoiVe, UiTheme.SecondarySlate, UiTheme.SecondarySlateHover, Color.White);
            UiTheme.ApplyButtonStyle(btnThayDoiChuyenBay, UiTheme.PrimaryBlue, UiTheme.PrimaryBlueHover, Color.White);
            UiTheme.ApplyButtonStyle(btnThayDoiGhe, Color.FromArgb(14, 165, 233), Color.FromArgb(2, 132, 199), Color.White);
            UiTheme.ApplyButtonStyle(btnHuyVe, UiTheme.DangerRose, UiTheme.DangerRoseHover, Color.White);

            UiTheme.ApplyButtonStyle(btnLuuYeuCau, UiTheme.SuccessGreen, UiTheme.SuccessGreenHover, Color.White);
            UiTheme.ApplyButtonStyle(btnLamMoiNhapYc, UiTheme.SecondarySlate, UiTheme.SecondarySlateHover, Color.White);
            UiTheme.ApplyButtonStyle(btnXuLyHoanTat, UiTheme.SuccessGreen, UiTheme.SuccessGreenHover, Color.White);
            UiTheme.ApplyButtonStyle(btnTuChoiYc, UiTheme.DangerRose, UiTheme.DangerRoseHover, Color.White);
            UiTheme.ApplyButtonStyle(btnXoaYc, UiTheme.DangerRose, UiTheme.DangerRoseHover, Color.White);
            UiTheme.ApplyButtonStyle(btnLamMoiDsYc, UiTheme.SecondarySlate, UiTheme.SecondarySlateHover, Color.White);

            UiTheme.ApplyDataGridStyle(dgvVe);
            UiTheme.ApplyDataGridStyle(dgvYeuCau);

            dgvVe.CellFormatting += (s, e) => UiTheme.FormatStatusCell(e, "TrangThai", dgvVe);
            dgvYeuCau.CellFormatting += (s, e) => UiTheme.FormatStatusCell(e, "TrangThai", dgvYeuCau);
            dgvYeuCau.CellClick += dgvYeuCau_CellClick;
        }

        private void KhoiTaoDuLieuBanDau()
        {
            cboLocTrangThai.Items.Clear();
            cboLocTrangThai.Items.Add("Tất cả trạng thái");
            cboLocTrangThai.Items.Add("Chờ thanh toán");
            cboLocTrangThai.Items.Add("Đã thanh toán");
            cboLocTrangThai.Items.Add("Đã hủy");
            cboLocTrangThai.SelectedIndex = 0;

            cboLoaiYeuCau.Items.Clear();
            cboLoaiYeuCau.Items.Add("Đổi ghế ngồi");
            cboLoaiYeuCau.Items.Add("Đổi chuyến bay");
            cboLoaiYeuCau.Items.Add("Hủy vé & Hoàn tiền");
            cboLoaiYeuCau.Items.Add("Hỗ trợ thanh toán");
            cboLoaiYeuCau.Items.Add("Khiếu nại hành lý / Dịch vụ");
            cboLoaiYeuCau.SelectedIndex = 0;

            cboLoaiYeuCau.SelectedIndexChanged += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtYcNoiDung.Text))
                {
                    txtYcNoiDung.Text = $"Hành khách yêu cầu hỗ trợ {cboLoaiYeuCau.Text.ToLower()}";
                }
            };
        }

        // =========================================================================
        // PHẦN 1: TRA CỨU & XEM THÔNG TIN VÉ
        // =========================================================================

        private void TaiDanhSachVe(string tuKhoa = "")
        {
            string sql = @"
                SELECT v.MaVe, kh.HoTen, kh.SDT, cb.MaChuyenBay, cb.SanBayDi, cb.SanBayDen, 
                       g.MaGhe, g.SoGhe, v.GiaVe, v.TrangThai 
                FROM VE v 
                LEFT JOIN KHACHHANG kh ON v.MaKH = kh.MaKH 
                LEFT JOIN CHUYENBAY cb ON v.MaChuyenBay = cb.MaChuyenBay 
                LEFT JOIN GHE g ON v.MaGhe = g.MaGhe 
                WHERE 1=1 ";

            if (!string.IsNullOrEmpty(tuKhoa))
            {
                // UC08: tra cứu theo mã vé, họ tên, SĐT, số giấy tờ (CCCD) hoặc sân bay
                sql += " AND (v.MaVe LIKE @tk OR kh.HoTen LIKE @tk OR kh.SDT LIKE @tk OR kh.CCCD LIKE @tk OR cb.SanBayDi LIKE @tk OR cb.SanBayDen LIKE @tk)";
            }

            if (cboLocTrangThai.SelectedIndex > 0)
            {
                sql += " AND v.TrangThai = @tt";
            }

            sql += " ORDER BY v.MaVe DESC;";

            dgvVe.DataSource = Database.GetData(sql,
                new MySqlParameter("@tk", $"%{tuKhoa}%"),
                new MySqlParameter("@tt", cboLocTrangThai.Text));
            BoChonVe();

            UiTheme.SetCol(dgvVe, "MaVe", "Mã vé", width: 65, align: DataGridViewContentAlignment.MiddleCenter);
            UiTheme.SetCol(dgvVe, "HoTen", "Tên hành khách");
            UiTheme.SetCol(dgvVe, "SDT", "Số điện thoại");
            UiTheme.SetCol(dgvVe, "MaChuyenBay", "Mã CB", width: 65, align: DataGridViewContentAlignment.MiddleCenter);
            UiTheme.SetCol(dgvVe, "SanBayDi", "Sân bay đi");
            UiTheme.SetCol(dgvVe, "SanBayDen", "Sân bay đến");
            UiTheme.SetCol(dgvVe, "MaGhe", "Mã ghế", visible: false);
            UiTheme.SetCol(dgvVe, "SoGhe", "Ghế", width: 60, align: DataGridViewContentAlignment.MiddleCenter);
            UiTheme.SetCol(dgvVe, "GiaVe", "Giá vé (VNĐ)", align: DataGridViewContentAlignment.MiddleRight, format: "N0");
            UiTheme.SetCol(dgvVe, "TrangThai", "Trạng thái", align: DataGridViewContentAlignment.MiddleCenter);
        }

        // Bỏ chọn vé sau khi tải lại danh sách, tránh thao tác lần 2 trên trạng thái vé cũ
        // (ví dụ bấm Hủy vé 2 lần sẽ sinh 2 yêu cầu hoàn tiền)
        private void BoChonVe()
        {
            _maVeChon = 0;
            _maChuyenBayChon = 0;
            _maGheChon = 0;
            _tenKhachChon = "";
            _sdtChon = "";
            _soGheChon = "";
            _trangThaiVeChon = "";
            lblChiTietVeText.Text = "Vui lòng chọn 1 vé trong danh sách bảng bên trái để xem thông tin chi tiết và thực hiện thay đổi vé hoặc hủy vé.";
            dgvVe.ClearSelection();
        }

        private void dgvVe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvVe.Rows[e.RowIndex];
            _maVeChon = Database.ToInt(row.Cells["MaVe"].Value);
            _maChuyenBayChon = Database.ToInt(row.Cells["MaChuyenBay"].Value);
            _maGheChon = Database.ToInt(row.Cells["MaGhe"].Value);
            _tenKhachChon = row.Cells["HoTen"].Value?.ToString() ?? "";
            _sdtChon = row.Cells["SDT"].Value?.ToString() ?? "";
            _soGheChon = row.Cells["SoGhe"].Value?.ToString() ?? "";
            _trangThaiVeChon = row.Cells["TrangThai"].Value?.ToString() ?? "";

            string di = row.Cells["SanBayDi"].Value?.ToString() ?? "";
            string den = row.Cells["SanBayDen"].Value?.ToString() ?? "";

            lblChiTietVeText.Text =
                $"Mã vé: #{_maVeChon}\n" +
                $"Hành khách: {_tenKhachChon}\n" +
                $"Chuyến bay: CB #{_maChuyenBayChon} ({di} ➔ {den})\n" +
                $"Số ghế: {_soGheChon}\n" +
                $"Trạng thái: {_trangThaiVeChon}";

            txtYcMaVe.Text = _maVeChon.ToString();
            txtYcTenKhach.Text = _tenKhachChon;
            if (string.IsNullOrWhiteSpace(txtYcNoiDung.Text))
            {
                txtYcNoiDung.Text = $"Hành khách {_tenKhachChon} (vé #{_maVeChon}, ghế {_soGheChon}) yêu cầu hỗ trợ.";
            }
        }

        private void btnTimKiemVe_Click(object sender, EventArgs e)
        {
            TaiDanhSachVe(txtTimKiemVe.Text.Trim());
        }

        private void txtTimKiemVe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TaiDanhSachVe(txtTimKiemVe.Text.Trim());
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void cboLocTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            TaiDanhSachVe(txtTimKiemVe.Text.Trim());
        }

        private void btnLamMoiVe_Click(object sender, EventArgs e)
        {
            txtTimKiemVe.Clear();
            cboLocTrangThai.SelectedIndex = 0;
            TaiDanhSachVe();
        }

        // =========================================================================
        // PHẦN 2: THAY ĐỔI VÉ (ĐỔI GHẾ / ĐỔI CHUYẾN BAY)
        // =========================================================================

        // UC09 (tiền điều kiện): chỉ được đổi vé khi còn ít nhất 3 giờ trước giờ khởi hành
        private bool ConDuThoiGianDoiVe()
        {
            DateTime gioBay = Database.ToDateTime(Database.ExecuteScalar("SELECT ThoiGianDi FROM CHUYENBAY WHERE MaChuyenBay = @cb;",
                new MySqlParameter("@cb", _maChuyenBayChon)));
            if (gioBay < DateTime.Now.AddHours(3))
            {
                MessageBox.Show($"Chuyến bay khởi hành lúc {gioBay:dd/MM/yyyy HH:mm}.\nChỉ được đổi vé trước giờ bay tối thiểu 3 giờ!", "Quá hạn đổi vé", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnThayDoiGhe_Click(object sender, EventArgs e)
        {
            if (_maVeChon <= 0)
            {
                MessageBox.Show("Vui lòng chọn vé cần đổi ghế trong bảng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_trangThaiVeChon == "Đã hủy")
            {
                MessageBox.Show("Vé này đã bị hủy, không thể đổi ghế!", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ConDuThoiGianDoiVe()) return;

            try
            {
                string sqlTimGhe = @"
                    SELECT g.MaGhe, g.SoGhe, g.HangGhe 
                    FROM GHE g 
                    JOIN CHUYENBAY cb ON g.MaMayBay = cb.MaMayBay 
                    WHERE cb.MaChuyenBay = @cb 
                      AND g.TrangThai = 'Trong' 
                      AND g.MaGhe <> @gheCu
                      AND g.HangGhe = (SELECT HangGhe FROM GHE WHERE MaGhe = @gheCu)
                      AND NOT EXISTS (
                          SELECT 1 FROM VE v 
                          WHERE v.MaChuyenBay = @cb 
                            AND v.MaGhe = g.MaGhe 
                            AND v.TrangThai NOT IN ('Đã hủy', 'Da huy')
                      )
                    LIMIT 1;";

                DataTable dtGheTrong = Database.GetData(sqlTimGhe,
                    new MySqlParameter("@cb", _maChuyenBayChon),
                    new MySqlParameter("@gheCu", _maGheChon));

                if (dtGheTrong.Rows.Count == 0)
                {
                    MessageBox.Show("Chuyến bay này hiện không còn ghế trống cùng hạng để đổi!", "Hết ghế", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int maGheMoi = Database.ToInt(dtGheTrong.Rows[0]["MaGhe"]);
                string soGheMoi = dtGheTrong.Rows[0]["SoGhe"].ToString() ?? "";

                if (MessageBox.Show($"Xác nhận đổi ghế cho khách '{_tenKhachChon}' từ ghế '{_soGheChon}' sang ghế mới '{soGheMoi}'?",
                    "Xác nhận đổi ghế", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Cập nhật mã ghế mới vào vé (ghế cũ tự động được giải phóng cho chuyến bay này)
                    int soDong = Database.ExecuteNonQuery("UPDATE VE SET MaGhe = @gMoi WHERE MaVe = @mv AND TrangThai <> 'Đã hủy';",
                        new MySqlParameter("@gMoi", maGheMoi),
                        new MySqlParameter("@mv", _maVeChon));
                    if (soDong == 0)
                    {
                        MessageBox.Show("Vé đã bị hủy hoặc không còn tồn tại, không thể đổi ghế!", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TaiDanhSachVe();
                        return;
                    }

                    MessageBox.Show($"Đã đổi sang ghế '{soGheMoi}' thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TaiDanhSachVe();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đổi ghế: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThayDoiChuyenBay_Click(object sender, EventArgs e)
        {
            if (_maVeChon <= 0)
            {
                MessageBox.Show("Vui lòng chọn vé cần đổi chuyến bay!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_trangThaiVeChon == "Đã hủy")
            {
                MessageBox.Show("Vé này đã bị hủy, không thể đổi chuyến bay!", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ConDuThoiGianDoiVe()) return;

            try
            {
                // 1. Tìm chuyến bay thay thế CÙNG TUYẾN (cùng sân bay đi/đến), đang mở bán và chưa khởi hành
                string sqlCbMoi = @"
                    SELECT cbMoi.MaChuyenBay, cbMoi.SanBayDi, cbMoi.SanBayDen
                    FROM CHUYENBAY cbMoi
                    JOIN CHUYENBAY cbCu ON cbCu.MaChuyenBay = @cb
                    WHERE cbMoi.MaChuyenBay <> @cb
                      AND cbMoi.SanBayDi = cbCu.SanBayDi
                      AND cbMoi.SanBayDen = cbCu.SanBayDen
                      AND cbMoi.TrangThai = 'Đang mở'
                      AND cbMoi.ThoiGianDi > NOW()
                    ORDER BY cbMoi.ThoiGianDi ASC
                    LIMIT 1;";
                DataTable dtCb = Database.GetData(sqlCbMoi, new MySqlParameter("@cb", _maChuyenBayChon));

                if (dtCb.Rows.Count == 0)
                {
                    MessageBox.Show("Hiện không có chuyến bay thay thế cùng tuyến nào khả dụng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int maCbMoi = Database.ToInt(dtCb.Rows[0]["MaChuyenBay"]);
                string tuyenMoi = $"{dtCb.Rows[0]["SanBayDi"]} ➔ {dtCb.Rows[0]["SanBayDen"]}";

                // 2. Tìm ghế còn trống trên chuyến bay mới
                string sqlGheTrong = @"
                    SELECT g.MaGhe, g.SoGhe 
                    FROM GHE g 
                    JOIN CHUYENBAY cb ON g.MaMayBay = cb.MaMayBay 
                    WHERE cb.MaChuyenBay = @cbMoi 
                      AND g.TrangThai = 'Trong' 
                      AND NOT EXISTS (
                          SELECT 1 FROM VE v 
                          WHERE v.MaChuyenBay = @cbMoi 
                            AND v.MaGhe = g.MaGhe 
                            AND v.TrangThai NOT IN ('Đã hủy', 'Da huy')
                      )
                    LIMIT 1;";
                DataTable dtGheMoi = Database.GetData(sqlGheTrong, new MySqlParameter("@cbMoi", maCbMoi));

                if (dtGheMoi.Rows.Count == 0)
                {
                    MessageBox.Show($"Chuyến bay #{maCbMoi} hiện đã kín chỗ, không thể đổi sang chuyến này!", "Hết ghế", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int maGheMoi = Database.ToInt(dtGheMoi.Rows[0]["MaGhe"]);
                string soGheMoi = dtGheMoi.Rows[0]["SoGhe"].ToString() ?? "";

                if (MessageBox.Show($"Xác nhận đổi chuyến bay cho vé #{_maVeChon} sang chuyến mới #{maCbMoi} ({tuyenMoi}), ghế {soGheMoi}?",
                    "Xác nhận đổi chuyến", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Cập nhật cả mã chuyến bay và mã ghế mới
                    int soDong = Database.ExecuteNonQuery("UPDATE VE SET MaChuyenBay = @cbMoi, MaGhe = @gMoi WHERE MaVe = @mv AND TrangThai <> 'Đã hủy';",
                        new MySqlParameter("@cbMoi", maCbMoi),
                        new MySqlParameter("@gMoi", maGheMoi),
                        new MySqlParameter("@mv", _maVeChon));
                    if (soDong == 0)
                    {
                        MessageBox.Show("Vé đã bị hủy hoặc không còn tồn tại, không thể đổi chuyến!", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TaiDanhSachVe();
                        return;
                    }

                    MessageBox.Show($"Đã đổi sang chuyến bay #{maCbMoi} (ghế {soGheMoi}) thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TaiDanhSachVe();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đổi chuyến: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================================================
        // PHẦN 3: HỦY VÉ (TRẢ GHẾ TRỐNG VỀ HỆ THỐNG)
        // =========================================================================

        private void btnHuyVe_Click(object sender, EventArgs e)
        {
            if (_maVeChon <= 0)
            {
                MessageBox.Show("Vui lòng chọn vé cần hủy trong bảng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_trangThaiVeChon == "Đã hủy")
            {
                MessageBox.Show("Vé này đã được hủy trước đó rồi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_trangThaiVeChon == "Đã thanh toán")
            {
                // Vé đã thanh toán: Khách muốn hủy vé và đòi lại tiền
                if (MessageBox.Show($"Vé #{_maVeChon} của khách '{_tenKhachChon}' ĐÃ THANH TOÁN TIỀN.\nBạn có chắc chắn muốn HỦY VÉ và HOÀN TIỀN cho khách?",
                    "Hủy vé & Đề xuất hoàn tiền", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        // 1. Chuyển vé sang Đã hủy (ghế tự động được trả về cho chuyến bay)
                        //    Chỉ cập nhật khi vé vẫn đang 'Đã thanh toán' để không sinh yêu cầu hoàn tiền trùng
                        int soDong = Database.ExecuteNonQuery("UPDATE VE SET TrangThai = 'Đã hủy' WHERE MaVe = @mv AND TrangThai = 'Đã thanh toán';",
                            new MySqlParameter("@mv", _maVeChon));
                        if (soDong == 0)
                        {
                            MessageBox.Show("Trạng thái vé đã thay đổi (có thể đã bị hủy trước đó). Vui lòng tải lại danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            TaiDanhSachVe();
                            return;
                        }

                        // 2. UC10: Hoàn tiền - chuyển giao dịch thanh toán của vé sang 'Đã hoàn tiền'
                        //    (thống kê doanh thu chỉ cộng giao dịch 'Đã thanh toán' nên doanh thu thuần tự trừ khoản hoàn)
                        decimal soTienHoan = Database.ToDecimal(Database.ExecuteScalar(
                            "SELECT IFNULL(SUM(SoTien), 0) FROM THANHTOAN WHERE MaVe = @mv AND TrangThai IN ('Đã thanh toán', 'Thành công');",
                            new MySqlParameter("@mv", _maVeChon)));
                        Database.ExecuteNonQuery("UPDATE THANHTOAN SET TrangThai = 'Đã hoàn tiền' WHERE MaVe = @mv AND TrangThai IN ('Đã thanh toán', 'Thành công');",
                            new MySqlParameter("@mv", _maVeChon));

                        // 3. Lưu lịch sử hủy vé vào YEUCAU_CSKH
                        string sqlYc = @"
                            INSERT INTO YEUCAU_CSKH (MaVe, TenKhach, LoaiYeuCau, NoiDung, NgayTao, TrangThai, GhiChuXuLy) 
                            VALUES (@mv, @ten, 'Hủy vé & Hoàn tiền', @nd, NOW(), 'Đã giải quyết', @gc);";
                        Database.ExecuteNonQuery(sqlYc,
                            new MySqlParameter("@mv", _maVeChon),
                            new MySqlParameter("@ten", _tenKhachChon),
                            new MySqlParameter("@nd", $"Hành khách {_tenKhachChon} (SĐT: {_sdtChon}) hủy vé #{_maVeChon}. Ghế {_soGheChon} đã giải phóng."),
                            new MySqlParameter("@gc", $"Đã hoàn tiền {soTienHoan:N0} VNĐ cho khách"));

                        MessageBox.Show($"Đã hủy vé #{_maVeChon}, giải phóng ghế '{_soGheChon}' và hoàn tiền {soTienHoan:N0} VNĐ cho khách!", "Hủy vé & Hoàn tiền", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TaiDanhSachVe();
                        TaiDanhSachYeuCau();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi hủy vé: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                // Vé Chờ thanh toán: Khách hủy giữ chỗ bình thường
                if (MessageBox.Show($"Xác nhận HỦY VÉ GIỮ CHỖ #{_maVeChon} của khách '{_tenKhachChon}'?\n(Ghế '{_soGheChon}' sẽ được hoàn trả tự động về trạng thái còn trống).",
                    "Xác nhận hủy vé giữ chỗ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        int soDong = Database.ExecuteNonQuery("UPDATE VE SET TrangThai = 'Đã hủy' WHERE MaVe = @mv AND TrangThai = 'Chờ thanh toán';",
                            new MySqlParameter("@mv", _maVeChon));
                        if (soDong == 0)
                        {
                            MessageBox.Show("Trạng thái vé đã thay đổi (đã thanh toán hoặc đã hủy). Vui lòng tải lại danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            TaiDanhSachVe();
                            return;
                        }

                        MessageBox.Show($"Đã hủy vé giữ chỗ #{_maVeChon} và giải phóng ghế '{_soGheChon}' thành công!", "Hủy vé thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TaiDanhSachVe();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi hủy vé: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // =========================================================================
        // PHẦN 4: TIẾP NHẬN & QUẢN LÝ YÊU CẦU CỦA KHÁCH HÀNG
        // =========================================================================

        private void TaiDanhSachYeuCau()
        {
            DataTable dt;
            try
            {
                string sql = "SELECT MaYeuCau, MaVe, TenKhach, LoaiYeuCau, NoiDung, NgayTao, TrangThai, GhiChuXuLy FROM YEUCAU_CSKH ORDER BY MaYeuCau DESC;";
                dt = Database.GetData(sql);
            }
            catch
            {
                // Dự phòng nếu bảng trong MySQL chưa có cột GhiChuXuLy
                string sqlFallback = "SELECT MaYeuCau, MaVe, TenKhach, LoaiYeuCau, NoiDung, NgayTao, TrangThai FROM YEUCAU_CSKH ORDER BY MaYeuCau DESC;";
                dt = Database.GetData(sqlFallback);
            }

            if (!dt.Columns.Contains("GhiChuXuLy"))
            {
                dt.Columns.Add("GhiChuXuLy", typeof(string));
            }

            dgvYeuCau.DataSource = dt;

            UiTheme.SetCol(dgvYeuCau, "MaYeuCau", "Mã YC", width: 65, align: DataGridViewContentAlignment.MiddleCenter);
            UiTheme.SetCol(dgvYeuCau, "MaVe", "Mã vé", width: 65, align: DataGridViewContentAlignment.MiddleCenter);
            UiTheme.SetCol(dgvYeuCau, "TenKhach", "Khách hàng");
            UiTheme.SetCol(dgvYeuCau, "LoaiYeuCau", "Loại yêu cầu");
            UiTheme.SetCol(dgvYeuCau, "NoiDung", "Nội dung phản ánh");
            UiTheme.SetCol(dgvYeuCau, "NgayTao", "Ngày tiếp nhận", format: "dd/MM/yyyy HH:mm");
            UiTheme.SetCol(dgvYeuCau, "TrangThai", "Trạng thái", align: DataGridViewContentAlignment.MiddleCenter);
            UiTheme.SetCol(dgvYeuCau, "GhiChuXuLy", "Ghi chú xử lý");
        }

        private void btnLuuYeuCau_Click(object sender, EventArgs e)
        {
            try
            {
                int maVe = 0;
                int.TryParse(txtYcMaVe.Text.Trim(), out maVe);

                string tenKhach = txtYcTenKhach.Text.Trim();
                if (string.IsNullOrWhiteSpace(tenKhach))
                {
                    if (maVe > 0)
                    {
                        object? nameObj = Database.ExecuteScalar(@"
                            SELECT kh.HoTen FROM VE v 
                            JOIN KHACHHANG kh ON v.MaKH = kh.MaKH 
                            WHERE v.MaVe = @mv LIMIT 1;", new MySqlParameter("@mv", maVe));
                        if (nameObj != null && !string.IsNullOrWhiteSpace(nameObj.ToString()))
                        {
                            tenKhach = nameObj.ToString()!.Trim();
                        }
                    }
                }
                if (string.IsNullOrWhiteSpace(tenKhach))
                {
                    tenKhach = "Khách hàng yêu cầu";
                }

                string noiDung = txtYcNoiDung.Text.Trim();
                if (string.IsNullOrWhiteSpace(noiDung))
                {
                    noiDung = $"Hành khách yêu cầu hỗ trợ: {cboLoaiYeuCau.Text}" + (maVe > 0 ? $" (liên quan đến vé #{maVe})" : "");
                }

                // Kiểm tra mã vé: Nếu không hợp lệ hoặc không có trong bảng VE thì lưu NULL để không vi phạm FK
                object maVeVal = DBNull.Value;
                if (maVe > 0)
                {
                    object? cnt = Database.ExecuteScalar("SELECT COUNT(*) FROM VE WHERE MaVe = @mv;", new MySqlParameter("@mv", maVe));
                    if (Database.ToLong(cnt) > 0)
                    {
                        maVeVal = maVe;
                    }
                }

                string sql = @"
                    INSERT INTO YEUCAU_CSKH (MaVe, TenKhach, LoaiYeuCau, NoiDung, NgayTao, TrangThai) 
                    VALUES (@mv, @ten, @loai, @nd, NOW(), 'Tiếp nhận');";

                Database.ExecuteNonQuery(sql,
                    new MySqlParameter("@mv", maVeVal),
                    new MySqlParameter("@ten", tenKhach),
                    new MySqlParameter("@loai", cboLoaiYeuCau.Text),
                    new MySqlParameter("@nd", noiDung));

                MessageBox.Show($"Tiếp nhận yêu cầu của khách hàng '{tenKhach}' thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TaiDanhSachYeuCau();
                btnLamMoiNhapYc_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXuLyHoanTat_Click(object sender, EventArgs e)
        {
            if (dgvYeuCau.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn yêu cầu cần xử lý trong bảng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Database.ToInt(dgvYeuCau.CurrentRow.Cells["MaYeuCau"].Value);
            try
            {
                try
                {
                    string sql = "UPDATE YEUCAU_CSKH SET TrangThai = 'Đã giải quyết', GhiChuXuLy = 'CSKH đã xử lý hỗ trợ xong cho hành khách' WHERE MaYeuCau = @id;";
                    Database.ExecuteNonQuery(sql, new MySqlParameter("@id", id));
                }
                catch
                {
                    string sqlFallback = "UPDATE YEUCAU_CSKH SET TrangThai = 'Đã giải quyết' WHERE MaYeuCau = @id;";
                    Database.ExecuteNonQuery(sqlFallback, new MySqlParameter("@id", id));
                }

                MessageBox.Show("Cập nhật trạng thái 'Đã giải quyết' thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TaiDanhSachYeuCau();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTuChoiYc_Click(object sender, EventArgs e)
        {
            if (dgvYeuCau.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn yêu cầu cần từ chối trong bảng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Database.ToInt(dgvYeuCau.CurrentRow.Cells["MaYeuCau"].Value);
            try
            {
                try
                {
                    string sql = "UPDATE YEUCAU_CSKH SET TrangThai = 'Từ chối', GhiChuXuLy = 'Không đáp ứng điều kiện theo quy định của hãng' WHERE MaYeuCau = @id;";
                    Database.ExecuteNonQuery(sql, new MySqlParameter("@id", id));
                }
                catch
                {
                    string sqlFallback = "UPDATE YEUCAU_CSKH SET TrangThai = 'Từ chối' WHERE MaYeuCau = @id;";
                    Database.ExecuteNonQuery(sqlFallback, new MySqlParameter("@id", id));
                }

                MessageBox.Show("Đã từ chối yêu cầu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TaiDanhSachYeuCau();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // XÓA YÊU CẦU CSKH
        private void btnXoaYc_Click(object sender, EventArgs e)
        {
            if (dgvYeuCau.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn yêu cầu cần xóa trong bảng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Database.ToInt(dgvYeuCau.CurrentRow.Cells["MaYeuCau"].Value);
            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa yêu cầu #{id}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    Database.ExecuteNonQuery("DELETE FROM YEUCAU_CSKH WHERE MaYeuCau = @id;", new MySqlParameter("@id", id));
                    MessageBox.Show("Xóa yêu cầu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TaiDanhSachYeuCau();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvYeuCau_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow r = dgvYeuCau.Rows[e.RowIndex];
            txtYcMaVe.Text = r.Cells["MaVe"].Value?.ToString() ?? "";
            txtYcTenKhach.Text = r.Cells["TenKhach"].Value?.ToString() ?? "";
            txtYcNoiDung.Text = r.Cells["NoiDung"].Value?.ToString() ?? "";
            string loai = r.Cells["LoaiYeuCau"].Value?.ToString() ?? "";
            if (cboLoaiYeuCau.Items.Contains(loai))
                cboLoaiYeuCau.Text = loai;
        }

        private void btnLamMoiNhapYc_Click(object sender, EventArgs e)
        {
            txtYcMaVe.Clear();
            txtYcTenKhach.Clear();
            txtYcNoiDung.Clear();
            cboLoaiYeuCau.SelectedIndex = 0;
        }

        private void btnLamMoiDsYc_Click(object sender, EventArgs e)
        {
            TaiDanhSachYeuCau();
        }
    }
}
