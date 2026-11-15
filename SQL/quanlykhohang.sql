-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Máy chủ: 127.0.0.1
-- Thời gian đã tạo: Th10 15, 2026 lúc 04:26 PM
-- Phiên bản máy phục vụ: 10.4.32-MariaDB
-- Phiên bản PHP: 8.0.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Cơ sở dữ liệu: `quanlykhohang`
--

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `chitietphieunhap`
--

CREATE TABLE `chitietphieunhap` (
  `MaCTPN` int(11) NOT NULL,
  `MaPhieuNhap` int(11) NOT NULL,
  `MaSP` int(11) NOT NULL,
  `SoLuong` int(11) NOT NULL,
  `DonGia` decimal(18,2) NOT NULL,
  `ThanhTien` decimal(18,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `chitietphieunhap`
--

INSERT INTO `chitietphieunhap` (`MaCTPN`, `MaPhieuNhap`, `MaSP`, `SoLuong`, `DonGia`, `ThanhTien`) VALUES
(1, 1, 1, 10, 15000000.00, 150000000.00),
(2, 1, 2, 50, 250000.00, 12500000.00),
(3, 1, 3, 20, 1500000.00, 30000000.00),
(4, 2, 4, 30, 55000.00, 1650000.00),
(5, 2, 5, 40, 30000.00, 1200000.00),
(6, 3, 8, 10, 450000.00, 4500000.00),
(7, 3, 15, 15, 350000.00, 5250000.00),
(8, 3, 10, 100, 25000.00, 2500000.00);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `chitietphieuxuat`
--

CREATE TABLE `chitietphieuxuat` (
  `MaCTPX` int(11) NOT NULL,
  `MaPhieuXuat` int(11) NOT NULL,
  `MaSP` int(11) NOT NULL,
  `SoLuong` int(11) NOT NULL,
  `DonGia` decimal(18,2) NOT NULL,
  `ThanhTien` decimal(18,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `chitietphieuxuat`
--

INSERT INTO `chitietphieuxuat` (`MaCTPX`, `MaPhieuXuat`, `MaSP`, `SoLuong`, `DonGia`, `ThanhTien`) VALUES
(1, 1, 1, 2, 18000000.00, 36000000.00),
(2, 1, 2, 2, 350000.00, 700000.00),
(3, 2, 4, 5, 75000.00, 375000.00),
(4, 2, 5, 2, 45000.00, 90000.00);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `danhmuc`
--

CREATE TABLE `danhmuc` (
  `MaDanhMuc` int(11) NOT NULL,
  `TenDanhMuc` varchar(100) NOT NULL,
  `MoTa` varchar(255) DEFAULT NULL,
  `TrangThai` tinyint(4) DEFAULT 1 COMMENT '1=Hoß║ít ─æß╗Öng, 0=ß║¿n',
  `NgayTao` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `danhmuc`
--

INSERT INTO `danhmuc` (`MaDanhMuc`, `TenDanhMuc`, `MoTa`, `TrangThai`, `NgayTao`) VALUES
(1, 'Điện tử', 'Thiết bị điện tử, linh kiện', 1, '2026-11-10 21:41:03'),
(2, 'Văn phòng phẩm', 'Đồ dùng văn phòng', 1, '2026-11-10 21:41:03'),
(3, 'Thực phẩm', 'Thực phẩm, đồ uống', 1, '2026-11-10 21:41:03'),
(4, 'Gia dụng', 'Đồ gia dụng', 1, '2026-11-10 21:41:03'),
(5, 'Quần áo', 'Thời trang, quần áo', 1, '2026-11-10 21:41:03'),
(6, 'Phụ kiện', 'Phụ kiện các loại', 1, '2026-11-10 21:41:03'),
(7, 'Vật liệu', 'Vật liệu xây dựng, công nghiệp', 1, '2026-11-10 21:41:03'),
(8, 'Khác', 'Các mặt hàng khác', 1, '2026-11-10 21:41:03');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `donvitinh`
--

CREATE TABLE `donvitinh` (
  `MaDVT` int(11) NOT NULL,
  `TenDVT` varchar(50) NOT NULL,
  `MoTa` varchar(255) DEFAULT NULL,
  `TrangThai` tinyint(4) DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `donvitinh`
--

INSERT INTO `donvitinh` (`MaDVT`, `TenDVT`, `MoTa`, `TrangThai`) VALUES
(1, 'Cái', 'Đơn vị đếm cái', 1),
(2, 'Chiếc', 'Đơn vị đếm chiếc', 1),
(3, 'Hộp', 'Đơn vị đóng hộp', 1),
(4, 'Thùng', 'Đơn vị đóng thùng', 1),
(5, 'Kg', 'Kilogram', 1),
(6, 'Lít', 'Lít', 1),
(7, 'Mét', 'Mét', 1),
(8, 'Bộ', 'Bộ/Combo', 1),
(9, 'Cuộn', 'Cuộn', 1),
(10, 'Gói', 'Gói', 1);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `khachhang`
--

CREATE TABLE `khachhang` (
  `MaKH` int(11) NOT NULL,
  `TenKH` varchar(200) NOT NULL,
  `SoDienThoai` varchar(20) DEFAULT NULL,
  `Email` varchar(100) DEFAULT NULL,
  `DiaChi` varchar(255) DEFAULT NULL,
  `MoTa` text DEFAULT NULL,
  `TrangThai` tinyint(4) DEFAULT 1,
  `NgayTao` datetime DEFAULT current_timestamp(),
  `NgayCapNhat` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `khachhang`
--

INSERT INTO `khachhang` (`MaKH`, `TenKH`, `SoDienThoai`, `Email`, `DiaChi`, `MoTa`, `TrangThai`, `NgayTao`, `NgayCapNhat`) VALUES
(1, 'Cửa hàng Minh Anh', '0901111111', 'minhanh@email.com', '100 Nguyễn Trãi, Q5, TP.HCM', NULL, 1, '2026-11-10 21:41:03', '2026-11-11 01:41:46'),
(2, 'Shop Hải Đăng', '0902222222', 'haidang@email.com', '200 Lý Tự Trọng, Q1, TP.HCM', NULL, 1, '2026-11-10 21:41:03', '2026-11-11 01:41:46'),
(3, 'Đại lý Thanh Xuân', '0903333333', 'thanhxuan@email.com', '300 Giải Phóng, Hà Nội', NULL, 1, '2026-11-10 21:41:03', '2026-11-11 01:41:46'),
(4, 'Siêu thị Mini Phước Lộc', '0904444444', 'phuocloc@email.com', '400 Cách Mạng T8, Q3, TP.HCM', NULL, 1, '2026-11-10 21:41:03', '2026-11-11 01:41:46'),
(5, 'Công ty TNHH Hoa Sen', '0905555555', 'hoasen@email.com', '500 Hai Bà Trưng, Huế', NULL, 1, '2026-11-10 21:41:03', '2026-11-11 01:41:46');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `lichsutonkho`
--

CREATE TABLE `lichsutonkho` (
  `MaLichSu` int(11) NOT NULL,
  `MaSP` int(11) NOT NULL,
  `LoaiGiaoDich` varchar(20) NOT NULL COMMENT 'NHAP, XUAT, HUY_NHAP, HUY_XUAT, DIEU_CHINH',
  `SoLuongThayDoi` int(11) NOT NULL COMMENT 'Dã░ãíng=t─âng, ├ém=giß║úm',
  `TonSauGiaoDich` int(11) NOT NULL,
  `MaPhieuNhap` int(11) DEFAULT NULL,
  `MaPhieuXuat` int(11) DEFAULT NULL,
  `MaTK` int(11) DEFAULT NULL COMMENT 'Ngã░ß╗Øi thß╗▒c hiß╗çn',
  `GhiChu` varchar(500) DEFAULT NULL,
  `NgayTao` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `lichsutonkho`
--

INSERT INTO `lichsutonkho` (`MaLichSu`, `MaSP`, `LoaiGiaoDich`, `SoLuongThayDoi`, `TonSauGiaoDich`, `MaPhieuNhap`, `MaPhieuXuat`, `MaTK`, `GhiChu`, `NgayTao`) VALUES
(18, 1, 'NHAP', 10, 27, 1, NULL, 1, 'Nhập từ PN-20241001-001', '2024-10-01 09:30:00'),
(19, 2, 'NHAP', 50, 102, 1, NULL, 1, 'Nhập từ PN-20241001-001', '2024-10-01 09:30:00'),
(20, 3, 'NHAP', 20, 30, 1, NULL, 1, 'Nhập từ PN-20241001-001', '2024-10-01 09:30:00'),
(21, 4, 'NHAP', 30, 205, 2, NULL, 2, 'Nhập từ PN-20241015-001', '2024-10-15 10:30:00'),
(22, 5, 'NHAP', 40, 152, 2, NULL, 2, 'Nhập từ PN-20241015-001', '2024-10-15 10:30:00'),
(23, 8, 'NHAP', 10, 15, 3, NULL, 1, 'Nhập từ PN-20241101-001', '2024-11-01 08:30:00'),
(24, 15, 'NHAP', 15, 20, 3, NULL, 1, 'Nhập từ PN-20241101-001', '2024-11-01 08:30:00'),
(25, 10, 'NHAP', 100, 500, 3, NULL, 1, 'Nhập từ PN-20241101-001', '2024-11-01 08:30:00'),
(26, 1, 'XUAT', -2, 25, NULL, NULL, 1, 'Xuất từ PX-20241005-001', '2024-10-05 14:30:00'),
(27, 2, 'XUAT', -2, 100, NULL, NULL, 1, 'Xuất từ PX-20241005-001', '2024-10-05 14:30:00'),
(28, 4, 'XUAT', -5, 200, NULL, NULL, 2, 'Xuất từ PX-20241020-001', '2024-10-20 11:30:00'),
(29, 5, 'XUAT', -2, 150, NULL, NULL, 2, 'Xuất từ PX-20241020-001', '2024-10-20 11:30:00');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `nhacungcap`
--

CREATE TABLE `nhacungcap` (
  `MaNCC` int(11) NOT NULL,
  `TenNCC` varchar(200) NOT NULL,
  `NguoiLienHe` varchar(100) DEFAULT NULL,
  `SoDienThoai` varchar(20) DEFAULT NULL,
  `Email` varchar(100) DEFAULT NULL,
  `DiaChi` varchar(255) DEFAULT NULL,
  `MoTa` text DEFAULT NULL,
  `TrangThai` tinyint(4) DEFAULT 1 COMMENT '1=Hoß║ít ─æß╗Öng, 0=Ngß╗½ng',
  `NgayTao` datetime DEFAULT current_timestamp(),
  `NgayCapNhat` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `nhacungcap`
--

INSERT INTO `nhacungcap` (`MaNCC`, `TenNCC`, `NguoiLienHe`, `SoDienThoai`, `Email`, `DiaChi`, `MoTa`, `TrangThai`, `NgayTao`, `NgayCapNhat`) VALUES
(1, 'Công ty TNHH ABC', 'Nguyễn Văn A', '0281234567', 'abc@email.com', '123 Lê Lợi, Q1, TP.HCM', NULL, 1, '2026-11-10 21:41:03', '2026-11-11 01:41:46'),
(2, 'Công ty CP XYZ', 'Trần Văn B', '0241234567', 'xyz@email.com', '456 Trần Hưng Đạo, Hà Nội', NULL, 1, '2026-11-10 21:41:03', '2026-11-11 01:41:46'),
(3, 'Công ty TNHH Phát Đạt', 'Lê Thị C', '0261234567', 'phatdat@email.com', '789 Nguyễn Huệ, Đà Nẵng', NULL, 1, '2026-11-10 21:41:03', '2026-11-11 01:41:46'),
(4, 'Nhà phân phối Miền Nam', 'Phạm Văn D', '0291234567', 'miennam@email.com', '321 Võ Văn Tần, Q3, TP.HCM', NULL, 1, '2026-11-10 21:41:03', '2026-11-11 01:41:46'),
(5, 'Công ty Thương mại Bắc Hà', 'Hoàng Văn E', '0231234567', 'bactha@email.com', '654 Điện Biên Phủ, Hải Phòng', NULL, 1, '2026-11-10 21:41:03', '2026-11-11 01:41:46');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `nhanvien`
--

CREATE TABLE `nhanvien` (
  `MaNV` int(11) NOT NULL,
  `HoTen` varchar(100) NOT NULL,
  `GioiTinh` varchar(10) DEFAULT NULL,
  `NgaySinh` date DEFAULT NULL,
  `SoDienThoai` varchar(20) DEFAULT NULL,
  `Email` varchar(100) DEFAULT NULL,
  `DiaChi` varchar(255) DEFAULT NULL,
  `ChucVu` varchar(50) DEFAULT NULL,
  `TrangThai` tinyint(4) DEFAULT 1 COMMENT '1=─Éang l├ám, 0=Nghß╗ë viß╗çc',
  `NgayTao` datetime DEFAULT current_timestamp(),
  `NgayCapNhat` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `nhanvien`
--

INSERT INTO `nhanvien` (`MaNV`, `HoTen`, `GioiTinh`, `NgaySinh`, `SoDienThoai`, `Email`, `DiaChi`, `ChucVu`, `TrangThai`, `NgayTao`, `NgayCapNhat`) VALUES
(1, 'Nguyễn Văn Admin', 'Nam', NULL, '0901234567', 'admin@kho.vn', 'Hà Nội', 'Quản trị viên', 1, '2026-11-10 21:41:03', '2026-11-11 01:41:46'),
(2, 'Trần Thị Quản Lý', 'Nữ', NULL, '0912345678', 'quanly@kho.vn', 'TP.HCM', 'Quản lý kho', 1, '2026-11-10 21:41:03', '2026-11-11 01:41:46'),
(3, 'Lê Văn Nhân Viên', 'Nam', NULL, '0923456789', 'nhanvien@kho.vn', 'Đà Nẵng', 'Nhân viên kho', 1, '2026-11-10 21:41:03', '2026-11-11 01:41:46');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `phanquyen`
--

CREATE TABLE `phanquyen` (
  `MaVaiTro` int(11) NOT NULL,
  `MaQuyen` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `phanquyen`
--

INSERT INTO `phanquyen` (`MaVaiTro`, `MaQuyen`) VALUES
(1, 1),
(1, 2),
(1, 3),
(1, 4),
(1, 5),
(1, 6),
(1, 7),
(1, 8),
(1, 9),
(1, 10),
(1, 11),
(1, 12),
(1, 13),
(1, 14),
(1, 15),
(1, 16),
(1, 17),
(1, 18),
(1, 19),
(1, 20),
(1, 21),
(2, 1),
(2, 3),
(2, 5),
(2, 6),
(2, 7),
(2, 8),
(2, 9),
(2, 10),
(2, 11),
(2, 12),
(2, 13),
(2, 14),
(2, 15),
(2, 16),
(2, 17),
(2, 18),
(2, 19),
(2, 20),
(2, 21),
(3, 1),
(3, 5),
(3, 6),
(3, 7),
(3, 10),
(3, 13),
(3, 14),
(3, 17),
(3, 18);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `phieunhap`
--

CREATE TABLE `phieunhap` (
  `MaPhieuNhap` int(11) NOT NULL,
  `MaPhieuNhapCode` varchar(50) NOT NULL COMMENT 'PN-20241001-001',
  `MaNCC` int(11) DEFAULT NULL,
  `MaTK` int(11) DEFAULT NULL COMMENT 'Ngã░ß╗Øi tß║ío phiß║┐u',
  `NgayNhap` datetime DEFAULT current_timestamp(),
  `TongTien` decimal(18,2) DEFAULT 0.00,
  `GhiChu` text DEFAULT NULL,
  `TrangThai` tinyint(4) DEFAULT 0 COMMENT '0=Nh├íp, 1=─É├ú x├íc nhß║¡n, 2=─É├ú hß╗ºy',
  `NgayXacNhan` datetime DEFAULT NULL,
  `NguoiXacNhan` int(11) DEFAULT NULL COMMENT 'MaTK ngã░ß╗Øi x├íc nhß║¡n',
  `NgayTao` datetime DEFAULT current_timestamp(),
  `NgayCapNhat` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `phieunhap`
--

INSERT INTO `phieunhap` (`MaPhieuNhap`, `MaPhieuNhapCode`, `MaNCC`, `MaTK`, `NgayNhap`, `TongTien`, `GhiChu`, `TrangThai`, `NgayXacNhan`, `NguoiXacNhan`, `NgayTao`, `NgayCapNhat`) VALUES
(1, 'PN-20241001-001', 1, 1, '2024-10-01 09:00:00', 192500000.00, 'Nhập hàng điện tử đợt 1', 1, '2024-10-01 09:30:00', 1, '2026-11-10 21:41:03', '2026-11-11 01:41:46'),
(2, 'PN-20241015-001', 2, 2, '2024-10-15 10:00:00', 2850000.00, 'Nhập văn phòng phẩm', 1, '2024-10-15 10:30:00', 1, '2026-11-10 21:41:03', '2026-11-11 01:41:46'),
(3, 'PN-20241101-001', 3, 1, '2024-11-01 08:00:00', 12250000.00, 'Nhập hàng gia dụng', 1, '2024-11-01 08:30:00', 1, '2026-11-10 21:41:03', '2026-11-11 01:41:46');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `phieuxuat`
--

CREATE TABLE `phieuxuat` (
  `MaPhieuXuat` int(11) NOT NULL,
  `MaPhieuXuatCode` varchar(50) NOT NULL COMMENT 'PX-20241001-001',
  `MaKH` int(11) DEFAULT NULL,
  `MaTK` int(11) DEFAULT NULL COMMENT 'Ngã░ß╗Øi tß║ío phiß║┐u',
  `NgayXuat` datetime DEFAULT current_timestamp(),
  `TongTien` decimal(18,2) DEFAULT 0.00,
  `GhiChu` text DEFAULT NULL,
  `TrangThai` tinyint(4) DEFAULT 0 COMMENT '0=Nh├íp, 1=─É├ú x├íc nhß║¡n, 2=─É├ú hß╗ºy',
  `NgayXacNhan` datetime DEFAULT NULL,
  `NguoiXacNhan` int(11) DEFAULT NULL COMMENT 'MaTK ngã░ß╗Øi x├íc nhß║¡n',
  `NgayTao` datetime DEFAULT current_timestamp(),
  `NgayCapNhat` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `phieuxuat`
--

INSERT INTO `phieuxuat` (`MaPhieuXuat`, `MaPhieuXuatCode`, `MaKH`, `MaTK`, `NgayXuat`, `TongTien`, `GhiChu`, `TrangThai`, `NgayXacNhan`, `NguoiXacNhan`, `NgayTao`, `NgayCapNhat`) VALUES
(1, 'PX-20241005-001', 1, 1, '2024-10-05 14:00:00', 36700000.00, 'Xuất hàng cho cửa hàng Minh Anh', 1, '2024-10-05 14:30:00', 1, '2026-11-10 21:41:03', '2026-11-11 01:41:46'),
(2, 'PX-20241020-001', 2, 2, '2024-10-20 11:00:00', 525000.00, 'Xuất VPP cho Shop Hải Đăng', 1, '2024-10-20 11:30:00', 1, '2026-11-10 21:41:03', '2026-11-11 01:41:46');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `quyen`
--

CREATE TABLE `quyen` (
  `MaQuyen` int(11) NOT NULL,
  `TenQuyen` varchar(100) NOT NULL,
  `MoTa` varchar(255) DEFAULT NULL,
  `NhomQuyen` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `quyen`
--

INSERT INTO `quyen` (`MaQuyen`, `TenQuyen`, `MoTa`, `NhomQuyen`) VALUES
(1, 'XEM_DASHBOARD', 'Xem tổng quan dashboard', 'Dashboard'),
(2, 'QUAN_LY_TAI_KHOAN', 'Quản lý tài khoản người dùng', 'Hệ thống'),
(3, 'QUAN_LY_NHAN_VIEN', 'Quản lý thông tin nhân viên', 'Hệ thống'),
(4, 'QUAN_LY_VAI_TRO', 'Quản lý vai trò và phân quyền', 'Hệ thống'),
(5, 'QUAN_LY_SAN_PHAM', 'Quản lý sản phẩm', 'Hàng hóa'),
(6, 'QUAN_LY_DANH_MUC', 'Quản lý danh mục sản phẩm', 'Hàng hóa'),
(7, 'QUAN_LY_DON_VI', 'Quản lý đơn vị tính', 'Hàng hóa'),
(8, 'QUAN_LY_NCC', 'Quản lý nhà cung cấp', 'Đối tác'),
(9, 'QUAN_LY_KHACH_HANG', 'Quản lý khách hàng', 'Đối tác'),
(10, 'TAO_PHIEU_NHAP', 'Tạo phiếu nhập kho', 'Nhập kho'),
(11, 'XAC_NHAN_PHIEU_NHAP', 'Xác nhận phiếu nhập kho', 'Nhập kho'),
(12, 'HUY_PHIEU_NHAP', 'Hủy phiếu nhập kho', 'Nhập kho'),
(13, 'XEM_PHIEU_NHAP', 'Xem danh sách phiếu nhập', 'Nhập kho'),
(14, 'TAO_PHIEU_XUAT', 'Tạo phiếu xuất kho', 'Xuất kho'),
(15, 'XAC_NHAN_PHIEU_XUAT', 'Xác nhận phiếu xuất kho', 'Xuất kho'),
(16, 'HUY_PHIEU_XUAT', 'Hủy phiếu xuất kho', 'Xuất kho'),
(17, 'XEM_PHIEU_XUAT', 'Xem danh sách phiếu xuất', 'Xuất kho'),
(18, 'XEM_TON_KHO', 'Xem tồn kho', 'Tồn kho'),
(19, 'BAO_CAO', 'Xem báo cáo thống kê', 'Báo cáo'),
(20, 'XUAT_EXCEL', 'Xuất dữ liệu ra Excel', 'Báo cáo'),
(21, 'XUAT_PDF', 'Xuất dữ liệu ra PDF', 'Báo cáo');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `sanpham`
--

CREATE TABLE `sanpham` (
  `MaSP` int(11) NOT NULL,
  `MaSPCode` varchar(50) NOT NULL COMMENT 'M├ú sß║ún phß║®m hiß╗ân thß╗ï (SP001...)',
  `TenSP` varchar(200) NOT NULL,
  `MaDanhMuc` int(11) DEFAULT NULL,
  `MaDVT` int(11) DEFAULT NULL,
  `GiaNhap` decimal(18,2) DEFAULT 0.00,
  `GiaBan` decimal(18,2) DEFAULT 0.00,
  `SoLuongTon` int(11) DEFAULT 0,
  `TonToiThieu` int(11) DEFAULT 10 COMMENT 'Mß╗®c tß╗ôn kho tß╗æi thiß╗âu',
  `HinhAnh` varchar(500) DEFAULT NULL COMMENT '─Éã░ß╗Øng dß║½n file ß║únh',
  `MoTa` text DEFAULT NULL,
  `TrangThai` tinyint(4) DEFAULT 1 COMMENT '1=─Éang KD, 0=Ngß╗½ng KD',
  `NgayTao` datetime DEFAULT current_timestamp(),
  `NgayCapNhat` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `sanpham`
--

INSERT INTO `sanpham` (`MaSP`, `MaSPCode`, `TenSP`, `MaDanhMuc`, `MaDVT`, `GiaNhap`, `GiaBan`, `SoLuongTon`, `TonToiThieu`, `HinhAnh`, `MoTa`, `TrangThai`, `NgayTao`, `NgayCapNhat`) VALUES
(1, 'SP001', 'Laptop Dell Inspiron 15', 1, 1, 15000000.00, 18000000.00, 25, 5, NULL, 'Laptop Dell Inspiron 15 inch, Core i5, 8GB RAM', 1, '2026-11-10 21:41:03', '2026-11-10 21:41:03'),
(2, 'SP002', 'Chuột không dây Logitech M331', 1, 1, 250000.00, 350000.00, 100, 20, NULL, 'Chuột không dây Logitech M331 Silent', 1, '2026-11-10 21:41:03', '2026-11-11 01:41:46'),
(3, 'SP003', 'Bàn phím cơ Razer BlackWidow', 1, 1, 1500000.00, 2000000.00, 30, 10, NULL, 'Bàn phím cơ gaming Razer BlackWidow', 1, '2026-11-10 21:41:03', '2026-11-11 01:41:46'),
(4, 'SP004', 'Giấy A4 Double A', 2, 3, 55000.00, 75000.00, 200, 50, NULL, 'Giấy A4 80gsm 500 tờ', 1, '2026-11-10 21:41:03', '2026-11-11 01:41:46'),
(5, 'SP005', 'Bút bi Thiên Long TL-027', 2, 3, 30000.00, 45000.00, 150, 30, NULL, 'Hộp 20 bút bi Thiên Long', 1, '2026-11-10 21:41:03', '2026-11-11 01:41:46'),
(6, 'SP006', 'Nước suối Aquafina 500ml', 3, 4, 60000.00, 84000.00, 500, 100, NULL, 'Thùng 24 chai nước suối 500ml', 1, '2026-11-10 21:41:03', '2026-11-11 01:41:46'),
(7, 'SP007', 'Mì Hảo Hảo tôm chua cay', 3, 4, 70000.00, 95000.00, 300, 80, NULL, 'Thùng 30 gói mì Hảo Hảo', 1, '2026-11-10 21:41:03', '2026-11-11 01:41:46'),
(8, 'SP008', 'Nồi cơm điện Sunhouse 1.8L', 4, 1, 450000.00, 650000.00, 15, 5, NULL, 'Nồi cơm điện Sunhouse SHD8601 1.8L', 1, '2026-11-10 21:41:03', '2026-11-11 01:41:46'),
(9, 'SP009', 'Áo thun nam basic', 5, 1, 80000.00, 150000.00, 200, 30, NULL, 'Áo thun nam cotton basic nhiều màu', 1, '2026-11-10 21:41:03', '2026-11-11 01:41:46'),
(10, 'SP010', 'Cáp sạc USB-C 1m', 6, 1, 25000.00, 50000.00, 500, 50, NULL, 'Cáp sạc nhanh USB-C dài 1 mét', 1, '2026-11-10 21:41:03', '2026-11-11 01:41:46'),
(11, 'SP011', 'Tai nghe Bluetooth Sony WH-1000XM5', 1, 1, 7000000.00, 8500000.00, 10, 3, NULL, 'Tai nghe chống ồn Sony WH-1000XM5', 1, '2026-11-10 21:41:03', '2026-11-11 01:41:46'),
(12, 'SP012', 'Ổ cứng SSD Samsung 500GB', 1, 1, 1200000.00, 1600000.00, 40, 10, NULL, 'SSD Samsung 870 EVO 500GB SATA III', 1, '2026-11-10 21:41:03', '2026-11-11 01:41:46'),
(13, 'SP013', 'Kẹp giấy 32mm', 2, 3, 8000.00, 12000.00, 300, 50, NULL, 'Hộp 100 kẹp giấy 32mm', 1, '2026-11-10 21:41:03', '2026-11-11 01:41:46'),
(14, 'SP014', 'Dầu ăn Tường An 1L', 3, 2, 35000.00, 48000.00, 120, 30, NULL, 'Dầu ăn Tường An chai 1 lít', 1, '2026-11-10 21:41:03', '2026-11-11 01:41:46'),
(15, 'SP015', 'Quạt điện Senko 40cm', 4, 1, 350000.00, 500000.00, 20, 5, NULL, 'Quạt đứng Senko 3 tốc độ 40cm', 1, '2026-11-10 21:41:03', '2026-11-11 01:41:46');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `taikhoan`
--

CREATE TABLE `taikhoan` (
  `MaTK` int(11) NOT NULL,
  `TenDangNhap` varchar(50) NOT NULL,
  `MatKhau` varchar(255) NOT NULL COMMENT 'BCrypt hash',
  `MaNV` int(11) DEFAULT NULL,
  `MaVaiTro` int(11) NOT NULL,
  `TrangThai` tinyint(4) DEFAULT 1 COMMENT '1=Hoß║ít ─æß╗Öng, 0=Kh├│a',
  `NgayTao` datetime DEFAULT current_timestamp(),
  `NgayCapNhat` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `taikhoan`
--

INSERT INTO `taikhoan` (`MaTK`, `TenDangNhap`, `MatKhau`, `MaNV`, `MaVaiTro`, `TrangThai`, `NgayTao`, `NgayCapNhat`) VALUES
(1, 'admin', '$2a$11$lwnTecyne.PqdvcbgzqpiOR9ZRH2Lc8jOgqhs9nM4vRwhTA8PfFy2', 1, 1, 1, '2026-11-10 21:41:03', '2026-11-11 00:08:49'),
(2, 'quanly', '$2a$11$lwnTecyne.PqdvcbgzqpiOR9ZRH2Lc8jOgqhs9nM4vRwhTA8PfFy2', 2, 2, 1, '2026-11-10 21:41:03', '2026-11-11 00:08:49'),
(3, 'nhanvien', '$2a$11$lwnTecyne.PqdvcbgzqpiOR9ZRH2Lc8jOgqhs9nM4vRwhTA8PfFy2', 3, 3, 1, '2026-11-10 21:41:03', '2026-11-11 00:08:49');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `vaitro`
--

CREATE TABLE `vaitro` (
  `MaVaiTro` int(11) NOT NULL,
  `TenVaiTro` varchar(50) NOT NULL,
  `MoTa` varchar(255) DEFAULT NULL,
  `NgayTao` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `vaitro`
--

INSERT INTO `vaitro` (`MaVaiTro`, `TenVaiTro`, `MoTa`, `NgayTao`) VALUES
(1, 'Admin', 'Quản trị hệ thống - Toàn quyền', '2026-11-10 21:41:03'),
(2, 'QuanLyKho', 'Quản lý kho - Quản lý nhập xuất, báo cáo', '2026-11-10 21:41:03'),
(3, 'NhanVienKho', 'Nhân viên kho - Nhập xuất hàng hóa', '2026-11-10 21:41:03');

--
-- Chỉ mục cho các bảng đã đổ
--

--
-- Chỉ mục cho bảng `chitietphieunhap`
--
ALTER TABLE `chitietphieunhap`
  ADD PRIMARY KEY (`MaCTPN`),
  ADD KEY `idx_ctpn_phieu` (`MaPhieuNhap`),
  ADD KEY `idx_ctpn_sp` (`MaSP`);

--
-- Chỉ mục cho bảng `chitietphieuxuat`
--
ALTER TABLE `chitietphieuxuat`
  ADD PRIMARY KEY (`MaCTPX`),
  ADD KEY `idx_ctpx_phieu` (`MaPhieuXuat`),
  ADD KEY `idx_ctpx_sp` (`MaSP`);

--
-- Chỉ mục cho bảng `danhmuc`
--
ALTER TABLE `danhmuc`
  ADD PRIMARY KEY (`MaDanhMuc`),
  ADD UNIQUE KEY `TenDanhMuc` (`TenDanhMuc`);

--
-- Chỉ mục cho bảng `donvitinh`
--
ALTER TABLE `donvitinh`
  ADD PRIMARY KEY (`MaDVT`),
  ADD UNIQUE KEY `TenDVT` (`TenDVT`);

--
-- Chỉ mục cho bảng `khachhang`
--
ALTER TABLE `khachhang`
  ADD PRIMARY KEY (`MaKH`);

--
-- Chỉ mục cho bảng `lichsutonkho`
--
ALTER TABLE `lichsutonkho`
  ADD PRIMARY KEY (`MaLichSu`),
  ADD KEY `MaPhieuNhap` (`MaPhieuNhap`),
  ADD KEY `MaPhieuXuat` (`MaPhieuXuat`),
  ADD KEY `MaTK` (`MaTK`),
  ADD KEY `idx_lstk_sp` (`MaSP`),
  ADD KEY `idx_lstk_ngay` (`NgayTao`),
  ADD KEY `idx_lstk_loai` (`LoaiGiaoDich`);

--
-- Chỉ mục cho bảng `nhacungcap`
--
ALTER TABLE `nhacungcap`
  ADD PRIMARY KEY (`MaNCC`);

--
-- Chỉ mục cho bảng `nhanvien`
--
ALTER TABLE `nhanvien`
  ADD PRIMARY KEY (`MaNV`);

--
-- Chỉ mục cho bảng `phanquyen`
--
ALTER TABLE `phanquyen`
  ADD PRIMARY KEY (`MaVaiTro`,`MaQuyen`),
  ADD KEY `MaQuyen` (`MaQuyen`);

--
-- Chỉ mục cho bảng `phieunhap`
--
ALTER TABLE `phieunhap`
  ADD PRIMARY KEY (`MaPhieuNhap`),
  ADD UNIQUE KEY `MaPhieuNhapCode` (`MaPhieuNhapCode`),
  ADD KEY `MaTK` (`MaTK`),
  ADD KEY `NguoiXacNhan` (`NguoiXacNhan`),
  ADD KEY `idx_pn_ngaynhap` (`NgayNhap`),
  ADD KEY `idx_pn_trangthai` (`TrangThai`),
  ADD KEY `idx_pn_ncc` (`MaNCC`);

--
-- Chỉ mục cho bảng `phieuxuat`
--
ALTER TABLE `phieuxuat`
  ADD PRIMARY KEY (`MaPhieuXuat`),
  ADD UNIQUE KEY `MaPhieuXuatCode` (`MaPhieuXuatCode`),
  ADD KEY `MaTK` (`MaTK`),
  ADD KEY `NguoiXacNhan` (`NguoiXacNhan`),
  ADD KEY `idx_px_ngayxuat` (`NgayXuat`),
  ADD KEY `idx_px_trangthai` (`TrangThai`),
  ADD KEY `idx_px_kh` (`MaKH`);

--
-- Chỉ mục cho bảng `quyen`
--
ALTER TABLE `quyen`
  ADD PRIMARY KEY (`MaQuyen`),
  ADD UNIQUE KEY `TenQuyen` (`TenQuyen`);

--
-- Chỉ mục cho bảng `sanpham`
--
ALTER TABLE `sanpham`
  ADD PRIMARY KEY (`MaSP`),
  ADD UNIQUE KEY `MaSPCode` (`MaSPCode`),
  ADD KEY `MaDVT` (`MaDVT`),
  ADD KEY `idx_sp_tensp` (`TenSP`),
  ADD KEY `idx_sp_danhmuc` (`MaDanhMuc`),
  ADD KEY `idx_sp_trangthai` (`TrangThai`);

--
-- Chỉ mục cho bảng `taikhoan`
--
ALTER TABLE `taikhoan`
  ADD PRIMARY KEY (`MaTK`),
  ADD UNIQUE KEY `TenDangNhap` (`TenDangNhap`),
  ADD KEY `MaNV` (`MaNV`),
  ADD KEY `MaVaiTro` (`MaVaiTro`);

--
-- Chỉ mục cho bảng `vaitro`
--
ALTER TABLE `vaitro`
  ADD PRIMARY KEY (`MaVaiTro`),
  ADD UNIQUE KEY `TenVaiTro` (`TenVaiTro`);

--
-- AUTO_INCREMENT cho các bảng đã đổ
--

--
-- AUTO_INCREMENT cho bảng `chitietphieunhap`
--
ALTER TABLE `chitietphieunhap`
  MODIFY `MaCTPN` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT cho bảng `chitietphieuxuat`
--
ALTER TABLE `chitietphieuxuat`
  MODIFY `MaCTPX` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT cho bảng `danhmuc`
--
ALTER TABLE `danhmuc`
  MODIFY `MaDanhMuc` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT cho bảng `donvitinh`
--
ALTER TABLE `donvitinh`
  MODIFY `MaDVT` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT cho bảng `khachhang`
--
ALTER TABLE `khachhang`
  MODIFY `MaKH` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT cho bảng `lichsutonkho`
--
ALTER TABLE `lichsutonkho`
  MODIFY `MaLichSu` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=30;

--
-- AUTO_INCREMENT cho bảng `nhacungcap`
--
ALTER TABLE `nhacungcap`
  MODIFY `MaNCC` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT cho bảng `nhanvien`
--
ALTER TABLE `nhanvien`
  MODIFY `MaNV` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT cho bảng `phieunhap`
--
ALTER TABLE `phieunhap`
  MODIFY `MaPhieuNhap` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT cho bảng `phieuxuat`
--
ALTER TABLE `phieuxuat`
  MODIFY `MaPhieuXuat` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT cho bảng `quyen`
--
ALTER TABLE `quyen`
  MODIFY `MaQuyen` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- AUTO_INCREMENT cho bảng `sanpham`
--
ALTER TABLE `sanpham`
  MODIFY `MaSP` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT cho bảng `taikhoan`
--
ALTER TABLE `taikhoan`
  MODIFY `MaTK` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT cho bảng `vaitro`
--
ALTER TABLE `vaitro`
  MODIFY `MaVaiTro` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Các ràng buộc cho các bảng đã đổ
--

--
-- Các ràng buộc cho bảng `chitietphieunhap`
--
ALTER TABLE `chitietphieunhap`
  ADD CONSTRAINT `chitietphieunhap_ibfk_1` FOREIGN KEY (`MaPhieuNhap`) REFERENCES `phieunhap` (`MaPhieuNhap`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `chitietphieunhap_ibfk_2` FOREIGN KEY (`MaSP`) REFERENCES `sanpham` (`MaSP`) ON UPDATE CASCADE;

--
-- Các ràng buộc cho bảng `chitietphieuxuat`
--
ALTER TABLE `chitietphieuxuat`
  ADD CONSTRAINT `chitietphieuxuat_ibfk_1` FOREIGN KEY (`MaPhieuXuat`) REFERENCES `phieuxuat` (`MaPhieuXuat`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `chitietphieuxuat_ibfk_2` FOREIGN KEY (`MaSP`) REFERENCES `sanpham` (`MaSP`) ON UPDATE CASCADE;

--
-- Các ràng buộc cho bảng `lichsutonkho`
--
ALTER TABLE `lichsutonkho`
  ADD CONSTRAINT `lichsutonkho_ibfk_1` FOREIGN KEY (`MaSP`) REFERENCES `sanpham` (`MaSP`) ON UPDATE CASCADE,
  ADD CONSTRAINT `lichsutonkho_ibfk_2` FOREIGN KEY (`MaPhieuNhap`) REFERENCES `phieunhap` (`MaPhieuNhap`) ON UPDATE CASCADE,
  ADD CONSTRAINT `lichsutonkho_ibfk_3` FOREIGN KEY (`MaPhieuXuat`) REFERENCES `phieuxuat` (`MaPhieuXuat`) ON UPDATE CASCADE,
  ADD CONSTRAINT `lichsutonkho_ibfk_4` FOREIGN KEY (`MaTK`) REFERENCES `taikhoan` (`MaTK`) ON UPDATE CASCADE;

--
-- Các ràng buộc cho bảng `phanquyen`
--
ALTER TABLE `phanquyen`
  ADD CONSTRAINT `phanquyen_ibfk_1` FOREIGN KEY (`MaVaiTro`) REFERENCES `vaitro` (`MaVaiTro`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `phanquyen_ibfk_2` FOREIGN KEY (`MaQuyen`) REFERENCES `quyen` (`MaQuyen`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Các ràng buộc cho bảng `phieunhap`
--
ALTER TABLE `phieunhap`
  ADD CONSTRAINT `phieunhap_ibfk_1` FOREIGN KEY (`MaNCC`) REFERENCES `nhacungcap` (`MaNCC`) ON UPDATE CASCADE,
  ADD CONSTRAINT `phieunhap_ibfk_2` FOREIGN KEY (`MaTK`) REFERENCES `taikhoan` (`MaTK`) ON UPDATE CASCADE,
  ADD CONSTRAINT `phieunhap_ibfk_3` FOREIGN KEY (`NguoiXacNhan`) REFERENCES `taikhoan` (`MaTK`) ON UPDATE CASCADE;

--
-- Các ràng buộc cho bảng `phieuxuat`
--
ALTER TABLE `phieuxuat`
  ADD CONSTRAINT `phieuxuat_ibfk_1` FOREIGN KEY (`MaKH`) REFERENCES `khachhang` (`MaKH`) ON UPDATE CASCADE,
  ADD CONSTRAINT `phieuxuat_ibfk_2` FOREIGN KEY (`MaTK`) REFERENCES `taikhoan` (`MaTK`) ON UPDATE CASCADE,
  ADD CONSTRAINT `phieuxuat_ibfk_3` FOREIGN KEY (`NguoiXacNhan`) REFERENCES `taikhoan` (`MaTK`) ON UPDATE CASCADE;

--
-- Các ràng buộc cho bảng `sanpham`
--
ALTER TABLE `sanpham`
  ADD CONSTRAINT `sanpham_ibfk_1` FOREIGN KEY (`MaDanhMuc`) REFERENCES `danhmuc` (`MaDanhMuc`) ON UPDATE CASCADE,
  ADD CONSTRAINT `sanpham_ibfk_2` FOREIGN KEY (`MaDVT`) REFERENCES `donvitinh` (`MaDVT`) ON UPDATE CASCADE;

--
-- Các ràng buộc cho bảng `taikhoan`
--
ALTER TABLE `taikhoan`
  ADD CONSTRAINT `taikhoan_ibfk_1` FOREIGN KEY (`MaNV`) REFERENCES `nhanvien` (`MaNV`) ON UPDATE CASCADE,
  ADD CONSTRAINT `taikhoan_ibfk_2` FOREIGN KEY (`MaVaiTro`) REFERENCES `vaitro` (`MaVaiTro`) ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
