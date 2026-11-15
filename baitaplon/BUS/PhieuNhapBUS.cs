using System;
using System.Collections.Generic;
using System.Data;
using baitaplon.DAL;
using baitaplon.Models;

namespace baitaplon.BUS
{
    /// <summary>
    /// Lớp xử lý nghiệp vụ cho Phiếu nhập kho
    /// </summary>
    public class PhieuNhapBUS
    {
        private readonly PhieuNhapDAL _phieuNhapDAL;

        public PhieuNhapBUS()
        {
            _phieuNhapDAL = new PhieuNhapDAL();
        }

        /// <summary>
        /// Lấy danh sách phiếu nhập với bộ lọc
        /// </summary>
        /// <param name="tuNgay">Ngày bắt đầu</param>
        /// <param name="denNgay">Ngày kết thúc</param>
        /// <param name="maNCC">Mã nhà cung cấp</param>
        /// <param name="trangThai">Trạng thái phiếu</param>
        public List<PhieuNhap> GetAll(DateTime? tuNgay, DateTime? denNgay, int? maNCC, int? trangThai)
        {
            // DAL signature: GetAll(tuNgay, denNgay, trangThai, maNCC)
            return _phieuNhapDAL.GetAll(tuNgay, denNgay, trangThai, maNCC);
        }

        /// <summary>
        /// Lấy phiếu nhập theo mã (bao gồm chi tiết)
        /// </summary>
        /// <param name="maPhieuNhap">Mã phiếu nhập</param>
        public PhieuNhap GetById(int maPhieuNhap)
        {
            PhieuNhap pn = _phieuNhapDAL.GetById(maPhieuNhap);
            if (pn != null)
            {
                pn.ChiTietPhieuNhaps = _phieuNhapDAL.GetChiTiet(maPhieuNhap);
            }
            return pn;
        }

        /// <summary>
        /// Sinh mã phiếu nhập tiếp theo
        /// </summary>
        public string GetNextMaPhieuNhap()
        {
            return _phieuNhapDAL.GenerateMaPhieuNhap();
        }

        /// <summary>
        /// Lấy danh sách chi tiết phiếu nhập
        /// </summary>
        /// <param name="maPhieuNhap">Mã phiếu nhập</param>
        public List<ChiTietPhieuNhap> GetChiTiet(int maPhieuNhap)
        {
            return _phieuNhapDAL.GetChiTiet(maPhieuNhap);
        }

