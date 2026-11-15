using System;
using System.Collections.Generic;
using System.Data;
using MySqlConnector;
using baitaplon.Models;

namespace baitaplon.DAL
{
    /// <summary>
    /// Lớp truy cập dữ liệu cho Vai trò
    /// </summary>
    public class VaiTroDAL
    {
        /// <summary>
        /// Lấy tất cả vai trò
        /// </summary>
        public List<VaiTro> GetAll()
        {
            try
            {
                string query = @"SELECT MaVaiTro, TenVaiTro, MoTa, NgayTao FROM VaiTro ORDER BY MaVaiTro";
                DataTable dt = DatabaseHelper.ExecuteReader(query);
                List<VaiTro> list = new List<VaiTro>();
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(new VaiTro
                    {
                        MaVaiTro = Convert.ToInt32(row["MaVaiTro"]),
                        TenVaiTro = row["TenVaiTro"].ToString(),
                        MoTa = row["MoTa"] == DBNull.Value ? "" : row["MoTa"].ToString(),
                        NgayTao = Convert.ToDateTime(row["NgayTao"])
                    });
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách vai trò: " + ex.Message, ex);
            }
        }
    }
}
