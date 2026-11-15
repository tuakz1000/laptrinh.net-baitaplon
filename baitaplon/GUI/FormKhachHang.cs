using System;
using System.Drawing;
using System.Windows.Forms;
using baitaplon.BUS;
using baitaplon.Models;
using baitaplon.Helpers;

namespace baitaplon.GUI
{
    public partial class FormKhachHang : Form
    {
        private KhachHangBUS _bus = new KhachHangBUS();

        public FormKhachHang()
        {
            InitializeComponent();
        }

        private void FormKhachHang_Load(object sender, EventArgs e)
        {
            UIHelper.StyleDataGridView(dgvData);
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                string kw = txtTimKiem.Text.Trim();
                var list = string.IsNullOrEmpty(kw) ? _bus.GetAll() : _bus.Search(kw);
                dgvData.Rows.Clear();
                foreach (var kh in list)
                {
                    int idx = dgvData.Rows.Add(kh.MaKH, kh.TenKH, kh.SoDienThoai, kh.Email, kh.DiaChi,
                        kh.TrangThai == 1 ? "Hoạt động" : "Ngừng");
                    dgvData.Rows[idx].Tag = kh;
                    if (kh.TrangThai == 0) dgvData.Rows[idx].DefaultCellStyle.ForeColor = Color.Gray;
                }
            }
            catch (Exception ex) { MessageHelper.ShowError(ex.Message); }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var frm = new FormKhachHangDetail();
            if (frm.ShowDialog() == DialogResult.OK) LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 0) { MessageHelper.ShowWarning("Chọn khách hàng!"); return; }
            KhachHang kh = dgvData.SelectedRows[0].Tag as KhachHang;
            if (kh == null) return;
            var frm = new FormKhachHangDetail(kh.MaKH);
            if (frm.ShowDialog() == DialogResult.OK) LoadData();
        }

        private void btnTimKiem_Click(object sender, EventArgs e) { LoadData(); }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { LoadData(); e.SuppressKeyPress = true; }
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) btnSua_Click(sender, e);
        }
    }

    public partial class FormKhachHangDetail : Form
    {
        private KhachHangBUS _bus = new KhachHangBUS();
        private int _maKH = 0;

        public FormKhachHangDetail(int maKH = 0)
        {
            InitializeComponent();
            _maKH = maKH;
        }

        private void FormKhachHangDetail_Load(object sender, EventArgs e)
        {
            if (_maKH > 0) { this.Text = "Sửa khách hàng"; LoadData(); }
            else this.Text = "Thêm khách hàng";
        }

        private void LoadData()
        {
            var kh = _bus.GetById(_maKH);
            if (kh == null) { this.Close(); return; }
            txtTen.Text = kh.TenKH; txtSDT.Text = kh.SoDienThoai; txtEmail.Text = kh.Email; txtDiaChi.Text = kh.DiaChi;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTen.Text)) { MessageHelper.ShowWarning("Nhập tên khách hàng!"); return; }
            try
            {
                var kh = new KhachHang
                {
                    MaKH = _maKH,
                    TenKH = txtTen.Text.Trim(),
                    SoDienThoai = txtSDT.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    DiaChi = txtDiaChi.Text.Trim()
                };
                if (_maKH > 0) _bus.CapNhatKhachHang(kh); else _bus.ThemKhachHang(kh);
                MessageHelper.ShowSuccess(_maKH > 0 ? "Cập nhật thành công!" : "Thêm thành công!");
                this.DialogResult = DialogResult.OK; this.Close();
            }
            catch (Exception ex) { MessageHelper.ShowError(ex.Message); }
        }

        private void btnHuy_Click(object sender, EventArgs e) { this.DialogResult = DialogResult.Cancel; this.Close(); }
    }
}
