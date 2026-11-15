using System;
using System.Collections.Generic;
using System.Data;
using MySqlConnector;
using baitaplon.Models;

namespace baitaplon.DAL
{
    public class PhieuXuatDAL
    {
        public List<PhieuXuat> GetAll(DateTime? tuNgay, DateTime? denNgay, int? trangThai, int? maKH)
        {
            string query = @"SELECT px.*, kh.TenKH, tk.TenDangNhap AS TenNguoiTao,
                             nv.HoTen AS TenNVTao, tk2.TenDangNhap AS TenNguoiXN, nv2.HoTen AS TenNVXN
                             FROM PhieuXuat px
                             LEFT JOIN KhachHang kh ON px.MaKH = kh.MaKH
                             LEFT JOIN TaiKhoan tk ON px.MaTK = tk.MaTK
                             LEFT JOIN NhanVien nv ON tk.MaNV = nv.MaNV
                             LEFT JOIN TaiKhoan tk2 ON px.NguoiXacNhan = tk2.MaTK
                             LEFT JOIN NhanVien nv2 ON tk2.MaNV = nv2.MaNV
                             WHERE 1=1";

            var parameters = new List<MySqlParameter>();
            if (tuNgay.HasValue)
            {
                query += " AND px.NgayXuat >= @TuNgay";
                parameters.Add(new MySqlParameter("@TuNgay", tuNgay.Value.Date));
            }
            if (denNgay.HasValue)
            {
                query += " AND px.NgayXuat < @DenNgay";
                parameters.Add(new MySqlParameter("@DenNgay", denNgay.Value.Date.AddDays(1)));
            }
            if (trangThai.HasValue)
            {
                query += " AND px.TrangThai = @TrangThai";
                parameters.Add(new MySqlParameter("@TrangThai", trangThai.Value));
            }
            if (maKH.HasValue)
            {
                query += " AND px.MaKH = @MaKH";
                parameters.Add(new MySqlParameter("@MaKH", maKH.Value));
            }
            query += " ORDER BY px.NgayXuat DESC";

            var list = new List<PhieuXuat>();
            DataTable dt = DatabaseHelper.ExecuteReader(query, parameters.ToArray());
            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapPhieuXuat(row));
            }
            return list;
        }

        public PhieuXuat GetById(int maPhieuXuat)
        {
            string query = @"SELECT px.*, kh.TenKH, tk.TenDangNhap AS TenNguoiTao,
                             nv.HoTen AS TenNVTao, tk2.TenDangNhap AS TenNguoiXN, nv2.HoTen AS TenNVXN
                             FROM PhieuXuat px
                             LEFT JOIN KhachHang kh ON px.MaKH = kh.MaKH
                             LEFT JOIN TaiKhoan tk ON px.MaTK = tk.MaTK
                             LEFT JOIN NhanVien nv ON tk.MaNV = nv.MaNV
                             LEFT JOIN TaiKhoan tk2 ON px.NguoiXacNhan = tk2.MaTK
                             LEFT JOIN NhanVien nv2 ON tk2.MaNV = nv2.MaNV
                             WHERE px.MaPhieuXuat = @Ma";

            DataTable dt = DatabaseHelper.ExecuteReader(query, new MySqlParameter("@Ma", maPhieuXuat));
            if (dt.Rows.Count > 0)
            {
                var phieu = MapPhieuXuat(dt.Rows[0]);
                phieu.ChiTietPhieuXuats = GetChiTiet(maPhieuXuat);
                return phieu;
            }
            return null;
        }

        public List<ChiTietPhieuXuat> GetChiTiet(int maPhieuXuat)
        {
            string query = @"SELECT ct.*, sp.MaSPCode, sp.TenSP, dvt.TenDVT
                             FROM ChiTietPhieuXuat ct
                             JOIN SanPham sp ON ct.MaSP = sp.MaSP
                             LEFT JOIN DonViTinh dvt ON sp.MaDVT = dvt.MaDVT
                             WHERE ct.MaPhieuXuat = @Ma";

            var list = new List<ChiTietPhieuXuat>();
            DataTable dt = DatabaseHelper.ExecuteReader(query, new MySqlParameter("@Ma", maPhieuXuat));
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new ChiTietPhieuXuat
                {
                    MaCTPX = Convert.ToInt32(row["MaCTPX"]),
                    MaPhieuXuat = Convert.ToInt32(row["MaPhieuXuat"]),
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

        public int Insert(PhieuXuat phieu, List<ChiTietPhieuXuat> chiTiet)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        string query = @"INSERT INTO PhieuXuat (MaPhieuXuatCode, MaKH, MaTK, NgayXuat, TongTien, GhiChu, TrangThai)
                                         VALUES (@Code, @MaKH, @MaTK, @NgayXuat, @TongTien, @GhiChu, 0);
                                         SELECT LAST_INSERT_ID();";

                        using (var cmd = new MySqlCommand(query, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@Code", phieu.MaPhieuXuatCode);
                            cmd.Parameters.AddWithValue("@MaKH", (object)phieu.MaKH ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@MaTK", (object)phieu.MaTK ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@NgayXuat", phieu.NgayXuat);
                            cmd.Parameters.AddWithValue("@TongTien", phieu.TongTien);
                            cmd.Parameters.AddWithValue("@GhiChu", (object)phieu.GhiChu ?? DBNull.Value);

                            int maPhieu = Convert.ToInt32(cmd.ExecuteScalar());

                            foreach (var ct in chiTiet)
                            {
                                string ctQuery = @"INSERT INTO ChiTietPhieuXuat (MaPhieuXuat, MaSP, SoLuong, DonGia, ThanhTien)
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

        public bool UpdateDraft(PhieuXuat phieu, List<ChiTietPhieuXuat> chiTiet)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        using (var checkCmd = new MySqlCommand("SELECT TrangThai FROM PhieuXuat WHERE MaPhieuXuat=@Ma", conn, trans))
                        {
                            checkCmd.Parameters.AddWithValue("@Ma", phieu.MaPhieuXuat);
                            if (Convert.ToInt32(checkCmd.ExecuteScalar()) != 0)
                                throw new Exception("Chỉ có thể sửa phiếu ở trạng thái Nháp!");
                        }

                        using (var cmd = new MySqlCommand(
                            @"UPDATE PhieuXuat SET MaKH=@MaKH, NgayXuat=@NgayXuat, TongTien=@TongTien, GhiChu=@GhiChu 
                              WHERE MaPhieuXuat=@Ma AND TrangThai=0", conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@Ma", phieu.MaPhieuXuat);
                            cmd.Parameters.AddWithValue("@MaKH", (object)phieu.MaKH ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@NgayXuat", phieu.NgayXuat);
                            cmd.Parameters.AddWithValue("@TongTien", phieu.TongTien);
                            cmd.Parameters.AddWithValue("@GhiChu", (object)phieu.GhiChu ?? DBNull.Value);
                            cmd.ExecuteNonQuery();
                        }

                        using (var delCmd = new MySqlCommand("DELETE FROM ChiTietPhieuXuat WHERE MaPhieuXuat=@Ma", conn, trans))
                        {
                            delCmd.Parameters.AddWithValue("@Ma", phieu.MaPhieuXuat);
                            delCmd.ExecuteNonQuery();
                        }

                        foreach (var ct in chiTiet)
                        {
                            using (var ctCmd = new MySqlCommand(
                                @"INSERT INTO ChiTietPhieuXuat (MaPhieuXuat, MaSP, SoLuong, DonGia, ThanhTien)
                                  VALUES (@MaPhieu, @MaSP, @SoLuong, @DonGia, @ThanhTien)", conn, trans))
                            {
                                ctCmd.Parameters.AddWithValue("@MaPhieu", phieu.MaPhieuXuat);
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

        public bool XacNhanPhieuXuat(int maPhieuXuat, int maTKXacNhan)
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
                            "SELECT TrangThai FROM PhieuXuat WHERE MaPhieuXuat=@Ma FOR UPDATE", conn, trans))
                        {
                            checkCmd.Parameters.AddWithValue("@Ma", maPhieuXuat);
                            object result = checkCmd.ExecuteScalar();
                            if (result == null) throw new Exception("Phiếu xuất không tồn tại!");
                            if (Convert.ToInt32(result) != 0) throw new Exception("Phiếu không ở trạng thái Nháp!");
                        }

                        // Get details
                        var chiTiet = new List<ChiTietPhieuXuat>();
                        using (var detailCmd = new MySqlCommand(
                            "SELECT MaSP, SoLuong FROM ChiTietPhieuXuat WHERE MaPhieuXuat=@Ma", conn, trans))
                        {
                            detailCmd.Parameters.AddWithValue("@Ma", maPhieuXuat);
                            using (var reader = detailCmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    chiTiet.Add(new ChiTietPhieuXuat
                                    {
                                        MaSP = reader.GetInt32("MaSP"),
                                        SoLuong = reader.GetInt32("SoLuong")
                                    });
                                }
                            }
                        }

                        // Check stock and update
                        foreach (var ct in chiTiet)
                        {
                            int currentStock = 0;
                            using (var stockCmd = new MySqlCommand(
                                "SELECT SoLuongTon FROM SanPham WHERE MaSP=@MaSP FOR UPDATE", conn, trans))
                            {
                                stockCmd.Parameters.AddWithValue("@MaSP", ct.MaSP);
                                currentStock = Convert.ToInt32(stockCmd.ExecuteScalar());
                            }

                            if (currentStock < ct.SoLuong)
                            {
                                // Get product name for error
                                string tenSP = "";
                                using (var nameCmd = new MySqlCommand("SELECT TenSP FROM SanPham WHERE MaSP=@MaSP", conn, trans))
                                {
                                    nameCmd.Parameters.AddWithValue("@MaSP", ct.MaSP);
                                    tenSP = nameCmd.ExecuteScalar()?.ToString() ?? "";
                                }
                                throw new Exception(string.Format(
                                    "Không đủ tồn kho cho sản phẩm '{0}'! Tồn hiện tại: {1}, Yêu cầu xuất: {2}",
                                    tenSP, currentStock, ct.SoLuong));
                            }

                            using (var updateCmd = new MySqlCommand(
                                "UPDATE SanPham SET SoLuongTon = SoLuongTon - @SoLuong WHERE MaSP=@MaSP", conn, trans))
                            {
                                updateCmd.Parameters.AddWithValue("@SoLuong", ct.SoLuong);
                                updateCmd.Parameters.AddWithValue("@MaSP", ct.MaSP);
                                updateCmd.ExecuteNonQuery();
                            }

                            int tonSau = currentStock - ct.SoLuong;
                            using (var histCmd = new MySqlCommand(
                                @"INSERT INTO LichSuTonKho (MaSP, LoaiGiaoDich, SoLuongThayDoi, TonSauGiaoDich, MaPhieuXuat, MaTK, GhiChu)
                                  VALUES (@MaSP, 'XUAT', @SoLuong, @Ton, @MaPhieu, @TK, 'Xuất kho - Xác nhận phiếu')", conn, trans))
                            {
                                histCmd.Parameters.AddWithValue("@MaSP", ct.MaSP);
                                histCmd.Parameters.AddWithValue("@SoLuong", -ct.SoLuong);
                                histCmd.Parameters.AddWithValue("@Ton", tonSau);
                                histCmd.Parameters.AddWithValue("@MaPhieu", maPhieuXuat);
                                histCmd.Parameters.AddWithValue("@TK", maTKXacNhan);
                                histCmd.ExecuteNonQuery();
                            }
                        }

                        // Update status
                        using (var updateCmd = new MySqlCommand(
                            "UPDATE PhieuXuat SET TrangThai=1, NgayXacNhan=NOW(), NguoiXacNhan=@TK WHERE MaPhieuXuat=@Ma", conn, trans))
                        {
                            updateCmd.Parameters.AddWithValue("@Ma", maPhieuXuat);
                            updateCmd.Parameters.AddWithValue("@TK", maTKXacNhan);
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

        public bool HuyPhieuXuat(int maPhieuXuat, int maTKHuy)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        int currentStatus = 0;
                        using (var checkCmd = new MySqlCommand(
                            "SELECT TrangThai FROM PhieuXuat WHERE MaPhieuXuat=@Ma FOR UPDATE", conn, trans))
                        {
                            checkCmd.Parameters.AddWithValue("@Ma", maPhieuXuat);
                            currentStatus = Convert.ToInt32(checkCmd.ExecuteScalar());
                        }
                        if (currentStatus == 2) throw new Exception("Phiếu đã bị hủy trước đó!");

                        if (currentStatus == 1)
                        {
                            var chiTiet = new List<ChiTietPhieuXuat>();
                            using (var detailCmd = new MySqlCommand(
                                "SELECT MaSP, SoLuong FROM ChiTietPhieuXuat WHERE MaPhieuXuat=@Ma", conn, trans))
                            {
                                detailCmd.Parameters.AddWithValue("@Ma", maPhieuXuat);
                                using (var reader = detailCmd.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        chiTiet.Add(new ChiTietPhieuXuat
                                        {
                                            MaSP = reader.GetInt32("MaSP"),
                                            SoLuong = reader.GetInt32("SoLuong")
                                        });
                                    }
                                }
                            }

                            foreach (var ct in chiTiet)
                            {
                                using (var stockCmd = new MySqlCommand(
                                    "UPDATE SanPham SET SoLuongTon = SoLuongTon + @SoLuong WHERE MaSP=@MaSP", conn, trans))
                                {
                                    stockCmd.Parameters.AddWithValue("@SoLuong", ct.SoLuong);
                                    stockCmd.Parameters.AddWithValue("@MaSP", ct.MaSP);
                                    stockCmd.ExecuteNonQuery();
                                }

                                int tonSau = 0;
                                using (var getCmd = new MySqlCommand("SELECT SoLuongTon FROM SanPham WHERE MaSP=@MaSP", conn, trans))
                                {
                                    getCmd.Parameters.AddWithValue("@MaSP", ct.MaSP);
                                    tonSau = Convert.ToInt32(getCmd.ExecuteScalar());
                                }

                                using (var histCmd = new MySqlCommand(
                                    @"INSERT INTO LichSuTonKho (MaSP, LoaiGiaoDich, SoLuongThayDoi, TonSauGiaoDich, MaPhieuXuat, MaTK, GhiChu)
                                      VALUES (@MaSP, 'HUY_XUAT', @SoLuong, @Ton, @MaPhieu, @TK, 'Hủy phiếu xuất - Hoàn trả tồn kho')", conn, trans))
                                {
                                    histCmd.Parameters.AddWithValue("@MaSP", ct.MaSP);
                                    histCmd.Parameters.AddWithValue("@SoLuong", ct.SoLuong);
                                    histCmd.Parameters.AddWithValue("@Ton", tonSau);
                                    histCmd.Parameters.AddWithValue("@MaPhieu", maPhieuXuat);
                                    histCmd.Parameters.AddWithValue("@TK", maTKHuy);
                                    histCmd.ExecuteNonQuery();
                                }
                            }
                        }

                        using (var updateCmd = new MySqlCommand(
                            "UPDATE PhieuXuat SET TrangThai=2 WHERE MaPhieuXuat=@Ma", conn, trans))
                        {
                            updateCmd.Parameters.AddWithValue("@Ma", maPhieuXuat);
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

        public string GenerateMaPhieuXuat()
        {
            string today = DateTime.Now.ToString("yyyyMMdd");
            string prefix = "PX-" + today + "-";
            object result = DatabaseHelper.ExecuteScalar(
                "SELECT COUNT(*) FROM PhieuXuat WHERE MaPhieuXuatCode LIKE @Prefix",
                new MySqlParameter("@Prefix", prefix + "%"));
            int count = Convert.ToInt32(result) + 1;
            return prefix + count.ToString("D3");
        }

        public int GetSoPhieuTheoThang(int nam, int thang)
        {
            return Convert.ToInt32(DatabaseHelper.ExecuteScalar(
                "SELECT COUNT(*) FROM PhieuXuat WHERE YEAR(NgayXuat)=@Nam AND MONTH(NgayXuat)=@Thang AND TrangThai=1",
                new MySqlParameter("@Nam", nam), new MySqlParameter("@Thang", thang)));
        }

        public int GetSoPhieuTheoNgay(DateTime ngay)
        {
            return Convert.ToInt32(DatabaseHelper.ExecuteScalar(
                "SELECT COUNT(*) FROM PhieuXuat WHERE DATE(NgayXuat)=@Ngay AND TrangThai=1",
                new MySqlParameter("@Ngay", ngay.Date)));
        }

        public DataTable GetThongKeXuatTheoThang(int nam)
        {
            return DatabaseHelper.ExecuteReader(
                @"SELECT MONTH(NgayXuat) AS Thang, SUM(TongTien) AS TongGiaTri, COUNT(*) AS SoPhieu
                  FROM PhieuXuat WHERE YEAR(NgayXuat)=@Nam AND TrangThai=1
                  GROUP BY MONTH(NgayXuat) ORDER BY Thang",
                new MySqlParameter("@Nam", nam));
        }

        private PhieuXuat MapPhieuXuat(DataRow row)
        {
            return new PhieuXuat
            {
                MaPhieuXuat = Convert.ToInt32(row["MaPhieuXuat"]),
                MaPhieuXuatCode = row["MaPhieuXuatCode"].ToString(),
                MaKH = row["MaKH"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["MaKH"]),
                MaTK = row["MaTK"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["MaTK"]),
                NgayXuat = Convert.ToDateTime(row["NgayXuat"]),
                TongTien = Convert.ToDecimal(row["TongTien"]),
                GhiChu = row["GhiChu"] == DBNull.Value ? "" : row["GhiChu"].ToString(),
                TrangThai = Convert.ToInt32(row["TrangThai"]),
                NgayXacNhan = row["NgayXacNhan"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["NgayXacNhan"]),
                NguoiXacNhan = row["NguoiXacNhan"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["NguoiXacNhan"]),
                TenKH = row["TenKH"] == DBNull.Value ? "" : row["TenKH"].ToString(),
                TenNguoiTao = row["TenNVTao"] == DBNull.Value ? (row["TenNguoiTao"] == DBNull.Value ? "" : row["TenNguoiTao"].ToString()) : row["TenNVTao"].ToString(),
                TenNguoiXacNhan = row["TenNVXN"] == DBNull.Value ? (row["TenNguoiXN"] == DBNull.Value ? "" : row["TenNguoiXN"].ToString()) : row["TenNVXN"].ToString()
            };
        }
    }
}

