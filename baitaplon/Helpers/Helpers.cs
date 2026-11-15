using System;
using System.Drawing;
using System.Windows.Forms;

namespace baitaplon.Helpers
{
    /// <summary>
    /// Helper class for common message dialogs
    /// </summary>
    public static class MessageHelper
    {
        public static void ShowInfo(string message, string title = "Thông báo")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowError(string message, string title = "Lỗi")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowWarning(string message, string title = "Cảnh báo")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ShowSuccess(string message, string title = "Thành công")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool Confirm(string message, string title = "Xác nhận")
        {
            return MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public static bool ConfirmWarning(string message, string title = "Cảnh báo")
        {
            return MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;
        }
    }

    /// <summary>
    /// Helper for formatting display values
    /// </summary>
    public static class FormatHelper
    {
        public static string FormatCurrency(decimal amount)
        {
            return string.Format("{0:N0} đ", amount);
        }

        public static string FormatNumber(int number)
        {
            return string.Format("{0:N0}", number);
        }

        public static string FormatDate(DateTime date)
        {
            return date.ToString("dd/MM/yyyy");
        }

        public static string FormatDateTime(DateTime date)
        {
            return date.ToString("dd/MM/yyyy HH:mm");
        }

        public static string GetTrangThaiPhieu(int trangThai)
        {
            switch (trangThai)
            {
                case 0: return "Nháp";
                case 1: return "Đã xác nhận";
                case 2: return "Đã hủy";
                default: return "Không xác định";
            }
        }

        public static Color GetTrangThaiColor(int trangThai)
        {
            switch (trangThai)
            {
                case 0: return Color.FromArgb(255, 152, 0);  // Orange - Draft
                case 1: return Color.FromArgb(76, 175, 80);   // Green - Confirmed
                case 2: return Color.FromArgb(244, 67, 54);   // Red - Cancelled
                default: return Color.Gray;
            }
        }

        public static string GetTrangThaiSanPham(int trangThai)
        {
            return trangThai == 1 ? "Đang kinh doanh" : "Ngừng kinh doanh";
        }

        public static string GetTrangThaiTaiKhoan(int trangThai)
        {
            return trangThai == 1 ? "Hoạt động" : "Đã khóa";
        }
    }

    /// <summary>
    /// Helper for UI styling
    /// </summary>
    public static class UIHelper
    {
        // Color palette
        public static readonly Color PrimaryColor = Color.FromArgb(25, 118, 210);        // Blue
        public static readonly Color PrimaryDarkColor = Color.FromArgb(21, 101, 192);     // Dark Blue
        public static readonly Color PrimaryLightColor = Color.FromArgb(66, 165, 245);    // Light Blue
        public static readonly Color AccentColor = Color.FromArgb(255, 152, 0);           // Orange
        public static readonly Color SidebarColor = Color.FromArgb(33, 37, 41);           // Dark sidebar
        public static readonly Color SidebarHoverColor = Color.FromArgb(52, 58, 64);      // Sidebar hover
        public static readonly Color SidebarActiveColor = Color.FromArgb(25, 118, 210);   // Active menu
        public static readonly Color BackgroundColor = Color.FromArgb(245, 245, 245);     // Light gray bg
        public static readonly Color CardColor = Color.White;
        public static readonly Color TextColor = Color.FromArgb(33, 37, 41);
        public static readonly Color TextLightColor = Color.FromArgb(108, 117, 125);
        public static readonly Color BorderColor = Color.FromArgb(222, 226, 230);
        public static readonly Color SuccessColor = Color.FromArgb(76, 175, 80);
        public static readonly Color DangerColor = Color.FromArgb(244, 67, 54);
        public static readonly Color WarningColor = Color.FromArgb(255, 152, 0);
        public static readonly Color InfoColor = Color.FromArgb(33, 150, 243);

        // Fonts
        public static readonly Font HeaderFont = new Font("Segoe UI", 18F, FontStyle.Bold);
        public static readonly Font SubHeaderFont = new Font("Segoe UI", 14F, FontStyle.Bold);
        public static readonly Font TitleFont = new Font("Segoe UI", 12F, FontStyle.Bold);
        public static readonly Font NormalFont = new Font("Segoe UI", 10F);
        public static readonly Font SmallFont = new Font("Segoe UI", 9F);
        public static readonly Font MenuFont = new Font("Segoe UI", 10.5F);
        public static readonly Font MenuFontBold = new Font("Segoe UI", 10.5F, FontStyle.Bold);
        public static readonly Font StatNumberFont = new Font("Segoe UI", 24F, FontStyle.Bold);
        public static readonly Font StatLabelFont = new Font("Segoe UI", 10F);

