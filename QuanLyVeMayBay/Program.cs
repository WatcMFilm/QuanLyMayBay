using System;
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

            // Khởi tạo và kiểm tra CSDL tự động
            DbInitializer.InitializeDatabase();

            // Mở form đăng nhập hệ thống
            Application.Run(new frmDangNhap());
        }
    }
}
