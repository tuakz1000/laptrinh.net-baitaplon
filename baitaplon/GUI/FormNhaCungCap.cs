using System;
using System.Drawing;
using System.Windows.Forms;
using baitaplon.BUS;
using baitaplon.Models;
using baitaplon.Helpers;

namespace baitaplon.GUI
{
    public partial class FormNhaCungCap : Form
    {
        private NhaCungCapBUS _bus = new NhaCungCapBUS();
        public FormNhaCungCap() { InitializeComponent(); }
        private void FormNhaCungCap_Load(object sender, EventArgs e) { UIHelper.StyleDataGridView(dgvData); LoadData(); }
        private void LoadData()
        {
            try
            {
                string kw = txtTimKiem.Text.Trim();
                var list = string.IsNullOrEmpty(kw) ? _bus.GetAll() : _bus.Search(kw);
                dgvData.Rows.Clear();
                foreach (var ncc in list)
                {
                    int idx = dgvData.Rows.Add(ncc.MaNCC, ncc.TenNCC, ncc.NguoiLienHe, ncc.SoDienThoai, ncc.Email, ncc.DiaChi, ncc.TrangThai == 1 ? "Hoạt động" : "Ngừng");
                    dgvData.Rows[idx].Tag = ncc;
                    if (ncc.TrangThai == 0) dgvData.Rows[idx].DefaultCellStyle.ForeColor = Color.Gray;
                }
            }
            catch (Exception ex) { MessageHelper.ShowError(ex.Message); }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            var frm = new FormNhaCungCapDetail();
            if (frm.ShowDialog() == DialogResult.OK) LoadData();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 0) { MessageHelper.ShowWarning("Chọn nhà cung cấp!"); return; }
            NhaCungCap ncc = dgvData.SelectedRows[0].Tag as NhaCungCap;
            if (ncc == null) return;
            var frm = new FormNhaCungCapDetail(ncc.MaNCC);
            if (frm.ShowDialog() == DialogResult.OK) LoadData();
        }
        private void btnTimKiem_Click(object sender, EventArgs e) { LoadData(); }
        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e) { if (e.KeyCode == Keys.Enter) { LoadData(); e.SuppressKeyPress = true; } }
        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e) { if (e.RowIndex >= 0) btnSua_Click(sender, e); }
    }

    public partial class FormNhaCungCapDetail : Form
    {
        private NhaCungCapBUS _bus = new NhaCungCapBUS();
        private int _maNCC = 0;
        public FormNhaCungCapDetail(int maNCC = 0) { InitializeComponent(); _maNCC = maNCC; }
        private void FormNhaCungCapDetail_Load(object sender, EventArgs e)
        {
            if (_maNCC > 0) { this.Text = "Sửa nhà cung cấp"; LoadData(); }
            else this.Text = "Thêm nhà cung cấp";
        }
        private void LoadData()
        {
            var ncc = _bus.GetById(_maNCC);
            if (ncc == null) { this.Close(); return; }
            txtTen.Text = ncc.TenNCC; txtNguoiLH.Text = ncc.NguoiLienHe;
            txtSDT.Text = ncc.SoDienThoai; txtEmail.Text = ncc.Email; txtDiaChi.Text = ncc.DiaChi;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTen.Text)) { MessageHelper.ShowWarning("Nhập tên NCC!"); return; }
            try
            {
                var ncc = new NhaCungCap { MaNCC = _maNCC, TenNCC = txtTen.Text.Trim(), NguoiLienHe = txtNguoiLH.Text.Trim(),
                    SoDienThoai = txtSDT.Text.Trim(), Email = txtEmail.Text.Trim(), DiaChi = txtDiaChi.Text.Trim() };
                if (_maNCC > 0) _bus.CapNhatNhaCungCap(ncc); else _bus.ThemNhaCungCap(ncc);
                MessageHelper.ShowSuccess(_maNCC > 0 ? "Cập nhật thành công!" : "Thêm thành công!");
                this.DialogResult = DialogResult.OK; this.Close();
            }
            catch (Exception ex) { MessageHelper.ShowError(ex.Message); }
        }
        private void btnHuy_Click(object sender, EventArgs e) { this.Close(); }
    }
}

