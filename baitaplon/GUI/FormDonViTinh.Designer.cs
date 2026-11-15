namespace baitaplon.GUI
{
    partial class FormDonViTinh
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }
        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle h = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnAnHien = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.btnAnHien); this.pnlTop.Controls.Add(this.btnSua); this.pnlTop.Controls.Add(this.btnThem);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top; this.pnlTop.Location = new System.Drawing.Point(15, 15);
            this.pnlTop.Size = new System.Drawing.Size(770, 50);
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.btnThem.FlatAppearance.BorderSize = 0; this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White; this.btnThem.Location = new System.Drawing.Point(10, 10);
            this.btnThem.Size = new System.Drawing.Size(100, 30); this.btnThem.Text = "➕ Thêm mới";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(25, 118, 210);
            this.btnSua.FlatAppearance.BorderSize = 0; this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSua.ForeColor = System.Drawing.Color.White; this.btnSua.Location = new System.Drawing.Point(120, 10);
            this.btnSua.Size = new System.Drawing.Size(90, 30); this.btnSua.Text = "✏ Chỉnh sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            this.btnAnHien.BackColor = System.Drawing.Color.FromArgb(255, 152, 0);
            this.btnAnHien.FlatAppearance.BorderSize = 0; this.btnAnHien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnHien.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAnHien.ForeColor = System.Drawing.Color.White; this.btnAnHien.Location = new System.Drawing.Point(220, 10);
            this.btnAnHien.Size = new System.Drawing.Size(90, 30); this.btnAnHien.Text = "👁 Ẩn/Hiện";
            this.btnAnHien.Click += new System.EventHandler(this.btnAnHien_Click);
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
            this.dgvData.Columns.Add("colMa", "Mã"); this.dgvData.Columns.Add("colTen", "Tên ĐVT");
            this.dgvData.Columns.Add("colMoTa", "Mô tả"); this.dgvData.Columns.Add("colTT", "Trạng thái");
            this.dgvData.Columns["colMa"].FillWeight = 40; this.dgvData.Columns["colTen"].FillWeight = 100;
            this.dgvData.Columns["colMoTa"].FillWeight = 150; this.dgvData.Columns["colTT"].FillWeight = 70;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.dgvData); this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F); this.Name = "FormDonViTinh";
            this.Padding = new System.Windows.Forms.Padding(15);
            this.Load += new System.EventHandler(this.FormDonViTinh_Load);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnThem, btnSua, btnAnHien;
        private System.Windows.Forms.DataGridView dgvData;
    }
}


