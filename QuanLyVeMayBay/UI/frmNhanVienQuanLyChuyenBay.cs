using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using QuanLyVeMayBay.DAL;

namespace QuanLyVeMayBay
{
    /// <summary>
    /// Giao diện Bộ phận Quản lý chuyến bay
    /// Viết chuẩn theo kiến thức môn Lập trình .NET cho sinh viên năm 3:
    /// - Quản lý chuyến bay: Thêm, Sửa, Xóa chuyến bay (kiểm tra an toàn nếu đã có vé)
    /// - Cập nhật thông tin chuyến bay: Giờ bay, giá vé, trạng thái (Đang mở, Đã cất cánh, Đã hủy)
    /// - Cập nhật tình trạng ghế: Khóa ghế bảo trì, mở lại ghế trống
    /// </summary>
    public partial class frmNhanVienQuanLyChuyenBay : Form
    {
        private int _maChuyenBayChon = 0;
        private int _maGheChon = 0;

        public frmNhanVienQuanLyChuyenBay()
        {
            InitializeComponent();
        }

        private void frmNhanVienQuanLyChuyenBay_Load(object sender, EventArgs e)
        {
            // 1. Tạo thanh tiêu đề TopBar
            UiTheme.CreateTopBar(this, "🛫 BỘ PHẬN QUẢN LÝ CHUYẾN BAY",
                "Thêm, sửa, xóa chuyến bay, cập nhật trạng thái bay & tình trạng bảo trì ghế",
                (s, ev) => this.Close());

            // 2. Làm đẹp giao diện
            CaiDatGiaoDien();

            // 3. Khởi tạo danh mục ban đầu
            KhoiTaoDuLieuBanDau();

            // 4. Tải dữ liệu ban đầu
            TaiDanhSachChuyenBay();
            TaiDanhSachGhe();

            // 5. Thêm tab "Quản lý máy bay": nhúng form frmMayBay vào trong tab
            TabPage tabMayBay = new TabPage("✈️ Quản lý máy bay");
            frmMayBay frm = new frmMayBay
            {
                TopLevel = false,                        // Cho phép đặt form vào trong control khác
                FormBorderStyle = FormBorderStyle.None,  // Bỏ viền và thanh tiêu đề
                Dock = DockStyle.Fill
            };
            frm.DuLieuThayDoi += (s, ev) => TaiDanhMucMayBay(); // Máy bay thay đổi -> nạp lại ComboBox
            tabMayBay.Controls.Add(frm);
            tabCtrlQLCB.TabPages.Add(tabMayBay);
            frm.Show();
        }

        private void CaiDatGiaoDien()
        {
            UiTheme.ApplyFormStyle(this);
            UiTheme.ApplyCardStyle(grpDanhSachCb);
            UiTheme.ApplyCardStyle(grpThongTinCb);
            UiTheme.ApplyCardStyle(grpDanhSachGhe);
            UiTheme.ApplyCardStyle(grpThaoTacGhe);

            UiTheme.ApplyButtonStyle(btnThem, UiTheme.SuccessGreen, UiTheme.SuccessGreenHover, Color.White);
            UiTheme.ApplyButtonStyle(btnSua, UiTheme.WarningAmber, UiTheme.WarningAmberHover, Color.White);
            UiTheme.ApplyButtonStyle(btnXoa, UiTheme.DangerRose, UiTheme.DangerRoseHover, Color.White);
            UiTheme.ApplyButtonStyle(btnLamMoi, UiTheme.SecondarySlate, UiTheme.SecondarySlateHover, Color.White);
            UiTheme.ApplyButtonStyle(btnCapNhatGioBay, UiTheme.PrimaryBlue, UiTheme.PrimaryBlueHover, Color.White);
            UiTheme.ApplyButtonStyle(btnLamMoiTim, UiTheme.SecondarySlate, UiTheme.SecondarySlateHover, Color.White);

            UiTheme.ApplyButtonStyle(btnCapNhatGhe, UiTheme.WarningAmber, UiTheme.WarningAmberHover, Color.White);
            UiTheme.ApplyButtonStyle(btnKhoiPhucTatCaGhe, UiTheme.SuccessGreen, UiTheme.SuccessGreenHover, Color.White);
            UiTheme.ApplyButtonStyle(btnSinhGheMau, Color.FromArgb(79, 70, 229), Color.FromArgb(67, 56, 202), Color.White);
            UiTheme.ApplyButtonStyle(btnXoaGhe, UiTheme.DangerRose, UiTheme.DangerRoseHover, Color.White);

            UiTheme.ApplyDataGridStyle(dgvChuyenBay);
            UiTheme.ApplyDataGridStyle(dgvGhe);

            dgvChuyenBay.CellFormatting += (s, e) => UiTheme.FormatStatusCell(e, "TrangThai", dgvChuyenBay);
            dgvGhe.CellFormatting += (s, e) => UiTheme.FormatStatusCell(e, "TrangThai", dgvGhe);
        }

