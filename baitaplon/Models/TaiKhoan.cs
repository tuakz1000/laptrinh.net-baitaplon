using System;

namespace baitaplon.Models
{
    public class TaiKhoan
    {
        public int MaTK { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public int? MaNV { get; set; }
        public int MaVaiTro { get; set; }
        public int TrangThai { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }

        // Navigation properties
        public string TenNhanVien { get; set; }
        public string TenVaiTro { get; set; }

        public TaiKhoan()
        {
            TrangThai = 1;
            NgayTao = DateTime.Now;
            NgayCapNhat = DateTime.Now;
        }
    }
}
