using System;
using System.Data;
using MySqlConnector;

namespace baitaplon.DAL
{
    /// <summary>
    /// Lớp tiện ích truy cập cơ sở dữ liệu MySQL
    /// Cung cấp các phương thức chung cho các lớp DAL khác
    /// </summary>
    public static class DatabaseHelper
    {
        /// <summary>
        /// Tạo và trả về kết nối MySQL mới
        /// </summary>
        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(DatabaseConfig.ConnectionString);
        }

        /// <summary>
        /// Thực thi câu lệnh SQL không trả về kết quả (INSERT, UPDATE, DELETE)
        /// </summary>
        /// <param name="query">Câu truy vấn SQL</param>
        /// <param name="parameters">Tham số truy vấn</param>
        /// <returns>Số dòng bị ảnh hưởng</returns>
        public static int ExecuteNonQuery(string query, params MySqlParameter[] parameters)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Thực thi câu lệnh SQL trả về giá trị đơn (COUNT, MAX, LAST_INSERT_ID...)
        /// </summary>
        /// <param name="query">Câu truy vấn SQL</param>
        /// <param name="parameters">Tham số truy vấn</param>
        /// <returns>Giá trị kết quả</returns>
        public static object ExecuteScalar(string query, params MySqlParameter[] parameters)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    return cmd.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// Thực thi câu lệnh SQL trả về DataTable
        /// </summary>
        /// <param name="query">Câu truy vấn SQL</param>
        /// <param name="parameters">Tham số truy vấn</param>
        /// <returns>DataTable chứa kết quả</returns>
        public static DataTable ExecuteReader(string query, params MySqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            return dt;
        }

        /// <summary>
        /// Kiểm tra kết nối đến cơ sở dữ liệu
        /// </summary>
        /// <returns>true nếu kết nối thành công</returns>
        public static bool TestConnection()
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
