using System;
using System.Drawing;
using System.Windows.Forms;

namespace baitaplon.GUI
{
    partial class FormBaoCao
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
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.btnLoc = new System.Windows.Forms.Button();
            this.btnTopSP = new System.Windows.Forms.Button();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.btnXuatPDF = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.chartDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // pnlTop
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.btnXuatPDF);
            this.pnlTop.Controls.Add(this.btnXuatExcel);
            this.pnlTop.Controls.Add(this.btnTopSP);
            this.pnlTop.Controls.Add(this.btnLoc);
            this.pnlTop.Controls.Add(this.dtpDenNgay);
            this.pnlTop.Controls.Add(this.dtpTuNgay);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Size = new System.Drawing.Size(1000, 60);
            // lblTitle
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(10, 15);
            this.lblTitle.Size = new System.Drawing.Size(220, 30);
            this.lblTitle.Text = "📈 Báo cáo & Thống kê";
            // dtpTuNgay
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(240, 18);
            this.dtpTuNgay.Size = new System.Drawing.Size(110, 22);
            // dtpDenNgay
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(355, 18);
            this.dtpDenNgay.Size = new System.Drawing.Size(110, 22);
            // btnLoc
            this.btnLoc.BackColor = System.Drawing.Color.FromArgb(25, 118, 210);
            this.btnLoc.FlatAppearance.BorderSize = 0;
            this.btnLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLoc.ForeColor = System.Drawing.Color.White;
            this.btnLoc.Location = new System.Drawing.Point(470, 15);
            this.btnLoc.Size = new System.Drawing.Size(80, 30);
            this.btnLoc.Text = "🔍 Xem";
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // btnTopSP
            this.btnTopSP.BackColor = System.Drawing.Color.FromArgb(0, 150, 136);
            this.btnTopSP.FlatAppearance.BorderSize = 0;
            this.btnTopSP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTopSP.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTopSP.ForeColor = System.Drawing.Color.White;
            this.btnTopSP.Location = new System.Drawing.Point(555, 15);
            this.btnTopSP.Size = new System.Drawing.Size(120, 30);
            this.btnTopSP.Text = "🏆 Top SP tồn";
            this.btnTopSP.Click += new System.EventHandler(this.btnTopSP_Click);
            // btnXuatExcel
            this.btnXuatExcel.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.btnXuatExcel.FlatAppearance.BorderSize = 0;
            this.btnXuatExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatExcel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXuatExcel.ForeColor = System.Drawing.Color.White;
            this.btnXuatExcel.Location = new System.Drawing.Point(680, 15);
            this.btnXuatExcel.Size = new System.Drawing.Size(100, 30);
            this.btnXuatExcel.Text = "📥 Excel";
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // btnXuatPDF
            this.btnXuatPDF.BackColor = System.Drawing.Color.FromArgb(244, 67, 54);
            this.btnXuatPDF.FlatAppearance.BorderSize = 0;
            this.btnXuatPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatPDF.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXuatPDF.ForeColor = System.Drawing.Color.White;
            this.btnXuatPDF.Location = new System.Drawing.Point(785, 15);
            this.btnXuatPDF.Size = new System.Drawing.Size(100, 30);
            this.btnXuatPDF.Text = "📄 PDF";
            this.btnXuatPDF.Click += new System.EventHandler(this.btnXuatPDF_Click);
            // splitContainer1
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(15, 75);
            this.splitContainer1.Size = new System.Drawing.Size(970, 560);
            this.splitContainer1.SplitterDistance = 480;
            // chartDoanhThu
            this.chartDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartDoanhThu.Name = "chartDoanhThu";
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
            this.dgvData.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.dgvData.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(25, 118, 210);
            this.dgvData.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            // FormBaoCao
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.ClientSize = new System.Drawing.Size(1000, 650);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FormBaoCao";
            this.Padding = new System.Windows.Forms.Padding(15);
            this.Text = "Báo cáo & Thống kê";
            this.Load += new System.EventHandler(this.FormBaoCao_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.Button btnTopSP;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.Button btnXuatPDF;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu;
        private System.Windows.Forms.DataGridView dgvData;
    }
}

