using System;
using System.Drawing;
using System.Windows.Forms;
using baitaplon.BUS;
using baitaplon.Models;
using baitaplon.Helpers;

namespace baitaplon.GUI
{
    public partial class FormDanhMuc : Form
    {
        private DanhMucBUS _bus = new DanhMucBUS();
        public FormDanhMuc() { InitializeComponent(); }

        private void FormDanhMuc_Load(object sender, EventArgs e) { UIHelper.StyleDataGridView(dgvData); LoadData(); }

        private void LoadData()
        {
            try
            {
                var list = _bus.GetAll();
                dgvData.Rows.Clear();
                foreach (var item in list)
                {
                    int idx = dgvData.Rows.Add();
                    dgvData.Rows[idx].Cells[0].Value = item.MaDanhMuc;
                    dgvData.Rows[idx].Cells[1].Value = item.TenDanhMuc;
                    dgvData.Rows[idx].Cells[2].Value = item.MoTa;
                    dgvData.Rows[idx].Cells[3].Value = item.TrangThai == 1 ? "Hoạt động" : "Ẩn";
                    dgvData.Rows[idx].Tag = item;
                    if (item.TrangThai == 0) dgvData.Rows[idx].DefaultCellStyle.ForeColor = Color.Gray;
                }
            }
            catch (Exception ex) { MessageHelper.ShowError(ex.Message); }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string ten = Microsoft.VisualBasic.Interaction.InputBox("Nhập tên danh mục:", "Thêm danh mục", "");
            if (string.IsNullOrWhiteSpace(ten)) return;
            try
            {
                _bus.ThemDanhMuc(new DanhMuc { TenDanhMuc = ten });
                MessageHelper.ShowSuccess("Thêm danh mục thành công!");
                LoadData();
            }
            catch (Exception ex) { MessageHelper.ShowError(ex.Message); }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 0) { MessageHelper.ShowWarning("Chọn danh mục cần sửa!"); return; }
            DanhMuc dm = dgvData.SelectedRows[0].Tag as DanhMuc;
            if (dm == null) return;
            string ten = Microsoft.VisualBasic.Interaction.InputBox("Sửa tên danh mục:", "Sửa danh mục", dm.TenDanhMuc);
            if (string.IsNullOrWhiteSpace(ten)) return;
            try
            {
                dm.TenDanhMuc = ten;
                _bus.CapNhatDanhMuc(dm);
                MessageHelper.ShowSuccess("Cập nhật thành công!");
                LoadData();
            }
            catch (Exception ex) { MessageHelper.ShowError(ex.Message); }
        }

        private void btnAnHien_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 0) { MessageHelper.ShowWarning("Chọn danh mục!"); return; }
            DanhMuc dm = dgvData.SelectedRows[0].Tag as DanhMuc;
            if (dm == null) return;
            try
            {
                _bus.AnDanhMuc(dm.MaDanhMuc, dm.TrangThai == 1 ? 0 : 1);
                LoadData();
            }
            catch (Exception ex) { MessageHelper.ShowError(ex.Message); }
        }
    }
}

