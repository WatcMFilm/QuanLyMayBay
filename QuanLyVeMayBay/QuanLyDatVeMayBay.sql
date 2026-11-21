-- ====================================================================================================
-- HỆ THỐNG QUẢN LÝ BÁN VÉ MÁY BAY - KỊCH BẢN CƠ SỞ DỮ LIỆU MYSQL WORKBENCH
-- Bộ môn: Lập trình .NET / C# Windows Forms
-- Hỗ trợ: MySQL 5.7, 8.0, 8.4+ / MariaDB 10+
-- Bảng mã: UTF-8 Unicode (utf8mb4 / utf8mb4_unicode_ci)
-- ====================================================================================================

-- 1. Khởi tạo Cơ sở dữ liệu
DROP DATABASE IF EXISTS QuanLyDatVeMayBay;
CREATE DATABASE QuanLyDatVeMayBay 
    CHARACTER SET utf8mb4 
    COLLATE utf8mb4_unicode_ci;

USE QuanLyDatVeMayBay;

-- Tắt kiểm tra khóa ngoại tạm thời để tạo bảng an toàn
SET FOREIGN_KEY_CHECKS = 0;

-- ====================================================================================================
-- 2. TẠO CÁC BẢNG DỮ LIỆU (9 BẢNG CHUẨN)
-- ====================================================================================================

