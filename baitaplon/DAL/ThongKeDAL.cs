using System;
using System.Data;
using MySqlConnector;

namespace baitaplon.DAL
{
    public class ThongKeDAL
    {
        public int GetTongSanPham()
        {
            return Convert.ToInt32(DatabaseHelper.ExecuteScalar("SELECT COUNT(*) FROM SanPham WHERE TrangThai=1"));
        }

        public int GetTongSoLuongTon()
        {
            object result = DatabaseHelper.ExecuteScalar("SELECT COALESCE(SUM(SoLuongTon),0) FROM SanPham WHERE TrangThai=1");
            return Convert.ToInt32(result);
        }

        public decimal GetTongGiaTriTon()
        {
            object result = DatabaseHelper.ExecuteScalar("SELECT COALESCE(SUM(SoLuongTon * GiaNhap),0) FROM SanPham WHERE TrangThai=1");
            return Convert.ToDecimal(result);
        }

        public int GetSoPhieuNhapHomNay()
        {
            return Convert.ToInt32(DatabaseHelper.ExecuteScalar(
                "SELECT COUNT(*) FROM PhieuNhap WHERE DATE(NgayNhap)=CURDATE() AND TrangThai=1"));
        }

        public int GetSoPhieuXuatHomNay()
        {
            return Convert.ToInt32(DatabaseHelper.ExecuteScalar(
                "SELECT COUNT(*) FROM PhieuXuat WHERE DATE(NgayXuat)=CURDATE() AND TrangThai=1"));
        }

        public int GetSoPhieuNhapThang()
        {
            return Convert.ToInt32(DatabaseHelper.ExecuteScalar(
                "SELECT COUNT(*) FROM PhieuNhap WHERE YEAR(NgayNhap)=YEAR(CURDATE()) AND MONTH(NgayNhap)=MONTH(CURDATE()) AND TrangThai=1"));
        }

        public int GetSoPhieuXuatThang()
        {
            return Convert.ToInt32(DatabaseHelper.ExecuteScalar(
                "SELECT COUNT(*) FROM PhieuXuat WHERE YEAR(NgayXuat)=YEAR(CURDATE()) AND MONTH(NgayXuat)=MONTH(CURDATE()) AND TrangThai=1"));
        }

        public DataTable GetBieuDoNhapXuat(int nam)
        {
            string query = @"
                SELECT m.Thang,
                       COALESCE(n.TongNhap, 0) AS TongNhap,
                       COALESCE(x.TongXuat, 0) AS TongXuat
                FROM (SELECT 1 AS Thang UNION SELECT 2 UNION SELECT 3 UNION SELECT 4
                      UNION SELECT 5 UNION SELECT 6 UNION SELECT 7 UNION SELECT 8
                      UNION SELECT 9 UNION SELECT 10 UNION SELECT 11 UNION SELECT 12) m
                LEFT JOIN (SELECT MONTH(NgayNhap) AS Thang, SUM(TongTien) AS TongNhap
                           FROM PhieuNhap WHERE YEAR(NgayNhap)=@Nam AND TrangThai=1
                           GROUP BY MONTH(NgayNhap)) n ON m.Thang = n.Thang
                LEFT JOIN (SELECT MONTH(NgayXuat) AS Thang, SUM(TongTien) AS TongXuat
                           FROM PhieuXuat WHERE YEAR(NgayXuat)=@Nam AND TrangThai=1
                           GROUP BY MONTH(NgayXuat)) x ON m.Thang = x.Thang
                ORDER BY m.Thang";
            return DatabaseHelper.ExecuteReader(query, new MySqlParameter("@Nam", nam));
        }

        public DataTable GetBieuDoTheoDanhMuc()
        {
            string query = @"SELECT COALESCE(dm.TenDanhMuc, 'Chưa phân loại') AS DanhMuc, 
                             COUNT(*) AS SoLuong, SUM(sp.SoLuongTon) AS TongTon
                             FROM SanPham sp LEFT JOIN DanhMuc dm ON sp.MaDanhMuc = dm.MaDanhMuc
                             WHERE sp.TrangThai=1 GROUP BY dm.TenDanhMuc ORDER BY SoLuong DESC";
            return DatabaseHelper.ExecuteReader(query);
        }

        public int GetSoSanPhamSapHet()
        {
            return Convert.ToInt32(DatabaseHelper.ExecuteScalar(
                "SELECT COUNT(*) FROM SanPham WHERE TrangThai=1 AND SoLuongTon > 0 AND SoLuongTon <= TonToiThieu"));
        }

        public int GetSoSanPhamHetHang()
        {
            return Convert.ToInt32(DatabaseHelper.ExecuteScalar(
                "SELECT COUNT(*) FROM SanPham WHERE TrangThai=1 AND SoLuongTon = 0"));
        }

        public int GetTongSoSanPham()
        {
            return GetTongSanPham();
        }

