using System;
using System.Collections.Generic;
using System.Data;
using MySqlConnector;
using baitaplon.Models;

namespace baitaplon.DAL
{
    public class LichSuTonKhoDAL
    {
        public List<LichSuTonKho> GetBySanPham(int maSP)
        {
            string query = @"SELECT ls.*, sp.MaSPCode, sp.TenSP, nv.HoTen AS TenNguoiThucHien
                             FROM LichSuTonKho ls
                             JOIN SanPham sp ON ls.MaSP = sp.MaSP
                             LEFT JOIN TaiKhoan tk ON ls.MaTK = tk.MaTK
                             LEFT JOIN NhanVien nv ON tk.MaNV = nv.MaNV
                             WHERE ls.MaSP = @MaSP ORDER BY ls.NgayTao DESC";
            var list = new List<LichSuTonKho>();
            DataTable dt = DatabaseHelper.ExecuteReader(query, new MySqlParameter("@MaSP", maSP));
            foreach (DataRow row in dt.Rows) list.Add(MapRow(row));
            return list;
        }

        public List<LichSuTonKho> GetAll(DateTime? tuNgay, DateTime? denNgay)
        {
            string query = @"SELECT ls.*, sp.MaSPCode, sp.TenSP, nv.HoTen AS TenNguoiThucHien
                             FROM LichSuTonKho ls
                             JOIN SanPham sp ON ls.MaSP = sp.MaSP
                             LEFT JOIN TaiKhoan tk ON ls.MaTK = tk.MaTK
                             LEFT JOIN NhanVien nv ON tk.MaNV = nv.MaNV WHERE 1=1";
            var parms = new List<MySqlParameter>();
            if (tuNgay.HasValue) { query += " AND ls.NgayTao >= @Tu"; parms.Add(new MySqlParameter("@Tu", tuNgay.Value.Date)); }
            if (denNgay.HasValue) { query += " AND ls.NgayTao < @Den"; parms.Add(new MySqlParameter("@Den", denNgay.Value.Date.AddDays(1))); }
            query += " ORDER BY ls.NgayTao DESC";
            var list = new List<LichSuTonKho>();
            DataTable dt = DatabaseHelper.ExecuteReader(query, parms.ToArray());
            foreach (DataRow row in dt.Rows) list.Add(MapRow(row));
            return list;
        }

        private LichSuTonKho MapRow(DataRow row)
        {
            return new LichSuTonKho
            {
                MaLichSu = Convert.ToInt32(row["MaLichSu"]),
                MaSP = Convert.ToInt32(row["MaSP"]),
                LoaiGiaoDich = row["LoaiGiaoDich"].ToString(),
                SoLuongThayDoi = Convert.ToInt32(row["SoLuongThayDoi"]),
                TonSauGiaoDich = Convert.ToInt32(row["TonSauGiaoDich"]),
                MaPhieuNhap = row["MaPhieuNhap"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["MaPhieuNhap"]),
                MaPhieuXuat = row["MaPhieuXuat"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["MaPhieuXuat"]),
                MaTK = row["MaTK"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["MaTK"]),
                GhiChu = row["GhiChu"] == DBNull.Value ? "" : row["GhiChu"].ToString(),
                NgayTao = Convert.ToDateTime(row["NgayTao"]),
                MaSPCode = row["MaSPCode"].ToString(),
                TenSP = row["TenSP"].ToString(),
                TenNguoiThucHien = row["TenNguoiThucHien"] == DBNull.Value ? "" : row["TenNguoiThucHien"].ToString()
            };
        }
    }
}

