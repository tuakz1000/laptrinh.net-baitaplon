namespace baitaplon.GUI
{
    partial class FormSanPham
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
            System.Windows.Forms.DataGridViewCellStyle headerStyle = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.btnNgungKD = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.lblTongSP = new System.Windows.Forms.Label();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.cmbLocTrangThai = new System.Windows.Forms.ComboBox();
            this.cmbLocDanhMuc = new System.Windows.Forms.ComboBox();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.dgvSanPham = new System.Windows.Forms.DataGridView();
            this.colMaSPCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDanhMuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDVT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGiaNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTonKho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTonMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlTop.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            this.SuspendLayout();
            // pnlTop
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.btnXuatExcel);
            this.pnlTop.Controls.Add(this.btnNgungKD);
            this.pnlTop.Controls.Add(this.btnSua);
            this.pnlTop.Controls.Add(this.btnThem);
            this.pnlTop.Controls.Add(this.lblTongSP);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(15, 15);
            this.pnlTop.Size = new System.Drawing.Size(970, 50);
            this.pnlTop.Padding = new System.Windows.Forms.Padding(10, 10, 10, 5);
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
            // btnNgungKD
            this.btnNgungKD.BackColor = System.Drawing.Color.FromArgb(255, 152, 0);
            this.btnNgungKD.FlatAppearance.BorderSize = 0;
            this.btnNgungKD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNgungKD.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnNgungKD.ForeColor = System.Drawing.Color.White;
            this.btnNgungKD.Location = new System.Drawing.Point(220, 10);
            this.btnNgungKD.Size = new System.Drawing.Size(110, 30);
            this.btnNgungKD.Text = "🚫 Ngừng KD";
            this.btnNgungKD.Click += new System.EventHandler(this.btnNgungKD_Click);
            // btnXuatExcel
            this.btnXuatExcel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnXuatExcel.BackColor = System.Drawing.Color.FromArgb(0, 150, 136);
            this.btnXuatExcel.FlatAppearance.BorderSize = 0;
            this.btnXuatExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatExcel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXuatExcel.ForeColor = System.Drawing.Color.White;
            this.btnXuatExcel.Location = new System.Drawing.Point(860, 10);
            this.btnXuatExcel.Size = new System.Drawing.Size(100, 30);
            this.btnXuatExcel.Text = "📊 Xuất Excel";
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // lblTongSP
            this.lblTongSP.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.lblTongSP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTongSP.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblTongSP.Location = new System.Drawing.Point(700, 15);
            this.lblTongSP.Size = new System.Drawing.Size(150, 20);
            this.lblTongSP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTongSP.Text = "Tổng: 0 sản phẩm";
            // pnlFilter
            this.pnlFilter.BackColor = System.Drawing.Color.White;
            this.pnlFilter.Controls.Add(this.btnTimKiem);
            this.pnlFilter.Controls.Add(this.cmbLocTrangThai);
            this.pnlFilter.Controls.Add(this.cmbLocDanhMuc);
            this.pnlFilter.Controls.Add(this.txtTimKiem);
            this.pnlFilter.Controls.Add(this.lblTimKiem);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(15, 65);
            this.pnlFilter.Size = new System.Drawing.Size(970, 45);
            this.pnlFilter.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            // lblTimKiem
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTimKiem.Location = new System.Drawing.Point(10, 13);
            this.lblTimKiem.Text = "🔍 Tìm kiếm:";
            // txtTimKiem
            this.txtTimKiem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtTimKiem.Location = new System.Drawing.Point(100, 9);
            this.txtTimKiem.Size = new System.Drawing.Size(250, 25);
            this.txtTimKiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTimKiem_KeyDown);
            // cmbLocDanhMuc
            this.cmbLocDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocDanhMuc.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbLocDanhMuc.Location = new System.Drawing.Point(370, 9);
            this.cmbLocDanhMuc.Size = new System.Drawing.Size(180, 25);
            this.cmbLocDanhMuc.SelectedIndexChanged += new System.EventHandler(this.cmbLocDanhMuc_SelectedIndexChanged);
            // cmbLocTrangThai
            this.cmbLocTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocTrangThai.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbLocTrangThai.Location = new System.Drawing.Point(560, 9);
            this.cmbLocTrangThai.Size = new System.Drawing.Size(150, 25);
            this.cmbLocTrangThai.SelectedIndexChanged += new System.EventHandler(this.cmbLocTrangThai_SelectedIndexChanged);
            // btnTimKiem
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(25, 118, 210);
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(720, 8);
            this.btnTimKiem.Size = new System.Drawing.Size(80, 28);
            this.btnTimKiem.Text = "Tìm kiếm";
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
            headerStyle.BackColor = System.Drawing.Color.FromArgb(25, 118, 210);
            headerStyle.ForeColor = System.Drawing.Color.White;
            headerStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            headerStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvSanPham.ColumnHeadersDefaultCellStyle = headerStyle;
            this.dgvSanPham.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSanPham_CellDoubleClick);
            // Columns
            this.colMaSPCode = new System.Windows.Forms.DataGridViewTextBoxColumn() { Name = "colMaSPCode", HeaderText = "Mã SP", FillWeight = 55 };
            this.colTenSP = new System.Windows.Forms.DataGridViewTextBoxColumn() { Name = "colTenSP", HeaderText = "Tên sản phẩm", FillWeight = 150 };
            this.colDanhMuc = new System.Windows.Forms.DataGridViewTextBoxColumn() { Name = "colDanhMuc", HeaderText = "Danh mục", FillWeight = 80 };
            this.colDVT = new System.Windows.Forms.DataGridViewTextBoxColumn() { Name = "colDVT", HeaderText = "ĐVT", FillWeight = 45 };
            this.colGiaNhap = new System.Windows.Forms.DataGridViewTextBoxColumn() { Name = "colGiaNhap", HeaderText = "Giá nhập", FillWeight = 70 };
            this.colGiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn() { Name = "colGiaBan", HeaderText = "Giá bán", FillWeight = 70 };
            this.colTonKho = new System.Windows.Forms.DataGridViewTextBoxColumn() { Name = "colTonKho", HeaderText = "Tồn kho", FillWeight = 50 };
            this.colTonMin = new System.Windows.Forms.DataGridViewTextBoxColumn() { Name = "colTonMin", HeaderText = "Tồn min", FillWeight = 45 };
            this.colTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn() { Name = "colTrangThai", HeaderText = "Trạng thái", FillWeight = 80 };
            this.dgvSanPham.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                colMaSPCode, colTenSP, colDanhMuc, colDVT, colGiaNhap, colGiaBan, colTonKho, colTonMin, colTrangThai });
            // colGiaNhap, colGiaBan right align
            this.colGiaNhap.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colGiaBan.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colTonKho.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colTonMin.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            // FormSanPham
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.dgvSanPham);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FormSanPham";
            this.Padding = new System.Windows.Forms.Padding(15);
            this.Load += new System.EventHandler(this.FormSanPham_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnThem, btnSua, btnNgungKD, btnXuatExcel;
        private System.Windows.Forms.Label lblTongSP;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.ComboBox cmbLocDanhMuc, cmbLocTrangThai;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.DataGridView dgvSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaSPCode, colTenSP, colDanhMuc, colDVT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGiaNhap, colGiaBan, colTonKho, colTonMin, colTrangThai;
    }
}


