using System;
using System.Collections.Generic;
using System.Data;
using MySqlConnector;
using baitaplon.Models;

namespace baitaplon.DAL
{
    /// <summary>
    /// Lớp truy cập dữ liệu cho Tài khoản
    /// </summary>
    public class TaiKhoanDAL
    {
        /// <summary>
        /// Lấy thông tin tài khoản theo tên đăng nhập (dùng cho đăng nhập)
        /// </summary>
        public TaiKhoan DangNhap(string tenDangNhap)
        {
            try
            {
                string query = @"SELECT tk.*, nv.HoTen AS TenNhanVien, vt.TenVaiTro
                                 FROM TaiKhoan tk
                                 LEFT JOIN NhanVien nv ON tk.MaNV = nv.MaNV
                                 LEFT JOIN VaiTro vt ON tk.MaVaiTro = vt.MaVaiTro
                                 WHERE tk.TenDangNhap = @TenDangNhap";

                DataTable dt = DatabaseHelper.ExecuteReader(query,
                    new MySqlParameter("@TenDangNhap", tenDangNhap));

                if (dt.Rows.Count > 0)
                {
                    return MapTaiKhoan(dt.Rows[0]);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi đăng nhập: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Lấy danh sách tất cả tài khoản kèm thông tin nhân viên và vai trò
        /// </summary>
        public List<TaiKhoan> GetAll()
        {
            try
            {
                string query = @"SELECT tk.*, nv.HoTen AS TenNhanVien, vt.TenVaiTro
                                 FROM TaiKhoan tk
                                 LEFT JOIN NhanVien nv ON tk.MaNV = nv.MaNV
                                 LEFT JOIN VaiTro vt ON tk.MaVaiTro = vt.MaVaiTro
                                 ORDER BY tk.MaTK DESC";

                DataTable dt = DatabaseHelper.ExecuteReader(query);
                List<TaiKhoan> list = new List<TaiKhoan>();
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(MapTaiKhoan(row));
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách tài khoản: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Lấy tài khoản theo mã
        /// </summary>
        public TaiKhoan GetById(int maTK)
        {
            try
            {
                string query = @"SELECT tk.*, nv.HoTen AS TenNhanVien, vt.TenVaiTro
                                 FROM TaiKhoan tk
                                 LEFT JOIN NhanVien nv ON tk.MaNV = nv.MaNV
                                 LEFT JOIN VaiTro vt ON tk.MaVaiTro = vt.MaVaiTro
                                 WHERE tk.MaTK = @MaTK";

                DataTable dt = DatabaseHelper.ExecuteReader(query,
                    new MySqlParameter("@MaTK", maTK));

                if (dt.Rows.Count > 0)
                {
                    return MapTaiKhoan(dt.Rows[0]);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy tài khoản: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Thêm tài khoản mới
        /// </summary>
        /// <returns>Mã tài khoản vừa thêm</returns>
        public int Insert(TaiKhoan tk)
        {
            try
            {
                string query = @"INSERT INTO TaiKhoan (TenDangNhap, MatKhau, MaNV, MaVaiTro, TrangThai, NgayTao, NgayCapNhat)
                                 VALUES (@TenDangNhap, @MatKhau, @MaNV, @MaVaiTro, @TrangThai, NOW(), NOW());
                                 SELECT LAST_INSERT_ID();";

                object result = DatabaseHelper.ExecuteScalar(query,
                    new MySqlParameter("@TenDangNhap", tk.TenDangNhap),
                    new MySqlParameter("@MatKhau", tk.MatKhau),
                    new MySqlParameter("@MaNV", (object)tk.MaNV ?? DBNull.Value),
                    new MySqlParameter("@MaVaiTro", tk.MaVaiTro),
                    new MySqlParameter("@TrangThai", tk.TrangThai));

                return Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm tài khoản: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Cập nhật tài khoản
        /// </summary>
        public bool Update(TaiKhoan tk)
        {
            try
            {
                string query = @"UPDATE TaiKhoan SET 
                                    TenDangNhap = @TenDangNhap,
                                    MaNV = @MaNV,
                                    MaVaiTro = @MaVaiTro,
                                    TrangThai = @TrangThai,
                                    NgayCapNhat = NOW()
                                 WHERE MaTK = @MaTK";

                int rows = DatabaseHelper.ExecuteNonQuery(query,
                    new MySqlParameter("@TenDangNhap", tk.TenDangNhap),
                    new MySqlParameter("@MaNV", (object)tk.MaNV ?? DBNull.Value),
                    new MySqlParameter("@MaVaiTro", tk.MaVaiTro),
                    new MySqlParameter("@TrangThai", tk.TrangThai),
                    new MySqlParameter("@MaTK", tk.MaTK));

                return rows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật tài khoản: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Đổi mật khẩu tài khoản
        /// </summary>
        public bool DoiMatKhau(int maTK, string matKhauMoi)
        {
            try
            {
                string query = @"UPDATE TaiKhoan SET MatKhau = @MatKhau, NgayCapNhat = NOW()
                                 WHERE MaTK = @MaTK";

                int rows = DatabaseHelper.ExecuteNonQuery(query,
                    new MySqlParameter("@MatKhau", matKhauMoi),
                    new MySqlParameter("@MaTK", maTK));

                return rows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi đổi mật khẩu: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Khóa tài khoản (TrangThai = 0)
        /// </summary>
        public bool KhoaTaiKhoan(int maTK)
        {
            try
            {
                string query = @"UPDATE TaiKhoan SET TrangThai = 0, NgayCapNhat = NOW()
                                 WHERE MaTK = @MaTK";

                int rows = DatabaseHelper.ExecuteNonQuery(query,
                    new MySqlParameter("@MaTK", maTK));

                return rows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi khóa tài khoản: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Mở khóa tài khoản (TrangThai = 1)
        /// </summary>
        public bool MoKhoaTaiKhoan(int maTK)
        {
            try
            {
                string query = @"UPDATE TaiKhoan SET TrangThai = 1, NgayCapNhat = NOW()
                                 WHERE MaTK = @MaTK";

                int rows = DatabaseHelper.ExecuteNonQuery(query,
                    new MySqlParameter("@MaTK", maTK));

                return rows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi mở khóa tài khoản: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Lấy danh sách quyền theo vai trò
        /// </summary>
        public List<string> GetQuyenByVaiTro(int maVaiTro)
        {
            try
            {
                string query = @"SELECT q.TenQuyen
                                 FROM PhanQuyen pq
                                 INNER JOIN Quyen q ON pq.MaQuyen = q.MaQuyen
                                 WHERE pq.MaVaiTro = @MaVaiTro";

                DataTable dt = DatabaseHelper.ExecuteReader(query,
                    new MySqlParameter("@MaVaiTro", maVaiTro));

                List<string> list = new List<string>();
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(row["TenQuyen"].ToString());
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy quyền vai trò: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Lấy tài khoản theo tên đăng nhập
        /// </summary>
        public TaiKhoan GetByTenDangNhap(string tenDangNhap)
        {
            return DangNhap(tenDangNhap);
        }

        /// <summary>
        /// Kiểm tra vai trò có quyền không
        /// </summary>
        public bool KiemTraQuyen(int maVaiTro, string tenQuyen)
        {
            try
            {
                string query = @"SELECT COUNT(*) FROM PhanQuyen pq
                                 INNER JOIN Quyen q ON pq.MaQuyen = q.MaQuyen
                                 WHERE pq.MaVaiTro = @MaVaiTro AND q.TenQuyen = @TenQuyen";
                object result = DatabaseHelper.ExecuteScalar(query,
                    new MySqlParameter("@MaVaiTro", maVaiTro),
                    new MySqlParameter("@TenQuyen", tenQuyen));
                return Convert.ToInt32(result) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi kiểm tra quyền: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Chuyển DataRow thành đối tượng TaiKhoan
        /// </summary>
        private TaiKhoan MapTaiKhoan(DataRow row)
        {
            TaiKhoan tk = new TaiKhoan();
            tk.MaTK = Convert.ToInt32(row["MaTK"]);
            tk.TenDangNhap = row["TenDangNhap"].ToString();
            tk.MatKhau = row["MatKhau"].ToString();
            tk.MaNV = row["MaNV"] != DBNull.Value ? (int?)Convert.ToInt32(row["MaNV"]) : null;
            tk.MaVaiTro = Convert.ToInt32(row["MaVaiTro"]);
            tk.TrangThai = Convert.ToInt32(row["TrangThai"]);
            tk.NgayTao = Convert.ToDateTime(row["NgayTao"]);
            tk.NgayCapNhat = Convert.ToDateTime(row["NgayCapNhat"]);

            if (row.Table.Columns.Contains("TenNhanVien") && row["TenNhanVien"] != DBNull.Value)
                tk.TenNhanVien = row["TenNhanVien"].ToString();

            if (row.Table.Columns.Contains("TenVaiTro") && row["TenVaiTro"] != DBNull.Value)
                tk.TenVaiTro = row["TenVaiTro"].ToString();

            return tk;
        }
    }
}
