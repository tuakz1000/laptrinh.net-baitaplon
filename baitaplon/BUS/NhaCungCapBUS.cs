using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using baitaplon.DAL;
using baitaplon.Models;

namespace baitaplon.BUS
{
    /// <summary>
    /// Lớp xử lý nghiệp vụ cho Nhà cung cấp
    /// </summary>
    public class NhaCungCapBUS
    {
        private readonly NhaCungCapDAL _nhaCungCapDAL;

        public NhaCungCapBUS()
        {
            _nhaCungCapDAL = new NhaCungCapDAL();
        }

        /// <summary>
        /// Lấy tất cả nhà cung cấp
        /// </summary>
        public List<NhaCungCap> GetAll()
        {
            return _nhaCungCapDAL.GetAll();
        }

        /// <summary>
        /// Lấy danh sách nhà cung cấp đang hoạt động
        /// </summary>
        public List<NhaCungCap> GetAllActive()
        {
            return _nhaCungCapDAL.GetAllActive();
        }

        /// <summary>
        /// Lấy nhà cung cấp theo mã
        /// </summary>
        /// <param name="maNCC">Mã nhà cung cấp</param>
        public NhaCungCap GetById(int maNCC)
        {
            return _nhaCungCapDAL.GetById(maNCC);
        }

        /// <summary>
        /// Tìm kiếm nhà cung cấp
        /// </summary>
        /// <param name="keyword">Từ khóa tìm kiếm</param>
        public List<NhaCungCap> Search(string keyword)
        {
            return _nhaCungCapDAL.Search(keyword);
        }

        /// <summary>
        /// Thêm nhà cung cấp mới
        /// </summary>
        /// <param name="ncc">Đối tượng nhà cung cấp</param>
        public void ThemNhaCungCap(NhaCungCap ncc)
        {
            ValidateNhaCungCap(ncc);
            _nhaCungCapDAL.Insert(ncc);
        }

        /// <summary>
        /// Cập nhật nhà cung cấp
        /// </summary>
        /// <param name="ncc">Đối tượng nhà cung cấp cần cập nhật</param>
        public void CapNhatNhaCungCap(NhaCungCap ncc)
        {
            if (ncc.MaNCC <= 0)
                throw new Exception("Mã nhà cung cấp không hợp lệ.");

            NhaCungCap existing = _nhaCungCapDAL.GetById(ncc.MaNCC);
            if (existing == null)
                throw new Exception("Không tìm thấy nhà cung cấp cần cập nhật.");

            ValidateNhaCungCap(ncc);
            _nhaCungCapDAL.Update(ncc);
        }

        /// <summary>
        /// Ngừng hợp tác với nhà cung cấp (đặt TrangThai = 0)
        /// </summary>
        /// <param name="maNCC">Mã nhà cung cấp</param>
        public void NgungHopTac(int maNCC)
        {
            NhaCungCap ncc = _nhaCungCapDAL.GetById(maNCC);
            if (ncc == null)
                throw new Exception("Không tìm thấy nhà cung cấp.");

            if (ncc.TrangThai == 0)
                throw new Exception("Nhà cung cấp này đã ngừng hợp tác.");

            _nhaCungCapDAL.UpdateTrangThai(maNCC, 0);
        }

        /// <summary>
        /// Validate thông tin nhà cung cấp
        /// </summary>
        private void ValidateNhaCungCap(NhaCungCap ncc)
        {
            if (string.IsNullOrWhiteSpace(ncc.TenNCC))
                throw new Exception("Tên nhà cung cấp không được để trống.");

            if (ncc.TenNCC.Length > 200)
                throw new Exception("Tên nhà cung cấp không được vượt quá 200 ký tự.");

            if (!string.IsNullOrWhiteSpace(ncc.SoDienThoai))
            {
                string pattern = @"^(0[1-9][0-9]{8,9})$";
                if (!Regex.IsMatch(ncc.SoDienThoai.Trim(), pattern))
                    throw new Exception("Số điện thoại không đúng định dạng. Vui lòng nhập số điện thoại hợp lệ (VD: 0901234567).");
            }

            if (!string.IsNullOrWhiteSpace(ncc.Email))
            {
                string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                if (!Regex.IsMatch(ncc.Email.Trim(), emailPattern))
                    throw new Exception("Email không đúng định dạng.");
            }
        }
    }
}
