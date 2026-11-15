using System;
using System.Collections.Generic;
using System.Data;
using MySqlConnector;
using baitaplon.Models;

namespace baitaplon.DAL
{
    public class PhieuNhapDAL
    {
        public List<PhieuNhap> GetAll(DateTime? tuNgay, DateTime? denNgay, int? trangThai, int? maNCC)
        {
            string query = @"SELECT pn.*, ncc.TenNCC, tk.TenDangNhap AS TenNguoiTao,
                             nv.HoTen AS TenNVTao, tk2.TenDangNhap AS TenNguoiXN, nv2.HoTen AS TenNVXN
                             FROM PhieuNhap pn
                             LEFT JOIN NhaCungCap ncc ON pn.MaNCC = ncc.MaNCC
                             LEFT JOIN TaiKhoan tk ON pn.MaTK = tk.MaTK
                             LEFT JOIN NhanVien nv ON tk.MaNV = nv.MaNV
                             LEFT JOIN TaiKhoan tk2 ON pn.NguoiXacNhan = tk2.MaTK
                             LEFT JOIN NhanVien nv2 ON tk2.MaNV = nv2.MaNV
                             WHERE 1=1";

            var parameters = new List<MySqlParameter>();

            if (tuNgay.HasValue)
            {
                query += " AND pn.NgayNhap >= @TuNgay";
                parameters.Add(new MySqlParameter("@TuNgay", tuNgay.Value.Date));
            }
            if (denNgay.HasValue)
            {
                query += " AND pn.NgayNhap < @DenNgay";
                parameters.Add(new MySqlParameter("@DenNgay", denNgay.Value.Date.AddDays(1)));
            }
            if (trangThai.HasValue)
            {
                query += " AND pn.TrangThai = @TrangThai";
                parameters.Add(new MySqlParameter("@TrangThai", trangThai.Value));
            }
            if (maNCC.HasValue)
            {
                query += " AND pn.MaNCC = @MaNCC";
                parameters.Add(new MySqlParameter("@MaNCC", maNCC.Value));
            }

            query += " ORDER BY pn.NgayNhap DESC";

            var list = new List<PhieuNhap>();
            DataTable dt = DatabaseHelper.ExecuteReader(query, parameters.ToArray());

            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapPhieuNhap(row));
            }
            return list;
        }

        public PhieuNhap GetById(int maPhieuNhap)
        {
            string query = @"SELECT pn.*, ncc.TenNCC, tk.TenDangNhap AS TenNguoiTao,
                             nv.HoTen AS TenNVTao, tk2.TenDangNhap AS TenNguoiXN, nv2.HoTen AS TenNVXN
                             FROM PhieuNhap pn
                             LEFT JOIN NhaCungCap ncc ON pn.MaNCC = ncc.MaNCC
                             LEFT JOIN TaiKhoan tk ON pn.MaTK = tk.MaTK
                             LEFT JOIN NhanVien nv ON tk.MaNV = nv.MaNV
                             LEFT JOIN TaiKhoan tk2 ON pn.NguoiXacNhan = tk2.MaTK
                             LEFT JOIN NhanVien nv2 ON tk2.MaNV = nv2.MaNV
                             WHERE pn.MaPhieuNhap = @MaPhieuNhap";

            DataTable dt = DatabaseHelper.ExecuteReader(query, new MySqlParameter("@MaPhieuNhap", maPhieuNhap));
            if (dt.Rows.Count > 0)
            {
                var phieu = MapPhieuNhap(dt.Rows[0]);
                phieu.ChiTietPhieuNhaps = GetChiTiet(maPhieuNhap);
                return phieu;
            }
            return null;
        }

        public List<ChiTietPhieuNhap> GetChiTiet(int maPhieuNhap)
        {
            string query = @"SELECT ct.*, sp.MaSPCode, sp.TenSP, dvt.TenDVT
                             FROM ChiTietPhieuNhap ct
                             JOIN SanPham sp ON ct.MaSP = sp.MaSP
                             LEFT JOIN DonViTinh dvt ON sp.MaDVT = dvt.MaDVT
                             WHERE ct.MaPhieuNhap = @MaPhieuNhap";

            var list = new List<ChiTietPhieuNhap>();
            DataTable dt = DatabaseHelper.ExecuteReader(query, new MySqlParameter("@MaPhieuNhap", maPhieuNhap));
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new ChiTietPhieuNhap
                {
                    MaCTPN = Convert.ToInt32(row["MaCTPN"]),
                    MaPhieuNhap = Convert.ToInt32(row["MaPhieuNhap"]),
                    MaSP = Convert.ToInt32(row["MaSP"]),
                    SoLuong = Convert.ToInt32(row["SoLuong"]),
                    DonGia = Convert.ToDecimal(row["DonGia"]),
                    ThanhTien = Convert.ToDecimal(row["ThanhTien"]),
                    MaSPCode = row["MaSPCode"].ToString(),
                    TenSP = row["TenSP"].ToString(),
                    TenDVT = row["TenDVT"] == DBNull.Value ? "" : row["TenDVT"].ToString()
                });
            }
            return list;
        }

        public int Insert(PhieuNhap phieu, List<ChiTietPhieuNhap> chiTiet)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        string query = @"INSERT INTO PhieuNhap (MaPhieuNhapCode, MaNCC, MaTK, NgayNhap, TongTien, GhiChu, TrangThai)
                                         VALUES (@Code, @MaNCC, @MaTK, @NgayNhap, @TongTien, @GhiChu, 0);
                                         SELECT LAST_INSERT_ID();";

                        using (var cmd = new MySqlCommand(query, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@Code", phieu.MaPhieuNhapCode);
                            cmd.Parameters.AddWithValue("@MaNCC", (object)phieu.MaNCC ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@MaTK", (object)phieu.MaTK ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@NgayNhap", phieu.NgayNhap);
                            cmd.Parameters.AddWithValue("@TongTien", phieu.TongTien);
                            cmd.Parameters.AddWithValue("@GhiChu", (object)phieu.GhiChu ?? DBNull.Value);

                            int maPhieu = Convert.ToInt32(cmd.ExecuteScalar());

                            foreach (var ct in chiTiet)
                            {
                                string ctQuery = @"INSERT INTO ChiTietPhieuNhap (MaPhieuNhap, MaSP, SoLuong, DonGia, ThanhTien)
                                                   VALUES (@MaPhieu, @MaSP, @SoLuong, @DonGia, @ThanhTien)";
                                using (var ctCmd = new MySqlCommand(ctQuery, conn, trans))
                                {
                                    ctCmd.Parameters.AddWithValue("@MaPhieu", maPhieu);
                                    ctCmd.Parameters.AddWithValue("@MaSP", ct.MaSP);
                                    ctCmd.Parameters.AddWithValue("@SoLuong", ct.SoLuong);
                                    ctCmd.Parameters.AddWithValue("@DonGia", ct.DonGia);
                                    ctCmd.Parameters.AddWithValue("@ThanhTien", ct.ThanhTien);
                                    ctCmd.ExecuteNonQuery();
                                }
                            }

                            trans.Commit();
                            return maPhieu;
                        }
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        public bool UpdateDraft(PhieuNhap phieu, List<ChiTietPhieuNhap> chiTiet)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        // Check draft status
                        using (var checkCmd = new MySqlCommand("SELECT TrangThai FROM PhieuNhap WHERE MaPhieuNhap = @Ma", conn, trans))
                        {
                            checkCmd.Parameters.AddWithValue("@Ma", phieu.MaPhieuNhap);
                            int status = Convert.ToInt32(checkCmd.ExecuteScalar());
                            if (status != 0) throw new Exception("Chỉ có thể sửa phiếu ở trạng thái Nháp!");
                        }

                        string query = @"UPDATE PhieuNhap SET MaNCC=@MaNCC, NgayNhap=@NgayNhap, 
                                         TongTien=@TongTien, GhiChu=@GhiChu WHERE MaPhieuNhap=@Ma AND TrangThai=0";
                        using (var cmd = new MySqlCommand(query, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@Ma", phieu.MaPhieuNhap);
                            cmd.Parameters.AddWithValue("@MaNCC", (object)phieu.MaNCC ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@NgayNhap", phieu.NgayNhap);
                            cmd.Parameters.AddWithValue("@TongTien", phieu.TongTien);
                            cmd.Parameters.AddWithValue("@GhiChu", (object)phieu.GhiChu ?? DBNull.Value);
                            cmd.ExecuteNonQuery();
                        }

                        // Delete old details
                        using (var delCmd = new MySqlCommand("DELETE FROM ChiTietPhieuNhap WHERE MaPhieuNhap=@Ma", conn, trans))
                        {
                            delCmd.Parameters.AddWithValue("@Ma", phieu.MaPhieuNhap);
                            delCmd.ExecuteNonQuery();
                        }

                        // Insert new details
                        foreach (var ct in chiTiet)
                        {
                            string ctQuery = @"INSERT INTO ChiTietPhieuNhap (MaPhieuNhap, MaSP, SoLuong, DonGia, ThanhTien)
                                               VALUES (@MaPhieu, @MaSP, @SoLuong, @DonGia, @ThanhTien)";
                            using (var ctCmd = new MySqlCommand(ctQuery, conn, trans))
                            {
                                ctCmd.Parameters.AddWithValue("@MaPhieu", phieu.MaPhieuNhap);
                                ctCmd.Parameters.AddWithValue("@MaSP", ct.MaSP);
                                ctCmd.Parameters.AddWithValue("@SoLuong", ct.SoLuong);
                                ctCmd.Parameters.AddWithValue("@DonGia", ct.DonGia);
                                ctCmd.Parameters.AddWithValue("@ThanhTien", ct.ThanhTien);
                                ctCmd.ExecuteNonQuery();
                            }
                        }

                        trans.Commit();
                        return true;
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        public bool XacNhanPhieuNhap(int maPhieuNhap, int maTKXacNhan)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        // Lock and check status
                        using (var checkCmd = new MySqlCommand(
                            "SELECT TrangThai FROM PhieuNhap WHERE MaPhieuNhap = @Ma FOR UPDATE", conn, trans))
                        {
                            checkCmd.Parameters.AddWithValue("@Ma", maPhieuNhap);
                            object result = checkCmd.ExecuteScalar();
                            if (result == null) throw new Exception("Phiếu nhập không tồn tại!");
                            int status = Convert.ToInt32(result);
                            if (status != 0) throw new Exception("Phiếu này không ở trạng thái Nháp, không thể xác nhận!");
                        }

                        // Update status
                        using (var updateCmd = new MySqlCommand(
                            @"UPDATE PhieuNhap SET TrangThai=1, NgayXacNhan=NOW(), NguoiXacNhan=@TK 
                              WHERE MaPhieuNhap=@Ma", conn, trans))
                        {
                            updateCmd.Parameters.AddWithValue("@Ma", maPhieuNhap);
                            updateCmd.Parameters.AddWithValue("@TK", maTKXacNhan);
                            updateCmd.ExecuteNonQuery();
                        }

                        // Get details and update stock
                        var chiTiet = new List<ChiTietPhieuNhap>();
                        using (var detailCmd = new MySqlCommand(
                            "SELECT MaSP, SoLuong FROM ChiTietPhieuNhap WHERE MaPhieuNhap=@Ma", conn, trans))
                        {
                            detailCmd.Parameters.AddWithValue("@Ma", maPhieuNhap);
                            using (var reader = detailCmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    chiTiet.Add(new ChiTietPhieuNhap
                                    {
                                        MaSP = reader.GetInt32("MaSP"),
                                        SoLuong = reader.GetInt32("SoLuong")
                                    });
                                }
                            }
                        }

                        foreach (var ct in chiTiet)
                        {
                            // Update stock with row lock
                            using (var stockCmd = new MySqlCommand(
                                "UPDATE SanPham SET SoLuongTon = SoLuongTon + @SoLuong WHERE MaSP = @MaSP", conn, trans))
                            {
                                stockCmd.Parameters.AddWithValue("@SoLuong", ct.SoLuong);
                                stockCmd.Parameters.AddWithValue("@MaSP", ct.MaSP);
                                stockCmd.ExecuteNonQuery();
                            }

                            // Get current stock for history
                            int tonHienTai = 0;
                            using (var getStockCmd = new MySqlCommand(
                                "SELECT SoLuongTon FROM SanPham WHERE MaSP = @MaSP", conn, trans))
                            {
                                getStockCmd.Parameters.AddWithValue("@MaSP", ct.MaSP);
                                tonHienTai = Convert.ToInt32(getStockCmd.ExecuteScalar());
                            }

                            // Insert inventory history
                            using (var histCmd = new MySqlCommand(
                                @"INSERT INTO LichSuTonKho (MaSP, LoaiGiaoDich, SoLuongThayDoi, TonSauGiaoDich, MaPhieuNhap, MaTK, GhiChu)
                                  VALUES (@MaSP, 'NHAP', @SoLuong, @Ton, @MaPhieu, @TK, @GhiChu)", conn, trans))
                            {
                                histCmd.Parameters.AddWithValue("@MaSP", ct.MaSP);
                                histCmd.Parameters.AddWithValue("@SoLuong", ct.SoLuong);
                                histCmd.Parameters.AddWithValue("@Ton", tonHienTai);
                                histCmd.Parameters.AddWithValue("@MaPhieu", maPhieuNhap);
                                histCmd.Parameters.AddWithValue("@TK", maTKXacNhan);
                                histCmd.Parameters.AddWithValue("@GhiChu", "Nhập kho - Xác nhận phiếu");
                                histCmd.ExecuteNonQuery();
                            }
                        }

                        trans.Commit();
                        return true;
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        public bool HuyPhieuNhap(int maPhieuNhap, int maTKHuy)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        // Check status
                        int currentStatus = 0;
                        using (var checkCmd = new MySqlCommand(
                            "SELECT TrangThai FROM PhieuNhap WHERE MaPhieuNhap = @Ma FOR UPDATE", conn, trans))
                        {
                            checkCmd.Parameters.AddWithValue("@Ma", maPhieuNhap);
                            currentStatus = Convert.ToInt32(checkCmd.ExecuteScalar());
                        }

                        if (currentStatus == 2) throw new Exception("Phiếu đã bị hủy trước đó!");

                        // If confirmed, need to revert stock
                        if (currentStatus == 1)
                        {
                            var chiTiet = new List<ChiTietPhieuNhap>();
                            using (var detailCmd = new MySqlCommand(
                                "SELECT MaSP, SoLuong FROM ChiTietPhieuNhap WHERE MaPhieuNhap=@Ma", conn, trans))
                            {
                                detailCmd.Parameters.AddWithValue("@Ma", maPhieuNhap);
                                using (var reader = detailCmd.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        chiTiet.Add(new ChiTietPhieuNhap
                                        {
                                            MaSP = reader.GetInt32("MaSP"),
                                            SoLuong = reader.GetInt32("SoLuong")
                                        });
                                    }
                                }
                            }

                            foreach (var ct in chiTiet)
                            {
                                // Check if stock is sufficient to revert
                                int currentStock = 0;
                                using (var getCmd = new MySqlCommand(
                                    "SELECT SoLuongTon FROM SanPham WHERE MaSP = @MaSP FOR UPDATE", conn, trans))
                                {
                                    getCmd.Parameters.AddWithValue("@MaSP", ct.MaSP);
                                    currentStock = Convert.ToInt32(getCmd.ExecuteScalar());
                                }

                                if (currentStock < ct.SoLuong)
                                {
                                    throw new Exception(string.Format(
                                        "Không thể hủy phiếu! Sản phẩm (MaSP={0}) tồn kho hiện tại ({1}) nhỏ hơn số lượng cần hoàn trả ({2}).",
                                        ct.MaSP, currentStock, ct.SoLuong));
                                }

                                using (var stockCmd = new MySqlCommand(
                                    "UPDATE SanPham SET SoLuongTon = SoLuongTon - @SoLuong WHERE MaSP = @MaSP", conn, trans))
                                {
                                    stockCmd.Parameters.AddWithValue("@SoLuong", ct.SoLuong);
                                    stockCmd.Parameters.AddWithValue("@MaSP", ct.MaSP);
                                    stockCmd.ExecuteNonQuery();
                                }

                                int tonSau = 0;
                                using (var getCmd2 = new MySqlCommand(
                                    "SELECT SoLuongTon FROM SanPham WHERE MaSP = @MaSP", conn, trans))
                                {
                                    getCmd2.Parameters.AddWithValue("@MaSP", ct.MaSP);
                                    tonSau = Convert.ToInt32(getCmd2.ExecuteScalar());
                                }

                                using (var histCmd = new MySqlCommand(
                                    @"INSERT INTO LichSuTonKho (MaSP, LoaiGiaoDich, SoLuongThayDoi, TonSauGiaoDich, MaPhieuNhap, MaTK, GhiChu)
                                      VALUES (@MaSP, 'HUY_NHAP', @SoLuong, @Ton, @MaPhieu, @TK, 'Hủy phiếu nhập - Hoàn trả tồn kho')", conn, trans))
                                {
                                    histCmd.Parameters.AddWithValue("@MaSP", ct.MaSP);
                                    histCmd.Parameters.AddWithValue("@SoLuong", -ct.SoLuong);
                                    histCmd.Parameters.AddWithValue("@Ton", tonSau);
                                    histCmd.Parameters.AddWithValue("@MaPhieu", maPhieuNhap);
                                    histCmd.Parameters.AddWithValue("@TK", maTKHuy);
                                    histCmd.ExecuteNonQuery();
                                }
                            }
                        }

                        // Update status to cancelled
                        using (var updateCmd = new MySqlCommand(
                            "UPDATE PhieuNhap SET TrangThai=2 WHERE MaPhieuNhap=@Ma", conn, trans))
                        {
                            updateCmd.Parameters.AddWithValue("@Ma", maPhieuNhap);
                            updateCmd.ExecuteNonQuery();
                        }

                        trans.Commit();
                        return true;
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        public string GenerateMaPhieuNhap()
        {
            string today = DateTime.Now.ToString("yyyyMMdd");
            string prefix = "PN-" + today + "-";
            string query = "SELECT COUNT(*) FROM PhieuNhap WHERE MaPhieuNhapCode LIKE @Prefix";
            object result = DatabaseHelper.ExecuteScalar(query, new MySqlParameter("@Prefix", prefix + "%"));
            int count = Convert.ToInt32(result) + 1;
            return prefix + count.ToString("D3");
        }

        public int GetSoPhieuTheoThang(int nam, int thang)
        {
            string query = "SELECT COUNT(*) FROM PhieuNhap WHERE YEAR(NgayNhap)=@Nam AND MONTH(NgayNhap)=@Thang AND TrangThai=1";
            object result = DatabaseHelper.ExecuteScalar(query,
                new MySqlParameter("@Nam", nam), new MySqlParameter("@Thang", thang));
            return Convert.ToInt32(result);
        }

        public int GetSoPhieuTheoNgay(DateTime ngay)
        {
            string query = "SELECT COUNT(*) FROM PhieuNhap WHERE DATE(NgayNhap)=@Ngay AND TrangThai=1";
            object result = DatabaseHelper.ExecuteScalar(query, new MySqlParameter("@Ngay", ngay.Date));
            return Convert.ToInt32(result);
        }

        public DataTable GetThongKeNhapTheoThang(int nam)
        {
            string query = @"SELECT MONTH(NgayNhap) AS Thang, SUM(TongTien) AS TongGiaTri, COUNT(*) AS SoPhieu
                             FROM PhieuNhap WHERE YEAR(NgayNhap)=@Nam AND TrangThai=1
                             GROUP BY MONTH(NgayNhap) ORDER BY Thang";
            return DatabaseHelper.ExecuteReader(query, new MySqlParameter("@Nam", nam));
        }

        private PhieuNhap MapPhieuNhap(DataRow row)
        {
            return new PhieuNhap
            {
                MaPhieuNhap = Convert.ToInt32(row["MaPhieuNhap"]),
                MaPhieuNhapCode = row["MaPhieuNhapCode"].ToString(),
                MaNCC = row["MaNCC"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["MaNCC"]),
                MaTK = row["MaTK"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["MaTK"]),
                NgayNhap = Convert.ToDateTime(row["NgayNhap"]),
                TongTien = Convert.ToDecimal(row["TongTien"]),
                GhiChu = row["GhiChu"] == DBNull.Value ? "" : row["GhiChu"].ToString(),
                TrangThai = Convert.ToInt32(row["TrangThai"]),
                NgayXacNhan = row["NgayXacNhan"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["NgayXacNhan"]),
                NguoiXacNhan = row["NguoiXacNhan"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["NguoiXacNhan"]),
                TenNCC = row["TenNCC"] == DBNull.Value ? "" : row["TenNCC"].ToString(),
                TenNguoiTao = row["TenNVTao"] == DBNull.Value ? (row["TenNguoiTao"] == DBNull.Value ? "" : row["TenNguoiTao"].ToString()) : row["TenNVTao"].ToString(),
                TenNguoiXacNhan = row["TenNVXN"] == DBNull.Value ? (row["TenNguoiXN"] == DBNull.Value ? "" : row["TenNguoiXN"].ToString()) : row["TenNVXN"].ToString()
            };
        }
    }
}

