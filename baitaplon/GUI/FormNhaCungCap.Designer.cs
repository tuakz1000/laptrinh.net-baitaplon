using System;
using System.Drawing;
using System.Windows.Forms;

namespace baitaplon.GUI
{
    partial class FormNhaCungCap
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle h = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.lblTong = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // pnlTop
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.lblTong);
            this.pnlTop.Controls.Add(this.btnTimKiem);
            this.pnlTop.Controls.Add(this.txtTimKiem);
            this.pnlTop.Controls.Add(this.btnSua);
            this.pnlTop.Controls.Add(this.btnThem);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(15, 15);
            this.pnlTop.Size = new System.Drawing.Size(870, 50);
            // btnThem
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.btnThem.FlatAppearance.BorderSize = 0; this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(10, 10); this.btnThem.Size = new System.Drawing.Size(100, 30);
            this.btnThem.Text = "➕ Thêm mới"; this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // btnSua
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(25, 118, 210);
            this.btnSua.FlatAppearance.BorderSize = 0; this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(120, 10); this.btnSua.Size = new System.Drawing.Size(90, 30);
            this.btnSua.Text = "✏ Chỉnh sửa"; this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // txtTimKiem
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTimKiem.Location = new System.Drawing.Point(380, 13); this.txtTimKiem.Size = new System.Drawing.Size(250, 25);
            this.txtTimKiem.Text = "Tìm kiếm...";
            this.txtTimKiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTimKiem_KeyDown);
            // btnTimKiem
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnTimKiem.FlatAppearance.BorderSize = 0; this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(640, 10); this.btnTimKiem.Size = new System.Drawing.Size(90, 30);
            this.btnTimKiem.Text = "🔍 Tìm"; this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // lblTong
            this.lblTong.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTong.Location = new System.Drawing.Point(740, 16); this.lblTong.Size = new System.Drawing.Size(120, 20);
            this.lblTong.Text = "Tổng: 0";
            // dgvData
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.AllowUserToAddRows = false; this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.ReadOnly = true; this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.MultiSelect = false; this.dgvData.RowHeadersVisible = false;
            this.dgvData.BackgroundColor = System.Drawing.Color.White; this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.ColumnHeadersHeight = 38; this.dgvData.RowTemplate.Height = 35;
            this.dgvData.EnableHeadersVisualStyles = false;
            h.BackColor = System.Drawing.Color.FromArgb(25, 118, 210); h.ForeColor = System.Drawing.Color.White;
            h.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.dgvData.ColumnHeadersDefaultCellStyle = h;
            this.dgvData.Columns.Add("colMaNCC", "Mã");
            this.dgvData.Columns.Add("colTenNCC", "Tên nhà cung cấp");
            this.dgvData.Columns.Add("colNguoiLH", "Người liên hệ");
            this.dgvData.Columns.Add("colSDT", "Số điện thoại");
            this.dgvData.Columns.Add("colEmail", "Email");
            this.dgvData.Columns.Add("colDiaChi", "Địa chỉ");
            this.dgvData.Columns.Add("colTrangThai", "Trạng thái");
            this.dgvData.Columns["colMaNCC"].FillWeight = 40;
            this.dgvData.Columns["colTenNCC"].FillWeight = 120;
            this.dgvData.Columns["colNguoiLH"].FillWeight = 80;
            this.dgvData.Columns["colSDT"].FillWeight = 60;
            this.dgvData.Columns["colEmail"].FillWeight = 80;
            this.dgvData.Columns["colDiaChi"].FillWeight = 100;
            this.dgvData.Columns["colTrangThai"].FillWeight = 50;
            this.dgvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellDoubleClick);
            // FormNhaCungCap
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.ClientSize = new System.Drawing.Size(900, 550);
            this.Controls.Add(this.dgvData); this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FormNhaCungCap"; this.Padding = new System.Windows.Forms.Padding(15);
            this.Text = "Quản lý Nhà cung cấp";
            this.Load += new System.EventHandler(this.FormNhaCungCap_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnThem, btnSua, btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lblTong;
        private System.Windows.Forms.DataGridView dgvData;
    }

    partial class FormNhaCungCapDetail
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.lblTen = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.lblNguoiLH = new System.Windows.Forms.Label();
            this.txtNguoiLH = new System.Windows.Forms.TextBox();
            this.lblSDT = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
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
            this.lblTitle.Text = "Thông tin nhà cung cấp";
            // pnlForm
            this.pnlForm.Controls.Add(this.txtDiaChi);
            this.pnlForm.Controls.Add(this.lblDiaChi);
            this.pnlForm.Controls.Add(this.txtEmail);
            this.pnlForm.Controls.Add(this.lblEmail);
            this.pnlForm.Controls.Add(this.txtSDT);
            this.pnlForm.Controls.Add(this.lblSDT);
            this.pnlForm.Controls.Add(this.txtNguoiLH);
            this.pnlForm.Controls.Add(this.lblNguoiLH);
            this.pnlForm.Controls.Add(this.txtTen);
            this.pnlForm.Controls.Add(this.lblTen);
            this.pnlForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlForm.Location = new System.Drawing.Point(0, 50);
            this.pnlForm.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            // lblTen
            this.lblTen.Location = new System.Drawing.Point(20, 15); this.lblTen.Size = new System.Drawing.Size(80, 20);
            this.lblTen.Text = "Tên NCC:";
            // txtTen
            this.txtTen.Location = new System.Drawing.Point(110, 12); this.txtTen.Size = new System.Drawing.Size(300, 25);
            // lblNguoiLH
            this.lblNguoiLH.Location = new System.Drawing.Point(20, 50); this.lblNguoiLH.Size = new System.Drawing.Size(80, 20);
            this.lblNguoiLH.Text = "Người LH:";
            // txtNguoiLH
            this.txtNguoiLH.Location = new System.Drawing.Point(110, 47); this.txtNguoiLH.Size = new System.Drawing.Size(300, 25);
            // lblSDT
            this.lblSDT.Location = new System.Drawing.Point(20, 85); this.lblSDT.Size = new System.Drawing.Size(80, 20);
            this.lblSDT.Text = "SĐT:";
            // txtSDT
            this.txtSDT.Location = new System.Drawing.Point(110, 82); this.txtSDT.Size = new System.Drawing.Size(300, 25);
            // lblEmail
            this.lblEmail.Location = new System.Drawing.Point(20, 120); this.lblEmail.Size = new System.Drawing.Size(80, 20);
            this.lblEmail.Text = "Email:";
            // txtEmail
            this.txtEmail.Location = new System.Drawing.Point(110, 117); this.txtEmail.Size = new System.Drawing.Size(300, 25);
            // lblDiaChi
            this.lblDiaChi.Location = new System.Drawing.Point(20, 155); this.lblDiaChi.Size = new System.Drawing.Size(80, 20);
            this.lblDiaChi.Text = "Địa chỉ:";
            // txtDiaChi
            this.txtDiaChi.Location = new System.Drawing.Point(110, 152); this.txtDiaChi.Size = new System.Drawing.Size(300, 25);
            // pnlButtons
            this.pnlButtons.Controls.Add(this.btnHuy);
            this.pnlButtons.Controls.Add(this.btnLuu);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Height = 55;
            // btnLuu
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.btnLuu.FlatAppearance.BorderSize = 0; this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(240, 12); this.btnLuu.Size = new System.Drawing.Size(90, 30);
            this.btnLuu.Text = "💾 Lưu"; this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // btnHuy
            this.btnHuy.BackColor = System.Drawing.Color.FromArgb(244, 67, 54);
            this.btnHuy.FlatAppearance.BorderSize = 0; this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(340, 12); this.btnHuy.Size = new System.Drawing.Size(90, 30);
            this.btnHuy.Text = "✕ Hủy"; this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // FormNhaCungCapDetail
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 270);
            this.Controls.Add(this.pnlForm); this.Controls.Add(this.pnlButtons); this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FormNhaCungCapDetail";
            this.Text = "Nhà cung cấp";
            this.Load += new System.EventHandler(this.FormNhaCungCapDetail_Load);
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
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Label lblNguoiLH;
        private System.Windows.Forms.TextBox txtNguoiLH;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
    }
}

