using System;
using System.Collections.Generic;
using System.Data;
using MySqlConnector;
using baitaplon.Models;

namespace baitaplon.DAL
{
    /// <summary>
    /// Lớp truy cập dữ liệu cho Khách hàng
    /// </summary>
    public class KhachHangDAL
    {
        /// <summary>
        /// Lấy tất cả khách hàng
        /// </summary>
        public List<KhachHang> GetAll()
        {
            try
            {
                string query = @"SELECT * FROM KhachHang ORDER BY MaKH DESC";

                DataTable dt = DatabaseHelper.ExecuteReader(query);
                List<KhachHang> list = new List<KhachHang>();
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(MapKhachHang(row));
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách khách hàng: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Lấy tất cả khách hàng đang hoạt động
        /// </summary>
        public List<KhachHang> GetAllActive()
        {
            try
            {
                string query = @"SELECT * FROM KhachHang WHERE TrangThai = 1 ORDER BY TenKH";

                DataTable dt = DatabaseHelper.ExecuteReader(query);
                List<KhachHang> list = new List<KhachHang>();
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(MapKhachHang(row));
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách khách hàng hoạt động: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Lấy khách hàng theo mã
        /// </summary>
        public KhachHang GetById(int maKH)
        {
            try
            {
                string query = @"SELECT * FROM KhachHang WHERE MaKH = @MaKH";

                DataTable dt = DatabaseHelper.ExecuteReader(query,
                    new MySqlParameter("@MaKH", maKH));

                if (dt.Rows.Count > 0)
                {
                    return MapKhachHang(dt.Rows[0]);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy khách hàng: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Thêm khách hàng mới
        /// </summary>
        public int Insert(KhachHang kh)
        {
            try
            {
                string query = @"INSERT INTO KhachHang (TenKH, SoDienThoai, Email, DiaChi, MoTa, TrangThai, NgayTao, NgayCapNhat)
                                 VALUES (@TenKH, @SoDienThoai, @Email, @DiaChi, @MoTa, @TrangThai, NOW(), NOW());
                                 SELECT LAST_INSERT_ID();";

                object result = DatabaseHelper.ExecuteScalar(query,
                    new MySqlParameter("@TenKH", kh.TenKH),
                    new MySqlParameter("@SoDienThoai", (object)kh.SoDienThoai ?? DBNull.Value),
                    new MySqlParameter("@Email", (object)kh.Email ?? DBNull.Value),
                    new MySqlParameter("@DiaChi", (object)kh.DiaChi ?? DBNull.Value),
                    new MySqlParameter("@MoTa", (object)kh.MoTa ?? DBNull.Value),
                    new MySqlParameter("@TrangThai", kh.TrangThai));

                return Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm khách hàng: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Cập nhật khách hàng
        /// </summary>
        public bool Update(KhachHang kh)
        {
            try
            {
                string query = @"UPDATE KhachHang SET 
                                    TenKH = @TenKH,
                                    SoDienThoai = @SoDienThoai,
                                    Email = @Email,
                                    DiaChi = @DiaChi,
                                    MoTa = @MoTa,
                                    TrangThai = @TrangThai,
                                    NgayCapNhat = NOW()
                                 WHERE MaKH = @MaKH";

                int rows = DatabaseHelper.ExecuteNonQuery(query,
                    new MySqlParameter("@TenKH", kh.TenKH),
                    new MySqlParameter("@SoDienThoai", (object)kh.SoDienThoai ?? DBNull.Value),
                    new MySqlParameter("@Email", (object)kh.Email ?? DBNull.Value),
                    new MySqlParameter("@DiaChi", (object)kh.DiaChi ?? DBNull.Value),
                    new MySqlParameter("@MoTa", (object)kh.MoTa ?? DBNull.Value),
                    new MySqlParameter("@TrangThai", kh.TrangThai),
                    new MySqlParameter("@MaKH", kh.MaKH));

                return rows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật khách hàng: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Cập nhật trạng thái khách hàng
        /// </summary>
        public bool UpdateTrangThai(int maKH, int trangThai)
        {
            try
            {
                string query = @"UPDATE KhachHang SET TrangThai = @TrangThai, NgayCapNhat = NOW()
                                 WHERE MaKH = @MaKH";

                int rows = DatabaseHelper.ExecuteNonQuery(query,
                    new MySqlParameter("@TrangThai", trangThai),
                    new MySqlParameter("@MaKH", maKH));

                return rows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật trạng thái khách hàng: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Tìm kiếm khách hàng
        /// </summary>
        public List<KhachHang> Search(string keyword)
        {
            try
            {
                string query = @"SELECT * FROM KhachHang
                                 WHERE TenKH LIKE @Keyword 
                                    OR SoDienThoai LIKE @Keyword
                                    OR Email LIKE @Keyword
                                 ORDER BY MaKH DESC";

                DataTable dt = DatabaseHelper.ExecuteReader(query,
                    new MySqlParameter("@Keyword", "%" + keyword + "%"));

                List<KhachHang> list = new List<KhachHang>();
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(MapKhachHang(row));
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm khách hàng: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Chuyển DataRow thành đối tượng KhachHang
        /// </summary>
        private KhachHang MapKhachHang(DataRow row)
        {
            KhachHang kh = new KhachHang();
            kh.MaKH = Convert.ToInt32(row["MaKH"]);
            kh.TenKH = row["TenKH"].ToString();
            kh.SoDienThoai = row["SoDienThoai"] != DBNull.Value ? row["SoDienThoai"].ToString() : null;
            kh.Email = row["Email"] != DBNull.Value ? row["Email"].ToString() : null;
            kh.DiaChi = row["DiaChi"] != DBNull.Value ? row["DiaChi"].ToString() : null;
            kh.MoTa = row["MoTa"] != DBNull.Value ? row["MoTa"].ToString() : null;
            kh.TrangThai = Convert.ToInt32(row["TrangThai"]);
            kh.NgayTao = Convert.ToDateTime(row["NgayTao"]);
            kh.NgayCapNhat = Convert.ToDateTime(row["NgayCapNhat"]);
            return kh;
        }
    }
}
