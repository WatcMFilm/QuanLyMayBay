using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using QuanLyVeMayBay.DAL;

namespace QuanLyVeMayBay
{
    /// <summary>
    /// Quản lý máy bay (bảng MAYBAY): Thêm - Xem - Sửa - Xóa - Tìm kiếm
    /// Form này được nhúng vào tab "Quản lý máy bay" của form Quản lý chuyến bay
    /// </summary>
    public partial class frmMayBay : Form
    {
        private int _maMayBayChon = 0;

        // Báo cho form cha biết danh sách máy bay đã thay đổi (để nạp lại ComboBox máy bay)
        public event EventHandler? DuLieuThayDoi;

        public frmMayBay()
        {
            InitializeComponent();
        }

        private void frmMayBay_Load(object sender, EventArgs e)
        {
            // Giao diện
            UiTheme.ApplyFormStyle(this);
            UiTheme.ApplyCardStyle(grpThongTin);
            UiTheme.ApplyCardStyle(grpDanhSach);
            UiTheme.ApplyButtonStyle(btnThem, UiTheme.SuccessGreen, UiTheme.SuccessGreenHover, Color.White);
            UiTheme.ApplyButtonStyle(btnSua, UiTheme.WarningAmber, UiTheme.WarningAmberHover, Color.White);
            UiTheme.ApplyButtonStyle(btnXoa, UiTheme.DangerRose, UiTheme.DangerRoseHover, Color.White);
            UiTheme.ApplyButtonStyle(btnLamMoi, UiTheme.SecondarySlate, UiTheme.SecondarySlateHover, Color.White);
            UiTheme.ApplyDataGridStyle(dgvMayBay);
            dgvMayBay.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Danh mục trạng thái máy bay
            cboTrangThai.Items.Add("Hoạt động");
            cboTrangThai.Items.Add("Bảo dưỡng");
            cboTrangThai.Items.Add("Ngừng bay");
            cboTrangThai.SelectedIndex = 0;

            TaiDanhSach();
        }

        // XEM: tải danh sách máy bay (kèm số ghế và số chuyến bay của từng máy bay)
        private void TaiDanhSach()
        {
            string sql = @"
                SELECT mb.MaMayBay, mb.TenMayBay, mb.TrangThai,
                       (SELECT COUNT(*) FROM GHE g WHERE g.MaMayBay = mb.MaMayBay) AS SoGhe,
                       (SELECT COUNT(*) FROM CHUYENBAY cb WHERE cb.MaMayBay = mb.MaMayBay) AS SoChuyenBay
                FROM MAYBAY mb
                WHERE mb.MaMayBay LIKE @tk OR mb.TenMayBay LIKE @tk
                ORDER BY mb.MaMayBay;";

            dgvMayBay.DataSource = Database.GetData(sql, new MySqlParameter("@tk", $"%{txtTimKiem.Text.Trim()}%"));

            UiTheme.SetCol(dgvMayBay, "MaMayBay", "Mã máy bay", align: DataGridViewContentAlignment.MiddleCenter);
            UiTheme.SetCol(dgvMayBay, "TenMayBay", "Tên máy bay");
            UiTheme.SetCol(dgvMayBay, "TrangThai", "Trạng thái", align: DataGridViewContentAlignment.MiddleCenter);
            UiTheme.SetCol(dgvMayBay, "SoGhe", "Số ghế", align: DataGridViewContentAlignment.MiddleCenter);
            UiTheme.SetCol(dgvMayBay, "SoChuyenBay", "Số chuyến bay", align: DataGridViewContentAlignment.MiddleCenter);
        }

        // Click 1 dòng trong bảng -> đổ dữ liệu lên ô nhập
        private void dgvMayBay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow r = dgvMayBay.Rows[e.RowIndex];
            _maMayBayChon = Database.ToInt(r.Cells["MaMayBay"].Value);
            txtMaMayBay.Text = _maMayBayChon.ToString();
            txtTenMayBay.Text = r.Cells["TenMayBay"].Value?.ToString() ?? "";
            string trangThai = r.Cells["TrangThai"].Value?.ToString() ?? "";
            if (cboTrangThai.Items.Contains(trangThai))
                cboTrangThai.SelectedItem = trangThai;
        }

        // THÊM máy bay
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenMayBay.Text))
            {
                MessageBox.Show("Vui lòng nhập tên máy bay!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenMayBay.Focus();
                return;
            }

            try
            {
                Database.ExecuteNonQuery("INSERT INTO MAYBAY (TenMayBay, TrangThai) VALUES (@ten, @tt);",
                    new MySqlParameter("@ten", txtTenMayBay.Text.Trim()),
                    new MySqlParameter("@tt", cboTrangThai.Text));

                MessageBox.Show("Thêm máy bay thành công!\nHãy sang tab 'Tình trạng ghế' để sinh ghế cho máy bay mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoi();
                TaiDanhSach();
                DuLieuThayDoi?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // SỬA máy bay
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_maMayBayChon <= 0)
            {
                MessageBox.Show("Vui lòng chọn máy bay trong bảng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTenMayBay.Text))
            {
                MessageBox.Show("Vui lòng nhập tên máy bay!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Database.ExecuteNonQuery("UPDATE MAYBAY SET TenMayBay = @ten, TrangThai = @tt WHERE MaMayBay = @id;",
                    new MySqlParameter("@ten", txtTenMayBay.Text.Trim()),
                    new MySqlParameter("@tt", cboTrangThai.Text),
                    new MySqlParameter("@id", _maMayBayChon));

                MessageBox.Show("Cập nhật máy bay thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TaiDanhSach();
                DuLieuThayDoi?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // XÓA máy bay (không cho xóa nếu máy bay đã được xếp chuyến bay)
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_maMayBayChon <= 0)
            {
                MessageBox.Show("Vui lòng chọn máy bay trong bảng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            long soChuyen = Database.ToLong(Database.ExecuteScalar("SELECT COUNT(*) FROM CHUYENBAY WHERE MaMayBay = @id;",
                new MySqlParameter("@id", _maMayBayChon)));
            if (soChuyen > 0)
            {
                MessageBox.Show($"Máy bay này đang có {soChuyen} chuyến bay nên không thể xóa!\nBạn có thể chuyển trạng thái sang 'Ngừng bay'.", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa máy bay #{_maMayBayChon} và toàn bộ ghế của nó?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    // Xóa ghế của máy bay trước, sau đó xóa máy bay
                    Database.ExecuteNonQuery("DELETE FROM GHE WHERE MaMayBay = @id;", new MySqlParameter("@id", _maMayBayChon));
                    Database.ExecuteNonQuery("DELETE FROM MAYBAY WHERE MaMayBay = @id;", new MySqlParameter("@id", _maMayBayChon));

                    MessageBox.Show("Xóa máy bay thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LamMoi();
                    TaiDanhSach();
                    DuLieuThayDoi?.Invoke(this, EventArgs.Empty);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LamMoi()
        {
            _maMayBayChon = 0;
            txtMaMayBay.Clear();
            txtTenMayBay.Clear();
            cboTrangThai.SelectedIndex = 0;
            txtTenMayBay.Focus();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
            txtTimKiem.Clear();
            TaiDanhSach();
        }

        // TÌM KIẾM: gõ tới đâu lọc tới đó
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            TaiDanhSach();
        }
    }
}
