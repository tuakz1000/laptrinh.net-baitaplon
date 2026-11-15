using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using baitaplon.DAL;
using baitaplon.Models;

namespace baitaplon.BUS
{
    /// <summary>
    /// Lớp xử lý nghiệp vụ cho Nhân viên
    /// </summary>
    public class NhanVienBUS
    {
        private readonly NhanVienDAL _nhanVienDAL;

        public NhanVienBUS()
        {
            _nhanVienDAL = new NhanVienDAL();
        }

        /// <summary>
        /// Lấy danh sách tất cả nhân viên
        /// </summary>
        public List<NhanVien> GetAll()
        {
            return _nhanVienDAL.GetAll();
        }

        /// <summary>
        /// Lấy nhân viên theo mã
        /// </summary>
        /// <param name="maNV">Mã nhân viên</param>
        public NhanVien GetById(int maNV)
        {
            return _nhanVienDAL.GetById(maNV);
        }

        /// <summary>
        /// Thêm nhân viên mới
        /// </summary>
        /// <param name="nv">Đối tượng nhân viên</param>
        public void ThemNhanVien(NhanVien nv)
        {
            ValidateNhanVien(nv);
            _nhanVienDAL.Insert(nv);
        }

        /// <summary>
        /// Cập nhật thông tin nhân viên
        /// </summary>
        /// <param name="nv">Đối tượng nhân viên cần cập nhật</param>
        public void CapNhatNhanVien(NhanVien nv)
        {
            if (nv.MaNV <= 0)
                throw new Exception("Mã nhân viên không hợp lệ.");

            NhanVien existing = _nhanVienDAL.GetById(nv.MaNV);
            if (existing == null)
                throw new Exception("Không tìm thấy nhân viên cần cập nhật.");

            ValidateNhanVien(nv);
            _nhanVienDAL.Update(nv);
        }

        /// <summary>
        /// Đánh dấu nhân viên nghỉ việc (TrangThai = 0)
        /// </summary>
        /// <param name="maNV">Mã nhân viên</param>
        public void NghiViec(int maNV)
        {
            NhanVien nv = _nhanVienDAL.GetById(maNV);
            if (nv == null)
                throw new Exception("Không tìm thấy nhân viên.");

            if (nv.TrangThai == 0)
                throw new Exception("Nhân viên này đã nghỉ việc.");

            _nhanVienDAL.UpdateTrangThai(maNV, 0);
        }

        /// <summary>
        /// Validate thông tin nhân viên
        /// </summary>
        /// <param name="nv">Đối tượng nhân viên cần validate</param>
        private void ValidateNhanVien(NhanVien nv)
        {
            if (string.IsNullOrWhiteSpace(nv.HoTen))
                throw new Exception("Họ tên nhân viên không được để trống.");

            if (nv.HoTen.Length > 100)
                throw new Exception("Họ tên nhân viên không được vượt quá 100 ký tự.");

            if (!string.IsNullOrWhiteSpace(nv.SoDienThoai))
            {
                // Kiểm tra định dạng số điện thoại Việt Nam
                string pattern = @"^(0[1-9][0-9]{8,9})$";
                if (!Regex.IsMatch(nv.SoDienThoai.Trim(), pattern))
                    throw new Exception("Số điện thoại không đúng định dạng. Vui lòng nhập số điện thoại hợp lệ (VD: 0901234567).");
            }

            if (!string.IsNullOrWhiteSpace(nv.Email))
            {
                string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                if (!Regex.IsMatch(nv.Email.Trim(), emailPattern))
                    throw new Exception("Email không đúng định dạng.");
            }

            if (nv.NgaySinh.HasValue && nv.NgaySinh.Value > DateTime.Now)
                throw new Exception("Ngày sinh không được lớn hơn ngày hiện tại.");
        }
    }
}
