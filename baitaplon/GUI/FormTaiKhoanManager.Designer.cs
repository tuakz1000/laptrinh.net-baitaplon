using System;
using System.Drawing;
using System.Windows.Forms;

namespace baitaplon.GUI
{
    partial class FormTaiKhoanManager
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle h = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnKhoaMoKhoa = new System.Windows.Forms.Button();
            this.btnResetMatKhau = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // pnlTop
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.btnKhoaMoKhoa);
            this.pnlTop.Controls.Add(this.btnResetMatKhau);
            this.pnlTop.Controls.Add(this.btnSua);
            this.pnlTop.Controls.Add(this.btnThem);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(15, 15);
            this.pnlTop.Size = new System.Drawing.Size(870, 50);
            // btnThem
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(10, 10);
            this.btnThem.Size = new System.Drawing.Size(100, 30);
            this.btnThem.Text = "➕ Thêm mới";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // btnSua
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(25, 118, 210);
            this.btnSua.FlatAppearance.BorderSize = 0;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(120, 10);
            this.btnSua.Size = new System.Drawing.Size(90, 30);
            this.btnSua.Text = "✏ Chỉnh sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // btnResetMatKhau
            this.btnResetMatKhau.BackColor = System.Drawing.Color.FromArgb(255, 152, 0);
            this.btnResetMatKhau.FlatAppearance.BorderSize = 0;
            this.btnResetMatKhau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetMatKhau.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnResetMatKhau.ForeColor = System.Drawing.Color.White;
            this.btnResetMatKhau.Location = new System.Drawing.Point(220, 10);
            this.btnResetMatKhau.Size = new System.Drawing.Size(150, 30);
            this.btnResetMatKhau.Text = "🔑 Đặt lại mật khẩu";
            this.btnResetMatKhau.Click += new System.EventHandler(this.btnResetMatKhau_Click);
            // btnKhoaMoKhoa
            this.btnKhoaMoKhoa.BackColor = System.Drawing.Color.FromArgb(244, 67, 54);
            this.btnKhoaMoKhoa.FlatAppearance.BorderSize = 0;
            this.btnKhoaMoKhoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKhoaMoKhoa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnKhoaMoKhoa.ForeColor = System.Drawing.Color.White;
            this.btnKhoaMoKhoa.Location = new System.Drawing.Point(380, 10);
            this.btnKhoaMoKhoa.Size = new System.Drawing.Size(130, 30);
            this.btnKhoaMoKhoa.Text = "🔒 Khóa/Mở khóa";
            this.btnKhoaMoKhoa.Click += new System.EventHandler(this.btnKhoaMoKhoa_Click);
            // dgvData
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.ReadOnly = true;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.MultiSelect = false;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.ColumnHeadersHeight = 38;
            this.dgvData.RowTemplate.Height = 35;
            this.dgvData.EnableHeadersVisualStyles = false;
            h.BackColor = System.Drawing.Color.FromArgb(25, 118, 210); h.ForeColor = System.Drawing.Color.White;
            h.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.dgvData.ColumnHeadersDefaultCellStyle = h;
            this.dgvData.Columns.Add("colMaTK", "Mã");
            this.dgvData.Columns.Add("colTenDangNhap", "Tên đăng nhập");
            this.dgvData.Columns.Add("colNhanVien", "Nhân viên");
            this.dgvData.Columns.Add("colVaiTro", "Vai trò");
            this.dgvData.Columns.Add("colTrangThai", "Trạng thái");
            this.dgvData.Columns["colMaTK"].FillWeight = 40;
            this.dgvData.Columns["colTenDangNhap"].FillWeight = 100;
            this.dgvData.Columns["colNhanVien"].FillWeight = 110;
            this.dgvData.Columns["colVaiTro"].FillWeight = 80;
            this.dgvData.Columns["colTrangThai"].FillWeight = 60;
            // FormTaiKhoanManager
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.ClientSize = new System.Drawing.Size(900, 550);
            this.Controls.Add(this.dgvData); this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FormTaiKhoanManager"; this.Padding = new System.Windows.Forms.Padding(15);
            this.Text = "Quản lý Tài khoản";
            this.Load += new System.EventHandler(this.FormTaiKhoanManager_Load);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnThem, btnSua, btnResetMatKhau, btnKhoaMoKhoa;
        private System.Windows.Forms.DataGridView dgvData;
    }

    partial class FormTaiKhoanDetail
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.lblTenDangNhap = new System.Windows.Forms.Label();
            this.txtTenDangNhap = new System.Windows.Forms.TextBox();
            this.lblMatKhau = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.cmbNhanVien = new System.Windows.Forms.ComboBox();
            this.lblVaiTro = new System.Windows.Forms.Label();
            this.cmbVaiTro = new System.Windows.Forms.ComboBox();
            this.chkHoatDong = new System.Windows.Forms.CheckBox();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.pnlForm.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // pnlTop
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Size = new System.Drawing.Size(450, 50);
            this.pnlTop.BackColor = System.Drawing.Color.White;
            // lblTitle
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(15, 10);
            this.lblTitle.Size = new System.Drawing.Size(420, 30);
            this.lblTitle.Text = "Thông tin tài khoản";
            // pnlForm
            this.pnlForm.Controls.Add(this.chkHoatDong);
            this.pnlForm.Controls.Add(this.cmbVaiTro);
            this.pnlForm.Controls.Add(this.lblVaiTro);
            this.pnlForm.Controls.Add(this.cmbNhanVien);
            this.pnlForm.Controls.Add(this.lblNhanVien);
            this.pnlForm.Controls.Add(this.txtMatKhau);
            this.pnlForm.Controls.Add(this.lblMatKhau);
            this.pnlForm.Controls.Add(this.txtTenDangNhap);
            this.pnlForm.Controls.Add(this.lblTenDangNhap);
            this.pnlForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlForm.Location = new System.Drawing.Point(0, 50);
            this.pnlForm.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            // lblTenDangNhap
            this.lblTenDangNhap.Location = new System.Drawing.Point(20, 15); this.lblTenDangNhap.Size = new System.Drawing.Size(120, 20);
            this.lblTenDangNhap.Text = "Tên đăng nhập:";
            // txtTenDangNhap
            this.txtTenDangNhap.Location = new System.Drawing.Point(160, 12); this.txtTenDangNhap.Size = new System.Drawing.Size(250, 25);
            // lblMatKhau
            this.lblMatKhau.Location = new System.Drawing.Point(20, 48); this.lblMatKhau.Size = new System.Drawing.Size(120, 20);
            this.lblMatKhau.Text = "Mật khẩu:";
            // txtMatKhau
            this.txtMatKhau.Location = new System.Drawing.Point(160, 45); this.txtMatKhau.Size = new System.Drawing.Size(250, 25);
            this.txtMatKhau.UseSystemPasswordChar = true;
            // lblNhanVien
            this.lblNhanVien.Location = new System.Drawing.Point(20, 81); this.lblNhanVien.Size = new System.Drawing.Size(120, 20);
            this.lblNhanVien.Text = "Nhân viên:";
            // cmbNhanVien
            this.cmbNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNhanVien.Location = new System.Drawing.Point(160, 78); this.cmbNhanVien.Size = new System.Drawing.Size(250, 24);
            // lblVaiTro
            this.lblVaiTro.Location = new System.Drawing.Point(20, 114); this.lblVaiTro.Size = new System.Drawing.Size(120, 20);
            this.lblVaiTro.Text = "Vai trò:";
            // cmbVaiTro
            this.cmbVaiTro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVaiTro.Location = new System.Drawing.Point(160, 111); this.cmbVaiTro.Size = new System.Drawing.Size(250, 24);
            // chkHoatDong
            this.chkHoatDong.Location = new System.Drawing.Point(160, 150); this.chkHoatDong.Size = new System.Drawing.Size(150, 20);
            this.chkHoatDong.Text = "Tài khoản hoạt động";
            this.chkHoatDong.Checked = true;
            // pnlButtons
            this.pnlButtons.Controls.Add(this.btnHuy);
            this.pnlButtons.Controls.Add(this.btnLuu);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Height = 55;
            // btnLuu
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.btnLuu.FlatAppearance.BorderSize = 0;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(240, 12);
            this.btnLuu.Size = new System.Drawing.Size(90, 30);
            this.btnLuu.Text = "💾 Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // btnHuy
            this.btnHuy.BackColor = System.Drawing.Color.FromArgb(244, 67, 54);
            this.btnHuy.FlatAppearance.BorderSize = 0;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(340, 12);
            this.btnHuy.Size = new System.Drawing.Size(90, 30);
            this.btnHuy.Text = "✕ Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // FormTaiKhoanDetail
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 300);
            this.Controls.Add(this.pnlForm); this.Controls.Add(this.pnlButtons); this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FormTaiKhoanDetail";
            this.Text = "Tài khoản";
            this.Load += new System.EventHandler(this.FormTaiKhoanDetail_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Label lblTenDangNhap;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.Label lblMatKhau;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.ComboBox cmbNhanVien;
        private System.Windows.Forms.Label lblVaiTro;
        private System.Windows.Forms.ComboBox cmbVaiTro;
        private System.Windows.Forms.CheckBox chkHoatDong;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
    }
}

