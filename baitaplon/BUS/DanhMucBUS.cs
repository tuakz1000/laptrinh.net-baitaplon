using System;
using System.Collections.Generic;
using baitaplon.DAL;
using baitaplon.Models;

namespace baitaplon.BUS
{
    /// <summary>
    /// Lớp xử lý nghiệp vụ cho Danh mục sản phẩm
    /// </summary>
    public class DanhMucBUS
    {
        private readonly DanhMucDAL _danhMucDAL;

        public DanhMucBUS()
        {
            _danhMucDAL = new DanhMucDAL();
        }

        /// <summary>
        /// Lấy tất cả danh mục
        /// </summary>
        public List<DanhMuc> GetAll()
        {
            return _danhMucDAL.GetAll();
        }

        /// <summary>
        /// Lấy danh sách danh mục đang hoạt động
        /// </summary>
        public List<DanhMuc> GetAllActive()
        {
            return _danhMucDAL.GetAllActive();
        }

        /// <summary>
        /// Thêm danh mục mới
        /// </summary>
        /// <param name="dm">Đối tượng danh mục</param>
        public void ThemDanhMuc(DanhMuc dm)
        {
            ValidateDanhMuc(dm);

            // Kiểm tra trùng tên
            if (_danhMucDAL.KiemTraTrung(dm.TenDanhMuc, 0))
                throw new Exception("Tên danh mục đã tồn tại trong hệ thống.");

            _danhMucDAL.Insert(dm);
        }

        /// <summary>
        /// Cập nhật danh mục
        /// </summary>
        /// <param name="dm">Đối tượng danh mục cần cập nhật</param>
        public void CapNhatDanhMuc(DanhMuc dm)
        {
            if (dm.MaDanhMuc <= 0)
                throw new Exception("Mã danh mục không hợp lệ.");

            ValidateDanhMuc(dm);

            // Kiểm tra trùng tên (trừ chính nó)
            if (_danhMucDAL.KiemTraTrung(dm.TenDanhMuc, dm.MaDanhMuc))
                throw new Exception("Tên danh mục đã tồn tại trong hệ thống.");

            _danhMucDAL.Update(dm);
        }

        /// <summary>
        /// Cập nhật trạng thái danh mục
        /// </summary>
        /// <param name="maDanhMuc">Mã danh mục</param>
        /// <param name="trangThai">Trạng thái mới (1=Hoạt động, 0=Ẩn)</param>
        public void AnDanhMuc(int maDanhMuc, int trangThai)
        {
            DanhMuc dm = _danhMucDAL.GetById(maDanhMuc);
            if (dm == null)
                throw new Exception("Không tìm thấy danh mục.");

            if (dm.TrangThai == trangThai)
                return;

            _danhMucDAL.UpdateTrangThai(maDanhMuc, trangThai);
        }

        /// <summary>
        /// Validate thông tin danh mục
        /// </summary>
        private void ValidateDanhMuc(DanhMuc dm)
        {
            if (string.IsNullOrWhiteSpace(dm.TenDanhMuc))
                throw new Exception("Tên danh mục không được để trống.");

            if (dm.TenDanhMuc.Length > 100)
                throw new Exception("Tên danh mục không được vượt quá 100 ký tự.");
        }
    }
}
