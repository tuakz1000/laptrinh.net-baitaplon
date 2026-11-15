using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using baitaplon.BUS;
using baitaplon.Models;
using baitaplon.Helpers;

namespace baitaplon.GUI
{
    public partial class FormXuatKho : Form
    {
        private PhieuXuatBUS _bus = new PhieuXuatBUS();
        private KhachHangBUS _khBUS = new KhachHangBUS();

        public FormXuatKho()
        {
            InitializeComponent();
        }

        private void FormXuatKho_Load(object sender, EventArgs e)
        {
            UIHelper.StyleDataGridView(dgvPhieu);
            LoadKHCombo();
            LoadTrangThaiCombo();
            dtpTuNgay.Value = DateTime.Now.AddDays(-30);
            dtpDenNgay.Value = DateTime.Now;
            LoadData();
        }

        private void LoadKHCombo()
        {
            cmbKH.Items.Clear();
            cmbKH.Items.Add("-- Tất cả --");
            foreach (var kh in _khBUS.GetAllActive())
                cmbKH.Items.Add(kh);
            cmbKH.DisplayMember = "TenKH";
            cmbKH.SelectedIndex = 0;
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
                int? maKH = null;
                if (cmbKH.SelectedIndex > 0 && cmbKH.SelectedItem is KhachHang kh)
                    maKH = kh.MaKH;

                int? trangThai = null;
                if (cmbTrangThai.SelectedIndex == 1) trangThai = 0;
                else if (cmbTrangThai.SelectedIndex == 2) trangThai = 1;
                else if (cmbTrangThai.SelectedIndex == 3) trangThai = 2;

                var list = _bus.GetAll(dtpTuNgay.Value, dtpDenNgay.Value, maKH, trangThai);
                dgvPhieu.Rows.Clear();
                foreach (var px in list)
                {
                    int idx = dgvPhieu.Rows.Add(px.MaPhieuXuat, px.MaPhieuXuatCode, px.TenKH,
                        FormatHelper.FormatDate(px.NgayXuat), FormatHelper.FormatCurrency(px.TongTien),
                        FormatHelper.GetTrangThaiPhieu(px.TrangThai));
                    dgvPhieu.Rows[idx].Tag = px;
                    dgvPhieu.Rows[idx].DefaultCellStyle.ForeColor = FormatHelper.GetTrangThaiColor(px.TrangThai);
                }
            }
            catch (Exception ex) { MessageHelper.ShowError(ex.Message); }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var frm = new FormXuatKhoDetail();
            if (frm.ShowDialog() == DialogResult.OK) LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvPhieu.SelectedRows.Count == 0) { MessageHelper.ShowWarning("Chọn phiếu xuất!"); return; }
            PhieuXuat px = dgvPhieu.SelectedRows[0].Tag as PhieuXuat;
            if (px == null) return;
            if (px.TrangThai != 0) { MessageHelper.ShowWarning("Chỉ có thể sửa phiếu ở trạng thái Nháp!"); return; }
            var frm = new FormXuatKhoDetail(px.MaPhieuXuat);
            if (frm.ShowDialog() == DialogResult.OK) LoadData();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (dgvPhieu.SelectedRows.Count == 0) { MessageHelper.ShowWarning("Chọn phiếu cần xác nhận!"); return; }
            PhieuXuat px = dgvPhieu.SelectedRows[0].Tag as PhieuXuat;
            if (px == null) return;
            if (px.TrangThai != 0) { MessageHelper.ShowWarning("Phiếu không ở trạng thái Nháp!"); return; }
            if (!MessageHelper.Confirm("Xác nhận phiếu xuất này? Tồn kho sẽ được trừ đi.")) return;
            try
            {
                _bus.XacNhanPhieuXuat(px.MaPhieuXuat);
                MessageHelper.ShowSuccess("Đã xác nhận phiếu xuất và cập nhật tồn kho!");
                LoadData();
            }
            catch (Exception ex) { MessageHelper.ShowError(ex.Message); }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (dgvPhieu.SelectedRows.Count == 0) { MessageHelper.ShowWarning("Chọn phiếu cần hủy!"); return; }
            PhieuXuat px = dgvPhieu.SelectedRows[0].Tag as PhieuXuat;
            if (px == null) return;
            if (px.TrangThai == 2) { MessageHelper.ShowWarning("Phiếu đã bị hủy trước đó!"); return; }
            if (!MessageHelper.ConfirmWarning("Hủy phiếu xuất này?" + (px.TrangThai == 1 ? " Tồn kho sẽ được hoàn trả." : ""))) return;
            try
            {
                _bus.HuyPhieuXuat(px.MaPhieuXuat);
                MessageHelper.ShowSuccess("Đã hủy phiếu xuất!");
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

    public partial class FormXuatKhoDetail : Form
    {
        private PhieuXuatBUS _bus = new PhieuXuatBUS();
        private KhachHangBUS _khBUS = new KhachHangBUS();
        private int _maPhieu = 0;
        private bool _isEdit = false;

        public FormXuatKhoDetail(int maPhieu = 0)
        {
            InitializeComponent();
            _maPhieu = maPhieu;
            _isEdit = maPhieu > 0;
        }

        private void FormXuatKhoDetail_Load(object sender, EventArgs e)
        {
            LoadKHCombo();
            if (_isEdit)
            {
                this.Text = "Sửa phiếu xuất";
                LoadPhieu();
            }
            else
            {
                this.Text = "Tạo phiếu xuất mới";
                txtMaPhieu.Text = _bus.GetNextMaPhieuXuat();
                dtpNgayXuat.Value = DateTime.Now;
            }
        }

        private void LoadKHCombo()
        {
            cmbKH.Items.Clear();
            cmbKH.Items.Add("-- Chọn khách hàng --");
            foreach (var kh in _khBUS.GetAllActive())
                cmbKH.Items.Add(kh);
            cmbKH.DisplayMember = "TenKH";
            cmbKH.ValueMember = "MaKH";
            cmbKH.SelectedIndex = 0;
        }

        private void LoadPhieu()
        {
            try
            {
                var px = _bus.GetById(_maPhieu);
                if (px == null) { MessageHelper.ShowError("Không tìm thấy phiếu!"); this.Close(); return; }

                txtMaPhieu.Text = px.MaPhieuXuatCode;
                dtpNgayXuat.Value = px.NgayXuat;
                txtGhiChu.Text = px.GhiChu;

                for (int i = 1; i < cmbKH.Items.Count; i++)
                {
                    if (cmbKH.Items[i] is KhachHang kh && kh.MaKH == px.MaKH)
                    { cmbKH.SelectedIndex = i; break; }
                }

                foreach (var ct in px.ChiTietPhieuXuats)
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
                foreach (DataGridViewRow row in dgvChiTiet.Rows)
                {
                    if (row.Tag != null && (int)row.Tag == maSP)
                    {
                        MessageHelper.ShowWarning("Sản phẩm này đã có trong phiếu!");
                        return;
                    }
                }

                if (frm.SelectedSoLuong > frm.SelectedSP.SoLuongTon)
                {
                    MessageHelper.ShowWarning("Số lượng vượt quá tồn kho hiện tại: " + frm.SelectedSP.SoLuongTon);
                    return;
                }

                int soLuong = frm.SelectedSoLuong;
                decimal donGia = frm.SelectedSP.GiaBan;
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
            if (cmbKH.SelectedIndex == 0) { MessageHelper.ShowWarning("Vui lòng chọn khách hàng!"); return; }
            if (dgvChiTiet.Rows.Count == 0) { MessageHelper.ShowWarning("Phiếu phải có ít nhất 1 sản phẩm!"); return; }

            try
            {
                var kh = cmbKH.SelectedItem as KhachHang;
                if (kh == null) return;

                var px = new PhieuXuat
                {
                    MaPhieuXuat = _maPhieu,
                    MaPhieuXuatCode = txtMaPhieu.Text.Trim(),
                    MaKH = kh.MaKH,
                    NgayXuat = dtpNgayXuat.Value,
                    GhiChu = txtGhiChu.Text.Trim(),
                    TrangThai = 0
                };

                var chiTiet = new List<ChiTietPhieuXuat>();
                foreach (DataGridViewRow row in dgvChiTiet.Rows)
                {
                    int maSP = (int)row.Tag;
                    int soLuong = 0;
                    decimal donGia = 0;
                    int.TryParse(row.Cells["colSoLuong"].Value.ToString(), out soLuong);
                    decimal.TryParse(row.Cells["colDonGia"].Value.ToString(), out donGia);

                    if (soLuong <= 0) { MessageHelper.ShowWarning("Số lượng phải lớn hơn 0!"); return; }
                    if (donGia < 0) { MessageHelper.ShowWarning("Đơn giá không được âm!"); return; }

                    chiTiet.Add(new ChiTietPhieuXuat
                    {
                        MaSP = maSP,
                        SoLuong = soLuong,
                        DonGia = donGia,
                        ThanhTien = soLuong * donGia
                    });
                }

                if (_isEdit)
                {
                    _bus.CapNhatPhieuXuat(px, chiTiet);
                    MessageHelper.ShowSuccess("Cập nhật phiếu xuất thành công!");
                }
                else
                {
                    _bus.TaoPhieuXuat(px, chiTiet);
                    MessageHelper.ShowSuccess("Tạo phiếu xuất thành công!");
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
