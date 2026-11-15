using System;
using System.Collections.Generic;
using System.Data;
using MySqlConnector;
using baitaplon.Models;

namespace baitaplon.DAL
{
    /// <summary>
    /// Lớp truy cập dữ liệu cho Nhà cung cấp
    /// </summary>
    public class NhaCungCapDAL
    {
        /// <summary>
        /// Lấy tất cả nhà cung cấp
        /// </summary>
        public List<NhaCungCap> GetAll()
        {
            try
            {
                string query = @"SELECT * FROM NhaCungCap ORDER BY MaNCC DESC";

                DataTable dt = DatabaseHelper.ExecuteReader(query);
                List<NhaCungCap> list = new List<NhaCungCap>();
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(MapNhaCungCap(row));
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách nhà cung cấp: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Lấy tất cả nhà cung cấp đang hoạt động
        /// </summary>
        public List<NhaCungCap> GetAllActive()
        {
            try
            {
                string query = @"SELECT * FROM NhaCungCap WHERE TrangThai = 1 ORDER BY TenNCC";

                DataTable dt = DatabaseHelper.ExecuteReader(query);
                List<NhaCungCap> list = new List<NhaCungCap>();
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(MapNhaCungCap(row));
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách nhà cung cấp hoạt động: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Lấy nhà cung cấp theo mã
        /// </summary>
        public NhaCungCap GetById(int maNCC)
        {
            try
            {
                string query = @"SELECT * FROM NhaCungCap WHERE MaNCC = @MaNCC";

                DataTable dt = DatabaseHelper.ExecuteReader(query,
                    new MySqlParameter("@MaNCC", maNCC));

                if (dt.Rows.Count > 0)
                {
                    return MapNhaCungCap(dt.Rows[0]);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy nhà cung cấp: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Thêm nhà cung cấp mới
        /// </summary>
        public int Insert(NhaCungCap ncc)
        {
            try
            {
                string query = @"INSERT INTO NhaCungCap (TenNCC, NguoiLienHe, SoDienThoai, Email, DiaChi, MoTa, TrangThai, NgayTao, NgayCapNhat)
                                 VALUES (@TenNCC, @NguoiLienHe, @SoDienThoai, @Email, @DiaChi, @MoTa, @TrangThai, NOW(), NOW());
                                 SELECT LAST_INSERT_ID();";

                object result = DatabaseHelper.ExecuteScalar(query,
                    new MySqlParameter("@TenNCC", ncc.TenNCC),
                    new MySqlParameter("@NguoiLienHe", (object)ncc.NguoiLienHe ?? DBNull.Value),
                    new MySqlParameter("@SoDienThoai", (object)ncc.SoDienThoai ?? DBNull.Value),
                    new MySqlParameter("@Email", (object)ncc.Email ?? DBNull.Value),
                    new MySqlParameter("@DiaChi", (object)ncc.DiaChi ?? DBNull.Value),
                    new MySqlParameter("@MoTa", (object)ncc.MoTa ?? DBNull.Value),
                    new MySqlParameter("@TrangThai", ncc.TrangThai));

                return Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm nhà cung cấp: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Cập nhật nhà cung cấp
        /// </summary>
        public bool Update(NhaCungCap ncc)
        {
            try
            {
                string query = @"UPDATE NhaCungCap SET 
                                    TenNCC = @TenNCC,
                                    NguoiLienHe = @NguoiLienHe,
                                    SoDienThoai = @SoDienThoai,
                                    Email = @Email,
                                    DiaChi = @DiaChi,
                                    MoTa = @MoTa,
                                    TrangThai = @TrangThai,
                                    NgayCapNhat = NOW()
                                 WHERE MaNCC = @MaNCC";

                int rows = DatabaseHelper.ExecuteNonQuery(query,
                    new MySqlParameter("@TenNCC", ncc.TenNCC),
                    new MySqlParameter("@NguoiLienHe", (object)ncc.NguoiLienHe ?? DBNull.Value),
                    new MySqlParameter("@SoDienThoai", (object)ncc.SoDienThoai ?? DBNull.Value),
                    new MySqlParameter("@Email", (object)ncc.Email ?? DBNull.Value),
                    new MySqlParameter("@DiaChi", (object)ncc.DiaChi ?? DBNull.Value),
                    new MySqlParameter("@MoTa", (object)ncc.MoTa ?? DBNull.Value),
                    new MySqlParameter("@TrangThai", ncc.TrangThai),
                    new MySqlParameter("@MaNCC", ncc.MaNCC));

                return rows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật nhà cung cấp: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Cập nhật trạng thái nhà cung cấp
        /// </summary>
        public bool UpdateTrangThai(int maNCC, int trangThai)
        {
            try
            {
                string query = @"UPDATE NhaCungCap SET TrangThai = @TrangThai, NgayCapNhat = NOW()
                                 WHERE MaNCC = @MaNCC";

                int rows = DatabaseHelper.ExecuteNonQuery(query,
                    new MySqlParameter("@TrangThai", trangThai),
                    new MySqlParameter("@MaNCC", maNCC));

                return rows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật trạng thái nhà cung cấp: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Tìm kiếm nhà cung cấp
        /// </summary>
        public List<NhaCungCap> Search(string keyword)
        {
            try
            {
                string query = @"SELECT * FROM NhaCungCap
                                 WHERE TenNCC LIKE @Keyword 
                                    OR NguoiLienHe LIKE @Keyword 
                                    OR SoDienThoai LIKE @Keyword
                                    OR Email LIKE @Keyword
                                 ORDER BY MaNCC DESC";

                DataTable dt = DatabaseHelper.ExecuteReader(query,
                    new MySqlParameter("@Keyword", "%" + keyword + "%"));

                List<NhaCungCap> list = new List<NhaCungCap>();
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(MapNhaCungCap(row));
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm nhà cung cấp: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Chuyển DataRow thành đối tượng NhaCungCap
        /// </summary>
        private NhaCungCap MapNhaCungCap(DataRow row)
        {
            NhaCungCap ncc = new NhaCungCap();
            ncc.MaNCC = Convert.ToInt32(row["MaNCC"]);
            ncc.TenNCC = row["TenNCC"].ToString();
            ncc.NguoiLienHe = row["NguoiLienHe"] != DBNull.Value ? row["NguoiLienHe"].ToString() : null;
            ncc.SoDienThoai = row["SoDienThoai"] != DBNull.Value ? row["SoDienThoai"].ToString() : null;
            ncc.Email = row["Email"] != DBNull.Value ? row["Email"].ToString() : null;
            ncc.DiaChi = row["DiaChi"] != DBNull.Value ? row["DiaChi"].ToString() : null;
            ncc.MoTa = row["MoTa"] != DBNull.Value ? row["MoTa"].ToString() : null;
            ncc.TrangThai = Convert.ToInt32(row["TrangThai"]);
            ncc.NgayTao = Convert.ToDateTime(row["NgayTao"]);
            ncc.NgayCapNhat = Convert.ToDateTime(row["NgayCapNhat"]);
            return ncc;
        }
    }
}
