using System;
using System.Drawing;
using System.Windows.Forms;
using baitaplon.BUS;
using baitaplon.Models;

namespace baitaplon.GUI
{
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {
            txtTenDangNhap.Focus();
            // Load saved credentials if "remember me" was checked
            string savedUser, savedPass;
            if (LoginConfig.LoadLogin(out savedUser, out savedPass))
            {
                txtTenDangNhap.Text = savedUser;
                txtMatKhau.Text = savedPass;
                chkLuuThongTin.Checked = true;
                txtMatKhau.Focus();
            }

            // Test connection on load
            try
            {
                if (!DAL.DatabaseHelper.TestConnection())
                {
                    lblThongBao.Text = "⚠ Không thể kết nối database!";
                    lblThongBao.ForeColor = Color.FromArgb(244, 67, 54);
                }
            }
            catch
            {
                lblThongBao.Text = "⚠ Không thể kết nối database!";
                lblThongBao.ForeColor = Color.FromArgb(244, 67, 54);
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text;

            if (string.IsNullOrEmpty(tenDangNhap))
            {
                lblThongBao.Text = "Vui lòng nhập tên đăng nhập!";
                lblThongBao.ForeColor = Color.FromArgb(244, 67, 54);
                txtTenDangNhap.Focus();
                return;
            }

            if (string.IsNullOrEmpty(matKhau))
            {
                lblThongBao.Text = "Vui lòng nhập mật khẩu!";
                lblThongBao.ForeColor = Color.FromArgb(244, 67, 54);
                txtMatKhau.Focus();
                return;
            }

            try
            {
                lblThongBao.Text = "Đang đăng nhập...";
                lblThongBao.ForeColor = Color.FromArgb(108, 117, 125);
                Application.DoEvents();

                TaiKhoanBUS bus = new TaiKhoanBUS();
                TaiKhoan taiKhoan = bus.DangNhap(tenDangNhap, matKhau);

                if (taiKhoan != null)
                {
                    // Save or clear remembered credentials
                    if (chkLuuThongTin.Checked)
                        LoginConfig.SaveLogin(tenDangNhap, matKhau);
                    else
                        LoginConfig.ClearLogin();

                    // Set current user
                    TaiKhoanBUS.CurrentUser = taiKhoan;
                    TaiKhoanBUS.CurrentPermissions = bus.GetQuyenByVaiTro(taiKhoan.MaVaiTro);

                    this.Hide();
                    FormMain frm = new FormMain(taiKhoan);
                    frm.FormClosed += (s, args) =>
                    {
                        TaiKhoanBUS.CurrentUser = null;
                        TaiKhoanBUS.CurrentPermissions = null;
                        txtMatKhau.Text = "";
                        lblThongBao.Text = "";
                        this.Show();
                        txtTenDangNhap.Focus();
                    };
                    frm.Show();
                }
                else
                {
                    lblThongBao.Text = "Tên đăng nhập hoặc mật khẩu không đúng!";
                    lblThongBao.ForeColor = Color.FromArgb(244, 67, 54);
                    txtMatKhau.SelectAll();
                    txtMatKhau.Focus();
                }
            }
            catch (Exception ex)
            {
                lblThongBao.Text = "Lỗi: " + ex.Message;
                lblThongBao.ForeColor = Color.FromArgb(244, 67, 54);
            }
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangNhap_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }

        private void txtTenDangNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMatKhau.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = !chkHienMatKhau.Checked;
        }
    }
}

