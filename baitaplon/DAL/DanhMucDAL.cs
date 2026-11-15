using System;
using System.Collections.Generic;
using System.Data;
using MySqlConnector;
using baitaplon.Models;

namespace baitaplon.DAL
{
    /// <summary>
    /// Lớp truy cập dữ liệu cho Danh mục sản phẩm
    /// </summary>
    public class DanhMucDAL
    {
        /// <summary>
        /// Lấy tất cả danh mục
        /// </summary>
        public List<DanhMuc> GetAll()
        {
            try
            {
                string query = @"SELECT * FROM DanhMuc ORDER BY MaDanhMuc DESC";

                DataTable dt = DatabaseHelper.ExecuteReader(query);
                List<DanhMuc> list = new List<DanhMuc>();
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(MapDanhMuc(row));
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách danh mục: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Lấy tất cả danh mục đang hoạt động (TrangThai = 1)
        /// </summary>
        public List<DanhMuc> GetAllActive()
        {
            try
            {
                string query = @"SELECT * FROM DanhMuc WHERE TrangThai = 1 ORDER BY TenDanhMuc";

                DataTable dt = DatabaseHelper.ExecuteReader(query);
                List<DanhMuc> list = new List<DanhMuc>();
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(MapDanhMuc(row));
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách danh mục hoạt động: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Lấy danh mục theo mã
        /// </summary>
        public DanhMuc GetById(int maDanhMuc)
        {
            try
            {
                string query = @"SELECT * FROM DanhMuc WHERE MaDanhMuc = @MaDanhMuc";

                DataTable dt = DatabaseHelper.ExecuteReader(query,
                    new MySqlParameter("@MaDanhMuc", maDanhMuc));

                if (dt.Rows.Count > 0)
                {
                    return MapDanhMuc(dt.Rows[0]);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh mục: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Thêm danh mục mới
        /// </summary>
        public int Insert(DanhMuc dm)
        {
            try
            {
                string query = @"INSERT INTO DanhMuc (TenDanhMuc, MoTa, TrangThai, NgayTao)
                                 VALUES (@TenDanhMuc, @MoTa, @TrangThai, NOW());
                                 SELECT LAST_INSERT_ID();";

                object result = DatabaseHelper.ExecuteScalar(query,
                    new MySqlParameter("@TenDanhMuc", dm.TenDanhMuc),
                    new MySqlParameter("@MoTa", (object)dm.MoTa ?? DBNull.Value),
                    new MySqlParameter("@TrangThai", dm.TrangThai));

                return Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm danh mục: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Cập nhật danh mục
        /// </summary>
        public bool Update(DanhMuc dm)
        {
            try
            {
                string query = @"UPDATE DanhMuc SET 
                                    TenDanhMuc = @TenDanhMuc,
                                    MoTa = @MoTa,
                                    TrangThai = @TrangThai
                                 WHERE MaDanhMuc = @MaDanhMuc";

                int rows = DatabaseHelper.ExecuteNonQuery(query,
                    new MySqlParameter("@TenDanhMuc", dm.TenDanhMuc),
                    new MySqlParameter("@MoTa", (object)dm.MoTa ?? DBNull.Value),
                    new MySqlParameter("@TrangThai", dm.TrangThai),
                    new MySqlParameter("@MaDanhMuc", dm.MaDanhMuc));

                return rows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật danh mục: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Cập nhật trạng thái danh mục
        /// </summary>
        public bool UpdateTrangThai(int maDanhMuc, int trangThai)
        {
            try
            {
                string query = @"UPDATE DanhMuc SET TrangThai = @TrangThai
                                 WHERE MaDanhMuc = @MaDanhMuc";

                int rows = DatabaseHelper.ExecuteNonQuery(query,
                    new MySqlParameter("@TrangThai", trangThai),
                    new MySqlParameter("@MaDanhMuc", maDanhMuc));

                return rows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật trạng thái danh mục: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Kiểm tra trùng tên danh mục
        /// </summary>
        public bool KiemTraTrung(string tenDanhMuc, int maDanhMuc)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM DanhMuc WHERE TenDanhMuc = @Ten AND MaDanhMuc <> @Ma";
                object result = DatabaseHelper.ExecuteScalar(query,
                    new MySqlParameter("@Ten", tenDanhMuc),
                    new MySqlParameter("@Ma", maDanhMuc));
                return Convert.ToInt32(result) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi kiểm tra trùng tên: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Chuyển DataRow thành đối tượng DanhMuc
        /// </summary>
        private DanhMuc MapDanhMuc(DataRow row)
        {
            DanhMuc dm = new DanhMuc();
            dm.MaDanhMuc = Convert.ToInt32(row["MaDanhMuc"]);
            dm.TenDanhMuc = row["TenDanhMuc"].ToString();
            dm.MoTa = row["MoTa"] != DBNull.Value ? row["MoTa"].ToString() : null;
            dm.TrangThai = Convert.ToInt32(row["TrangThai"]);
            dm.NgayTao = Convert.ToDateTime(row["NgayTao"]);
            return dm;
        }
    }
}
