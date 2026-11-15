using System;

namespace baitaplon.Models
{
    public class DonViTinh
    {
        public int MaDVT { get; set; }
        public string TenDVT { get; set; }
        public string MoTa { get; set; }
        public int TrangThai { get; set; }

        public DonViTinh()
        {
            TrangThai = 1;
        }
    }
}
