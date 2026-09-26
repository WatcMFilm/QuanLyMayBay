using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QuanLyVeMayBay
{
    // Lớp tiện ích giao diện chuẩn Doanh nghiệp
    public static class UiTheme
    {
        // Bảng màu Doanh nghiệp Hàng không (Aviation Slate / Ocean Blue)
        public static readonly Color FormBg           = Color.FromArgb(241, 245, 249); // Slate 100
        public static readonly Color CardBg           = Color.FromArgb(255, 255, 255); // White
        public static readonly Color HeaderDark       = Color.FromArgb(15, 23, 42);    // Slate 900
        public static readonly Color BorderLight      = Color.FromArgb(203, 213, 225); // Slate 300
        public static readonly Color TextPrimary      = Color.FromArgb(15, 23, 42);    // Slate 900
        public static readonly Color TextMuted        = Color.FromArgb(100, 116, 139); // Slate 500

        // Màu nút hành động (Vibrant Action Colors)
        public static readonly Color PrimaryBlue      = Color.FromArgb(2, 132, 199);   // Sky 600
        public static readonly Color PrimaryBlueHover = Color.FromArgb(3, 105, 161);   // Sky 700

        public static readonly Color SuccessGreen     = Color.FromArgb(16, 185, 129);  // Emerald 500
        public static readonly Color SuccessGreenHover= Color.FromArgb(5, 150, 105);   // Emerald 600

        public static readonly Color WarningAmber     = Color.FromArgb(245, 158, 11);  // Amber 500
        public static readonly Color WarningAmberHover= Color.FromArgb(217, 119, 6);   // Amber 600

        public static readonly Color DangerRose       = Color.FromArgb(239, 68, 68);   // Rose 500
        public static readonly Color DangerRoseHover  = Color.FromArgb(220, 38, 38);   // Rose 600

        public static readonly Color SecondarySlate   = Color.FromArgb(100, 116, 139); // Slate 500
        public static readonly Color SecondarySlateHover = Color.FromArgb(71, 85, 105);// Slate 600

        public static readonly Color CalloutBg        = Color.FromArgb(239, 246, 255); // Blue 50
        public static readonly Color CalloutBorder    = Color.FromArgb(147, 197, 253); // Blue 300

        // Font chữ tiêu chuẩn Segoe UI
        public static readonly Font FontTitle         = new Font("Segoe UI", 16f, FontStyle.Bold);
        public static readonly Font FontSubTitle      = new Font("Segoe UI", 9.5f, FontStyle.Regular);
        public static readonly Font FontCardHeader    = new Font("Segoe UI", 10f, FontStyle.Bold);
        public static readonly Font FontLabel         = new Font("Segoe UI", 9.5f, FontStyle.Regular);
        public static readonly Font FontButton        = new Font("Segoe UI", 9.5f, FontStyle.Bold);
        public static readonly Font FontInput         = new Font("Segoe UI", 9.5f, FontStyle.Regular);
        public static readonly Font FontGridHeader    = new Font("Segoe UI", 9.5f, FontStyle.Bold);
        public static readonly Font FontGridCell      = new Font("Segoe UI", 9.5f, FontStyle.Regular);

        // Áp dụng kiểu dáng form chuẩn
        public static void ApplyFormStyle(Form form)
        {
            form.BackColor = FormBg;
            form.Font = FontLabel;
            form.ForeColor = TextPrimary;
        }

        // Áp dụng kiểu dáng Card cho GroupBox
        public static void ApplyCardStyle(GroupBox grp)
        {
            grp.BackColor = CardBg;
            grp.ForeColor = TextPrimary;
            grp.Font = FontCardHeader;
        }

        // Áp dụng kiểu dáng Callout Banner
        public static void ApplyCalloutStyle(GroupBox grp)
        {
            grp.BackColor = CalloutBg;
            grp.ForeColor = Color.FromArgb(30, 58, 138); // Blue 900
            grp.Font = FontCardHeader;
        }

        // Áp dụng kiểu dáng nút bấm phẳng hiện đại
        public static void ApplyButtonStyle(Button btn, Color bg, Color hoverBg, Color fg)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = hoverBg;
            btn.FlatAppearance.MouseDownBackColor = hoverBg;
            btn.BackColor = bg;
            btn.ForeColor = fg;
            btn.Font = FontButton;
            btn.Cursor = Cursors.Hand;
            btn.UseVisualStyleBackColor = false;
        }

        // Áp dụng kiểu dáng chuẩn cho DataGridView
        public static void ApplyDataGridStyle(DataGridView dgv)
        {
            dgv.BorderStyle = BorderStyle.None;
            dgv.BackgroundColor = Color.White;
            dgv.GridColor = Color.FromArgb(226, 232, 240); // Slate 200
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.EnableHeadersVisualStyles = false;
            dgv.RowHeadersVisible = false;
            dgv.MultiSelect = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.RowTemplate.Height = 36;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Header tối màu sang trọng
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersHeight = 40;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = HeaderDark;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = FontGridHeader;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 0, 0);

            // Dòng dữ liệu mặc định
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = TextPrimary;
            dgv.DefaultCellStyle.Font = FontGridCell;
            dgv.DefaultCellStyle.Padding = new Padding(8, 0, 0, 0);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 242, 254); // Light Sky
            dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(3, 105, 161);   // Deep Sky

            // Hàng xen kẽ (Zebra Striping)
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252); // Slate 50
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = TextPrimary;
            dgv.AlternatingRowsDefaultCellStyle.Padding = new Padding(8, 0, 0, 0);
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 242, 254);
            dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(3, 105, 161);
        }

        // Tô màu Badge trực quan cho cột trạng thái
        public static void FormatStatusCell(DataGridViewCellFormattingEventArgs e, string statusColumnName, DataGridView dgv)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dgv.Columns[e.ColumnIndex].Name != statusColumnName) return;

            string status = e.Value?.ToString() ?? "";
            if (string.IsNullOrWhiteSpace(status)) return;

            // Đang mở / Mở
            if (status.Contains("Đang mở") || status.Contains("Dang mo"))
            {
                e.CellStyle.ForeColor = Color.FromArgb(21, 128, 61); // Green 700
                e.CellStyle.BackColor = Color.FromArgb(220, 252, 231); // Green 100
                e.CellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            }
            // Sắp cất cánh
            else if (status.Contains("Sắp cất cánh") || status.Contains("Sap cat canh"))
            {
                e.CellStyle.ForeColor = Color.FromArgb(180, 83, 9); // Amber 700
                e.CellStyle.BackColor = Color.FromArgb(254, 243, 199); // Amber 100
                e.CellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            }
            // Đã cất cánh
            else if (status.Contains("Đã cất cánh") || status.Contains("Da cat canh"))
            {
                e.CellStyle.ForeColor = Color.FromArgb(3, 105, 161); // Sky 700
                e.CellStyle.BackColor = Color.FromArgb(224, 242, 254); // Sky 100
                e.CellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            }
            // Hoàn tất / Đã thanh toán
            else if (status.Contains("Hoàn tất") || status.Contains("Hoan tat") || status.Contains("Đã thanh toán") || status.Contains("Da thanh toan"))
            {
                e.CellStyle.ForeColor = Color.FromArgb(21, 128, 61); // Green 700
                e.CellStyle.BackColor = Color.FromArgb(220, 252, 231); // Green 100
                e.CellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            }
            // Đã hủy
            else if (status.Contains("Đã hủy") || status.Contains("Da huy"))
            {
                e.CellStyle.ForeColor = Color.FromArgb(185, 28, 28); // Red 700
                e.CellStyle.BackColor = Color.FromArgb(254, 226, 226); // Red 100
                e.CellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            }
            // Chờ thanh toán (dành cho vé)
            else if (status.Contains("Chờ thanh toán") || status.Contains("Cho thanh toan"))
            {
                e.CellStyle.ForeColor = Color.FromArgb(146, 64, 14); // Yellow 800
                e.CellStyle.BackColor = Color.FromArgb(254, 249, 195); // Yellow 100
                e.CellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            }
        }
    }
}
