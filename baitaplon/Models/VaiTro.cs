using System;

namespace baitaplon.Models
{
    public class VaiTro
    {
        public int MaVaiTro { get; set; }
        public string TenVaiTro { get; set; }
        public string MoTa { get; set; }
        public DateTime NgayTao { get; set; }

        public VaiTro()
        {
            NgayTao = DateTime.Now;
        }
    }
}
