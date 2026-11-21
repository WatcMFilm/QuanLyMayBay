using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using QuanLyVeMayBay.DAL;

namespace QuanLyVeMayBay
{
    /// <summary>
    /// Giao diện Đăng nhập phân quyền
    /// Viết chuẩn theo kiến thức môn Lập trình .NET cho sinh viên năm 3:
    /// - Kiểm tra tài khoản và mật khẩu từ bảng NHANVIEN
    /// - Phân quyền mở 1 trong 5 Form chính tương ứng với Chức vụ
    /// - Cung cấp 5 nút Demo 1-Click để thuận tiện chạy thử nghiệm
    /// </summary>
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            // Cài đặt giao diện
            UiTheme.ApplyFormStyle(this);
            UiTheme.ApplyButtonStyle(btnDangNhap, UiTheme.PrimaryBlue, UiTheme.PrimaryBlueHover, Color.White);
            UiTheme.ApplyButtonStyle(btnThoat, UiTheme.SecondarySlate, UiTheme.SecondarySlateHover, Color.White);

            UiTheme.ApplyButtonStyle(btnDemoAdmin, Color.FromArgb(79, 70, 229), Color.FromArgb(67, 56, 202), Color.White);
            UiTheme.ApplyButtonStyle(btnDemoCSKH, Color.FromArgb(14, 165, 233), Color.FromArgb(2, 132, 199), Color.White);
            UiTheme.ApplyButtonStyle(btnDemoKeToan, Color.FromArgb(16, 185, 129), Color.FromArgb(5, 150, 105), Color.White);
            UiTheme.ApplyButtonStyle(btnDemoDatVe, Color.FromArgb(245, 158, 11), Color.FromArgb(217, 119, 6), Color.White);
            UiTheme.ApplyButtonStyle(btnDemoQLCB, Color.FromArgb(99, 102, 241), Color.FromArgb(79, 70, 229), Color.White);

