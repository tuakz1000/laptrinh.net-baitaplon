using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using baitaplon.BUS;
using baitaplon.Helpers;
using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace baitaplon.GUI
{
    public partial class FormBaoCao : Form
    {
        private ThongKeBUS _tkBUS = new ThongKeBUS();
        private PhieuNhapBUS _pnBUS = new PhieuNhapBUS();
        private PhieuXuatBUS _pxBUS = new PhieuXuatBUS();
        private SanPhamBUS _spBUS = new SanPhamBUS();

        public FormBaoCao()
        {
            InitializeComponent();
        }

        private void FormBaoCao_Load(object sender, EventArgs e)
        {
            UIHelper.StyleDataGridView(dgvData);
            dtpTuNgay.Value = DateTime.Now.AddDays(-30);
            dtpDenNgay.Value = DateTime.Now;
            LoadBieuDo();
        }

        private void LoadBieuDo()
        {
            try
            {
                chartDoanhThu.Series.Clear();
                chartDoanhThu.ChartAreas.Clear();
                ChartArea area = new ChartArea("Main");
                area.AxisX.Title = "Tháng";
                area.AxisY.Title = "Giá trị (VNĐ)";
                area.AxisX.Interval = 1;
                area.AxisY.LabelStyle.Format = "#,##0";
                chartDoanhThu.ChartAreas.Add(area);

                Series sNhap = new Series("Nhập");
                sNhap.ChartType = SeriesChartType.Column;
                sNhap.Color = Color.FromArgb(25, 118, 210);
                Series sXuat = new Series("Xuất");
                sXuat.ChartType = SeriesChartType.Column;
                sXuat.Color = Color.FromArgb(255, 152, 0);

                DataTable dt = _tkBUS.GetThongKeNhapXuatTheoThang(DateTime.Now.Year);
                foreach (DataRow r in dt.Rows)
                {
                    int thang = Convert.ToInt32(r["Thang"]);
                    decimal nhap = Convert.ToDecimal(r["TongNhap"]);
                    decimal xuat = Convert.ToDecimal(r["TongXuat"]);
                    sNhap.Points.AddXY("T" + thang, (double)nhap);
                    sXuat.Points.AddXY("T" + thang, (double)xuat);
                }
                chartDoanhThu.Series.Add(sNhap);
                chartDoanhThu.Series.Add(sXuat);
            }
            catch (Exception ex) { MessageHelper.ShowError("Lỗi biểu đồ: " + ex.Message); }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            try
            {
                dgvData.Rows.Clear();
                dgvData.Columns.Clear();
                dgvData.Columns.Add("colThang", "Tháng");
                dgvData.Columns.Add("colNhap", "Tổng nhập");
                dgvData.Columns.Add("colXuat", "Tổng xuất");
                dgvData.Columns.Add("colLoiNhuan", "Chênh lệch");
                DataTable dt = _tkBUS.GetThongKeNhapXuatTheoThang(dtpTuNgay.Value.Year);
                foreach (DataRow r in dt.Rows)
                {
                    int thang = Convert.ToInt32(r["Thang"]);
                    decimal nhap = Convert.ToDecimal(r["TongNhap"]);
                    decimal xuat = Convert.ToDecimal(r["TongXuat"]);
                    decimal loiNhuan = xuat - nhap;
                    int idx = dgvData.Rows.Add(thang, FormatHelper.FormatCurrency(nhap), FormatHelper.FormatCurrency(xuat), FormatHelper.FormatCurrency(loiNhuan));
                }
            }
            catch (Exception ex) { MessageHelper.ShowError(ex.Message); }
        }

        private void btnTopSP_Click(object sender, EventArgs e)
        {
            try
            {
                dgvData.Rows.Clear();
                DataTable dt = _tkBUS.GetTopSanPhamTonKho(20);
                dgvData.Columns.Clear();
                dgvData.Columns.Add("colTen", "Tên SP");
                dgvData.Columns.Add("colTon", "Tồn kho");
                dgvData.Columns.Add("colGiaTri", "Giá trị tồn");
                foreach (DataRow r in dt.Rows)
                {
                    dgvData.Rows.Add(r["TenSP"], r["SoLuongTon"], FormatHelper.FormatCurrency(Convert.ToDecimal(r["GiaTriTon"])));
                }
            }
            catch (Exception ex) { MessageHelper.ShowError(ex.Message); }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel Files|*.xlsx";
                sfd.FileName = "BaoCao_" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var wb = new XLWorkbook();
                    var ws = wb.Worksheets.Add("Báo cáo");
                    // Headers from dgv
                    for (int c = 0; c < dgvData.Columns.Count; c++)
                    {
                        ws.Cell(1, c + 1).Value = dgvData.Columns[c].HeaderText;
                        ws.Cell(1, c + 1).Style.Font.Bold = true;
                        ws.Cell(1, c + 1).Style.Fill.BackgroundColor = XLColor.FromArgb(25, 118, 210);
                        ws.Cell(1, c + 1).Style.Font.FontColor = XLColor.White;
                    }
                    for (int r = 0; r < dgvData.Rows.Count; r++)
                    {
                        for (int c = 0; c < dgvData.Columns.Count; c++)
                        {
                            ws.Cell(r + 2, c + 1).Value = dgvData.Rows[r].Cells[c].Value?.ToString() ?? "";
                        }
                    }
                    ws.Columns().AdjustToContents();
                    wb.SaveAs(sfd.FileName);
                    MessageHelper.ShowSuccess("Xuất Excel thành công!");
                }
            }
            catch (Exception ex) { MessageHelper.ShowError("Lỗi xuất Excel: " + ex.Message); }
        }

        private void btnXuatPDF_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF Files|*.pdf";
                sfd.FileName = "BaoCao_" + DateTime.Now.ToString("yyyyMMdd") + ".pdf";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream fs = new FileStream(sfd.FileName, FileMode.Create))
                    {
                        Document doc = new Document(PageSize.A4.Rotate(), 20, 20, 20, 20);
                        PdfWriter.GetInstance(doc, fs);
                        doc.Open();

                        BaseFont bf = BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                        iTextSharp.text.Font titleFont = new iTextSharp.text.Font(bf, 14, iTextSharp.text.Font.BOLD);
                        iTextSharp.text.Font headerFont = new iTextSharp.text.Font(bf, 9, iTextSharp.text.Font.BOLD);
                        iTextSharp.text.Font cellFont = new iTextSharp.text.Font(bf, 9);

                        Paragraph title = new Paragraph("BÁO CÁO NHẬP XUẤT KHO", titleFont);
                        title.Alignment = Element.ALIGN_CENTER;
                        title.SpacingAfter = 10f;
                        doc.Add(title);

                        Paragraph period = new Paragraph($"Từ {dtpTuNgay.Value:dd/MM/yyyy} đến {dtpDenNgay.Value:dd/MM/yyyy}", cellFont);
                        period.Alignment = Element.ALIGN_CENTER;
                        period.SpacingAfter = 15f;
                        doc.Add(period);

                        PdfPTable table = new PdfPTable(dgvData.Columns.Count);
                        table.WidthPercentage = 100;
                        foreach (DataGridViewColumn col in dgvData.Columns)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(col.HeaderText, headerFont));
                            cell.BackgroundColor = new BaseColor(25, 118, 210);
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.Padding = 5;
                            table.AddCell(cell);
                        }
                        foreach (DataGridViewRow row in dgvData.Rows)
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                table.AddCell(new PdfPCell(new Phrase(cell.Value?.ToString() ?? "", cellFont)) { Padding = 5 });
                            }
                        }
                        doc.Add(table);
                        doc.Close();
                    }
                    MessageHelper.ShowSuccess("Xuất PDF thành công!");
                }
            }
            catch (Exception ex) { MessageHelper.ShowError("Lỗi xuất PDF: " + ex.Message); }
        }
    }
}