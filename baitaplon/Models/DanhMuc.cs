using System;

namespace baitaplon.Models
{
    public class DanhMuc
    {
        public int MaDanhMuc { get; set; }
        public string TenDanhMuc { get; set; }
        public string MoTa { get; set; }
        public int TrangThai { get; set; }
        public DateTime NgayTao { get; set; }

        public DanhMuc()
        {
            TrangThai = 1;
            NgayTao = DateTime.Now;
        }
    }
}
