using System;
using System.Drawing;
using System.Windows.Forms;
using baitaplon.BUS;
using baitaplon.DAL;
using baitaplon.Models;
using baitaplon.Helpers;

namespace baitaplon.GUI
{
    public partial class FormTaiKhoanManager : Form
    {
        private TaiKhoanBUS _bus = new TaiKhoanBUS();
        private NhanVienBUS _nvBUS = new NhanVienBUS();
        private VaiTroDAL _vtDAL = new VaiTroDAL();

        public FormTaiKhoanManager()
        {
            InitializeComponent();
        }

        private void FormTaiKhoanManager_Load(object sender, EventArgs e)
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
                foreach (var tk in list)
                {
                    int idx = dgvData.Rows.Add(tk.MaTK, tk.TenDangNhap, tk.TenNhanVien ?? "(Chưa gán NV)",
                        tk.TenVaiTro ?? "?", FormatHelper.GetTrangThaiTaiKhoan(tk.TrangThai));
                    dgvData.Rows[idx].Tag = tk;
                    if (tk.TrangThai == 0) dgvData.Rows[idx].DefaultCellStyle.ForeColor = Color.Gray;
                }
            }
            catch (Exception ex) { MessageHelper.ShowError(ex.Message); }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var frm = new FormTaiKhoanDetail();
            if (frm.ShowDialog() == DialogResult.OK) LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 0) { MessageHelper.ShowWarning("Chọn tài khoản!"); return; }
            TaiKhoan tk = dgvData.SelectedRows[0].Tag as TaiKhoan;
            if (tk == null) return;
            var frm = new FormTaiKhoanDetail(tk.MaTK);
            if (frm.ShowDialog() == DialogResult.OK) LoadData();
        }

        private void btnResetMatKhau_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 0) { MessageHelper.ShowWarning("Chọn tài khoản!"); return; }
            TaiKhoan tk = dgvData.SelectedRows[0].Tag as TaiKhoan;
            if (tk == null) return;
            string mk = Microsoft.VisualBasic.Interaction.InputBox("Nhập mật khẩu mới cho '" + tk.TenDangNhap + "':", "Đặt lại mật khẩu", "");
            if (string.IsNullOrWhiteSpace(mk)) return;
            if (mk.Length < 6) { MessageHelper.ShowWarning("Mật khẩu phải có ít nhất 6 ký tự!"); return; }
            if (!MessageHelper.Confirm("Đặt lại mật khẩu cho tài khoản này?")) return;
            try
            {
                _bus.ResetMatKhau(tk.MaTK, mk);
                MessageHelper.ShowSuccess("Đã đặt lại mật khẩu!");
            }
            catch (Exception ex) { MessageHelper.ShowError(ex.Message); }
        }

        private void btnKhoaMoKhoa_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 0) { MessageHelper.ShowWarning("Chọn tài khoản!"); return; }
            TaiKhoan tk = dgvData.SelectedRows[0].Tag as TaiKhoan;
            if (tk == null) return;
            try
            {
                if (tk.TrangThai == 1)
                {
                    if (!MessageHelper.Confirm("Khóa tài khoản '" + tk.TenDangNhap + "'?")) return;
                    _bus.KhoaTaiKhoan(tk.MaTK);
                    MessageHelper.ShowSuccess("Đã khóa tài khoản!");
                }
                else
                {
                    if (!MessageHelper.Confirm("Mở khóa tài khoản '" + tk.TenDangNhap + "'?")) return;
                    _bus.MoKhoaTaiKhoan(tk.MaTK);
                    MessageHelper.ShowSuccess("Đã mở khóa tài khoản!");
                }
                LoadData();
            }
            catch (Exception ex) { MessageHelper.ShowError(ex.Message); }
        }
    }

    public partial class FormTaiKhoanDetail : Form
    {
        private TaiKhoanBUS _bus = new TaiKhoanBUS();
        private NhanVienBUS _nvBUS = new NhanVienBUS();
        private VaiTroDAL _vtDAL = new VaiTroDAL();
        private int _maTK = 0;
        private bool _isEdit = false;

        public FormTaiKhoanDetail(int maTK = 0)
        {
            InitializeComponent();
            _maTK = maTK;
            _isEdit = maTK > 0;
        }

        private void FormTaiKhoanDetail_Load(object sender, EventArgs e)
        {
            LoadNVCombo();
            LoadVTCombo();
            if (_isEdit) { this.Text = "Sửa tài khoản"; LoadData(); }
            else this.Text = "Thêm tài khoản mới";
        }

        private void LoadNVCombo()
        {
            cmbNhanVien.Items.Clear();
            cmbNhanVien.Items.Add(new NhanVien { MaNV = 0, HoTen = "-- Chưa gán --" });
            foreach (var nv in _nvBUS.GetAll())
                cmbNhanVien.Items.Add(nv);
            cmbNhanVien.DisplayMember = "HoTen";
            cmbNhanVien.ValueMember = "MaNV";
            cmbNhanVien.SelectedIndex = 0;
        }

        private void LoadVTCombo()
        {
            cmbVaiTro.Items.Clear();
            foreach (var vt in _vtDAL.GetAll())
                cmbVaiTro.Items.Add(vt);
            cmbVaiTro.DisplayMember = "TenVaiTro";
            cmbVaiTro.ValueMember = "MaVaiTro";
            if (cmbVaiTro.Items.Count > 0) cmbVaiTro.SelectedIndex = 0;
        }

        private void LoadData()
        {
            var tk = _bus.GetById(_maTK);
            if (tk == null) { MessageHelper.ShowError("Không tìm thấy tài khoản!"); this.Close(); return; }
            txtTenDangNhap.Text = tk.TenDangNhap;
            txtMatKhau.Text = ""; // don't show hash; leave blank = keep old password
            for (int i = 0; i < cmbNhanVien.Items.Count; i++)
            {
                if (cmbNhanVien.Items[i] is NhanVien nv && nv.MaNV == tk.MaNV)
                { cmbNhanVien.SelectedIndex = i; break; }
            }
            for (int i = 0; i < cmbVaiTro.Items.Count; i++)
            {
                if (cmbVaiTro.Items[i] is VaiTro vt && vt.MaVaiTro == tk.MaVaiTro)
                { cmbVaiTro.SelectedIndex = i; break; }
            }
            chkHoatDong.Checked = tk.TrangThai == 1;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text)) { MessageHelper.ShowWarning("Nhập tên đăng nhập!"); return; }
            if (cmbVaiTro.SelectedIndex < 0) { MessageHelper.ShowWarning("Chọn vai trò!"); return; }

            try
            {
                var vt = cmbVaiTro.SelectedItem as VaiTro;
                var nv = cmbNhanVien.SelectedItem as NhanVien;

                if (_isEdit)
                {
                    var tk = new TaiKhoan
                    {
                        MaTK = _maTK,
                        TenDangNhap = txtTenDangNhap.Text.Trim(),
                        MaNV = (nv != null && nv.MaNV > 0) ? nv.MaNV : (int?)null,
                        MaVaiTro = vt.MaVaiTro,
                        TrangThai = chkHoatDong.Checked ? 1 : 0
                    };
                    _bus.CapNhatTaiKhoan(tk);
                    if (!string.IsNullOrWhiteSpace(txtMatKhau.Text))
                    {
                        _bus.ResetMatKhau(_maTK, txtMatKhau.Text);
                    }
                    MessageHelper.ShowSuccess("Cập nhật tài khoản thành công!");
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(txtMatKhau.Text)) { MessageHelper.ShowWarning("Nhập mật khẩu!"); return; }
                    var tk = new TaiKhoan
                    {
                        TenDangNhap = txtTenDangNhap.Text.Trim(),
                        MaNV = (nv != null && nv.MaNV > 0) ? nv.MaNV : (int?)null,
                        MaVaiTro = vt.MaVaiTro,
                        TrangThai = 1
                    };
                    _bus.ThemTaiKhoan(tk, txtMatKhau.Text);
                    MessageHelper.ShowSuccess("Thêm tài khoản thành công!");
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex) { MessageHelper.ShowError(ex.Message); }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; this.Close();
        }
    }
}