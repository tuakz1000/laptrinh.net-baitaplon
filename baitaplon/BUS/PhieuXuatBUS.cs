using System;
using System.Collections.Generic;
using System.Data;
using baitaplon.DAL;
using baitaplon.Models;

namespace baitaplon.BUS
{
    /// <summary>
    /// Lớp xử lý nghiệp vụ cho Phiếu xuất kho
    /// </summary>
    public class PhieuXuatBUS
    {
        private readonly PhieuXuatDAL _phieuXuatDAL;
        private readonly SanPhamDAL _sanPhamDAL;

        public PhieuXuatBUS()
        {
            _phieuXuatDAL = new PhieuXuatDAL();
            _sanPhamDAL = new SanPhamDAL();
        }

        /// <summary>
        /// Lấy danh sách phiếu xuất với bộ lọc
        /// </summary>
        /// <param name="tuNgay">Ngày bắt đầu</param>
        /// <param name="denNgay">Ngày kết thúc</param>
        /// <param name="maKH">Mã khách hàng</param>
        /// <param name="trangThai">Trạng thái phiếu</param>
        public List<PhieuXuat> GetAll(DateTime? tuNgay, DateTime? denNgay, int? maKH, int? trangThai)
        {
            // DAL signature: GetAll(tuNgay, denNgay, trangThai, maKH)
            return _phieuXuatDAL.GetAll(tuNgay, denNgay, trangThai, maKH);
        }

        /// <summary>
        /// Lấy phiếu xuất theo mã (bao gồm chi tiết)
        /// </summary>
        /// <param name="maPhieuXuat">Mã phiếu xuất</param>
        public PhieuXuat GetById(int maPhieuXuat)
        {
            PhieuXuat px = _phieuXuatDAL.GetById(maPhieuXuat);
            if (px != null)
            {
                px.ChiTietPhieuXuats = _phieuXuatDAL.GetChiTiet(maPhieuXuat);
            }
            return px;
        }

        /// <summary>
        /// Sinh mã phiếu xuất tiếp theo
        /// </summary>
        public string GetNextMaPhieuXuat()
        {
            return _phieuXuatDAL.GenerateMaPhieuXuat();
        }

        /// <summary>
        /// Lấy danh sách chi tiết phiếu xuất
        /// </summary>
        /// <param name="maPhieuXuat">Mã phiếu xuất</param>
        public List<ChiTietPhieuXuat> GetChiTiet(int maPhieuXuat)
        {
            return _phieuXuatDAL.GetChiTiet(maPhieuXuat);
        }

        /// <summary>
        /// Tạo phiếu xuất mới
        /// </summary>
        /// <param name="px">Đối tượng phiếu xuất</param>
        /// <param name="chiTiet">Danh sách chi tiết phiếu xuất</param>
        public void TaoPhieuXuat(PhieuXuat px, List<ChiTietPhieuXuat> chiTiet)
        {
            // Validate
            if (!px.MaKH.HasValue || px.MaKH.Value <= 0)
                throw new Exception("Vui lòng chọn khách hàng.");

            if (chiTiet == null || chiTiet.Count == 0)
                throw new Exception("Phiếu xuất phải có ít nhất 1 sản phẩm.");

            decimal tongTien = 0;
            for (int i = 0; i < chiTiet.Count; i++)
            {
                ChiTietPhieuXuat ct = chiTiet[i];

                if (ct.MaSP <= 0)
                    throw new Exception(string.Format("Dòng {0}: Vui lòng chọn sản phẩm.", i + 1));

                if (ct.SoLuong <= 0)
                    throw new Exception(string.Format("Dòng {0}: Số lượng phải lớn hơn 0.", i + 1));

                if (ct.DonGia < 0)
                    throw new Exception(string.Format("Dòng {0}: Đơn giá phải lớn hơn hoặc bằng 0.", i + 1));

                ct.ThanhTien = ct.SoLuong * ct.DonGia;
                tongTien += ct.ThanhTien;
            }

            // Kiểm tra trùng sản phẩm
            HashSet<int> maSPs = new HashSet<int>();
            foreach (ChiTietPhieuXuat ct in chiTiet)
            {
                if (!maSPs.Add(ct.MaSP))
                    throw new Exception("Không được xuất trùng sản phẩm trong cùng một phiếu.");
            }

            px.TongTien = tongTien;
            px.TrangThai = 0; // Phiếu nháp
            px.MaTK = TaiKhoanBUS.CurrentUser != null ? TaiKhoanBUS.CurrentUser.MaTK : (int?)null;

            _phieuXuatDAL.Insert(px, chiTiet);
        }

