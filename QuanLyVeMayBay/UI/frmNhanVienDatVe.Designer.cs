namespace QuanLyVeMayBay
{
    partial class frmNhanVienDatVe
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
            pnlMainContainer = new Panel();
            tabCtrlDatVe = new TabControl();
            tabDatVe = new TabPage();
            pnlRight = new Panel();
            grpKhachHang = new GroupBox();
            btnDatVe = new Button();
            btnLamMoiNhap = new Button();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtSDT = new TextBox();
            lblSDT = new Label();
            txtCCCD = new TextBox();
            lblCCCD = new Label();
            txtHoTen = new TextBox();
            lblHoTen = new Label();
            grpGhe = new GroupBox();
            lblSoLuongGheTrong = new Label();
            lblGiaVeHienThi = new Label();
            lblGiaVeTitle = new Label();
            cboHangGhe = new ComboBox();
            lblHangGhe = new Label();
            cboGhe = new ComboBox();
            lblChonGhe = new Label();
            grpChuyenBayChon = new GroupBox();
            lblChiTietChuyenBay = new Label();
            pnlLeft = new Panel();
            grpDanhSach = new GroupBox();
            dgvChuyenBay = new DataGridView();
            grpTimKiem = new GroupBox();
            btnXemTatCa = new Button();
            btnTimKiem = new Button();
            dtpNgayDi = new DateTimePicker();
            lblNgayDi = new Label();
            cboSanBayDen = new ComboBox();
            lblSanBayDen = new Label();
            cboSanBayDi = new ComboBox();
            lblSanBayDi = new Label();
            tabXacNhan = new TabPage();
            pnlXacNhanContent = new Panel();
            grpDanhSachVeVuaDat = new GroupBox();
            dgvVeChoXacNhan = new DataGridView();
            pnlXacNhanActions = new Panel();
            lblGhiChuXacNhan = new Label();
            btnInPhieuDatCho = new Button();
            btnKiemTraXacNhanKeToan = new Button();
            btnLamMoiDanhSachVe = new Button();
            pnlMainContainer.SuspendLayout();
            tabCtrlDatVe.SuspendLayout();
            tabDatVe.SuspendLayout();
            pnlRight.SuspendLayout();
            grpKhachHang.SuspendLayout();
            grpGhe.SuspendLayout();
            grpChuyenBayChon.SuspendLayout();
            pnlLeft.SuspendLayout();
            grpDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChuyenBay).BeginInit();
            grpTimKiem.SuspendLayout();
            tabXacNhan.SuspendLayout();
            pnlXacNhanContent.SuspendLayout();
            grpDanhSachVeVuaDat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVeChoXacNhan).BeginInit();
            pnlXacNhanActions.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMainContainer
            // 
            pnlMainContainer.Controls.Add(tabCtrlDatVe);
            pnlMainContainer.Dock = DockStyle.Fill;
            pnlMainContainer.Location = new Point(0, 65);
            pnlMainContainer.Name = "pnlMainContainer";
            pnlMainContainer.Padding = new Padding(12);
            pnlMainContainer.Size = new Size(1160, 655);
            pnlMainContainer.TabIndex = 0;
            // 
            // tabCtrlDatVe
            // 
            tabCtrlDatVe.Controls.Add(tabDatVe);
            tabCtrlDatVe.Controls.Add(tabXacNhan);
            tabCtrlDatVe.Dock = DockStyle.Fill;
            tabCtrlDatVe.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            tabCtrlDatVe.Location = new Point(12, 12);
            tabCtrlDatVe.Name = "tabCtrlDatVe";
            tabCtrlDatVe.SelectedIndex = 0;
            tabCtrlDatVe.Size = new Size(1136, 631);
            tabCtrlDatVe.TabIndex = 0;
            // 
            // tabDatVe
            // 
            tabDatVe.BackColor = Color.FromArgb(241, 245, 249);
            tabDatVe.Controls.Add(pnlRight);
            tabDatVe.Controls.Add(pnlLeft);
            tabDatVe.Location = new Point(4, 26);
            tabDatVe.Name = "tabDatVe";
            tabDatVe.Padding = new Padding(10);
            tabDatVe.Size = new Size(1128, 601);
            tabDatVe.TabIndex = 0;
            tabDatVe.Text = "✈️ Nghiệp vụ Tra cứu & Đặt vé";
            // 
            // pnlRight
            // 
            pnlRight.Controls.Add(grpKhachHang);
            pnlRight.Controls.Add(grpGhe);
            pnlRight.Controls.Add(grpChuyenBayChon);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(620, 10);
            pnlRight.Name = "pnlRight";
            pnlRight.Padding = new Padding(10, 0, 0, 0);
            pnlRight.Size = new Size(498, 581);
            pnlRight.TabIndex = 1;
            // 
            // grpKhachHang
            // 
            grpKhachHang.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpKhachHang.BackColor = Color.White;
            grpKhachHang.Controls.Add(btnDatVe);
            grpKhachHang.Controls.Add(btnLamMoiNhap);
            grpKhachHang.Controls.Add(txtEmail);
            grpKhachHang.Controls.Add(lblEmail);
            grpKhachHang.Controls.Add(txtSDT);
            grpKhachHang.Controls.Add(lblSDT);
            grpKhachHang.Controls.Add(txtCCCD);
            grpKhachHang.Controls.Add(lblCCCD);
            grpKhachHang.Controls.Add(txtHoTen);
            grpKhachHang.Controls.Add(lblHoTen);
            grpKhachHang.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpKhachHang.Location = new Point(10, 290);
            grpKhachHang.Name = "grpKhachHang";
            grpKhachHang.Size = new Size(488, 280);
            grpKhachHang.TabIndex = 2;
            grpKhachHang.TabStop = false;
            grpKhachHang.Text = "👤 Thông tin Hành khách";
            // 
            // btnDatVe
            // 
            btnDatVe.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDatVe.Cursor = Cursors.Hand;
            btnDatVe.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDatVe.Location = new Point(278, 215);
            btnDatVe.Name = "btnDatVe";
            btnDatVe.Size = new Size(195, 45);
            btnDatVe.TabIndex = 9;
            btnDatVe.Text = "🎫 XÁC NHẬN ĐẶT VÉ";
            btnDatVe.UseVisualStyleBackColor = true;
            btnDatVe.Click += btnDatVe_Click;
            // 
            // btnLamMoiNhap
            // 
            btnLamMoiNhap.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLamMoiNhap.Cursor = Cursors.Hand;
            btnLamMoiNhap.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnLamMoiNhap.Location = new Point(148, 215);
            btnLamMoiNhap.Name = "btnLamMoiNhap";
            btnLamMoiNhap.Size = new Size(120, 45);
            btnLamMoiNhap.TabIndex = 8;
            btnLamMoiNhap.Text = "🔄 Làm mới";
            btnLamMoiNhap.UseVisualStyleBackColor = true;
            btnLamMoiNhap.Click += btnLamMoiNhap_Click;
            // 
            // txtEmail
            // 
            txtEmail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtEmail.Font = new Font("Segoe UI", 9.5F);
            txtEmail.Location = new Point(148, 160);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(325, 24);
            txtEmail.TabIndex = 7;
            // 
            // lblEmail
            // 
            lblEmail.Font = new Font("Segoe UI", 9F);
            lblEmail.Location = new Point(15, 160);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(125, 24);
            lblEmail.TabIndex = 6;
            lblEmail.Text = "Email liên hệ:";
            lblEmail.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtSDT
            // 
            txtSDT.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSDT.Font = new Font("Segoe UI", 9.5F);
            txtSDT.Location = new Point(148, 118);
            txtSDT.MaxLength = 10;
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(325, 24);
            txtSDT.TabIndex = 5;
            // 
            // lblSDT
            // 
            lblSDT.Font = new Font("Segoe UI", 9F);
            lblSDT.Location = new Point(15, 118);
            lblSDT.Name = "lblSDT";
            lblSDT.Size = new Size(125, 24);
            lblSDT.TabIndex = 4;
            lblSDT.Text = "Số điện thoại (*):";
            lblSDT.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtCCCD
            // 
            txtCCCD.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCCCD.Font = new Font("Segoe UI", 9.5F);
            txtCCCD.Location = new Point(148, 75);
            txtCCCD.MaxLength = 12;
            txtCCCD.Name = "txtCCCD";
            txtCCCD.Size = new Size(325, 24);
            txtCCCD.TabIndex = 3;
            // 
            // lblCCCD
            // 
            lblCCCD.Font = new Font("Segoe UI", 9F);
            lblCCCD.Location = new Point(15, 75);
            lblCCCD.Name = "lblCCCD";
            lblCCCD.Size = new Size(125, 24);
            lblCCCD.TabIndex = 2;
            lblCCCD.Text = "Số CCCD/CMND (*):";
            lblCCCD.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtHoTen
            // 
            txtHoTen.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtHoTen.Font = new Font("Segoe UI", 9.5F);
            txtHoTen.Location = new Point(148, 33);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(325, 24);
            txtHoTen.TabIndex = 1;
            // 
            // lblHoTen
            // 
            lblHoTen.Font = new Font("Segoe UI", 9F);
            lblHoTen.Location = new Point(15, 33);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(125, 24);
            lblHoTen.TabIndex = 0;
            lblHoTen.Text = "Họ tên hành khách (*):";
            lblHoTen.TextAlign = ContentAlignment.MiddleRight;
            // 
            // grpGhe
            // 
            grpGhe.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpGhe.BackColor = Color.White;
            grpGhe.Controls.Add(lblSoLuongGheTrong);
            grpGhe.Controls.Add(lblGiaVeHienThi);
            grpGhe.Controls.Add(lblGiaVeTitle);
            grpGhe.Controls.Add(cboHangGhe);
            grpGhe.Controls.Add(lblHangGhe);
            grpGhe.Controls.Add(cboGhe);
            grpGhe.Controls.Add(lblChonGhe);
            grpGhe.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpGhe.Location = new Point(10, 125);
            grpGhe.Name = "grpGhe";
            grpGhe.Size = new Size(488, 155);
            grpGhe.TabIndex = 1;
            grpGhe.TabStop = false;
            grpGhe.Text = "💺 Kiểm tra & Chọn ghế trống";
            // 
            // lblSoLuongGheTrong
            // 
            lblSoLuongGheTrong.AutoSize = true;
            lblSoLuongGheTrong.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblSoLuongGheTrong.ForeColor = Color.FromArgb(2, 132, 199);
            lblSoLuongGheTrong.Location = new Point(148, 70);
            lblSoLuongGheTrong.Name = "lblSoLuongGheTrong";
            lblSoLuongGheTrong.Size = new Size(175, 15);
            lblSoLuongGheTrong.TabIndex = 6;
            lblSoLuongGheTrong.Text = "● Đang chờ chọn chuyến bay...";
            // 
            // lblGiaVeHienThi
            // 
            lblGiaVeHienThi.AutoSize = true;
            lblGiaVeHienThi.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblGiaVeHienThi.ForeColor = Color.FromArgb(16, 185, 129);
            lblGiaVeHienThi.Location = new Point(148, 105);
            lblGiaVeHienThi.Name = "lblGiaVeHienThi";
            lblGiaVeHienThi.Size = new Size(67, 25);
            lblGiaVeHienThi.TabIndex = 5;
            lblGiaVeHienThi.Text = "0 VNĐ";
            // 
            // lblGiaVeTitle
            // 
            lblGiaVeTitle.Font = new Font("Segoe UI", 9F);
            lblGiaVeTitle.Location = new Point(15, 108);
            lblGiaVeTitle.Name = "lblGiaVeTitle";
            lblGiaVeTitle.Size = new Size(125, 22);
            lblGiaVeTitle.TabIndex = 4;
            lblGiaVeTitle.Text = "Giá vé áp dụng:";
            lblGiaVeTitle.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cboHangGhe
            // 
            cboHangGhe.DropDownStyle = ComboBoxStyle.DropDownList;
            cboHangGhe.Font = new Font("Segoe UI", 9.5F);
            cboHangGhe.FormattingEnabled = true;
            cboHangGhe.Location = new Point(148, 30);
            cboHangGhe.Name = "cboHangGhe";
            cboHangGhe.Size = new Size(140, 24);
            cboHangGhe.TabIndex = 3;
            cboHangGhe.SelectedIndexChanged += cboHangGhe_SelectedIndexChanged;
            // 
            // lblHangGhe
            // 
            lblHangGhe.Font = new Font("Segoe UI", 9F);
            lblHangGhe.Location = new Point(15, 30);
            lblHangGhe.Name = "lblHangGhe";
            lblHangGhe.Size = new Size(125, 24);
            lblHangGhe.TabIndex = 2;
            lblHangGhe.Text = "Lọc hạng ghế:";
            lblHangGhe.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cboGhe
            // 
            cboGhe.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboGhe.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGhe.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            cboGhe.FormattingEnabled = true;
            cboGhe.Location = new Point(315, 30);
            cboGhe.Name = "cboGhe";
            cboGhe.Size = new Size(158, 25);
            cboGhe.TabIndex = 1;
            cboGhe.SelectedIndexChanged += cboGhe_SelectedIndexChanged;
            // 
            // lblChonGhe
            // 
            lblChonGhe.AutoSize = true;
            lblChonGhe.Font = new Font("Segoe UI", 9F);
            lblChonGhe.Location = new Point(292, 34);
            lblChonGhe.Name = "lblChonGhe";
            lblChonGhe.Size = new Size(20, 15);
            lblChonGhe.TabIndex = 0;
            lblChonGhe.Text = "->";
            // 
            // grpChuyenBayChon
            // 
            grpChuyenBayChon.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpChuyenBayChon.BackColor = Color.FromArgb(239, 246, 255);
            grpChuyenBayChon.Controls.Add(lblChiTietChuyenBay);
            grpChuyenBayChon.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpChuyenBayChon.ForeColor = Color.FromArgb(30, 58, 138);
            grpChuyenBayChon.Location = new Point(10, 5);
            grpChuyenBayChon.Name = "grpChuyenBayChon";
            grpChuyenBayChon.Size = new Size(488, 110);
            grpChuyenBayChon.TabIndex = 0;
            grpChuyenBayChon.TabStop = false;
            grpChuyenBayChon.Text = "ℹ️ Chuyến bay đang chọn";
            // 
            // lblChiTietChuyenBay
            // 
            lblChiTietChuyenBay.Dock = DockStyle.Fill;
            lblChiTietChuyenBay.Font = new Font("Segoe UI", 9F);
            lblChiTietChuyenBay.ForeColor = Color.FromArgb(15, 23, 42);
            lblChiTietChuyenBay.Location = new Point(3, 20);
            lblChiTietChuyenBay.Name = "lblChiTietChuyenBay";
            lblChiTietChuyenBay.Padding = new Padding(8);
            lblChiTietChuyenBay.Size = new Size(482, 87);
            lblChiTietChuyenBay.TabIndex = 0;
            lblChiTietChuyenBay.Text = "Vui lòng chọn 1 chuyến bay trong danh sách bên trái để tiếp tục.";
            // 
            // pnlLeft
            // 
            pnlLeft.Controls.Add(grpDanhSach);
            pnlLeft.Controls.Add(grpTimKiem);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(10, 10);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(610, 581);
            pnlLeft.TabIndex = 0;
            // 
            // grpDanhSach
            // 
            grpDanhSach.BackColor = Color.White;
            grpDanhSach.Controls.Add(dgvChuyenBay);
            grpDanhSach.Dock = DockStyle.Fill;
            grpDanhSach.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpDanhSach.Location = new Point(0, 120);
            grpDanhSach.Name = "grpDanhSach";
            grpDanhSach.Padding = new Padding(8);
            grpDanhSach.Size = new Size(610, 461);
            grpDanhSach.TabIndex = 1;
            grpDanhSach.TabStop = false;
            grpDanhSach.Text = "📋 Danh sách Chuyến bay phù hợp";
            // 
            // dgvChuyenBay
            // 
            dgvChuyenBay.AllowUserToAddRows = false;
            dgvChuyenBay.AllowUserToDeleteRows = false;
            dgvChuyenBay.BackgroundColor = Color.White;
            dgvChuyenBay.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChuyenBay.Dock = DockStyle.Fill;
            dgvChuyenBay.Location = new Point(8, 25);
            dgvChuyenBay.Name = "dgvChuyenBay";
            dgvChuyenBay.ReadOnly = true;
            dgvChuyenBay.RowTemplate.Height = 36;
            dgvChuyenBay.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChuyenBay.Size = new Size(594, 428);
            dgvChuyenBay.TabIndex = 0;
            dgvChuyenBay.CellClick += dgvChuyenBay_CellClick;
            // 
            // grpTimKiem
            // 
            grpTimKiem.BackColor = Color.White;
            grpTimKiem.Controls.Add(btnXemTatCa);
            grpTimKiem.Controls.Add(btnTimKiem);
            grpTimKiem.Controls.Add(dtpNgayDi);
            grpTimKiem.Controls.Add(lblNgayDi);
            grpTimKiem.Controls.Add(cboSanBayDen);
            grpTimKiem.Controls.Add(lblSanBayDen);
            grpTimKiem.Controls.Add(cboSanBayDi);
            grpTimKiem.Controls.Add(lblSanBayDi);
            grpTimKiem.Dock = DockStyle.Top;
            grpTimKiem.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpTimKiem.Location = new Point(0, 0);
            grpTimKiem.Name = "grpTimKiem";
            grpTimKiem.Size = new Size(610, 120);
            grpTimKiem.TabIndex = 0;
            grpTimKiem.TabStop = false;
            grpTimKiem.Text = "🔍 Tìm kiếm Chuyến bay";
            // 
            // btnXemTatCa
            // 
            btnXemTatCa.Cursor = Cursors.Hand;
            btnXemTatCa.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnXemTatCa.Location = new Point(480, 68);
            btnXemTatCa.Name = "btnXemTatCa";
            btnXemTatCa.Size = new Size(115, 34);
            btnXemTatCa.TabIndex = 7;
            btnXemTatCa.Text = "Hiện tất cả";
            btnXemTatCa.UseVisualStyleBackColor = true;
            btnXemTatCa.Click += btnXemTatCa_Click;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Cursor = Cursors.Hand;
            btnTimKiem.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnTimKiem.Location = new Point(480, 24);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(115, 36);
            btnTimKiem.TabIndex = 6;
            btnTimKiem.Text = "🔎 Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // dtpNgayDi
            // 
            dtpNgayDi.CustomFormat = "dd/MM/yyyy";
            dtpNgayDi.Font = new Font("Segoe UI", 9.5F);
            dtpNgayDi.Format = DateTimePickerFormat.Custom;
            dtpNgayDi.Location = new Point(105, 73);
            dtpNgayDi.Name = "dtpNgayDi";
            dtpNgayDi.Size = new Size(160, 24);
            dtpNgayDi.TabIndex = 5;
            // 
            // lblNgayDi
            // 
            lblNgayDi.Font = new Font("Segoe UI", 9F);
            lblNgayDi.Location = new Point(10, 73);
            lblNgayDi.Name = "lblNgayDi";
            lblNgayDi.Size = new Size(90, 24);
            lblNgayDi.TabIndex = 4;
            lblNgayDi.Text = "Ngày đi:";
            lblNgayDi.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cboSanBayDen
            // 
            cboSanBayDen.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSanBayDen.Font = new Font("Segoe UI", 9F);
            cboSanBayDen.FormattingEnabled = true;
            cboSanBayDen.Location = new Point(310, 30);
            cboSanBayDen.Name = "cboSanBayDen";
            cboSanBayDen.Size = new Size(155, 23);
            cboSanBayDen.TabIndex = 3;
            // 
            // lblSanBayDen
            // 
            lblSanBayDen.Font = new Font("Segoe UI", 9F);
            lblSanBayDen.Location = new Point(245, 30);
            lblSanBayDen.Name = "lblSanBayDen";
            lblSanBayDen.Size = new Size(60, 23);
            lblSanBayDen.TabIndex = 2;
            lblSanBayDen.Text = "Đến:";
            lblSanBayDen.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cboSanBayDi
            // 
            cboSanBayDi.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSanBayDi.Font = new Font("Segoe UI", 9F);
            cboSanBayDi.FormattingEnabled = true;
            cboSanBayDi.Location = new Point(105, 30);
            cboSanBayDi.Name = "cboSanBayDi";
            cboSanBayDi.Size = new Size(140, 23);
            cboSanBayDi.TabIndex = 1;
            // 
            // lblSanBayDi
            // 
            lblSanBayDi.Font = new Font("Segoe UI", 9F);
            lblSanBayDi.Location = new Point(10, 30);
            lblSanBayDi.Name = "lblSanBayDi";
            lblSanBayDi.Size = new Size(90, 23);
            lblSanBayDi.TabIndex = 0;
            lblSanBayDi.Text = "Sân bay đi:";
            lblSanBayDi.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tabXacNhan
            // 
            tabXacNhan.BackColor = Color.FromArgb(241, 245, 249);
            tabXacNhan.Controls.Add(pnlXacNhanContent);
            tabXacNhan.Location = new Point(4, 26);
            tabXacNhan.Name = "tabXacNhan";
            tabXacNhan.Padding = new Padding(10);
            tabXacNhan.Size = new Size(1128, 601);
            tabXacNhan.TabIndex = 1;
            tabXacNhan.Text = "📋 Xác nhận Đặt vé & Chờ Kế toán";
            // 
            // pnlXacNhanContent
            // 
            pnlXacNhanContent.Controls.Add(grpDanhSachVeVuaDat);
            pnlXacNhanContent.Controls.Add(pnlXacNhanActions);
            pnlXacNhanContent.Dock = DockStyle.Fill;
            pnlXacNhanContent.Location = new Point(10, 10);
            pnlXacNhanContent.Name = "pnlXacNhanContent";
            pnlXacNhanContent.Size = new Size(1108, 581);
            pnlXacNhanContent.TabIndex = 0;
            // 
            // grpDanhSachVeVuaDat
            // 
            grpDanhSachVeVuaDat.BackColor = Color.White;
            grpDanhSachVeVuaDat.Controls.Add(dgvVeChoXacNhan);
            grpDanhSachVeVuaDat.Dock = DockStyle.Fill;
            grpDanhSachVeVuaDat.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpDanhSachVeVuaDat.Location = new Point(0, 0);
            grpDanhSachVeVuaDat.Name = "grpDanhSachVeVuaDat";
            grpDanhSachVeVuaDat.Padding = new Padding(8);
            grpDanhSachVeVuaDat.Size = new Size(1108, 516);
            grpDanhSachVeVuaDat.TabIndex = 0;
            grpDanhSachVeVuaDat.TabStop = false;
            grpDanhSachVeVuaDat.Text = "📋 Danh sách Vé vừa đặt (Theo dõi trạng thái xác nhận từ Kế toán)";
            // 
            // dgvVeChoXacNhan
            // 
            dgvVeChoXacNhan.AllowUserToAddRows = false;
            dgvVeChoXacNhan.AllowUserToDeleteRows = false;
            dgvVeChoXacNhan.BackgroundColor = Color.White;
            dgvVeChoXacNhan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVeChoXacNhan.Dock = DockStyle.Fill;
            dgvVeChoXacNhan.Location = new Point(8, 25);
            dgvVeChoXacNhan.Name = "dgvVeChoXacNhan";
            dgvVeChoXacNhan.ReadOnly = true;
            dgvVeChoXacNhan.RowTemplate.Height = 36;
            dgvVeChoXacNhan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVeChoXacNhan.Size = new Size(1092, 483);
            dgvVeChoXacNhan.TabIndex = 0;
            // 
            // pnlXacNhanActions
            // 
            pnlXacNhanActions.BackColor = Color.White;
            pnlXacNhanActions.Controls.Add(lblGhiChuXacNhan);
            pnlXacNhanActions.Controls.Add(btnInPhieuDatCho);
            pnlXacNhanActions.Controls.Add(btnKiemTraXacNhanKeToan);
            pnlXacNhanActions.Controls.Add(btnLamMoiDanhSachVe);
            pnlXacNhanActions.Dock = DockStyle.Bottom;
            pnlXacNhanActions.Location = new Point(0, 516);
            pnlXacNhanActions.Name = "pnlXacNhanActions";
            pnlXacNhanActions.Size = new Size(1108, 65);
            pnlXacNhanActions.TabIndex = 1;
            // 
            // lblGhiChuXacNhan
            // 
            lblGhiChuXacNhan.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblGhiChuXacNhan.ForeColor = Color.FromArgb(71, 85, 105);
            lblGhiChuXacNhan.Location = new Point(15, 15);
            lblGhiChuXacNhan.Name = "lblGhiChuXacNhan";
            lblGhiChuXacNhan.Size = new Size(460, 36);
            lblGhiChuXacNhan.TabIndex = 3;
            lblGhiChuXacNhan.Text = "💡 Lưu ý: Khi tạo vé, trạng thái là \"Chờ thanh toán\". Khi Bộ phận Kế toán xác nhận thu tiền, trạng thái sẽ tự động đổi sang \"Đã thanh toán\".";
            // 
            // btnInPhieuDatCho
            // 
            btnInPhieuDatCho.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnInPhieuDatCho.Cursor = Cursors.Hand;
            btnInPhieuDatCho.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnInPhieuDatCho.Location = new Point(888, 12);
            btnInPhieuDatCho.Name = "btnInPhieuDatCho";
            btnInPhieuDatCho.Size = new Size(205, 42);
            btnInPhieuDatCho.TabIndex = 2;
            btnInPhieuDatCho.Text = "🖨️ In Phiếu giữ chỗ / Đặt vé";
            btnInPhieuDatCho.UseVisualStyleBackColor = true;
            btnInPhieuDatCho.Click += btnInPhieuDatCho_Click;
            // 
            // btnKiemTraXacNhanKeToan
            // 
            btnKiemTraXacNhanKeToan.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnKiemTraXacNhanKeToan.Cursor = Cursors.Hand;
            btnKiemTraXacNhanKeToan.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnKiemTraXacNhanKeToan.Location = new Point(650, 12);
            btnKiemTraXacNhanKeToan.Name = "btnKiemTraXacNhanKeToan";
            btnKiemTraXacNhanKeToan.Size = new Size(230, 42);
            btnKiemTraXacNhanKeToan.TabIndex = 1;
            btnKiemTraXacNhanKeToan.Text = "🔍 Kiểm tra tiến độ xác nhận Kế toán";
            btnKiemTraXacNhanKeToan.UseVisualStyleBackColor = true;
            btnKiemTraXacNhanKeToan.Click += btnKiemTraXacNhanKeToan_Click;
            // 
            // btnLamMoiDanhSachVe
            // 
            btnLamMoiDanhSachVe.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLamMoiDanhSachVe.Cursor = Cursors.Hand;
            btnLamMoiDanhSachVe.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnLamMoiDanhSachVe.Location = new Point(495, 12);
            btnLamMoiDanhSachVe.Name = "btnLamMoiDanhSachVe";
            btnLamMoiDanhSachVe.Size = new Size(145, 42);
            btnLamMoiDanhSachVe.TabIndex = 0;
            btnLamMoiDanhSachVe.Text = "🔄 Làm mới";
            btnLamMoiDanhSachVe.UseVisualStyleBackColor = true;
            btnLamMoiDanhSachVe.Click += btnLamMoiDanhSachVe_Click;
            // 
            // frmNhanVienDatVe
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1160, 720);
            Controls.Add(pnlMainContainer);
            MinimumSize = new Size(1100, 700);
            Name = "frmNhanVienDatVe";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bộ phận Đặt vé - Hệ thống Bán vé Máy bay";
            Load += frmNhanVienDatVe_Load;
            pnlMainContainer.ResumeLayout(false);
            tabCtrlDatVe.ResumeLayout(false);
            tabDatVe.ResumeLayout(false);
            pnlRight.ResumeLayout(false);
            grpKhachHang.ResumeLayout(false);
            grpKhachHang.PerformLayout();
            grpGhe.ResumeLayout(false);
            grpGhe.PerformLayout();
            grpChuyenBayChon.ResumeLayout(false);
            pnlLeft.ResumeLayout(false);
            grpDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvChuyenBay).EndInit();
            grpTimKiem.ResumeLayout(false);
            tabXacNhan.ResumeLayout(false);
            pnlXacNhanContent.ResumeLayout(false);
            grpDanhSachVeVuaDat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvVeChoXacNhan).EndInit();
            pnlXacNhanActions.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMainContainer;
        private TabControl tabCtrlDatVe;
        private TabPage tabDatVe;
        private Panel pnlLeft;
        private GroupBox grpTimKiem;
        private ComboBox cboSanBayDi;
        private Label lblSanBayDi;
        private ComboBox cboSanBayDen;
        private Label lblSanBayDen;
        private DateTimePicker dtpNgayDi;
        private Label lblNgayDi;
        private Button btnTimKiem;
        private Button btnXemTatCa;
        private GroupBox grpDanhSach;
        private DataGridView dgvChuyenBay;
        private Panel pnlRight;
        private GroupBox grpChuyenBayChon;
        private Label lblChiTietChuyenBay;
        private GroupBox grpGhe;
        private Label lblHangGhe;
        private ComboBox cboHangGhe;
        private Label lblChonGhe;
        private ComboBox cboGhe;
        private Label lblGiaVeTitle;
        private Label lblGiaVeHienThi;
        private Label lblSoLuongGheTrong;
        private GroupBox grpKhachHang;
        private Label lblHoTen;
        private TextBox txtHoTen;
        private Label lblCCCD;
        private TextBox txtCCCD;
        private Label lblSDT;
        private TextBox txtSDT;
        private Label lblEmail;
        private TextBox txtEmail;
        private Button btnDatVe;
        private Button btnLamMoiNhap;
        private TabPage tabXacNhan;
        private Panel pnlXacNhanContent;
        private GroupBox grpDanhSachVeVuaDat;
        private DataGridView dgvVeChoXacNhan;
        private Panel pnlXacNhanActions;
        private Button btnLamMoiDanhSachVe;
        private Button btnKiemTraXacNhanKeToan;
        private Button btnInPhieuDatCho;
        private Label lblGhiChuXacNhan;
    }
}
