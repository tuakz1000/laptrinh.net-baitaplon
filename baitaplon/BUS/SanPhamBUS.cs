using System;
using System.Collections.Generic;
using System.Data;
using baitaplon.DAL;
using baitaplon.Models;

namespace baitaplon.BUS
{
    /// <summary>
    /// Lớp xử lý nghiệp vụ cho Sản phẩm
    /// </summary>
    public class SanPhamBUS
    {
        private readonly SanPhamDAL _sanPhamDAL;

        public SanPhamBUS()
        {
            _sanPhamDAL = new SanPhamDAL();
        }

        /// <summary>
        /// Lấy tất cả sản phẩm
        /// </summary>
        public List<SanPham> GetAll()
        {
            return _sanPhamDAL.GetAll();
        }

        /// <summary>
        /// Lấy sản phẩm theo mã
        /// </summary>
        /// <param name="maSP">Mã sản phẩm</param>
        public SanPham GetById(int maSP)
        {
            return _sanPhamDAL.GetById(maSP);
        }

        /// <summary>
        /// Tìm kiếm sản phẩm
        /// </summary>
        /// <param name="keyword">Từ khóa tìm kiếm (tên hoặc mã SP)</param>
        /// <param name="maDanhMuc">Lọc theo danh mục (null = tất cả)</param>
        /// <param name="trangThai">Lọc theo trạng thái (null = tất cả)</param>
        public List<SanPham> Search(string keyword, int? maDanhMuc, int? trangThai)
        {
            return _sanPhamDAL.Search(keyword, maDanhMuc, trangThai);
        }

        /// <summary>
        /// Thêm sản phẩm mới
        /// </summary>
        /// <param name="sp">Đối tượng sản phẩm</param>
        public void ThemSanPham(SanPham sp)
        {
            ValidateSanPham(sp);

            // Tự động sinh mã sản phẩm
            if (string.IsNullOrEmpty(sp.MaSPCode))
                sp.MaSPCode = GenerateMaSPCode();

            _sanPhamDAL.Insert(sp);
        }

        /// <summary>
        /// Cập nhật sản phẩm
        /// </summary>
        /// <param name="sp">Đối tượng sản phẩm cần cập nhật</param>
        public void CapNhatSanPham(SanPham sp)
        {
            if (sp.MaSP <= 0)
                throw new Exception("Mã sản phẩm không hợp lệ.");

            SanPham existing = _sanPhamDAL.GetById(sp.MaSP);
            if (existing == null)
                throw new Exception("Không tìm thấy sản phẩm cần cập nhật.");

            ValidateSanPham(sp);
            _sanPhamDAL.Update(sp);
        }

        /// <summary>
        /// Ngừng kinh doanh sản phẩm
        /// </summary>
        /// <param name="maSP">Mã sản phẩm</param>
        public void NgungKinhDoanh(int maSP)
        {
            SanPham sp = _sanPhamDAL.GetById(maSP);
            if (sp == null)
                throw new Exception("Không tìm thấy sản phẩm.");

            if (sp.TrangThai == 0)
                throw new Exception("Sản phẩm này đã ngừng kinh doanh.");

            // Kiểm tra sản phẩm có trong phiếu nhập/xuất chưa xác nhận không
            if (_sanPhamDAL.HasTransaction(maSP))
                throw new Exception("Không thể ngừng kinh doanh sản phẩm này vì đang có giao dịch chưa hoàn thành.");

            _sanPhamDAL.UpdateTrangThai(maSP, 0);
        }

        /// <summary>
        /// Lấy danh sách sản phẩm sắp hết hàng (tồn kho <= tồn tối thiểu)
        /// </summary>
        public List<SanPham> GetSanPhamSapHet()
        {
            return _sanPhamDAL.GetSanPhamSapHet();
        }

        /// <summary>
        /// Lấy danh sách sản phẩm hết hàng (tồn kho = 0)
        /// </summary>
        public List<SanPham> GetSanPhamHetHang()
        {
            return _sanPhamDAL.GetSanPhamHetHang();
        }

        /// <summary>
        /// Lấy top sản phẩm nhập nhiều nhất
        /// </summary>
        /// <param name="top">Số lượng sản phẩm cần lấy</param>
        public DataTable GetTopNhapNhieu(int top)
        {
            return _sanPhamDAL.GetTopNhapNhieu(top, null, null);
        }

        /// <summary>
        /// Lấy top sản phẩm xuất nhiều nhất
        /// </summary>
        /// <param name="top">Số lượng sản phẩm cần lấy</param>
        public DataTable GetTopXuatNhieu(int top)
        {
            return _sanPhamDAL.GetTopXuatNhieu(top, null, null);
        }

        /// <summary>
        /// Cập nhật trạng thái sản phẩm
        /// </summary>
        /// <param name="maSP">Mã sản phẩm</param>
        /// <param name="trangThai">Trạng thái mới (1=Đang KD, 0=Ngừng KD)</param>
        public void CapNhatTrangThai(int maSP, int trangThai)
        {
            SanPham sp = _sanPhamDAL.GetById(maSP);
            if (sp == null)
                throw new Exception("Không tìm thấy sản phẩm.");

            if (sp.TrangThai == trangThai)
                return;

            _sanPhamDAL.UpdateTrangThai(maSP, trangThai);
        }

        /// <summary>
        /// Validate thông tin sản phẩm
        /// </summary>
        private void ValidateSanPham(SanPham sp)
        {
            if (string.IsNullOrWhiteSpace(sp.TenSP))
                throw new Exception("Tên sản phẩm không được để trống.");

            if (sp.TenSP.Length > 200)
                throw new Exception("Tên sản phẩm không được vượt quá 200 ký tự.");

            if (sp.GiaNhap < 0)
                throw new Exception("Giá nhập phải lớn hơn hoặc bằng 0.");

            if (sp.GiaBan < 0)
                throw new Exception("Giá bán phải lớn hơn hoặc bằng 0.");

            if (sp.GiaBan < sp.GiaNhap)
                throw new Exception("Giá bán phải lớn hơn hoặc bằng giá nhập.");

            if (sp.TonToiThieu < 0)
                throw new Exception("Số lượng tồn tối thiểu phải lớn hơn hoặc bằng 0.");
        }

        /// <summary>
        /// Lấy mã sản phẩm tiếp theo (SP0001, ...)
        /// </summary>
        public string GenerateMaSP()
        {
            return GenerateMaSPCode();
        }
        private string GenerateMaSPCode()
        {
            string lastCode = _sanPhamDAL.GetLastMaSPCode();
            int nextNumber = 1;

            if (!string.IsNullOrEmpty(lastCode) && lastCode.Length > 2)
            {
                string numberPart = lastCode.Substring(2);
                int lastNumber;
                if (int.TryParse(numberPart, out lastNumber))
                {
                    nextNumber = lastNumber + 1;
                }
            }

            return "SP" + nextNumber.ToString("D4");
        }
    }
}