        /// <summary>
        /// Tạo phiếu nhập mới
        /// </summary>
        /// <param name="pn">Đối tượng phiếu nhập</param>
        /// <param name="chiTiet">Danh sách chi tiết phiếu nhập</param>
        public void TaoPhieuNhap(PhieuNhap pn, List<ChiTietPhieuNhap> chiTiet)
        {
            // Validate
            if (!pn.MaNCC.HasValue || pn.MaNCC.Value <= 0)
                throw new Exception("Vui lòng chọn nhà cung cấp.");

            if (chiTiet == null || chiTiet.Count == 0)
                throw new Exception("Phiếu nhập phải có ít nhất 1 sản phẩm.");

            decimal tongTien = 0;
            for (int i = 0; i < chiTiet.Count; i++)
            {
                ChiTietPhieuNhap ct = chiTiet[i];

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
            foreach (ChiTietPhieuNhap ct in chiTiet)
            {
                if (!maSPs.Add(ct.MaSP))
                    throw new Exception("Không được nhập trùng sản phẩm trong cùng một phiếu.");
            }

            pn.TongTien = tongTien;
            pn.TrangThai = 0; // Phiếu nháp
            pn.MaTK = TaiKhoanBUS.CurrentUser != null ? TaiKhoanBUS.CurrentUser.MaTK : (int?)null;

            _phieuNhapDAL.Insert(pn, chiTiet);
        }

        /// <summary>
        /// Cập nhật phiếu nhập (chỉ phiếu nháp - TrangThai = 0)
        /// </summary>
        /// <param name="pn">Đối tượng phiếu nhập</param>
        /// <param name="chiTiet">Danh sách chi tiết phiếu nhập</param>
        public void CapNhatPhieuNhap(PhieuNhap pn, List<ChiTietPhieuNhap> chiTiet)
        {
            PhieuNhap existing = _phieuNhapDAL.GetById(pn.MaPhieuNhap);
            if (existing == null)
                throw new Exception("Không tìm thấy phiếu nhập cần cập nhật.");

            if (existing.TrangThai != 0)
                throw new Exception("Chỉ có thể sửa phiếu nhập ở trạng thái nháp.");

            // Validate
            if (!pn.MaNCC.HasValue || pn.MaNCC.Value <= 0)
                throw new Exception("Vui lòng chọn nhà cung cấp.");

            if (chiTiet == null || chiTiet.Count == 0)
                throw new Exception("Phiếu nhập phải có ít nhất 1 sản phẩm.");

            decimal tongTien = 0;
            for (int i = 0; i < chiTiet.Count; i++)
            {
                ChiTietPhieuNhap ct = chiTiet[i];

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
            foreach (ChiTietPhieuNhap ct in chiTiet)
            {
                if (!maSPs.Add(ct.MaSP))
                    throw new Exception("Không được nhập trùng sản phẩm trong cùng một phiếu.");
            }

            pn.TongTien = tongTien;

            _phieuNhapDAL.UpdateDraft(pn, chiTiet);
        }

        /// <summary>
        /// Xác nhận phiếu nhập (duyệt phiếu, cập nhật tồn kho)
        /// </summary>
        /// <param name="maPhieuNhap">Mã phiếu nhập</param>
        public void XacNhanPhieuNhap(int maPhieuNhap)
        {
            PhieuNhap pn = _phieuNhapDAL.GetById(maPhieuNhap);
            if (pn == null)
                throw new Exception("Không tìm thấy phiếu nhập.");

            if (pn.TrangThai != 0)
                throw new Exception("Chỉ có thể xác nhận phiếu nhập ở trạng thái nháp.");

            int maTK = TaiKhoanBUS.CurrentUser != null ? TaiKhoanBUS.CurrentUser.MaTK : 0;
            _phieuNhapDAL.XacNhanPhieuNhap(maPhieuNhap, maTK);
        }

        /// <summary>
        /// Hủy phiếu nhập (nếu đã xác nhận thì hoàn trả tồn kho - có kiểm tra đủ tồn kho trước khi hoàn)
        /// </summary>
        /// <param name="maPhieuNhap">Mã phiếu nhập</param>
        public void HuyPhieuNhap(int maPhieuNhap)
        {
            PhieuNhap pn = _phieuNhapDAL.GetById(maPhieuNhap);
            if (pn == null)
                throw new Exception("Không tìm thấy phiếu nhập.");

            if (pn.TrangThai == 2)
                throw new Exception("Phiếu nhập đã bị hủy trước đó.");

            int maTK = TaiKhoanBUS.CurrentUser != null ? TaiKhoanBUS.CurrentUser.MaTK : 0;
            _phieuNhapDAL.HuyPhieuNhap(maPhieuNhap, maTK);
        }

        /// <summary>
        /// Lấy số phiếu nhập theo tháng trong năm
        /// </summary>
        /// <param name="nam">Năm cần thống kê</param>
        /// <param name="thang">Tháng cần thống kê</param>
        public int GetSoPhieuTheoThang(int nam, int thang)
        {
            return _phieuNhapDAL.GetSoPhieuTheoThang(nam, thang);
        }

        /// <summary>
        /// Lấy số phiếu nhập theo ngày
        /// </summary>
        /// <param name="ngay">Ngày cần thống kê</param>
        public int GetSoPhieuTheoNgay(DateTime ngay)
        {
            return _phieuNhapDAL.GetSoPhieuTheoNgay(ngay);
        }

        /// <summary>
        /// Lấy thống kê nhập kho theo tháng
        /// </summary>
        /// <param name="nam">Năm cần thống kê</param>
        public DataTable GetThongKeNhapTheoThang(int nam)
        {
            return _phieuNhapDAL.GetThongKeNhapTheoThang(nam);
        }
    }
}
