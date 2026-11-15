using System;

namespace baitaplon.Models
{
    public class ChiTietPhieuNhap
    {
        public int MaCTPN { get; set; }
        public int MaPhieuNhap { get; set; }
        public int MaSP { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }

        // Navigation properties
        public string MaSPCode { get; set; }
        public string TenSP { get; set; }
        public string TenDVT { get; set; }

        public ChiTietPhieuNhap()
        {
        }
    }
}
