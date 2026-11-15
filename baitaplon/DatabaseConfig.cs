using System;

namespace baitaplon
{
    /// <summary>
    /// Cấu hình kết nối MySQL Database
    /// Server: localhost (XAMPP)
    /// User: root
    /// Password: (rỗng)
    /// Database: quanlykhohang
    /// 
    /// Để thay đổi thông tin kết nối, chỉnh sửa các hằng số bên dưới.
    /// </summary>
    public static class DatabaseConfig
    {
        // ============================================================
        // THÔNG TIN KẾT NỐI MYSQL - CHỈNH SỬA TẠI ĐÂY
        // ============================================================
        public const string Server = "localhost";
        public const int Port = 3306;
        public const string Database = "quanlykhohang";
        public const string User = "root";
        public const string Password = "";
        // ============================================================

        /// <summary>
        /// Chuỗi kết nối MySQL hoàn chỉnh
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                return string.Format(
                    "Server={0};Port={1};Database={2};User={3};Password={4};CharSet=utf8mb4;SslMode=None;AllowPublicKeyRetrieval=true;ConnectionTimeout=30;DefaultCommandTimeout=60;",
                    Server, Port, Database, User, Password);
            }
        }
    }
}

