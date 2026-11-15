namespace baitaplon.GUI
{
    partial class FormDashboard
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.pnlCards = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlCard1 = new System.Windows.Forms.Panel();
            this.lblTongSP = new System.Windows.Forms.Label();
            this.lblCard1Title = new System.Windows.Forms.Label();
            this.pnlStrip1 = new System.Windows.Forms.Panel();
            this.pnlCard2 = new System.Windows.Forms.Panel();
            this.lblTongTon = new System.Windows.Forms.Label();
            this.lblCard2Title = new System.Windows.Forms.Label();
            this.pnlStrip2 = new System.Windows.Forms.Panel();
            this.pnlCard3 = new System.Windows.Forms.Panel();
            this.lblGiaTriTon = new System.Windows.Forms.Label();
            this.lblCard3Title = new System.Windows.Forms.Label();
            this.pnlStrip3 = new System.Windows.Forms.Panel();
            this.pnlCard4 = new System.Windows.Forms.Panel();
            this.lblNhapHomNay = new System.Windows.Forms.Label();
            this.lblCard4Title = new System.Windows.Forms.Label();
            this.pnlStrip4 = new System.Windows.Forms.Panel();
            this.pnlCard5 = new System.Windows.Forms.Panel();
            this.lblXuatHomNay = new System.Windows.Forms.Label();
            this.lblCard5Title = new System.Windows.Forms.Label();
            this.pnlStrip5 = new System.Windows.Forms.Panel();
            this.pnlCard6 = new System.Windows.Forms.Panel();
            this.lblNhapThang = new System.Windows.Forms.Label();
            this.lblCard6Title = new System.Windows.Forms.Label();
            this.pnlStrip6 = new System.Windows.Forms.Panel();
            this.pnlCard7 = new System.Windows.Forms.Panel();
            this.lblXuatThang = new System.Windows.Forms.Label();
            this.lblCard7Title = new System.Windows.Forms.Label();
            this.pnlStrip7 = new System.Windows.Forms.Panel();
            this.pnlCard8 = new System.Windows.Forms.Panel();
            this.lblSapHet = new System.Windows.Forms.Label();
            this.lblCard8Title = new System.Windows.Forms.Label();
            this.pnlStrip8 = new System.Windows.Forms.Panel();
            this.pnlCard9 = new System.Windows.Forms.Panel();
            this.lblHetHang = new System.Windows.Forms.Label();
            this.lblCard9Title = new System.Windows.Forms.Label();
            this.pnlStrip9 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.chartNhapXuat = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblChartTitle = new System.Windows.Forms.Label();
            this.dgvCanhBao = new System.Windows.Forms.DataGridView();
            this.colMaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTonKho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colToiThieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrangThai2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblWarningTitle = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.pnlCards.SuspendLayout();
            this.pnlCard1.SuspendLayout();
            this.pnlCard2.SuspendLayout();
            this.pnlCard3.SuspendLayout();
            this.pnlCard4.SuspendLayout();
            this.pnlCard5.SuspendLayout();
            this.pnlCard6.SuspendLayout();
            this.pnlCard7.SuspendLayout();
            this.pnlCard8.SuspendLayout();
            this.pnlCard9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartNhapXuat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCanhBao)).BeginInit();
            this.SuspendLayout();
            // pnlTop
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.btnRefresh);
            this.pnlTop.Controls.Add(this.lblTieuDe);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(15, 15);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(970, 45);
            this.pnlTop.TabIndex = 0;
            // lblTieuDe
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            this.lblTieuDe.Location = new System.Drawing.Point(10, 8);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(200, 25);
            this.lblTieuDe.Text = "📊 Tổng quan hệ thống";
            // btnRefresh
            this.btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(25, 118, 210);
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(870, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(90, 30);
            this.btnRefresh.Text = "🔄 Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // pnlCards
            this.pnlCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCards.Location = new System.Drawing.Point(15, 60);
            this.pnlCards.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.pnlCards.Size = new System.Drawing.Size(970, 220);
            this.pnlCards.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.pnlCards.WrapContents = true;
            this.pnlCards.Controls.Add(this.pnlCard1);
            this.pnlCards.Controls.Add(this.pnlCard2);
            this.pnlCards.Controls.Add(this.pnlCard3);
            this.pnlCards.Controls.Add(this.pnlCard4);
            this.pnlCards.Controls.Add(this.pnlCard5);
            this.pnlCards.Controls.Add(this.pnlCard6);
            this.pnlCards.Controls.Add(this.pnlCard7);
            this.pnlCards.Controls.Add(this.pnlCard8);
            this.pnlCards.Controls.Add(this.pnlCard9);
            // Helper to create card panels
            SetupCard(pnlCard1, pnlStrip1, lblTongSP, lblCard1Title, "Tổng sản phẩm", System.Drawing.Color.FromArgb(25, 118, 210));
            SetupCard(pnlCard2, pnlStrip2, lblTongTon, lblCard2Title, "Tổng tồn kho", System.Drawing.Color.FromArgb(76, 175, 80));
            SetupCard(pnlCard3, pnlStrip3, lblGiaTriTon, lblCard3Title, "Giá trị tồn kho", System.Drawing.Color.FromArgb(156, 39, 176));
            SetupCard(pnlCard4, pnlStrip4, lblNhapHomNay, lblCard4Title, "Nhập hôm nay", System.Drawing.Color.FromArgb(33, 150, 243));
            SetupCard(pnlCard5, pnlStrip5, lblXuatHomNay, lblCard5Title, "Xuất hôm nay", System.Drawing.Color.FromArgb(255, 152, 0));
            SetupCard(pnlCard6, pnlStrip6, lblNhapThang, lblCard6Title, "Nhập tháng này", System.Drawing.Color.FromArgb(0, 150, 136));
            SetupCard(pnlCard7, pnlStrip7, lblXuatThang, lblCard7Title, "Xuất tháng này", System.Drawing.Color.FromArgb(255, 87, 34));
            SetupCard(pnlCard8, pnlStrip8, lblSapHet, lblCard8Title, "SP sắp hết", System.Drawing.Color.FromArgb(255, 152, 0));
            SetupCard(pnlCard9, pnlStrip9, lblHetHang, lblCard9Title, "SP hết hàng", System.Drawing.Color.FromArgb(244, 67, 54));
            // splitContainer1
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(15, 280);
            this.splitContainer1.SplitterDistance = 550;
            this.splitContainer1.Name = "splitContainer1";
            // Panel1 - Chart
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainer1.Panel1.Controls.Add(this.chartNhapXuat);
            this.splitContainer1.Panel1.Controls.Add(this.lblChartTitle);
            // lblChartTitle
            this.lblChartTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChartTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblChartTitle.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            this.lblChartTitle.Text = "📈 Biểu đồ Nhập - Xuất theo tháng (" + System.DateTime.Now.Year + ")";
            this.lblChartTitle.Height = 30;
            this.lblChartTitle.Padding = new System.Windows.Forms.Padding(5);
            // chartNhapXuat
            this.chartNhapXuat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartNhapXuat.BackColor = System.Drawing.Color.White;
            // Panel2 - Warning grid
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainer1.Panel2.Controls.Add(this.dgvCanhBao);
            this.splitContainer1.Panel2.Controls.Add(this.lblWarningTitle);
            // lblWarningTitle
            this.lblWarningTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblWarningTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblWarningTitle.ForeColor = System.Drawing.Color.FromArgb(244, 67, 54);
            this.lblWarningTitle.Text = "⚠ Cảnh báo tồn kho";
            this.lblWarningTitle.Height = 30;
            this.lblWarningTitle.Padding = new System.Windows.Forms.Padding(5);
            // dgvCanhBao
            this.dgvCanhBao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCanhBao.AllowUserToAddRows = false;
            this.dgvCanhBao.AllowUserToDeleteRows = false;
            this.dgvCanhBao.ReadOnly = true;
            this.dgvCanhBao.RowHeadersVisible = false;
            this.dgvCanhBao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCanhBao.BackgroundColor = System.Drawing.Color.White;
            this.dgvCanhBao.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCanhBao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCanhBao.ColumnHeadersHeight = 35;
            this.dgvCanhBao.RowTemplate.Height = 30;
            this.dgvCanhBao.EnableHeadersVisualStyles = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(25, 118, 210);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvCanhBao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCanhBao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colMaSP, this.colTenSP, this.colTonKho, this.colToiThieu, this.colTrangThai2 });
            // Columns
            this.colMaSP.HeaderText = "Mã SP"; this.colMaSP.Name = "colMaSP"; this.colMaSP.FillWeight = 60;
            this.colTenSP.HeaderText = "Tên SP"; this.colTenSP.Name = "colTenSP"; this.colTenSP.FillWeight = 120;
            this.colTonKho.HeaderText = "Tồn"; this.colTonKho.Name = "colTonKho"; this.colTonKho.FillWeight = 40;
            this.colToiThieu.HeaderText = "Tối thiểu"; this.colToiThieu.Name = "colToiThieu"; this.colToiThieu.FillWeight = 50;
            this.colTrangThai2.HeaderText = "Trạng thái"; this.colTrangThai2.Name = "colTrangThai2"; this.colTrangThai2.FillWeight = 60;
            // FormDashboard
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.pnlCards);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FormDashboard";
            this.Padding = new System.Windows.Forms.Padding(15);
            this.Load += new System.EventHandler(this.FormDashboard_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlCards.ResumeLayout(false);
            this.pnlCard1.ResumeLayout(false);
            this.pnlCard1.PerformLayout();
            this.pnlCard2.ResumeLayout(false);
            this.pnlCard2.PerformLayout();
            this.pnlCard3.ResumeLayout(false);
            this.pnlCard3.PerformLayout();
            this.pnlCard4.ResumeLayout(false);
            this.pnlCard4.PerformLayout();
            this.pnlCard5.ResumeLayout(false);
            this.pnlCard5.PerformLayout();
            this.pnlCard6.ResumeLayout(false);
            this.pnlCard6.PerformLayout();
            this.pnlCard7.ResumeLayout(false);
            this.pnlCard7.PerformLayout();
            this.pnlCard8.ResumeLayout(false);
            this.pnlCard8.PerformLayout();
            this.pnlCard9.ResumeLayout(false);
            this.pnlCard9.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartNhapXuat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCanhBao)).EndInit();
            this.ResumeLayout(false);
        }

        private void SetupCard(System.Windows.Forms.Panel card, System.Windows.Forms.Panel strip, 
            System.Windows.Forms.Label lblValue, System.Windows.Forms.Label lblTitle, string title, System.Drawing.Color color)
        {
            card.Size = new System.Drawing.Size(195, 90);
            card.BackColor = System.Drawing.Color.White;
            card.Margin = new System.Windows.Forms.Padding(5);
            card.Controls.Add(strip);
            card.Controls.Add(lblValue);
            card.Controls.Add(lblTitle);
            strip.Dock = System.Windows.Forms.DockStyle.Left;
            strip.Width = 5;
            strip.BackColor = color;
            lblValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            lblValue.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            lblValue.Location = new System.Drawing.Point(15, 10);
            lblValue.AutoSize = true;
            lblValue.Text = "0";
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblTitle.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            lblTitle.Location = new System.Drawing.Point(15, 60);
            lblTitle.AutoSize = true;
            lblTitle.Text = title;
        }
        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.FlowLayoutPanel pnlCards;
        private System.Windows.Forms.Panel pnlCard1, pnlCard2, pnlCard3, pnlCard4, pnlCard5, pnlCard6, pnlCard7, pnlCard8, pnlCard9;
        private System.Windows.Forms.Panel pnlStrip1, pnlStrip2, pnlStrip3, pnlStrip4, pnlStrip5, pnlStrip6, pnlStrip7, pnlStrip8, pnlStrip9;
        private System.Windows.Forms.Label lblTongSP, lblTongTon, lblGiaTriTon, lblNhapHomNay, lblXuatHomNay, lblNhapThang, lblXuatThang, lblSapHet, lblHetHang;
        private System.Windows.Forms.Label lblCard1Title, lblCard2Title, lblCard3Title, lblCard4Title, lblCard5Title, lblCard6Title, lblCard7Title, lblCard8Title, lblCard9Title;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartNhapXuat;
        private System.Windows.Forms.Label lblChartTitle;
        private System.Windows.Forms.DataGridView dgvCanhBao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaSP, colTenSP, colTonKho, colToiThieu, colTrangThai2;
        private System.Windows.Forms.Label lblWarningTitle;
    }
}


