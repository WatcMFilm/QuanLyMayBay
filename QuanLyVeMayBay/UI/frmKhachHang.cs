using System;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using QuanLyVeMayBay.DAL;

namespace QuanLyVeMayBay
{
    /// <summary>
    /// Quản lý khách hàng (bảng KHACHHANG): Thêm - Xem - Sửa - Xóa - Tìm kiếm
    /// Form này được nhúng vào tab "Quản lý khách hàng" của form CSKH
    /// </summary>
    public partial class frmKhachHang : Form
    {
        private int _maKHChon = 0;

        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            // Giao diện
            UiTheme.ApplyFormStyle(this);
            UiTheme.ApplyCardStyle(grpThongTin);
            UiTheme.ApplyCardStyle(grpDanhSach);
            UiTheme.ApplyButtonStyle(btnThem, UiTheme.SuccessGreen, UiTheme.SuccessGreenHover, Color.White);
            UiTheme.ApplyButtonStyle(btnSua, UiTheme.WarningAmber, UiTheme.WarningAmberHover, Color.White);
            UiTheme.ApplyButtonStyle(btnXoa, UiTheme.DangerRose, UiTheme.DangerRoseHover, Color.White);
            UiTheme.ApplyButtonStyle(btnLamMoi, UiTheme.SecondarySlate, UiTheme.SecondarySlateHover, Color.White);
            UiTheme.ApplyDataGridStyle(dgvKhachHang);
            dgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            TaiDanhSach();
        }

        // XEM: tải danh sách khách hàng (kèm số vé khách đã đặt)
        public void TaiDanhSach()
        {
            string sql = @"
                SELECT kh.MaKH, kh.HoTen, kh.CCCD, kh.SDT, kh.Email,
                       (SELECT COUNT(*) FROM VE v WHERE v.MaKH = kh.MaKH) AS SoVe
                FROM KHACHHANG kh
                WHERE kh.HoTen LIKE @tk OR kh.CCCD LIKE @tk OR kh.SDT LIKE @tk
                ORDER BY kh.MaKH DESC;";

            dgvKhachHang.DataSource = Database.GetData(sql, new MySqlParameter("@tk", $"%{txtTimKiem.Text.Trim()}%"));

            UiTheme.SetCol(dgvKhachHang, "MaKH", "Mã KH", align: DataGridViewContentAlignment.MiddleCenter);
            UiTheme.SetCol(dgvKhachHang, "HoTen", "Họ tên");
            UiTheme.SetCol(dgvKhachHang, "CCCD", "CCCD", align: DataGridViewContentAlignment.MiddleCenter);
            UiTheme.SetCol(dgvKhachHang, "SDT", "Số điện thoại", align: DataGridViewContentAlignment.MiddleCenter);
            UiTheme.SetCol(dgvKhachHang, "Email", "Email");
            UiTheme.SetCol(dgvKhachHang, "SoVe", "Số vé đã đặt", align: DataGridViewContentAlignment.MiddleCenter);
        }

        // Click 1 dòng trong bảng -> đổ dữ liệu lên ô nhập
        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow r = dgvKhachHang.Rows[e.RowIndex];
            _maKHChon = Database.ToInt(r.Cells["MaKH"].Value);
            txtMaKH.Text = _maKHChon.ToString();
            txtHoTen.Text = r.Cells["HoTen"].Value?.ToString() ?? "";
            txtCCCD.Text = r.Cells["CCCD"].Value?.ToString() ?? "";
            txtSDT.Text = r.Cells["SDT"].Value?.ToString() ?? "";
            txtEmail.Text = r.Cells["Email"].Value?.ToString() ?? "";
        }

        // Kiểm tra dữ liệu nhập (dùng chung cho Thêm và Sửa)
        private bool KiemTraDuLieu()
        {
            if (!Regex.IsMatch(txtHoTen.Text.Trim(), @"^[\p{L}\s]+$"))
            {
                MessageBox.Show("Họ tên không được để trống và chỉ chứa chữ cái!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return false;
            }
            if (!Regex.IsMatch(txtCCCD.Text.Trim(), @"^\d{12}$"))
            {
                MessageBox.Show("CCCD phải gồm đúng 12 chữ số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCCCD.Focus();
                return false;
            }
            if (!Regex.IsMatch(txtSDT.Text.Trim(), @"^0\d{9}$"))
            {
                MessageBox.Show("Số điện thoại phải gồm 10 chữ số và bắt đầu bằng số 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return false;
            }
            string email = txtEmail.Text.Trim();
            if (email != "" && !Regex.IsMatch(email, @"^[^\s@]+@[^\s@]+\.[^\s@]+$"))
            {
                MessageBox.Show("Email không đúng định dạng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            // CCCD không được trùng với khách hàng khác
            long trung = Database.ToLong(Database.ExecuteScalar("SELECT COUNT(*) FROM KHACHHANG WHERE CCCD = @cccd AND MaKH <> @id;",
                new MySqlParameter("@cccd", txtCCCD.Text.Trim()),
                new MySqlParameter("@id", _maKHChon)));
            if (trung > 0)
            {
                MessageBox.Show("CCCD này đã thuộc về một khách hàng khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCCCD.Focus();
                return false;
            }

            return true;
        }

        // THÊM khách hàng
        private void btnThem_Click(object sender, EventArgs e)
        {
            _maKHChon = 0; // Thêm mới nên không có mã đang chọn
            if (!KiemTraDuLieu()) return;

            try
            {
                Database.ExecuteNonQuery("INSERT INTO KHACHHANG (HoTen, CCCD, SDT, Email) VALUES (@ten, @cccd, @sdt, @email);",
                    new MySqlParameter("@ten", txtHoTen.Text.Trim()),
                    new MySqlParameter("@cccd", txtCCCD.Text.Trim()),
                    new MySqlParameter("@sdt", txtSDT.Text.Trim()),
                    new MySqlParameter("@email", txtEmail.Text.Trim()));

                MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoi();
                TaiDanhSach();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // SỬA khách hàng
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_maKHChon <= 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng trong bảng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!KiemTraDuLieu()) return;

            try
            {
                Database.ExecuteNonQuery("UPDATE KHACHHANG SET HoTen = @ten, CCCD = @cccd, SDT = @sdt, Email = @email WHERE MaKH = @id;",
                    new MySqlParameter("@ten", txtHoTen.Text.Trim()),
                    new MySqlParameter("@cccd", txtCCCD.Text.Trim()),
                    new MySqlParameter("@sdt", txtSDT.Text.Trim()),
                    new MySqlParameter("@email", txtEmail.Text.Trim()),
                    new MySqlParameter("@id", _maKHChon));

                MessageBox.Show("Cập nhật khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TaiDanhSach();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // XÓA khách hàng (không cho xóa nếu khách đã có vé)
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_maKHChon <= 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng trong bảng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            long soVe = Database.ToLong(Database.ExecuteScalar("SELECT COUNT(*) FROM VE WHERE MaKH = @id;",
                new MySqlParameter("@id", _maKHChon)));
            if (soVe > 0)
            {
                MessageBox.Show($"Khách hàng này đã có {soVe} vé nên không thể xóa!", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa khách hàng '{txtHoTen.Text}'?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    Database.ExecuteNonQuery("DELETE FROM KHACHHANG WHERE MaKH = @id;", new MySqlParameter("@id", _maKHChon));
                    MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LamMoi();
                    TaiDanhSach();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LamMoi()
        {
            _maKHChon = 0;
            txtMaKH.Clear();
            txtHoTen.Clear();
            txtCCCD.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            txtHoTen.Focus();
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