        private void KhoiTaoDuLieuBanDau()
        {
            // Danh mục trạng thái chuyến bay
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add("Đang mở");
            cboTrangThai.Items.Add("Sắp cất cánh");
            cboTrangThai.Items.Add("Đã cất cánh");
            cboTrangThai.Items.Add("Hoàn tất");
            cboTrangThai.Items.Add("Đã hủy");
            cboTrangThai.SelectedIndex = 0;

            // Danh sách sân bay
            string[] dsSanBay = { "HAN - Nội Bài (Hà Nội)", "SGN - Tân Sơn Nhất (TP.HCM)", "DAD - Đà Nẵng", "CXR - Cam Ranh", "PQC - Phú Quốc" };
            cboSanBayDi.Items.Clear();
            cboSanBayDen.Items.Clear();
            cboSanBayDi.Items.AddRange(dsSanBay);
            cboSanBayDen.Items.AddRange(dsSanBay);
            cboSanBayDi.SelectedIndex = 0;
            cboSanBayDen.SelectedIndex = 1;

            // Danh mục trạng thái ghế
            cboTrangThaiGheMoi.Items.Clear();
            cboTrangThaiGheMoi.Items.Add("Trong");
            cboTrangThaiGheMoi.Items.Add("Bảo trì");
            cboTrangThaiGheMoi.SelectedIndex = 0;

            TaiDanhMucMayBay();
        }

        // Tải danh mục tàu bay vào 2 ComboBox (gọi lại mỗi khi tab Quản lý máy bay thêm/sửa/xóa)
        private void TaiDanhMucMayBay()
        {
            // Đặt DisplayMember & ValueMember trước khi gán DataSource
            DataTable dtMayBay = Database.GetData("SELECT MaMayBay, TenMayBay FROM MAYBAY ORDER BY MaMayBay;");
            cboMaMayBay.DisplayMember = "TenMayBay";
            cboMaMayBay.ValueMember = "MaMayBay";
            cboMaMayBay.DataSource = dtMayBay;

            DataTable dtMb2 = dtMayBay.Copy();
            cboMayBayGhe.DisplayMember = "TenMayBay";
            cboMayBayGhe.ValueMember = "MaMayBay";
            cboMayBayGhe.DataSource = dtMb2;
        }

        // Hàm trích xuất mã máy bay an toàn từ ComboBox, chống lỗi InvalidCastException
        private int LayMaMayBayChon(ComboBox cbo)
        {
            if (cbo == null) return 1;

            if (cbo.SelectedItem is DataRowView drv)
            {
                if (drv.Row.Table.Columns.Contains("MaMayBay"))
                    return Convert.ToInt32(drv["MaMayBay"]);
                if (drv.Row.ItemArray.Length > 0 && int.TryParse(drv.Row[0]?.ToString(), out int idFromRow))
                    return idFromRow;
            }

            if (cbo.SelectedValue != null && !(cbo.SelectedValue is DataRowView))
            {
                if (int.TryParse(cbo.SelectedValue.ToString(), out int id) && id > 0)
                    return id;
            }

            return 1;
        }