        public int GetTongSoPhieuNhap(DateTime? tuNgay, DateTime? denNgay)
        {
            string query = "SELECT COUNT(*) FROM PhieuNhap WHERE TrangThai=1";
            var p = new System.Collections.Generic.List<MySqlParameter>();
            if (tuNgay.HasValue) { query += " AND NgayNhap >= @Tu"; p.Add(new MySqlParameter("@Tu", tuNgay.Value.Date)); }
            if (denNgay.HasValue) { query += " AND NgayNhap < @Den"; p.Add(new MySqlParameter("@Den", denNgay.Value.Date.AddDays(1))); }
            return Convert.ToInt32(DatabaseHelper.ExecuteScalar(query, p.ToArray()));
        }

        public int GetTongSoPhieuXuat(DateTime? tuNgay, DateTime? denNgay)
        {
            string query = "SELECT COUNT(*) FROM PhieuXuat WHERE TrangThai=1";
            var p = new System.Collections.Generic.List<MySqlParameter>();
            if (tuNgay.HasValue) { query += " AND NgayXuat >= @Tu"; p.Add(new MySqlParameter("@Tu", tuNgay.Value.Date)); }
            if (denNgay.HasValue) { query += " AND NgayXuat < @Den"; p.Add(new MySqlParameter("@Den", denNgay.Value.Date.AddDays(1))); }
            return Convert.ToInt32(DatabaseHelper.ExecuteScalar(query, p.ToArray()));
        }

        public decimal GetTongGiaTriNhap(DateTime? tuNgay, DateTime? denNgay)
        {
            string query = "SELECT COALESCE(SUM(TongTien),0) FROM PhieuNhap WHERE TrangThai=1";
            var p = new System.Collections.Generic.List<MySqlParameter>();
            if (tuNgay.HasValue) { query += " AND NgayNhap >= @Tu"; p.Add(new MySqlParameter("@Tu", tuNgay.Value.Date)); }
            if (denNgay.HasValue) { query += " AND NgayNhap < @Den"; p.Add(new MySqlParameter("@Den", denNgay.Value.Date.AddDays(1))); }
            return Convert.ToDecimal(DatabaseHelper.ExecuteScalar(query, p.ToArray()));
        }

        public decimal GetTongGiaTriXuat(DateTime? tuNgay, DateTime? denNgay)
        {
            string query = "SELECT COALESCE(SUM(TongTien),0) FROM PhieuXuat WHERE TrangThai=1";
            var p = new System.Collections.Generic.List<MySqlParameter>();
            if (tuNgay.HasValue) { query += " AND NgayXuat >= @Tu"; p.Add(new MySqlParameter("@Tu", tuNgay.Value.Date)); }
            if (denNgay.HasValue) { query += " AND NgayXuat < @Den"; p.Add(new MySqlParameter("@Den", denNgay.Value.Date.AddDays(1))); }
            return Convert.ToDecimal(DatabaseHelper.ExecuteScalar(query, p.ToArray()));
        }

        public decimal GetTongGiaTriTonKho()
        {
            return GetTongGiaTriTon();
        }

        public DataTable GetThongKeNhapXuatTheoThang(int nam)
        {
            string query = @"
                SELECT m.Thang,
                       COALESCE(n.TongNhap, 0) AS TongNhap,
                       COALESCE(x.TongXuat, 0) AS TongXuat
                FROM (SELECT 1 AS Thang UNION SELECT 2 UNION SELECT 3 UNION SELECT 4
                      UNION SELECT 5 UNION SELECT 6 UNION SELECT 7 UNION SELECT 8
                      UNION SELECT 9 UNION SELECT 10 UNION SELECT 11 UNION SELECT 12) m
                LEFT JOIN (SELECT MONTH(NgayNhap) AS Thang, SUM(TongTien) AS TongNhap
                           FROM PhieuNhap WHERE YEAR(NgayNhap)=@Nam AND TrangThai=1
                           GROUP BY MONTH(NgayNhap)) n ON m.Thang = n.Thang
                LEFT JOIN (SELECT MONTH(NgayXuat) AS Thang, SUM(TongTien) AS TongXuat
                           FROM PhieuXuat WHERE YEAR(NgayXuat)=@Nam AND TrangThai=1
                           GROUP BY MONTH(NgayXuat)) x ON m.Thang = x.Thang
                ORDER BY m.Thang";
            return DatabaseHelper.ExecuteReader(query, new MySqlParameter("@Nam", nam));
        }

        public DataTable GetTopSanPhamTonKho(int top)
        {
            string query = @"
                SELECT sp.MaSPCode, sp.TenSP, sp.SoLuongTon,
                       (sp.SoLuongTon * sp.GiaNhap) AS GiaTriTon
                FROM SanPham sp WHERE sp.TrangThai=1
                ORDER BY sp.SoLuongTon DESC
                LIMIT @Top";
            return DatabaseHelper.ExecuteReader(query, new MySqlParameter("@Top", top));
        }

        public DataTable GetThongKeTheoDanhMuc()
        {
            string query = @"SELECT COALESCE(dm.TenDanhMuc, 'Chưa phân loại') AS DanhMuc,
                             COUNT(*) AS SoLuong, SUM(sp.SoLuongTon) AS TongTon
                             FROM SanPham sp LEFT JOIN DanhMuc dm ON sp.MaDanhMuc = dm.MaDanhMuc
                             WHERE sp.TrangThai=1 GROUP BY dm.TenDanhMuc ORDER BY SoLuong DESC";
            return DatabaseHelper.ExecuteReader(query);
        }

