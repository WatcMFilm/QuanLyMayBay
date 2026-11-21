using System;
using System.IO;
using MySql.Data.MySqlClient;

namespace QuanLyVeMayBay.DAL
{
    /// <summary>
    /// Lớp tự động kiểm tra, khởi tạo và tự sửa chữa CSDL MySQL
    /// Tự động dò mật khẩu root, tự bù đắp bảng và cột còn thiếu, tự chèn dữ liệu mẫu
    /// </summary>
    public static class DbInitializer
    {
        private static bool _isInitialized = false;
        private static bool _isMySqlAvailable = false;

        public static bool IsMySqlAvailable => _isMySqlAvailable;

        public static void InitializeDatabase()
        {
            if (_isInitialized) return;

            // 1. Danh sách các mật khẩu root phổ biến để tự động dò tìm
            string[] commonPasswords = { "123456", "root", "", "admin", "1234" };
            string? workingPassword = null;

            foreach (var pwd in commonPasswords)
            {
                try
                {
                    string testConnStr = $"Server=localhost;Port=3306;Uid=root;Pwd={pwd};Charset=utf8mb4;";
                    using (var conn = new MySqlConnection(testConnStr))
                    {
                        conn.Open();
                        workingPassword = pwd;

                        // Tạo CSDL nếu chưa có
                        using (var cmdDb = new MySqlCommand("CREATE DATABASE IF NOT EXISTS QuanLyDatVeMayBay CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;", conn))
                        {
                            cmdDb.ExecuteNonQuery();
                        }
                        break;
                    }
                }
                catch
                {
                    // Thử mật khẩu tiếp theo
                }
            }

            if (workingPassword != null)
            {
                _isMySqlAvailable = true;
                Database.ConnectionString = $"Server=localhost;Port=3306;Database=QuanLyDatVeMayBay;Uid=root;Pwd={workingPassword};Charset=utf8mb4;";

                try
                {
                    using (var conn = Database.TaoKetNoi())
                    {
                        conn.Open();

                        // Tự động kiểm tra và nâng cấp / bù đắp tất cả các bảng và cột cần thiết
                        TuSuaChuaCoSoDuLieu(conn);
                    }
                }
                catch
                {
                    // Không ngắt chương trình nếu có cảnh báo CSDL
                }
            }
            else
            {
                _isMySqlAvailable = false;
            }

            _isInitialized = true;
        }

