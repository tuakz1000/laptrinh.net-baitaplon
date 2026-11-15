using System;
using System.Collections.Generic;
using System.Data;
using MySqlConnector;
using baitaplon.Models;

namespace baitaplon.DAL
{
    /// <summary>
    /// Lớp truy cập dữ liệu cho Sản phẩm
    /// </summary>
    public class SanPhamDAL
    {
        /// <summary>
        /// Lấy tất cả sản phẩm kèm thông tin danh mục và đơn vị tính
        /// </summary>
        public List<SanPham> GetAll()
        {
            try
            {
                string query = @"SELECT sp.*, dm.TenDanhMuc, dvt.TenDVT
                                 FROM SanPham sp
                                 LEFT JOIN DanhMuc dm ON sp.MaDanhMuc = dm.MaDanhMuc
                                 LEFT JOIN DonViTinh dvt ON sp.MaDVT = dvt.MaDVT
                                 ORDER BY sp.MaSP DESC";

                DataTable dt = DatabaseHelper.ExecuteReader(query);
                List<SanPham> list = new List<SanPham>();
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(MapSanPham(row));
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách sản phẩm: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Lấy sản phẩm theo mã
        /// </summary>
        public SanPham GetById(int maSP)
        {
            try
            {
                string query = @"SELECT sp.*, dm.TenDanhMuc, dvt.TenDVT
                                 FROM SanPham sp
                                 LEFT JOIN DanhMuc dm ON sp.MaDanhMuc = dm.MaDanhMuc
                                 LEFT JOIN DonViTinh dvt ON sp.MaDVT = dvt.MaDVT
                                 WHERE sp.MaSP = @MaSP";

                DataTable dt = DatabaseHelper.ExecuteReader(query,
                    new MySqlParameter("@MaSP", maSP));

                if (dt.Rows.Count > 0)
                {
                    return MapSanPham(dt.Rows[0]);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy sản phẩm: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Tìm kiếm sản phẩm theo từ khóa, danh mục, trạng thái
        /// </summary>
        public List<SanPham> Search(string keyword, int? maDanhMuc, int? trangThai)
        {
            try
            {
                string query = @"SELECT sp.*, dm.TenDanhMuc, dvt.TenDVT
                                 FROM SanPham sp
                                 LEFT JOIN DanhMuc dm ON sp.MaDanhMuc = dm.MaDanhMuc
                                 LEFT JOIN DonViTinh dvt ON sp.MaDVT = dvt.MaDVT
                                 WHERE 1=1";

                List<MySqlParameter> parameters = new List<MySqlParameter>();

                if (!string.IsNullOrEmpty(keyword))
                {
                    query += " AND (sp.MaSPCode LIKE @Keyword OR sp.TenSP LIKE @Keyword)";
                    parameters.Add(new MySqlParameter("@Keyword", "%" + keyword + "%"));
                }

                if (maDanhMuc.HasValue)
                {
                    query += " AND sp.MaDanhMuc = @MaDanhMuc";
                    parameters.Add(new MySqlParameter("@MaDanhMuc", maDanhMuc.Value));
                }

                if (trangThai.HasValue)
                {
                    query += " AND sp.TrangThai = @TrangThai";
                    parameters.Add(new MySqlParameter("@TrangThai", trangThai.Value));
                }

                query += " ORDER BY sp.MaSP DESC";

                DataTable dt = DatabaseHelper.ExecuteReader(query, parameters.ToArray());
                List<SanPham> list = new List<SanPham>();
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(MapSanPham(row));
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm sản phẩm: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Thêm sản phẩm mới
        /// </summary>
        /// <returns>Mã sản phẩm vừa thêm</returns>
        public int Insert(SanPham sp)
        {
            try
            {
                string query = @"INSERT INTO SanPham (MaSPCode, TenSP, MaDanhMuc, MaDVT, GiaNhap, GiaBan, SoLuongTon, TonToiThieu, HinhAnh, MoTa, TrangThai, NgayTao, NgayCapNhat)
                                 VALUES (@MaSPCode, @TenSP, @MaDanhMuc, @MaDVT, @GiaNhap, @GiaBan, @SoLuongTon, @TonToiThieu, @HinhAnh, @MoTa, @TrangThai, NOW(), NOW());
                                 SELECT LAST_INSERT_ID();";

                object result = DatabaseHelper.ExecuteScalar(query,
                    new MySqlParameter("@MaSPCode", sp.MaSPCode),
                    new MySqlParameter("@TenSP", sp.TenSP),
                    new MySqlParameter("@MaDanhMuc", (object)sp.MaDanhMuc ?? DBNull.Value),
                    new MySqlParameter("@MaDVT", (object)sp.MaDVT ?? DBNull.Value),
                    new MySqlParameter("@GiaNhap", sp.GiaNhap),
                    new MySqlParameter("@GiaBan", sp.GiaBan),
                    new MySqlParameter("@SoLuongTon", sp.SoLuongTon),
                    new MySqlParameter("@TonToiThieu", sp.TonToiThieu),
                    new MySqlParameter("@HinhAnh", (object)sp.HinhAnh ?? DBNull.Value),
                    new MySqlParameter("@MoTa", (object)sp.MoTa ?? DBNull.Value),
                    new MySqlParameter("@TrangThai", sp.TrangThai));

                return Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm sản phẩm: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Cập nhật sản phẩm
        /// </summary>
        public bool Update(SanPham sp)
        {
            try
            {
                string query = @"UPDATE SanPham SET 
                                    MaSPCode = @MaSPCode,
                                    TenSP = @TenSP,
                                    MaDanhMuc = @MaDanhMuc,
                                    MaDVT = @MaDVT,
                                    GiaNhap = @GiaNhap,
                                    GiaBan = @GiaBan,
                                    TonToiThieu = @TonToiThieu,
                                    HinhAnh = @HinhAnh,
                                    MoTa = @MoTa,
                                    TrangThai = @TrangThai,
                                    NgayCapNhat = NOW()
                                 WHERE MaSP = @MaSP";

                int rows = DatabaseHelper.ExecuteNonQuery(query,
                    new MySqlParameter("@MaSPCode", sp.MaSPCode),
                    new MySqlParameter("@TenSP", sp.TenSP),
                    new MySqlParameter("@MaDanhMuc", (object)sp.MaDanhMuc ?? DBNull.Value),
                    new MySqlParameter("@MaDVT", (object)sp.MaDVT ?? DBNull.Value),
                    new MySqlParameter("@GiaNhap", sp.GiaNhap),
                    new MySqlParameter("@GiaBan", sp.GiaBan),
                    new MySqlParameter("@TonToiThieu", sp.TonToiThieu),
                    new MySqlParameter("@HinhAnh", (object)sp.HinhAnh ?? DBNull.Value),
                    new MySqlParameter("@MoTa", (object)sp.MoTa ?? DBNull.Value),
                    new MySqlParameter("@TrangThai", sp.TrangThai),
                    new MySqlParameter("@MaSP", sp.MaSP));

                return rows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật sản phẩm: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Cập nhật trạng thái sản phẩm
        /// </summary>
        public bool UpdateTrangThai(int maSP, int trangThai)
        {
            try
            {
                string query = @"UPDATE SanPham SET TrangThai = @TrangThai, NgayCapNhat = NOW()
                                 WHERE MaSP = @MaSP";

                int rows = DatabaseHelper.ExecuteNonQuery(query,
                    new MySqlParameter("@TrangThai", trangThai),
                    new MySqlParameter("@MaSP", maSP));

                return rows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật trạng thái sản phẩm: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Cập nhật số lượng tồn kho (dùng trong transaction)
        /// </summary>
        public bool UpdateSoLuongTon(int maSP, int soLuong, MySqlConnection conn, MySqlTransaction trans)
        {
            try
            {
                string query = @"UPDATE SanPham SET SoLuongTon = @SoLuong, NgayCapNhat = NOW()
                                 WHERE MaSP = @MaSP";

                using (MySqlCommand cmd = new MySqlCommand(query, conn, trans))
                {
                    cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                    cmd.Parameters.AddWithValue("@MaSP", maSP);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật số lượng tồn kho: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Lấy danh sách sản phẩm sắp hết hàng (SoLuongTon <= TonToiThieu)
        /// </summary>
        public List<SanPham> GetSanPhamSapHet()
        {
            try
            {
                string query = @"SELECT sp.*, dm.TenDanhMuc, dvt.TenDVT
                                 FROM SanPham sp
                                 LEFT JOIN DanhMuc dm ON sp.MaDanhMuc = dm.MaDanhMuc
                                 LEFT JOIN DonViTinh dvt ON sp.MaDVT = dvt.MaDVT
                                 WHERE sp.TrangThai = 1 AND sp.SoLuongTon <= sp.TonToiThieu AND sp.SoLuongTon > 0
                                 ORDER BY sp.SoLuongTon ASC";

                DataTable dt = DatabaseHelper.ExecuteReader(query);
                List<SanPham> list = new List<SanPham>();
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(MapSanPham(row));
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy sản phẩm sắp hết: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Lấy danh sách sản phẩm hết hàng (SoLuongTon = 0)
        /// </summary>
        public List<SanPham> GetSanPhamHetHang()
        {
            try
            {
                string query = @"SELECT sp.*, dm.TenDanhMuc, dvt.TenDVT
                                 FROM SanPham sp
                                 LEFT JOIN DanhMuc dm ON sp.MaDanhMuc = dm.MaDanhMuc
                                 LEFT JOIN DonViTinh dvt ON sp.MaDVT = dvt.MaDVT
                                 WHERE sp.TrangThai = 1 AND sp.SoLuongTon = 0
                                 ORDER BY sp.TenSP";

                DataTable dt = DatabaseHelper.ExecuteReader(query);
                List<SanPham> list = new List<SanPham>();
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(MapSanPham(row));
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy sản phẩm hết hàng: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Lấy mã sản phẩm cuối cùng
        /// </summary>
        public string GetLastMaSPCode()
        {
            string query = "SELECT MaSPCode FROM SanPham ORDER BY MaSPCode DESC LIMIT 1";
            object result = DatabaseHelper.ExecuteScalar(query);
            return result == null || result == DBNull.Value ? null : result.ToString();
        }

        /// <summary>
        /// Tạo mã sản phẩm tự động (VD: SP001, SP002...)
        /// </summary>
        public string GenerateMaSP()
        {
            try
            {
                string query = @"SELECT MAX(CAST(SUBSTRING(MaSPCode, 3) AS UNSIGNED)) AS MaxCode
                                 FROM SanPham WHERE MaSPCode LIKE 'SP%'";

                object result = DatabaseHelper.ExecuteScalar(query);

                int nextNumber = 1;
                if (result != null && result != DBNull.Value)
                {
                    nextNumber = Convert.ToInt32(result) + 1;
                }

                return "SP" + nextNumber.ToString("D3");
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tạo mã sản phẩm: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Kiểm tra sản phẩm có phiếu nhập/xuất liên quan không
        /// </summary>
        public bool HasTransaction(int maSP)
        {
            try
            {
                string query = @"SELECT COUNT(*) FROM (
                                    SELECT MaSP FROM ChiTietPhieuNhap WHERE MaSP = @MaSP
                                    UNION ALL
                                    SELECT MaSP FROM ChiTietPhieuXuat WHERE MaSP = @MaSP
                                 ) AS t";

                object result = DatabaseHelper.ExecuteScalar(query,
                    new MySqlParameter("@MaSP", maSP));

                return Convert.ToInt32(result) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi kiểm tra giao dịch sản phẩm: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Lấy top sản phẩm nhập nhiều nhất
        /// </summary>
        public DataTable GetTopNhapNhieu(int top, DateTime? tuNgay, DateTime? denNgay)
        {
            try
            {
                string query = @"SELECT sp.MaSPCode, sp.TenSP, SUM(ct.SoLuong) AS TongSoLuong, SUM(ct.ThanhTien) AS TongGiaTri
                                 FROM ChiTietPhieuNhap ct
                                 INNER JOIN SanPham sp ON ct.MaSP = sp.MaSP
                                 INNER JOIN PhieuNhap pn ON ct.MaPhieuNhap = pn.MaPhieuNhap
                                 WHERE pn.TrangThai = 1";

                List<MySqlParameter> parameters = new List<MySqlParameter>();

                if (tuNgay.HasValue)
                {
                    query += " AND pn.NgayNhap >= @TuNgay";
                    parameters.Add(new MySqlParameter("@TuNgay", tuNgay.Value.Date));
                }
                if (denNgay.HasValue)
                {
                    query += " AND pn.NgayNhap <= @DenNgay";
                    parameters.Add(new MySqlParameter("@DenNgay", denNgay.Value.Date.AddDays(1).AddSeconds(-1)));
                }

                query += " GROUP BY sp.MaSP, sp.MaSPCode, sp.TenSP ORDER BY TongSoLuong DESC LIMIT @Top";
                parameters.Add(new MySqlParameter("@Top", top));

                return DatabaseHelper.ExecuteReader(query, parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy top sản phẩm nhập nhiều: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Lấy top sản phẩm xuất nhiều nhất
        /// </summary>
        public DataTable GetTopXuatNhieu(int top, DateTime? tuNgay, DateTime? denNgay)
        {
            try
            {
                string query = @"SELECT sp.MaSPCode, sp.TenSP, SUM(ct.SoLuong) AS TongSoLuong, SUM(ct.ThanhTien) AS TongGiaTri
                                 FROM ChiTietPhieuXuat ct
                                 INNER JOIN SanPham sp ON ct.MaSP = sp.MaSP
                                 INNER JOIN PhieuXuat px ON ct.MaPhieuXuat = px.MaPhieuXuat
                                 WHERE px.TrangThai = 1";

                List<MySqlParameter> parameters = new List<MySqlParameter>();

                if (tuNgay.HasValue)
                {
                    query += " AND px.NgayXuat >= @TuNgay";
                    parameters.Add(new MySqlParameter("@TuNgay", tuNgay.Value.Date));
                }
                if (denNgay.HasValue)
                {
                    query += " AND px.NgayXuat <= @DenNgay";
                    parameters.Add(new MySqlParameter("@DenNgay", denNgay.Value.Date.AddDays(1).AddSeconds(-1)));
                }

                query += " GROUP BY sp.MaSP, sp.MaSPCode, sp.TenSP ORDER BY TongSoLuong DESC LIMIT @Top";
                parameters.Add(new MySqlParameter("@Top", top));

                return DatabaseHelper.ExecuteReader(query, parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy top sản phẩm xuất nhiều: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Chuyển DataRow thành đối tượng SanPham
        /// </summary>
        private SanPham MapSanPham(DataRow row)
        {
            SanPham sp = new SanPham();
            sp.MaSP = Convert.ToInt32(row["MaSP"]);
            sp.MaSPCode = row["MaSPCode"].ToString();
            sp.TenSP = row["TenSP"].ToString();
            sp.MaDanhMuc = row["MaDanhMuc"] != DBNull.Value ? (int?)Convert.ToInt32(row["MaDanhMuc"]) : null;
            sp.MaDVT = row["MaDVT"] != DBNull.Value ? (int?)Convert.ToInt32(row["MaDVT"]) : null;
            sp.GiaNhap = Convert.ToDecimal(row["GiaNhap"]);
            sp.GiaBan = Convert.ToDecimal(row["GiaBan"]);
            sp.SoLuongTon = Convert.ToInt32(row["SoLuongTon"]);
            sp.TonToiThieu = Convert.ToInt32(row["TonToiThieu"]);
            sp.HinhAnh = row["HinhAnh"] != DBNull.Value ? row["HinhAnh"].ToString() : null;
            sp.MoTa = row["MoTa"] != DBNull.Value ? row["MoTa"].ToString() : null;
            sp.TrangThai = Convert.ToInt32(row["TrangThai"]);
            sp.NgayTao = Convert.ToDateTime(row["NgayTao"]);
            sp.NgayCapNhat = Convert.ToDateTime(row["NgayCapNhat"]);

            if (row.Table.Columns.Contains("TenDanhMuc") && row["TenDanhMuc"] != DBNull.Value)
                sp.TenDanhMuc = row["TenDanhMuc"].ToString();

            if (row.Table.Columns.Contains("TenDVT") && row["TenDVT"] != DBNull.Value)
                sp.TenDVT = row["TenDVT"].ToString();

            return sp;
        }
    }
}
