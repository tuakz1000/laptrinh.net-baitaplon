using System;

namespace baitaplon.Models
{
    public class SanPham
    {
        public int MaSP { get; set; }
        public string MaSPCode { get; set; }
        public string TenSP { get; set; }
        public int? MaDanhMuc { get; set; }
        public int? MaDVT { get; set; }
        public decimal GiaNhap { get; set; }
        public decimal GiaBan { get; set; }
        public int SoLuongTon { get; set; }
        public int TonToiThieu { get; set; }
        public string HinhAnh { get; set; }
        public string MoTa { get; set; }
        public int TrangThai { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }

        // Navigation properties
        public string TenDanhMuc { get; set; }
        public string TenDVT { get; set; }

        public SanPham()
        {
            TrangThai = 1;
            NgayTao = DateTime.Now;
            NgayCapNhat = DateTime.Now;
        }
    }
}