        // =========================================================================
        // TỰ ĐỘNG BÙ ĐẮP CÁC BẢNG, CỘT VÀ DỮ LIỆU CÒN THIẾU
        // =========================================================================
        private static void TuSuaChuaCoSoDuLieu(MySqlConnection conn)
        {
            try
            {
                // BẢNG 1: NHANVIEN
                ThucThiLenh(conn, @"
                    CREATE TABLE IF NOT EXISTS NHANVIEN (
                        MaNV INT AUTO_INCREMENT PRIMARY KEY,
                        TenDangNhap VARCHAR(50) NOT NULL UNIQUE,
                        MatKhau VARCHAR(100) NOT NULL,
                        HoTen VARCHAR(100) NOT NULL,
                        ChucVu VARCHAR(50) NOT NULL,
                        QueQuan VARCHAR(100) DEFAULT NULL,
                        SoDienThoai VARCHAR(20) DEFAULT NULL,
                        NgayTao DATETIME DEFAULT CURRENT_TIMESTAMP
                    ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;");

                EnsureColumnExists(conn, "NHANVIEN", "QueQuan", "VARCHAR(100) DEFAULT NULL");
                EnsureColumnExists(conn, "NHANVIEN", "SoDienThoai", "VARCHAR(20) DEFAULT NULL");
                EnsureColumnExists(conn, "NHANVIEN", "NgayTao", "DATETIME DEFAULT CURRENT_TIMESTAMP");

                // Nếu bảng NHANVIEN rỗng thì nạp 5 tài khoản mẫu
                if (DemSoDong(conn, "NHANVIEN") == 0)
                {
                    ThucThiLenh(conn, @"
                        INSERT INTO NHANVIEN (TenDangNhap, MatKhau, HoTen, ChucVu, QueQuan, SoDienThoai) VALUES
                        ('admin',  '123456', 'Nguyễn Quản Trị', 'Admin',                   'Hà Nội',         '0901234567'),
                        ('cskh',   '123456', 'Trần Chăm Sóc',   'NhanVienCSKH',            'Đà Nẵng',        '0912345678'),
                        ('ketoan', '123456', 'Lê Kế Toán',      'NhanVienKeToan',          'TP. Hồ Chí Minh','0923456789'),
                        ('datve',  '123456', 'Phạm Đặt Vé',     'NhanVienDatVe',           'Hải Phòng',      '0934567890'),
                        ('qlcb',   '123456', 'Hoàng Chuyến Bay','NhanVienQuanLyChuyenBay', 'Cần Thơ',        '0945678901');");
                }

                // BẢNG 2: MAYBAY
                ThucThiLenh(conn, @"
                    CREATE TABLE IF NOT EXISTS MAYBAY (
                        MaMayBay INT AUTO_INCREMENT PRIMARY KEY,
                        TenMayBay VARCHAR(100) NOT NULL,
                        TrangThai VARCHAR(50) DEFAULT 'Hoạt động'
                    ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;");

                if (DemSoDong(conn, "MAYBAY") == 0)
                {
                    ThucThiLenh(conn, @"
                        INSERT INTO MAYBAY (MaMayBay, TenMayBay, TrangThai) VALUES
                        (1, 'Boeing 787-9 Dreamliner', 'Hoạt động'),
                        (2, 'Airbus A321 Neo',         'Hoạt động'),
                        (3, 'Boeing 777-300ER',        'Hoạt động'),
                        (4, 'Airbus A350-900',         'Hoạt động')
                        ON DUPLICATE KEY UPDATE TenMayBay = VALUES(TenMayBay);");
                }

                // BẢNG 3: GHE
                ThucThiLenh(conn, @"
                    CREATE TABLE IF NOT EXISTS GHE (
                        MaGhe INT AUTO_INCREMENT PRIMARY KEY,
                        MaMayBay INT NOT NULL,
                        SoGhe VARCHAR(10) NOT NULL,
                        HangGhe VARCHAR(50) NOT NULL DEFAULT 'Pho thong',
                        TrangThai VARCHAR(50) DEFAULT 'Trong'
                    ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;");

                EnsureColumnExists(conn, "GHE", "HangGhe", "VARCHAR(50) NOT NULL DEFAULT 'Pho thong'");
                EnsureColumnExists(conn, "GHE", "TrangThai", "VARCHAR(50) DEFAULT 'Trong'");

                if (DemSoDong(conn, "GHE") == 0)
                {
                    ThucThiLenh(conn, @"
                        INSERT INTO GHE (MaMayBay, SoGhe, HangGhe, TrangThai) VALUES
                        (1, 'A1', 'Thuong gia', 'Trong'), (1, 'A2', 'Thuong gia', 'Trong'),
                        (1, 'B1', 'Thuong gia', 'Trong'), (1, 'B2', 'Thuong gia', 'Trong'),
                        (1, 'C1', 'Pho thong',  'Trong'), (1, 'C2', 'Pho thong',  'Trong'),
                        (1, 'D1', 'Pho thong',  'Trong'), (1, 'D2', 'Pho thong',  'Trong'),
                        (2, 'A1', 'Thuong gia', 'Trong'), (2, 'A2', 'Thuong gia', 'Trong'),
                        (2, 'B1', 'Thuong gia', 'Trong'), (2, 'B2', 'Thuong gia', 'Trong'),
                        (2, 'C1', 'Pho thong',  'Trong'), (2, 'C2', 'Pho thong',  'Trong');");
                }

                // BẢNG 4: CHUYENBAY
                ThucThiLenh(conn, @"
                    CREATE TABLE IF NOT EXISTS CHUYENBAY (
                        MaChuyenBay INT AUTO_INCREMENT PRIMARY KEY,
                        MaMayBay INT NOT NULL,
                        SanBayDi VARCHAR(100) NOT NULL,
                        SanBayDen VARCHAR(100) NOT NULL,
                        ThoiGianDi DATETIME NOT NULL,
                        ThoiGianDen DATETIME NOT NULL,
                        GiaVe DECIMAL(18,2) NOT NULL DEFAULT 0.00,
                        TrangThai VARCHAR(50) DEFAULT 'Đang mở'
                    ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;");

                EnsureColumnExists(conn, "CHUYENBAY", "GiaVe", "DECIMAL(18,2) NOT NULL DEFAULT 0.00");
                EnsureColumnExists(conn, "CHUYENBAY", "TrangThai", "VARCHAR(50) DEFAULT 'Đang mở'");

                if (DemSoDong(conn, "CHUYENBAY") == 0)
                {
                    ThucThiLenh(conn, @"
                        INSERT INTO CHUYENBAY (MaMayBay, SanBayDi, SanBayDen, ThoiGianDi, ThoiGianDen, GiaVe, TrangThai) VALUES
                        (1, 'HAN - Nội Bài (Hà Nội)',       'SGN - Tân Sơn Nhất (TP.HCM)', DATE_ADD(NOW(), INTERVAL 1 DAY), DATE_ADD(DATE_ADD(NOW(), INTERVAL 1 DAY), INTERVAL 2 HOUR), 1850000.00, 'Đang mở'),
                        (2, 'SGN - Tân Sơn Nhất (TP.HCM)',  'DAD - Đà Nẵng',               DATE_ADD(NOW(), INTERVAL 1 DAY), DATE_ADD(DATE_ADD(NOW(), INTERVAL 1 DAY), INTERVAL 1 HOUR), 1200000.00, 'Đang mở'),
                        (3, 'HAN - Nội Bài (Hà Nội)',       'CXR - Cam Ranh',              DATE_ADD(NOW(), INTERVAL 2 DAY), DATE_ADD(DATE_ADD(NOW(), INTERVAL 2 DAY), INTERVAL 2 HOUR), 2100000.00, 'Đang mở');");
                }

                // BẢNG 5: KHACHHANG
                ThucThiLenh(conn, @"
                    CREATE TABLE IF NOT EXISTS KHACHHANG (
                        MaKH INT AUTO_INCREMENT PRIMARY KEY,
                        HoTen VARCHAR(100) NOT NULL,
                        CCCD VARCHAR(20) NOT NULL,
                        SDT VARCHAR(20) NOT NULL,
                        Email VARCHAR(100) DEFAULT NULL
                    ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;");

                if (DemSoDong(conn, "KHACHHANG") == 0)
                {
                    ThucThiLenh(conn, @"
                        INSERT INTO KHACHHANG (HoTen, CCCD, SDT, Email) VALUES
                        ('Nguyễn Văn An', '001200001234', '0912345678', 'an.nguyen@gmail.com'),
                        ('Trần Thị Bình', '079201005678', '0987654321', 'binh.tran@gmail.com');");
                }

                // BẢNG 6: VE
                ThucThiLenh(conn, @"
                    CREATE TABLE IF NOT EXISTS VE (
                        MaVe INT AUTO_INCREMENT PRIMARY KEY,
                        MaChuyenBay INT NOT NULL,
                        MaKH INT NOT NULL,
                        MaGhe INT NOT NULL,
                        NgayDat DATETIME DEFAULT CURRENT_TIMESTAMP,
                        GiaVe DECIMAL(18,2) NOT NULL DEFAULT 0.00,
                        TrangThai VARCHAR(50) DEFAULT 'Chờ thanh toán'
                    ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;");

                EnsureColumnExists(conn, "VE", "GiaVe", "DECIMAL(18,2) NOT NULL DEFAULT 0.00");
                EnsureColumnExists(conn, "VE", "TrangThai", "VARCHAR(50) DEFAULT 'Chờ thanh toán'");

                // BẢNG 7: THANHTOAN
                ThucThiLenh(conn, @"
                    CREATE TABLE IF NOT EXISTS THANHTOAN (
                        MaThanhToan INT AUTO_INCREMENT PRIMARY KEY,
                        MaVe INT NOT NULL,
                        SoTien DECIMAL(18,2) NOT NULL,
                        PhuongThuc VARCHAR(100) NOT NULL,
                        NgayThanhToan DATETIME DEFAULT CURRENT_TIMESTAMP,
                        TrangThai VARCHAR(50) DEFAULT 'Đã thanh toán'
                    ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;");

                EnsureColumnExists(conn, "THANHTOAN", "PhuongThuc", "VARCHAR(100) NOT NULL DEFAULT 'Tiền mặt'");
                EnsureColumnExists(conn, "THANHTOAN", "TrangThai", "VARCHAR(50) DEFAULT 'Đã thanh toán'");

                // BẢNG 8: HOADON
                ThucThiLenh(conn, @"
                    CREATE TABLE IF NOT EXISTS HOADON (
                        MaHoaDon INT AUTO_INCREMENT PRIMARY KEY,
                        MaThanhToan INT NOT NULL,
                        NgayLap DATETIME DEFAULT CURRENT_TIMESTAMP,
                        TongTien DECIMAL(18,2) NOT NULL
                    ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;");

                // BẢNG 9: YEUCAU_CSKH (ĐẶC BIỆT: TỰ ĐỘNG BÙ CỘT GhiChuXuLy NẾU BỊ THIẾU)
                ThucThiLenh(conn, @"
                    CREATE TABLE IF NOT EXISTS YEUCAU_CSKH (
                        MaYeuCau INT AUTO_INCREMENT PRIMARY KEY,
                        MaVe INT DEFAULT NULL,
                        TenKhach VARCHAR(100) NOT NULL,
                        LoaiYeuCau VARCHAR(50) NOT NULL,
                        NoiDung TEXT NOT NULL,
                        NgayTao DATETIME DEFAULT CURRENT_TIMESTAMP,
                        TrangThai VARCHAR(50) DEFAULT 'Tiếp nhận',
                        GhiChuXuLy TEXT DEFAULT NULL
                    ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;");

                // Đảm bảo cột GhiChuXuLy luôn tồn tại
                EnsureColumnExists(conn, "YEUCAU_CSKH", "GhiChuXuLy", "TEXT DEFAULT NULL");

                // Nếu có cột cũ tên là GhiChu thì đồng bộ dữ liệu sang GhiChuXuLy
                try
                {
                    ThucThiLenh(conn, "UPDATE YEUCAU_CSKH SET GhiChuXuLy = GhiChu WHERE GhiChuXuLy IS NULL AND GhiChu IS NOT NULL;");
                }
                catch { }

                if (DemSoDong(conn, "YEUCAU_CSKH") == 0)
                {
                    ThucThiLenh(conn, @"
                        INSERT INTO YEUCAU_CSKH (TenKhach, LoaiYeuCau, NoiDung, NgayTao, TrangThai, GhiChuXuLy) VALUES
                        ('Nguyễn Văn An', 'Đổi ghế ngồi', 'Hành khách mong muốn đổi sang ghế cạnh cửa sổ', NOW(), 'Đang xử lý', 'Đã tư vấn danh sách ghế trống cho khách'),
                        ('Trần Thị Bình', 'Hỗ trợ thanh toán', 'Khách hỏi hướng dẫn chuyển khoản qua mã QR', NOW(), 'Đã giải quyết', 'Đã gửi thông tin số tài khoản cho khách');");
                }
            }
            catch
            {
                // Không throw để ứng dụng vẫn khởi động được
            }
        }

        // Kiểm tra và tự động thêm một cột vào bảng nếu chưa có
        private static void EnsureColumnExists(MySqlConnection conn, string tableName, string columnName, string columnDefinition)
        {
            try
            {
                string sqlCheck = $"SELECT COUNT(*) FROM information_schema.COLUMNS WHERE TABLE_SCHEMA = DATABASE() AND TABLE_NAME = '{tableName}' AND COLUMN_NAME = '{columnName}';";
                using (var cmd = new MySqlCommand(sqlCheck, conn))
                {
                    long count = Database.ToLong(cmd.ExecuteScalar());
                    if (count == 0)
                    {
                        using (var cmdAdd = new MySqlCommand($"ALTER TABLE {tableName} ADD COLUMN {columnName} {columnDefinition};", conn))
                        {
                            cmdAdd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch { }
        }

        private static long DemSoDong(MySqlConnection conn, string tableName)
        {
            try
            {
                using (var cmd = new MySqlCommand($"SELECT COUNT(*) FROM {tableName};", conn))
                {
                    return Database.ToLong(cmd.ExecuteScalar());
                }
            }
            catch
            {
                return 0;
            }
        }

        private static void ThucThiLenh(MySqlConnection conn, string sql)
        {
            try
            {
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch { }
        }

        // Danh sách nhân viên mặc định phục vụ demo
        public static System.Collections.Generic.List<NhanVienModel> LayDanhSachNhanVienMacDinh()
        {
            return new System.Collections.Generic.List<NhanVienModel>
            {
                new NhanVienModel { MaNV = 1, TenDangNhap = "admin", MatKhau = "123456", HoTen = "Nguyễn Quản Trị", ChucVu = "Admin", QueQuan = "Hà Nội", SoDienThoai = "0901234567" },
                new NhanVienModel { MaNV = 2, TenDangNhap = "cskh", MatKhau = "123456", HoTen = "Trần Chăm Sóc", ChucVu = "NhanVienCSKH", QueQuan = "Đà Nẵng", SoDienThoai = "0912345678" },
                new NhanVienModel { MaNV = 3, TenDangNhap = "ketoan", MatKhau = "123456", HoTen = "Lê Kế Toán", ChucVu = "NhanVienKeToan", QueQuan = "TP. Hồ Chí Minh", SoDienThoai = "0923456789" },
                new NhanVienModel { MaNV = 4, TenDangNhap = "datve", MatKhau = "123456", HoTen = "Phạm Đặt Vé", ChucVu = "NhanVienDatVe", QueQuan = "Hải Phòng", SoDienThoai = "0934567890" },
                new NhanVienModel { MaNV = 5, TenDangNhap = "qlcb", MatKhau = "123456", HoTen = "Hoàng Chuyến Bay", ChucVu = "NhanVienQuanLyChuyenBay", QueQuan = "Cần Thơ", SoDienThoai = "0945678901" }
            };
        }
    }
}
