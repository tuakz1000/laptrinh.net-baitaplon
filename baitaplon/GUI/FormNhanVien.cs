using System;
using System.Drawing;
using System.Windows.Forms;
using baitaplon.BUS;
using baitaplon.Models;
using baitaplon.Helpers;

namespace baitaplon.GUI
{
    public partial class FormNhanVien : Form
    {
        private NhanVienBUS _bus = new NhanVienBUS();

        public FormNhanVien()
        {
            InitializeComponent();
        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            UIHelper.StyleDataGridView(dgvData);
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = _bus.GetAll();
                dgvData.Rows.Clear();
                foreach (var nv in list)
                {
                    int idx = dgvData.Rows.Add(nv.MaNV, nv.HoTen, nv.GioiTinh, nv.NgaySinh?.ToString("dd/MM/yyyy"),
                        nv.SoDienThoai, nv.Email, nv.DiaChi, nv.ChucVu,
                        nv.TrangThai == 1 ? "Đang làm" : "Nghỉ việc");
                    dgvData.Rows[idx].Tag = nv;
                    if (nv.TrangThai == 0) dgvData.Rows[idx].DefaultCellStyle.ForeColor = Color.Gray;
                }
            }
            catch (Exception ex) { MessageHelper.ShowError(ex.Message); }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var frm = new FormNhanVienDetail();
            if (frm.ShowDialog() == DialogResult.OK) LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 0) { MessageHelper.ShowWarning("Chọn nhân viên!"); return; }
            NhanVien nv = dgvData.SelectedRows[0].Tag as NhanVien;
            if (nv == null) return;
            var frm = new FormNhanVienDetail(nv.MaNV);
            if (frm.ShowDialog() == DialogResult.OK) LoadData();
        }

        private void btnNghiViec_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 0) { MessageHelper.ShowWarning("Chọn nhân viên!"); return; }
            NhanVien nv = dgvData.SelectedRows[0].Tag as NhanVien;
            if (nv == null) return;
            if (nv.TrangThai == 0) { MessageHelper.ShowWarning("Nhân viên này đã nghỉ việc!"); return; }
            if (!MessageHelper.Confirm("Đánh dấu nhân viên này đã nghỉ việc?")) return;
            try
            {
                _bus.NghiViec(nv.MaNV);
                MessageHelper.ShowSuccess("Đã cập nhật trạng thái nhân viên!");
                LoadData();
            }
            catch (Exception ex) { MessageHelper.ShowError(ex.Message); }
        }
    }

    public partial class FormNhanVienDetail : Form
    {
        private NhanVienBUS _bus = new NhanVienBUS();
        private int _maNV = 0;
        private bool _isEdit = false;

        public FormNhanVienDetail(int maNV = 0)
        {
            InitializeComponent();
            _maNV = maNV;
            _isEdit = maNV > 0;
        }

        private void FormNhanVienDetail_Load(object sender, EventArgs e)
        {
            if (_isEdit) { this.Text = "Sửa nhân viên"; LoadData(); }
            else this.Text = "Thêm nhân viên mới";
        }

        private void LoadData()
        {
            var nv = _bus.GetById(_maNV);
            if (nv == null) { MessageHelper.ShowError("Không tìm thấy nhân viên!"); this.Close(); return; }
            txtHoTen.Text = nv.HoTen; txtGioiTinh.Text = nv.GioiTinh;
            if (nv.NgaySinh.HasValue) dtpNgaySinh.Value = nv.NgaySinh.Value;
            txtSDT.Text = nv.SoDienThoai; txtEmail.Text = nv.Email;
            txtDiaChi.Text = nv.DiaChi; txtChucVu.Text = nv.ChucVu;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text)) { MessageHelper.ShowWarning("Nhập họ tên!"); return; }
            try
            {
                var nv = new NhanVien
                {
                    MaNV = _maNV,
                    HoTen = txtHoTen.Text.Trim(),
                    GioiTinh = txtGioiTinh.Text.Trim(),
                    NgaySinh = dtpNgaySinh.Value,
                    SoDienThoai = txtSDT.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    DiaChi = txtDiaChi.Text.Trim(),
                    ChucVu = txtChucVu.Text.Trim()
                };
                if (_isEdit) _bus.CapNhatNhanVien(nv); else _bus.ThemNhanVien(nv);
                MessageHelper.ShowSuccess(_isEdit ? "Cập nhật thành công!" : "Thêm thành công!");
                this.DialogResult = DialogResult.OK; this.Close();
            }
            catch (Exception ex) { MessageHelper.ShowError(ex.Message); }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; this.Close();
        }
    }
}