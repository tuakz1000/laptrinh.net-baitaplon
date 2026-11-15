namespace baitaplon.GUI
{
    partial class FormSanPhamDetail
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblMaSP = new System.Windows.Forms.Label();
            this.txtMaSP = new System.Windows.Forms.TextBox();
            this.lblTenSP = new System.Windows.Forms.Label();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.lblDanhMuc = new System.Windows.Forms.Label();
            this.cmbDanhMuc = new System.Windows.Forms.ComboBox();
            this.lblDVT = new System.Windows.Forms.Label();
            this.cmbDVT = new System.Windows.Forms.ComboBox();
            this.lblGiaNhap = new System.Windows.Forms.Label();
            this.txtGiaNhap = new System.Windows.Forms.TextBox();
            this.lblGiaBan = new System.Windows.Forms.Label();
            this.txtGiaBan = new System.Windows.Forms.TextBox();
            this.lblTonMin = new System.Windows.Forms.Label();
            this.numTonToiThieu = new System.Windows.Forms.NumericUpDown();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numTonToiThieu)).BeginInit();
            this.SuspendLayout();
            // lblTitle
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(25, 118, 210);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Size = new System.Drawing.Size(440, 30);
            this.lblTitle.Text = "➕ Thêm sản phẩm mới";
            // lblMaSP
            this.lblMaSP.AutoSize = true; this.lblMaSP.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblMaSP.Location = new System.Drawing.Point(20, 60); this.lblMaSP.Text = "Mã sản phẩm:";
            // txtMaSP
            this.txtMaSP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaSP.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMaSP.Location = new System.Drawing.Point(160, 57); this.txtMaSP.Size = new System.Drawing.Size(150, 25);
            this.txtMaSP.ReadOnly = true; this.txtMaSP.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            // lblTenSP
            this.lblTenSP.AutoSize = true; this.lblTenSP.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTenSP.Location = new System.Drawing.Point(20, 95); this.lblTenSP.Text = "Tên sản phẩm: *";
            // txtTenSP
            this.txtTenSP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTenSP.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTenSP.Location = new System.Drawing.Point(160, 92); this.txtTenSP.Size = new System.Drawing.Size(300, 25);
            // lblDanhMuc
            this.lblDanhMuc.AutoSize = true; this.lblDanhMuc.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDanhMuc.Location = new System.Drawing.Point(20, 130); this.lblDanhMuc.Text = "Danh mục:";
            // cmbDanhMuc
            this.cmbDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDanhMuc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbDanhMuc.Location = new System.Drawing.Point(160, 127); this.cmbDanhMuc.Size = new System.Drawing.Size(200, 25);
            // lblDVT
            this.lblDVT.AutoSize = true; this.lblDVT.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDVT.Location = new System.Drawing.Point(20, 165); this.lblDVT.Text = "Đơn vị tính:";
            // cmbDVT
            this.cmbDVT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDVT.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbDVT.Location = new System.Drawing.Point(160, 162); this.cmbDVT.Size = new System.Drawing.Size(150, 25);
            // lblGiaNhap
            this.lblGiaNhap.AutoSize = true; this.lblGiaNhap.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblGiaNhap.Location = new System.Drawing.Point(20, 200); this.lblGiaNhap.Text = "Giá nhập (VNĐ):";
            // txtGiaNhap
            this.txtGiaNhap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGiaNhap.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtGiaNhap.Location = new System.Drawing.Point(160, 197); this.txtGiaNhap.Size = new System.Drawing.Size(150, 25);
            this.txtGiaNhap.TextAlign = System.Windows.Forms.HorizontalAlignment.Right; this.txtGiaNhap.Text = "0";
            // lblGiaBan
            this.lblGiaBan.AutoSize = true; this.lblGiaBan.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblGiaBan.Location = new System.Drawing.Point(20, 235); this.lblGiaBan.Text = "Giá bán (VNĐ):";
            // txtGiaBan
            this.txtGiaBan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGiaBan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtGiaBan.Location = new System.Drawing.Point(160, 232); this.txtGiaBan.Size = new System.Drawing.Size(150, 25);
            this.txtGiaBan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right; this.txtGiaBan.Text = "0";
            // lblTonMin
            this.lblTonMin.AutoSize = true; this.lblTonMin.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTonMin.Location = new System.Drawing.Point(20, 270); this.lblTonMin.Text = "Tồn tối thiểu:";
            // numTonToiThieu
            this.numTonToiThieu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numTonToiThieu.Location = new System.Drawing.Point(160, 267); this.numTonToiThieu.Size = new System.Drawing.Size(100, 25);
            this.numTonToiThieu.Minimum = 0; this.numTonToiThieu.Maximum = 99999; this.numTonToiThieu.Value = 10;
            // lblMoTa
            this.lblMoTa.AutoSize = true; this.lblMoTa.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblMoTa.Location = new System.Drawing.Point(20, 305); this.lblMoTa.Text = "Mô tả:";
            // txtMoTa
            this.txtMoTa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMoTa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMoTa.Location = new System.Drawing.Point(160, 302); this.txtMoTa.Size = new System.Drawing.Size(300, 60);
            this.txtMoTa.Multiline = true; this.txtMoTa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            // btnLuu
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.btnLuu.FlatAppearance.BorderSize = 0; this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(160, 380); this.btnLuu.Size = new System.Drawing.Size(120, 38);
            this.btnLuu.Text = "💾 Lưu"; this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // btnHuy
            this.btnHuy.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnHuy.FlatAppearance.BorderSize = 0; this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(290, 380); this.btnHuy.Size = new System.Drawing.Size(100, 38);
            this.btnHuy.Text = "Hủy"; this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // FormSanPhamDetail
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(490, 440);
            this.Controls.Add(this.lblTitle); this.Controls.Add(this.lblMaSP); this.Controls.Add(this.txtMaSP);
            this.Controls.Add(this.lblTenSP); this.Controls.Add(this.txtTenSP);
            this.Controls.Add(this.lblDanhMuc); this.Controls.Add(this.cmbDanhMuc);
            this.Controls.Add(this.lblDVT); this.Controls.Add(this.cmbDVT);
            this.Controls.Add(this.lblGiaNhap); this.Controls.Add(this.txtGiaNhap);
            this.Controls.Add(this.lblGiaBan); this.Controls.Add(this.txtGiaBan);
            this.Controls.Add(this.lblTonMin); this.Controls.Add(this.numTonToiThieu);
            this.Controls.Add(this.lblMoTa); this.Controls.Add(this.txtMoTa);
            this.Controls.Add(this.btnLuu); this.Controls.Add(this.btnHuy);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false; this.MinimizeBox = false;
            this.Name = "FormSanPhamDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sản phẩm";
            this.Load += new System.EventHandler(this.FormSanPhamDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numTonToiThieu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
        private System.Windows.Forms.Label lblTitle, lblMaSP, lblTenSP, lblDanhMuc, lblDVT, lblGiaNhap, lblGiaBan, lblTonMin, lblMoTa;
        private System.Windows.Forms.TextBox txtMaSP, txtTenSP, txtGiaNhap, txtGiaBan, txtMoTa;
        private System.Windows.Forms.ComboBox cmbDanhMuc, cmbDVT;
        private System.Windows.Forms.NumericUpDown numTonToiThieu;
        private System.Windows.Forms.Button btnLuu, btnHuy;
    }
}


