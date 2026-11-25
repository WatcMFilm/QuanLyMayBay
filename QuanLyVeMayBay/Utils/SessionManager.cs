using System;

namespace QuanLyVeMayBay
{
    // Quản lý phiên đăng nhập hiện tại
    public static class SessionManager
    {
        public static NhanVienModel? CurrentUser { get; set; }

        public static bool IsLoggedIn => CurrentUser != null;

        public static void Logout()
        {
            CurrentUser = null;
        }
    }
}
