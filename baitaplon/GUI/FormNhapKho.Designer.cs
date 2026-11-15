using System;
using System.Drawing;
using System.Windows.Forms;

namespace baitaplon.GUI
{
    partial class FormNhapKho
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
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.cmbNCC = new System.Windows.Forms.ComboBox();
            this.cmbTrangThai = new System.Windows.Forms.ComboBox();
            this.btnLoc = new System.Windows.Forms.Button();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.dgvPhieu = new System.Windows.Forms.DataGridView();
            this.pnlFilter.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieu)).BeginInit();
            this.SuspendLayout();
            // pnlFilter
            this.pnlFilter.BackColor = System.Drawing.Color.White;
            this.pnlFilter.Controls.Add(this.btnLoc);
            this.pnlFilter.Controls.Add(this.cmbTrangThai);
            this.pnlFilter.Controls.Add(this.cmbNCC);
            this.pnlFilter.Controls.Add(this.dtpDenNgay);
            this.pnlFilter.Controls.Add(this.dtpTuNgay);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Size = new System.Drawing.Size(1000, 50);
            // dtpTuNgay
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(10, 12);
            this.dtpTuNgay.Size = new System.Drawing.Size(110, 22);
            // dtpDenNgay
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(125, 12);
            this.dtpDenNgay.Size = new System.Drawing.Size(110, 22);
            // cmbNCC
            this.cmbNCC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNCC.Location = new System.Drawing.Point(240, 12);
            this.cmbNCC.Size = new System.Drawing.Size(220, 24);
            // cmbTrangThai
            this.cmbTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrangThai.Location = new System.Drawing.Point(465, 12);
            this.cmbTrangThai.Size = new System.Drawing.Size(140, 24);
            // btnLoc
            this.btnLoc.BackColor = System.Drawing.Color.FromArgb(25, 118, 210);
            this.btnLoc.FlatAppearance.BorderSize = 0;
            this.btnLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLoc.ForeColor = System.Drawing.Color.White;
            this.btnLoc.Location = new System.Drawing.Point(610, 10);
            this.btnLoc.Size = new System.Drawing.Size(80, 30);
            this.btnLoc.Text = "🔍 Lọc";
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // pnlButtons
            this.pnlButtons.BackColor = System.Drawing.Color.White;
            this.pnlButtons.Controls.Add(this.btnHuy);
            this.pnlButtons.Controls.Add(this.btnXacNhan);
            this.pnlButtons.Controls.Add(this.btnSua);
            this.pnlButtons.Controls.Add(this.btnThem);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlButtons.Location = new System.Drawing.Point(0, 50);
            this.pnlButtons.Size = new System.Drawing.Size(1000, 50);
            // btnThem
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(10, 10);
            this.btnThem.Size = new System.Drawing.Size(110, 30);
            this.btnThem.Text = "➕ Tạo phiếu";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // btnSua
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(25, 118, 210);
            this.btnSua.FlatAppearance.BorderSize = 0;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(125, 10);
            this.btnSua.Size = new System.Drawing.Size(90, 30);
            this.btnSua.Text = "✏ Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // btnXacNhan
            this.btnXacNhan.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.btnXacNhan.FlatAppearance.BorderSize = 0;
            this.btnXacNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXacNhan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXacNhan.ForeColor = System.Drawing.Color.White;
            this.btnXacNhan.Location = new System.Drawing.Point(220, 10);
            this.btnXacNhan.Size = new System.Drawing.Size(110, 30);
            this.btnXacNhan.Text = "✔ Xác nhận";
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // btnHuy
            this.btnHuy.BackColor = System.Drawing.Color.FromArgb(244, 67, 54);
            this.btnHuy.FlatAppearance.BorderSize = 0;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(335, 10);
            this.btnHuy.Size = new System.Drawing.Size(90, 30);
            this.btnHuy.Text = "✕ Hủy phiếu";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // dgvPhieu
            this.dgvPhieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPhieu.AllowUserToAddRows = false;
            this.dgvPhieu.AllowUserToDeleteRows = false;
            this.dgvPhieu.ReadOnly = true;
            this.dgvPhieu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhieu.MultiSelect = false;
            this.dgvPhieu.RowHeadersVisible = false;
            this.dgvPhieu.BackgroundColor = System.Drawing.Color.White;
            this.dgvPhieu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPhieu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhieu.ColumnHeadersHeight = 38;
            this.dgvPhieu.RowTemplate.Height = 35;
            this.dgvPhieu.EnableHeadersVisualStyles = false;
            h.BackColor = System.Drawing.Color.FromArgb(25, 118, 210); h.ForeColor = System.Drawing.Color.White;
            h.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.dgvPhieu.ColumnHeadersDefaultCellStyle = h;
            this.dgvPhieu.Columns.Add("colMaPhieu", "Mã");
            this.dgvPhieu.Columns.Add("colCode", "Mã phiếu");
            this.dgvPhieu.Columns.Add("colNCC", "Nhà cung cấp");
            this.dgvPhieu.Columns.Add("colNgay", "Ngày nhập");
            this.dgvPhieu.Columns.Add("colTongTien", "Tổng tiền");
            this.dgvPhieu.Columns.Add("colTrangThai", "Trạng thái");
            this.dgvPhieu.Columns["colMaPhieu"].FillWeight = 40;
            this.dgvPhieu.Columns["colCode"].FillWeight = 100;
            this.dgvPhieu.Columns["colNCC"].FillWeight = 130;
            this.dgvPhieu.Columns["colNgay"].FillWeight = 60;
            this.dgvPhieu.Columns["colTongTien"].FillWeight = 80;
            this.dgvPhieu.Columns["colTrangThai"].FillWeight = 60;
            this.dgvPhieu.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhieu_CellDoubleClick);
            // FormNhapKho
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.ClientSize = new System.Drawing.Size(1000, 550);
            this.Controls.Add(this.dgvPhieu);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlFilter);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FormNhapKho";
            this.Text = "Quản lý Nhập kho";
            this.Load += new System.EventHandler(this.FormNhapKho_Load);
            this.pnlFilter.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieu)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.ComboBox cmbNCC;
        private System.Windows.Forms.ComboBox cmbTrangThai;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.DataGridView dgvPhieu;
    }

    partial class FormNhapKhoDetail
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
            this.lblMaPhieu = new System.Windows.Forms.Label();
            this.txtMaPhieu = new System.Windows.Forms.TextBox();
            this.lblNgayNhap = new System.Windows.Forms.Label();
            this.dtpNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.lblNCC = new System.Windows.Forms.Label();
            this.cmbNCC = new System.Windows.Forms.ComboBox();
            this.dgvChiTiet = new System.Windows.Forms.DataGridView();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.btnThemSP = new System.Windows.Forms.Button();
            this.btnXoaSP = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // pnlTop
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.lblGhiChu);
            this.pnlTop.Controls.Add(this.txtGhiChu);
            this.pnlTop.Controls.Add(this.cmbNCC);
            this.pnlTop.Controls.Add(this.lblNCC);
            this.pnlTop.Controls.Add(this.dtpNgayNhap);
            this.pnlTop.Controls.Add(this.lblNgayNhap);
            this.pnlTop.Controls.Add(this.txtMaPhieu);
            this.pnlTop.Controls.Add(this.lblMaPhieu);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Size = new System.Drawing.Size(700, 90);
            // lblMaPhieu
            this.lblMaPhieu.Location = new System.Drawing.Point(10, 15);
            this.lblMaPhieu.Size = new System.Drawing.Size(70, 20);
            this.lblMaPhieu.Text = "Mã phiếu:";
            // txtMaPhieu
            this.txtMaPhieu.Location = new System.Drawing.Point(90, 12);
            this.txtMaPhieu.ReadOnly = true;
            this.txtMaPhieu.Size = new System.Drawing.Size(120, 25);
            // lblNgayNhap
            this.lblNgayNhap.Location = new System.Drawing.Point(230, 15);
            this.lblNgayNhap.Size = new System.Drawing.Size(70, 20);
            this.lblNgayNhap.Text = "Ngày nhập:";
            // dtpNgayNhap
            this.dtpNgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayNhap.Location = new System.Drawing.Point(315, 12);
            this.dtpNgayNhap.Size = new System.Drawing.Size(110, 22);
            // lblNCC
            this.lblNCC.Location = new System.Drawing.Point(10, 48);
            this.lblNCC.Size = new System.Drawing.Size(70, 20);
            this.lblNCC.Text = "Nhà cung cấp:";
            // cmbNCC
            this.cmbNCC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNCC.Location = new System.Drawing.Point(110, 45);
            this.cmbNCC.Size = new System.Drawing.Size(300, 24);
            // lblGhiChu
            this.lblGhiChu.Location = new System.Drawing.Point(425, 48);
            this.lblGhiChu.Size = new System.Drawing.Size(50, 20);
            this.lblGhiChu.Text = "Ghi chú:";
            // txtGhiChu
            this.txtGhiChu.Location = new System.Drawing.Point(480, 45);
            this.txtGhiChu.Size = new System.Drawing.Size(200, 25);
            // dgvChiTiet
            this.dgvChiTiet.AllowUserToAddRows = false;
            this.dgvChiTiet.AllowUserToDeleteRows = false;
            this.dgvChiTiet.RowHeadersVisible = false;
            this.dgvChiTiet.AllowUserToOrderColumns = false;
            this.dgvChiTiet.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTiet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvChiTiet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTiet.ColumnHeadersHeight = 38;
            this.dgvChiTiet.RowTemplate.Height = 35;
            this.dgvChiTiet.EnableHeadersVisualStyles = false;
            this.dgvChiTiet.Columns.Add("colMaSP", "Mã SP");
            this.dgvChiTiet.Columns.Add("colMaSPCode", "Mã");
            this.dgvChiTiet.Columns.Add("colTenSP", "Tên sản phẩm");
            this.dgvChiTiet.Columns.Add("colDVT", "ĐVT");
            this.dgvChiTiet.Columns.Add("colSoLuong", "Số lượng");
            this.dgvChiTiet.Columns.Add("colDonGia", "Đơn giá");
            this.dgvChiTiet.Columns.Add("colThanhTien", "Thành tiền");
            this.dgvChiTiet.Columns["colSoLuong"].ValueType = typeof(int);
            this.dgvChiTiet.Columns["colDonGia"].ValueType = typeof(decimal);
            this.dgvChiTiet.Columns["colThanhTien"].ValueType = typeof(decimal);
            this.dgvChiTiet.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChiTiet_CellEndEdit);
            this.dgvChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            // pnlBottom
            this.pnlBottom.BackColor = System.Drawing.Color.White;
            this.pnlBottom.Controls.Add(this.lblTongTien);
            this.pnlBottom.Controls.Add(this.btnThemSP);
            this.pnlBottom.Controls.Add(this.btnXoaSP);
            this.pnlBottom.Controls.Add(this.btnLuu);
            this.pnlBottom.Controls.Add(this.btnHuy);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Height = 50;
            // lblTongTien
            this.lblTongTien.Location = new System.Drawing.Point(10, 15);
            this.lblTongTien.Size = new System.Drawing.Size(200, 20);
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.Text = "Tổng tiền: 0 đ";
            // btnThemSP
            this.btnThemSP.BackColor = System.Drawing.Color.FromArgb(25, 118, 210);
            this.btnThemSP.FlatAppearance.BorderSize = 0;
            this.btnThemSP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemSP.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnThemSP.ForeColor = System.Drawing.Color.White;
            this.btnThemSP.Location = new System.Drawing.Point(250, 10);
            this.btnThemSP.Size = new System.Drawing.Size(100, 30);
            this.btnThemSP.Text = "➕ Thêm SP";
            this.btnThemSP.Click += new System.EventHandler(this.btnThemSP_Click);
            // btnXoaSP
            this.btnXoaSP.BackColor = System.Drawing.Color.FromArgb(244, 67, 54);
            this.btnXoaSP.FlatAppearance.BorderSize = 0;
            this.btnXoaSP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaSP.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXoaSP.ForeColor = System.Drawing.Color.White;
            this.btnXoaSP.Location = new System.Drawing.Point(360, 10);
            this.btnXoaSP.Size = new System.Drawing.Size(90, 30);
            this.btnXoaSP.Text = "🗑 Xóa SP";
            this.btnXoaSP.Click += new System.EventHandler(this.btnXoaSP_Click);
            // btnLuu
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.btnLuu.FlatAppearance.BorderSize = 0;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(460, 10);
            this.btnLuu.Size = new System.Drawing.Size(90, 30);
            this.btnLuu.Text = "💾 Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // btnHuy
            this.btnHuy.BackColor = System.Drawing.Color.FromArgb(244, 67, 54);
            this.btnHuy.FlatAppearance.BorderSize = 0;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(560, 10);
            this.btnHuy.Size = new System.Drawing.Size(90, 30);
            this.btnHuy.Text = "✕ Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // FormNhapKhoDetail
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 550);
            this.Controls.Add(this.dgvChiTiet);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FormNhapKhoDetail";
            this.Text = "Phiếu nhập kho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.FormNhapKhoDetail_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblMaPhieu;
        private System.Windows.Forms.TextBox txtMaPhieu;
        private System.Windows.Forms.Label lblNgayNhap;
        private System.Windows.Forms.DateTimePicker dtpNgayNhap;
        private System.Windows.Forms.Label lblNCC;
        private System.Windows.Forms.ComboBox cmbNCC;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.DataGridView dgvChiTiet;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Button btnThemSP;
        private System.Windows.Forms.Button btnXoaSP;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
    }
}

