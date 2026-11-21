using System;

namespace QuanLyVeMayBay
{
    // Model đại diện cho Nhân viên trong hệ thống
    public class NhanVienModel
    {
        public int MaNV { get; set; }
        public string TenDangNhap { get; set; } = "";
        public string MatKhau { get; set; } = "";
        public string HoTen { get; set; } = "";
        public string ChucVu { get; set; } = ""; // Admin, NhanVienCSKH, NhanVienKeToan, NhanVienDatVe, NhanVienQuanLyChuyenBay
        public string QueQuan { get; set; } = "";
        public string SoDienThoai { get; set; } = "";
        public DateTime NgayTao { get; set; } = DateTime.Now;

        // Tên hiển thị chức vụ tiếng Việt
        public string TenChucVuTiengViet
        {
            get
            {
                return ChucVu switch
                {
                    "Admin" => "Quản trị viên (Admin)",
                    "NhanVienCSKH" => "Nhân viên Chăm sóc khách hàng",
                    "NhanVienKeToan" => "Nhân viên Kế toán",
                    "NhanVienDatVe" => "Nhân viên Đặt vé",
                    "NhanVienQuanLyChuyenBay" => "Nhân viên Quản lý chuyến bay",
                    _ => ChucVu
                };
            }
        }
    }

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
