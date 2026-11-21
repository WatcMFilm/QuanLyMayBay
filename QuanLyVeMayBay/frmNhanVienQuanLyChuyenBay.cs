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

            // Tải danh mục tàu bay vào ComboBox (đặt DisplayMember & ValueMember trước khi gán DataSource)
            DataTable dtMayBay = Database.GetData("SELECT MaMayBay, TenMayBay FROM MAYBAY;");
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
                sql += $" AND (cb.MaChuyenBay LIKE '%{tuKhoa}%' OR cb.SanBayDi LIKE '%{tuKhoa}%' OR cb.SanBayDen LIKE '%{tuKhoa}%' OR mb.TenMayBay LIKE '%{tuKhoa}%')";
            }

            sql += " ORDER BY cb.ThoiGianDi DESC;";

            dgvChuyenBay.DataSource = Database.GetData(sql);

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
            cboSanBayDi.Text = r.Cells["SanBayDi"].Value?.ToString() ?? "";
            cboSanBayDen.Text = r.Cells["SanBayDen"].Value?.ToString() ?? "";
            dtpThoiGianDi.Value = Database.ToDateTime(r.Cells["ThoiGianDi"].Value);
            dtpThoiGianDen.Value = Database.ToDateTime(r.Cells["ThoiGianDen"].Value);
            txtGiaVe.Text = Database.ToDecimal(r.Cells["GiaVe"].Value).ToString("0");
            cboTrangThai.Text = r.Cells["TrangThai"].Value?.ToString() ?? "Đang mở";
        }

        // THÊM CHUYẾN BAY MỚI
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cboSanBayDi.Text == cboSanBayDen.Text)
            {
                MessageBox.Show("Sân bay đi và sân bay đến không được trùng nhau!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpThoiGianDen.Value <= dtpThoiGianDi.Value)
            {
                MessageBox.Show("Thời gian hạ cánh phải sau thời gian khởi hành!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal giaVe = 0;
            if (!decimal.TryParse(txtGiaVe.Text.Trim(), out giaVe) || giaVe <= 0)
            {
                MessageBox.Show("Vui lòng nhập giá vé hợp lệ lớn hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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

            if (dtpThoiGianDen.Value <= dtpThoiGianDi.Value)
            {
                MessageBox.Show("Thời gian hạ cánh phải sau thời gian khởi hành!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal giaVe = 0;
            decimal.TryParse(txtGiaVe.Text.Trim(), out giaVe);

            try
            {
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

                MessageBox.Show($"Cập nhật thông tin chuyến bay #{_maChuyenBayChon} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            try
            {
                string sql = "UPDATE CHUYENBAY SET ThoiGianDi = @t1, ThoiGianDen = @t2, TrangThai = @tt WHERE MaChuyenBay = @id;";
                Database.ExecuteNonQuery(sql,
                    new MySqlParameter("@t1", dtpThoiGianDi.Value),
                    new MySqlParameter("@t2", dtpThoiGianDen.Value),
                    new MySqlParameter("@tt", cboTrangThai.Text),
                    new MySqlParameter("@id", _maChuyenBayChon));

                MessageBox.Show($"Đã cập nhật giờ bay và trạng thái chuyến bay thành '{cboTrangThai.Text}'!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TaiDanhSachChuyenBay();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                foreach (string g in hangTG)
                {
                    Database.ExecuteNonQuery("INSERT INTO GHE (MaMayBay, SoGhe, HangGhe, TrangThai) VALUES (@mb, @so, 'Thuong gia', 'Trong');",
                        new MySqlParameter("@mb", maMb),
                        new MySqlParameter("@so", g));
                }

                foreach (string g in hangPT)
                {
                    Database.ExecuteNonQuery("INSERT INTO GHE (MaMayBay, SoGhe, HangGhe, TrangThai) VALUES (@mb, @so, 'Pho thong', 'Trong');",
                        new MySqlParameter("@mb", maMb),
                        new MySqlParameter("@so", g));
                }

                MessageBox.Show("Đã sinh danh sách ghế mẫu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TaiDanhSachGhe();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sinh ghế: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
