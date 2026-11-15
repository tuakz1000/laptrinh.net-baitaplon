namespace baitaplon.GUI
{
    partial class FormDangNhap
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.lblAppTitle = new System.Windows.Forms.Label();
            this.lblAppSubtitle = new System.Windows.Forms.Label();
            this.lblAppIcon = new System.Windows.Forms.Label();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlLoginBox = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTenDangNhap = new System.Windows.Forms.Label();
            this.txtTenDangNhap = new System.Windows.Forms.TextBox();
            this.lblMatKhau = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.chkHienMatKhau = new System.Windows.Forms.CheckBox();
            this.chkLuuThongTin = new System.Windows.Forms.CheckBox();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.lblThongBao = new System.Windows.Forms.Label();
            this.pnlLeft.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlLoginBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.pnlLeft.Controls.Add(this.lblAppIcon);
            this.pnlLeft.Controls.Add(this.lblAppTitle);
            this.pnlLeft.Controls.Add(this.lblAppSubtitle);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(380, 500);
            this.pnlLeft.TabIndex = 0;
            // 
            // lblAppIcon
            // 
            this.lblAppIcon.Font = new System.Drawing.Font("Segoe UI", 48F);
            this.lblAppIcon.ForeColor = System.Drawing.Color.White;
            this.lblAppIcon.Location = new System.Drawing.Point(0, 120);
            this.lblAppIcon.Name = "lblAppIcon";
            this.lblAppIcon.Size = new System.Drawing.Size(380, 90);
            this.lblAppIcon.TabIndex = 0;
            this.lblAppIcon.Text = "📦";
            this.lblAppIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAppTitle
            // 
            this.lblAppTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblAppTitle.ForeColor = System.Drawing.Color.White;
            this.lblAppTitle.Location = new System.Drawing.Point(0, 220);
            this.lblAppTitle.Name = "lblAppTitle";
            this.lblAppTitle.Size = new System.Drawing.Size(380, 40);
            this.lblAppTitle.TabIndex = 1;
            this.lblAppTitle.Text = "QUẢN LÝ KHO HÀNG";
            this.lblAppTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAppSubtitle
            // 
            this.lblAppSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAppSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lblAppSubtitle.Location = new System.Drawing.Point(0, 265);
            this.lblAppSubtitle.Name = "lblAppSubtitle";
            this.lblAppSubtitle.Size = new System.Drawing.Size(380, 25);
            this.lblAppSubtitle.TabIndex = 2;
            this.lblAppSubtitle.Text = "Warehouse Management System";
            this.lblAppSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.pnlRight.Controls.Add(this.pnlLoginBox);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(380, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(420, 500);
            this.pnlRight.TabIndex = 1;
            // 
            // pnlLoginBox
            // 
            this.pnlLoginBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlLoginBox.BackColor = System.Drawing.Color.White;
            this.pnlLoginBox.Controls.Add(this.lblTitle);
            this.pnlLoginBox.Controls.Add(this.lblSubtitle);
            this.pnlLoginBox.Controls.Add(this.lblTenDangNhap);
            this.pnlLoginBox.Controls.Add(this.txtTenDangNhap);
            this.pnlLoginBox.Controls.Add(this.lblMatKhau);
            this.pnlLoginBox.Controls.Add(this.txtMatKhau);
            this.pnlLoginBox.Controls.Add(this.chkHienMatKhau);
            this.pnlLoginBox.Controls.Add(this.chkLuuThongTin);
            this.pnlLoginBox.Controls.Add(this.btnDangNhap);
            this.pnlLoginBox.Controls.Add(this.lblThongBao);
            this.pnlLoginBox.Location = new System.Drawing.Point(40, 60);
            this.pnlLoginBox.Name = "pnlLoginBox";
            this.pnlLoginBox.Padding = new System.Windows.Forms.Padding(30);
            this.pnlLoginBox.Size = new System.Drawing.Size(340, 380);
            this.pnlLoginBox.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblTitle.Location = new System.Drawing.Point(30, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(280, 35);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Đăng nhập";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblSubtitle.Location = new System.Drawing.Point(30, 60);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(280, 20);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Vui lòng đăng nhập để tiếp tục";
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTenDangNhap
            // 
            this.lblTenDangNhap.AutoSize = true;
            this.lblTenDangNhap.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTenDangNhap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblTenDangNhap.Location = new System.Drawing.Point(30, 100);
            this.lblTenDangNhap.Name = "lblTenDangNhap";
            this.lblTenDangNhap.Size = new System.Drawing.Size(101, 17);
            this.lblTenDangNhap.TabIndex = 2;
            this.lblTenDangNhap.Text = "Tên đăng nhập";
            // 
            // txtTenDangNhap
            // 
            this.txtTenDangNhap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTenDangNhap.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtTenDangNhap.Location = new System.Drawing.Point(30, 122);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Size = new System.Drawing.Size(280, 27);
            this.txtTenDangNhap.TabIndex = 3;
            this.txtTenDangNhap.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTenDangNhap_KeyDown);
            // 
            // lblMatKhau
            // 
            this.lblMatKhau.AutoSize = true;
            this.lblMatKhau.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblMatKhau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblMatKhau.Location = new System.Drawing.Point(30, 165);
            this.lblMatKhau.Name = "lblMatKhau";
            this.lblMatKhau.Size = new System.Drawing.Size(65, 17);
            this.lblMatKhau.TabIndex = 4;
            this.lblMatKhau.Text = "Mật khẩu";
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMatKhau.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtMatKhau.Location = new System.Drawing.Point(30, 187);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(280, 27);
            this.txtMatKhau.TabIndex = 5;
            this.txtMatKhau.UseSystemPasswordChar = true;
            this.txtMatKhau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMatKhau_KeyDown);
            // 
            // chkHienMatKhau
            // 
            // chkHienMatKhau
            //
            this.chkHienMatKhau.AutoSize = true;
            this.chkHienMatKhau.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkHienMatKhau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.chkHienMatKhau.Location = new System.Drawing.Point(30, 222);
            this.chkHienMatKhau.Name = "chkHienMatKhau";
            this.chkHienMatKhau.Size = new System.Drawing.Size(114, 19);
            this.chkHienMatKhau.TabIndex = 6;
            this.chkHienMatKhau.Text = "Hiện mật khẩu";
            this.chkHienMatKhau.CheckedChanged += new System.EventHandler(this.chkHienMatKhau_CheckedChanged);
            //
            // chkLuuThongTin
            //
            this.chkLuuThongTin.AutoSize = true;
            this.chkLuuThongTin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkLuuThongTin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.chkLuuThongTin.Location = new System.Drawing.Point(160, 222);
            this.chkLuuThongTin.Name = "chkLuuThongTin";
            this.chkLuuThongTin.Size = new System.Drawing.Size(140, 19);
            this.chkLuuThongTin.TabIndex = 7;
            this.chkLuuThongTin.Text = "Lưu thông tin đăng nhập";
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.btnDangNhap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDangNhap.FlatAppearance.BorderSize = 0;
            this.btnDangNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangNhap.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDangNhap.ForeColor = System.Drawing.Color.White;
            this.btnDangNhap.Location = new System.Drawing.Point(30, 260);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(280, 42);
            this.btnDangNhap.TabIndex = 8;
            this.btnDangNhap.Text = "ĐĂNG NHẬP";
            this.btnDangNhap.UseVisualStyleBackColor = false;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // lblThongBao
            // 
            this.lblThongBao.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblThongBao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.lblThongBao.Location = new System.Drawing.Point(30, 315);
            this.lblThongBao.Name = "lblThongBao";
            this.lblThongBao.Size = new System.Drawing.Size(280, 40);
            this.lblThongBao.TabIndex = 9;
            this.lblThongBao.Text = "";
            this.lblThongBao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormDangNhap
            // 
            this.AcceptButton = this.btnDangNhap;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormDangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập - Quản lý Kho hàng";
            this.Load += new System.EventHandler(this.FormDangNhap_Load);
            this.pnlLeft.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlLoginBox.ResumeLayout(false);
            this.pnlLoginBox.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Label lblAppIcon;
        private System.Windows.Forms.Label lblAppTitle;
        private System.Windows.Forms.Label lblAppSubtitle;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlLoginBox;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblTenDangNhap;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.Label lblMatKhau;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.CheckBox chkHienMatKhau;
        private System.Windows.Forms.CheckBox chkLuuThongTin;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.Label lblThongBao;
    }
}


