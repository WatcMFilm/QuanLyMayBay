namespace QuanLyVeMayBay
{
    partial class frmThanhToan
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTieuDe = new Label();
            tabMain = new TabControl();
            tabThanhToan = new TabPage();
            grpDanhSachVe = new GroupBox();
            dgvVe = new DataGridView();
            pnlLocVe = new Panel();
            btnLamMoiVe = new Button();
            cboLocTrangThai = new ComboBox();
            lblLocTrangThai = new Label();
            txtTimVe = new TextBox();
            lblTimVe = new Label();
            grpThongTinChiTiet = new GroupBox();
            btnLamMoi = new Button();
            btnLapHoaDon = new Button();
            btnXacNhanThanhToan = new Button();
            chkLapHoaDonNgay = new CheckBox();
            cboPhuongThuc = new ComboBox();
            lblPhuongThuc = new Label();
            txtSoTien = new TextBox();
            lblSoTien = new Label();
            txtThoiGianDi = new TextBox();
            lblThoiGianDi = new Label();
            txtGhe = new TextBox();
            lblGhe = new Label();
            txtTuyenBay = new TextBox();
            lblTuyenBay = new Label();
            txtChuyenBay = new TextBox();
            lblChuyenBay = new Label();
            txtCCCD = new TextBox();
            lblCCCD = new Label();
            txtSDT = new TextBox();
            lblSDT = new Label();
            txtKhachHang = new TextBox();
            lblKhachHang = new Label();
            txtMaVe = new TextBox();
            lblMaVe = new Label();
            tabHoaDon = new TabPage();
            grpChiTietHoaDon = new GroupBox();
            btnInHoaDon = new Button();
            txtChiTietHoaDon = new TextBox();
            grpDanhSachHoaDon = new GroupBox();
            dgvHoaDon = new DataGridView();
            grpBoLocHoaDon = new GroupBox();
            btnLamMoiHoaDon = new Button();
            btnTraCuuHoaDon = new Button();
            dtpDenNgay = new DateTimePicker();
            lblDenNgay = new Label();
            dtpTuNgay = new DateTimePicker();
            chkLocTheoNgay = new CheckBox();
            txtTimHoaDon = new TextBox();
            lblTimHoaDon = new Label();
            tabMain.SuspendLayout();
            tabThanhToan.SuspendLayout();
            grpDanhSachVe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVe).BeginInit();
            pnlLocVe.SuspendLayout();
            grpThongTinChiTiet.SuspendLayout();
            tabHoaDon.SuspendLayout();
            grpChiTietHoaDon.SuspendLayout();
            grpDanhSachHoaDon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).BeginInit();
            grpBoLocHoaDon.SuspendLayout();
            SuspendLayout();
            // 
            // lblTieuDe
            // 
            lblTieuDe.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTieuDe.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTieuDe.ForeColor = Color.FromArgb(15, 23, 42);
            lblTieuDe.Location = new Point(12, 12);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(1036, 40);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "💳 QUẢN LÝ THANH TOÁN VÀ LẬP HÓA ĐƠN";
            lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tabMain
            // 
            tabMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabMain.Controls.Add(tabThanhToan);
            tabMain.Controls.Add(tabHoaDon);
            tabMain.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            tabMain.Location = new Point(12, 58);
            tabMain.Name = "tabMain";
            tabMain.SelectedIndex = 0;
            tabMain.Size = new Size(1036, 650);
            tabMain.TabIndex = 1;
            // 
            // tabThanhToan
            // 
            tabThanhToan.BackColor = Color.FromArgb(241, 245, 249);
            tabThanhToan.Controls.Add(grpDanhSachVe);
            tabThanhToan.Controls.Add(grpThongTinChiTiet);
            tabThanhToan.Location = new Point(4, 30);
            tabThanhToan.Name = "tabThanhToan";
            tabThanhToan.Padding = new Padding(10);
            tabThanhToan.Size = new Size(1028, 616);
            tabThanhToan.TabIndex = 0;
            tabThanhToan.Text = "💳 Xác nhận thanh toán";
            // 
            // grpDanhSachVe
            // 
            grpDanhSachVe.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpDanhSachVe.Controls.Add(dgvVe);
            grpDanhSachVe.Controls.Add(pnlLocVe);
            grpDanhSachVe.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpDanhSachVe.Location = new Point(10, 10);
            grpDanhSachVe.Name = "grpDanhSachVe";
            grpDanhSachVe.Size = new Size(610, 595);
            grpDanhSachVe.TabIndex = 0;
            grpDanhSachVe.TabStop = false;
            grpDanhSachVe.Text = "DANH SÁCH VÉ CHỜ THANH TOÁN";
            // 
            // dgvVe
            // 
            dgvVe.AllowUserToAddRows = false;
            dgvVe.AllowUserToDeleteRows = false;
            dgvVe.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvVe.BackgroundColor = Color.White;
            dgvVe.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVe.Font = new Font("Segoe UI", 9F);
            dgvVe.Location = new Point(10, 75);
            dgvVe.MultiSelect = false;
            dgvVe.Name = "dgvVe";
            dgvVe.ReadOnly = true;
            dgvVe.RowHeadersVisible = false;
            dgvVe.RowHeadersWidth = 51;
            dgvVe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVe.Size = new Size(590, 508);
            dgvVe.TabIndex = 1;
            dgvVe.CellClick += dgvVe_CellClick;
            // 
            // pnlLocVe
            // 
            pnlLocVe.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlLocVe.Controls.Add(btnLamMoiVe);
            pnlLocVe.Controls.Add(cboLocTrangThai);
            pnlLocVe.Controls.Add(lblLocTrangThai);
            pnlLocVe.Controls.Add(txtTimVe);
            pnlLocVe.Controls.Add(lblTimVe);
            pnlLocVe.Location = new Point(10, 25);
            pnlLocVe.Name = "pnlLocVe";
            pnlLocVe.Size = new Size(590, 42);
            pnlLocVe.TabIndex = 0;
            // 
            // btnLamMoiVe
            // 
            btnLamMoiVe.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLamMoiVe.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLamMoiVe.Location = new Point(495, 6);
            btnLamMoiVe.Name = "btnLamMoiVe";
            btnLamMoiVe.Size = new Size(90, 30);
            btnLamMoiVe.TabIndex = 4;
            btnLamMoiVe.Text = "🔄 Tải lại";
            btnLamMoiVe.UseVisualStyleBackColor = true;
            btnLamMoiVe.Click += btnLamMoiVe_Click;
            // 
            // cboLocTrangThai
            // 
            cboLocTrangThai.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboLocTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLocTrangThai.Font = new Font("Segoe UI", 9F);
            cboLocTrangThai.FormattingEnabled = true;
            cboLocTrangThai.Location = new Point(345, 7);
            cboLocTrangThai.Name = "cboLocTrangThai";
            cboLocTrangThai.Size = new Size(140, 28);
            cboLocTrangThai.TabIndex = 3;
            cboLocTrangThai.SelectedIndexChanged += cboLocTrangThai_SelectedIndexChanged;
            // 
            // lblLocTrangThai
            // 
            lblLocTrangThai.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblLocTrangThai.AutoSize = true;
            lblLocTrangThai.Font = new Font("Segoe UI", 9F);
            lblLocTrangThai.Location = new Point(265, 11);
            lblLocTrangThai.Name = "lblLocTrangThai";
            lblLocTrangThai.Size = new Size(78, 20);
            lblLocTrangThai.TabIndex = 2;
            lblLocTrangThai.Text = "Trạng thái:";
            // 
            // txtTimVe
            // 
            txtTimVe.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTimVe.Font = new Font("Segoe UI", 9F);
            txtTimVe.Location = new Point(75, 8);
            txtTimVe.Name = "txtTimVe";
            txtTimVe.PlaceholderText = "Mã vé, tên, SĐT...";
            txtTimVe.Size = new Size(180, 27);
            txtTimVe.TabIndex = 1;
            txtTimVe.TextChanged += txtTimVe_TextChanged;
            // 
            // lblTimVe
            // 
            lblTimVe.AutoSize = true;
            lblTimVe.Font = new Font("Segoe UI", 9F);
            lblTimVe.Location = new Point(5, 11);
            lblTimVe.Name = "lblTimVe";
            lblTimVe.Size = new Size(73, 20);
            lblTimVe.TabIndex = 0;
            lblTimVe.Text = "Tìm kiếm:";
            // 
            // grpThongTinChiTiet
            // 
            grpThongTinChiTiet.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            grpThongTinChiTiet.Controls.Add(btnLamMoi);
            grpThongTinChiTiet.Controls.Add(btnLapHoaDon);
            grpThongTinChiTiet.Controls.Add(btnXacNhanThanhToan);
            grpThongTinChiTiet.Controls.Add(chkLapHoaDonNgay);
            grpThongTinChiTiet.Controls.Add(cboPhuongThuc);
            grpThongTinChiTiet.Controls.Add(lblPhuongThuc);
            grpThongTinChiTiet.Controls.Add(txtSoTien);
            grpThongTinChiTiet.Controls.Add(lblSoTien);
            grpThongTinChiTiet.Controls.Add(txtThoiGianDi);
            grpThongTinChiTiet.Controls.Add(lblThoiGianDi);
            grpThongTinChiTiet.Controls.Add(txtGhe);
            grpThongTinChiTiet.Controls.Add(lblGhe);
            grpThongTinChiTiet.Controls.Add(txtTuyenBay);
            grpThongTinChiTiet.Controls.Add(lblTuyenBay);
            grpThongTinChiTiet.Controls.Add(txtChuyenBay);
            grpThongTinChiTiet.Controls.Add(lblChuyenBay);
            grpThongTinChiTiet.Controls.Add(txtCCCD);
            grpThongTinChiTiet.Controls.Add(lblCCCD);
            grpThongTinChiTiet.Controls.Add(txtSDT);
            grpThongTinChiTiet.Controls.Add(lblSDT);
            grpThongTinChiTiet.Controls.Add(txtKhachHang);
            grpThongTinChiTiet.Controls.Add(lblKhachHang);
            grpThongTinChiTiet.Controls.Add(txtMaVe);
            grpThongTinChiTiet.Controls.Add(lblMaVe);
            grpThongTinChiTiet.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpThongTinChiTiet.Location = new Point(628, 10);
            grpThongTinChiTiet.Name = "grpThongTinChiTiet";
            grpThongTinChiTiet.Size = new Size(390, 595);
            grpThongTinChiTiet.TabIndex = 1;
            grpThongTinChiTiet.TabStop = false;
            grpThongTinChiTiet.Text = "THÔNG TIN THANH TOÁN";
            // 
            // btnLamMoi
            // 
            btnLamMoi.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnLamMoi.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLamMoi.Location = new Point(200, 545);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(175, 38);
            btnLamMoi.TabIndex = 23;
            btnLamMoi.Text = "🔄 Xóa trắng";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnLapHoaDon
            // 
            btnLapHoaDon.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnLapHoaDon.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLapHoaDon.Location = new Point(15, 545);
            btnLapHoaDon.Name = "btnLapHoaDon";
            btnLapHoaDon.Size = new Size(175, 38);
            btnLapHoaDon.TabIndex = 22;
            btnLapHoaDon.Text = "🧾 Lập hóa đơn";
            btnLapHoaDon.UseVisualStyleBackColor = true;
            btnLapHoaDon.Click += btnLapHoaDon_Click;
            // 
            // btnXacNhanThanhToan
            // 
            btnXacNhanThanhToan.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnXacNhanThanhToan.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnXacNhanThanhToan.Location = new Point(15, 492);
            btnXacNhanThanhToan.Name = "btnXacNhanThanhToan";
            btnXacNhanThanhToan.Size = new Size(360, 44);
            btnXacNhanThanhToan.TabIndex = 21;
            btnXacNhanThanhToan.Text = "💳 XÁC NHẬN THANH TOÁN";
            btnXacNhanThanhToan.UseVisualStyleBackColor = true;
            btnXacNhanThanhToan.Click += btnXacNhanThanhToan_Click;
            // 
            // chkLapHoaDonNgay
            // 
            chkLapHoaDonNgay.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            chkLapHoaDonNgay.AutoSize = true;
            chkLapHoaDonNgay.Checked = true;
            chkLapHoaDonNgay.CheckState = CheckState.Checked;
            chkLapHoaDonNgay.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            chkLapHoaDonNgay.Location = new Point(15, 458);
            chkLapHoaDonNgay.Name = "chkLapHoaDonNgay";
            chkLapHoaDonNgay.Size = new Size(328, 24);
            chkLapHoaDonNgay.TabIndex = 20;
            chkLapHoaDonNgay.Text = "🧾 Tự động xuất hóa đơn sau khi thanh toán";
            chkLapHoaDonNgay.UseVisualStyleBackColor = true;
            // 
            // cboPhuongThuc
            // 
            cboPhuongThuc.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cboPhuongThuc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPhuongThuc.Font = new Font("Segoe UI", 9.5F);
            cboPhuongThuc.FormattingEnabled = true;
            cboPhuongThuc.Location = new Point(15, 422);
            cboPhuongThuc.Name = "cboPhuongThuc";
            cboPhuongThuc.Size = new Size(360, 29);
            cboPhuongThuc.TabIndex = 19;
            // 
            // lblPhuongThuc
            // 
            lblPhuongThuc.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblPhuongThuc.AutoSize = true;
            lblPhuongThuc.Font = new Font("Segoe UI", 9F);
            lblPhuongThuc.Location = new Point(15, 398);
            lblPhuongThuc.Name = "lblPhuongThuc";
            lblPhuongThuc.Size = new Size(171, 20);
            lblPhuongThuc.TabIndex = 18;
            lblPhuongThuc.Text = "Phương thức thanh toán:";
            // 
            // txtSoTien
            // 
            txtSoTien.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtSoTien.BackColor = Color.FromArgb(240, 253, 244);
            txtSoTien.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            txtSoTien.ForeColor = Color.FromArgb(22, 101, 52);
            txtSoTien.Location = new Point(15, 350);
            txtSoTien.Name = "txtSoTien";
            txtSoTien.ReadOnly = true;
            txtSoTien.Size = new Size(360, 36);
            txtSoTien.TabIndex = 17;
            txtSoTien.TextAlign = HorizontalAlignment.Center;
            // 
            // lblSoTien
            // 
            lblSoTien.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblSoTien.AutoSize = true;
            lblSoTien.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSoTien.ForeColor = Color.FromArgb(15, 23, 42);
            lblSoTien.Location = new Point(15, 326);
            lblSoTien.Name = "lblSoTien";
            lblSoTien.Size = new Size(189, 20);
            lblSoTien.TabIndex = 16;
            lblSoTien.Text = "SỐ TIỀN CẦN THANH TOÁN:";
            // 
            // txtThoiGianDi
            // 
            txtThoiGianDi.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtThoiGianDi.Font = new Font("Segoe UI", 9F);
            txtThoiGianDi.Location = new Point(130, 275);
            txtThoiGianDi.Name = "txtThoiGianDi";
            txtThoiGianDi.ReadOnly = true;
            txtThoiGianDi.Size = new Size(245, 27);
            txtThoiGianDi.TabIndex = 15;
            // 
            // lblThoiGianDi
            // 
            lblThoiGianDi.AutoSize = true;
            lblThoiGianDi.Font = new Font("Segoe UI", 9F);
            lblThoiGianDi.Location = new Point(15, 278);
            lblThoiGianDi.Name = "lblThoiGianDi";
            lblThoiGianDi.Size = new Size(106, 20);
            lblThoiGianDi.TabIndex = 14;
            lblThoiGianDi.Text = "Giờ khởi hành:";
            // 
            // txtGhe
            // 
            txtGhe.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtGhe.Font = new Font("Segoe UI", 9F);
            txtGhe.Location = new Point(130, 240);
            txtGhe.Name = "txtGhe";
            txtGhe.ReadOnly = true;
            txtGhe.Size = new Size(245, 27);
            txtGhe.TabIndex = 13;
            // 
            // lblGhe
            // 
            lblGhe.AutoSize = true;
            lblGhe.Font = new Font("Segoe UI", 9F);
            lblGhe.Location = new Point(15, 243);
            lblGhe.Name = "lblGhe";
            lblGhe.Size = new Size(74, 20);
            lblGhe.TabIndex = 12;
            lblGhe.Text = "Ghế ngồi:";
            // 
            // txtTuyenBay
            // 
            txtTuyenBay.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTuyenBay.Font = new Font("Segoe UI", 9F);
            txtTuyenBay.Location = new Point(130, 205);
            txtTuyenBay.Name = "txtTuyenBay";
            txtTuyenBay.ReadOnly = true;
            txtTuyenBay.Size = new Size(245, 27);
            txtTuyenBay.TabIndex = 11;
            // 
            // lblTuyenBay
            // 
            lblTuyenBay.AutoSize = true;
            lblTuyenBay.Font = new Font("Segoe UI", 9F);
            lblTuyenBay.Location = new Point(15, 208);
            lblTuyenBay.Name = "lblTuyenBay";
            lblTuyenBay.Size = new Size(82, 20);
            lblTuyenBay.TabIndex = 10;
            lblTuyenBay.Text = "Hành trình:";
            // 
            // txtChuyenBay
            // 
            txtChuyenBay.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtChuyenBay.Font = new Font("Segoe UI", 9F);
            txtChuyenBay.Location = new Point(130, 170);
            txtChuyenBay.Name = "txtChuyenBay";
            txtChuyenBay.ReadOnly = true;
            txtChuyenBay.Size = new Size(245, 27);
            txtChuyenBay.TabIndex = 9;
            // 
            // lblChuyenBay
            // 
            lblChuyenBay.AutoSize = true;
            lblChuyenBay.Font = new Font("Segoe UI", 9F);
            lblChuyenBay.Location = new Point(15, 173);
            lblChuyenBay.Name = "lblChuyenBay";
            lblChuyenBay.Size = new Size(88, 20);
            lblChuyenBay.TabIndex = 8;
            lblChuyenBay.Text = "Chuyến bay:";
            // 
            // txtCCCD
            // 
            txtCCCD.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCCCD.Font = new Font("Segoe UI", 9F);
            txtCCCD.Location = new Point(130, 135);
            txtCCCD.Name = "txtCCCD";
            txtCCCD.ReadOnly = true;
            txtCCCD.Size = new Size(245, 27);
            txtCCCD.TabIndex = 7;
            // 
            // lblCCCD
            // 
            lblCCCD.AutoSize = true;
            lblCCCD.Font = new Font("Segoe UI", 9F);
            lblCCCD.Location = new Point(15, 138);
            lblCCCD.Name = "lblCCCD";
            lblCCCD.Size = new Size(71, 20);
            lblCCCD.TabIndex = 6;
            lblCCCD.Text = "Số CCCD:";
            // 
            // txtSDT
            // 
            txtSDT.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSDT.Font = new Font("Segoe UI", 9F);
            txtSDT.Location = new Point(130, 100);
            txtSDT.Name = "txtSDT";
            txtSDT.ReadOnly = true;
            txtSDT.Size = new Size(245, 27);
            txtSDT.TabIndex = 5;
            // 
            // lblSDT
            // 
            lblSDT.AutoSize = true;
            lblSDT.Font = new Font("Segoe UI", 9F);
            lblSDT.Location = new Point(15, 103);
            lblSDT.Name = "lblSDT";
            lblSDT.Size = new Size(52, 20);
            lblSDT.TabIndex = 4;
            lblSDT.Text = "Số ĐT:";
            // 
            // txtKhachHang
            // 
            txtKhachHang.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtKhachHang.Font = new Font("Segoe UI", 9F);
            txtKhachHang.Location = new Point(130, 65);
            txtKhachHang.Name = "txtKhachHang";
            txtKhachHang.ReadOnly = true;
            txtKhachHang.Size = new Size(245, 27);
            txtKhachHang.TabIndex = 3;
            // 
            // lblKhachHang
            // 
            lblKhachHang.AutoSize = true;
            lblKhachHang.Font = new Font("Segoe UI", 9F);
            lblKhachHang.Location = new Point(15, 68);
            lblKhachHang.Name = "lblKhachHang";
            lblKhachHang.Size = new Size(89, 20);
            lblKhachHang.TabIndex = 2;
            lblKhachHang.Text = "Khách hàng:";
            // 
            // txtMaVe
            // 
            txtMaVe.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMaVe.Font = new Font("Segoe UI", 9F);
            txtMaVe.Location = new Point(130, 30);
            txtMaVe.Name = "txtMaVe";
            txtMaVe.ReadOnly = true;
            txtMaVe.Size = new Size(245, 27);
            txtMaVe.TabIndex = 1;
            // 
            // lblMaVe
            // 
            lblMaVe.AutoSize = true;
            lblMaVe.Font = new Font("Segoe UI", 9F);
            lblMaVe.Location = new Point(15, 33);
            lblMaVe.Name = "lblMaVe";
            lblMaVe.Size = new Size(54, 20);
            lblMaVe.TabIndex = 0;
            lblMaVe.Text = "Mã vé:";
            // 
            // tabHoaDon
            // 
            tabHoaDon.BackColor = Color.FromArgb(241, 245, 249);
            tabHoaDon.Controls.Add(grpChiTietHoaDon);
            tabHoaDon.Controls.Add(grpDanhSachHoaDon);
            tabHoaDon.Controls.Add(grpBoLocHoaDon);
            tabHoaDon.Location = new Point(4, 30);
            tabHoaDon.Name = "tabHoaDon";
            tabHoaDon.Padding = new Padding(10);
            tabHoaDon.Size = new Size(1028, 616);
            tabHoaDon.TabIndex = 1;
            tabHoaDon.Text = "🧾 Tra cứu & Quản lý hóa đơn";
            // 
            // grpChiTietHoaDon
            // 
            grpChiTietHoaDon.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            grpChiTietHoaDon.Controls.Add(btnInHoaDon);
            grpChiTietHoaDon.Controls.Add(txtChiTietHoaDon);
            grpChiTietHoaDon.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpChiTietHoaDon.Location = new Point(668, 80);
            grpChiTietHoaDon.Name = "grpChiTietHoaDon";
            grpChiTietHoaDon.Size = new Size(350, 525);
            grpChiTietHoaDon.TabIndex = 2;
            grpChiTietHoaDon.TabStop = false;
            grpChiTietHoaDon.Text = "CHI TIẾT HÓA ĐƠN";
            // 
            // btnInHoaDon
            // 
            btnInHoaDon.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnInHoaDon.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnInHoaDon.Location = new Point(12, 476);
            btnInHoaDon.Name = "btnInHoaDon";
            btnInHoaDon.Size = new Size(326, 38);
            btnInHoaDon.TabIndex = 1;
            btnInHoaDon.Text = "🖨️ Xem chi tiết / In hóa đơn";
            btnInHoaDon.UseVisualStyleBackColor = true;
            btnInHoaDon.Click += btnInHoaDon_Click;
            // 
            // txtChiTietHoaDon
            // 
            txtChiTietHoaDon.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtChiTietHoaDon.BackColor = Color.White;
            txtChiTietHoaDon.Font = new Font("Consolas", 9F);
            txtChiTietHoaDon.Location = new Point(12, 26);
            txtChiTietHoaDon.Multiline = true;
            txtChiTietHoaDon.Name = "txtChiTietHoaDon";
            txtChiTietHoaDon.ReadOnly = true;
            txtChiTietHoaDon.ScrollBars = ScrollBars.Vertical;
            txtChiTietHoaDon.Size = new Size(326, 444);
            txtChiTietHoaDon.TabIndex = 0;
            // 
            // grpDanhSachHoaDon
            // 
            grpDanhSachHoaDon.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpDanhSachHoaDon.Controls.Add(dgvHoaDon);
            grpDanhSachHoaDon.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpDanhSachHoaDon.Location = new Point(10, 80);
            grpDanhSachHoaDon.Name = "grpDanhSachHoaDon";
            grpDanhSachHoaDon.Size = new Size(650, 525);
            grpDanhSachHoaDon.TabIndex = 1;
            grpDanhSachHoaDon.TabStop = false;
            grpDanhSachHoaDon.Text = "DANH SÁCH HÓA ĐƠN ĐÃ LẬP";
            // 
            // dgvHoaDon
            // 
            dgvHoaDon.AllowUserToAddRows = false;
            dgvHoaDon.AllowUserToDeleteRows = false;
            dgvHoaDon.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvHoaDon.BackgroundColor = Color.White;
            dgvHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoaDon.Font = new Font("Segoe UI", 9F);
            dgvHoaDon.Location = new Point(10, 26);
            dgvHoaDon.MultiSelect = false;
            dgvHoaDon.Name = "dgvHoaDon";
            dgvHoaDon.ReadOnly = true;
            dgvHoaDon.RowHeadersVisible = false;
            dgvHoaDon.RowHeadersWidth = 51;
            dgvHoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHoaDon.Size = new Size(630, 488);
            dgvHoaDon.TabIndex = 0;
            dgvHoaDon.CellClick += dgvHoaDon_CellClick;
            // 
            // grpBoLocHoaDon
            // 
            grpBoLocHoaDon.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpBoLocHoaDon.Controls.Add(btnLamMoiHoaDon);
            grpBoLocHoaDon.Controls.Add(btnTraCuuHoaDon);
            grpBoLocHoaDon.Controls.Add(dtpDenNgay);
            grpBoLocHoaDon.Controls.Add(lblDenNgay);
            grpBoLocHoaDon.Controls.Add(dtpTuNgay);
            grpBoLocHoaDon.Controls.Add(chkLocTheoNgay);
            grpBoLocHoaDon.Controls.Add(txtTimHoaDon);
            grpBoLocHoaDon.Controls.Add(lblTimHoaDon);
            grpBoLocHoaDon.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpBoLocHoaDon.Location = new Point(10, 10);
            grpBoLocHoaDon.Name = "grpBoLocHoaDon";
            grpBoLocHoaDon.Size = new Size(1008, 65);
            grpBoLocHoaDon.TabIndex = 0;
            grpBoLocHoaDon.TabStop = false;
            grpBoLocHoaDon.Text = "BỘ LỌC VÀ TÌM KIẾM";
            // 
            // btnLamMoiHoaDon
            // 
            btnLamMoiHoaDon.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLamMoiHoaDon.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLamMoiHoaDon.Location = new Point(885, 23);
            btnLamMoiHoaDon.Name = "btnLamMoiHoaDon";
            btnLamMoiHoaDon.Size = new Size(110, 32);
            btnLamMoiHoaDon.TabIndex = 7;
            btnLamMoiHoaDon.Text = "🔄 Làm mới";
            btnLamMoiHoaDon.UseVisualStyleBackColor = true;
            btnLamMoiHoaDon.Click += btnLamMoiHoaDon_Click;
            // 
            // btnTraCuuHoaDon
            // 
            btnTraCuuHoaDon.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTraCuuHoaDon.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnTraCuuHoaDon.Location = new Point(765, 23);
            btnTraCuuHoaDon.Name = "btnTraCuuHoaDon";
            btnTraCuuHoaDon.Size = new Size(110, 32);
            btnTraCuuHoaDon.TabIndex = 6;
            btnTraCuuHoaDon.Text = "🔍 Tra cứu";
            btnTraCuuHoaDon.UseVisualStyleBackColor = true;
            btnTraCuuHoaDon.Click += btnTraCuuHoaDon_Click;
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            dtpDenNgay.Enabled = false;
            dtpDenNgay.Font = new Font("Segoe UI", 9F);
            dtpDenNgay.Format = DateTimePickerFormat.Custom;
            dtpDenNgay.Location = new Point(610, 25);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(130, 27);
            dtpDenNgay.TabIndex = 5;
            // 
            // lblDenNgay
            // 
            lblDenNgay.AutoSize = true;
            lblDenNgay.Font = new Font("Segoe UI", 9F);
            lblDenNgay.Location = new Point(570, 28);
            lblDenNgay.Name = "lblDenNgay";
            lblDenNgay.Size = new Size(34, 20);
            lblDenNgay.TabIndex = 4;
            lblDenNgay.Text = "đến";
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            dtpTuNgay.Enabled = false;
            dtpTuNgay.Font = new Font("Segoe UI", 9F);
            dtpTuNgay.Format = DateTimePickerFormat.Custom;
            dtpTuNgay.Location = new Point(430, 25);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(130, 27);
            dtpTuNgay.TabIndex = 3;
            // 
            // chkLocTheoNgay
            // 
            chkLocTheoNgay.AutoSize = true;
            chkLocTheoNgay.Font = new Font("Segoe UI", 9F);
            chkLocTheoNgay.Location = new Point(295, 27);
            chkLocTheoNgay.Name = "chkLocTheoNgay";
            chkLocTheoNgay.Size = new Size(127, 24);
            chkLocTheoNgay.TabIndex = 2;
            chkLocTheoNgay.Text = "Lọc theo ngày:";
            chkLocTheoNgay.UseVisualStyleBackColor = true;
            chkLocTheoNgay.CheckedChanged += chkLocTheoNgay_CheckedChanged;
            // 
            // txtTimHoaDon
            // 
            txtTimHoaDon.Font = new Font("Segoe UI", 9F);
            txtTimHoaDon.Location = new Point(80, 25);
            txtTimHoaDon.Name = "txtTimHoaDon";
            txtTimHoaDon.PlaceholderText = "Mã HĐ, Mã vé, Tên KH, SĐT...";
            txtTimHoaDon.Size = new Size(195, 27);
            txtTimHoaDon.TabIndex = 1;
            // 
            // lblTimHoaDon
            // 
            lblTimHoaDon.AutoSize = true;
            lblTimHoaDon.Font = new Font("Segoe UI", 9F);
            lblTimHoaDon.Location = new Point(12, 28);
            lblTimHoaDon.Name = "lblTimHoaDon";
            lblTimHoaDon.Size = new Size(65, 20);
            lblTimHoaDon.TabIndex = 0;
            lblTimHoaDon.Text = "Từ khóa:";
            // 
            // frmThanhToan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1060, 720);
            Controls.Add(tabMain);
            Controls.Add(lblTieuDe);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(980, 660);
            Name = "frmThanhToan";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "QUẢN LÝ THANH TOÁN VÀ HÓA ĐƠN";
            Load += frmThanhToan_Load;
            tabMain.ResumeLayout(false);
            tabThanhToan.ResumeLayout(false);
            grpDanhSachVe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvVe).EndInit();
            pnlLocVe.ResumeLayout(false);
            pnlLocVe.PerformLayout();
            grpThongTinChiTiet.ResumeLayout(false);
            grpThongTinChiTiet.PerformLayout();
            tabHoaDon.ResumeLayout(false);
            grpChiTietHoaDon.ResumeLayout(false);
            grpChiTietHoaDon.PerformLayout();
            grpDanhSachHoaDon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).EndInit();
            grpBoLocHoaDon.ResumeLayout(false);
            grpBoLocHoaDon.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTieuDe;
        private TabControl tabMain;
        private TabPage tabThanhToan;
        private TabPage tabHoaDon;
        private GroupBox grpDanhSachVe;
        private Panel pnlLocVe;
        private Label lblTimVe;
        private TextBox txtTimVe;
        private Label lblLocTrangThai;
        private ComboBox cboLocTrangThai;
        private Button btnLamMoiVe;
        private DataGridView dgvVe;
        private GroupBox grpThongTinChiTiet;
        private Label lblMaVe;
        private TextBox txtMaVe;
        private Label lblKhachHang;
        private TextBox txtKhachHang;
        private Label lblSDT;
        private TextBox txtSDT;
        private Label lblCCCD;
        private TextBox txtCCCD;
        private Label lblChuyenBay;
        private TextBox txtChuyenBay;
        private Label lblTuyenBay;
        private TextBox txtTuyenBay;
        private Label lblGhe;
        private TextBox txtGhe;
        private Label lblThoiGianDi;
        private TextBox txtThoiGianDi;
        private Label lblSoTien;
        private TextBox txtSoTien;
        private Label lblPhuongThuc;
        private ComboBox cboPhuongThuc;
        private CheckBox chkLapHoaDonNgay;
        private Button btnXacNhanThanhToan;
        private Button btnLapHoaDon;
        private Button btnLamMoi;
        private GroupBox grpBoLocHoaDon;
        private Label lblTimHoaDon;
        private TextBox txtTimHoaDon;
        private CheckBox chkLocTheoNgay;
        private DateTimePicker dtpTuNgay;
        private Label lblDenNgay;
        private DateTimePicker dtpDenNgay;
        private Button btnTraCuuHoaDon;
        private Button btnLamMoiHoaDon;
        private GroupBox grpDanhSachHoaDon;
        private DataGridView dgvHoaDon;
        private GroupBox grpChiTietHoaDon;
        private TextBox txtChiTietHoaDon;
        private Button btnInHoaDon;
    }
}