-- ----------------------------------------------------------------------------------------------------
-- BẢNG 1: NHANVIEN (Quản lý tài khoản đăng nhập & phân quyền cho 5 vai trò)
-- ----------------------------------------------------------------------------------------------------
DROP TABLE IF EXISTS NHANVIEN;
CREATE TABLE NHANVIEN (
    MaNV INT AUTO_INCREMENT PRIMARY KEY,
    TenDangNhap VARCHAR(50) NOT NULL UNIQUE COMMENT 'Tên tài khoản đăng nhập',
    MatKhau VARCHAR(100) NOT NULL COMMENT 'Mật khẩu đăng nhập',
    HoTen VARCHAR(100) NOT NULL COMMENT 'Họ và tên nhân viên',
    ChucVu VARCHAR(50) NOT NULL COMMENT 'Admin, NhanVienCSKH, NhanVienKeToan, NhanVienDatVe, NhanVienQuanLyChuyenBay',
    QueQuan VARCHAR(100) DEFAULT NULL COMMENT 'Quê quán nhân viên',
    SoDienThoai VARCHAR(20) DEFAULT NULL COMMENT 'Số điện thoại liên hệ',
    NgayTao DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Ngày tạo tài khoản'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- ----------------------------------------------------------------------------------------------------
-- BẢNG 2: MAYBAY (Quản lý đội máy bay của hãng)
-- ----------------------------------------------------------------------------------------------------
DROP TABLE IF EXISTS MAYBAY;
CREATE TABLE MAYBAY (
    MaMayBay INT AUTO_INCREMENT PRIMARY KEY,
    TenMayBay VARCHAR(100) NOT NULL COMMENT 'Tên máy bay (Boeing 787, Airbus A321...)',
    TrangThai VARCHAR(50) DEFAULT 'Hoạt động' COMMENT 'Hoạt động, Bảo dưỡng, Ngừng bay'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- ----------------------------------------------------------------------------------------------------
-- BẢNG 3: CHUYENBAY (Quản lý các chuyến bay mở bán)
-- ----------------------------------------------------------------------------------------------------
DROP TABLE IF EXISTS CHUYENBAY;
CREATE TABLE CHUYENBAY (
    MaChuyenBay INT AUTO_INCREMENT PRIMARY KEY,
    MaMayBay INT NOT NULL COMMENT 'Khóa ngoại tham chiếu MAYBAY',
    SanBayDi VARCHAR(100) NOT NULL COMMENT 'Sân bay đi (HAN, SGN, DAD...)',
    SanBayDen VARCHAR(100) NOT NULL COMMENT 'Sân bay đến',
    ThoiGianDi DATETIME NOT NULL COMMENT 'Giờ khởi hành dự kiến',
    ThoiGianDen DATETIME NOT NULL COMMENT 'Giờ hạ cánh dự kiến',
    GiaVe DECIMAL(18,2) NOT NULL DEFAULT 0.00 COMMENT 'Giá vé cơ bản (VNĐ)',
    TrangThai VARCHAR(50) DEFAULT 'Đang mở' COMMENT 'Đang mở, Sắp cất cánh, Đã cất cánh, Hoàn tất, Đã hủy',
    CONSTRAINT FK_ChuyenBay_MayBay FOREIGN KEY (MaMayBay) 
        REFERENCES MAYBAY(MaMayBay) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- ----------------------------------------------------------------------------------------------------
-- BẢNG 4: GHE (Danh mục ghế ngồi thuộc từng tàu bay)
-- Ghế thuộc về Máy bay. Trạng thái 'Trong': sẵn sàng; 'Bảo trì': ghế hỏng cần sửa chữa
-- Ghế được đặt trên chuyến bay cụ thể được ghi nhận thông qua bảng VE
-- ----------------------------------------------------------------------------------------------------
DROP TABLE IF EXISTS GHE;
CREATE TABLE GHE (
    MaGhe INT AUTO_INCREMENT PRIMARY KEY,
    MaMayBay INT NOT NULL COMMENT 'Khóa ngoại tham chiếu MAYBAY',
    SoGhe VARCHAR(10) NOT NULL COMMENT 'Ký hiệu ghế: A1, A2, B1, E1...',
    HangGhe VARCHAR(50) NOT NULL DEFAULT 'Pho thong' COMMENT 'Thuong gia, Pho thong',
    TrangThai VARCHAR(50) DEFAULT 'Trong' COMMENT 'Trong, Bảo trì',
    CONSTRAINT FK_Ghe_MayBay FOREIGN KEY (MaMayBay) 
        REFERENCES MAYBAY(MaMayBay) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- ----------------------------------------------------------------------------------------------------
-- BẢNG 5: KHACHHANG (Quản lý hồ sơ hành khách)
-- ----------------------------------------------------------------------------------------------------
DROP TABLE IF EXISTS KHACHHANG;
CREATE TABLE KHACHHANG (
    MaKH INT AUTO_INCREMENT PRIMARY KEY,
    HoTen VARCHAR(100) NOT NULL COMMENT 'Họ tên hành khách',
    CCCD VARCHAR(20) NOT NULL COMMENT 'Số CCCD hoặc Hộ chiếu',
    SDT VARCHAR(20) NOT NULL COMMENT 'Số điện thoại',
    Email VARCHAR(100) DEFAULT NULL COMMENT 'Địa chỉ email'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- ----------------------------------------------------------------------------------------------------
-- BẢNG 6: VE (Thông tin đặt vé máy bay của khách)
-- ----------------------------------------------------------------------------------------------------
DROP TABLE IF EXISTS VE;
CREATE TABLE VE (
    MaVe INT AUTO_INCREMENT PRIMARY KEY,
    MaChuyenBay INT NOT NULL COMMENT 'Khóa ngoại tham chiếu CHUYENBAY',
    MaKH INT NOT NULL COMMENT 'Khóa ngoại tham chiếu KHACHHANG',
    MaGhe INT NOT NULL COMMENT 'Khóa ngoại tham chiếu GHE',
    NgayDat DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Thời điểm đặt vé',
    GiaVe DECIMAL(18,2) NOT NULL DEFAULT 0.00 COMMENT 'Giá vé thực tế thanh toán',
    TrangThai VARCHAR(50) DEFAULT 'Chờ thanh toán' COMMENT 'Chờ thanh toán, Đã thanh toán, Đã hủy',
    CONSTRAINT FK_Ve_ChuyenBay FOREIGN KEY (MaChuyenBay) 
        REFERENCES CHUYENBAY(MaChuyenBay) ON DELETE RESTRICT ON UPDATE CASCADE,
    CONSTRAINT FK_Ve_KhachHang FOREIGN KEY (MaKH) 
        REFERENCES KHACHHANG(MaKH) ON DELETE RESTRICT ON UPDATE CASCADE,
    CONSTRAINT FK_Ve_Ghe FOREIGN KEY (MaGhe) 
        REFERENCES GHE(MaGhe) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- ----------------------------------------------------------------------------------------------------
-- BẢNG 7: THANHTOAN (Lưu thông tin giao dịch thanh toán)
-- ----------------------------------------------------------------------------------------------------
DROP TABLE IF EXISTS THANHTOAN;
CREATE TABLE THANHTOAN (
    MaThanhToan INT AUTO_INCREMENT PRIMARY KEY,
    MaVe INT NOT NULL COMMENT 'Khóa ngoại tham chiếu VE',
    SoTien DECIMAL(18,2) NOT NULL COMMENT 'Số tiền thanh toán',
    PhuongThuc VARCHAR(100) NOT NULL COMMENT 'Tiền mặt, Chuyển khoản, Thẻ POS, Ví điện tử',
    NgayThanhToan DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Thời điểm thanh toán',
    TrangThai VARCHAR(50) DEFAULT 'Đã thanh toán' COMMENT 'Đã thanh toán, Thành công, Đã hoàn tiền',
    CONSTRAINT FK_ThanhToan_Ve FOREIGN KEY (MaVe) 
        REFERENCES VE(MaVe) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- ----------------------------------------------------------------------------------------------------
-- BẢNG 8: HOADON (Hóa đơn tài chính xuất cho khách sau khi thanh toán)
-- ----------------------------------------------------------------------------------------------------
DROP TABLE IF EXISTS HOADON;
CREATE TABLE HOADON (
    MaHoaDon INT AUTO_INCREMENT PRIMARY KEY,
    MaThanhToan INT NOT NULL COMMENT 'Khóa ngoại tham chiếu THANHTOAN',
    NgayLap DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Ngày giờ lập hóa đơn',
    TongTien DECIMAL(18,2) NOT NULL COMMENT 'Tổng số tiền ghi nhận trên hóa đơn',
    CONSTRAINT FK_HoaDon_ThanhToan FOREIGN KEY (MaThanhToan) 
        REFERENCES THANHTOAN(MaThanhToan) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- ----------------------------------------------------------------------------------------------------
-- BẢNG 9: YEUCAU_CSKH (Quản lý các yêu cầu, khiếu nại, đổi trả vé của khách)
-- ----------------------------------------------------------------------------------------------------
DROP TABLE IF EXISTS YEUCAU_CSKH;
CREATE TABLE YEUCAU_CSKH (
    MaYeuCau INT AUTO_INCREMENT PRIMARY KEY,
    MaVe INT DEFAULT NULL COMMENT 'Mã vé liên quan (nếu có)',
    TenKhach VARCHAR(100) NOT NULL COMMENT 'Tên khách hàng yêu cầu',
    LoaiYeuCau VARCHAR(50) NOT NULL COMMENT 'Đổi ghế, Đổi chuyến, Hủy vé, Hỗ trợ thanh toán...',
    NoiDung TEXT NOT NULL COMMENT 'Nội dung chi tiết yêu cầu',
    NgayTao DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Thời điểm tiếp nhận',
    TrangThai VARCHAR(50) DEFAULT 'Tiếp nhận' COMMENT 'Tiếp nhận, Đang xử lý, Đã giải quyết, Từ chối',
    GhiChuXuLy TEXT DEFAULT NULL COMMENT 'Ghi chú kết quả xử lý của CSKH',
    CONSTRAINT FK_YeuCau_Ve FOREIGN KEY (MaVe) 
        REFERENCES VE(MaVe) ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Bật lại kiểm tra khóa ngoại
SET FOREIGN_KEY_CHECKS = 1;

-- ----------------------------------------------------------------------------------------------------
-- CÁC CHỈ MỤC TỐI ƯU TRUY VẤN (INDEXES)
-- ----------------------------------------------------------------------------------------------------
CREATE INDEX IX_ChuyenBay_ThoiGianDi ON CHUYENBAY(ThoiGianDi);
CREATE INDEX IX_ChuyenBay_Tuyen ON CHUYENBAY(SanBayDi, SanBayDen);
CREATE INDEX IX_Ghe_MayBay_TrangThai ON GHE(MaMayBay, TrangThai);
CREATE INDEX IX_Ve_ChuyenBay_Ghe ON VE(MaChuyenBay, MaGhe, TrangThai);
CREATE INDEX IX_KhachHang_CCCD ON KHACHHANG(CCCD);
CREATE INDEX IX_KhachHang_SDT ON KHACHHANG(SDT);
CREATE INDEX IX_ThanhToan_MaVe ON THANHTOAN(MaVe);


-- ====================================================================================================
-- 3. CHÈN DỮ LIỆU KHỞI TẠO MẪU (SEED DATA CHUẨN)
-- ====================================================================================================

-- 1. Tài khoản nhân viên cho 5 bộ phận (Mật khẩu mặc định: 123456)
INSERT INTO NHANVIEN (TenDangNhap, MatKhau, HoTen, ChucVu, QueQuan, SoDienThoai) VALUES
('admin',  '123456', 'Nguyễn Quản Trị', 'Admin',                   'Hà Nội',         '0901234567'),
('cskh',   '123456', 'Trần Chăm Sóc',   'NhanVienCSKH',            'Đà Nẵng',        '0912345678'),
('ketoan', '123456', 'Lê Kế Toán',      'NhanVienKeToan',          'TP. Hồ Chí Minh','0923456789'),
('datve',  '123456', 'Phạm Đặt Vé',     'NhanVienDatVe',           'Hải Phòng',      '0934567890'),
('qlcb',   '123456', 'Hoàng Chuyến Bay','NhanVienQuanLyChuyenBay', 'Cần Thơ',        '0945678901');

-- 2. Đội máy bay
INSERT INTO MAYBAY (TenMayBay, TrangThai) VALUES
('Boeing 787-9 Dreamliner', 'Hoạt động'),
('Airbus A321 Neo',         'Hoạt động'),
('Boeing 777-300ER',        'Hoạt động'),
('Airbus A350-900',         'Hoạt động');

-- 3. Danh mục ghế cho từng máy bay (Hạng Thương gia & Phổ thông)
-- Tàu bay 1: Boeing 787-9 Dreamliner
INSERT INTO GHE (MaMayBay, SoGhe, HangGhe, TrangThai) VALUES
(1, 'A1', 'Thuong gia', 'Trong'), (1, 'A2', 'Thuong gia', 'Trong'),
(1, 'B1', 'Thuong gia', 'Trong'), (1, 'B2', 'Thuong gia', 'Trong'),
(1, 'C1', 'Pho thong',  'Trong'), (1, 'C2', 'Pho thong',  'Trong'),
(1, 'D1', 'Pho thong',  'Trong'), (1, 'D2', 'Pho thong',  'Trong'),
(1, 'E1', 'Pho thong',  'Trong'), (1, 'E2', 'Pho thong',  'Trong'),
(1, 'F1', 'Pho thong',  'Trong'), (1, 'F2', 'Pho thong',  'Trong');

-- Tàu bay 2: Airbus A321 Neo
INSERT INTO GHE (MaMayBay, SoGhe, HangGhe, TrangThai) VALUES
(2, 'A1', 'Thuong gia', 'Trong'), (2, 'A2', 'Thuong gia', 'Trong'),
(2, 'B1', 'Thuong gia', 'Trong'), (2, 'B2', 'Thuong gia', 'Trong'),
(2, 'C1', 'Pho thong',  'Trong'), (2, 'C2', 'Pho thong',  'Trong'),
(2, 'D1', 'Pho thong',  'Trong'), (2, 'D2', 'Pho thong',  'Trong');

-- Tàu bay 3: Boeing 777-300ER
INSERT INTO GHE (MaMayBay, SoGhe, HangGhe, TrangThai) VALUES
(3, 'A1', 'Thuong gia', 'Trong'), (3, 'A2', 'Thuong gia', 'Trong'),
(3, 'B1', 'Thuong gia', 'Trong'), (3, 'B2', 'Thuong gia', 'Trong'),
(3, 'C1', 'Pho thong',  'Trong'), (3, 'C2', 'Pho thong',  'Trong');

-- Tàu bay 4: Airbus A350-900
INSERT INTO GHE (MaMayBay, SoGhe, HangGhe, TrangThai) VALUES
(4, 'A1', 'Thuong gia', 'Trong'), (4, 'A2', 'Thuong gia', 'Trong'),
(4, 'B1', 'Thuong gia', 'Trong'), (4, 'B2', 'Thuong gia', 'Trong'),
(4, 'C1', 'Pho thong',  'Trong'), (4, 'C2', 'Pho thong',  'Trong');

-- 4. Danh sách các chuyến bay mở bán
INSERT INTO CHUYENBAY (MaMayBay, SanBayDi, SanBayDen, ThoiGianDi, ThoiGianDen, GiaVe, TrangThai) VALUES
(1, 'HAN - Nội Bài (Hà Nội)',       'SGN - Tân Sơn Nhất (TP.HCM)', DATE_ADD(NOW(), INTERVAL 1 DAY), DATE_ADD(DATE_ADD(NOW(), INTERVAL 1 DAY), INTERVAL 2 HOUR), 1850000.00, 'Đang mở'),
(2, 'SGN - Tân Sơn Nhất (TP.HCM)',  'DAD - Đà Nẵng',               DATE_ADD(NOW(), INTERVAL 1 DAY), DATE_ADD(DATE_ADD(NOW(), INTERVAL 1 DAY), INTERVAL 1 HOUR), 1200000.00, 'Đang mở'),
(3, 'HAN - Nội Bài (Hà Nội)',       'CXR - Cam Ranh',              DATE_ADD(NOW(), INTERVAL 2 DAY), DATE_ADD(DATE_ADD(NOW(), INTERVAL 2 DAY), INTERVAL 2 HOUR), 2100000.00, 'Đang mở'),
(4, 'DAD - Đà Nẵng',                'HAN - Nội Bài (Hà Nội)',      DATE_ADD(NOW(), INTERVAL 3 DAY), DATE_ADD(DATE_ADD(NOW(), INTERVAL 3 DAY), INTERVAL 1 HOUR), 1350000.00, 'Đang mở'),
(1, 'SGN - Tân Sơn Nhất (TP.HCM)',  'PQC - Phú Quốc',              DATE_ADD(NOW(), INTERVAL 3 DAY), DATE_ADD(DATE_ADD(NOW(), INTERVAL 3 DAY), INTERVAL 1 HOUR), 1150000.00, 'Đang mở');

-- 5. Khách hàng mẫu
INSERT INTO KHACHHANG (HoTen, CCCD, SDT, Email) VALUES
('Nguyễn Văn An',   '001200001234', '0912345678', 'an.nguyen@gmail.com'),
('Trần Thị Bình',   '079201005678', '0987654321', 'binh.tran@gmail.com'),
('Lê Hoàng Nam',    '048202009876', '0933445566', 'nam.le@gmail.com');

-- 6. Vé mẫu
INSERT INTO VE (MaChuyenBay, MaKH, MaGhe, NgayDat, GiaVe, TrangThai) VALUES
(1, 1, 1, DATE_SUB(NOW(), INTERVAL 2 DAY), 1850000.00, 'Đã thanh toán'),
(1, 2, 2, DATE_SUB(NOW(), INTERVAL 1 DAY), 1850000.00, 'Chờ thanh toán'),
(2, 3, 13, DATE_SUB(NOW(), INTERVAL 1 DAY), 1200000.00, 'Đã thanh toán');

-- 7. Thanh toán mẫu
INSERT INTO THANHTOAN (MaVe, SoTien, PhuongThuc, NgayThanhToan, TrangThai) VALUES
(1, 1850000.00, 'Chuyển khoản ngân hàng', DATE_SUB(NOW(), INTERVAL 2 DAY), 'Đã thanh toán'),
(3, 1200000.00, 'Tiền mặt',               DATE_SUB(NOW(), INTERVAL 1 DAY), 'Đã thanh toán');

-- 8. Hóa đơn mẫu
INSERT INTO HOADON (MaThanhToan, NgayLap, TongTien) VALUES
(1, DATE_SUB(NOW(), INTERVAL 2 DAY), 1850000.00),
(2, DATE_SUB(NOW(), INTERVAL 1 DAY), 1200000.00);

-- 9. Yêu cầu CSKH mẫu
INSERT INTO YEUCAU_CSKH (MaVe, TenKhach, LoaiYeuCau, NoiDung, NgayTao, TrangThai, GhiChuXuLy) VALUES
(1, 'Nguyễn Văn An', 'Đổi ghế ngồi', 'Hành khách mong muốn đổi sang ghế cạnh cửa sổ', DATE_SUB(NOW(), INTERVAL 3 HOUR), 'Đang xử lý', 'Đã tư vấn danh sách ghế trống cho khách'),
(2, 'Trần Thị Bình', 'Hỗ trợ thanh toán', 'Khách hỏi hướng dẫn chuyển khoản qua mã QR', DATE_SUB(NOW(), INTERVAL 1 HOUR), 'Đã giải quyết', 'Đã gửi thông tin số tài khoản cho khách');

-- ====================================================================================================
-- HOÀN TẤT KHỞI TẠO DATABASE
-- ====================================================================================================