        /// <summary>
        /// Style a DataGridView for modern look
        /// </summary>
        public static void StyleDataGridView(DataGridView dgv)
        {
            dgv.BorderStyle = BorderStyle.None;
            dgv.BackgroundColor = Color.White;
            dgv.GridColor = BorderColor;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dgv.DefaultCellStyle.Font = NormalFont;
            dgv.DefaultCellStyle.ForeColor = TextColor;
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(232, 240, 254);
            dgv.DefaultCellStyle.SelectionForeColor = TextColor;
            dgv.DefaultCellStyle.Padding = new Padding(5, 8, 5, 8);

            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);

            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = PrimaryColor;
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(5, 10, 5, 10);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersHeight = 40;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgv.RowHeadersVisible = false;
            dgv.RowTemplate.Height = 38;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ReadOnly = true;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        /// <summary>
        /// Style a Button as primary
        /// </summary>
        public static void StyleButton(Button btn, Color bgColor, Color foreColor)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = bgColor;
            btn.ForeColor = foreColor;
            btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
            btn.Padding = new Padding(10, 5, 10, 5);

            btn.MouseEnter += (s, e) => {
                btn.BackColor = ControlPaint.Dark(bgColor, 0.1f);
            };
            btn.MouseLeave += (s, e) => {
                btn.BackColor = bgColor;
            };
        }

        public static void StylePrimaryButton(Button btn)
        {
            StyleButton(btn, PrimaryColor, Color.White);
        }

        public static void StyleSuccessButton(Button btn)
        {
            StyleButton(btn, SuccessColor, Color.White);
        }

        public static void StyleDangerButton(Button btn)
        {
            StyleButton(btn, DangerColor, Color.White);
        }

        public static void StyleWarningButton(Button btn)
        {
            StyleButton(btn, WarningColor, Color.White);
        }

        public static void StyleSecondaryButton(Button btn)
        {
            StyleButton(btn, Color.FromArgb(108, 117, 125), Color.White);
        }

        /// <summary>
        /// Style a TextBox
        /// </summary>
        public static void StyleTextBox(TextBox txt)
        {
            txt.Font = NormalFont;
            txt.BorderStyle = BorderStyle.FixedSingle;
        }

        /// <summary>
        /// Style a ComboBox
        /// </summary>
        public static void StyleComboBox(ComboBox cmb)
        {
            cmb.Font = NormalFont;
            cmb.FlatStyle = FlatStyle.Flat;
            cmb.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>
        /// Create a styled card panel
        /// </summary>
        public static Panel CreateCard(int x, int y, int width, int height)
        {
            Panel card = new Panel();
            card.Location = new Point(x, y);
            card.Size = new Size(width, height);
            card.BackColor = CardColor;
            card.Padding = new Padding(15);
            return card;
        }

        /// <summary>
        /// Style a Panel as a stat card for dashboard
        /// </summary>
        public static Panel CreateStatCard(string title, string value, Color color, int x, int y, int width = 220, int height = 100)
        {
            Panel card = new Panel();
            card.Location = new Point(x, y);
            card.Size = new Size(width, height);
            card.BackColor = Color.White;
            card.Cursor = Cursors.Hand;
            card.Tag = title;

            // Left color strip
            Panel strip = new Panel();
            strip.Dock = DockStyle.Left;
            strip.Width = 5;
            strip.BackColor = color;
            card.Controls.Add(strip);

            // Value label
            Label lblValue = new Label();
            lblValue.Text = value;
            lblValue.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblValue.ForeColor = TextColor;
            lblValue.Location = new Point(20, 15);
            lblValue.AutoSize = true;
            card.Controls.Add(lblValue);

            // Title label
            Label lblTitle = new Label();
            lblTitle.Text = title;
            lblTitle.Font = StatLabelFont;
            lblTitle.ForeColor = TextLightColor;
            lblTitle.Location = new Point(20, height - 35);
            lblTitle.AutoSize = true;
            card.Controls.Add(lblTitle);

            return card;
        }
    }

    /// <summary>
    /// Input validation helper
    /// </summary>
    public static class ValidationHelper
    {
        public static bool IsNullOrEmpty(string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return true; // Optional field
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return true; // Optional field
            phone = phone.Trim();
            if (phone.Length < 9 || phone.Length > 15) return false;
            foreach (char c in phone)
            {
                if (!char.IsDigit(c) && c != '+' && c != '-' && c != ' ') return false;
            }
            return true;
        }

        public static bool IsPositiveNumber(decimal value)
        {
            return value > 0;
        }

        public static bool IsNonNegativeNumber(decimal value)
        {
            return value >= 0;
        }

        public static bool IsPositiveInt(int value)
        {
            return value > 0;
        }
    }
}