        public DataTable GetThongKeTheoNhaCungCap(DateTime? tuNgay, DateTime? denNgay)
        {
            string query = @"
                SELECT ncc.TenNCC, COUNT(pn.MaPhieuNhap) AS SoPhieu,
                       COALESCE(SUM(pn.TongTien),0) AS TongTien
                FROM PhieuNhap pn
                LEFT JOIN NhaCungCap ncc ON pn.MaNCC = ncc.MaNCC
                WHERE pn.TrangThai=1";
            var p = new System.Collections.Generic.List<MySqlParameter>();
            if (tuNgay.HasValue) { query += " AND pn.NgayNhap >= @Tu"; p.Add(new MySqlParameter("@Tu", tuNgay.Value.Date)); }
            if (denNgay.HasValue) { query += " AND pn.NgayNhap < @Den"; p.Add(new MySqlParameter("@Den", denNgay.Value.Date.AddDays(1))); }
            query += " GROUP BY ncc.TenNCC ORDER BY TongTien DESC";
            return DatabaseHelper.ExecuteReader(query, p.ToArray());
        }

        public DataTable GetThongKeTheoKhachHang(DateTime? tuNgay, DateTime? denNgay)
        {
            string query = @"
                SELECT kh.TenKH, COUNT(px.MaPhieuXuat) AS SoPhieu,
                       COALESCE(SUM(px.TongTien),0) AS TongTien
                FROM PhieuXuat px
                LEFT JOIN KhachHang kh ON px.MaKH = kh.MaKH
                WHERE px.TrangThai=1";
            var p = new System.Collections.Generic.List<MySqlParameter>();
            if (tuNgay.HasValue) { query += " AND px.NgayXuat >= @Tu"; p.Add(new MySqlParameter("@Tu", tuNgay.Value.Date)); }
            if (denNgay.HasValue) { query += " AND px.NgayXuat < @Den"; p.Add(new MySqlParameter("@Den", denNgay.Value.Date.AddDays(1))); }
            query += " GROUP BY kh.TenKH ORDER BY TongTien DESC";
            return DatabaseHelper.ExecuteReader(query, p.ToArray());
        }

        public DataTable GetDoanhThuLoiNhuanTheoThang(int nam)
        {
            string query = @"
                SELECT m.Thang,
                       COALESCE(x.TongXuat, 0) AS DoanhThu,
                       COALESCE(n.TongNhap, 0) AS ChiPhi,
                       (COALESCE(x.TongXuat, 0) - COALESCE(n.TongNhap, 0)) AS LoiNhuan
                FROM (SELECT 1 AS Thang UNION SELECT 2 UNION SELECT 3 UNION SELECT 4
                      UNION SELECT 5 UNION SELECT 6 UNION SELECT 7 UNION SELECT 8
                      UNION SELECT 9 UNION SELECT 10 UNION SELECT 11 UNION SELECT 12) m
                LEFT JOIN (SELECT MONTH(NgayNhap) AS Thang, SUM(TongTien) AS TongNhap
                           FROM PhieuNhap WHERE YEAR(NgayNhap)=@Nam AND TrangThai=1
                           GROUP BY MONTH(NgayNhap)) n ON m.Thang = n.Thang
                LEFT JOIN (SELECT MONTH(NgayXuat) AS Thang, SUM(TongTien) AS TongXuat
                           FROM PhieuXuat WHERE YEAR(NgayXuat)=@Nam AND TrangThai=1
                           GROUP BY MONTH(NgayXuat)) x ON m.Thang = x.Thang
                ORDER BY m.Thang";
            return DatabaseHelper.ExecuteReader(query, new MySqlParameter("@Nam", nam));
        }

        public DataTable GetPhieuNhapGanDay(int top)
        {
            string query = @"
                SELECT pn.MaPhieuNhap, pn.MaPhieuNhapCode, ncc.TenNCC, pn.NgayNhap,
                       pn.TongTien, pn.TrangThai
                FROM PhieuNhap pn
                LEFT JOIN NhaCungCap ncc ON pn.MaNCC = ncc.MaNCC
                ORDER BY pn.NgayNhap DESC LIMIT @Top";
            return DatabaseHelper.ExecuteReader(query, new MySqlParameter("@Top", top));
        }

        public DataTable GetPhieuXuatGanDay(int top)
        {
            string query = @"
                SELECT px.MaPhieuXuat, px.MaPhieuXuatCode, kh.TenKH, px.NgayXuat,
                       px.TongTien, px.TrangThai
                FROM PhieuXuat px
                LEFT JOIN KhachHang kh ON px.MaKH = kh.MaKH
                ORDER BY px.NgayXuat DESC LIMIT @Top";
            return DatabaseHelper.ExecuteReader(query, new MySqlParameter("@Top", top));
        }
    }
}

