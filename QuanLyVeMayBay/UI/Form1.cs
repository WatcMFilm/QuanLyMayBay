using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using QuanLyVeMayBay.DAL;

namespace QuanLyVeMayBay
{
    public partial class Form1 : Form
    {
        private readonly Database db = new Database();

        // Khởi tạo Form
        public Form1()
        {
            InitializeComponent();
        }

        // Xử lý khi Form được tải
        private void Form1_Load(object sender, EventArgs e)
        {
            CaiDatGiaoDien();
            KhoiTaoTrangThai();
            LoadSanBay();
            LoadMayBay();
            HienThiChuyenBay();
            XoaTrang();
        }

        // Cài đặt giao diện chuẩn Doanh nghiệp
        private void CaiDatGiaoDien()
        {
            UiTheme.ApplyFormStyle(this);
            UiTheme.ApplyCardStyle(grpThongTin);
            UiTheme.ApplyCardStyle(grpDanhSach);

            UiTheme.ApplyButtonStyle(btnThem, UiTheme.SuccessGreen, UiTheme.SuccessGreenHover, Color.White);
            UiTheme.ApplyButtonStyle(btnSua, UiTheme.WarningAmber, UiTheme.WarningAmberHover, Color.White);
            UiTheme.ApplyButtonStyle(btnXoa, UiTheme.DangerRose, UiTheme.DangerRoseHover, Color.White);
            UiTheme.ApplyButtonStyle(btnLamMoi, UiTheme.SecondarySlate, UiTheme.SecondarySlateHover, Color.White);
            UiTheme.ApplyButtonStyle(btnMoDatVe, UiTheme.PrimaryBlue, UiTheme.PrimaryBlueHover, Color.White);
            UiTheme.ApplyButtonStyle(btnMoThanhToan, Color.FromArgb(14, 165, 233), Color.FromArgb(2, 132, 199), Color.White);

            dgvChuyenBay.CellFormatting += dgvChuyenBay_CellFormatting;
        }

        // Định dạng hiển thị màu sắc trạng thái chuyến bay
        private void dgvChuyenBay_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            UiTheme.FormatStatusCell(e, "TrangThai", dgvChuyenBay);
        }

        // Mở form đặt vé
        private void btnMoDatVe_Click(object sender, EventArgs e)
        {
            using (frmDatVe formDatVe = new frmDatVe())
            {
                formDatVe.ShowDialog();
            }
        }

        // Mở form thanh toán và lập hóa đơn
        private void btnMoThanhToan_Click(object sender, EventArgs e)
        {
            using (frmThanhToan formThanhToan = new frmThanhToan())
            {
                formThanhToan.ShowDialog();
            }
        }

        // Tải danh sách máy bay
        private void LoadMayBay()
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT MaMayBay, TenMayBay FROM MAYBAY WHERE TrangThai = 'Hoạt động' ORDER BY MaMayBay;";
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dtMayBay = new DataTable();
                        adapter.Fill(dtMayBay);

                        dtMayBay.Columns.Add("HienThi", typeof(string));
                        foreach (DataRow dong in dtMayBay.Rows)
                        {
                            dong["HienThi"] = $"{dong["MaMayBay"]} - {dong["TenMayBay"]}";
                        }

