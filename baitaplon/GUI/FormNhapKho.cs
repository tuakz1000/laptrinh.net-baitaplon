using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using baitaplon.BUS;
using baitaplon.Models;
using baitaplon.Helpers;

namespace baitaplon.GUI
{
    public partial class FormNhapKho : Form
    {
        private PhieuNhapBUS _bus = new PhieuNhapBUS();
        private NhaCungCapBUS _nccBUS = new NhaCungCapBUS();

        public FormNhapKho()
        {
            InitializeComponent();
        }

        private void FormNhapKho_Load(object sender, EventArgs e)
        {
            UIHelper.StyleDataGridView(dgvPhieu);
            LoadNCCCombo();
            LoadTrangThaiCombo();
            dtpTuNgay.Value = DateTime.Now.AddDays(-30);
            dtpDenNgay.Value = DateTime.Now;
            LoadData();
        }

        private void LoadNCCCombo()
        {
            cmbNCC.Items.Clear();
            cmbNCC.Items.Add("-- Tất cả --");
            foreach (var ncc in _nccBUS.GetAllActive())
                cmbNCC.Items.Add(ncc);
            cmbNCC.DisplayMember = "TenNCC";
            cmbNCC.SelectedIndex = 0;
        }

        private void LoadTrangThaiCombo()
        {
            cmbTrangThai.Items.Clear();
            cmbTrangThai.Items.Add("-- Tất cả --");
            cmbTrangThai.Items.Add("Nháp");
            cmbTrangThai.Items.Add("Đã xác nhận");
            cmbTrangThai.Items.Add("Đã hủy");
            cmbTrangThai.SelectedIndex = 0;
        }

        private void LoadData()
        {
            try
            {
                int? maNCC = null;
                if (cmbNCC.SelectedIndex > 0 && cmbNCC.SelectedItem is NhaCungCap ncc)
                    maNCC = ncc.MaNCC;

                int? trangThai = null;
                if (cmbTrangThai.SelectedIndex == 1) trangThai = 0;
                else if (cmbTrangThai.SelectedIndex == 2) trangThai = 1;
                else if (cmbTrangThai.SelectedIndex == 3) trangThai = 2;

                var list = _bus.GetAll(dtpTuNgay.Value, dtpDenNgay.Value, maNCC, trangThai);
                dgvPhieu.Rows.Clear();
                foreach (var pn in list)
                {
                    int idx = dgvPhieu.Rows.Add(pn.MaPhieuNhap, pn.MaPhieuNhapCode, pn.TenNCC,
                        FormatHelper.FormatDate(pn.NgayNhap), FormatHelper.FormatCurrency(pn.TongTien),
                        FormatHelper.GetTrangThaiPhieu(pn.TrangThai));
                    dgvPhieu.Rows[idx].Tag = pn;
                    dgvPhieu.Rows[idx].DefaultCellStyle.ForeColor = FormatHelper.GetTrangThaiColor(pn.TrangThai);
                }
            }
            catch (Exception ex) { MessageHelper.ShowError(ex.Message); }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var frm = new FormNhapKhoDetail();
            if (frm.ShowDialog() == DialogResult.OK) LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvPhieu.SelectedRows.Count == 0) { MessageHelper.ShowWarning("Chọn phiếu nhập!"); return; }
            PhieuNhap pn = dgvPhieu.SelectedRows[0].Tag as PhieuNhap;
            if (pn == null) return;
            if (pn.TrangThai != 0) { MessageHelper.ShowWarning("Chỉ có thể sửa phiếu ở trạng thái Nháp!"); return; }
            var frm = new FormNhapKhoDetail(pn.MaPhieuNhap);
            if (frm.ShowDialog() == DialogResult.OK) LoadData();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (dgvPhieu.SelectedRows.Count == 0) { MessageHelper.ShowWarning("Chọn phiếu cần xác nhận!"); return; }
            PhieuNhap pn = dgvPhieu.SelectedRows[0].Tag as PhieuNhap;
            if (pn == null) return;
            if (pn.TrangThai != 0) { MessageHelper.ShowWarning("Phiếu không ở trạng thái Nháp!"); return; }
            if (!MessageHelper.Confirm("Xác nhận phiếu nhập này? Tồn kho sẽ được cập nhật.")) return;
            try
            {
                _bus.XacNhanPhieuNhap(pn.MaPhieuNhap);
                MessageHelper.ShowSuccess("Đã xác nhận phiếu nhập và cập nhật tồn kho!");
                LoadData();
            }
            catch (Exception ex) { MessageHelper.ShowError(ex.Message); }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (dgvPhieu.SelectedRows.Count == 0) { MessageHelper.ShowWarning("Chọn phiếu cần hủy!"); return; }
            PhieuNhap pn = dgvPhieu.SelectedRows[0].Tag as PhieuNhap;
            if (pn == null) return;
            if (pn.TrangThai == 2) { MessageHelper.ShowWarning("Phiếu đã bị hủy trước đó!"); return; }
            if (!MessageHelper.ConfirmWarning("Hủy phiếu nhập này?" + (pn.TrangThai == 1 ? " Tồn kho sẽ được hoàn trả." : ""))) return;
            try
            {
                _bus.HuyPhieuNhap(pn.MaPhieuNhap);
                MessageHelper.ShowSuccess("Đã hủy phiếu nhập!");
                LoadData();
            }
            catch (Exception ex) { MessageHelper.ShowError(ex.Message); }
        }

