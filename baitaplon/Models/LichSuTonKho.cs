using System;

namespace baitaplon.Models
{
    public class LichSuTonKho
    {
        public int MaLichSu { get; set; }
        public int MaSP { get; set; }
        public string LoaiGiaoDich { get; set; }
        public int SoLuongThayDoi { get; set; }
        public int TonSauGiaoDich { get; set; }
        public int? MaPhieuNhap { get; set; }
        public int? MaPhieuXuat { get; set; }
        public int? MaTK { get; set; }
        public string GhiChu { get; set; }
        public DateTime NgayTao { get; set; }

        // Navigation properties
        public string MaSPCode { get; set; }
        public string TenSP { get; set; }
        public string TenNguoiThucHien { get; set; }

        public LichSuTonKho()
        {
            NgayTao = DateTime.Now;
        }
    }
}
