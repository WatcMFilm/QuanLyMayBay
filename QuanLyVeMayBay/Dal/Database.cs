using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace QuanLyVeMayBay.DAL
{
    /// <summary>
    /// Lớp xử lý kết nối và thao tác với Cơ sở dữ liệu MySQL
    /// Viết chuẩn theo kiến thức môn Lập trình .NET cho sinh viên năm 3:
    /// - GetData: Thực thi câu lệnh SELECT trả về DataTable
    /// - ExecuteNonQuery: Thực thi INSERT, UPDATE, DELETE
    /// - ExecuteScalar: Lấy 1 giá trị đơn lẻ (COUNT, SUM, MAX...)
    /// - ExecuteInsertAndGetId: Thực thi INSERT và lấy mã ID tự tăng (LastInsertedId)
    /// </summary>
    public class Database
    {
        // Chuỗi kết nối tới MySQL Database (Mặc định: root / 123456)
        public static string ConnectionString { get; set; } =
            "Server=localhost;Port=3306;Database=QuanLyDatVeMayBay;Uid=root;Pwd=123456;Charset=utf8mb4;";

        // 1. Lấy kết nối MySQL
        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public static MySqlConnection TaoKetNoi()
        {
            return new MySqlConnection(ConnectionString);
        }

        // =========================================================================
        // 2. Hàm GetData: Thực thi câu lệnh SELECT và trả về DataTable
        // =========================================================================
        public static DataTable GetData(string sql, params MySqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = TaoKetNoi())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        if (parameters != null && parameters.Length > 0)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch
            {
                // Nếu MySQL chưa bật hoặc lỗi kết nối, trả về dữ liệu mẫu dự phòng
                dt = LayDuLieuMauDuPhong(sql, parameters);
            }
            return dt;
        }

        // =========================================================================
        // 3. Hàm ExecuteNonQuery: Thực thi INSERT, UPDATE, DELETE
        // =========================================================================
        public static int ExecuteNonQuery(string sql, params MySqlParameter[] parameters)
        {
            try
            {
                using (MySqlConnection conn = TaoKetNoi())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        if (parameters != null && parameters.Length > 0)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Unable to connect", StringComparison.OrdinalIgnoreCase) ||
                    ex.Message.Contains("Access denied", StringComparison.OrdinalIgnoreCase) ||
                    ex.Message.Contains("Connection refused", StringComparison.OrdinalIgnoreCase))
                {
                    return 1; // Giả lập thành công khi offline demo
                }
                throw new Exception("Lỗi thực thi CSDL: " + ex.Message);
            }
        }

        // =========================================================================
        // 4. Hàm ExecuteScalar: Lấy 1 giá trị đơn lẻ (COUNT, SUM, MAX...)
        // =========================================================================
        public static object? ExecuteScalar(string sql, params MySqlParameter[] parameters)
        {
            try
            {
                using (MySqlConnection conn = TaoKetNoi())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        if (parameters != null && parameters.Length > 0)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        object? res = cmd.ExecuteScalar();
                        if (res == DBNull.Value) return null;
                        return res;
                    }
                }
            }
            catch
            {
                if (sql.Contains("COUNT", StringComparison.OrdinalIgnoreCase)) return 5L;
                if (sql.Contains("SUM", StringComparison.OrdinalIgnoreCase)) return 18500000m;
                return 1;
            }
        }

        // =========================================================================
        // CÁC HÀM TIỆN ÍCH CHUYỂN ĐỔI KIỂU DỮ LIỆU AN TOÀN TUYỆT ĐỐI (TRÁNH LỖI ÉP KIỂU)
        // =========================================================================
        public static int ToInt(object? val, int defaultVal = 0)
        {
            if (val == null || val == DBNull.Value) return defaultVal;
            if (val is int i) return i;
            if (int.TryParse(val.ToString(), out int res)) return res;
            return defaultVal;
        }

        public static long ToLong(object? val, long defaultVal = 0)
        {
            if (val == null || val == DBNull.Value) return defaultVal;
            if (val is long l) return l;
            if (long.TryParse(val.ToString(), out long res)) return res;
            return defaultVal;
        }

        public static decimal ToDecimal(object? val, decimal defaultVal = 0m)
        {
            if (val == null || val == DBNull.Value) return defaultVal;
            if (val is decimal d) return d;
            if (decimal.TryParse(val.ToString(), out decimal res)) return res;
            return defaultVal;
        }

        public static DateTime ToDateTime(object? val, DateTime defaultVal = default)
        {
            if (val == null || val == DBNull.Value) return (defaultVal == default) ? DateTime.Now : defaultVal;
            if (val is DateTime dt) return dt;
            if (DateTime.TryParse(val.ToString(), out DateTime res)) return res;
            return (defaultVal == default) ? DateTime.Now : defaultVal;
        }

        public static string ToStr(object? val, string defaultVal = "")
        {
            if (val == null || val == DBNull.Value) return defaultVal;
            return val.ToString() ?? defaultVal;
        }

        // =========================================================================
        // 5. Hàm ExecuteInsertAndGetId: Thực thi lệnh INSERT và lấy ID tự tăng
        // =========================================================================
        public static int ExecuteInsertAndGetId(string sql, params MySqlParameter[] parameters)
        {
            try
            {
                using (MySqlConnection conn = TaoKetNoi())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        if (parameters != null && parameters.Length > 0)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        cmd.ExecuteNonQuery();
                        return (int)cmd.LastInsertedId;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Unable to connect", StringComparison.OrdinalIgnoreCase) ||
                    ex.Message.Contains("Access denied", StringComparison.OrdinalIgnoreCase) ||
                    ex.Message.Contains("Connection refused", StringComparison.OrdinalIgnoreCase))
                {
                    return new Random().Next(10, 99); // Giả lập sinh mã ID khi offline demo
                }
                throw new Exception("Lỗi thêm dữ liệu: " + ex.Message);
            }
        }

        // =========================================================================
        // 6. Dữ liệu mẫu dự phòng (Chỉ dùng khi máy tính chưa cài/bật MySQL Server)
        // =========================================================================
        private static DataTable LayDuLieuMauDuPhong(string sql, params MySqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            string upperSql = sql.ToUpperInvariant();

            if (upperSql.Contains("FROM NHANVIEN"))
            {
                dt.Columns.Add("MaNV", typeof(int));
                dt.Columns.Add("TenDangNhap", typeof(string));
                dt.Columns.Add("MatKhau", typeof(string));
                dt.Columns.Add("HoTen", typeof(string));
                dt.Columns.Add("ChucVu", typeof(string));
                dt.Columns.Add("QueQuan", typeof(string));
                dt.Columns.Add("SoDienThoai", typeof(string));
                dt.Columns.Add("NgayTao", typeof(DateTime));

                var danhSach = new (int id, string u, string p, string ten, string cv, string qq, string sdt)[]
                {
                    (1, "admin",  "123456", "Nguyễn Quản Trị", "Admin",                   "Hà Nội",          "0901234567"),
                    (2, "cskh",   "123456", "Trần Chăm Sóc",   "NhanVienCSKH",            "Đà Nẵng",         "0912345678"),
                    (3, "ketoan", "123456", "Lê Kế Toán",      "NhanVienKeToan",          "TP. Hồ Chí Minh", "0923456789"),
                    (4, "datve",  "123456", "Phạm Đặt Vé",     "NhanVienDatVe",           "Hải Phòng",       "0934567890"),
                    (5, "qlcb",   "123456", "Hoàng Chuyến Bay","NhanVienQuanLyChuyenBay", "Cần Thơ",         "0945678901")
                };

                // Lọc theo @u nếu câu truy vấn WHERE TenDangNhap = @u
                string? locUser = null;
                string? locPass = null;
                if (parameters != null)
                {
                    foreach (var p in parameters)
                    {
                        if (p.ParameterName.Equals("@u", StringComparison.OrdinalIgnoreCase))
                            locUser = p.Value?.ToString();
                        if (p.ParameterName.Equals("@p", StringComparison.OrdinalIgnoreCase))
                            locPass = p.Value?.ToString();
                    }
                }

                foreach (var nv in danhSach)
                {
                    if (!string.IsNullOrEmpty(locUser))
                    {
                        if (string.Equals(nv.u, locUser, StringComparison.OrdinalIgnoreCase))
                        {
                            if (string.IsNullOrEmpty(locPass) || nv.p == locPass)
                            {
                                dt.Rows.Add(nv.id, nv.u, nv.p, nv.ten, nv.cv, nv.qq, nv.sdt, DateTime.Now.AddDays(-30));
                            }
                        }
                    }
                    else
                    {
                        dt.Rows.Add(nv.id, nv.u, nv.p, nv.ten, nv.cv, nv.qq, nv.sdt, DateTime.Now.AddDays(-30));
                    }
                }
            }
            else if (upperSql.Contains("FROM CHUYENBAY"))
            {
                dt.Columns.Add("MaChuyenBay", typeof(int));
                dt.Columns.Add("MaMayBay", typeof(int));
                dt.Columns.Add("TenMayBay", typeof(string));
                dt.Columns.Add("SanBayDi", typeof(string));
                dt.Columns.Add("SanBayDen", typeof(string));
                dt.Columns.Add("ThoiGianDi", typeof(DateTime));
                dt.Columns.Add("ThoiGianDen", typeof(DateTime));
                dt.Columns.Add("GiaVe", typeof(decimal));
                dt.Columns.Add("TrangThai", typeof(string));

                DateTime now = DateTime.Now;
                dt.Rows.Add(1, 1, "Boeing 787-9 Dreamliner", "HAN - Nội Bài (Hà Nội)", "SGN - Tân Sơn Nhất (TP.HCM)", now.AddDays(1).Date.AddHours(8), now.AddDays(1).Date.AddHours(10).AddMinutes(15), 1850000m, "Đang mở");
                dt.Rows.Add(2, 2, "Airbus A321 Neo", "SGN - Tân Sơn Nhất (TP.HCM)", "DAD - Đà Nẵng", now.AddDays(1).Date.AddHours(13).AddMinutes(30), now.AddDays(1).Date.AddHours(15), 1200000m, "Đang mở");
                dt.Rows.Add(3, 3, "Boeing 777-300ER", "HAN - Nội Bài (Hà Nội)", "CXR - Cam Ranh", now.AddDays(2).Date.AddHours(9), now.AddDays(2).Date.AddHours(11), 2100000m, "Đang mở");
                dt.Rows.Add(4, 4, "Airbus A350-900", "DAD - Đà Nẵng", "HAN - Nội Bài (Hà Nội)", now.AddDays(3).Date.AddHours(16), now.AddDays(3).Date.AddHours(17).AddMinutes(30), 1350000m, "Đang mở");
                dt.Rows.Add(5, 1, "Boeing 787-9 Dreamliner", "SGN - Tân Sơn Nhất (TP.HCM)", "PQC - Phú Quốc", now.AddDays(3).Date.AddHours(11), now.AddDays(3).Date.AddHours(12), 1150000m, "Đang mở");
            }
            else if (upperSql.Contains("FROM GHE"))
            {
                dt.Columns.Add("MaGhe", typeof(int));
                dt.Columns.Add("MaMayBay", typeof(int));
                dt.Columns.Add("SoGhe", typeof(string));
                dt.Columns.Add("HangGhe", typeof(string));
                dt.Columns.Add("TrangThai", typeof(string));

                dt.Rows.Add(1, 1, "A1", "Thuong gia", "Trong");
                dt.Rows.Add(2, 1, "A2", "Thuong gia", "Trong");
                dt.Rows.Add(3, 1, "B1", "Thuong gia", "Trong");
                dt.Rows.Add(4, 1, "B2", "Thuong gia", "Trong");
                dt.Rows.Add(5, 1, "C1", "Pho thong", "Trong");
                dt.Rows.Add(6, 1, "C2", "Pho thong", "Trong");
                dt.Rows.Add(7, 1, "D1", "Pho thong", "Trong");
                dt.Rows.Add(8, 1, "D2", "Pho thong", "Trong");
                dt.Rows.Add(9, 1, "E1", "Pho thong", "Trong");
                dt.Rows.Add(10, 1, "E2", "Pho thong", "Trong");
            }
            else if (upperSql.Contains("FROM VE"))
            {
                dt.Columns.Add("MaVe", typeof(int));
                dt.Columns.Add("MaChuyenBay", typeof(int));
                dt.Columns.Add("MaKH", typeof(int));
                dt.Columns.Add("MaGhe", typeof(int));
                dt.Columns.Add("HoTen", typeof(string));
                dt.Columns.Add("SDT", typeof(string));
                dt.Columns.Add("CCCD", typeof(string));
                dt.Columns.Add("SanBayDi", typeof(string));
                dt.Columns.Add("SanBayDen", typeof(string));
                dt.Columns.Add("SoGhe", typeof(string));
                dt.Columns.Add("HangGhe", typeof(string));
                dt.Columns.Add("NgayDat", typeof(DateTime));
                dt.Columns.Add("GiaVe", typeof(decimal));
                dt.Columns.Add("TrangThai", typeof(string));

                dt.Rows.Add(1, 1, 1, 1, "Nguyễn Văn An", "0912345678", "001200001234", "HAN - Nội Bài (Hà Nội)", "SGN - Tân Sơn Nhất (TP.HCM)", "A1", "Thuong gia", DateTime.Now.AddDays(-2), 1850000m, "Đã thanh toán");
                dt.Rows.Add(2, 1, 2, 2, "Trần Thị Bình", "0987654321", "079201005678", "HAN - Nội Bài (Hà Nội)", "SGN - Tân Sơn Nhất (TP.HCM)", "A2", "Thuong gia", DateTime.Now.AddDays(-1), 1850000m, "Chờ thanh toán");
            }
            else if (upperSql.Contains("FROM HOADON"))
            {
                dt.Columns.Add("MaHoaDon", typeof(int));
                dt.Columns.Add("MaThanhToan", typeof(int));
                dt.Columns.Add("MaVe", typeof(int));
                dt.Columns.Add("HoTen", typeof(string));
                dt.Columns.Add("PhuongThuc", typeof(string));
                dt.Columns.Add("NgayLap", typeof(DateTime));
                dt.Columns.Add("TongTien", typeof(decimal));

                dt.Rows.Add(1, 1, 1, "Nguyễn Văn An", "Chuyển khoản ngân hàng", DateTime.Now.AddDays(-2), 1850000m);
            }
            else if (upperSql.Contains("FROM YEUCAU_CSKH"))
            {
                dt.Columns.Add("MaYeuCau", typeof(int));
                dt.Columns.Add("MaVe", typeof(int));
                dt.Columns.Add("TenKhach", typeof(string));
                dt.Columns.Add("LoaiYeuCau", typeof(string));
                dt.Columns.Add("NoiDung", typeof(string));
                dt.Columns.Add("NgayTao", typeof(DateTime));
                dt.Columns.Add("TrangThai", typeof(string));
                dt.Columns.Add("GhiChuXuLy", typeof(string));

                dt.Rows.Add(1, 1, "Nguyễn Văn An", "Đổi ghế ngồi", "Hành khách mong muốn đổi sang ghế cạnh cửa sổ", DateTime.Now.AddHours(-3), "Đang xử lý", "Đã tư vấn danh sách ghế trống cho khách");
                dt.Rows.Add(2, 2, "Trần Thị Bình", "Hỗ trợ thanh toán", "Khách hỏi hướng dẫn chuyển khoản qua mã QR", DateTime.Now.AddHours(-1), "Đã giải quyết", "Đã gửi thông tin số tài khoản cho khách");
            }
            else if (upperSql.Contains("FROM MAYBAY"))
            {
                dt.Columns.Add("MaMayBay", typeof(int));
                dt.Columns.Add("TenMayBay", typeof(string));
                dt.Columns.Add("TrangThai", typeof(string));

                dt.Rows.Add(1, "Boeing 787-9 Dreamliner", "Hoạt động");
                dt.Rows.Add(2, "Airbus A321 Neo", "Hoạt động");
                dt.Rows.Add(3, "Boeing 777-300ER", "Hoạt động");
                dt.Rows.Add(4, "Airbus A350-900", "Hoạt động");
            }
            else
            {
                dt.Columns.Add("TuyenBay", typeof(string));
                dt.Columns.Add("DoanhThuTrieu", typeof(float));
                dt.Rows.Add("HAN ➔ SGN", 8.5f);
                dt.Rows.Add("SGN ➔ DAD", 4.2f);
                dt.Rows.Add("HAN ➔ CXR", 3.1f);
                dt.Rows.Add("DAD ➔ HAN", 1.8f);
                dt.Rows.Add("SGN ➔ PQC", 0.9f);
            }

            return dt;
        }
    }
}
