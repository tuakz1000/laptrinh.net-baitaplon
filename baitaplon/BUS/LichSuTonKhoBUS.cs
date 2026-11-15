using System;
using System.Collections.Generic;
using baitaplon.DAL;
using baitaplon.Models;

namespace baitaplon.BUS
{
    /// <summary>
    /// Lớp xử lý nghiệp vụ cho Lịch sử tồn kho
    /// </summary>
    public class LichSuTonKhoBUS
    {
        private readonly LichSuTonKhoDAL _lichSuTonKhoDAL;

        public LichSuTonKhoBUS()
        {
            _lichSuTonKhoDAL = new LichSuTonKhoDAL();
        }

        /// <summary>
        /// Lấy lịch sử tồn kho theo sản phẩm
        /// </summary>
        /// <param name="maSP">Mã sản phẩm</param>
        public List<LichSuTonKho> GetBySanPham(int maSP)
        {
            return _lichSuTonKhoDAL.GetBySanPham(maSP);
        }

        /// <summary>
        /// Lấy tất cả lịch sử tồn kho với bộ lọc ngày
        /// </summary>
        /// <param name="tuNgay">Ngày bắt đầu</param>
        /// <param name="denNgay">Ngày kết thúc</param>
        public List<LichSuTonKho> GetAll(DateTime? tuNgay, DateTime? denNgay)
        {
            return _lichSuTonKhoDAL.GetAll(tuNgay, denNgay);
        }
    }
}