                        cboMaMayBay.DataSource = dtMayBay;
                        cboMaMayBay.DisplayMember = "HienThi";
                        cboMaMayBay.ValueMember = "MaMayBay";
                        cboMaMayBay.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách máy bay: " + ex.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Tạo danh sách sân bay
        private DataTable TaoBangSanBay()
        {
            DataTable dtSanBay = new DataTable();
            dtSanBay.Columns.Add("MaSanBay", typeof(string));
            dtSanBay.Columns.Add("TenSanBay", typeof(string));
            dtSanBay.Columns.Add("HienThi", typeof(string));

            void ThemSanBay(string maSanBay, string tenSanBay, string chuoiHienThi)
            {
                dtSanBay.Rows.Add(maSanBay, tenSanBay, chuoiHienThi);
            }

            ThemSanBay("HAN", "Nội Bài (Hà Nội)", "HAN - Nội Bài (Hà Nội)");
            ThemSanBay("SGN", "Tân Sơn Nhất (TP.HCM)", "SGN - Tân Sơn Nhất (TP.HCM)");
            ThemSanBay("DAD", "Đà Nẵng", "DAD - Đà Nẵng");
            ThemSanBay("CXR", "Cam Ranh", "CXR - Cam Ranh");
            ThemSanBay("PQC", "Phú Quốc", "PQC - Phú Quốc");
            ThemSanBay("HPH", "Cát Bi (Hải Phòng)", "HPH - Cát Bi (Hải Phòng)");
            ThemSanBay("VDO", "Vân Đồn", "VDO - Vân Đồn");
            ThemSanBay("VII", "Vinh", "VII - Vinh");
            ThemSanBay("HUI", "Phú Bài (Huế)", "HUI - Phú Bài (Huế)");
            ThemSanBay("UIH", "Phù Cát (Quy Nhơn)", "UIH - Phù Cát (Quy Nhơn)");
            ThemSanBay("BKK", "Suvarnabhumi (BKK)", "BKK - Suvarnabhumi (BKK)");
            ThemSanBay("NRT", "Narita (NRT)", "NRT - Narita (NRT)");

            return dtSanBay;
        }

        // Tải danh sách sân bay
        private void LoadSanBay()
        {
            DataTable dtSanBayDi = TaoBangSanBay();
            cboSanBayDi.DataSource = dtSanBayDi;
            cboSanBayDi.DisplayMember = "HienThi";
            cboSanBayDi.ValueMember = "HienThi";
            cboSanBayDi.SelectedIndex = -1;

            DataTable dtSanBayDen = TaoBangSanBay();
            cboSanBayDen.DataSource = dtSanBayDen;
            cboSanBayDen.DisplayMember = "HienThi";
            cboSanBayDen.ValueMember = "HienThi";
            cboSanBayDen.SelectedIndex = -1;
        }

