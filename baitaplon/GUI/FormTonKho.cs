using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using baitaplon.BUS;
using baitaplon.Models;
using baitaplon.Helpers;

namespace baitaplon.GUI
{
    public partial class FormTonKho : Form
    {
        private SanPhamBUS _spBUS = new SanPhamBUS();
        private LichSuTonKhoBUS _historyBUS = new LichSuTonKhoBUS();

        public FormTonKho()
        {
            InitializeComponent();
        }

        private void FormTonKho_Load(object sender, EventArgs e)
        {
            UIHelper.StyleDataGridView(dgvTonKho);
            UIHelper.StyleDataGridView(dgvLichSu);
            dtpTuNgay.Value = DateTime.Now.AddDays(-30);
            dtpDenNgay.Value = DateTime.Now;
            LoadTonKho();
        }

        private void LoadTonKho()
        {
            try
            {
                var list = _spBUS.GetAll();
                dgvTonKho.Rows.Clear();
                foreach (var sp in list)
                {
                    if (sp.TrangThai == 0) continue;
                    int idx = dgvTonKho.Rows.Add(sp.MaSP, sp.MaSPCode, sp.TenSP, sp.TenDanhMuc, sp.TenDVT,
                        sp.SoLuongTon, sp.TonToiThieu, FormatHelper.FormatCurrency(sp.GiaNhap),
                        FormatHelper.FormatCurrency(sp.GiaNhap * sp.SoLuongTon));
                    dgvTonKho.Rows[idx].Tag = sp;
                    if (sp.SoLuongTon == 0)
                        dgvTonKho.Rows[idx].DefaultCellStyle.ForeColor = Color.Red;
                    else if (sp.SoLuongTon <= sp.TonToiThieu)
                        dgvTonKho.Rows[idx].DefaultCellStyle.ForeColor = Color.FromArgb(255, 152, 0);
                }
            }
            catch (Exception ex) { MessageHelper.ShowError(ex.Message); }
        }

        private void btnXemLichSu_Click(object sender, EventArgs e)
        {
            if (dgvTonKho.SelectedRows.Count == 0) { MessageHelper.ShowWarning("Chọn sản phẩm!"); return; }
            SanPham sp = dgvTonKho.SelectedRows[0].Tag as SanPham;
            if (sp == null) return;

            try
            {
                var list = _historyBUS.GetBySanPham(sp.MaSP)
                    .Where(x => x.NgayTao >= dtpTuNgay.Value.Date && x.NgayTao < dtpDenNgay.Value.Date.AddDays(1))
                    .ToList();
                dgvLichSu.Rows.Clear();
                foreach (var ls in list)
                {
                    int idx = dgvLichSu.Rows.Add(ls.MaLichSu, sp.MaSPCode, sp.TenSP, ls.LoaiGiaoDich,
                        ls.SoLuongThayDoi, ls.TonSauGiaoDich, ls.MaPhieuNhap, ls.MaPhieuXuat, ls.GhiChu, FormatHelper.FormatDateTime(ls.NgayTao));
                    dgvLichSu.Rows[idx].Tag = ls;
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
                sfd.FileName = "BaoCaoTonKho_" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var wb = new ClosedXML.Excel.XLWorkbook();
                    var ws = wb.Worksheets.Add("Tồn kho");
                    string[] headers = { "Mã SP", "Tên SP", "Danh mục", "ĐVT", "Tồn kho", "Tồn tối thiểu", "Giá nhập", "Giá trị tồn" };
                    for (int i = 0; i < headers.Length; i++)
                    {
                        ws.Cell(1, i + 1).Value = headers[i];
                        ws.Cell(1, i + 1).Style.Font.Bold = true;
                        ws.Cell(1, i + 1).Style.Fill.BackgroundColor = ClosedXML.Excel.XLColor.FromArgb(25, 118, 210);
                        ws.Cell(1, i + 1).Style.Font.FontColor = ClosedXML.Excel.XLColor.White;
                    }

                    var list = _spBUS.GetAll();
                    int row = 2;
                    foreach (var sp in list)
                    {
                        if (sp.TrangThai == 0) continue;
                        ws.Cell(row, 1).Value = sp.MaSPCode;
                        ws.Cell(row, 2).Value = sp.TenSP;
                        ws.Cell(row, 3).Value = sp.TenDanhMuc;
                        ws.Cell(row, 4).Value = sp.TenDVT;
                        ws.Cell(row, 5).Value = sp.SoLuongTon;
                        ws.Cell(row, 6).Value = sp.TonToiThieu;
                        ws.Cell(row, 7).Value = (double)sp.GiaNhap;
                        ws.Cell(row, 7).Style.NumberFormat.Format = "#,##0";
                        ws.Cell(row, 8).Value = (double)(sp.GiaNhap * sp.SoLuongTon);
                        ws.Cell(row, 8).Style.NumberFormat.Format = "#,##0";
                        row++;
                    }
                    ws.Columns().AdjustToContents();
                    wb.SaveAs(sfd.FileName);
                    MessageHelper.ShowSuccess("Xuất Excel thành công!");
                }
            }
            catch (Exception ex) { MessageHelper.ShowError("Lỗi xuất Excel: " + ex.Message); }
        }
    }
}
