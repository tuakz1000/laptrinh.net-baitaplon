using System;
using System.Collections.Generic;
using baitaplon.DAL;
using baitaplon.Models;

namespace baitaplon.BUS
{
    /// <summary>
    /// Lớp xử lý nghiệp vụ cho Tài khoản
    /// Quản lý đăng nhập, phân quyền, và các thao tác CRUD tài khoản
    /// </summary>
    public class TaiKhoanBUS
    {
        private readonly TaiKhoanDAL _taiKhoanDAL;

        /// <summary>
        /// Tài khoản đang đăng nhập hiện tại
        /// </summary>
        public static TaiKhoan CurrentUser { get; set; }

        /// <summary>
        /// Danh sách quyền của tài khoản đang đăng nhập
        /// </summary>
        public static List<string> CurrentPermissions { get; set; }

        public TaiKhoanBUS()
        {
            _taiKhoanDAL = new TaiKhoanDAL();
        }

        /// <summary>
        /// Kiểm tra quyền của tài khoản đang đăng nhập
        /// </summary>
        /// <param name="tenQuyen">Tên quyền cần kiểm tra</param>
        /// <returns>true nếu có quyền</returns>
        public static bool HasPermission(string tenQuyen)
        {
            if (CurrentPermissions == null || string.IsNullOrEmpty(tenQuyen))
                return false;

            return CurrentPermissions.Contains(tenQuyen);
        }

        /// <summary>
        /// Đăng nhập hệ thống
        /// </summary>
        /// <param name="tenDangNhap">Tên đăng nhập</param>
        /// <param name="matKhau">Mật khẩu</param>
        /// <returns>Đối tượng TaiKhoan nếu đăng nhập thành công, null nếu thất bại</returns>
        public TaiKhoan DangNhap(string tenDangNhap, string matKhau)
        {
            if (string.IsNullOrWhiteSpace(tenDangNhap))
                throw new Exception("Vui lòng nhập tên đăng nhập.");

            if (string.IsNullOrWhiteSpace(matKhau))
                throw new Exception("Vui lòng nhập mật khẩu.");

            TaiKhoan tk = _taiKhoanDAL.GetByTenDangNhap(tenDangNhap);

            if (tk == null)
                return null;

            if (tk.TrangThai == 0)
                throw new Exception("Tài khoản đã bị khóa. Vui lòng liên hệ quản trị viên.");

            if (!BCrypt.Net.BCrypt.Verify(matKhau, tk.MatKhau))
                return null;

            // Đăng nhập thành công - lưu thông tin người dùng hiện tại
            CurrentUser = tk;
            CurrentPermissions = GetQuyenByVaiTro(tk.MaVaiTro);

            return tk;
        }

        /// <summary>
        /// Lấy danh sách tất cả tài khoản
        /// </summary>
        public List<TaiKhoan> GetAll()
        {
            return _taiKhoanDAL.GetAll();
        }

        /// <summary>
        /// Lấy tài khoản theo mã
        /// </summary>
        /// <param name="maTK">Mã tài khoản</param>
        public TaiKhoan GetById(int maTK)
        {
            return _taiKhoanDAL.GetById(maTK);
        }

        /// <summary>
        /// Thêm tài khoản mới
        /// </summary>
        /// <param name="tk">Đối tượng tài khoản</param>
        /// <param name="matKhauGoc">Mật khẩu gốc (chưa hash)</param>
        public void ThemTaiKhoan(TaiKhoan tk, string matKhauGoc)
        {
            // Validate
            if (string.IsNullOrWhiteSpace(tk.TenDangNhap))
                throw new Exception("Tên đăng nhập không được để trống.");

            if (tk.TenDangNhap.Length < 3)
                throw new Exception("Tên đăng nhập phải có ít nhất 3 ký tự.");

            if (string.IsNullOrWhiteSpace(matKhauGoc))
                throw new Exception("Mật khẩu không được để trống.");

            if (matKhauGoc.Length < 6)
                throw new Exception("Mật khẩu phải có ít nhất 6 ký tự.");

            // Kiểm tra tên đăng nhập trùng
            TaiKhoan existingTK = _taiKhoanDAL.GetByTenDangNhap(tk.TenDangNhap);
            if (existingTK != null)
                throw new Exception("Tên đăng nhập đã tồn tại trong hệ thống.");

            // Hash mật khẩu
            tk.MatKhau = BCrypt.Net.BCrypt.HashPassword(matKhauGoc);

            _taiKhoanDAL.Insert(tk);
        }