        private void btnLoc_Click(object sender, EventArgs e) { LoadData(); }

        private void dgvPhieu_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) btnSua_Click(sender, e);
        }
    }

    public partial class FormNhapKhoDetail : Form
    {
        private PhieuNhapBUS _bus = new PhieuNhapBUS();
        private NhaCungCapBUS _nccBUS = new NhaCungCapBUS();
        private SanPhamBUS _spBUS = new SanPhamBUS();
        private int _maPhieu = 0;
        private bool _isEdit = false;

        public FormNhapKhoDetail(int maPhieu = 0)
        {
            InitializeComponent();
            _maPhieu = maPhieu;
            _isEdit = maPhieu > 0;
        }

        private void FormNhapKhoDetail_Load(object sender, EventArgs e)
        {
            LoadNCCCombo();
            if (_isEdit)
            {
                this.Text = "Sửa phiếu nhập";
                LoadPhieu();
            }
            else
            {
                this.Text = "Tạo phiếu nhập mới";
                txtMaPhieu.Text = _bus.GetNextMaPhieuNhap();
                dtpNgayNhap.Value = DateTime.Now;
            }
        }

        private void LoadNCCCombo()
        {
            cmbNCC.Items.Clear();
            cmbNCC.Items.Add("-- Chọn nhà cung cấp --");
            foreach (var ncc in _nccBUS.GetAllActive())
                cmbNCC.Items.Add(ncc);
            cmbNCC.DisplayMember = "TenNCC";
            cmbNCC.ValueMember = "MaNCC";
            cmbNCC.SelectedIndex = 0;
        }

        private void LoadPhieu()
        {
            try
            {
                var pn = _bus.GetById(_maPhieu);
                if (pn == null) { MessageHelper.ShowError("Không tìm thấy phiếu!"); this.Close(); return; }

                txtMaPhieu.Text = pn.MaPhieuNhapCode;
                dtpNgayNhap.Value = pn.NgayNhap;
                txtGhiChu.Text = pn.GhiChu;

                for (int i = 1; i < cmbNCC.Items.Count; i++)
                {
                    if (cmbNCC.Items[i] is NhaCungCap ncc && ncc.MaNCC == pn.MaNCC)
                    { cmbNCC.SelectedIndex = i; break; }
                }

                foreach (var ct in pn.ChiTietPhieuNhaps)
                {
                    int idx = dgvChiTiet.Rows.Add(ct.MaSP, ct.MaSPCode, ct.TenSP, ct.TenDVT, ct.SoLuong, ct.DonGia, ct.ThanhTien);
                    dgvChiTiet.Rows[idx].Tag = ct.MaSP;
                }
                TinhTongTien();
            }
            catch (Exception ex) { MessageHelper.ShowError(ex.Message); }
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            var frm = new FormChonSanPham();
            if (frm.ShowDialog() == DialogResult.OK && frm.SelectedSP != null)
            {
                int maSP = frm.SelectedSP.MaSP;
                // Check duplicate
                foreach (DataGridViewRow row in dgvChiTiet.Rows)
                {
                    if (row.Tag != null && (int)row.Tag == maSP)
                    {
                        MessageHelper.ShowWarning("Sản phẩm này đã có trong phiếu!");
                        return;
                    }
                }

                int soLuong = frm.SelectedSoLuong;
                decimal donGia = frm.SelectedSP.GiaNhap;
                int idx = dgvChiTiet.Rows.Add(maSP, frm.SelectedSP.MaSPCode, frm.SelectedSP.TenSP, frm.SelectedSP.TenDVT,
                    soLuong, donGia, soLuong * donGia);
                dgvChiTiet.Rows[idx].Tag = maSP;
                TinhTongTien();
            }
        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            if (dgvChiTiet.SelectedRows.Count == 0) { MessageHelper.ShowWarning("Chọn sản phẩm cần xóa!"); return; }
            dgvChiTiet.Rows.Remove(dgvChiTiet.SelectedRows[0]);
            TinhTongTien();
        }

        private void dgvChiTiet_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            TinhTongTien();
        }

        private void TinhTongTien()
        {
            decimal tong = 0;
            foreach (DataGridViewRow row in dgvChiTiet.Rows)
            {
                if (row.Cells["colSoLuong"].Value != null && row.Cells["colDonGia"].Value != null)
                {
                    int soLuong = 0;
                    decimal donGia = 0;
                    int.TryParse(row.Cells["colSoLuong"].Value.ToString(), out soLuong);
                    decimal.TryParse(row.Cells["colDonGia"].Value.ToString(), out donGia);
                    decimal thanhTien = soLuong * donGia;
                    row.Cells["colThanhTien"].Value = thanhTien;
                    tong += thanhTien;
                }
            }
            lblTongTien.Text = "Tổng tiền: " + FormatHelper.FormatCurrency(tong);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cmbNCC.SelectedIndex == 0) { MessageHelper.ShowWarning("Vui lòng chọn nhà cung cấp!"); return; }
            if (dgvChiTiet.Rows.Count == 0) { MessageHelper.ShowWarning("Phiếu phải có ít nhất 1 sản phẩm!"); return; }

            try
            {
                var ncc = cmbNCC.SelectedItem as NhaCungCap;
                if (ncc == null) return;

                var pn = new PhieuNhap
                {
                    MaPhieuNhap = _maPhieu,
                    MaPhieuNhapCode = txtMaPhieu.Text.Trim(),
                    MaNCC = ncc.MaNCC,
                    NgayNhap = dtpNgayNhap.Value,
                    GhiChu = txtGhiChu.Text.Trim(),
                    TrangThai = 0
                };

                var chiTiet = new List<ChiTietPhieuNhap>();
                foreach (DataGridViewRow row in dgvChiTiet.Rows)
                {
                    int maSP = (int)row.Tag;
                    int soLuong = 0;
                    decimal donGia = 0;
                    int.TryParse(row.Cells["colSoLuong"].Value.ToString(), out soLuong);
                    decimal.TryParse(row.Cells["colDonGia"].Value.ToString(), out donGia);

                    if (soLuong <= 0) { MessageHelper.ShowWarning("Số lượng phải lớn hơn 0!"); return; }
                    if (donGia < 0) { MessageHelper.ShowWarning("Đơn giá không được âm!"); return; }

                    chiTiet.Add(new ChiTietPhieuNhap
                    {
                        MaSP = maSP,
                        SoLuong = soLuong,
                        DonGia = donGia,
                        ThanhTien = soLuong * donGia
                    });
                }

                if (_isEdit)
                {
                    _bus.CapNhatPhieuNhap(pn, chiTiet);
                    MessageHelper.ShowSuccess("Cập nhật phiếu nhập thành công!");
                }
                else
                {
                    _bus.TaoPhieuNhap(pn, chiTiet);
                    MessageHelper.ShowSuccess("Tạo phiếu nhập thành công!");
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex) { MessageHelper.ShowError(ex.Message); }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
