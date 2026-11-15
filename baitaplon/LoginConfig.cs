using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace baitaplon
{
    /// <summary>
    /// Cấu hình lưu thông tin đăng nhập (Remember me)
    /// Mật khẩu được mã hóa bằng DPAPI (Windows) nên chỉ giải mã được trên máy này.
    /// </summary>
    public static class LoginConfig
    {
        // File lưu thông tin đăng nhập trong thư mục AppData của user
        private static readonly string ConfigPath =
            Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "baitaplon",
                "login.dat");

        /// <summary>
        /// Lưu thông tin đăng nhập (mã hóa mật khẩu bằng DPAPI)
        /// </summary>
        public static void SaveLogin(string username, string password)
        {
            try
            {
                string dir = Path.GetDirectoryName(ConfigPath);
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                byte[] plain = Encoding.UTF8.GetBytes(username + "|" + password);
                byte[] encrypted = ProtectedData.Protect(plain, null, DataProtectionScope.CurrentUser);
                File.WriteAllBytes(ConfigPath, encrypted);
            }
            catch
            {
                // Không lưu được thì bỏ qua (không ảnh hưởng đăng nhập)
            }
        }

        /// <summary>
        /// Đọc thông tin đăng nhập đã lưu. Trả về false nếu không có hoặc không giải mã được.
        /// </summary>
        public static bool LoadLogin(out string username, out string password)
        {
            username = "";
            password = "";
            try
            {
                if (!File.Exists(ConfigPath))
                    return false;

                byte[] encrypted = File.ReadAllBytes(ConfigPath);
                byte[] plain = ProtectedData.Unprotect(encrypted, null, DataProtectionScope.CurrentUser);
                string text = Encoding.UTF8.GetString(plain);
                int sep = text.IndexOf('|');
                if (sep <= 0)
                    return false;

                username = text.Substring(0, sep);
                password = text.Substring(sep + 1);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Xóa thông tin đăng nhập đã lưu
        /// </summary>
        public static void ClearLogin()
        {
            try
            {
                if (File.Exists(ConfigPath))
                    File.Delete(ConfigPath);
            }
            catch
            {
                // Bỏ qua
            }
        }
    }
}
