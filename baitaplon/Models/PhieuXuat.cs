using System;
using System.Collections.Generic;

namespace baitaplon.Models
{
    public class PhieuXuat
    {
        public int MaPhieuXuat { get; set; }
        public string MaPhieuXuatCode { get; set; }
        public int? MaKH { get; set; }
        public int? MaTK { get; set; }
        public DateTime NgayXuat { get; set; }
        public decimal TongTien { get; set; }
        public string GhiChu { get; set; }
        public int TrangThai { get; set; }
        public DateTime? NgayXacNhan { get; set; }
        public int? NguoiXacNhan { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }

        // Navigation properties
        public string TenKH { get; set; }
        public string TenNguoiTao { get; set; }
        public string TenNguoiXacNhan { get; set; }

        // Chi tiết phiếu xuất
        public List<ChiTietPhieuXuat> ChiTietPhieuXuats { get; set; }

        public PhieuXuat()
        {
            NgayXuat = DateTime.Now;
            TrangThai = 0;
            NgayTao = DateTime.Now;
            NgayCapNhat = DateTime.Now;
            ChiTietPhieuXuats = new List<ChiTietPhieuXuat>();
        }
    }
}
