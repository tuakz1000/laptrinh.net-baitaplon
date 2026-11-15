using System;
using System.Collections.Generic;

namespace baitaplon.Models
{
    public class PhieuNhap
    {
        public int MaPhieuNhap { get; set; }
        public string MaPhieuNhapCode { get; set; }
        public int? MaNCC { get; set; }
        public int? MaTK { get; set; }
        public DateTime NgayNhap { get; set; }
        public decimal TongTien { get; set; }
        public string GhiChu { get; set; }
        public int TrangThai { get; set; }
        public DateTime? NgayXacNhan { get; set; }
        public int? NguoiXacNhan { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }

        // Navigation properties
        public string TenNCC { get; set; }
        public string TenNguoiTao { get; set; }
        public string TenNguoiXacNhan { get; set; }

        // Chi tiết phiếu nhập
        public List<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }

        public PhieuNhap()
        {
            NgayNhap = DateTime.Now;
            TrangThai = 0;
            NgayTao = DateTime.Now;
            NgayCapNhat = DateTime.Now;
            ChiTietPhieuNhaps = new List<ChiTietPhieuNhap>();
        }
    }
}
