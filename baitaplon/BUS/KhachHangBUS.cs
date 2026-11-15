using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using baitaplon.DAL;
using baitaplon.Models;

namespace baitaplon.BUS
{
    /// <summary>
    /// Lớp xử lý nghiệp vụ cho Khách hàng
    /// </summary>
    public class KhachHangBUS
    {
        private readonly KhachHangDAL _khachHangDAL;

        public KhachHangBUS()
        {
            _khachHangDAL = new KhachHangDAL();
        }

        /// <summary>
        /// Lấy tất cả khách hàng
        /// </summary>
        public List<KhachHang> GetAll()
        {
            return _khachHangDAL.GetAll();
        }

        /// <summary>
        /// Lấy danh sách khách hàng đang hoạt động
        /// </summary>
        public List<KhachHang> GetAllActive()
        {
            return _khachHangDAL.GetAllActive();
        }

        /// <summary>
        /// Lấy khách hàng theo mã
        /// </summary>
        /// <param name="maKH">Mã khách hàng</param>
        public KhachHang GetById(int maKH)
        {
            return _khachHangDAL.GetById(maKH);
        }

        /// <summary>
        /// Tìm kiếm khách hàng
        /// </summary>
        /// <param name="keyword">Từ khóa tìm kiếm</param>
        public List<KhachHang> Search(string keyword)
        {
            return _khachHangDAL.Search(keyword);
        }

        /// <summary>
        /// Thêm khách hàng mới
        /// </summary>
        /// <param name="kh">Đối tượng khách hàng</param>
        public void ThemKhachHang(KhachHang kh)
        {
            ValidateKhachHang(kh);
            _khachHangDAL.Insert(kh);
        }

        /// <summary>
        /// Cập nhật khách hàng
        /// </summary>
        /// <param name="kh">Đối tượng khách hàng cần cập nhật</param>
        public void CapNhatKhachHang(KhachHang kh)
        {
            if (kh.MaKH <= 0)
                throw new Exception("Mã khách hàng không hợp lệ.");

            KhachHang existing = _khachHangDAL.GetById(kh.MaKH);
            if (existing == null)
                throw new Exception("Không tìm thấy khách hàng cần cập nhật.");

            ValidateKhachHang(kh);
            _khachHangDAL.Update(kh);
        }

        /// <summary>
        /// Ngừng giao dịch với khách hàng (đặt TrangThai = 0)
        /// </summary>
        /// <param name="maKH">Mã khách hàng</param>
        public void NgungGiaoDich(int maKH)
        {
            KhachHang kh = _khachHangDAL.GetById(maKH);
            if (kh == null)
                throw new Exception("Không tìm thấy khách hàng.");

            if (kh.TrangThai == 0)
                throw new Exception("Khách hàng này đã ngừng giao dịch.");

            _khachHangDAL.UpdateTrangThai(maKH, 0);
        }

        /// <summary>
        /// Validate thông tin khách hàng
        /// </summary>
        private void ValidateKhachHang(KhachHang kh)
        {
            if (string.IsNullOrWhiteSpace(kh.TenKH))
                throw new Exception("Tên khách hàng không được để trống.");

            if (kh.TenKH.Length > 200)
                throw new Exception("Tên khách hàng không được vượt quá 200 ký tự.");

            if (!string.IsNullOrWhiteSpace(kh.SoDienThoai))
            {
                string pattern = @"^(0[1-9][0-9]{8,9})$";
                if (!Regex.IsMatch(kh.SoDienThoai.Trim(), pattern))
                    throw new Exception("Số điện thoại không đúng định dạng. Vui lòng nhập số điện thoại hợp lệ (VD: 0901234567).");
            }

            if (!string.IsNullOrWhiteSpace(kh.Email))
            {
                string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                if (!Regex.IsMatch(kh.Email.Trim(), emailPattern))
                    throw new Exception("Email không đúng định dạng.");
            }
        }
    }
}
