using System;
using System.Collections.Generic;
using System.Data;
using MySqlConnector;
using baitaplon.Models;

namespace baitaplon.DAL
{
    /// <summary>
    /// Lớp truy cập dữ liệu cho Đơn vị tính
    /// </summary>
    public class DonViTinhDAL
    {
        /// <summary>
        /// Lấy tất cả đơn vị tính
        /// </summary>
        public List<DonViTinh> GetAll()
        {
            try
            {
                string query = @"SELECT * FROM DonViTinh ORDER BY MaDVT DESC";

                DataTable dt = DatabaseHelper.ExecuteReader(query);
                List<DonViTinh> list = new List<DonViTinh>();
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(MapDonViTinh(row));
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách đơn vị tính: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Lấy tất cả đơn vị tính đang hoạt động (TrangThai = 1)
        /// </summary>
        public List<DonViTinh> GetAllActive()
        {
            try
            {
                string query = @"SELECT * FROM DonViTinh WHERE TrangThai = 1 ORDER BY TenDVT";

                DataTable dt = DatabaseHelper.ExecuteReader(query);
                List<DonViTinh> list = new List<DonViTinh>();
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(MapDonViTinh(row));
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách đơn vị tính hoạt động: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Lấy đơn vị tính theo mã
        /// </summary>
        public DonViTinh GetById(int maDVT)
        {
            try
            {
                string query = @"SELECT * FROM DonViTinh WHERE MaDVT = @MaDVT";

                DataTable dt = DatabaseHelper.ExecuteReader(query,
                    new MySqlParameter("@MaDVT", maDVT));

                if (dt.Rows.Count > 0)
                {
                    return MapDonViTinh(dt.Rows[0]);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy đơn vị tính: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Thêm đơn vị tính mới
        /// </summary>
        public int Insert(DonViTinh dvt)
        {
            try
            {
                string query = @"INSERT INTO DonViTinh (TenDVT, MoTa, TrangThai)
                                 VALUES (@TenDVT, @MoTa, @TrangThai);
                                 SELECT LAST_INSERT_ID();";

                object result = DatabaseHelper.ExecuteScalar(query,
                    new MySqlParameter("@TenDVT", dvt.TenDVT),
                    new MySqlParameter("@MoTa", (object)dvt.MoTa ?? DBNull.Value),
                    new MySqlParameter("@TrangThai", dvt.TrangThai));

                return Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm đơn vị tính: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Cập nhật đơn vị tính
        /// </summary>
        public bool Update(DonViTinh dvt)
        {
            try
            {
                string query = @"UPDATE DonViTinh SET 
                                    TenDVT = @TenDVT,
                                    MoTa = @MoTa,
                                    TrangThai = @TrangThai
                                 WHERE MaDVT = @MaDVT";

                int rows = DatabaseHelper.ExecuteNonQuery(query,
                    new MySqlParameter("@TenDVT", dvt.TenDVT),
                    new MySqlParameter("@MoTa", (object)dvt.MoTa ?? DBNull.Value),
                    new MySqlParameter("@TrangThai", dvt.TrangThai),
                    new MySqlParameter("@MaDVT", dvt.MaDVT));

                return rows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật đơn vị tính: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Cập nhật trạng thái đơn vị tính
        /// </summary>
        public bool UpdateTrangThai(int maDVT, int trangThai)
        {
            try
            {
                string query = @"UPDATE DonViTinh SET TrangThai = @TrangThai
                                 WHERE MaDVT = @MaDVT";

                int rows = DatabaseHelper.ExecuteNonQuery(query,
                    new MySqlParameter("@TrangThai", trangThai),
                    new MySqlParameter("@MaDVT", maDVT));

                return rows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật trạng thái đơn vị tính: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Kiểm tra trùng tên đơn vị tính
        /// </summary>
        public bool KiemTraTrung(string tenDVT, int maDVT)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM DonViTinh WHERE TenDVT = @Ten AND MaDVT <> @Ma";
                object result = DatabaseHelper.ExecuteScalar(query,
                    new MySqlParameter("@Ten", tenDVT),
                    new MySqlParameter("@Ma", maDVT));
                return Convert.ToInt32(result) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi kiểm tra trùng tên: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Chuyển DataRow thành đối tượng DonViTinh
        /// </summary>
        private DonViTinh MapDonViTinh(DataRow row)
        {
            DonViTinh dvt = new DonViTinh();
            dvt.MaDVT = Convert.ToInt32(row["MaDVT"]);
            dvt.TenDVT = row["TenDVT"].ToString();
            dvt.MoTa = row["MoTa"] != DBNull.Value ? row["MoTa"].ToString() : null;
            dvt.TrangThai = Convert.ToInt32(row["TrangThai"]);
            return dvt;
        }
    }
}