        // Chọn sân bay trong ComboBox
        private void ChonSanBay(ComboBox cbo, string giaTriSanBay)
        {
            if (string.IsNullOrWhiteSpace(giaTriSanBay))
            {
                cbo.SelectedIndex = -1;
                return;
            }

            string giaTri = giaTriSanBay.Trim();

            for (int i = 0; i < cbo.Items.Count; i++)
            {
                string? chuoiHienThi = cbo.GetItemText(cbo.Items[i]);
                if (string.Equals(chuoiHienThi, giaTri, StringComparison.OrdinalIgnoreCase))
                {
                    cbo.SelectedIndex = i;
                    return;
                }

                if (cbo.Items[i] is DataRowView dongView)
                {
                    string maSanBay = dongView["MaSanBay"]?.ToString() ?? "";
                    string tenSanBay = dongView["TenSanBay"]?.ToString() ?? "";
                    string hienThi = dongView["HienThi"]?.ToString() ?? "";
                    if (string.Equals(maSanBay, giaTri, StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(tenSanBay, giaTri, StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(hienThi, giaTri, StringComparison.OrdinalIgnoreCase))
                    {
                        cbo.SelectedIndex = i;
                        return;
                    }
                }
            }

            string maIATA = "";
            int ngoacMo = giaTri.IndexOf('(');
            int ngoacDong = giaTri.IndexOf(')');
            if (ngoacMo >= 0 && ngoacDong > ngoacMo)
            {
                maIATA = giaTri.Substring(ngoacMo + 1, ngoacDong - ngoacMo - 1).Trim();
            }
            else if (giaTri.Length == 3)
            {
                maIATA = giaTri;
            }

            if (!string.IsNullOrEmpty(maIATA))
            {
                for (int i = 0; i < cbo.Items.Count; i++)
                {
                    if (cbo.Items[i] is DataRowView dongView)
                    {
                        string maSanBay = dongView["MaSanBay"]?.ToString() ?? "";
                        if (string.Equals(maSanBay, maIATA, StringComparison.OrdinalIgnoreCase))
                        {
                            cbo.SelectedIndex = i;
                            return;
                        }
                    }
                    string? chuoiItem = cbo.GetItemText(cbo.Items[i]);
                    if (!string.IsNullOrEmpty(chuoiItem) && chuoiItem.IndexOf(maIATA, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        cbo.SelectedIndex = i;
                        return;
                    }
                }
            }

            for (int i = 0; i < cbo.Items.Count; i++)
            {
                if (cbo.Items[i] is DataRowView dongView)
                {
                    string tenSanBay = dongView["TenSanBay"]?.ToString() ?? "";
                    if (!string.IsNullOrEmpty(tenSanBay) && (giaTri.IndexOf(tenSanBay, StringComparison.OrdinalIgnoreCase) >= 0 || tenSanBay.IndexOf(giaTri, StringComparison.OrdinalIgnoreCase) >= 0))
                    {
                        cbo.SelectedIndex = i;
                        return;
                    }
                }
            }

            if (cbo.DropDownStyle == ComboBoxStyle.DropDown)
            {
                cbo.Text = giaTri;
            }
            else
            {
                cbo.SelectedIndex = -1;
            }
        }

        // Khởi tạo danh sách trạng thái
        private void KhoiTaoTrangThai()
        {
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add("Đang mở");
            cboTrangThai.Items.Add("Sắp cất cánh");
            cboTrangThai.Items.Add("Đã cất cánh");
            cboTrangThai.Items.Add("Hoàn tất");
            cboTrangThai.Items.Add("Đã hủy");
            cboTrangThai.SelectedIndex = 0;
        }

        // Hiển thị danh sách chuyến bay
        private void HienThiChuyenBay()
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT MaChuyenBay, MaMayBay, SanBayDi, SanBayDen, ThoiGianDi, ThoiGianDen, GiaVe, TrangThai FROM chuyenbay ORDER BY MaChuyenBay DESC";
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dtChuyenBay = new DataTable();
                        adapter.Fill(dtChuyenBay);
                        dgvChuyenBay.DataSource = dtChuyenBay;
                    }
                }

                DinhDangBang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách chuyến bay: " + ex.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Định dạng bảng chuyến bay
        private void DinhDangBang()
        {
            UiTheme.ApplyDataGridStyle(dgvChuyenBay);

            if (dgvChuyenBay.Columns.Count > 0)
            {
                if (dgvChuyenBay.Columns.Contains("MaChuyenBay") && dgvChuyenBay.Columns["MaChuyenBay"] is DataGridViewColumn colMaChuyenBay)
                {
                    colMaChuyenBay.HeaderText = "Mã chuyến bay";
                    colMaChuyenBay.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                if (dgvChuyenBay.Columns.Contains("MaMayBay") && dgvChuyenBay.Columns["MaMayBay"] is DataGridViewColumn colMaMayBay)
                {
                    colMaMayBay.HeaderText = "Mã máy bay";
                    colMaMayBay.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                if (dgvChuyenBay.Columns.Contains("SanBayDi") && dgvChuyenBay.Columns["SanBayDi"] is DataGridViewColumn colSanBayDi)
                    colSanBayDi.HeaderText = "Sân bay đi";
                if (dgvChuyenBay.Columns.Contains("SanBayDen") && dgvChuyenBay.Columns["SanBayDen"] is DataGridViewColumn colSanBayDen)
                    colSanBayDen.HeaderText = "Sân bay đến";
                if (dgvChuyenBay.Columns.Contains("ThoiGianDi") && dgvChuyenBay.Columns["ThoiGianDi"] is DataGridViewColumn colThoiGianDi)
                {
                    colThoiGianDi.HeaderText = "Thời gian đi";
                    colThoiGianDi.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                }
                if (dgvChuyenBay.Columns.Contains("ThoiGianDen") && dgvChuyenBay.Columns["ThoiGianDen"] is DataGridViewColumn colThoiGianDen)
                {
                    colThoiGianDen.HeaderText = "Thời gian đến";
                    colThoiGianDen.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                }
                if (dgvChuyenBay.Columns.Contains("GiaVe") && dgvChuyenBay.Columns["GiaVe"] is DataGridViewColumn colGiaVe)
                {
                    colGiaVe.HeaderText = "Giá vé (VNĐ)";
                    colGiaVe.DefaultCellStyle.Format = "N0";
                    colGiaVe.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                if (dgvChuyenBay.Columns.Contains("TrangThai") && dgvChuyenBay.Columns["TrangThai"] is DataGridViewColumn colTrangThai)
                {
                    colTrangThai.HeaderText = "Trạng thái";
                    colTrangThai.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }

        // Kiểm tra dữ liệu nhập
        private bool KiemTraNhapLieu(out int maMayBay, out decimal giaVe)
        {
            maMayBay = 0;
            giaVe = 0;

            if (cboMaMayBay.SelectedValue == null || !int.TryParse(cboMaMayBay.SelectedValue.ToString(), out maMayBay) || maMayBay <= 0)
            {
                MessageBox.Show("Vui lòng chọn máy bay.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaMayBay.Focus();
                return false;
            }

            if (cboSanBayDi.SelectedIndex < 0 || string.IsNullOrWhiteSpace(cboSanBayDi.Text))
            {
                MessageBox.Show("Vui lòng chọn sân bay đi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboSanBayDi.Focus();
                return false;
            }

            if (cboSanBayDen.SelectedIndex < 0 || string.IsNullOrWhiteSpace(cboSanBayDen.Text))
            {
                MessageBox.Show("Vui lòng chọn sân bay đến!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboSanBayDen.Focus();
                return false;
            }

            string sanBayDi = cboSanBayDi.Text.Trim();
            string sanBayDen = cboSanBayDen.Text.Trim();
            bool trungSanBay = false;

            if (cboSanBayDi.SelectedItem is DataRowView rowSanBayDi && cboSanBayDen.SelectedItem is DataRowView rowSanBayDen)
            {
                string maSanBayDi = rowSanBayDi["MaSanBay"]?.ToString() ?? "";
                string maSanBayDen = rowSanBayDen["MaSanBay"]?.ToString() ?? "";
                if (!string.IsNullOrEmpty(maSanBayDi) && !string.IsNullOrEmpty(maSanBayDen) && maSanBayDi.Equals(maSanBayDen, StringComparison.OrdinalIgnoreCase))
                {
                    trungSanBay = true;
                }
            }
            if (sanBayDi.Equals(sanBayDen, StringComparison.OrdinalIgnoreCase))
            {
                trungSanBay = true;
            }

            if (trungSanBay)
            {
                MessageBox.Show("Sân bay đi và sân bay đến không được giống nhau.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboSanBayDen.Focus();
                return false;
            }

            if (dtpThoiGianDen.Value <= dtpThoiGianDi.Value)
            {
                MessageBox.Show("Thời gian đến phải sau thời gian đi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpThoiGianDen.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtGiaVe.Text))
            {
                MessageBox.Show("Vui lòng nhập giá vé!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiaVe.Focus();
                return false;
            }

            string giaVeChuoi = txtGiaVe.Text.Trim().Replace(",", "").Replace(" ", "");
            if (!decimal.TryParse(giaVeChuoi, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out giaVe) &&
                !decimal.TryParse(giaVeChuoi, out giaVe))
            {
                MessageBox.Show("Giá vé không hợp lệ! Vui lòng nhập số tiền.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiaVe.Focus();
                return false;
            }

            if (giaVe <= 0)
            {
                MessageBox.Show("Giá vé phải lớn hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiaVe.Focus();
                return false;
            }

            return true;
        }

        // Thêm chuyến bay
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraNhapLieu(out int maMayBay, out decimal giaVe))
                return;

            string sanBayDi = cboSanBayDi.Text.Trim();
            string sanBayDen = cboSanBayDen.Text.Trim();
            string trangThai = string.IsNullOrWhiteSpace(cboTrangThai.Text) ? "Đang mở" : cboTrangThai.Text.Trim();

            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string query = @"INSERT INTO chuyenbay (MaMayBay, SanBayDi, SanBayDen, ThoiGianDi, ThoiGianDen, GiaVe, TrangThai) 
                                     VALUES (@MaMayBay, @SanBayDi, @SanBayDen, @ThoiGianDi, @ThoiGianDen, @GiaVe, @TrangThai)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.Add("@MaMayBay", MySqlDbType.Int32).Value = maMayBay;
                        cmd.Parameters.Add("@SanBayDi", MySqlDbType.VarChar, 100).Value = sanBayDi;
                        cmd.Parameters.Add("@SanBayDen", MySqlDbType.VarChar, 100).Value = sanBayDen;
                        cmd.Parameters.Add("@ThoiGianDi", MySqlDbType.DateTime).Value = dtpThoiGianDi.Value;
                        cmd.Parameters.Add("@ThoiGianDen", MySqlDbType.DateTime).Value = dtpThoiGianDen.Value;
                        cmd.Parameters.Add("@GiaVe", MySqlDbType.Decimal).Value = giaVe;
                        cmd.Parameters.Add("@TrangThai", MySqlDbType.VarChar, 50).Value = trangThai;

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Thêm chuyến bay thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                XoaTrang();
                HienThiChuyenBay();
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1452)
                {
                    MessageBox.Show($"Mã máy bay '{maMayBay}' không tồn tại trong hệ thống! Vui lòng kiểm tra lại mã máy bay.", "Lỗi ràng buộc khóa ngoại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ex.Number == 1062)
                {
                    MessageBox.Show("Mã chuyến bay đã tồn tại trong cơ sở dữ liệu!", "Trùng khóa chính", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Lỗi MySQL khi thêm chuyến bay: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm chuyến bay: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sửa chuyến bay
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaChuyenBay.Text) || !int.TryParse(txtMaChuyenBay.Text.Trim(), out int maChuyenBay))
            {
                MessageBox.Show("Vui lòng chọn hoặc nhập mã chuyến bay hợp lệ cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaChuyenBay.Focus();
                return;
            }

            if (!KiemTraNhapLieu(out int maMayBay, out decimal giaVe))
                return;

            string sanBayDi = cboSanBayDi.Text.Trim();
            string sanBayDen = cboSanBayDen.Text.Trim();
            string trangThai = string.IsNullOrWhiteSpace(cboTrangThai.Text) ? "Đang mở" : cboTrangThai.Text.Trim();

            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string query = @"UPDATE chuyenbay 
                                     SET MaMayBay = @MaMayBay, 
                                         SanBayDi = @SanBayDi, 
                                         SanBayDen = @SanBayDen, 
                                         ThoiGianDi = @ThoiGianDi, 
                                         ThoiGianDen = @ThoiGianDen, 
                                         GiaVe = @GiaVe, 
                                         TrangThai = @TrangThai 
                                     WHERE MaChuyenBay = @MaChuyenBay";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.Add("@MaChuyenBay", MySqlDbType.Int32).Value = maChuyenBay;
                        cmd.Parameters.Add("@MaMayBay", MySqlDbType.Int32).Value = maMayBay;
                        cmd.Parameters.Add("@SanBayDi", MySqlDbType.VarChar, 100).Value = sanBayDi;
                        cmd.Parameters.Add("@SanBayDen", MySqlDbType.VarChar, 100).Value = sanBayDen;
                        cmd.Parameters.Add("@ThoiGianDi", MySqlDbType.DateTime).Value = dtpThoiGianDi.Value;
                        cmd.Parameters.Add("@ThoiGianDen", MySqlDbType.DateTime).Value = dtpThoiGianDen.Value;
                        cmd.Parameters.Add("@GiaVe", MySqlDbType.Decimal).Value = giaVe;
                        cmd.Parameters.Add("@TrangThai", MySqlDbType.VarChar, 50).Value = trangThai;

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cập nhật thông tin chuyến bay thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            XoaTrang();
                            HienThiChuyenBay();
                        }
                        else
                        {
                            MessageBox.Show($"Không tìm thấy chuyến bay có mã '{maChuyenBay}' để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1452)
                {
                    MessageBox.Show($"Mã máy bay '{maMayBay}' không tồn tại trong hệ thống!", "Lỗi ràng buộc khóa ngoại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Lỗi MySQL khi cập nhật chuyến bay: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật chuyến bay: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xóa chuyến bay
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaChuyenBay.Text) || !int.TryParse(txtMaChuyenBay.Text.Trim(), out int maChuyenBay))
            {
                MessageBox.Show("Vui lòng chọn chuyến bay cần xóa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa chuyến bay có mã {maChuyenBay} không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) 
                return;

            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM chuyenbay WHERE MaChuyenBay = @MaChuyenBay";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.Add("@MaChuyenBay", MySqlDbType.Int32).Value = maChuyenBay;
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Xóa chuyến bay thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            XoaTrang();
                            HienThiChuyenBay();
                        }
                        else
                        {
                            MessageBox.Show($"Không tìm thấy chuyến bay có mã '{maChuyenBay}' để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1451)
                {
                    MessageBox.Show("Không thể xóa chuyến bay này vì đã có dữ liệu vé hoặc hóa đơn liên quan trong hệ thống!", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Lỗi MySQL khi xóa chuyến bay: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa chuyến bay: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Cập nhật trạng thái chuyến bay đã đến giờ khởi hành
        private void CapNhatTrangThaiChuyenBay()
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string query = @"UPDATE CHUYENBAY 
                                     SET TrangThai = 'Đã khởi hành' 
                                     WHERE ThoiGianDi <= @ThoiGianHienTai 
                                     AND TrangThai = 'Đang mở';";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.Add("@ThoiGianHienTai", MySqlDbType.DateTime).Value = DateTime.Now;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Lỗi MySQL khi cập nhật trạng thái chuyến bay: " + ex.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật trạng thái chuyến bay: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Làm mới dữ liệu trên form
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            CapNhatTrangThaiChuyenBay();
            HienThiChuyenBay();
            XoaTrang();
        }

        // Xóa dữ liệu trên form
        private void XoaTrang()
        {
            txtMaChuyenBay.Clear();
            cboMaMayBay.SelectedIndex = -1;
            cboSanBayDi.SelectedIndex = -1;
            cboSanBayDen.SelectedIndex = -1;
            txtGiaVe.Clear();
            dtpThoiGianDi.Value = DateTime.Now;
            dtpThoiGianDen.Value = DateTime.Now.AddHours(2);
            if (cboTrangThai.Items.Count > 0)
            {
                cboTrangThai.SelectedIndex = 0;
            }
            else
            {
                cboTrangThai.Text = "Đang mở";
            }
            dgvChuyenBay.ClearSelection();
        }

        // Xử lý khi chọn một chuyến bay
        private void dgvChuyenBay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvChuyenBay.Rows.Count)
            {
                DataGridViewRow dong = dgvChuyenBay.Rows[e.RowIndex];

                txtMaChuyenBay.Text = LayGiaTriO(dong, "MaChuyenBay", 0);

                string chuoiMaMayBay = LayGiaTriO(dong, "MaMayBay", 1);
                if (int.TryParse(chuoiMaMayBay, out int maMayBay))
                {
                    cboMaMayBay.SelectedValue = maMayBay;
                }
                else
                {
                    cboMaMayBay.SelectedIndex = -1;
                }

                ChonSanBay(cboSanBayDi, LayGiaTriO(dong, "SanBayDi", 2));
                ChonSanBay(cboSanBayDen, LayGiaTriO(dong, "SanBayDen", 3));

                string chuoiThoiGianDi = LayGiaTriO(dong, "ThoiGianDi", 4);
                if (DateTime.TryParse(chuoiThoiGianDi, out DateTime thoiGianDi))
                {
                    dtpThoiGianDi.Value = thoiGianDi;
                }

                string chuoiThoiGianDen = LayGiaTriO(dong, "ThoiGianDen", 5);
                if (DateTime.TryParse(chuoiThoiGianDen, out DateTime thoiGianDen))
                {
                    dtpThoiGianDen.Value = thoiGianDen;
                }

                string chuoiGiaVe = LayGiaTriO(dong, "GiaVe", 6);
                if (decimal.TryParse(chuoiGiaVe, out decimal soGiaVe))
                {
                    txtGiaVe.Text = soGiaVe.ToString("0.##");
                }
                else
                {
                    txtGiaVe.Text = chuoiGiaVe;
                }

                cboTrangThai.Text = LayGiaTriO(dong, "TrangThai", 7);
            }
        }

        // Lấy giá trị ô trong bảng
        private string LayGiaTriO(DataGridViewRow dong, string tenCot, int viTriPhu)
        {
            if (dong.DataGridView != null && dong.DataGridView.Columns.Contains(tenCot) && dong.Cells[tenCot]?.Value != null)
            {
                return dong.Cells[tenCot].Value?.ToString() ?? "";
            }
            if (viTriPhu >= 0 && viTriPhu < dong.Cells.Count && dong.Cells[viTriPhu]?.Value != null)
            {
                return dong.Cells[viTriPhu].Value?.ToString() ?? "";
            }
            return "";
        }
    }
}