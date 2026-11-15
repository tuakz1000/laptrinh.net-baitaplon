using System;
using System.Collections.Generic;
using baitaplon.DAL;
using baitaplon.Models;

namespace baitaplon.BUS
{
    /// <summary>
    /// Lớp xử lý nghiệp vụ cho Đơn vị tính
    /// </summary>
    public class DonViTinhBUS
    {
        private readonly DonViTinhDAL _donViTinhDAL;

        public DonViTinhBUS()
        {
            _donViTinhDAL = new DonViTinhDAL();
        }

        /// <summary>
        /// Lấy tất cả đơn vị tính
        /// </summary>
        public List<DonViTinh> GetAll()
        {
            return _donViTinhDAL.GetAll();
        }

        /// <summary>
        /// Lấy danh sách đơn vị tính đang hoạt động
        /// </summary>
        public List<DonViTinh> GetAllActive()
        {
            return _donViTinhDAL.GetAllActive();
        }

        /// <summary>
        /// Thêm đơn vị tính mới
        /// </summary>
        /// <param name="dvt">Đối tượng đơn vị tính</param>
        public void ThemDonViTinh(DonViTinh dvt)
        {
            ValidateDonViTinh(dvt);

            // Kiểm tra trùng tên
            if (_donViTinhDAL.KiemTraTrung(dvt.TenDVT, 0))
                throw new Exception("Tên đơn vị tính đã tồn tại trong hệ thống.");

            _donViTinhDAL.Insert(dvt);
        }

        /// <summary>
        /// Cập nhật đơn vị tính
        /// </summary>
        /// <param name="dvt">Đối tượng đơn vị tính cần cập nhật</param>
        public void CapNhatDonViTinh(DonViTinh dvt)
        {
            if (dvt.MaDVT <= 0)
                throw new Exception("Mã đơn vị tính không hợp lệ.");

            ValidateDonViTinh(dvt);

            // Kiểm tra trùng tên (trừ chính nó)
            if (_donViTinhDAL.KiemTraTrung(dvt.TenDVT, dvt.MaDVT))
                throw new Exception("Tên đơn vị tính đã tồn tại trong hệ thống.");

            _donViTinhDAL.Update(dvt);
        }

        /// <summary>
        /// Cập nhật trạng thái đơn vị tính
        /// </summary>
        /// <param name="maDVT">Mã đơn vị tính</param>
        /// <param name="trangThai">Trạng thái mới (1=Hoạt động, 0=Ẩn)</param>
        public void AnDonViTinh(int maDVT, int trangThai)
        {
            DonViTinh dvt = _donViTinhDAL.GetById(maDVT);
            if (dvt == null)
                throw new Exception("Không tìm thấy đơn vị tính.");

            if (dvt.TrangThai == trangThai)
                return;

            _donViTinhDAL.UpdateTrangThai(maDVT, trangThai);
        }

        /// <summary>
        /// Validate thông tin đơn vị tính
        /// </summary>
        private void ValidateDonViTinh(DonViTinh dvt)
        {
            if (string.IsNullOrWhiteSpace(dvt.TenDVT))
                throw new Exception("Tên đơn vị tính không được để trống.");

            if (dvt.TenDVT.Length > 50)
                throw new Exception("Tên đơn vị tính không được vượt quá 50 ký tự.");
        }
    }
}
