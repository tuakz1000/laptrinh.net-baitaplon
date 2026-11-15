using System;
using System.Drawing;
using System.Windows.Forms;
using baitaplon.BUS;
using baitaplon.Models;
using baitaplon.Helpers;

namespace baitaplon.GUI
{
    public partial class FormDonViTinh : Form
    {
        private DonViTinhBUS _bus = new DonViTinhBUS();
        public FormDonViTinh() { InitializeComponent(); }
        private void FormDonViTinh_Load(object sender, EventArgs e) { UIHelper.StyleDataGridView(dgvData); LoadData(); }
        private void LoadData()
        {
            try
            {
                var list = _bus.GetAll();
                dgvData.Rows.Clear();
                foreach (var item in list)
                {
                    int idx = dgvData.Rows.Add(item.MaDVT, item.TenDVT, item.MoTa, item.TrangThai == 1 ? "Hoạt động" : "Ẩn");
                    dgvData.Rows[idx].Tag = item;
                    if (item.TrangThai == 0) dgvData.Rows[idx].DefaultCellStyle.ForeColor = Color.Gray;
                }
            }
            catch (Exception ex) { MessageHelper.ShowError(ex.Message); }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string ten = Microsoft.VisualBasic.Interaction.InputBox("Nhập tên đơn vị tính:", "Thêm ĐVT", "");
            if (string.IsNullOrWhiteSpace(ten)) return;
            try { _bus.ThemDonViTinh(new DonViTinh { TenDVT = ten }); MessageHelper.ShowSuccess("Thêm thành công!"); LoadData(); }
            catch (Exception ex) { MessageHelper.ShowError(ex.Message); }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 0) { MessageHelper.ShowWarning("Chọn đơn vị tính cần sửa!"); return; }
            DonViTinh dvt = dgvData.SelectedRows[0].Tag as DonViTinh;
            if (dvt == null) return;
            string ten = Microsoft.VisualBasic.Interaction.InputBox("Sửa tên:", "Sửa ĐVT", dvt.TenDVT);
            if (string.IsNullOrWhiteSpace(ten)) return;
            try { dvt.TenDVT = ten; _bus.CapNhatDonViTinh(dvt); MessageHelper.ShowSuccess("Cập nhật thành công!"); LoadData(); }
            catch (Exception ex) { MessageHelper.ShowError(ex.Message); }
        }
        private void btnAnHien_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 0) return;
            DonViTinh dvt = dgvData.SelectedRows[0].Tag as DonViTinh;
            if (dvt == null) return;
            try { _bus.AnDonViTinh(dvt.MaDVT, dvt.TrangThai == 1 ? 0 : 1); LoadData(); }
            catch (Exception ex) { MessageHelper.ShowError(ex.Message); }
        }
    }
}

