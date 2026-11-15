using System;
using System.Drawing;
using System.Windows.Forms;
using baitaplon.BUS;
using baitaplon.Models;
using baitaplon.Helpers;

namespace baitaplon.GUI
{
    public partial class FormSanPhamDetail : Form
    {
        private SanPhamBUS _bus = new SanPhamBUS();
        private DanhMucBUS _dmBUS = new DanhMucBUS();
        private DonViTinhBUS _dvtBUS = new DonViTinhBUS();
        private int _maSP = 0;
        private bool _isEdit = false;

        public FormSanPhamDetail(int maSP = 0)
        {
            InitializeComponent();
            _maSP = maSP;
            _isEdit = maSP > 0;
        }

        private void FormSanPhamDetail_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            if (_isEdit)
            {
                this.Text = "Chỉnh sửa sản phẩm";
                lblTitle.Text = "✏ Chỉnh sửa sản phẩm";
                LoadSanPham();
            }
            else
            {
                this.Text = "Thêm sản phẩm mới";
                lblTitle.Text = "➕ Thêm sản phẩm mới";
                txtMaSP.Text = _bus.GenerateMaSP();
            }
        }

        private void LoadComboBoxes()
        {
            cmbDanhMuc.Items.Clear();
            cmbDanhMuc.Items.Add("-- Chọn danh mục --");
            foreach (var dm in _dmBUS.GetAllActive()) cmbDanhMuc.Items.Add(dm);
            cmbDanhMuc.DisplayMember = "TenDanhMuc";
            cmbDanhMuc.SelectedIndex = 0;

            cmbDVT.Items.Clear();
            cmbDVT.Items.Add("-- Chọn ĐVT --");
            foreach (var dvt in _dvtBUS.GetAllActive()) cmbDVT.Items.Add(dvt);
            cmbDVT.DisplayMember = "TenDVT";
            cmbDVT.SelectedIndex = 0;
        }

        private void LoadSanPham()
        {
            try
            {
                SanPham sp = _bus.GetById(_maSP);
                if (sp == null) { MessageHelper.ShowError("Không tìm thấy sản phẩm!"); this.Close(); return; }

                txtMaSP.Text = sp.MaSPCode;
                txtMaSP.ReadOnly = true;
                txtTenSP.Text = sp.TenSP;
                txtGiaNhap.Text = sp.GiaNhap.ToString("N0");
                txtGiaBan.Text = sp.GiaBan.ToString("N0");
                numTonToiThieu.Value = sp.TonToiThieu;
                txtMoTa.Text = sp.MoTa;

                // Select DanhMuc
                for (int i = 1; i < cmbDanhMuc.Items.Count; i++)
                {
                    if (cmbDanhMuc.Items[i] is DanhMuc dm && dm.MaDanhMuc == sp.MaDanhMuc)
                    { cmbDanhMuc.SelectedIndex = i; break; }
                }
                // Select DVT
                for (int i = 1; i < cmbDVT.Items.Count; i++)
                {
                    if (cmbDVT.Items[i] is DonViTinh dvt && dvt.MaDVT == sp.MaDVT)
                    { cmbDVT.SelectedIndex = i; break; }
                }
            }
            catch (Exception ex) { MessageHelper.ShowError(ex.Message); }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTenSP.Text))
                { MessageHelper.ShowWarning("Vui lòng nhập tên sản phẩm!"); txtTenSP.Focus(); return; }

                decimal giaNhap = 0, giaBan = 0;
                if (!decimal.TryParse(txtGiaNhap.Text.Replace(",", "").Replace(".", ""), out giaNhap) || giaNhap < 0)
                { MessageHelper.ShowWarning("Giá nhập không hợp lệ!"); txtGiaNhap.Focus(); return; }
                if (!decimal.TryParse(txtGiaBan.Text.Replace(",", "").Replace(".", ""), out giaBan) || giaBan < 0)
                { MessageHelper.ShowWarning("Giá bán không hợp lệ!"); txtGiaBan.Focus(); return; }

                SanPham sp = new SanPham();
                sp.MaSPCode = txtMaSP.Text.Trim();
                sp.TenSP = txtTenSP.Text.Trim();
                sp.GiaNhap = giaNhap;
                sp.GiaBan = giaBan;
                sp.TonToiThieu = (int)numTonToiThieu.Value;
                sp.MoTa = txtMoTa.Text.Trim();

                if (cmbDanhMuc.SelectedIndex > 0 && cmbDanhMuc.SelectedItem is DanhMuc dm)
                    sp.MaDanhMuc = dm.MaDanhMuc;
                if (cmbDVT.SelectedIndex > 0 && cmbDVT.SelectedItem is DonViTinh dvt)
                    sp.MaDVT = dvt.MaDVT;

                if (_isEdit)
                {
                    sp.MaSP = _maSP;
                    _bus.CapNhatSanPham(sp);
                    MessageHelper.ShowSuccess("Cập nhật sản phẩm thành công!");
                }
                else
                {
                    _bus.ThemSanPham(sp);
                    MessageHelper.ShowSuccess("Thêm sản phẩm thành công!");
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex) { MessageHelper.ShowError(ex.Message); }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

