# Quản Lý Kho Hàng - Warehouse Management System

Ứng dụng WinForms (.NET Framework 4.7.2) quản lý kho hàng với MySQL database.

## 📋 Tính năng chính

- **Đăng nhập & Phân quyền**: Hệ thống tài khoản, vai trò, quyền hạn (Admin, Quản lý kho, Nhân viên kho)
- **Quản lý Danh mục**: Sản phẩm, Danh mục, Đơn vị tính
- **Quản lý Đối tác**: Nhà cung cấp, Khách hàng
- **Nhập/Xuất kho**: Tạo phiếu nháp, xác nhận (cập nhật tồn kho transactional), hủy phiếu
- **Tồn kho & Lịch sử**: Xem tồn kho thực tế, lịch sử nhập/xuất chi tiết
- **Báo cáo & Thống kê**: Dashboard KPI, biểu đồ nhập/xuất theo tháng, xuất Excel/PDF
- **Bảo mật**: Mật khẩu hash BCrypt, connection string riêng biệt

## 🛠️ Yêu cầu hệ thống

| Thành phần | Phiên bản |
|-----------|-----------|
| Windows | 10/11 |
| .NET Framework | 4.7.2+ |
| Visual Studio | 2019/2022 (để mở Designer) |
| MySQL | 8.0 / MariaDB (XAMPP) |

## 🚀 Hướng dẫn cài đặt

### 1. Cài đặt MySQL (XAMPP)
```bash
# Tải XAMPP: https://www.apachefriends.org/download.html
# Cài đặt mặc định, MySQL chạy ở port 3306
# User: root, Password: (rỗng)
```

### 2. Tạo database
```sql
-- Mở MySQL command line hoặc phpMyAdmin
-- Chạy file: SQL/create_database.sql
-- Tự động tạo database `quanlykhohang` và dữ liệu mẫu
```

### 3. Mở project
```bash
# Mở baitaplon.sln bằng Visual Studio 2019/2022
# Build Solution (Ctrl+Shift+B)
# Chạy (F5)
```

### 4. Cấu hình kết nối (nếu khác mặc định)
Sửa file `baitaplon/DatabaseConfig.cs`:
```csharp
public const string Server = "localhost";
public const int Port = 3306;
public const string Database = "quanlykhohang";
public const string User = "root";
public const string Password = "";
```

## 🔑 Tài khoản mặc định

| Username | Password | Vai trò |
|----------|----------|---------|
| admin | 123456 | Quản trị hệ thống (Full quyền) |
| quanly | 123456 | Quản lý kho |
| nhanvien | 123456 | Nhân viên kho |

## 📁 Cấu trúc project

```
baitaplon/
├── DatabaseConfig.cs          # Cấu hình DB (đã tách riêng)
├── Models/                    # Entity classes
├── DAL/                       # Data Access Layer
├── BUS/                       # Business Logic Layer
├── GUI/                       # Forms (WinForms)
│   ├── FormDangNhap.cs
│   ├── FormMain.cs
│   ├── FormDashboard.cs
│   ├── FormSanPham.cs
│   ├── FormDanhMuc.cs
│   ├── FormDonViTinh.cs
│   ├── FormNhaCungCap.cs
│   ├── FormKhachHang.cs
│   ├── FormNhapKho.cs
│   ├── FormXuatKho.cs
│   ├── FormTonKho.cs
│   ├── FormBaoCao.cs
│   ├── FormNhanVien.cs
│   └── FormTaiKhoanManager.cs
├── Helpers/                   # Tiện ích chung
└── SQL/
    └── create_database.sql    # Schema + dữ liệu mẫu
```

## ⚡ Các lưu ý quan trọng

1. **Transaction**: Xác nhận/Hủy phiếu nhập/xuất dùng MySQL Transaction (ACID)
2. **Kiểm tra tồn kho**: Không cho xuất vượt quá tồn kho hiện tại (row-level lock trong transaction)
3. **Mật khẩu**: Hash BCrypt (cost 11), không lưu plain text
4. **Config DB**: Đặt riêng file `DatabaseConfig.cs`, không hardcode trong code
5. **Visual Studio Designer**: Tất cả Forms đều có file `.Designer.cs` để mở được Designer bình thường

## 📦 Thư viện NuGet sử dụng

- `MySqlConnector` 2.3.7
- `BCrypt.Net-Next` 4.0.3
- `ClosedXML` 0.102.3 (Xuất Excel)
- `iTextSharp` 5.5.13.4 (Xuất PDF)
- `System.IO.Packaging` 8.0.0
- `DocumentFormat.OpenXml` 3.0.2

## 🐛 Xử lý sự cố thường gặp

| Lỗi | Giải pháp |
|-----|-----------|
| "Không thể kết nối database" | Kiểm tra MySQL service đang chạy, port 3306, user/password trong DatabaseConfig.cs |
| Build error GenerateResource | Build với: `dotnet build -p:GenerateResourceMSBuildArchitecture=x64 -p:GenerateResourceMSBuildRuntime=CurrentRuntime` |
| Designer không mở | Đảm bảo Visual Studio cài workload ".NET desktop development" |
| Lỗi BCrypt verify | Kiểm tra mật khẩu trong DB đúng hash BCrypt (file SQL đã cung cấp hash cho "123456") |

## 📄 Giấy phép

Dự án bài tập lớn - Môn Lập trình .NET

---

**Lưu ý**: Mật khẩu mặc định là `123456`. Nên đổi ngay sau khi đăng nhập lần đầu (tại Form TaiKhoanManager → Đặt lại mật khẩu).