        /// <summary>
        /// Cập nhật phiếu xuất (chỉ phiếu nháp - TrangThai = 0)
        /// </summary>
        /// <param name="px">Đối tượng phiếu xuất</param>
        /// <param name="chiTiet">Danh sách chi tiết phiếu xuất</param>
        public void CapNhatPhieuXuat(PhieuXuat px, List<ChiTietPhieuXuat> chiTiet)
        {
            PhieuXuat existing = _phieuXuatDAL.GetById(px.MaPhieuXuat);
            if (existing == null)
                throw new Exception("Không tìm thấy phiếu xuất cần cập nhật.");

            if (existing.TrangThai != 0)
                throw new Exception("Chỉ có thể sửa phiếu xuất ở trạng thái nháp.");

            // Validate
            if (!px.MaKH.HasValue || px.MaKH.Value <= 0)
                throw new Exception("Vui lòng chọn khách hàng.");

            if (chiTiet == null || chiTiet.Count == 0)
                throw new Exception("Phiếu xuất phải có ít nhất 1 sản phẩm.");

            decimal tongTien = 0;
            for (int i = 0; i < chiTiet.Count; i++)
            {
                ChiTietPhieuXuat ct = chiTiet[i];

                if (ct.MaSP <= 0)
                    throw new Exception(string.Format("Dòng {0}: Vui lòng chọn sản phẩm.", i + 1));

                if (ct.SoLuong <= 0)
                    throw new Exception(string.Format("Dòng {0}: Số lượng phải lớn hơn 0.", i + 1));

                if (ct.DonGia < 0)
                    throw new Exception(string.Format("Dòng {0}: Đơn giá phải lớn hơn hoặc bằng 0.", i + 1));

                ct.ThanhTien = ct.SoLuong * ct.DonGia;
                tongTien += ct.ThanhTien;
            }

            // Kiểm tra trùng sản phẩm
            HashSet<int> maSPs = new HashSet<int>();
            foreach (ChiTietPhieuXuat ct in chiTiet)
            {
                if (!maSPs.Add(ct.MaSP))
                    throw new Exception("Không được xuất trùng sản phẩm trong cùng một phiếu.");
            }

            px.TongTien = tongTien;

            _phieuXuatDAL.UpdateDraft(px, chiTiet);
        }

        /// <summary>
        /// Xác nhận phiếu xuất (duyệt phiếu, kiểm tra tồn kho, cập nhật tồn kho)
        /// </summary>
        /// <param name="maPhieuXuat">Mã phiếu xuất</param>
        public void XacNhanPhieuXuat(int maPhieuXuat)
        {
            PhieuXuat px = _phieuXuatDAL.GetById(maPhieuXuat);
            if (px == null)
                throw new Exception("Không tìm thấy phiếu xuất.");

            if (px.TrangThai != 0)
                throw new Exception("Chỉ có thể xác nhận phiếu xuất ở trạng thái nháp.");

            // Kiểm tra tồn kho trước khi xác nhận
            List<ChiTietPhieuXuat> chiTiet = _phieuXuatDAL.GetChiTiet(maPhieuXuat);
            foreach (ChiTietPhieuXuat ct in chiTiet)
            {
                SanPham sp = _sanPhamDAL.GetById(ct.MaSP);
                if (sp == null)
                    throw new Exception(string.Format("Sản phẩm \"{0}\" không tồn tại.", ct.TenSP));

                if (sp.SoLuongTon < ct.SoLuong)
                    throw new Exception(string.Format(
                        "Sản phẩm \"{0}\" không đủ tồn kho. Tồn hiện tại: {1}, Yêu cầu: {2}.",
                        sp.TenSP, sp.SoLuongTon, ct.SoLuong));
            }

            int maTK = TaiKhoanBUS.CurrentUser != null ? TaiKhoanBUS.CurrentUser.MaTK : 0;
            _phieuXuatDAL.XacNhanPhieuXuat(maPhieuXuat, maTK);
        }

        /// <summary>
        /// Hủy phiếu xuất (nếu đã xác nhận thì hoàn trả tồn kho)
        /// </summary>
        /// <param name="maPhieuXuat">Mã phiếu xuất</param>
        public void HuyPhieuXuat(int maPhieuXuat)
        {
            PhieuXuat px = _phieuXuatDAL.GetById(maPhieuXuat);
            if (px == null)
                throw new Exception("Không tìm thấy phiếu xuất.");

            if (px.TrangThai == 2)
                throw new Exception("Phiếu xuất đã bị hủy trước đó.");

            int maTK = TaiKhoanBUS.CurrentUser != null ? TaiKhoanBUS.CurrentUser.MaTK : 0;
            _phieuXuatDAL.HuyPhieuXuat(maPhieuXuat, maTK);
        }

        /// <summary>
        /// Lấy số phiếu xuất theo tháng trong năm
        /// </summary>
        /// <param name="nam">Năm cần thống kê</param>
        /// <param name="thang">Tháng cần thống kê</param>
        public int GetSoPhieuTheoThang(int nam, int thang)
        {
            return _phieuXuatDAL.GetSoPhieuTheoThang(nam, thang);
        }

        /// <summary>
        /// Lấy số phiếu xuất theo ngày
        /// </summary>
        /// <param name="ngay">Ngày cần thống kê</param>
        public int GetSoPhieuTheoNgay(DateTime ngay)
        {
            return _phieuXuatDAL.GetSoPhieuTheoNgay(ngay);
        }

        /// <summary>
        /// Lấy thống kê xuất kho theo tháng
        /// </summary>
        /// <param name="nam">Năm cần thống kê</param>
        public DataTable GetThongKeXuatTheoThang(int nam)
        {
            return _phieuXuatDAL.GetThongKeXuatTheoThang(nam);
        }
    }
}
