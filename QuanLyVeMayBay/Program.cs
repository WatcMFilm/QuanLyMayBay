using System;
using System.Drawing;
using System.Windows.Forms;
using QuanLyVeMayBay.DAL;

namespace QuanLyVeMayBay
{
    internal static class Program
    {
        // Khởi chạy ứng dụng
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Khởi tạo và kiểm tra CSDL tự động (dò các mật khẩu root phổ biến)
            DbInitializer.InitializeDatabase();

            // Nếu MySQL có chạy nhưng sai mật khẩu: hỏi người dùng nhập mật khẩu root
            while (!DbInitializer.IsMySqlAvailable && DbInitializer.SaiMatKhau)
            {
                string? matKhau = HoiMatKhauMySql();
                if (matKhau == null) break; // Người dùng bấm Hủy -> chạy chế độ demo
                DbInitializer.InitializeDatabase(matKhau);
                if (!DbInitializer.IsMySqlAvailable)
                {
                    MessageBox.Show("Mật khẩu MySQL không đúng, vui lòng thử lại!", "Kết nối thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            if (!DbInitializer.IsMySqlAvailable)
            {
                MessageBox.Show(
                    "Không kết nối được MySQL Server.\n" +
                    $"Chi tiết: {DbInitializer.LoiKetNoiCuoi}\n\n" +
                    "Ứng dụng sẽ chạy ở CHẾ ĐỘ DEMO với dữ liệu mẫu: mọi thao tác thêm/sửa/xóa, đặt vé, thanh toán sẽ KHÔNG được lưu.",
                    "Chế độ demo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Mở form đăng nhập hệ thống
            Application.Run(new frmDangNhap());
        }

        // Hộp thoại nhập mật khẩu tài khoản root của MySQL. Trả về null nếu người dùng bấm Hủy
        private static string? HoiMatKhauMySql()
        {
            using Form frm = new Form
            {
                Text = "Kết nối MySQL",
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                MinimizeBox = false,
                ClientSize = new Size(380, 130),
                Font = new Font("Segoe UI", 9.5f)
            };

            Label lbl = new Label
            {
                Text = "Không đăng nhập được MySQL bằng mật khẩu mặc định.\nNhập mật khẩu tài khoản root của MySQL:",
                Location = new Point(12, 10),
                Size = new Size(356, 40)
            };
            TextBox txt = new TextBox { Location = new Point(12, 55), Width = 356, UseSystemPasswordChar = true };
            Button btnOk = new Button { Text = "Kết nối", DialogResult = DialogResult.OK, Location = new Point(192, 90), Size = new Size(85, 30) };
            Button btnHuy = new Button { Text = "Chạy demo", DialogResult = DialogResult.Cancel, Location = new Point(283, 90), Size = new Size(85, 30) };

            frm.Controls.AddRange(new Control[] { lbl, txt, btnOk, btnHuy });
            frm.AcceptButton = btnOk;
            frm.CancelButton = btnHuy;

            return frm.ShowDialog() == DialogResult.OK ? txt.Text : null;
        }
    }
}
