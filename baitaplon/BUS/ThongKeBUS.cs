using System;
using System.Data;
using baitaplon.DAL;

namespace baitaplon.BUS
{
    /// <summary>
    /// Lớp xử lý nghiệp vụ cho Thống kê và Báo cáo
    /// </summary>
    public class ThongKeBUS
    {
        private readonly ThongKeDAL _thongKeDAL;

        public ThongKeBUS()
        {
            _thongKeDAL = new ThongKeDAL();
        }

        /// <summary>
        /// Lấy tổng số sản phẩm đang hoạt động
        /// </summary>
        public int GetTongSoSanPham()
        {
            return _thongKeDAL.GetTongSoSanPham();
        }

        /// <summary>
        /// Lấy tổng số phiếu nhập trong khoảng thời gian
        /// </summary>
        /// <param name="tuNgay">Ngày bắt đầu</param>
        /// <param name="denNgay">Ngày kết thúc</param>
        public int GetTongSoPhieuNhap(DateTime? tuNgay, DateTime? denNgay)
        {
            return _thongKeDAL.GetTongSoPhieuNhap(tuNgay, denNgay);
        }

        /// <summary>
        /// Lấy tổng số phiếu xuất trong khoảng thời gian
        /// </summary>
        /// <param name="tuNgay">Ngày bắt đầu</param>
        /// <param name="denNgay">Ngày kết thúc</param>
        public int GetTongSoPhieuXuat(DateTime? tuNgay, DateTime? denNgay)
        {
            return _thongKeDAL.GetTongSoPhieuXuat(tuNgay, denNgay);
        }

        /// <summary>
        /// Lấy tổng giá trị nhập kho trong khoảng thời gian
        /// </summary>
        /// <param name="tuNgay">Ngày bắt đầu</param>
        /// <param name="denNgay">Ngày kết thúc</param>
        public decimal GetTongGiaTriNhap(DateTime? tuNgay, DateTime? denNgay)
        {
            return _thongKeDAL.GetTongGiaTriNhap(tuNgay, denNgay);
        }

        /// <summary>
        /// Lấy tổng giá trị xuất kho trong khoảng thời gian
        /// </summary>
        /// <param name="tuNgay">Ngày bắt đầu</param>
        /// <param name="denNgay">Ngày kết thúc</param>
        public decimal GetTongGiaTriXuat(DateTime? tuNgay, DateTime? denNgay)
        {
            return _thongKeDAL.GetTongGiaTriXuat(tuNgay, denNgay);
        }

        /// <summary>
        /// Lấy số sản phẩm sắp hết hàng
        /// </summary>
        public int GetSoSanPhamSapHet()
        {
            return _thongKeDAL.GetSoSanPhamSapHet();
        }

        /// <summary>
        /// Lấy số sản phẩm hết hàng
        /// </summary>
        public int GetSoSanPhamHetHang()
        {
            return _thongKeDAL.GetSoSanPhamHetHang();
        }

        /// <summary>
        /// Lấy tổng giá trị tồn kho
        /// </summary>
        public decimal GetTongGiaTriTonKho()
        {
            return _thongKeDAL.GetTongGiaTriTonKho();
        }

        /// <summary>
        /// Lấy tổng số lượng tồn kho
        /// </summary>
        public int GetTongSoLuongTon()
        {
            return _thongKeDAL.GetTongSoLuongTon();
        }

        /// <summary>
        /// Lấy tổng giá trị tồn kho (alias)
        /// </summary>
        public decimal GetTongGiaTriTon()
        {
            return _thongKeDAL.GetTongGiaTriTon();
        }

        /// <summary>
        /// Lấy số phiếu nhập hôm nay
        /// </summary>
        public int GetSoPhieuNhapHomNay()
        {
            return _thongKeDAL.GetSoPhieuNhapHomNay();
        }

        /// <summary>
        /// Lấy số phiếu xuất hôm nay
        /// </summary>
        public int GetSoPhieuXuatHomNay()
        {
            return _thongKeDAL.GetSoPhieuXuatHomNay();
        }

        /// <summary>
        /// Lấy số phiếu nhập tháng này
        /// </summary>
        public int GetSoPhieuNhapThang()
        {
            return _thongKeDAL.GetSoPhieuNhapThang();
        }

        /// <summary>
        /// Lấy số phiếu xuất tháng này
        /// </summary>
        public int GetSoPhieuXuatThang()
        {
            return _thongKeDAL.GetSoPhieuXuatThang();
        }

        /// <summary>
        /// Lấy biểu đồ nhập xuất theo năm
        /// </summary>
        public DataTable GetBieuDoNhapXuat(int nam)
        {
            return _thongKeDAL.GetBieuDoNhapXuat(nam);
        }

        /// <summary>
        /// Lấy thống kê nhập xuất theo tháng trong năm
        /// </summary>
        /// <param name="nam">Năm cần thống kê</param>
        public DataTable GetThongKeNhapXuatTheoThang(int nam)
        {
            return _thongKeDAL.GetThongKeNhapXuatTheoThang(nam);
        }

        /// <summary>
        /// Lấy top sản phẩm tồn kho nhiều nhất
        /// </summary>
        /// <param name="top">Số lượng sản phẩm</param>
        public DataTable GetTopSanPhamTonKho(int top)
        {
            return _thongKeDAL.GetTopSanPhamTonKho(top);
        }

        /// <summary>
        /// Lấy thống kê theo danh mục
        /// </summary>
        public DataTable GetThongKeTheoDanhMuc()
        {
            return _thongKeDAL.GetThongKeTheoDanhMuc();
        }

        /// <summary>
        /// Lấy thống kê theo nhà cung cấp trong khoảng thời gian
        /// </summary>
        /// <param name="tuNgay">Ngày bắt đầu</param>
        /// <param name="denNgay">Ngày kết thúc</param>
        public DataTable GetThongKeTheoNhaCungCap(DateTime? tuNgay, DateTime? denNgay)
        {
            return _thongKeDAL.GetThongKeTheoNhaCungCap(tuNgay, denNgay);
        }

        /// <summary>
        /// Lấy thống kê theo khách hàng trong khoảng thời gian
        /// </summary>
        /// <param name="tuNgay">Ngày bắt đầu</param>
        /// <param name="denNgay">Ngày kết thúc</param>
        public DataTable GetThongKeTheoKhachHang(DateTime? tuNgay, DateTime? denNgay)
        {
            return _thongKeDAL.GetThongKeTheoKhachHang(tuNgay, denNgay);
        }

        /// <summary>
        /// Lấy doanh thu lợi nhuận theo tháng
        /// </summary>
        /// <param name="nam">Năm cần thống kê</param>
        public DataTable GetDoanhThuLoiNhuanTheoThang(int nam)
        {
            return _thongKeDAL.GetDoanhThuLoiNhuanTheoThang(nam);
        }

        /// <summary>
        /// Lấy phiếu nhập gần đây
        /// </summary>
        /// <param name="top">Số lượng phiếu</param>
        public DataTable GetPhieuNhapGanDay(int top)
        {
            return _thongKeDAL.GetPhieuNhapGanDay(top);
        }

        /// <summary>
        /// Lấy phiếu xuất gần đây
        /// </summary>
        /// <param name="top">Số lượng phiếu</param>
        public DataTable GetPhieuXuatGanDay(int top)
        {
            return _thongKeDAL.GetPhieuXuatGanDay(top);
        }
    }
}