        /// <summary>
        /// Cập nhật thông tin tài khoản
        /// </summary>
        /// <param name="tk">Đối tượng tài khoản cần cập nhật</param>
        public void CapNhatTaiKhoan(TaiKhoan tk)
        {
            if (tk.MaTK <= 0)
                throw new Exception("Mã tài khoản không hợp lệ.");

            TaiKhoan existing = _taiKhoanDAL.GetById(tk.MaTK);
            if (existing == null)
                throw new Exception("Không tìm thấy tài khoản cần cập nhật.");

            _taiKhoanDAL.Update(tk);
        }

        /// <summary>
        /// Đổi mật khẩu (người dùng tự đổi)
        /// </summary>
        /// <param name="maTK">Mã tài khoản</param>
        /// <param name="matKhauCu">Mật khẩu cũ</param>
        /// <param name="matKhauMoi">Mật khẩu mới</param>
        public void DoiMatKhau(int maTK, string matKhauCu, string matKhauMoi)
        {
            if (string.IsNullOrWhiteSpace(matKhauCu))
                throw new Exception("Vui lòng nhập mật khẩu cũ.");

            if (string.IsNullOrWhiteSpace(matKhauMoi))
                throw new Exception("Vui lòng nhập mật khẩu mới.");

            if (matKhauMoi.Length < 6)
                throw new Exception("Mật khẩu mới phải có ít nhất 6 ký tự.");

            TaiKhoan tk = _taiKhoanDAL.GetById(maTK);
            if (tk == null)
                throw new Exception("Không tìm thấy tài khoản.");

            // Xác minh mật khẩu cũ
            if (!BCrypt.Net.BCrypt.Verify(matKhauCu, tk.MatKhau))
                throw new Exception("Mật khẩu cũ không chính xác.");

            // Hash và cập nhật mật khẩu mới
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(matKhauMoi);
            _taiKhoanDAL.DoiMatKhau(maTK, hashedPassword);
        }

        /// <summary>
        /// Đặt lại mật khẩu (dành cho admin)
        /// </summary>
        /// <param name="maTK">Mã tài khoản</param>
        /// <param name="matKhauMoi">Mật khẩu mới</param>
        public void ResetMatKhau(int maTK, string matKhauMoi)
        {
            if (string.IsNullOrWhiteSpace(matKhauMoi))
                throw new Exception("Mật khẩu mới không được để trống.");

            if (matKhauMoi.Length < 6)
                throw new Exception("Mật khẩu mới phải có ít nhất 6 ký tự.");

            TaiKhoan tk = _taiKhoanDAL.GetById(maTK);
            if (tk == null)
                throw new Exception("Không tìm thấy tài khoản.");

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(matKhauMoi);
            _taiKhoanDAL.DoiMatKhau(maTK, hashedPassword);
        }

        /// <summary>
        /// Khóa tài khoản
        /// </summary>
        /// <param name="maTK">Mã tài khoản</param>
        public void KhoaTaiKhoan(int maTK)
        {
            TaiKhoan tk = _taiKhoanDAL.GetById(maTK);
            if (tk == null)
                throw new Exception("Không tìm thấy tài khoản.");

            if (tk.TrangThai == 0)
                throw new Exception("Tài khoản này đã bị khóa.");

            _taiKhoanDAL.KhoaTaiKhoan(maTK);
        }

        /// <summary>
        /// Mở khóa tài khoản
        /// </summary>
        /// <param name="maTK">Mã tài khoản</param>
        public void MoKhoaTaiKhoan(int maTK)
        {
            TaiKhoan tk = _taiKhoanDAL.GetById(maTK);
            if (tk == null)
                throw new Exception("Không tìm thấy tài khoản.");

            if (tk.TrangThai == 1)
                throw new Exception("Tài khoản này đang hoạt động.");

            _taiKhoanDAL.MoKhoaTaiKhoan(maTK);
        }

        /// <summary>
        /// Kiểm tra quyền của vai trò
        /// </summary>
        /// <param name="maVaiTro">Mã vai trò</param>
        /// <param name="tenQuyen">Tên quyền cần kiểm tra</param>
        /// <returns>true nếu vai trò có quyền</returns>
        public bool KiemTraQuyen(int maVaiTro, string tenQuyen)
        {
            return _taiKhoanDAL.KiemTraQuyen(maVaiTro, tenQuyen);
        }

        /// <summary>
        /// Lấy danh sách quyền của vai trò
        /// </summary>
        /// <param name="maVaiTro">Mã vai trò</param>
        /// <returns>Danh sách tên quyền</returns>
        public List<string> GetQuyenByVaiTro(int maVaiTro)
        {
            return _taiKhoanDAL.GetQuyenByVaiTro(maVaiTro);
        }

        /// <summary>
        /// Đăng xuất - xóa thông tin người dùng hiện tại
        /// </summary>
        public static void DangXuat()
        {
            CurrentUser = null;
            CurrentPermissions = null;
        }
    }
}
