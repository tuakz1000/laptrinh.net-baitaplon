using System;
using System.Drawing;
using System.Windows.Forms;

namespace baitaplon.GUI
{
    partial class FormChonSanPham
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
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.dgvSanPham = new System.Windows.Forms.DataGridView();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnChon = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // pnlTop
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.btnTimKiem);
            this.pnlTop.Controls.Add(this.txtTimKiem);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Size = new System.Drawing.Size(700, 50);
            // txtTimKiem
            this.txtTimKiem.Location = new System.Drawing.Point(10, 13);
            this.txtTimKiem.Size = new System.Drawing.Size(400, 25);
            this.txtTimKiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTimKiem_KeyDown);
            // btnTimKiem
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(25, 118, 210);
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(420, 10);
            this.btnTimKiem.Size = new System.Drawing.Size(90, 30);
            this.btnTimKiem.Text = "🔍 Tìm";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // dgvSanPham
            this.dgvSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSanPham.AllowUserToAddRows = false;
            this.dgvSanPham.AllowUserToDeleteRows = false;
            this.dgvSanPham.ReadOnly = true;
            this.dgvSanPham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSanPham.MultiSelect = false;
            this.dgvSanPham.RowHeadersVisible = false;
            this.dgvSanPham.BackgroundColor = System.Drawing.Color.White;
            this.dgvSanPham.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSanPham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSanPham.ColumnHeadersHeight = 38;
            this.dgvSanPham.RowTemplate.Height = 35;
            this.dgvSanPham.EnableHeadersVisualStyles = false;
            h.BackColor = System.Drawing.Color.FromArgb(25, 118, 210); h.ForeColor = System.Drawing.Color.White;
            h.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.dgvSanPham.ColumnHeadersDefaultCellStyle = h;
            this.dgvSanPham.Columns.Add("colMa", "Mã");
            this.dgvSanPham.Columns.Add("colCode", "Mã SP");
            this.dgvSanPham.Columns.Add("colTen", "Tên sản phẩm");
            this.dgvSanPham.Columns.Add("colDVT", "ĐVT");
            this.dgvSanPham.Columns.Add("colTon", "Tồn");
            this.dgvSanPham.Columns.Add("colGiaN", "Giá nhập");
            this.dgvSanPham.Columns.Add("colGiaB", "Giá bán");
            this.dgvSanPham.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSanPham_CellDoubleClick);
            // pnlBottom
            this.pnlBottom.Controls.Add(this.lblSoLuong);
            this.pnlBottom.Controls.Add(this.txtSoLuong);
            this.pnlBottom.Controls.Add(this.btnHuy);
            this.pnlBottom.Controls.Add(this.btnChon);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Size = new System.Drawing.Size(700, 55);
            // lblSoLuong
            this.lblSoLuong.Location = new System.Drawing.Point(10, 17);
            this.lblSoLuong.Size = new System.Drawing.Size(80, 20);
            this.lblSoLuong.Text = "Số lượng:";
            // txtSoLuong
            this.txtSoLuong.Location = new System.Drawing.Point(100, 14);
            this.txtSoLuong.Size = new System.Drawing.Size(100, 25);
            this.txtSoLuong.Text = "1";
            // btnChon
            this.btnChon.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.btnChon.FlatAppearance.BorderSize = 0;
            this.btnChon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnChon.ForeColor = System.Drawing.Color.White;
            this.btnChon.Location = new System.Drawing.Point(450, 12);
            this.btnChon.Size = new System.Drawing.Size(100, 30);
            this.btnChon.Text = "✓ Chọn";
            this.btnChon.Click += new System.EventHandler(this.btnChon_Click);
            // btnHuy
            this.btnHuy.BackColor = System.Drawing.Color.FromArgb(244, 67, 54);
            this.btnHuy.FlatAppearance.BorderSize = 0;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(560, 12);
            this.btnHuy.Size = new System.Drawing.Size(100, 30);
            this.btnHuy.Text = "✕ Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // FormChonSanPham
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 500);
            this.Controls.Add(this.dgvSanPham);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FormChonSanPham";
            this.Text = "Chọn sản phẩm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.FormChonSanPham_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridView dgvSanPham;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Button btnChon;
        private System.Windows.Forms.Button btnHuy;
    }
}

