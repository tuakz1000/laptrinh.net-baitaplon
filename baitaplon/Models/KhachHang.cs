using System;

namespace baitaplon.Models
{
    public class KhachHang
    {
        public int MaKH { get; set; }
        public string TenKH { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string MoTa { get; set; }
        public int TrangThai { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }

        public KhachHang()
        {
            TrangThai = 1;
            NgayTao = DateTime.Now;
            NgayCapNhat = DateTime.Now;
        }
    }
}
