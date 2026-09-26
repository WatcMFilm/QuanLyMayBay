USE QuanLyDatVeMayBay;

-- =====================================================
-- 1. BẢNG MÁY BAY
-- =====================================================
CREATE TABLE MAYBAY (
    MaMayBay INT AUTO_INCREMENT PRIMARY KEY,
    TenMayBay VARCHAR(100) NOT NULL,
    SoGhe INT NOT NULL,
    TrangThai VARCHAR(50) DEFAULT 'Hoạt động'
);


-- =====================================================
-- 2. BẢNG CHUYẾN BAY
-- =====================================================
CREATE TABLE CHUYENBAY (
    MaChuyenBay INT AUTO_INCREMENT PRIMARY KEY,
    MaMayBay INT NOT NULL,
    SanBayDi VARCHAR(100) NOT NULL,
    SanBayDen VARCHAR(100) NOT NULL,
    ThoiGianDi DATETIME NOT NULL,
    ThoiGianDen DATETIME NOT NULL,
    GiaVe DECIMAL(15,2) NOT NULL,
    TrangThai VARCHAR(50) DEFAULT 'Đang mở',

    CONSTRAINT FK_CHUYENBAY_MAYBAY
        FOREIGN KEY (MaMayBay)
        REFERENCES MAYBAY(MaMayBay)
);


-- =====================================================
-- 3. BẢNG GHẾ
-- =====================================================
CREATE TABLE GHE (
    MaGhe INT AUTO_INCREMENT PRIMARY KEY,
    MaMayBay INT NOT NULL,
    SoGhe VARCHAR(10) NOT NULL,
    HangGhe VARCHAR(50) DEFAULT 'Phổ thông',
    TrangThai VARCHAR(50) DEFAULT 'Trống',

    CONSTRAINT FK_GHE_MAYBAY
        FOREIGN KEY (MaMayBay)
        REFERENCES MAYBAY(MaMayBay),

    CONSTRAINT UQ_GHE_MAYBAY
        UNIQUE (MaMayBay, SoGhe)
);


-- =====================================================
-- 4. BẢNG KHÁCH HÀNG
-- =====================================================
CREATE TABLE KHACHHANG (
    MaKH INT AUTO_INCREMENT PRIMARY KEY,
    HoTen VARCHAR(100) NOT NULL,
    CCCD VARCHAR(20),
    SDT VARCHAR(20) NOT NULL,
    Email VARCHAR(100),
    
    CONSTRAINT UQ_KHACHHANG_CCCD
        UNIQUE (CCCD)
);


-- =====================================================
-- 5. BẢNG NHÂN VIÊN
-- =====================================================
CREATE TABLE NHANVIEN (
    MaNV INT AUTO_INCREMENT PRIMARY KEY,
    HoTen VARCHAR(100) NOT NULL,
    NgaySinh DATE,
    GioiTinh VARCHAR(10),
    SDT VARCHAR(20),
    Email VARCHAR(100),
    ChucVu VARCHAR(100) NOT NULL,
    TrangThai VARCHAR(50) DEFAULT 'Đang làm việc'
);


-- =====================================================
-- 6. BẢNG PHÂN CÔNG
-- =====================================================
CREATE TABLE PHANCONG (
    MaPhanCong INT AUTO_INCREMENT PRIMARY KEY,
    MaNV INT NOT NULL,
    CongViec VARCHAR(200) NOT NULL,
    NgayPhanCong DATE NOT NULL,
    TrangThai VARCHAR(50) DEFAULT 'Chưa hoàn thành',

    CONSTRAINT FK_PHANCONG_NHANVIEN
        FOREIGN KEY (MaNV)
        REFERENCES NHANVIEN(MaNV)
);


-- =====================================================
-- 7. BẢNG VÉ
-- =====================================================
CREATE TABLE VE (
    MaVe INT AUTO_INCREMENT PRIMARY KEY,
    MaChuyenBay INT NOT NULL,
    MaKH INT NOT NULL,
    MaGhe INT NOT NULL,
    NgayDat DATETIME DEFAULT CURRENT_TIMESTAMP,
    GiaVe DECIMAL(15,2) NOT NULL,
    TrangThai VARCHAR(50) DEFAULT 'Chờ thanh toán',

    CONSTRAINT FK_VE_CHUYENBAY
        FOREIGN KEY (MaChuyenBay)
        REFERENCES CHUYENBAY(MaChuyenBay),

    CONSTRAINT FK_VE_KHACHHANG
        FOREIGN KEY (MaKH)
        REFERENCES KHACHHANG(MaKH),

    CONSTRAINT FK_VE_GHE
        FOREIGN KEY (MaGhe)
        REFERENCES GHE(MaGhe),

    CONSTRAINT UQ_VE_CHUYENBAY_GHE
        UNIQUE (MaChuyenBay, MaGhe)
);


-- =====================================================
-- 8. BẢNG THANH TOÁN
-- =====================================================
CREATE TABLE THANHTOAN (
    MaThanhToan INT AUTO_INCREMENT PRIMARY KEY,
    MaVe INT NOT NULL,
    SoTien DECIMAL(15,2) NOT NULL,
    PhuongThuc VARCHAR(50) NOT NULL,
    NgayThanhToan DATETIME,
    TrangThai VARCHAR(50) DEFAULT 'Chưa thanh toán',

    CONSTRAINT FK_THANHTOAN_VE
        FOREIGN KEY (MaVe)
        REFERENCES VE(MaVe)
);


-- =====================================================
-- 9. BẢNG HÓA ĐƠN
-- =====================================================
CREATE TABLE HOADON (
    MaHoaDon INT AUTO_INCREMENT PRIMARY KEY,
    MaThanhToan INT NOT NULL,
    NgayLap DATETIME DEFAULT CURRENT_TIMESTAMP,
    TongTien DECIMAL(15,2) NOT NULL,

    CONSTRAINT FK_HOADON_THANHTOAN
        FOREIGN KEY (MaThanhToan)
        REFERENCES THANHTOAN(MaThanhToan),

    CONSTRAINT UQ_HOADON_THANHTOAN
        UNIQUE (MaThanhToan)
);


-- =====================================================
-- 10. BẢNG YÊU CẦU CHĂM SÓC KHÁCH HÀNG
-- =====================================================
CREATE TABLE YEUCAU_CSKH (
    MaYeuCau INT AUTO_INCREMENT PRIMARY KEY,
    MaVe INT NOT NULL,
    MaNV INT,
    LoaiYeuCau VARCHAR(100) NOT NULL,
    NoiDung VARCHAR(500),
    NgayTiepNhan DATETIME DEFAULT CURRENT_TIMESTAMP,
    TrangThai VARCHAR(50) DEFAULT 'Chờ xử lý',

    CONSTRAINT FK_YEUCAU_VE
        FOREIGN KEY (MaVe)
        REFERENCES VE(MaVe),

    CONSTRAINT FK_YEUCAU_NHANVIEN
        FOREIGN KEY (MaNV)
        REFERENCES NHANVIEN(MaNV)
);


-- =====================================================
-- KIỂM TRA CÁC BẢNG ĐÃ TẠO
-- =====================================================
SHOW TABLES;
Select * from ghe;