        // =========================================================================
        // PHẦN 1: QUẢN LÝ CHUYẾN BAY (THÊM, SỬA, XÓA, CẬP NHẬT TRẠNG THÁI)
        // =========================================================================

        private void TaiDanhSachChuyenBay(string tuKhoa = "")
        {
            string sql = @"
                SELECT cb.MaChuyenBay, cb.MaMayBay, mb.TenMayBay, cb.SanBayDi, cb.SanBayDen, 
                       cb.ThoiGianDi, cb.ThoiGianDen, cb.GiaVe, cb.TrangThai 
                FROM CHUYENBAY cb 
                LEFT JOIN MAYBAY mb ON cb.MaMayBay = mb.MaMayBay 
                WHERE 1=1 ";

            if (!string.IsNullOrEmpty(tuKhoa))
            {
                sql += " AND (cb.MaChuyenBay LIKE @tk OR cb.SanBayDi LIKE @tk OR cb.SanBayDen LIKE @tk OR mb.TenMayBay LIKE @tk)";
            }

            sql += " ORDER BY cb.ThoiGianDi DESC;";

            dgvChuyenBay.DataSource = Database.GetData(sql, new MySqlParameter("@tk", $"%{tuKhoa}%"));

            UiTheme.SetCol(dgvChuyenBay, "MaChuyenBay", "Mã CB", width: 65, align: DataGridViewContentAlignment.MiddleCenter);
            UiTheme.SetCol(dgvChuyenBay, "MaMayBay", "Mã MB", visible: false);
            UiTheme.SetCol(dgvChuyenBay, "TenMayBay", "Tàu bay");
            UiTheme.SetCol(dgvChuyenBay, "SanBayDi", "Sân bay đi");
            UiTheme.SetCol(dgvChuyenBay, "SanBayDen", "Sân bay đến");
            UiTheme.SetCol(dgvChuyenBay, "ThoiGianDi", "Khởi hành", format: "dd/MM/yyyy HH:mm");
            UiTheme.SetCol(dgvChuyenBay, "ThoiGianDen", "Hạ cánh", format: "dd/MM/yyyy HH:mm");
            UiTheme.SetCol(dgvChuyenBay, "GiaVe", "Giá vé (VNĐ)", align: DataGridViewContentAlignment.MiddleRight, format: "N0");
            UiTheme.SetCol(dgvChuyenBay, "TrangThai", "Trạng thái", align: DataGridViewContentAlignment.MiddleCenter);
        }

        private void txtTimCb_TextChanged(object sender, EventArgs e)
        {
            TaiDanhSachChuyenBay(txtTimCb.Text.Trim());
        }

        private void btnLamMoiTim_Click(object sender, EventArgs e)
        {
            txtTimCb.Clear();
            TaiDanhSachChuyenBay();
        }

        private void dgvChuyenBay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow r = dgvChuyenBay.Rows[e.RowIndex];
            _maChuyenBayChon = Database.ToInt(r.Cells["MaChuyenBay"].Value);
            txtMaChuyenBay.Text = _maChuyenBayChon.ToString();
            if (r.Cells["MaMayBay"].Value != null && r.Cells["MaMayBay"].Value != DBNull.Value)
                cboMaMayBay.SelectedValue = Database.ToInt(r.Cells["MaMayBay"].Value);
            // ComboBox dạng DropDownList bỏ qua giá trị không có trong danh sách -> giữ nguyên sân bay cũ
            // và khi bấm Sửa sẽ ghi đè sai. Vì vậy thêm sân bay vào danh sách nếu chưa có.
            ChonSanBay(cboSanBayDi, r.Cells["SanBayDi"].Value?.ToString() ?? "");
            ChonSanBay(cboSanBayDen, r.Cells["SanBayDen"].Value?.ToString() ?? "");
            dtpThoiGianDi.Value = Database.ToDateTime(r.Cells["ThoiGianDi"].Value);
            dtpThoiGianDen.Value = Database.ToDateTime(r.Cells["ThoiGianDen"].Value);
            txtGiaVe.Text = Database.ToDecimal(r.Cells["GiaVe"].Value).ToString("0");
            cboTrangThai.Text = r.Cells["TrangThai"].Value?.ToString() ?? "Đang mở";
        }

