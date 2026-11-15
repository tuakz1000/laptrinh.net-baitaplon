using System;
using System.Drawing;
using System.Windows.Forms;
using baitaplon.BUS;
using baitaplon.Models;
using baitaplon.Helpers;

namespace baitaplon.GUI
{
    public partial class FormChonSanPham : Form
    {
        private SanPhamBUS _bus = new SanPhamBUS();

        public SanPham SelectedSP { get; private set; }
        public int SelectedSoLuong { get; private set; }

        public FormChonSanPham()
        {
            InitializeComponent();
        }

        private void FormChonSanPham_Load(object sender, EventArgs e)
        {
            UIHelper.StyleDataGridView(dgvSanPham);
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = _bus.GetAll();
                dgvSanPham.Rows.Clear();
                foreach (var sp in list)
                {
                    if (sp.TrangThai == 0) continue;
                    int idx = dgvSanPham.Rows.Add(sp.MaSP, sp.MaSPCode, sp.TenSP, sp.TenDVT, sp.SoLuongTon, FormatHelper.FormatCurrency(sp.GiaNhap), FormatHelper.FormatCurrency(sp.GiaBan));
                    dgvSanPham.Rows[idx].Tag = sp;
                    if (sp.SoLuongTon <= sp.TonToiThieu)
                        dgvSanPham.Rows[idx].DefaultCellStyle.ForeColor = Color.Red;
                }
            }
            catch (Exception ex) { MessageHelper.ShowError(ex.Message); }
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { TimKiem(); e.SuppressKeyPress = true; }
        }

        private void btnTimKiem_Click(object sender, EventArgs e) { TimKiem(); }

        private void TimKiem()
        {
            try
            {
                string kw = txtTimKiem.Text.Trim();
                var list = _bus.Search(kw, null, null);
                dgvSanPham.Rows.Clear();
                foreach (var sp in list)
                {
                    if (sp.TrangThai == 0) continue;
                    int idx = dgvSanPham.Rows.Add(sp.MaSP, sp.MaSPCode, sp.TenSP, sp.TenDVT, sp.SoLuongTon, FormatHelper.FormatCurrency(sp.GiaNhap), FormatHelper.FormatCurrency(sp.GiaBan));
                    dgvSanPham.Rows[idx].Tag = sp;
                }
            }
            catch (Exception ex) { MessageHelper.ShowError(ex.Message); }
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.SelectedRows.Count == 0) { MessageHelper.ShowWarning("Chọn sản phẩm!"); return; }
            SelectedSP = dgvSanPham.SelectedRows[0].Tag as SanPham;
            if (SelectedSP == null) return;

            int soLuong = 0;
            if (!int.TryParse(txtSoLuong.Text.Trim(), out soLuong) || soLuong <= 0)
            {
                MessageHelper.ShowWarning("Số lượng không hợp lệ!");
                return;
            }
            SelectedSoLuong = soLuong;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void dgvSanPham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) btnChon_Click(sender, e);
        }
    }
}