            txtTenDangNhap.Focus();
        }

        // Xử lý khi nhấn nút Đăng nhập
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            ThucHienDangNhap();
        }

        // Nhấn phím Enter trong ô mật khẩu để đăng nhập nhanh
        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ThucHienDangNhap();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        // =========================================================================
        // LOGIC XÁC THỰC TÀI KHOẢN & ĐIỀU HƯỚNG THEO CHỨC VỤ
        // =========================================================================
        private void ThucHienDangNhap()
        {
            string username = txtTenDangNhap.Text.Trim();
            string password = txtMatKhau.Text.Trim();

            // Bước 1: Kiểm tra rỗng
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Vui lòng nhập Tên đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDangNhap.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập Mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                return;
            }

            // Bước 2: Thực thi câu lệnh SQL kiểm tra trong bảng NHANVIEN
            string sql = @"
                SELECT MaNV, TenDangNhap, MatKhau, HoTen, ChucVu, QueQuan, SoDienThoai 
                FROM NHANVIEN 
                WHERE TenDangNhap = @u AND MatKhau = @p 
                LIMIT 1;";

            DataTable dt = Database.GetData(sql,
                new MySqlParameter("@u", username),
                new MySqlParameter("@p", password));

            // Bước 3: Tìm chính xác nhân viên theo tên đăng nhập (tránh nhầm lẫn row 0 khi CSDL trả về nhiều dòng)
            DataRow? row = null;
            foreach (DataRow r in dt.Rows)
            {
                if (string.Equals(r["TenDangNhap"]?.ToString(), username, StringComparison.OrdinalIgnoreCase))
                {
                    row = r;
                    break;
                }
            }

            if (row == null)
            {
                if (dt.Rows.Count > 0 && string.Equals(dt.Rows[0]["TenDangNhap"]?.ToString(), username, StringComparison.OrdinalIgnoreCase))
                {
                    row = dt.Rows[0];
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác!\nVui lòng kiểm tra lại hoặc sử dụng các nút Demo bên dưới.",
                        "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMatKhau.Focus();
                    txtMatKhau.SelectAll();
                    return;
                }
            }

            // Bước 4: Lấy thông tin nhân viên đăng nhập thành công
            NhanVienModel user = new NhanVienModel
            {
                MaNV = Database.ToInt(row["MaNV"]),
                TenDangNhap = row["TenDangNhap"]?.ToString() ?? "",
                MatKhau = row["MatKhau"]?.ToString() ?? "",
                HoTen = row["HoTen"]?.ToString() ?? "",
                ChucVu = row["ChucVu"]?.ToString() ?? "",
                QueQuan = row["QueQuan"]?.ToString() ?? "",
                SoDienThoai = row["SoDienThoai"]?.ToString() ?? ""
            };

            // Lưu vào phiên làm việc hiện tại
            SessionManager.CurrentUser = user;

            // Bước 5: Mở Form tương ứng theo 5 Chức vụ
            MoFormTheoVaiTro(user);
        }

        // Mở Form giao diện theo Chức vụ của tài khoản
        private void MoFormTheoVaiTro(NhanVienModel user)
        {
            this.Hide(); // Ẩn màn hình đăng nhập

            Form? mainForm = null;
            string cv = (user.ChucVu ?? "").Trim();
            string un = (user.TenDangNhap ?? "").Trim().ToLowerInvariant();

            // Nhận diện vai trò chuẩn xác theo cả ChucVu và TenDangNhap
            if (cv.Equals("Admin", StringComparison.OrdinalIgnoreCase) || un == "admin")
            {
                mainForm = new frmAdmin();
            }
            else if (cv.Contains("CSKH", StringComparison.OrdinalIgnoreCase) || un == "cskh")
            {
                mainForm = new frmNhanVienCSKH();
            }
            else if (cv.Contains("KeToan", StringComparison.OrdinalIgnoreCase) || cv.Contains("Kế toán", StringComparison.OrdinalIgnoreCase) || un == "ketoan")
            {
                mainForm = new frmNhanVienKeToan();
            }
            else if (cv.Contains("DatVe", StringComparison.OrdinalIgnoreCase) || cv.Contains("Đặt vé", StringComparison.OrdinalIgnoreCase) || un == "datve")
            {
                mainForm = new frmNhanVienDatVe();
            }
            else if (cv.Contains("ChuyenBay", StringComparison.OrdinalIgnoreCase) || cv.Contains("QLCB", StringComparison.OrdinalIgnoreCase) || un == "qlcb")
            {
                mainForm = new frmNhanVienQuanLyChuyenBay();
            }
            else
            {
                MessageBox.Show($"Chức vụ \"{user.ChucVu}\" chưa được hỗ trợ giao diện riêng!", "Lỗi phân quyền", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Show();
                return;
            }

            // Khi Form chính đóng lại (đăng xuất), hiện lại màn hình đăng nhập
            mainForm.FormClosed += (s, args) =>
            {
                SessionManager.CurrentUser = null;
                txtMatKhau.Clear();
                txtTenDangNhap.Focus();
                txtTenDangNhap.SelectAll();
                this.Show();
            };

            mainForm.Show();
        }

        // Nút Thoát
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // =========================================================================
        // 5 NÚT 1-CLICK DEMO TIỆN LỢI ĐỂ THUYẾT MINH / BẢO VỆ ĐỒ ÁN
        // =========================================================================
        private void btnDemo_Click(object sender, EventArgs e)
        {
            NhanVienModel demoUser;

            if (sender == btnDemoAdmin)
            {
                txtTenDangNhap.Text = "admin";
                txtMatKhau.Text = "123456";
                demoUser = new NhanVienModel { MaNV = 1, TenDangNhap = "admin", HoTen = "Nguyễn Quản Trị", ChucVu = "Admin" };
            }
            else if (sender == btnDemoCSKH)
            {
                txtTenDangNhap.Text = "cskh";
                txtMatKhau.Text = "123456";
                demoUser = new NhanVienModel { MaNV = 2, TenDangNhap = "cskh", HoTen = "Trần Chăm Sóc", ChucVu = "NhanVienCSKH" };
            }
            else if (sender == btnDemoKeToan)
            {
                txtTenDangNhap.Text = "ketoan";
                txtMatKhau.Text = "123456";
                demoUser = new NhanVienModel { MaNV = 3, TenDangNhap = "ketoan", HoTen = "Lê Kế Toán", ChucVu = "NhanVienKeToan" };
            }
            else if (sender == btnDemoDatVe)
            {
                txtTenDangNhap.Text = "datve";
                txtMatKhau.Text = "123456";
                demoUser = new NhanVienModel { MaNV = 4, TenDangNhap = "datve", HoTen = "Phạm Đặt Vé", ChucVu = "NhanVienDatVe" };
            }
            else if (sender == btnDemoQLCB)
            {
                txtTenDangNhap.Text = "qlcb";
                txtMatKhau.Text = "123456";
                demoUser = new NhanVienModel { MaNV = 5, TenDangNhap = "qlcb", HoTen = "Hoàng Chuyến Bay", ChucVu = "NhanVienQuanLyChuyenBay" };
            }
            else
            {
                ThucHienDangNhap();
                return;
            }

            // Với nút Demo: Mở thẳng giao diện tương ứng theo vai trò đã chọn
            SessionManager.CurrentUser = demoUser;
            MoFormTheoVaiTro(demoUser);
        }

        // Hiện / Ẩn mật khẩu
        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = !chkHienMatKhau.Checked;
        }
    }
}
