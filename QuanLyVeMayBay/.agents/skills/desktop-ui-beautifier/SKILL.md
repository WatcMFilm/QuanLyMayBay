---
name: desktop-ui-beautifier
description: >-
  Professional design guidelines, color palettes, component styling, and UI/UX modernization
  workflows for Desktop Applications (Windows Forms, WPF, and modern .NET desktop apps).
  Use this skill whenever the user asks to beautify, modernize, redesign, restyle, or improve
  the appearance, layout, and UX of desktop applications.
---

# Desktop UI Beautifier Skill

Hướng dẫn và quy chuẩn thiết kế giúp chuyển đổi các ứng dụng Desktop (.NET Windows Forms, WPF) từ giao diện cũ kỹ, thô sơ sang phong cách thiết kế phẳng (Flat Design), hiện đại (Modern Fluent/Material), chuyên nghiệp và sạch đẹp.

---

## 1. Hệ thống Bảng màu Hiện đại (Design Palette)

Tránh sử dụng màu mặc định của hệ thống Windows (`Control`, `White`, `Black`). Sử dụng bảng màu phối sẵn (Tailwind/Modern UI):

### Bảng màu Slate / Ocean (Phù hợp ứng dụng Quản lý, Doanh nghiệp, Hàng không)
- **Nền chính (Background)**: `#F8FAFC` (Slate 50 - xám trắng dịu mắt)
- **Nền thẻ / Container (Card/Panel)**: `#FFFFFF` (Trắng tinh khiết)
- **Màu chủ đạo (Primary)**: `#0284C7` (Sky 600) hoặc `#1E40AF` (Blue 800)
- **Màu phụ trợ (Secondary/Accent)**: `#0EA5E9` (Sky 500) hoặc `#0D9488` (Teal 600)
- **Màu thành công (Success/Add)**: `#10B981` (Emerald 500)
- **Màu cảnh báo (Warning/Edit)**: `#F59E0B` (Amber 500)
- **Màu nguy hiểm (Danger/Delete)**: `#EF4444` (Rose 500)
- **Màu chữ chính (Text Primary)**: `#0F172A` (Slate 900)
- **Màu chữ phụ (Text Muted)**: `#64748B` (Slate 500)
- **Đường viền (Border)**: `#E2E8F0` (Slate 200)

---

## 2. Quy chuẩn Typography (Font chữ)

- **Font tiêu chuẩn**: Luôn đặt `Segoe UI` (hoặc `Segoe UI Variable Text` trên Windows 11).
- **Phân cấp kích thước font (Hierarchy)**:
  - Tiêu đề Form / Header: `16pt` - `18pt`, **Bold**, màu `#0F172A` hoặc `#1E40AF`.
  - Tiêu đề GroupBox / Card: `10pt` - `11pt`, **Bold**, màu `#1E293B`.
  - Nhãn (Label): `9pt` - `9.5pt`, **Regular**, màu `#334155`.
  - Nút bấm (Button): `9.5pt` - `10pt`, **Bold**.
  - Ô nhập liệu (TextBox/ComboBox): `9.5pt`, **Regular**.
  - Bảng (DataGridView Data): `9pt`, **Regular**.
  - Bảng Header (DataGridView Header): `9.5pt`, **Bold**.

---

## 3. Kỹ thuật làm đẹp WinForms thuần (Pure C# - Không cần thư viện ngoài)

### A. Làm đẹp DataGridView (Khối quan trọng nhất)
```csharp
public static void LamDepDataGridView(DataGridView dgv)
{
    dgv.BorderStyle = BorderStyle.None;
    dgv.BackgroundColor = Color.White;
    dgv.GridColor = Color.FromArgb(241, 245, 249);
    dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
    dgv.EnableHeadersVisualStyles = false;
    dgv.RowHeadersVisible = false;
    dgv.MultiSelect = false;
    dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    dgv.RowTemplate.Height = 36;
    dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

    // Header đẹp mắt
    dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
    dgv.ColumnHeadersHeight = 42;
    dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 41, 59); // Slate 800
    dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
    dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
    dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

    // Hàng mặc định
    dgv.DefaultCellStyle.BackColor = Color.White;
    dgv.DefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
    dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9.5f);
    dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 242, 254); // Light Sky
    dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(3, 105, 161); // Deep Sky

    // Hàng xen kẽ (Zebra Striping)
    dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
    dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 242, 254);
    dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(3, 105, 161);
}
```

### B. Làm đẹp Nút bấm (Flat Modern Buttons)
```csharp
public static void LamDepButton(Button btn, Color mauNen, Color mauChu)
{
    btn.FlatStyle = FlatStyle.Flat;
    btn.FlatAppearance.BorderSize = 0;
    btn.BackColor = mauNen;
    btn.ForeColor = mauChu;
    btn.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
    btn.Cursor = Cursors.Hand;
    btn.UseVisualStyleBackColor = false;
}
```

### C. Sử dụng Icon ký tự Unicode gọn gàng
Tăng tính trực quan bằng emoji/ký tự Unicode không cần nạp file ảnh icon nặng:
- Thêm mới: `➕ Thêm` hoặc `➕ Thêm mới`
- Chỉnh sửa: `✏️ Sửa` hoặc `📝 Cập nhật`
- Xóa: `🗑️ Xóa`
- Làm mới: `🔄 Làm mới`
- Tìm kiếm: `🔍 Tìm kiếm`
- Đặt vé: `✈️ Đặt vé`
- Lưu dữ liệu: `💾 Lưu`
- Thoát: `🚪 Đóng`

---

## 4. Tích hợp Thư viện Ngoài (Khi được phép)

Nếu dự án cho phép cài thêm thư viện qua NuGet:
1. **ReaLTaiizor** (WinForms):
   `dotnet add package ReaLTaiizor`
   - Cung cấp: `MaterialButton`, `CyberTextBox`, `HopeComboBox`, `PoisonDataGridView`...
2. **WPF-UI** (WPF / Windows 11 Fluent):
   `dotnet add package WPF-UI`

---

## 5. Quy trình hiện đại hóa một Form (Checklist)

1. **Khảo sát bố cục (Layout)**: Gom nhóm các trường liên quan vào các Panel/Card có màu nền trắng `#FFFFFF` trên nền Form xám nhẹ `#F8FAFC`.
2. **Định dạng Control**:
   - Đổi font toàn bộ control sang `Segoe UI`.
   - Chuyển tất cả Button sang `FlatStyle.Flat` với màu sắc phân biệt rõ rệt (Thêm: Xanh lá/Xanh dương, Sửa: Vàng cam, Xóa: Đỏ cam, Làm mới: Xám xanh).
   - DataGridView áp dụng định dạng `LamDepDataGridView`.
3. **Hiệu ứng trực quan**: Thêm padding vừa phải (5-10px), khoảng cách giữa các ô nhập liệu thoáng đãng, không chen chúc.
