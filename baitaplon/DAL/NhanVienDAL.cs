using System;
using System.Collections.Generic;
using System.Data;
using MySqlConnector;
using baitaplon.Models;

namespace baitaplon.DAL
{
    /// <summary>
    /// Lớp truy cập dữ liệu cho Nhân viên
    /// </summary>
    public class NhanVienDAL
    {
        /// <summary>
        /// Lấy danh sách tất cả nhân viên
        /// </summary>
        public List<NhanVien> GetAll()
        {
            try
            {
                string query = @"SELECT * FROM NhanVien ORDER BY MaNV DESC";

                DataTable dt = DatabaseHelper.ExecuteReader(query);
                List<NhanVien> list = new List<NhanVien>();
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(MapNhanVien(row));
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách nhân viên: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Lấy nhân viên theo mã
        /// </summary>
        public NhanVien GetById(int maNV)
        {
            try
            {
                string query = @"SELECT * FROM NhanVien WHERE MaNV = @MaNV";

                DataTable dt = DatabaseHelper.ExecuteReader(query,
                    new MySqlParameter("@MaNV", maNV));

                if (dt.Rows.Count > 0)
                {
                    return MapNhanVien(dt.Rows[0]);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy nhân viên: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Thêm nhân viên mới
        /// </summary>
        /// <returns>Mã nhân viên vừa thêm</returns>
        public int Insert(NhanVien nv)
        {
            try
            {
                string query = @"INSERT INTO NhanVien (HoTen, GioiTinh, NgaySinh, SoDienThoai, Email, DiaChi, ChucVu, TrangThai, NgayTao, NgayCapNhat)
                                 VALUES (@HoTen, @GioiTinh, @NgaySinh, @SoDienThoai, @Email, @DiaChi, @ChucVu, @TrangThai, NOW(), NOW());
                                 SELECT LAST_INSERT_ID();";

                object result = DatabaseHelper.ExecuteScalar(query,
                    new MySqlParameter("@HoTen", nv.HoTen),
                    new MySqlParameter("@GioiTinh", (object)nv.GioiTinh ?? DBNull.Value),
                    new MySqlParameter("@NgaySinh", (object)nv.NgaySinh ?? DBNull.Value),
                    new MySqlParameter("@SoDienThoai", (object)nv.SoDienThoai ?? DBNull.Value),
                    new MySqlParameter("@Email", (object)nv.Email ?? DBNull.Value),
                    new MySqlParameter("@DiaChi", (object)nv.DiaChi ?? DBNull.Value),
                    new MySqlParameter("@ChucVu", (object)nv.ChucVu ?? DBNull.Value),
                    new MySqlParameter("@TrangThai", nv.TrangThai));

                return Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm nhân viên: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Cập nhật thông tin nhân viên
        /// </summary>
        public bool Update(NhanVien nv)
        {
            try
            {
                string query = @"UPDATE NhanVien SET 
                                    HoTen = @HoTen,
                                    GioiTinh = @GioiTinh,
                                    NgaySinh = @NgaySinh,
                                    SoDienThoai = @SoDienThoai,
                                    Email = @Email,
                                    DiaChi = @DiaChi,
                                    ChucVu = @ChucVu,
                                    NgayCapNhat = NOW()
                                 WHERE MaNV = @MaNV";

                int rows = DatabaseHelper.ExecuteNonQuery(query,
                    new MySqlParameter("@HoTen", nv.HoTen),
                    new MySqlParameter("@GioiTinh", (object)nv.GioiTinh ?? DBNull.Value),
                    new MySqlParameter("@NgaySinh", (object)nv.NgaySinh ?? DBNull.Value),
                    new MySqlParameter("@SoDienThoai", (object)nv.SoDienThoai ?? DBNull.Value),
                    new MySqlParameter("@Email", (object)nv.Email ?? DBNull.Value),
                    new MySqlParameter("@DiaChi", (object)nv.DiaChi ?? DBNull.Value),
                    new MySqlParameter("@ChucVu", (object)nv.ChucVu ?? DBNull.Value),
                    new MySqlParameter("@MaNV", nv.MaNV));

                return rows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật nhân viên: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Cập nhật trạng thái nhân viên
        /// </summary>
        public bool UpdateTrangThai(int maNV, int trangThai)
        {
            try
            {
                string query = @"UPDATE NhanVien SET TrangThai = @TrangThai, NgayCapNhat = NOW()
                                 WHERE MaNV = @MaNV";

                int rows = DatabaseHelper.ExecuteNonQuery(query,
                    new MySqlParameter("@TrangThai", trangThai),
                    new MySqlParameter("@MaNV", maNV));

                return rows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật trạng thái nhân viên: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Chuyển DataRow thành đối tượng NhanVien
        /// </summary>
        private NhanVien MapNhanVien(DataRow row)
        {
            NhanVien nv = new NhanVien();
            nv.MaNV = Convert.ToInt32(row["MaNV"]);
            nv.HoTen = row["HoTen"].ToString();
            nv.GioiTinh = row["GioiTinh"] != DBNull.Value ? row["GioiTinh"].ToString() : null;
            nv.NgaySinh = row["NgaySinh"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row["NgaySinh"]) : null;
            nv.SoDienThoai = row["SoDienThoai"] != DBNull.Value ? row["SoDienThoai"].ToString() : null;
            nv.Email = row["Email"] != DBNull.Value ? row["Email"].ToString() : null;
            nv.DiaChi = row["DiaChi"] != DBNull.Value ? row["DiaChi"].ToString() : null;
            nv.ChucVu = row["ChucVu"] != DBNull.Value ? row["ChucVu"].ToString() : null;
            nv.TrangThai = Convert.ToInt32(row["TrangThai"]);
            nv.NgayTao = Convert.ToDateTime(row["NgayTao"]);
            nv.NgayCapNhat = Convert.ToDateTime(row["NgayCapNhat"]);
            return nv;
        }
    }
}
