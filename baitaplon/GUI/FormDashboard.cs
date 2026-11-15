using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using baitaplon.BUS;
using baitaplon.Helpers;

namespace baitaplon.GUI
{
    public partial class FormDashboard : Form
    {
        private ThongKeBUS _thongKeBUS = new ThongKeBUS();

        public FormDashboard()
        {
            InitializeComponent();
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            LoadDashboard();
        }

        private void LoadDashboard()
        {
            try
            {
                // Statistics cards
                int tongSP = _thongKeBUS.GetTongSoSanPham();
                int tongTon = _thongKeBUS.GetTongSoLuongTon();
                decimal tongGiaTri = _thongKeBUS.GetTongGiaTriTonKho();
                int phieuNhapHN = _thongKeBUS.GetSoPhieuNhapHomNay();
                int phieuXuatHN = _thongKeBUS.GetSoPhieuXuatHomNay();
                int phieuNhapThang = _thongKeBUS.GetSoPhieuNhapThang();
                int phieuXuatThang = _thongKeBUS.GetSoPhieuXuatThang();
                int sapHet = _thongKeBUS.GetSoSanPhamSapHet();
                int hetHang = _thongKeBUS.GetSoSanPhamHetHang();

                lblTongSP.Text = tongSP.ToString("N0");
                lblTongTon.Text = tongTon.ToString("N0");
                lblGiaTriTon.Text = FormatHelper.FormatCurrency(tongGiaTri);
                lblNhapHomNay.Text = phieuNhapHN.ToString();
                lblXuatHomNay.Text = phieuXuatHN.ToString();
                lblNhapThang.Text = phieuNhapThang.ToString();
                lblXuatThang.Text = phieuXuatThang.ToString();
                lblSapHet.Text = sapHet.ToString();
                lblHetHang.Text = hetHang.ToString();

                // Chart
                LoadChart();

                // Low stock products
                LoadSanPhamCanhBao();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Lỗi tải dashboard: " + ex.Message);
            }
        }

        private void LoadChart()
        {
            try
            {
                chartNhapXuat.Series.Clear();
                chartNhapXuat.ChartAreas.Clear();

                ChartArea area = new ChartArea("MainArea");
                area.AxisX.Title = "Tháng";
                area.AxisY.Title = "Giá trị (VNĐ)";
                area.AxisX.Interval = 1;
                area.AxisY.LabelStyle.Format = "#,##0";
                area.BackColor = Color.White;
                chartNhapXuat.ChartAreas.Add(area);

                Series seriesNhap = new Series("Nhập kho");
                seriesNhap.ChartType = SeriesChartType.Column;
                seriesNhap.Color = Color.FromArgb(25, 118, 210);

                Series seriesXuat = new Series("Xuất kho");
                seriesXuat.ChartType = SeriesChartType.Column;
                seriesXuat.Color = Color.FromArgb(255, 152, 0);

                DataTable dt = _thongKeBUS.GetBieuDoNhapXuat(DateTime.Now.Year);
                foreach (DataRow row in dt.Rows)
                {
                    int thang = Convert.ToInt32(row["Thang"]);
                    decimal nhap = Convert.ToDecimal(row["TongNhap"]);
                    decimal xuat = Convert.ToDecimal(row["TongXuat"]);
                    seriesNhap.Points.AddXY("T" + thang, (double)nhap);
                    seriesXuat.Points.AddXY("T" + thang, (double)xuat);
                }

                chartNhapXuat.Series.Add(seriesNhap);
                chartNhapXuat.Series.Add(seriesXuat);
                chartNhapXuat.Legends.Clear();
                chartNhapXuat.Legends.Add(new Legend("Legend"));
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Lỗi tải biểu đồ: " + ex.Message);
            }
        }

        private void LoadSanPhamCanhBao()
        {
            try
            {
                SanPhamBUS spBUS = new SanPhamBUS();
                var sapHet = spBUS.GetSanPhamSapHet();

                dgvCanhBao.Rows.Clear();
                foreach (var sp in sapHet)
                {
                    int idx = dgvCanhBao.Rows.Add();
                    dgvCanhBao.Rows[idx].Cells["colMaSP"].Value = sp.MaSPCode;
                    dgvCanhBao.Rows[idx].Cells["colTenSP"].Value = sp.TenSP;
                    dgvCanhBao.Rows[idx].Cells["colTonKho"].Value = sp.SoLuongTon;
                    dgvCanhBao.Rows[idx].Cells["colToiThieu"].Value = sp.TonToiThieu;

                    if (sp.SoLuongTon == 0)
                    {
                        dgvCanhBao.Rows[idx].DefaultCellStyle.ForeColor = Color.Red;
                        dgvCanhBao.Rows[idx].Cells["colTrangThai2"].Value = "Hết hàng";
                    }
                    else
                    {
                        dgvCanhBao.Rows[idx].DefaultCellStyle.ForeColor = Color.FromArgb(255, 152, 0);
                        dgvCanhBao.Rows[idx].Cells["colTrangThai2"].Value = "Sắp hết";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Lỗi tải cảnh báo: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDashboard();
        }
    }
}

