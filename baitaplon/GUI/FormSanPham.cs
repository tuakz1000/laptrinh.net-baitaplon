using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using baitaplon.BUS;
using baitaplon.Models;
using baitaplon.Helpers;

namespace baitaplon.GUI
{
    public partial class FormSanPham : Form
    {
        private SanPhamBUS _bus = new SanPhamBUS();
        private DanhMucBUS _dmBUS = new DanhMucBUS();
        private DonViTinhBUS _dvtBUS = new DonViTinhBUS();

        public FormSanPham()
        {
            InitializeComponent();
        }

        private void FormSanPham_Load(object sender, EventArgs e)
        {
            UIHelper.StyleDataGridView(dgvSanPham);
            LoadComboBoxes();
            LoadData();
        }

        private void LoadComboBoxes()
        {
            // Filter combos
            cmbLocDanhMuc.Items.Clear();
            cmbLocDanhMuc.Items.Add("-- Tất cả --");
            foreach (var dm in _dmBUS.GetAllActive())
                cmbLocDanhMuc.Items.Add(dm);
            cmbLocDanhMuc.SelectedIndex = 0;
            cmbLocDanhMuc.DisplayMember = "TenDanhMuc";
            cmbLocDanhMuc.ValueMember = "MaDanhMuc";

            cmbLocTrangThai.Items.Clear();
            cmbLocTrangThai.Items.Add("-- Tất cả --");
            cmbLocTrangThai.Items.Add("Đang kinh doanh");
            cmbLocTrangThai.Items.Add("Ngừng kinh doanh");
            cmbLocTrangThai.SelectedIndex = 0;
        }

        private void LoadData()
        {
            try
            {
                string keyword = txtTimKiem.Text.Trim();
                int? maDM = null;
                int? trangThai = null;

                if (cmbLocDanhMuc.SelectedIndex > 0 && cmbLocDanhMuc.SelectedItem is DanhMuc dm)
                    maDM = dm.MaDanhMuc;

                if (cmbLocTrangThai.SelectedIndex == 1) trangThai = 1;
                else if (cmbLocTrangThai.SelectedIndex == 2) trangThai = 0;

                var list = _bus.Search(keyword, maDM, trangThai);
                dgvSanPham.Rows.Clear();
                foreach (var sp in list)
                {
                    int idx = dgvSanPham.Rows.Add();
                    var row = dgvSanPham.Rows[idx];
                    row.Cells["colMaSPCode"].Value = sp.MaSPCode;
                    row.Cells["colTenSP"].Value = sp.TenSP;
                    row.Cells["colDanhMuc"].Value = sp.TenDanhMuc;
                    row.Cells["colDVT"].Value = sp.TenDVT;
                    row.Cells["colGiaNhap"].Value = FormatHelper.FormatCurrency(sp.GiaNhap);
                    row.Cells["colGiaBan"].Value = FormatHelper.FormatCurrency(sp.GiaBan);
                    row.Cells["colTonKho"].Value = sp.SoLuongTon.ToString("N0");
                    row.Cells["colTonMin"].Value = sp.TonToiThieu;
                    row.Cells["colTrangThai"].Value = FormatHelper.GetTrangThaiSanPham(sp.TrangThai);
                    row.Tag = sp;

                    if (sp.SoLuongTon == 0)
                        row.DefaultCellStyle.ForeColor = Color.Red;
                    else if (sp.SoLuongTon <= sp.TonToiThieu)
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(255, 152, 0);

                    if (sp.TrangThai == 0)
                        row.DefaultCellStyle.ForeColor = Color.Gray;
                }
                lblTongSP.Text = string.Format("Tổng: {0} sản phẩm", list.Count);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FormSanPhamDetail frm = new FormSanPhamDetail();
            if (frm.ShowDialog() == DialogResult.OK)
                LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.SelectedRows.Count == 0)
            {
                MessageHelper.ShowWarning("Vui lòng chọn sản phẩm cần sửa!");
                return;
            }
            SanPham sp = dgvSanPham.SelectedRows[0].Tag as SanPham;
            if (sp == null) return;

            FormSanPhamDetail frm = new FormSanPhamDetail(sp.MaSP);
            if (frm.ShowDialog() == DialogResult.OK)
                LoadData();
        }

        private void btnNgungKD_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.SelectedRows.Count == 0)
            {
                MessageHelper.ShowWarning("Vui lòng chọn sản phẩm!");
                return;
            }
            SanPham sp = dgvSanPham.SelectedRows[0].Tag as SanPham;
            if (sp == null) return;

            string action = sp.TrangThai == 1 ? "ngừng kinh doanh" : "kích hoạt lại";
            if (!MessageHelper.Confirm(string.Format("Bạn có chắc muốn {0} sản phẩm '{1}'?", action, sp.TenSP)))
                return;

            try
            {
                int newStatus = sp.TrangThai == 1 ? 0 : 1;
                _bus.CapNhatTrangThai(sp.MaSP, newStatus);
                MessageHelper.ShowSuccess("Đã " + action + " sản phẩm thành công!");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(ex.Message);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { LoadData(); e.SuppressKeyPress = true; }
        }

        private void cmbLocDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cmbLocTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel Files|*.xlsx";
                sfd.FileName = "DanhSachSanPham_" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var wb = new ClosedXML.Excel.XLWorkbook();
                    var ws = wb.Worksheets.Add("Sản phẩm");
                    // Headers
                    string[] headers = { "Mã SP", "Tên SP", "Danh mục", "ĐVT", "Giá nhập", "Giá bán", "Tồn kho", "Tồn tối thiểu", "Trạng thái" };
                    for (int i = 0; i < headers.Length; i++)
                    {
                        ws.Cell(1, i + 1).Value = headers[i];
                        ws.Cell(1, i + 1).Style.Font.Bold = true;
                        ws.Cell(1, i + 1).Style.Fill.BackgroundColor = ClosedXML.Excel.XLColor.FromArgb(25, 118, 210);
                        ws.Cell(1, i + 1).Style.Font.FontColor = ClosedXML.Excel.XLColor.White;
                    }

                    var list = _bus.GetAll();
                    for (int i = 0; i < list.Count; i++)
                    {
                        var sp = list[i];
                        ws.Cell(i + 2, 1).Value = sp.MaSPCode;
                        ws.Cell(i + 2, 2).Value = sp.TenSP;
                        ws.Cell(i + 2, 3).Value = sp.TenDanhMuc;
                        ws.Cell(i + 2, 4).Value = sp.TenDVT;
                        ws.Cell(i + 2, 5).Value = (double)sp.GiaNhap;
                        ws.Cell(i + 2, 5).Style.NumberFormat.Format = "#,##0";
                        ws.Cell(i + 2, 6).Value = (double)sp.GiaBan;
                        ws.Cell(i + 2, 6).Style.NumberFormat.Format = "#,##0";
                        ws.Cell(i + 2, 7).Value = sp.SoLuongTon;
                        ws.Cell(i + 2, 8).Value = sp.TonToiThieu;
                        ws.Cell(i + 2, 9).Value = FormatHelper.GetTrangThaiSanPham(sp.TrangThai);
                    }
                    ws.Columns().AdjustToContents();
                    wb.SaveAs(sfd.FileName);
                    MessageHelper.ShowSuccess("Xuất Excel thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Lỗi xuất Excel: " + ex.Message);
            }
        }

        private void dgvSanPham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                btnSua_Click(sender, e);
        }
    }
}

