using System;

namespace baitaplon.Models
{
    public class NhanVien
    {
        public int MaNV { get; set; }
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string ChucVu { get; set; }
        public int TrangThai { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }

        public NhanVien()
        {
            TrangThai = 1;
            NgayTao = DateTime.Now;
            NgayCapNhat = DateTime.Now;
        }
    }
}
