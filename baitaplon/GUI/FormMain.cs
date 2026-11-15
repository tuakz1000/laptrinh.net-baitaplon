using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using baitaplon.BUS;
using baitaplon.Models;
using baitaplon.Helpers;

namespace baitaplon.GUI
{
    public partial class FormMain : Form
    {
        private TaiKhoan _currentUser;
        private Panel _activeMenu;
        private Dictionary<Panel, Label> _menuItems;

        public FormMain(TaiKhoan taiKhoan)
        {
            InitializeComponent();
            _currentUser = taiKhoan;
            _menuItems = new Dictionary<Panel, Label>();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            SetupUserInfo();
            SetupMenuEvents();
            SetupPermissions();
            // Load Dashboard by default
            SetActiveMenu(pnlMenuDashboard);
            LoadDashboard();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // nothing special to do; login form re-shows itself on FormClosed
        }

        private void SetupUserInfo()
        {
            lblUserName.Text = _currentUser.TenNhanVien ?? _currentUser.TenDangNhap;
            lblUserRole.Text = _currentUser.TenVaiTro ?? "";
            lblHeaderUser.Text = "👤 " + (_currentUser.TenNhanVien ?? _currentUser.TenDangNhap);
        }

        private void SetupMenuEvents()
        {
            // Map menu panels to labels
            _menuItems[pnlMenuDashboard] = lblMenuDashboard;
            _menuItems[pnlMenuSanPham] = lblMenuSanPham;
            _menuItems[pnlMenuDanhMuc] = lblMenuDanhMuc;
            _menuItems[pnlMenuDonViTinh] = lblMenuDonViTinh;
            _menuItems[pnlMenuNhaCungCap] = lblMenuNhaCungCap;
            _menuItems[pnlMenuKhachHang] = lblMenuKhachHang;
            _menuItems[pnlMenuNhapKho] = lblMenuNhapKho;
            _menuItems[pnlMenuXuatKho] = lblMenuXuatKho;
            _menuItems[pnlMenuTonKho] = lblMenuTonKho;
            _menuItems[pnlMenuBaoCao] = lblMenuBaoCao;
            _menuItems[pnlMenuNhanVien] = lblMenuNhanVien;
            _menuItems[pnlMenuTaiKhoan] = lblMenuTaiKhoan;

            foreach (var kvp in _menuItems)
            {
                Panel pnl = kvp.Key;
                Label lbl = kvp.Value;

                pnl.Cursor = Cursors.Hand;
                lbl.Cursor = Cursors.Hand;

                pnl.MouseEnter += Menu_MouseEnter;
                pnl.MouseLeave += Menu_MouseLeave;
                lbl.MouseEnter += (s, ev) => Menu_MouseEnter(pnl, ev);
                lbl.MouseLeave += (s, ev) => Menu_MouseLeave(pnl, ev);

                pnl.Click += Menu_Click;
                lbl.Click += (s, ev) => Menu_Click(pnl, ev);
            }
        }

        private void SetupPermissions()
        {
            var permissions = TaiKhoanBUS.CurrentPermissions ?? new List<string>();

            pnlMenuNhanVien.Visible = TaiKhoanBUS.HasPermission("QUAN_LY_NHAN_VIEN");
            pnlMenuTaiKhoan.Visible = TaiKhoanBUS.HasPermission("QUAN_LY_TAI_KHOAN");
        }

        private void Menu_MouseEnter(object sender, EventArgs e)
        {
            Panel pnl = sender as Panel;
            if (pnl != null && pnl != _activeMenu)
            {
                pnl.BackColor = Color.FromArgb(52, 58, 64);
            }
        }

        private void Menu_MouseLeave(object sender, EventArgs e)
        {
            Panel pnl = sender as Panel;
            if (pnl != null && pnl != _activeMenu)
            {
                pnl.BackColor = Color.FromArgb(33, 37, 41);
            }
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            Panel pnl = sender as Panel;
            if (pnl == null) return;

            SetActiveMenu(pnl);

            if (pnl == pnlMenuDashboard) LoadDashboard();
            else if (pnl == pnlMenuSanPham) LoadSanPham();
            else if (pnl == pnlMenuDanhMuc) LoadDanhMuc();
            else if (pnl == pnlMenuDonViTinh) LoadDonViTinh();
            else if (pnl == pnlMenuNhaCungCap) LoadNhaCungCap();
            else if (pnl == pnlMenuKhachHang) LoadKhachHang();
            else if (pnl == pnlMenuNhapKho) LoadNhapKho();
            else if (pnl == pnlMenuXuatKho) LoadXuatKho();
            else if (pnl == pnlMenuTonKho) LoadTonKho();
            else if (pnl == pnlMenuBaoCao) LoadBaoCao();
            else if (pnl == pnlMenuNhanVien) LoadNhanVien();
            else if (pnl == pnlMenuTaiKhoan) LoadTaiKhoan();
        }

        private void SetActiveMenu(Panel pnl)
        {
            // Reset old active
            if (_activeMenu != null)
            {
                _activeMenu.BackColor = Color.FromArgb(33, 37, 41);
            }

            _activeMenu = pnl;
            pnl.BackColor = Color.FromArgb(25, 118, 210);
        }

        private void LoadForm(Form childForm, string pageTitle)
        {
            lblPageTitle.Text = pageTitle;
            pnlContent.Controls.Clear();
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(childForm);
            childForm.Show();
        }

        private void LoadDashboard()
        {
            lblPageTitle.Text = "🏠 Tổng quan";
            LoadForm(new FormDashboard(), "🏠 Tổng quan");
        }

        private void LoadSanPham()
        {
            LoadForm(new FormSanPham(), "📦 Quản lý Sản phẩm");
        }

        private void LoadDanhMuc()
        {
            LoadForm(new FormDanhMuc(), "📂 Quản lý Danh mục");
        }

        private void LoadDonViTinh()
        {
            LoadForm(new FormDonViTinh(), "📏 Quản lý Đơn vị tính");
        }

        private void LoadNhaCungCap()
        {
            LoadForm(new FormNhaCungCap(), "🏭 Quản lý Nhà cung cấp");
        }

        private void LoadKhachHang()
        {
            LoadForm(new FormKhachHang(), "👥 Quản lý Khách hàng");
        }

        private void LoadNhapKho()
        {
            LoadForm(new FormNhapKho(), "📥 Quản lý Nhập kho");
        }

        private void LoadXuatKho()
        {
            LoadForm(new FormXuatKho(), "📤 Quản lý Xuất kho");
        }

        private void LoadTonKho()
        {
            LoadForm(new FormTonKho(), "📊 Quản lý Tồn kho");
        }

        private void LoadBaoCao()
        {
            LoadForm(new FormBaoCao(), "📈 Báo cáo & Thống kê");
        }

        private void LoadNhanVien()
        {
            LoadForm(new FormNhanVien(), "👤 Quản lý Nhân viên");
        }

        private void LoadTaiKhoan()
        {
            LoadForm(new FormTaiKhoanManager(), "🔑 Quản lý Tài khoản");
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageHelper.Confirm("Bạn có chắc chắn muốn đăng xuất?"))
            {
                this.Close();
            }
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }
    }
}

