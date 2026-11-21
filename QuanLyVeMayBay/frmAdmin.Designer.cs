namespace QuanLyVeMayBay
{
    partial class frmAdmin
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
            pnlContainer = new Panel();
            tabCtrlAdmin = new TabControl();
            tabBaoCao = new TabPage();
            pnlBaoCaoContent = new Panel();
            pnlChartWrapper = new Panel();
            grpBieuDo = new GroupBox();
            pnlBieuDo = new Panel();
            pnlChartRightInfo = new Panel();
            grpTomTatKinhDoanh = new GroupBox();
            txtTomTatKinhDoanh = new TextBox();
            pnlBaoCaoActions = new Panel();
            btnXuatBaoCaoTongHop = new Button();
            btnTaoBaoCao = new Button();
            pnlKpiCards = new Panel();
            cardNhanVien = new Panel();
            lblValNhanVien = new Label();
            lblTitleNhanVien = new Label();
            cardVeBan = new Panel();
            lblValVeBan = new Label();
            lblTitleVeBan = new Label();
            cardChuyenBay = new Panel();
            lblValChuyenBay = new Label();
            lblTitleChuyenBay = new Label();
            cardDoanhThuTong = new Panel();
            lblValDoanhThuTong = new Label();
            lblTitleDoanhThuTong = new Label();
            tabDanhSachChuyenBay = new TabPage();
            pnlChuyenBayReadOnly = new Panel();
            grpDanhSachCbAdmin = new GroupBox();
            dgvChuyenBayAdmin = new DataGridView();
            pnlFilterCbAdmin = new Panel();
            btnLamMoiCbAdmin = new Button();
            btnLocCbAdmin = new Button();
            cboLocTrangThaiCb = new ComboBox();
            lblLocTrangThaiCb = new Label();
            cboLocDenAdmin = new ComboBox();
            lblLocDenAdmin = new Label();
            cboLocDiAdmin = new ComboBox();
            lblLocDiAdmin = new Label();
            pnlCalloutChuyenBay = new Panel();
            lblCalloutChuyenBay = new Label();
            tabQuanLyNhanVien = new TabPage();
            pnlNhanVienContent = new Panel();
            pnlRightNv = new Panel();
            grpThongTinNv = new GroupBox();
            btnDoiQuyenNv = new Button();
            btnLamMoiNv = new Button();
            btnXoaNv = new Button();
            btnSuaNv = new Button();
            btnThemNv = new Button();
            cboChucVu = new ComboBox();
            lblChucVu = new Label();
            txtQueQuan = new TextBox();
            lblQueQuan = new Label();
            txtSoDienThoai = new TextBox();
            lblSoDienThoai = new Label();
            txtHoTen = new TextBox();
            lblHoTen = new Label();
            txtMatKhau = new TextBox();
            lblMatKhau = new Label();
            txtTenDangNhap = new TextBox();
            lblTenDangNhap = new Label();
            txtMaNV = new TextBox();
            lblMaNv = new Label();
            pnlLeftNv = new Panel();
            grpDanhSachNv = new GroupBox();
            dgvNhanVien = new DataGridView();
            pnlCheckIdNv = new Panel();
            btnHienTatCaNv = new Button();
            btnCheckNv = new Button();
            txtCheckNv = new TextBox();
            lblCheckNv = new Label();
            pnlContainer.SuspendLayout();
            tabCtrlAdmin.SuspendLayout();
            tabBaoCao.SuspendLayout();
            pnlBaoCaoContent.SuspendLayout();
            pnlChartWrapper.SuspendLayout();
            grpBieuDo.SuspendLayout();
            pnlChartRightInfo.SuspendLayout();
            grpTomTatKinhDoanh.SuspendLayout();
            pnlBaoCaoActions.SuspendLayout();
            pnlKpiCards.SuspendLayout();
            cardNhanVien.SuspendLayout();
            cardVeBan.SuspendLayout();
            cardChuyenBay.SuspendLayout();
            cardDoanhThuTong.SuspendLayout();
            tabDanhSachChuyenBay.SuspendLayout();
            pnlChuyenBayReadOnly.SuspendLayout();
            grpDanhSachCbAdmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChuyenBayAdmin).BeginInit();
            pnlFilterCbAdmin.SuspendLayout();
            pnlCalloutChuyenBay.SuspendLayout();
            tabQuanLyNhanVien.SuspendLayout();
            pnlNhanVienContent.SuspendLayout();
            pnlRightNv.SuspendLayout();
            grpThongTinNv.SuspendLayout();
            pnlLeftNv.SuspendLayout();
            grpDanhSachNv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).BeginInit();
            pnlCheckIdNv.SuspendLayout();
            SuspendLayout();
            // 
            // pnlContainer
            // 
            pnlContainer.Controls.Add(tabCtrlAdmin);
            pnlContainer.Dock = DockStyle.Fill;
            pnlContainer.Location = new Point(0, 65);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Padding = new Padding(12);
            pnlContainer.Size = new Size(1180, 675);
            pnlContainer.TabIndex = 0;
            // 
            // tabCtrlAdmin
            // 
            tabCtrlAdmin.Controls.Add(tabBaoCao);
            tabCtrlAdmin.Controls.Add(tabDanhSachChuyenBay);
            tabCtrlAdmin.Controls.Add(tabQuanLyNhanVien);
            tabCtrlAdmin.Dock = DockStyle.Fill;
            tabCtrlAdmin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            tabCtrlAdmin.Location = new Point(12, 12);
            tabCtrlAdmin.Name = "tabCtrlAdmin";
            tabCtrlAdmin.SelectedIndex = 0;
            tabCtrlAdmin.Size = new Size(1156, 651);
            tabCtrlAdmin.TabIndex = 0;
            // 
            // tabBaoCao
            // 
            tabBaoCao.BackColor = Color.FromArgb(241, 245, 249);
            tabBaoCao.Controls.Add(pnlBaoCaoContent);
            tabBaoCao.Controls.Add(pnlKpiCards);
            tabBaoCao.Location = new Point(4, 26);
            tabBaoCao.Name = "tabBaoCao";
            tabBaoCao.Padding = new Padding(10);
            tabBaoCao.Size = new Size(1148, 621);
            tabBaoCao.TabIndex = 0;
            tabBaoCao.Text = "📊 Báo cáo & Biểu đồ Quản trị (Dashboard)";
            // 
            // pnlBaoCaoContent
            // 
            pnlBaoCaoContent.Controls.Add(pnlChartWrapper);
            pnlBaoCaoContent.Controls.Add(pnlBaoCaoActions);
            pnlBaoCaoContent.Dock = DockStyle.Fill;
            pnlBaoCaoContent.Location = new Point(10, 115);
            pnlBaoCaoContent.Name = "pnlBaoCaoContent";
            pnlBaoCaoContent.Size = new Size(1128, 496);
            pnlBaoCaoContent.TabIndex = 1;
            // 
            // pnlChartWrapper
            // 
            pnlChartWrapper.Controls.Add(grpBieuDo);
            pnlChartWrapper.Controls.Add(pnlChartRightInfo);
            pnlChartWrapper.Dock = DockStyle.Fill;
            pnlChartWrapper.Location = new Point(0, 55);
            pnlChartWrapper.Name = "pnlChartWrapper";
            pnlChartWrapper.Size = new Size(1128, 441);
            pnlChartWrapper.TabIndex = 1;
            // 
            // grpBieuDo
            // 
            grpBieuDo.BackColor = Color.White;
            grpBieuDo.Controls.Add(pnlBieuDo);
            grpBieuDo.Dock = DockStyle.Fill;
            grpBieuDo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpBieuDo.Location = new Point(0, 0);
            grpBieuDo.Name = "grpBieuDo";
            grpBieuDo.Padding = new Padding(12);
            grpBieuDo.Size = new Size(748, 441);
            grpBieuDo.TabIndex = 0;
            grpBieuDo.TabStop = false;
            grpBieuDo.Text = "📈 BIỂU ĐỒ DOANH THU THEO TUYẾN BAY (Triệu VNĐ)";
            // 
            // pnlBieuDo
            // 
            pnlBieuDo.BackColor = Color.White;
            pnlBieuDo.Dock = DockStyle.Fill;
            pnlBieuDo.Location = new Point(12, 30);
            pnlBieuDo.Name = "pnlBieuDo";
            pnlBieuDo.Size = new Size(724, 399);
            pnlBieuDo.TabIndex = 0;
            pnlBieuDo.Paint += pnlBieuDo_Paint;
            // 
            // pnlChartRightInfo
            // 
            pnlChartRightInfo.Controls.Add(grpTomTatKinhDoanh);
            pnlChartRightInfo.Dock = DockStyle.Right;
            pnlChartRightInfo.Location = new Point(748, 0);
            pnlChartRightInfo.Name = "pnlChartRightInfo";
            pnlChartRightInfo.Padding = new Padding(10, 0, 0, 0);
            pnlChartRightInfo.Size = new Size(380, 441);
            pnlChartRightInfo.TabIndex = 1;
            // 
            // grpTomTatKinhDoanh
            // 
            grpTomTatKinhDoanh.BackColor = Color.White;
            grpTomTatKinhDoanh.Controls.Add(txtTomTatKinhDoanh);
            grpTomTatKinhDoanh.Dock = DockStyle.Fill;
            grpTomTatKinhDoanh.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpTomTatKinhDoanh.Location = new Point(10, 0);
            grpTomTatKinhDoanh.Name = "grpTomTatKinhDoanh";
            grpTomTatKinhDoanh.Padding = new Padding(10);
            grpTomTatKinhDoanh.Size = new Size(370, 441);
            grpTomTatKinhDoanh.TabIndex = 0;
            grpTomTatKinhDoanh.TabStop = false;
            grpTomTatKinhDoanh.Text = "📋 Tóm tắt Chỉ số Điều hành";
            // 
            // txtTomTatKinhDoanh
            // 
            txtTomTatKinhDoanh.BackColor = Color.FromArgb(248, 250, 252);
            txtTomTatKinhDoanh.BorderStyle = BorderStyle.None;
            txtTomTatKinhDoanh.Dock = DockStyle.Fill;
            txtTomTatKinhDoanh.Font = new Font("Segoe UI", 9.5F);
            txtTomTatKinhDoanh.Location = new Point(10, 28);
            txtTomTatKinhDoanh.Multiline = true;
            txtTomTatKinhDoanh.Name = "txtTomTatKinhDoanh";
            txtTomTatKinhDoanh.ReadOnly = true;
            txtTomTatKinhDoanh.ScrollBars = ScrollBars.Vertical;
            txtTomTatKinhDoanh.Size = new Size(350, 403);
            txtTomTatKinhDoanh.TabIndex = 0;
            // 
            // pnlBaoCaoActions
            // 
            pnlBaoCaoActions.BackColor = Color.White;
            pnlBaoCaoActions.Controls.Add(btnXuatBaoCaoTongHop);
            pnlBaoCaoActions.Controls.Add(btnTaoBaoCao);
            pnlBaoCaoActions.Dock = DockStyle.Top;
            pnlBaoCaoActions.Location = new Point(0, 0);
            pnlBaoCaoActions.Name = "pnlBaoCaoActions";
            pnlBaoCaoActions.Size = new Size(1128, 55);
            pnlBaoCaoActions.TabIndex = 0;
            // 
            // btnXuatBaoCaoTongHop
            // 
            btnXuatBaoCaoTongHop.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnXuatBaoCaoTongHop.Cursor = Cursors.Hand;
            btnXuatBaoCaoTongHop.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnXuatBaoCaoTongHop.Location = new Point(888, 8);
            btnXuatBaoCaoTongHop.Name = "btnXuatBaoCaoTongHop";
            btnXuatBaoCaoTongHop.Size = new Size(225, 40);
            btnXuatBaoCaoTongHop.TabIndex = 1;
            btnXuatBaoCaoTongHop.Text = "📄 Xuất Báo cáo Điều hành";
            btnXuatBaoCaoTongHop.UseVisualStyleBackColor = true;
            btnXuatBaoCaoTongHop.Click += btnXuatBaoCaoTongHop_Click;
            // 
            // btnTaoBaoCao
            // 
            btnTaoBaoCao.Cursor = Cursors.Hand;
            btnTaoBaoCao.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnTaoBaoCao.Location = new Point(15, 8);
            btnTaoBaoCao.Name = "btnTaoBaoCao";
            btnTaoBaoCao.Size = new Size(260, 40);
            btnTaoBaoCao.TabIndex = 0;
            btnTaoBaoCao.Text = "📊 TẠO BÁO CÁO & HIỆN BIỂU ĐỒ";
            btnTaoBaoCao.UseVisualStyleBackColor = true;
            btnTaoBaoCao.Click += btnTaoBaoCao_Click;
            // 
            // pnlKpiCards
            // 
            pnlKpiCards.Controls.Add(cardNhanVien);
            pnlKpiCards.Controls.Add(cardVeBan);
            pnlKpiCards.Controls.Add(cardChuyenBay);
            pnlKpiCards.Controls.Add(cardDoanhThuTong);
            pnlKpiCards.Dock = DockStyle.Top;
            pnlKpiCards.Location = new Point(10, 10);
            pnlKpiCards.Name = "pnlKpiCards";
            pnlKpiCards.Size = new Size(1128, 105);
            pnlKpiCards.TabIndex = 0;
            // 
            // cardNhanVien
            // 
            cardNhanVien.BackColor = Color.White;
            cardNhanVien.Controls.Add(lblValNhanVien);
            cardNhanVien.Controls.Add(lblTitleNhanVien);
            cardNhanVien.Location = new Point(845, 10);
            cardNhanVien.Name = "cardNhanVien";
            cardNhanVien.Size = new Size(265, 85);
            cardNhanVien.TabIndex = 3;
            // 
            // lblValNhanVien
            // 
            lblValNhanVien.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblValNhanVien.ForeColor = Color.FromArgb(79, 70, 229);
            lblValNhanVien.Location = new Point(15, 38);
            lblValNhanVien.Name = "lblValNhanVien";
            lblValNhanVien.Size = new Size(235, 32);
            lblValNhanVien.TabIndex = 1;
            lblValNhanVien.Text = "5 NV";
            // 
            // lblTitleNhanVien
            // 
            lblTitleNhanVien.AutoSize = true;
            lblTitleNhanVien.Font = new Font("Segoe UI", 9F);
            lblTitleNhanVien.ForeColor = Color.FromArgb(100, 116, 139);
            lblTitleNhanVien.Location = new Point(15, 15);
            lblTitleNhanVien.Name = "lblTitleNhanVien";
            lblTitleNhanVien.Size = new Size(135, 15);
            lblTitleNhanVien.TabIndex = 0;
            lblTitleNhanVien.Text = "👥 Tổng Nhân sự quản lý:";
            // 
            // cardVeBan
            // 
            cardVeBan.BackColor = Color.White;
            cardVeBan.Controls.Add(lblValVeBan);
            cardVeBan.Controls.Add(lblTitleVeBan);
            cardVeBan.Location = new Point(565, 10);
            cardVeBan.Name = "cardVeBan";
            cardVeBan.Size = new Size(265, 85);
            cardVeBan.TabIndex = 2;
            // 
            // lblValVeBan
            // 
            lblValVeBan.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblValVeBan.ForeColor = Color.FromArgb(245, 158, 11);
            lblValVeBan.Location = new Point(15, 38);
            lblValVeBan.Name = "lblValVeBan";
            lblValVeBan.Size = new Size(235, 32);
            lblValVeBan.TabIndex = 1;
            lblValVeBan.Text = "0 vé";
            // 
            // lblTitleVeBan
            // 
            lblTitleVeBan.AutoSize = true;
            lblTitleVeBan.Font = new Font("Segoe UI", 9F);
            lblTitleVeBan.ForeColor = Color.FromArgb(100, 116, 139);
            lblTitleVeBan.Location = new Point(15, 15);
            lblTitleVeBan.Name = "lblTitleVeBan";
            lblTitleVeBan.Size = new Size(116, 15);
            lblTitleVeBan.TabIndex = 0;
            lblTitleVeBan.Text = "🎫 Tổng số Vé đã bán:";
            // 
            // cardChuyenBay
            // 
            cardChuyenBay.BackColor = Color.White;
            cardChuyenBay.Controls.Add(lblValChuyenBay);
            cardChuyenBay.Controls.Add(lblTitleChuyenBay);
            cardChuyenBay.Location = new Point(285, 10);
            cardChuyenBay.Name = "cardChuyenBay";
            cardChuyenBay.Size = new Size(265, 85);
            cardChuyenBay.TabIndex = 1;
            // 
            // lblValChuyenBay
            // 
            lblValChuyenBay.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblValChuyenBay.ForeColor = Color.FromArgb(2, 132, 199);
            lblValChuyenBay.Location = new Point(15, 38);
            lblValChuyenBay.Name = "lblValChuyenBay";
            lblValChuyenBay.Size = new Size(235, 32);
            lblValChuyenBay.TabIndex = 1;
            lblValChuyenBay.Text = "0 CB";
            // 
            // lblTitleChuyenBay
            // 
            lblTitleChuyenBay.AutoSize = true;
            lblTitleChuyenBay.Font = new Font("Segoe UI", 9F);
            lblTitleChuyenBay.ForeColor = Color.FromArgb(100, 116, 139);
            lblTitleChuyenBay.Location = new Point(15, 15);
            lblTitleChuyenBay.Name = "lblTitleChuyenBay";
            lblTitleChuyenBay.Size = new Size(130, 15);
            lblTitleChuyenBay.TabIndex = 0;
            lblTitleChuyenBay.Text = "🛫 Tổng số Chuyến bay:";
            // 
            // cardDoanhThuTong
            // 
            cardDoanhThuTong.BackColor = Color.White;
            cardDoanhThuTong.Controls.Add(lblValDoanhThuTong);
            cardDoanhThuTong.Controls.Add(lblTitleDoanhThuTong);
            cardDoanhThuTong.Location = new Point(5, 10);
            cardDoanhThuTong.Name = "cardDoanhThuTong";
            cardDoanhThuTong.Size = new Size(265, 85);
            cardDoanhThuTong.TabIndex = 0;
            // 
            // lblValDoanhThuTong
            // 
            lblValDoanhThuTong.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblValDoanhThuTong.ForeColor = Color.FromArgb(16, 185, 129);
            lblValDoanhThuTong.Location = new Point(15, 38);
            lblValDoanhThuTong.Name = "lblValDoanhThuTong";
            lblValDoanhThuTong.Size = new Size(235, 32);
            lblValDoanhThuTong.TabIndex = 1;
            lblValDoanhThuTong.Text = "0 VNĐ";
            // 
            // lblTitleDoanhThuTong
            // 
            lblTitleDoanhThuTong.AutoSize = true;
            lblTitleDoanhThuTong.Font = new Font("Segoe UI", 9F);
            lblTitleDoanhThuTong.ForeColor = Color.FromArgb(100, 116, 139);
            lblTitleDoanhThuTong.Location = new Point(15, 15);
            lblTitleDoanhThuTong.Name = "lblTitleDoanhThuTong";
            lblTitleDoanhThuTong.Size = new Size(138, 15);
            lblTitleDoanhThuTong.TabIndex = 0;
            lblTitleDoanhThuTong.Text = "💰 Doanh thu toàn hãng:";
            // 
            // tabDanhSachChuyenBay
            // 
            tabDanhSachChuyenBay.BackColor = Color.FromArgb(241, 245, 249);
            tabDanhSachChuyenBay.Controls.Add(pnlChuyenBayReadOnly);
            tabDanhSachChuyenBay.Location = new Point(4, 26);
            tabDanhSachChuyenBay.Name = "tabDanhSachChuyenBay";
            tabDanhSachChuyenBay.Padding = new Padding(10);
            tabDanhSachChuyenBay.Size = new Size(1148, 621);
            tabDanhSachChuyenBay.TabIndex = 1;
            tabDanhSachChuyenBay.Text = "✈️ Danh sách Chuyến bay (Chỉ xem)";
            // 
            // pnlChuyenBayReadOnly
            // 
            pnlChuyenBayReadOnly.Controls.Add(grpDanhSachCbAdmin);
            pnlChuyenBayReadOnly.Controls.Add(pnlFilterCbAdmin);
            pnlChuyenBayReadOnly.Controls.Add(pnlCalloutChuyenBay);
            pnlChuyenBayReadOnly.Dock = DockStyle.Fill;
            pnlChuyenBayReadOnly.Location = new Point(10, 10);
            pnlChuyenBayReadOnly.Name = "pnlChuyenBayReadOnly";
            pnlChuyenBayReadOnly.Size = new Size(1128, 601);
            pnlChuyenBayReadOnly.TabIndex = 0;
            // 
            // grpDanhSachCbAdmin
            // 
            grpDanhSachCbAdmin.BackColor = Color.White;
            grpDanhSachCbAdmin.Controls.Add(dgvChuyenBayAdmin);
            grpDanhSachCbAdmin.Dock = DockStyle.Fill;
            grpDanhSachCbAdmin.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpDanhSachCbAdmin.Location = new Point(0, 115);
            grpDanhSachCbAdmin.Name = "grpDanhSachCbAdmin";
            grpDanhSachCbAdmin.Padding = new Padding(8);
            grpDanhSachCbAdmin.Size = new Size(1128, 486);
            grpDanhSachCbAdmin.TabIndex = 2;
            grpDanhSachCbAdmin.TabStop = false;
            grpDanhSachCbAdmin.Text = "📋 Danh sách Chuyến bay toàn hãng (Chế độ Xem / Read-Only)";
            // 
            // dgvChuyenBayAdmin
            // 
            dgvChuyenBayAdmin.AllowUserToAddRows = false;
            dgvChuyenBayAdmin.AllowUserToDeleteRows = false;
            dgvChuyenBayAdmin.BackgroundColor = Color.White;
            dgvChuyenBayAdmin.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChuyenBayAdmin.Dock = DockStyle.Fill;
            dgvChuyenBayAdmin.Location = new Point(8, 25);
            dgvChuyenBayAdmin.Name = "dgvChuyenBayAdmin";
            dgvChuyenBayAdmin.ReadOnly = true;
            dgvChuyenBayAdmin.RowTemplate.Height = 36;
            dgvChuyenBayAdmin.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChuyenBayAdmin.Size = new Size(1112, 453);
            dgvChuyenBayAdmin.TabIndex = 0;
            // 
            // pnlFilterCbAdmin
            // 
            pnlFilterCbAdmin.BackColor = Color.White;
            pnlFilterCbAdmin.Controls.Add(btnLamMoiCbAdmin);
            pnlFilterCbAdmin.Controls.Add(btnLocCbAdmin);
            pnlFilterCbAdmin.Controls.Add(cboLocTrangThaiCb);
            pnlFilterCbAdmin.Controls.Add(lblLocTrangThaiCb);
            pnlFilterCbAdmin.Controls.Add(cboLocDenAdmin);
            pnlFilterCbAdmin.Controls.Add(lblLocDenAdmin);
            pnlFilterCbAdmin.Controls.Add(cboLocDiAdmin);
            pnlFilterCbAdmin.Controls.Add(lblLocDiAdmin);
            pnlFilterCbAdmin.Dock = DockStyle.Top;
            pnlFilterCbAdmin.Location = new Point(0, 50);
            pnlFilterCbAdmin.Name = "pnlFilterCbAdmin";
            pnlFilterCbAdmin.Size = new Size(1128, 65);
            pnlFilterCbAdmin.TabIndex = 1;
            // 
            // btnLamMoiCbAdmin
            // 
            btnLamMoiCbAdmin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLamMoiCbAdmin.Cursor = Cursors.Hand;
            btnLamMoiCbAdmin.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLamMoiCbAdmin.Location = new Point(1015, 14);
            btnLamMoiCbAdmin.Name = "btnLamMoiCbAdmin";
            btnLamMoiCbAdmin.Size = new Size(95, 36);
            btnLamMoiCbAdmin.TabIndex = 7;
            btnLamMoiCbAdmin.Text = "🔄 Làm mới";
            btnLamMoiCbAdmin.UseVisualStyleBackColor = true;
            btnLamMoiCbAdmin.Click += btnLamMoiCbAdmin_Click;
            // 
            // btnLocCbAdmin
            // 
            btnLocCbAdmin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLocCbAdmin.Cursor = Cursors.Hand;
            btnLocCbAdmin.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLocCbAdmin.Location = new Point(915, 14);
            btnLocCbAdmin.Name = "btnLocCbAdmin";
            btnLocCbAdmin.Size = new Size(95, 36);
            btnLocCbAdmin.TabIndex = 6;
            btnLocCbAdmin.Text = "🔍 Lọc";
            btnLocCbAdmin.UseVisualStyleBackColor = true;
            btnLocCbAdmin.Click += btnLocCbAdmin_Click;
            // 
            // cboLocTrangThaiCb
            // 
            cboLocTrangThaiCb.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLocTrangThaiCb.Font = new Font("Segoe UI", 9F);
            cboLocTrangThaiCb.FormattingEnabled = true;
            cboLocTrangThaiCb.Location = new Point(680, 22);
            cboLocTrangThaiCb.Name = "cboLocTrangThaiCb";
            cboLocTrangThaiCb.Size = new Size(180, 23);
            cboLocTrangThaiCb.TabIndex = 5;
            // 
            // lblLocTrangThaiCb
            // 
            lblLocTrangThaiCb.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblLocTrangThaiCb.Location = new Point(595, 22);
            lblLocTrangThaiCb.Name = "lblLocTrangThaiCb";
            lblLocTrangThaiCb.Size = new Size(80, 23);
            lblLocTrangThaiCb.TabIndex = 4;
            lblLocTrangThaiCb.Text = "Trạng thái:";
            lblLocTrangThaiCb.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cboLocDenAdmin
            // 
            cboLocDenAdmin.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLocDenAdmin.Font = new Font("Segoe UI", 9F);
            cboLocDenAdmin.FormattingEnabled = true;
            cboLocDenAdmin.Location = new Point(390, 22);
            cboLocDenAdmin.Name = "cboLocDenAdmin";
            cboLocDenAdmin.Size = new Size(190, 23);
            cboLocDenAdmin.TabIndex = 3;
            // 
            // lblLocDenAdmin
            // 
            lblLocDenAdmin.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblLocDenAdmin.Location = new Point(305, 22);
            lblLocDenAdmin.Name = "lblLocDenAdmin";
            lblLocDenAdmin.Size = new Size(80, 23);
            lblLocDenAdmin.TabIndex = 2;
            lblLocDenAdmin.Text = "Nơi đến:";
            lblLocDenAdmin.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cboLocDiAdmin
            // 
            cboLocDiAdmin.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLocDiAdmin.Font = new Font("Segoe UI", 9F);
            cboLocDiAdmin.FormattingEnabled = true;
            cboLocDiAdmin.Location = new Point(100, 22);
            cboLocDiAdmin.Name = "cboLocDiAdmin";
            cboLocDiAdmin.Size = new Size(190, 23);
            cboLocDiAdmin.TabIndex = 1;
            // 
            // lblLocDiAdmin
            // 
            lblLocDiAdmin.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblLocDiAdmin.Location = new Point(15, 22);
            lblLocDiAdmin.Name = "lblLocDiAdmin";
            lblLocDiAdmin.Size = new Size(80, 23);
            lblLocDiAdmin.TabIndex = 0;
            lblLocDiAdmin.Text = "Nơi đi:";
            lblLocDiAdmin.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pnlCalloutChuyenBay
            // 
            pnlCalloutChuyenBay.BackColor = Color.FromArgb(239, 246, 255);
            pnlCalloutChuyenBay.Controls.Add(lblCalloutChuyenBay);
            pnlCalloutChuyenBay.Dock = DockStyle.Top;
            pnlCalloutChuyenBay.Location = new Point(0, 0);
            pnlCalloutChuyenBay.Name = "pnlCalloutChuyenBay";
            pnlCalloutChuyenBay.Size = new Size(1128, 50);
            pnlCalloutChuyenBay.TabIndex = 0;
            // 
            // lblCalloutChuyenBay
            // 
            lblCalloutChuyenBay.Dock = DockStyle.Fill;
            lblCalloutChuyenBay.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic);
            lblCalloutChuyenBay.ForeColor = Color.FromArgb(30, 58, 138);
            lblCalloutChuyenBay.Location = new Point(0, 0);
            lblCalloutChuyenBay.Name = "lblCalloutChuyenBay";
            lblCalloutChuyenBay.Padding = new Padding(15, 0, 15, 0);
            lblCalloutChuyenBay.Size = new Size(1128, 50);
            lblCalloutChuyenBay.TabIndex = 0;
            lblCalloutChuyenBay.Text = "ℹ️ Chế độ chỉ xem (Read-only) dành cho Quản trị viên (Admin). Admin được quyền giám sát toàn bộ danh sách chuyến bay của hãng nhưng không trực tiếp thao tác thêm/sửa/xóa (Nghiệp vụ do Bộ phận Quản lý Chuyến bay phụ trách).";
            lblCalloutChuyenBay.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tabQuanLyNhanVien
            // 
            tabQuanLyNhanVien.BackColor = Color.FromArgb(241, 245, 249);
            tabQuanLyNhanVien.Controls.Add(pnlNhanVienContent);
            tabQuanLyNhanVien.Location = new Point(4, 26);
            tabQuanLyNhanVien.Name = "tabQuanLyNhanVien";
            tabQuanLyNhanVien.Padding = new Padding(10);
            tabQuanLyNhanVien.Size = new Size(1148, 621);
            tabQuanLyNhanVien.TabIndex = 2;
            tabQuanLyNhanVien.Text = "👥 Quản lý Nhân viên & Phân quyền";
            // 
            // pnlNhanVienContent
            // 
            pnlNhanVienContent.Controls.Add(pnlRightNv);
            pnlNhanVienContent.Controls.Add(pnlLeftNv);
            pnlNhanVienContent.Dock = DockStyle.Fill;
            pnlNhanVienContent.Location = new Point(10, 10);
            pnlNhanVienContent.Name = "pnlNhanVienContent";
            pnlNhanVienContent.Size = new Size(1128, 601);
            pnlNhanVienContent.TabIndex = 0;
            // 
            // pnlRightNv
            // 
            pnlRightNv.Controls.Add(grpThongTinNv);
            pnlRightNv.Dock = DockStyle.Fill;
            pnlRightNv.Location = new Point(690, 0);
            pnlRightNv.Name = "pnlRightNv";
            pnlRightNv.Padding = new Padding(10, 0, 0, 0);
            pnlRightNv.Size = new Size(438, 601);
            pnlRightNv.TabIndex = 1;
            // 
            // grpThongTinNv
            // 
            grpThongTinNv.BackColor = Color.White;
            grpThongTinNv.Controls.Add(btnDoiQuyenNv);
            grpThongTinNv.Controls.Add(btnLamMoiNv);
            grpThongTinNv.Controls.Add(btnXoaNv);
            grpThongTinNv.Controls.Add(btnSuaNv);
            grpThongTinNv.Controls.Add(btnThemNv);
            grpThongTinNv.Controls.Add(cboChucVu);
            grpThongTinNv.Controls.Add(lblChucVu);
            grpThongTinNv.Controls.Add(txtQueQuan);
            grpThongTinNv.Controls.Add(lblQueQuan);
            grpThongTinNv.Controls.Add(txtSoDienThoai);
            grpThongTinNv.Controls.Add(lblSoDienThoai);
            grpThongTinNv.Controls.Add(txtHoTen);
            grpThongTinNv.Controls.Add(lblHoTen);
            grpThongTinNv.Controls.Add(txtMatKhau);
            grpThongTinNv.Controls.Add(lblMatKhau);
            grpThongTinNv.Controls.Add(txtTenDangNhap);
            grpThongTinNv.Controls.Add(lblTenDangNhap);
            grpThongTinNv.Controls.Add(txtMaNV);
            grpThongTinNv.Controls.Add(lblMaNv);
            grpThongTinNv.Dock = DockStyle.Fill;
            grpThongTinNv.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpThongTinNv.Location = new Point(10, 0);
            grpThongTinNv.Name = "grpThongTinNv";
            grpThongTinNv.Size = new Size(428, 601);
            grpThongTinNv.TabIndex = 0;
            grpThongTinNv.TabStop = false;
            grpThongTinNv.Text = "👤 Thông tin & Cấp quyền Nhân viên";
            // 
            // btnDoiQuyenNv
            // 
            btnDoiQuyenNv.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnDoiQuyenNv.Cursor = Cursors.Hand;
            btnDoiQuyenNv.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnDoiQuyenNv.Location = new Point(140, 510);
            btnDoiQuyenNv.Name = "btnDoiQuyenNv";
            btnDoiQuyenNv.Size = new Size(265, 42);
            btnDoiQuyenNv.TabIndex = 18;
            btnDoiQuyenNv.Text = "⚡ THAY ĐỔI QUYỀN HẠN NHÂN VIÊN";
            btnDoiQuyenNv.UseVisualStyleBackColor = true;
            btnDoiQuyenNv.Click += btnDoiQuyenNv_Click;
            // 
            // btnLamMoiNv
            // 
            btnLamMoiNv.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLamMoiNv.Cursor = Cursors.Hand;
            btnLamMoiNv.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLamMoiNv.Location = new Point(280, 455);
            btnLamMoiNv.Name = "btnLamMoiNv";
            btnLamMoiNv.Size = new Size(125, 42);
            btnLamMoiNv.TabIndex = 17;
            btnLamMoiNv.Text = "🔄 Làm mới";
            btnLamMoiNv.UseVisualStyleBackColor = true;
            btnLamMoiNv.Click += btnLamMoiNv_Click;
            // 
            // btnXoaNv
            // 
            btnXoaNv.Cursor = Cursors.Hand;
            btnXoaNv.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnXoaNv.Location = new Point(140, 455);
            btnXoaNv.Name = "btnXoaNv";
            btnXoaNv.Size = new Size(125, 42);
            btnXoaNv.TabIndex = 16;
            btnXoaNv.Text = "🗑️ Xóa NV";
            btnXoaNv.UseVisualStyleBackColor = true;
            btnXoaNv.Click += btnXoaNv_Click;
            // 
            // btnSuaNv
            // 
            btnSuaNv.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSuaNv.Cursor = Cursors.Hand;
            btnSuaNv.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSuaNv.Location = new Point(280, 400);
            btnSuaNv.Name = "btnSuaNv";
            btnSuaNv.Size = new Size(125, 42);
            btnSuaNv.TabIndex = 15;
            btnSuaNv.Text = "✏️ Sửa đổi";
            btnSuaNv.UseVisualStyleBackColor = true;
            btnSuaNv.Click += btnSuaNv_Click;
            // 
            // btnThemNv
            // 
            btnThemNv.Cursor = Cursors.Hand;
            btnThemNv.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnThemNv.Location = new Point(140, 400);
            btnThemNv.Name = "btnThemNv";
            btnThemNv.Size = new Size(125, 42);
            btnThemNv.TabIndex = 14;
            btnThemNv.Text = "➕ Thêm mới";
            btnThemNv.UseVisualStyleBackColor = true;
            btnThemNv.Click += btnThemNv_Click;
            // 
            // cboChucVu
            // 
            cboChucVu.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboChucVu.DropDownStyle = ComboBoxStyle.DropDownList;
            cboChucVu.Font = new Font("Segoe UI", 9.5F);
            cboChucVu.FormattingEnabled = true;
            cboChucVu.Location = new Point(140, 345);
            cboChucVu.Name = "cboChucVu";
            cboChucVu.Size = new Size(265, 24);
            cboChucVu.TabIndex = 13;
            // 
            // lblChucVu
            // 
            lblChucVu.Font = new Font("Segoe UI", 9F);
            lblChucVu.Location = new Point(15, 345);
            lblChucVu.Name = "lblChucVu";
            lblChucVu.Size = new Size(115, 24);
            lblChucVu.TabIndex = 12;
            lblChucVu.Text = "Chức vụ / Quyền:";
            lblChucVu.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtQueQuan
            // 
            txtQueQuan.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtQueQuan.Font = new Font("Segoe UI", 9.5F);
            txtQueQuan.Location = new Point(140, 295);
            txtQueQuan.Name = "txtQueQuan";
            txtQueQuan.Size = new Size(265, 24);
            txtQueQuan.TabIndex = 11;
            // 
            // lblQueQuan
            // 
            lblQueQuan.Font = new Font("Segoe UI", 9F);
            lblQueQuan.Location = new Point(15, 295);
            lblQueQuan.Name = "lblQueQuan";
            lblQueQuan.Size = new Size(115, 24);
            lblQueQuan.TabIndex = 10;
            lblQueQuan.Text = "Quê quán (*):";
            lblQueQuan.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtSoDienThoai
            // 
            txtSoDienThoai.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSoDienThoai.Font = new Font("Segoe UI", 9.5F);
            txtSoDienThoai.Location = new Point(140, 245);
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.Size = new Size(265, 24);
            txtSoDienThoai.TabIndex = 9;
            // 
            // lblSoDienThoai
            // 
            lblSoDienThoai.Font = new Font("Segoe UI", 9F);
            lblSoDienThoai.Location = new Point(15, 245);
            lblSoDienThoai.Name = "lblSoDienThoai";
            lblSoDienThoai.Size = new Size(115, 24);
            lblSoDienThoai.TabIndex = 8;
            lblSoDienThoai.Text = "Số điện thoại:";
            lblSoDienThoai.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtHoTen
            // 
            txtHoTen.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtHoTen.Font = new Font("Segoe UI", 9.5F);
            txtHoTen.Location = new Point(140, 195);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(265, 24);
            txtHoTen.TabIndex = 7;
            // 
            // lblHoTen
            // 
            lblHoTen.Font = new Font("Segoe UI", 9F);
            lblHoTen.Location = new Point(15, 195);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(115, 24);
            lblHoTen.TabIndex = 6;
            lblHoTen.Text = "Họ và tên (*):";
            lblHoTen.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMatKhau.Font = new Font("Segoe UI", 9.5F);
            txtMatKhau.Location = new Point(140, 145);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(265, 24);
            txtMatKhau.TabIndex = 5;
            // 
            // lblMatKhau
            // 
            lblMatKhau.Font = new Font("Segoe UI", 9F);
            lblMatKhau.Location = new Point(15, 145);
            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.Size = new Size(115, 24);
            lblMatKhau.TabIndex = 4;
            lblMatKhau.Text = "Mật khẩu (*):";
            lblMatKhau.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTenDangNhap.Font = new Font("Segoe UI", 9.5F);
            txtTenDangNhap.Location = new Point(140, 95);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(265, 24);
            txtTenDangNhap.TabIndex = 3;
            // 
            // lblTenDangNhap
            // 
            lblTenDangNhap.Font = new Font("Segoe UI", 9F);
            lblTenDangNhap.Location = new Point(15, 95);
            lblTenDangNhap.Name = "lblTenDangNhap";
            lblTenDangNhap.Size = new Size(115, 24);
            lblTenDangNhap.TabIndex = 2;
            lblTenDangNhap.Text = "Tên đăng nhập (*):";
            lblTenDangNhap.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtMaNV
            // 
            txtMaNV.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMaNV.BackColor = Color.FromArgb(241, 245, 249);
            txtMaNV.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            txtMaNV.Location = new Point(140, 45);
            txtMaNV.Name = "txtMaNV";
            txtMaNV.ReadOnly = true;
            txtMaNV.Size = new Size(265, 24);
            txtMaNV.TabIndex = 1;
            // 
            // lblMaNv
            // 
            lblMaNv.Font = new Font("Segoe UI", 9F);
            lblMaNv.Location = new Point(15, 45);
            lblMaNv.Name = "lblMaNv";
            lblMaNv.Size = new Size(115, 24);
            lblMaNv.TabIndex = 0;
            lblMaNv.Text = "Mã nhân viên (ID):";
            lblMaNv.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pnlLeftNv
            // 
            pnlLeftNv.Controls.Add(grpDanhSachNv);
            pnlLeftNv.Controls.Add(pnlCheckIdNv);
            pnlLeftNv.Dock = DockStyle.Left;
            pnlLeftNv.Location = new Point(0, 0);
            pnlLeftNv.Name = "pnlLeftNv";
            pnlLeftNv.Size = new Size(690, 601);
            pnlLeftNv.TabIndex = 0;
            // 
            // grpDanhSachNv
            // 
            grpDanhSachNv.BackColor = Color.White;
            grpDanhSachNv.Controls.Add(dgvNhanVien);
            grpDanhSachNv.Dock = DockStyle.Fill;
            grpDanhSachNv.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpDanhSachNv.Location = new Point(0, 65);
            grpDanhSachNv.Name = "grpDanhSachNv";
            grpDanhSachNv.Padding = new Padding(8);
            grpDanhSachNv.Size = new Size(690, 536);
            grpDanhSachNv.TabIndex = 1;
            grpDanhSachNv.TabStop = false;
            grpDanhSachNv.Text = "📋 Danh sách Tài khoản & Nhân sự công ty";
            // 
            // dgvNhanVien
            // 
            dgvNhanVien.AllowUserToAddRows = false;
            dgvNhanVien.AllowUserToDeleteRows = false;
            dgvNhanVien.BackgroundColor = Color.White;
            dgvNhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNhanVien.Dock = DockStyle.Fill;
            dgvNhanVien.Location = new Point(8, 25);
            dgvNhanVien.Name = "dgvNhanVien";
            dgvNhanVien.ReadOnly = true;
            dgvNhanVien.RowTemplate.Height = 36;
            dgvNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNhanVien.Size = new Size(674, 503);
            dgvNhanVien.TabIndex = 0;
            dgvNhanVien.CellClick += dgvNhanVien_CellClick;
            // 
            // pnlCheckIdNv
            // 
            pnlCheckIdNv.BackColor = Color.White;
            pnlCheckIdNv.Controls.Add(btnHienTatCaNv);
            pnlCheckIdNv.Controls.Add(btnCheckNv);
            pnlCheckIdNv.Controls.Add(txtCheckNv);
            pnlCheckIdNv.Controls.Add(lblCheckNv);
            pnlCheckIdNv.Dock = DockStyle.Top;
            pnlCheckIdNv.Location = new Point(0, 0);
            pnlCheckIdNv.Name = "pnlCheckIdNv";
            pnlCheckIdNv.Size = new Size(690, 65);
            pnlCheckIdNv.TabIndex = 0;
            // 
            // btnHienTatCaNv
            // 
            btnHienTatCaNv.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnHienTatCaNv.Cursor = Cursors.Hand;
            btnHienTatCaNv.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnHienTatCaNv.Location = new Point(575, 14);
            btnHienTatCaNv.Name = "btnHienTatCaNv";
            btnHienTatCaNv.Size = new Size(100, 36);
            btnHienTatCaNv.TabIndex = 3;
            btnHienTatCaNv.Text = "Hiện tất cả";
            btnHienTatCaNv.UseVisualStyleBackColor = true;
            btnHienTatCaNv.Click += btnHienTatCaNv_Click;
            // 
            // btnCheckNv
            // 
            btnCheckNv.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCheckNv.Cursor = Cursors.Hand;
            btnCheckNv.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCheckNv.Location = new Point(470, 14);
            btnCheckNv.Name = "btnCheckNv";
            btnCheckNv.Size = new Size(95, 36);
            btnCheckNv.TabIndex = 2;
            btnCheckNv.Text = "🔍 Check / Tìm";
            btnCheckNv.UseVisualStyleBackColor = true;
            btnCheckNv.Click += btnCheckNv_Click;
            // 
            // txtCheckNv
            // 
            txtCheckNv.Font = new Font("Segoe UI", 9.5F);
            txtCheckNv.Location = new Point(190, 20);
            txtCheckNv.Name = "txtCheckNv";
            txtCheckNv.PlaceholderText = "Nhập Mã NV (ID), Tên, Quê quán, Chức vụ...";
            txtCheckNv.Size = new Size(260, 24);
            txtCheckNv.TabIndex = 1;
            txtCheckNv.KeyDown += txtCheckNv_KeyDown;
            // 
            // lblCheckNv
            // 
            lblCheckNv.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCheckNv.Location = new Point(10, 20);
            lblCheckNv.Name = "lblCheckNv";
            lblCheckNv.Size = new Size(175, 24);
            lblCheckNv.TabIndex = 0;
            lblCheckNv.Text = "Tra cứu / Check ID Nhân viên:";
            lblCheckNv.TextAlign = ContentAlignment.MiddleRight;
            // 
            // frmAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1180, 740);
            Controls.Add(pnlContainer);
            MinimumSize = new Size(1100, 700);
            Name = "frmAdmin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hệ thống Quản trị viên (Admin Dashboard) - Quản lý Bán vé Máy bay";
            Load += frmAdmin_Load;
            pnlContainer.ResumeLayout(false);
            tabCtrlAdmin.ResumeLayout(false);
            tabBaoCao.ResumeLayout(false);
            pnlBaoCaoContent.ResumeLayout(false);
            pnlChartWrapper.ResumeLayout(false);
            grpBieuDo.ResumeLayout(false);
            pnlChartRightInfo.ResumeLayout(false);
            grpTomTatKinhDoanh.ResumeLayout(false);
            grpTomTatKinhDoanh.PerformLayout();
            pnlBaoCaoActions.ResumeLayout(false);
            pnlKpiCards.ResumeLayout(false);
            cardNhanVien.ResumeLayout(false);
            cardNhanVien.PerformLayout();
            cardVeBan.ResumeLayout(false);
            cardVeBan.PerformLayout();
            cardChuyenBay.ResumeLayout(false);
            cardChuyenBay.PerformLayout();
            cardDoanhThuTong.ResumeLayout(false);
            cardDoanhThuTong.PerformLayout();
            tabDanhSachChuyenBay.ResumeLayout(false);
            pnlChuyenBayReadOnly.ResumeLayout(false);
            grpDanhSachCbAdmin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvChuyenBayAdmin).EndInit();
            pnlFilterCbAdmin.ResumeLayout(false);
            pnlCalloutChuyenBay.ResumeLayout(false);
            tabQuanLyNhanVien.ResumeLayout(false);
            pnlNhanVienContent.ResumeLayout(false);
            pnlRightNv.ResumeLayout(false);
            grpThongTinNv.ResumeLayout(false);
            grpThongTinNv.PerformLayout();
            pnlLeftNv.ResumeLayout(false);
            grpDanhSachNv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).EndInit();
            pnlCheckIdNv.ResumeLayout(false);
            pnlCheckIdNv.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlContainer;
        private TabControl tabCtrlAdmin;
        private TabPage tabBaoCao;
        private Panel pnlKpiCards;
        private Panel cardDoanhThuTong;
        private Label lblTitleDoanhThuTong;
        private Label lblValDoanhThuTong;
        private Panel cardChuyenBay;
        private Label lblTitleChuyenBay;
        private Label lblValChuyenBay;
        private Panel cardVeBan;
        private Label lblTitleVeBan;
        private Label lblValVeBan;
        private Panel cardNhanVien;
        private Label lblTitleNhanVien;
        private Label lblValNhanVien;
        private Panel pnlBaoCaoContent;
        private Panel pnlBaoCaoActions;
        private Button btnTaoBaoCao;
        private Button btnXuatBaoCaoTongHop;
        private Panel pnlChartWrapper;
        private GroupBox grpBieuDo;
        private Panel pnlBieuDo;
        private Panel pnlChartRightInfo;
        private GroupBox grpTomTatKinhDoanh;
        private TextBox txtTomTatKinhDoanh;
        private TabPage tabDanhSachChuyenBay;
        private Panel pnlChuyenBayReadOnly;
        private Panel pnlCalloutChuyenBay;
        private Label lblCalloutChuyenBay;
        private Panel pnlFilterCbAdmin;
        private Label lblLocDiAdmin;
        private ComboBox cboLocDiAdmin;
        private Label lblLocDenAdmin;
        private ComboBox cboLocDenAdmin;
        private Label lblLocTrangThaiCb;
        private ComboBox cboLocTrangThaiCb;
        private Button btnLocCbAdmin;
        private Button btnLamMoiCbAdmin;
        private GroupBox grpDanhSachCbAdmin;
        private DataGridView dgvChuyenBayAdmin;
        private TabPage tabQuanLyNhanVien;
        private Panel pnlNhanVienContent;
        private Panel pnlLeftNv;
        private Panel pnlCheckIdNv;
        private Label lblCheckNv;
        private TextBox txtCheckNv;
        private Button btnCheckNv;
        private Button btnHienTatCaNv;
        private GroupBox grpDanhSachNv;
        private DataGridView dgvNhanVien;
        private Panel pnlRightNv;
        private GroupBox grpThongTinNv;
        private Label lblMaNv;
        private TextBox txtMaNV;
        private Label lblTenDangNhap;
        private TextBox txtTenDangNhap;
        private Label lblMatKhau;
        private TextBox txtMatKhau;
        private Label lblHoTen;
        private TextBox txtHoTen;
        private Label lblSoDienThoai;
        private TextBox txtSoDienThoai;
        private Label lblQueQuan;
        private TextBox txtQueQuan;
        private Label lblChucVu;
        private ComboBox cboChucVu;
        private Button btnThemNv;
        private Button btnSuaNv;
        private Button btnXoaNv;
        private Button btnLamMoiNv;
        private Button btnDoiQuyenNv;
    }
}
