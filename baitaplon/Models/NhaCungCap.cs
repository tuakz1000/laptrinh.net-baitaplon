using System;

namespace baitaplon.Models
{
    public class NhaCungCap
    {
        public int MaNCC { get; set; }
        public string TenNCC { get; set; }
        public string NguoiLienHe { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string MoTa { get; set; }
        public int TrangThai { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }

        public NhaCungCap()
        {
            TrangThai = 1;
            NgayTao = DateTime.Now;
            NgayCapNhat = DateTime.Now;
        }
    }
}
