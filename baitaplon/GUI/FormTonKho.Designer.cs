using System;
using System.Drawing;
using System.Windows.Forms;

namespace baitaplon.GUI
{
    partial class FormTonKho
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pnlTonKhoTop = new System.Windows.Forms.Panel();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.btnXemLichSu = new System.Windows.Forms.Button();
            this.lblTonKhoTitle = new System.Windows.Forms.Label();
            this.dgvTonKho = new System.Windows.Forms.DataGridView();
            this.pnlLichSuTop = new System.Windows.Forms.Panel();
            this.lblLichSuTitle = new System.Windows.Forms.Label();
            this.dgvLichSu = new System.Windows.Forms.DataGridView();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlTonKhoTop.SuspendLayout();
            this.pnlLichSuTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTonKho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSu)).BeginInit();
            this.SuspendLayout();
            // splitContainer1
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(15, 15);
            this.splitContainer1.Size = new System.Drawing.Size(970, 620);
            this.splitContainer1.SplitterDistance = 330;
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // Panel1 - Tồn kho
            this.splitContainer1.Panel1.Controls.Add(this.dgvTonKho);
            this.splitContainer1.Panel1.Controls.Add(this.pnlTonKhoTop);
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.dgvLichSu);
            this.splitContainer1.Panel2.Controls.Add(this.pnlLichSuTop);
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            // pnlTonKhoTop
            this.pnlTonKhoTop.Controls.Add(this.lblTonKhoTitle);
            this.pnlTonKhoTop.Controls.Add(this.btnXemLichSu);
            this.pnlTonKhoTop.Controls.Add(this.btnXuatExcel);
            this.pnlTonKhoTop.Controls.Add(this.dtpDenNgay);
            this.pnlTonKhoTop.Controls.Add(this.dtpTuNgay);
            this.pnlTonKhoTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTonKhoTop.Size = new System.Drawing.Size(970, 45);
            // dtpTuNgay
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(330, 12);
            this.dtpTuNgay.Size = new System.Drawing.Size(110, 22);
            // dtpDenNgay
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(450, 12);
            this.dtpDenNgay.Size = new System.Drawing.Size(110, 22);
            // lblTonKhoTitle
            this.lblTonKhoTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTonKhoTitle.Location = new System.Drawing.Point(10, 12);
            this.lblTonKhoTitle.Size = new System.Drawing.Size(300, 20);
            this.lblTonKhoTitle.Text = "📊 Tồn kho hiện tại";
            // btnXemLichSu
            this.btnXemLichSu.BackColor = System.Drawing.Color.FromArgb(25, 118, 210);
            this.btnXemLichSu.FlatAppearance.BorderSize = 0;
            this.btnXemLichSu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemLichSu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXemLichSu.ForeColor = System.Drawing.Color.White;
            this.btnXemLichSu.Location = new System.Drawing.Point(720, 8);
            this.btnXemLichSu.Size = new System.Drawing.Size(110, 30);
            this.btnXemLichSu.Text = "📜 Xem lịch sử";
            this.btnXemLichSu.Click += new System.EventHandler(this.btnXemLichSu_Click);
            // btnXuatExcel
            this.btnXuatExcel.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.btnXuatExcel.FlatAppearance.BorderSize = 0;
            this.btnXuatExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatExcel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXuatExcel.ForeColor = System.Drawing.Color.White;
            this.btnXuatExcel.Location = new System.Drawing.Point(840, 8);
            this.btnXuatExcel.Size = new System.Drawing.Size(110, 30);
            this.btnXuatExcel.Text = "📥 Xuất Excel";
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // dgvTonKho
            this.dgvTonKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTonKho.AllowUserToAddRows = false;
            this.dgvTonKho.AllowUserToDeleteRows = false;
            this.dgvTonKho.ReadOnly = true;
            this.dgvTonKho.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTonKho.MultiSelect = false;
            this.dgvTonKho.RowHeadersVisible = false;
            this.dgvTonKho.BackgroundColor = System.Drawing.Color.White;
            this.dgvTonKho.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTonKho.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTonKho.ColumnHeadersHeight = 38;
            this.dgvTonKho.RowTemplate.Height = 35;
            this.dgvTonKho.EnableHeadersVisualStyles = false;
            h.BackColor = System.Drawing.Color.FromArgb(25, 118, 210); h.ForeColor = System.Drawing.Color.White;
            h.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.dgvTonKho.ColumnHeadersDefaultCellStyle = h;
            this.dgvTonKho.Columns.Add("colMa", "Mã");
            this.dgvTonKho.Columns.Add("colCode", "Mã SP");
            this.dgvTonKho.Columns.Add("colTen", "Tên sản phẩm");
            this.dgvTonKho.Columns.Add("colDM", "Danh mục");
            this.dgvTonKho.Columns.Add("colDVT", "ĐVT");
            this.dgvTonKho.Columns.Add("colTon", "Tồn");
            this.dgvTonKho.Columns.Add("colMin", "Tối thiểu");
            this.dgvTonKho.Columns.Add("colGiaN", "Giá nhập");
            this.dgvTonKho.Columns.Add("colGiaTri", "Giá trị tồn");
            // pnlLichSuTop
            this.pnlLichSuTop.Controls.Add(this.lblLichSuTitle);
            this.pnlLichSuTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLichSuTop.Size = new System.Drawing.Size(970, 40);
            // lblLichSuTitle
            this.lblLichSuTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblLichSuTitle.Location = new System.Drawing.Point(10, 10);
            this.lblLichSuTitle.Size = new System.Drawing.Size(300, 20);
            this.lblLichSuTitle.Text = "📜 Lịch sử nhập xuất";
            // dgvLichSu
            this.dgvLichSu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLichSu.AllowUserToAddRows = false;
            this.dgvLichSu.AllowUserToDeleteRows = false;
            this.dgvLichSu.ReadOnly = true;
            this.dgvLichSu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLichSu.MultiSelect = false;
            this.dgvLichSu.RowHeadersVisible = false;
            this.dgvLichSu.BackgroundColor = System.Drawing.Color.White;
            this.dgvLichSu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLichSu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLichSu.ColumnHeadersHeight = 38;
            this.dgvLichSu.RowTemplate.Height = 35;
            this.dgvLichSu.EnableHeadersVisualStyles = false;
            h.BackColor = System.Drawing.Color.FromArgb(25, 118, 210); h.ForeColor = System.Drawing.Color.White;
            h.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.dgvLichSu.ColumnHeadersDefaultCellStyle = h;
            this.dgvLichSu.Columns.Add("colMa", "Mã");
            this.dgvLichSu.Columns.Add("colMaSP", "Mã SP");
            this.dgvLichSu.Columns.Add("colTenSP", "Tên SP");
            this.dgvLichSu.Columns.Add("colLoai", "Loại");
            this.dgvLichSu.Columns.Add("colQty", "Số lượng");
            this.dgvLichSu.Columns.Add("colTonSau", "Tồn sau GD");
            this.dgvLichSu.Columns.Add("colPN", "Phiếu nhập");
            this.dgvLichSu.Columns.Add("colPX", "Phiếu xuất");
            this.dgvLichSu.Columns.Add("colGhiChu", "Ghi chú");
            this.dgvLichSu.Columns.Add("colNgay", "Thời gian");
            // FormTonKho
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.ClientSize = new System.Drawing.Size(1000, 650);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FormTonKho";
            this.Padding = new System.Windows.Forms.Padding(15);
            this.Text = "Quản lý Tồn kho";
            this.Load += new System.EventHandler(this.FormTonKho_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.pnlTonKhoTop.ResumeLayout(false);
            this.pnlLichSuTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTonKho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSu)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel pnlTonKhoTop;
        private System.Windows.Forms.Panel pnlLichSuTop;
        private System.Windows.Forms.Label lblTonKhoTitle;
        private System.Windows.Forms.Label lblLichSuTitle;
        private System.Windows.Forms.Button btnXemLichSu;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.DataGridView dgvTonKho;
        private System.Windows.Forms.DataGridView dgvLichSu;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
    }
}