        private static void ChonSanBay(ComboBox cbo, string sanBay)
        {
            if (string.IsNullOrWhiteSpace(sanBay)) return;
            if (!cbo.Items.Contains(sanBay)) cbo.Items.Add(sanBay);
            cbo.SelectedItem = sanBay;
        }

        // Kiểm tra dữ liệu nhập dùng chung cho Thêm và Sửa chuyến bay
        // maChuyenBayBoQua: khi Sửa thì bỏ qua chính chuyến đang sửa lúc kiểm tra trùng lịch (Thêm thì truyền 0)
        private bool KiemTraDuLieuChuyenBay(int maChuyenBayBoQua, out decimal giaVe)
        {
            giaVe = 0;

            if (cboSanBayDi.Text == cboSanBayDen.Text)
            {
                MessageBox.Show("Sân bay đi và sân bay đến không được trùng nhau!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dtpThoiGianDen.Value <= dtpThoiGianDi.Value)
            {
                MessageBox.Show("Thời gian hạ cánh phải sau thời gian khởi hành!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(txtGiaVe.Text.Trim(), out giaVe) || giaVe <= 0)
            {
                MessageBox.Show("Vui lòng nhập giá vé hợp lệ lớn hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // UC03: Kiểm tra trùng lịch - 1 máy bay không thể bay 2 chuyến có khung giờ giao nhau
            string sqlTrung = @"
                SELECT COUNT(*) FROM CHUYENBAY
                WHERE MaMayBay = @mb AND MaChuyenBay <> @id AND TrangThai <> 'Đã hủy'
                  AND ThoiGianDi < @t2 AND ThoiGianDen > @t1;";
            long soChuyenTrung = Database.ToLong(Database.ExecuteScalar(sqlTrung,
                new MySqlParameter("@mb", LayMaMayBayChon(cboMaMayBay)),
                new MySqlParameter("@id", maChuyenBayBoQua),
                new MySqlParameter("@t1", dtpThoiGianDi.Value),
                new MySqlParameter("@t2", dtpThoiGianDen.Value)));
            if (soChuyenTrung > 0)
            {
                MessageBox.Show("Máy bay này đã có chuyến bay khác trong khung giờ này (trùng lịch)!\nVui lòng chọn máy bay khác hoặc đổi giờ bay.", "Trùng lịch", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        // THÊM CHUYẾN BAY MỚI
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieuChuyenBay(0, out decimal giaVe)) return;

            try
            {
                string sql = @"
                    INSERT INTO CHUYENBAY (MaMayBay, SanBayDi, SanBayDen, ThoiGianDi, ThoiGianDen, GiaVe, TrangThai) 
                    VALUES (@mb, @di, @den, @t1, @t2, @gia, @tt);";

                int maMayBay = LayMaMayBayChon(cboMaMayBay);

                Database.ExecuteNonQuery(sql,
                    new MySqlParameter("@mb", maMayBay),
                    new MySqlParameter("@di", cboSanBayDi.Text),
                    new MySqlParameter("@den", cboSanBayDen.Text),
                    new MySqlParameter("@t1", dtpThoiGianDi.Value),
                    new MySqlParameter("@t2", dtpThoiGianDen.Value),
                    new MySqlParameter("@gia", giaVe),
                    new MySqlParameter("@tt", cboTrangThai.Text));

                MessageBox.Show("Thêm chuyến bay mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TaiDanhSachChuyenBay();
                btnLamMoi_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm chuyến bay: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // SỬA THÔNG TIN CHUYẾN BAY
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_maChuyenBayChon <= 0)
            {
                MessageBox.Show("Vui lòng click chọn 1 chuyến bay trong bảng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!KiemTraDuLieuChuyenBay(_maChuyenBayChon, out decimal giaVe)) return;
            if (!KiemTraChuyenTrangThai(out string trangThaiCu)) return;

            try
            {
                // Không cho đổi tàu bay khi chuyến đã có vé: ghế trong vé thuộc tàu bay cũ sẽ không còn khớp
                int maMayBayMoi = LayMaMayBayChon(cboMaMayBay);
                int maMayBayCu = Database.ToInt(Database.ExecuteScalar("SELECT MaMayBay FROM CHUYENBAY WHERE MaChuyenBay = @id;",
                    new MySqlParameter("@id", _maChuyenBayChon)));
                if (maMayBayCu > 0 && maMayBayCu != maMayBayMoi)
                {
                    long soVe = Database.ToLong(Database.ExecuteScalar("SELECT COUNT(*) FROM VE WHERE MaChuyenBay = @id AND TrangThai <> 'Đã hủy';",
                        new MySqlParameter("@id", _maChuyenBayChon)));
                    if (soVe > 0)
                    {
                        MessageBox.Show($"Chuyến bay #{_maChuyenBayChon} đã có {soVe} vé đặt chỗ nên không thể đổi sang tàu bay khác!", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                string sql = @"
                    UPDATE CHUYENBAY
                    SET MaMayBay = @mb, SanBayDi = @di, SanBayDen = @den, 
                        ThoiGianDi = @t1, ThoiGianDen = @t2, GiaVe = @gia, TrangThai = @tt 
                    WHERE MaChuyenBay = @id;";

                int maMayBay = LayMaMayBayChon(cboMaMayBay);

                Database.ExecuteNonQuery(sql,
                    new MySqlParameter("@mb", maMayBay),
                    new MySqlParameter("@di", cboSanBayDi.Text),
                    new MySqlParameter("@den", cboSanBayDen.Text),
                    new MySqlParameter("@t1", dtpThoiGianDi.Value),
                    new MySqlParameter("@t2", dtpThoiGianDen.Value),
                    new MySqlParameter("@gia", giaVe),
                    new MySqlParameter("@tt", cboTrangThai.Text),
                    new MySqlParameter("@id", _maChuyenBayChon));

                string thongBao = $"Cập nhật thông tin chuyến bay #{_maChuyenBayChon} thành công!";
                if (cboTrangThai.Text == "Đã hủy" && trangThaiCu != "Đã hủy")
                    thongBao += ChuyenVeChoCSKHKhiHuyChuyen();
                MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TaiDanhSachChuyenBay();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa chuyến bay: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // XÓA CHUYẾN BAY (KIỂM TRA AN TOÀN NẾU ĐÃ CÓ VÉ BÁN)
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_maChuyenBayChon <= 0)
            {
                MessageBox.Show("Vui lòng click chọn 1 chuyến bay cần xóa trong bảng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string sqlCheck = "SELECT COUNT(*) FROM VE WHERE MaChuyenBay = @id;";
                long soVe = Database.ToLong(Database.ExecuteScalar(sqlCheck, new MySqlParameter("@id", _maChuyenBayChon)));

                if (soVe > 0)
                {
                    MessageBox.Show($"Chuyến bay #{_maChuyenBayChon} đã có {soVe} vé được đặt/bán!\nKhông thể xóa chuyến bay để bảo vệ dữ liệu khách hàng.",
                        "Từ chối xóa", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (MessageBox.Show($"Bạn có chắc chắn muốn xóa chuyến bay #{_maChuyenBayChon}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string sqlDel = "DELETE FROM CHUYENBAY WHERE MaChuyenBay = @id;";
                    Database.ExecuteNonQuery(sqlDel, new MySqlParameter("@id", _maChuyenBayChon));

                    MessageBox.Show($"Đã xóa chuyến bay #{_maChuyenBayChon} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TaiDanhSachChuyenBay();
                    btnLamMoi_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa chuyến bay: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // CẬP NHẬT GIỜ BAY VÀ TRẠNG THÁI
        private void btnCapNhatGioBay_Click(object sender, EventArgs e)
        {
            if (_maChuyenBayChon <= 0)
            {
                MessageBox.Show("Vui lòng chọn chuyến bay cần cập nhật trạng thái!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpThoiGianDen.Value <= dtpThoiGianDi.Value)
            {
                MessageBox.Show("Thời gian hạ cánh phải sau thời gian khởi hành!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!KiemTraChuyenTrangThai(out string trangThaiCu)) return;

            try
            {
                string sql = "UPDATE CHUYENBAY SET ThoiGianDi = @t1, ThoiGianDen = @t2, TrangThai = @tt WHERE MaChuyenBay = @id;";
                Database.ExecuteNonQuery(sql,
                    new MySqlParameter("@t1", dtpThoiGianDi.Value),
                    new MySqlParameter("@t2", dtpThoiGianDen.Value),
                    new MySqlParameter("@tt", cboTrangThai.Text),
                    new MySqlParameter("@id", _maChuyenBayChon));

                string thongBao = $"Đã cập nhật giờ bay và trạng thái chuyến bay thành '{cboTrangThai.Text}'!";
                if (cboTrangThai.Text == "Đã hủy" && trangThaiCu != "Đã hủy")
                    thongBao += ChuyenVeChoCSKHKhiHuyChuyen();

                MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TaiDanhSachChuyenBay();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // UC04: Kiểm tra phép chuyển trạng thái chuyến bay có hợp lệ không
        // Thứ tự: Đang mở -> Sắp cất cánh -> Đã cất cánh -> Hoàn tất (không được đi ngược)
        // "Đã hủy" chỉ được chọn khi chuyến bay chưa cất cánh. "Hoàn tất" và "Đã hủy" là trạng thái kết thúc.
        private bool KiemTraChuyenTrangThai(out string trangThaiCu)
        {
            trangThaiCu = Database.ToStr(Database.ExecuteScalar("SELECT TrangThai FROM CHUYENBAY WHERE MaChuyenBay = @id;",
                new MySqlParameter("@id", _maChuyenBayChon)));
            string trangThaiMoi = cboTrangThai.Text;
            if (trangThaiCu == trangThaiMoi || trangThaiCu == "") return true;

            string[] thuTu = { "Đang mở", "Sắp cất cánh", "Đã cất cánh", "Hoàn tất" };
            int viTriCu = Array.IndexOf(thuTu, trangThaiCu);
            int viTriMoi = Array.IndexOf(thuTu, trangThaiMoi);

            string? loi = null;
            if (trangThaiCu == "Hoàn tất" || trangThaiCu == "Đã hủy")
                loi = $"Chuyến bay đã ở trạng thái kết thúc '{trangThaiCu}', không thể đổi trạng thái nữa!";
            else if (trangThaiMoi == "Đã hủy" && viTriCu >= 2)
                loi = "Chuyến bay đã cất cánh, không thể hủy chuyến!";
            else if (viTriMoi >= 0 && viTriMoi < viTriCu)
                loi = $"Không thể chuyển ngược từ '{trangThaiCu}' về '{trangThaiMoi}'!";

            if (loi != null)
            {
                MessageBox.Show(loi, "Chuyển trạng thái không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // UC04 (luồng phụ 4b): Hủy chuyến -> mỗi vé còn hiệu lực sinh 1 yêu cầu đưa sang hàng đợi của bộ phận CSKH
        private string ChuyenVeChoCSKHKhiHuyChuyen()
        {
            string sql = @"
                INSERT INTO YEUCAU_CSKH (MaVe, TenKhach, LoaiYeuCau, NoiDung, NgayTao, TrangThai)
                SELECT v.MaVe, kh.HoTen, 'Đổi chuyến bay',
                       CONCAT('Chuyến bay #', v.MaChuyenBay, ' bị hủy. Cần liên hệ khách để đổi chuyến hoặc hủy vé & hoàn tiền.'),
                       NOW(), 'Tiếp nhận'
                FROM VE v JOIN KHACHHANG kh ON v.MaKH = kh.MaKH
                WHERE v.MaChuyenBay = @id AND v.TrangThai <> 'Đã hủy';";
            int soVe = Database.ExecuteNonQuery(sql, new MySqlParameter("@id", _maChuyenBayChon));
            return soVe > 0
                ? $"\n\nĐã chuyển {soVe} vé bị ảnh hưởng sang bộ phận CSKH để xử lý đổi chuyến / hoàn tiền."
                : "";
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            _maChuyenBayChon = 0;
            txtMaChuyenBay.Clear();
            cboSanBayDi.SelectedIndex = 0;
            cboSanBayDen.SelectedIndex = 1;
            txtGiaVe.Text = "1500000";
            cboTrangThai.SelectedIndex = 0;
            dtpThoiGianDi.Value = DateTime.Now.AddDays(1);
            dtpThoiGianDen.Value = DateTime.Now.AddDays(1).AddHours(2);
        }

        // =========================================================================
        // PHẦN 2: CẬP NHẬT TÌNH TRẠNG GHẾ (KHÓA GHẾ BẢO TRÌ, PHỤC HỒI GHẾ TRỐNG)
        // =========================================================================

        private void TaiDanhSachGhe()
        {
            int maMb = LayMaMayBayChon(cboMayBayGhe);
            string sql = "SELECT MaGhe, MaMayBay, SoGhe, HangGhe, TrangThai FROM GHE WHERE MaMayBay = @mb ORDER BY MaGhe ASC;";
            DataTable dt = Database.GetData(sql, new MySqlParameter("@mb", maMb));
            dgvGhe.DataSource = dt;

            lblThongKeGhe.Text = $"Tổng số ghế: {dt.Rows.Count} ghế";

            UiTheme.SetCol(dgvGhe, "MaGhe", "Mã ghế", width: 65, align: DataGridViewContentAlignment.MiddleCenter);
            UiTheme.SetCol(dgvGhe, "MaMayBay", "Mã MB", visible: false);
            UiTheme.SetCol(dgvGhe, "SoGhe", "Số ghế", align: DataGridViewContentAlignment.MiddleCenter);
            UiTheme.SetCol(dgvGhe, "HangGhe", "Hạng ghế", align: DataGridViewContentAlignment.MiddleCenter);
            UiTheme.SetCol(dgvGhe, "TrangThai", "Tình trạng", align: DataGridViewContentAlignment.MiddleCenter);
        }

        private void cboMayBayGhe_SelectedIndexChanged(object sender, EventArgs e)
        {
            TaiDanhSachGhe();
        }

        private void dgvGhe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow r = dgvGhe.Rows[e.RowIndex];
            _maGheChon = Database.ToInt(r.Cells["MaGhe"].Value);
            string soGhe = r.Cells["SoGhe"].Value?.ToString() ?? "";
            string tt = r.Cells["TrangThai"].Value?.ToString() ?? "Trong";

            lblGheDangChon.Text = $"Ghế đang chọn: {soGhe} (Hiện tại: {tt})";

            if (cboTrangThaiGheMoi.Items.Contains(tt))
                cboTrangThaiGheMoi.Text = tt;
        }

        // CẬP NHẬT TÌNH TRẠNG 1 GHẾ (VÍ DỤ: KHÓA BẢO TRÌ HOẶC MỞ TRỐNG)
        private void btnCapNhatGhe_Click(object sender, EventArgs e)
        {
            if (_maGheChon <= 0)
            {
                MessageBox.Show("Vui lòng chọn một ghế trong bảng ghế cần cập nhật tình trạng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string sql = "UPDATE GHE SET TrangThai = @tt WHERE MaGhe = @id;";
                Database.ExecuteNonQuery(sql,
                    new MySqlParameter("@tt", cboTrangThaiGheMoi.Text),
                    new MySqlParameter("@id", _maGheChon));

                MessageBox.Show($"Đã cập nhật tình trạng ghế thành '{cboTrangThaiGheMoi.Text}'!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TaiDanhSachGhe();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // XÓA 1 GHẾ (chỉ xóa được khi ghế chưa từng có vé)
        private void btnXoaGhe_Click(object sender, EventArgs e)
        {
            if (_maGheChon <= 0)
            {
                MessageBox.Show("Vui lòng chọn một ghế trong bảng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra ghế đã có vé chưa
            long soVe = Database.ToLong(Database.ExecuteScalar("SELECT COUNT(*) FROM VE WHERE MaGhe = @id;",
                new MySqlParameter("@id", _maGheChon)));
            if (soVe > 0)
            {
                MessageBox.Show("Ghế này đã có vé đặt nên không thể xóa! Bạn có thể chuyển ghế sang 'Bảo trì'.", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa ghế này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    Database.ExecuteNonQuery("DELETE FROM GHE WHERE MaGhe = @id;", new MySqlParameter("@id", _maGheChon));
                    MessageBox.Show("Xóa ghế thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _maGheChon = 0;
                    lblGheDangChon.Text = "Ghế đang chọn: (chưa chọn)";
                    TaiDanhSachGhe();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa ghế: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ĐẶT TẤT CẢ GHẾ BẢO TRÌ TRỞ LẠI CÒN TRỐNG
        private void btnKhoiPhucTatCaGhe_Click(object sender, EventArgs e)
        {
            int maMb = LayMaMayBayChon(cboMayBayGhe);
            if (MessageBox.Show("Khôi phục tất cả ghế đang bảo trì về trạng thái 'Trong' (Sẵn sàng phục vụ)?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string sql = "UPDATE GHE SET TrangThai = 'Trong' WHERE MaMayBay = @mb AND TrangThai = 'Bảo trì';";
                    int soGhe = Database.ExecuteNonQuery(sql, new MySqlParameter("@mb", maMb));

                    MessageBox.Show($"Đã khôi phục {soGhe} ghế bảo trì về trạng thái còn trống!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TaiDanhSachGhe();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // TỰ ĐỘNG SINH GHẾ MẪU CHO TÀU BAY MỚI
        private void btnSinhGheMau_Click(object sender, EventArgs e)
        {
            int maMb = LayMaMayBayChon(cboMayBayGhe);
            try
            {
                string[] hangTG = { "A1", "A2", "B1", "B2" };
                string[] hangPT = { "C1", "C2", "D1", "D2", "E1", "E2" };

                // Chỉ thêm những ghế chưa có trên tàu bay (bấm nhiều lần không bị nhân đôi ghế A1, A2...)
                string sqlThem = @"
                    INSERT INTO GHE (MaMayBay, SoGhe, HangGhe, TrangThai)
                    SELECT @mb, @so, @hang, 'Trong' FROM DUAL
                    WHERE NOT EXISTS (SELECT 1 FROM GHE WHERE MaMayBay = @mb AND SoGhe = @so);";

                int soGheThem = 0;
                foreach (string g in hangTG)
                {
                    soGheThem += Database.ExecuteNonQuery(sqlThem,
                        new MySqlParameter("@mb", maMb),
                        new MySqlParameter("@so", g),
                        new MySqlParameter("@hang", "Thuong gia"));
                }

                foreach (string g in hangPT)
                {
                    soGheThem += Database.ExecuteNonQuery(sqlThem,
                        new MySqlParameter("@mb", maMb),
                        new MySqlParameter("@so", g),
                        new MySqlParameter("@hang", "Pho thong"));
                }

                MessageBox.Show(soGheThem > 0
                        ? $"Đã sinh thêm {soGheThem} ghế mẫu thành công!"
                        : "Tàu bay này đã có đủ các ghế mẫu, không cần sinh thêm.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TaiDanhSachGhe();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sinh ghế: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
