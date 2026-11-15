using System;
using System.Drawing;
using System.Windows.Forms;

namespace baitaplon.GUI
{
    partial class FormNhanVien
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
            this.btnNghiViec = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // pnlTop
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.btnNghiViec);
            this.pnlTop.Controls.Add(this.btnSua);
            this.pnlTop.Controls.Add(this.btnThem);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(15, 15);
            this.pnlTop.Size = new System.Drawing.Size(970, 50);
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
            // btnNghiViec
            this.btnNghiViec.BackColor = System.Drawing.Color.FromArgb(255, 152, 0);
            this.btnNghiViec.FlatAppearance.BorderSize = 0;
            this.btnNghiViec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNghiViec.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnNghiViec.ForeColor = System.Drawing.Color.White;
            this.btnNghiViec.Location = new System.Drawing.Point(220, 10);
            this.btnNghiViec.Size = new System.Drawing.Size(110, 30);
            this.btnNghiViec.Text = "🚪 Nghỉ việc";
            this.btnNghiViec.Click += new System.EventHandler(this.btnNghiViec_Click);
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
            this.dgvData.Columns.Add("colMaNV", "Mã");
            this.dgvData.Columns.Add("colHoTen", "Họ tên");
            this.dgvData.Columns.Add("colGioiTinh", "Giới tính");
            this.dgvData.Columns.Add("colNgaySinh", "Ngày sinh");
            this.dgvData.Columns.Add("colSDT", "SĐT");
            this.dgvData.Columns.Add("colEmail", "Email");
            this.dgvData.Columns.Add("colDiaChi", "Địa chỉ");
            this.dgvData.Columns.Add("colChucVu", "Chức vụ");
            this.dgvData.Columns.Add("colTrangThai", "Trạng thái");
            // FormNhanVien
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.ClientSize = new System.Drawing.Size(1000, 550);
            this.Controls.Add(this.dgvData); this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FormNhanVien"; this.Padding = new System.Windows.Forms.Padding(15);
            this.Text = "Quản lý Nhân viên";
            this.Load += new System.EventHandler(this.FormNhanVien_Load);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnThem, btnSua, btnNghiViec;
        private System.Windows.Forms.DataGridView dgvData;
    }

    partial class FormNhanVienDetail
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
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.txtGioiTinh = new System.Windows.Forms.TextBox();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.lblSDT = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.lblChucVu = new System.Windows.Forms.Label();
            this.txtChucVu = new System.Windows.Forms.TextBox();
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
            this.lblTitle.Text = "Thông tin nhân viên";
            // pnlForm
            this.pnlForm.Controls.Add(this.txtChucVu);
            this.pnlForm.Controls.Add(this.lblChucVu);
            this.pnlForm.Controls.Add(this.txtDiaChi);
            this.pnlForm.Controls.Add(this.lblDiaChi);
            this.pnlForm.Controls.Add(this.txtEmail);
            this.pnlForm.Controls.Add(this.lblEmail);
            this.pnlForm.Controls.Add(this.txtSDT);
            this.pnlForm.Controls.Add(this.lblSDT);
            this.pnlForm.Controls.Add(this.dtpNgaySinh);
            this.pnlForm.Controls.Add(this.lblNgaySinh);
            this.pnlForm.Controls.Add(this.txtGioiTinh);
            this.pnlForm.Controls.Add(this.lblGioiTinh);
            this.pnlForm.Controls.Add(this.txtHoTen);
            this.pnlForm.Controls.Add(this.lblHoTen);
            this.pnlForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlForm.Location = new System.Drawing.Point(0, 50);
            this.pnlForm.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            // lblHoTen
            this.lblHoTen.Location = new System.Drawing.Point(20, 15); this.lblHoTen.Size = new System.Drawing.Size(80, 20);
            this.lblHoTen.Text = "Họ tên:";
            // txtHoTen
            this.txtHoTen.Location = new System.Drawing.Point(110, 12); this.txtHoTen.Size = new System.Drawing.Size(300, 25);
            // lblGioiTinh
            this.lblGioiTinh.Location = new System.Drawing.Point(20, 48); this.lblGioiTinh.Size = new System.Drawing.Size(80, 20);
            this.lblGioiTinh.Text = "Giới tính:";
            // txtGioiTinh
            this.txtGioiTinh.Location = new System.Drawing.Point(110, 45); this.txtGioiTinh.Size = new System.Drawing.Size(120, 25);
            // lblNgaySinh
            this.lblNgaySinh.Location = new System.Drawing.Point(250, 48); this.lblNgaySinh.Size = new System.Drawing.Size(80, 20);
            this.lblNgaySinh.Text = "Ngày sinh:";
            // dtpNgaySinh
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgaySinh.Location = new System.Drawing.Point(330, 45); this.dtpNgaySinh.Size = new System.Drawing.Size(80, 22);
            this.dtpNgaySinh.MaxDate = System.DateTime.Now;
            // lblSDT
            this.lblSDT.Location = new System.Drawing.Point(20, 81); this.lblSDT.Size = new System.Drawing.Size(80, 20);
            this.lblSDT.Text = "SĐT:";
            // txtSDT
            this.txtSDT.Location = new System.Drawing.Point(110, 78); this.txtSDT.Size = new System.Drawing.Size(300, 25);
            // lblEmail
            this.lblEmail.Location = new System.Drawing.Point(20, 114); this.lblEmail.Size = new System.Drawing.Size(80, 20);
            this.lblEmail.Text = "Email:";
            // txtEmail
            this.txtEmail.Location = new System.Drawing.Point(110, 111); this.txtEmail.Size = new System.Drawing.Size(300, 25);
            // lblDiaChi
            this.lblDiaChi.Location = new System.Drawing.Point(20, 147); this.lblDiaChi.Size = new System.Drawing.Size(80, 20);
            this.lblDiaChi.Text = "Địa chỉ:";
            // txtDiaChi
            this.txtDiaChi.Location = new System.Drawing.Point(110, 144); this.txtDiaChi.Size = new System.Drawing.Size(300, 25);
            // lblChucVu
            this.lblChucVu.Location = new System.Drawing.Point(20, 180); this.lblChucVu.Size = new System.Drawing.Size(80, 20);
            this.lblChucVu.Text = "Chức vụ:";
            // txtChucVu
            this.txtChucVu.Location = new System.Drawing.Point(110, 177); this.txtChucVu.Size = new System.Drawing.Size(300, 25);
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
            // FormNhanVienDetail
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 320);
            this.Controls.Add(this.pnlForm); this.Controls.Add(this.pnlButtons); this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FormNhanVienDetail";
            this.Text = "Nhân viên";
            this.Load += new System.EventHandler(this.FormNhanVienDetail_Load);
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
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblGioiTinh;
        private System.Windows.Forms.TextBox txtGioiTinh;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label lblChucVu;
        private System.Windows.Forms.TextBox txtChucVu;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
    }
}

