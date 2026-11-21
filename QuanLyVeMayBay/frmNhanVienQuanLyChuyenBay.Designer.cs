namespace QuanLyVeMayBay
{
    partial class frmNhanVienQuanLyChuyenBay
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
            tabCtrlQLCB = new TabControl();
            tabChuyenBay = new TabPage();
            pnlChuyenBayContent = new Panel();
            pnlRightCb = new Panel();
            grpDanhSachCb = new GroupBox();
            dgvChuyenBay = new DataGridView();
            pnlTimCb = new Panel();
            btnLamMoiTim = new Button();
            txtTimCb = new TextBox();
            lblTimCb = new Label();
            pnlLeftCb = new Panel();
            grpThongTinCb = new GroupBox();
            btnCapNhatGioBay = new Button();
            btnLamMoi = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            cboTrangThai = new ComboBox();
            lblTrangThai = new Label();
            txtGiaVe = new TextBox();
            lblGiaVe = new Label();
            dtpThoiGianDen = new DateTimePicker();
            lblThoiGianDen = new Label();
            dtpThoiGianDi = new DateTimePicker();
            lblThoiGianDi = new Label();
            cboSanBayDen = new ComboBox();
            lblSanBayDen = new Label();
            cboSanBayDi = new ComboBox();
            lblSanBayDi = new Label();
            cboMaMayBay = new ComboBox();
            lblMayBay = new Label();
            txtMaChuyenBay = new TextBox();
            lblMaCb = new Label();
            tabTinhTrangGhe = new TabPage();
            pnlGheContent = new Panel();
            pnlRightGhe = new Panel();
            grpThaoTacGhe = new GroupBox();
            lblHuongDanGhe = new Label();
            btnSinhGheMau = new Button();
            btnKhoiPhucTatCaGhe = new Button();
            btnCapNhatGhe = new Button();
            cboTrangThaiGheMoi = new ComboBox();
            lblChonTrangThaiGhe = new Label();
            lblGheDangChon = new Label();
            pnlLeftGhe = new Panel();
            grpDanhSachGhe = new GroupBox();
            dgvGhe = new DataGridView();
            pnlTopGhe = new Panel();
            lblThongKeGhe = new Label();
            cboMayBayGhe = new ComboBox();
            lblChonMayBayGhe = new Label();
            pnlContainer.SuspendLayout();
            tabCtrlQLCB.SuspendLayout();
            tabChuyenBay.SuspendLayout();
            pnlChuyenBayContent.SuspendLayout();
            pnlRightCb.SuspendLayout();
            grpDanhSachCb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChuyenBay).BeginInit();
            pnlTimCb.SuspendLayout();
            pnlLeftCb.SuspendLayout();
            grpThongTinCb.SuspendLayout();
            tabTinhTrangGhe.SuspendLayout();
            pnlGheContent.SuspendLayout();
            pnlRightGhe.SuspendLayout();
            grpThaoTacGhe.SuspendLayout();
            pnlLeftGhe.SuspendLayout();
            grpDanhSachGhe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGhe).BeginInit();
            pnlTopGhe.SuspendLayout();
            SuspendLayout();
            // 
            // pnlContainer
            // 
            pnlContainer.Controls.Add(tabCtrlQLCB);
            pnlContainer.Dock = DockStyle.Fill;
            pnlContainer.Location = new Point(0, 65);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Padding = new Padding(12);
            pnlContainer.Size = new Size(1180, 675);
            pnlContainer.TabIndex = 0;
            // 
            // tabCtrlQLCB
            // 
            tabCtrlQLCB.Controls.Add(tabChuyenBay);
            tabCtrlQLCB.Controls.Add(tabTinhTrangGhe);
            tabCtrlQLCB.Dock = DockStyle.Fill;
            tabCtrlQLCB.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            tabCtrlQLCB.Location = new Point(12, 12);
            tabCtrlQLCB.Name = "tabCtrlQLCB";
            tabCtrlQLCB.SelectedIndex = 0;
            tabCtrlQLCB.Size = new Size(1156, 651);
            tabCtrlQLCB.TabIndex = 0;
            // 
            // tabChuyenBay
            // 
            tabChuyenBay.BackColor = Color.FromArgb(241, 245, 249);
            tabChuyenBay.Controls.Add(pnlChuyenBayContent);
            tabChuyenBay.Location = new Point(4, 26);
            tabChuyenBay.Name = "tabChuyenBay";
            tabChuyenBay.Padding = new Padding(10);
            tabChuyenBay.Size = new Size(1148, 621);
            tabChuyenBay.TabIndex = 0;
            tabChuyenBay.Text = "🛫 Quản lý Chuyến bay (Thêm, Sửa, Xóa, Cập nhật)";
            // 
            // pnlChuyenBayContent
            // 
            pnlChuyenBayContent.Controls.Add(pnlRightCb);
            pnlChuyenBayContent.Controls.Add(pnlLeftCb);
            pnlChuyenBayContent.Dock = DockStyle.Fill;
            pnlChuyenBayContent.Location = new Point(10, 10);
            pnlChuyenBayContent.Name = "pnlChuyenBayContent";
            pnlChuyenBayContent.Size = new Size(1128, 601);
            pnlChuyenBayContent.TabIndex = 0;
            // 
            // pnlRightCb
            // 
            pnlRightCb.Controls.Add(grpDanhSachCb);
            pnlRightCb.Controls.Add(pnlTimCb);
            pnlRightCb.Dock = DockStyle.Fill;
            pnlRightCb.Location = new Point(460, 0);
            pnlRightCb.Name = "pnlRightCb";
            pnlRightCb.Padding = new Padding(10, 0, 0, 0);
            pnlRightCb.Size = new Size(668, 601);
            pnlRightCb.TabIndex = 1;
            // 
            // grpDanhSachCb
            // 
            grpDanhSachCb.BackColor = Color.White;
            grpDanhSachCb.Controls.Add(dgvChuyenBay);
            grpDanhSachCb.Dock = DockStyle.Fill;
            grpDanhSachCb.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpDanhSachCb.Location = new Point(10, 60);
            grpDanhSachCb.Name = "grpDanhSachCb";
            grpDanhSachCb.Padding = new Padding(8);
            grpDanhSachCb.Size = new Size(658, 541);
            grpDanhSachCb.TabIndex = 1;
            grpDanhSachCb.TabStop = false;
            grpDanhSachCb.Text = "📋 Danh sách Chuyến bay trong hệ thống";
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
            dgvChuyenBay.Size = new Size(642, 508);
            dgvChuyenBay.TabIndex = 0;
            dgvChuyenBay.CellClick += dgvChuyenBay_CellClick;
            // 
            // pnlTimCb
            // 
            pnlTimCb.BackColor = Color.White;
            pnlTimCb.Controls.Add(btnLamMoiTim);
            pnlTimCb.Controls.Add(txtTimCb);
            pnlTimCb.Controls.Add(lblTimCb);
            pnlTimCb.Dock = DockStyle.Top;
            pnlTimCb.Location = new Point(10, 0);
            pnlTimCb.Name = "pnlTimCb";
            pnlTimCb.Size = new Size(658, 60);
            pnlTimCb.TabIndex = 0;
            // 
            // btnLamMoiTim
            // 
            btnLamMoiTim.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLamMoiTim.Cursor = Cursors.Hand;
            btnLamMoiTim.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLamMoiTim.Location = new Point(545, 12);
            btnLamMoiTim.Name = "btnLamMoiTim";
            btnLamMoiTim.Size = new Size(100, 36);
            btnLamMoiTim.TabIndex = 2;
            btnLamMoiTim.Text = "🔄 Làm mới";
            btnLamMoiTim.UseVisualStyleBackColor = true;
            btnLamMoiTim.Click += btnLamMoiTim_Click;
            // 
            // txtTimCb
            // 
            txtTimCb.Font = new Font("Segoe UI", 9.5F);
            txtTimCb.Location = new Point(160, 18);
            txtTimCb.Name = "txtTimCb";
            txtTimCb.PlaceholderText = "Nhập mã chuyến bay, sân bay đi/đến...";
            txtTimCb.Size = new Size(350, 24);
            txtTimCb.TabIndex = 1;
            txtTimCb.TextChanged += txtTimCb_TextChanged;
            // 
            // lblTimCb
            // 
            lblTimCb.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTimCb.Location = new Point(10, 18);
            lblTimCb.Name = "lblTimCb";
            lblTimCb.Size = new Size(145, 24);
            lblTimCb.TabIndex = 0;
            lblTimCb.Text = "Tìm nhanh chuyến bay:";
            lblTimCb.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pnlLeftCb
            // 
            pnlLeftCb.Controls.Add(grpThongTinCb);
            pnlLeftCb.Dock = DockStyle.Left;
            pnlLeftCb.Location = new Point(0, 0);
            pnlLeftCb.Name = "pnlLeftCb";
            pnlLeftCb.Size = new Size(460, 601);
            pnlLeftCb.TabIndex = 0;
            // 
            // grpThongTinCb
            // 
            grpThongTinCb.BackColor = Color.White;
            grpThongTinCb.Controls.Add(btnCapNhatGioBay);
            grpThongTinCb.Controls.Add(btnLamMoi);
            grpThongTinCb.Controls.Add(btnXoa);
            grpThongTinCb.Controls.Add(btnSua);
            grpThongTinCb.Controls.Add(btnThem);
            grpThongTinCb.Controls.Add(cboTrangThai);
            grpThongTinCb.Controls.Add(lblTrangThai);
            grpThongTinCb.Controls.Add(txtGiaVe);
            grpThongTinCb.Controls.Add(lblGiaVe);
            grpThongTinCb.Controls.Add(dtpThoiGianDen);
            grpThongTinCb.Controls.Add(lblThoiGianDen);
            grpThongTinCb.Controls.Add(dtpThoiGianDi);
            grpThongTinCb.Controls.Add(lblThoiGianDi);
            grpThongTinCb.Controls.Add(cboSanBayDen);
            grpThongTinCb.Controls.Add(lblSanBayDen);
            grpThongTinCb.Controls.Add(cboSanBayDi);
            grpThongTinCb.Controls.Add(lblSanBayDi);
            grpThongTinCb.Controls.Add(cboMaMayBay);
            grpThongTinCb.Controls.Add(lblMayBay);
            grpThongTinCb.Controls.Add(txtMaChuyenBay);
            grpThongTinCb.Controls.Add(lblMaCb);
            grpThongTinCb.Dock = DockStyle.Fill;
            grpThongTinCb.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpThongTinCb.Location = new Point(0, 0);
            grpThongTinCb.Name = "grpThongTinCb";
            grpThongTinCb.Size = new Size(460, 601);
            grpThongTinCb.TabIndex = 0;
            grpThongTinCb.TabStop = false;
            grpThongTinCb.Text = "📝 Thông tin & Thiết lập Chuyến bay";
            // 
            // btnCapNhatGioBay
            // 
            btnCapNhatGioBay.Cursor = Cursors.Hand;
            btnCapNhatGioBay.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCapNhatGioBay.Location = new Point(145, 520);
            btnCapNhatGioBay.Name = "btnCapNhatGioBay";
            btnCapNhatGioBay.Size = new Size(295, 38);
            btnCapNhatGioBay.TabIndex = 20;
            btnCapNhatGioBay.Text = "⏱️ Quét cập nhật trạng thái theo giờ bay";
            btnCapNhatGioBay.UseVisualStyleBackColor = true;
            btnCapNhatGioBay.Click += btnCapNhatGioBay_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Cursor = Cursors.Hand;
            btnLamMoi.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnLamMoi.Location = new Point(300, 465);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(140, 42);
            btnLamMoi.TabIndex = 19;
            btnLamMoi.Text = "🔄 Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnXoa
            // 
            btnXoa.Cursor = Cursors.Hand;
            btnXoa.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnXoa.Location = new Point(145, 465);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(140, 42);
            btnXoa.TabIndex = 18;
            btnXoa.Text = "🗑️ Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.Cursor = Cursors.Hand;
            btnSua.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnSua.Location = new Point(300, 410);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(140, 42);
            btnSua.TabIndex = 17;
            btnSua.Text = "✏️ Sửa đổi";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.Cursor = Cursors.Hand;
            btnThem.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnThem.Location = new Point(145, 410);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(140, 42);
            btnThem.TabIndex = 16;
            btnThem.Text = "➕ Thêm mới";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // cboTrangThai
            // 
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.Font = new Font("Segoe UI", 9.5F);
            cboTrangThai.FormattingEnabled = true;
            cboTrangThai.Location = new Point(145, 355);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(295, 24);
            cboTrangThai.TabIndex = 15;
            // 
            // lblTrangThai
            // 
            lblTrangThai.Font = new Font("Segoe UI", 9F);
            lblTrangThai.Location = new Point(15, 355);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(120, 24);
            lblTrangThai.TabIndex = 14;
            lblTrangThai.Text = "Trạng thái CB:";
            lblTrangThai.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtGiaVe
            // 
            txtGiaVe.Font = new Font("Segoe UI", 9.5F);
            txtGiaVe.Location = new Point(145, 310);
            txtGiaVe.Name = "txtGiaVe";
            txtGiaVe.Size = new Size(295, 24);
            txtGiaVe.TabIndex = 13;
            // 
            // lblGiaVe
            // 
            lblGiaVe.Font = new Font("Segoe UI", 9F);
            lblGiaVe.Location = new Point(15, 310);
            lblGiaVe.Name = "lblGiaVe";
            lblGiaVe.Size = new Size(120, 24);
            lblGiaVe.TabIndex = 12;
            lblGiaVe.Text = "Giá vé cơ bản (*):";
            lblGiaVe.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dtpThoiGianDen
            // 
            dtpThoiGianDen.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpThoiGianDen.Font = new Font("Segoe UI", 9.5F);
            dtpThoiGianDen.Format = DateTimePickerFormat.Custom;
            dtpThoiGianDen.Location = new Point(145, 265);
            dtpThoiGianDen.Name = "dtpThoiGianDen";
            dtpThoiGianDen.Size = new Size(295, 24);
            dtpThoiGianDen.TabIndex = 11;
            // 
            // lblThoiGianDen
            // 
            lblThoiGianDen.Font = new Font("Segoe UI", 9F);
            lblThoiGianDen.Location = new Point(15, 265);
            lblThoiGianDen.Name = "lblThoiGianDen";
            lblThoiGianDen.Size = new Size(120, 24);
            lblThoiGianDen.TabIndex = 10;
            lblThoiGianDen.Text = "Thời gian đến (*):";
            lblThoiGianDen.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dtpThoiGianDi
            // 
            dtpThoiGianDi.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpThoiGianDi.Font = new Font("Segoe UI", 9.5F);
            dtpThoiGianDi.Format = DateTimePickerFormat.Custom;
            dtpThoiGianDi.Location = new Point(145, 220);
            dtpThoiGianDi.Name = "dtpThoiGianDi";
            dtpThoiGianDi.Size = new Size(295, 24);
            dtpThoiGianDi.TabIndex = 9;
            // 
            // lblThoiGianDi
            // 
            lblThoiGianDi.Font = new Font("Segoe UI", 9F);
            lblThoiGianDi.Location = new Point(15, 220);
            lblThoiGianDi.Name = "lblThoiGianDi";
            lblThoiGianDi.Size = new Size(120, 24);
            lblThoiGianDi.TabIndex = 8;
            lblThoiGianDi.Text = "Thời gian đi (*):";
            lblThoiGianDi.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cboSanBayDen
            // 
            cboSanBayDen.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSanBayDen.Font = new Font("Segoe UI", 9.5F);
            cboSanBayDen.FormattingEnabled = true;
            cboSanBayDen.Location = new Point(145, 175);
            cboSanBayDen.Name = "cboSanBayDen";
            cboSanBayDen.Size = new Size(295, 24);
            cboSanBayDen.TabIndex = 7;
            // 
            // lblSanBayDen
            // 
            lblSanBayDen.Font = new Font("Segoe UI", 9F);
            lblSanBayDen.Location = new Point(15, 175);
            lblSanBayDen.Name = "lblSanBayDen";
            lblSanBayDen.Size = new Size(120, 24);
            lblSanBayDen.TabIndex = 6;
            lblSanBayDen.Text = "Sân bay đến (*):";
            lblSanBayDen.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cboSanBayDi
            // 
            cboSanBayDi.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSanBayDi.Font = new Font("Segoe UI", 9.5F);
            cboSanBayDi.FormattingEnabled = true;
            cboSanBayDi.Location = new Point(145, 130);
            cboSanBayDi.Name = "cboSanBayDi";
            cboSanBayDi.Size = new Size(295, 24);
            cboSanBayDi.TabIndex = 5;
            // 
            // lblSanBayDi
            // 
            lblSanBayDi.Font = new Font("Segoe UI", 9F);
            lblSanBayDi.Location = new Point(15, 130);
            lblSanBayDi.Name = "lblSanBayDi";
            lblSanBayDi.Size = new Size(120, 24);
            lblSanBayDi.TabIndex = 4;
            lblSanBayDi.Text = "Sân bay đi (*):";
            lblSanBayDi.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cboMaMayBay
            // 
            cboMaMayBay.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMaMayBay.Font = new Font("Segoe UI", 9.5F);
            cboMaMayBay.FormattingEnabled = true;
            cboMaMayBay.Location = new Point(145, 85);
            cboMaMayBay.Name = "cboMaMayBay";
            cboMaMayBay.Size = new Size(295, 24);
            cboMaMayBay.TabIndex = 3;
            // 
            // lblMayBay
            // 
            lblMayBay.Font = new Font("Segoe UI", 9F);
            lblMayBay.Location = new Point(15, 85);
            lblMayBay.Name = "lblMayBay";
            lblMayBay.Size = new Size(120, 24);
            lblMayBay.TabIndex = 2;
            lblMayBay.Text = "Tàu bay (*):";
            lblMayBay.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtMaChuyenBay
            // 
            txtMaChuyenBay.BackColor = Color.FromArgb(241, 245, 249);
            txtMaChuyenBay.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            txtMaChuyenBay.Location = new Point(145, 40);
            txtMaChuyenBay.Name = "txtMaChuyenBay";
            txtMaChuyenBay.ReadOnly = true;
            txtMaChuyenBay.Size = new Size(295, 24);
            txtMaChuyenBay.TabIndex = 1;
            // 
            // lblMaCb
            // 
            lblMaCb.Font = new Font("Segoe UI", 9F);
            lblMaCb.Location = new Point(15, 40);
            lblMaCb.Name = "lblMaCb";
            lblMaCb.Size = new Size(120, 24);
            lblMaCb.TabIndex = 0;
            lblMaCb.Text = "Mã chuyến bay:";
            lblMaCb.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tabTinhTrangGhe
            // 
            tabTinhTrangGhe.BackColor = Color.FromArgb(241, 245, 249);
            tabTinhTrangGhe.Controls.Add(pnlGheContent);
            tabTinhTrangGhe.Controls.Add(pnlTopGhe);
            tabTinhTrangGhe.Location = new Point(4, 26);
            tabTinhTrangGhe.Name = "tabTinhTrangGhe";
            tabTinhTrangGhe.Padding = new Padding(10);
            tabTinhTrangGhe.Size = new Size(1148, 621);
            tabTinhTrangGhe.TabIndex = 1;
            tabTinhTrangGhe.Text = "💺 Cập nhật Tình trạng Ghế Tàu bay";
            // 
            // pnlGheContent
            // 
            pnlGheContent.Controls.Add(pnlRightGhe);
            pnlGheContent.Controls.Add(pnlLeftGhe);
            pnlGheContent.Dock = DockStyle.Fill;
            pnlGheContent.Location = new Point(10, 75);
            pnlGheContent.Name = "pnlGheContent";
            pnlGheContent.Size = new Size(1128, 536);
            pnlGheContent.TabIndex = 1;
            // 
            // pnlRightGhe
            // 
            pnlRightGhe.Controls.Add(grpThaoTacGhe);
            pnlRightGhe.Dock = DockStyle.Fill;
            pnlRightGhe.Location = new Point(680, 0);
            pnlRightGhe.Name = "pnlRightGhe";
            pnlRightGhe.Padding = new Padding(10, 0, 0, 0);
            pnlRightGhe.Size = new Size(448, 536);
            pnlRightGhe.TabIndex = 1;
            // 
            // grpThaoTacGhe
            // 
            grpThaoTacGhe.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpThaoTacGhe.BackColor = Color.White;
            grpThaoTacGhe.Controls.Add(lblHuongDanGhe);
            grpThaoTacGhe.Controls.Add(btnSinhGheMau);
            grpThaoTacGhe.Controls.Add(btnKhoiPhucTatCaGhe);
            grpThaoTacGhe.Controls.Add(btnCapNhatGhe);
            grpThaoTacGhe.Controls.Add(cboTrangThaiGheMoi);
            grpThaoTacGhe.Controls.Add(lblChonTrangThaiGhe);
            grpThaoTacGhe.Controls.Add(lblGheDangChon);
            grpThaoTacGhe.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpThaoTacGhe.Location = new Point(10, 0);
            grpThaoTacGhe.Name = "grpThaoTacGhe";
            grpThaoTacGhe.Size = new Size(438, 450);
            grpThaoTacGhe.TabIndex = 0;
            grpThaoTacGhe.TabStop = false;
            grpThaoTacGhe.Text = "⚙️ Thiết lập Trạng thái Ghế";
            // 
            // lblHuongDanGhe
            // 
            lblHuongDanGhe.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblHuongDanGhe.ForeColor = Color.FromArgb(71, 85, 105);
            lblHuongDanGhe.Location = new Point(20, 275);
            lblHuongDanGhe.Name = "lblHuongDanGhe";
            lblHuongDanGhe.Size = new Size(395, 60);
            lblHuongDanGhe.TabIndex = 6;
            lblHuongDanGhe.Text = "💡 Lưu ý: Khi ghế được chuyển sang trạng thái \"Bảo trì\" hoặc \"Hỏng / Khóa\", Bộ phận Đặt vé sẽ không thể chọn ghế này cho hành khách.";
            // 
            // btnSinhGheMau
            // 
            btnSinhGheMau.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnSinhGheMau.Cursor = Cursors.Hand;
            btnSinhGheMau.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSinhGheMau.Location = new Point(20, 390);
            btnSinhGheMau.Name = "btnSinhGheMau";
            btnSinhGheMau.Size = new Size(398, 42);
            btnSinhGheMau.TabIndex = 5;
            btnSinhGheMau.Text = "🔄 Tự động sinh lại ghế chuẩn cho tàu bay";
            btnSinhGheMau.UseVisualStyleBackColor = true;
            btnSinhGheMau.Click += btnSinhGheMau_Click;
            // 
            // btnKhoiPhucTatCaGhe
            // 
            btnKhoiPhucTatCaGhe.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnKhoiPhucTatCaGhe.Cursor = Cursors.Hand;
            btnKhoiPhucTatCaGhe.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnKhoiPhucTatCaGhe.Location = new Point(20, 340);
            btnKhoiPhucTatCaGhe.Name = "btnKhoiPhucTatCaGhe";
            btnKhoiPhucTatCaGhe.Size = new Size(398, 42);
            btnKhoiPhucTatCaGhe.TabIndex = 4;
            btnKhoiPhucTatCaGhe.Text = "⚡ Khôi phục toàn bộ ghế về trạng thái sẵn sàng (Trong)";
            btnKhoiPhucTatCaGhe.UseVisualStyleBackColor = true;
            btnKhoiPhucTatCaGhe.Click += btnKhoiPhucTatCaGhe_Click;
            // 
            // btnCapNhatGhe
            // 
            btnCapNhatGhe.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnCapNhatGhe.Cursor = Cursors.Hand;
            btnCapNhatGhe.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCapNhatGhe.Location = new Point(20, 205);
            btnCapNhatGhe.Name = "btnCapNhatGhe";
            btnCapNhatGhe.Size = new Size(398, 48);
            btnCapNhatGhe.TabIndex = 3;
            btnCapNhatGhe.Text = "💾 CẬP NHẬT TRẠNG THÁI GHẾ";
            btnCapNhatGhe.UseVisualStyleBackColor = true;
            btnCapNhatGhe.Click += btnCapNhatGhe_Click;
            // 
            // cboTrangThaiGheMoi
            // 
            cboTrangThaiGheMoi.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboTrangThaiGheMoi.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThaiGheMoi.Font = new Font("Segoe UI", 10F);
            cboTrangThaiGheMoi.FormattingEnabled = true;
            cboTrangThaiGheMoi.Location = new Point(20, 150);
            cboTrangThaiGheMoi.Name = "cboTrangThaiGheMoi";
            cboTrangThaiGheMoi.Size = new Size(398, 25);
            cboTrangThaiGheMoi.TabIndex = 2;
            // 
            // lblChonTrangThaiGhe
            // 
            lblChonTrangThaiGhe.Font = new Font("Segoe UI", 9F);
            lblChonTrangThaiGhe.Location = new Point(20, 125);
            lblChonTrangThaiGhe.Name = "lblChonTrangThaiGhe";
            lblChonTrangThaiGhe.Size = new Size(300, 20);
            lblChonTrangThaiGhe.TabIndex = 1;
            lblChonTrangThaiGhe.Text = "Chuyển sang trạng thái mới:";
            // 
            // lblGheDangChon
            // 
            lblGheDangChon.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblGheDangChon.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblGheDangChon.ForeColor = Color.FromArgb(2, 132, 199);
            lblGheDangChon.Location = new Point(20, 35);
            lblGheDangChon.Name = "lblGheDangChon";
            lblGheDangChon.Size = new Size(398, 75);
            lblGheDangChon.TabIndex = 0;
            lblGheDangChon.Text = "Vui lòng chọn 1 hoặc nhiều ghế trên bảng danh sách bên trái để chỉnh sửa trạng thái.";
            // 
            // pnlLeftGhe
            // 
            pnlLeftGhe.Controls.Add(grpDanhSachGhe);
            pnlLeftGhe.Dock = DockStyle.Left;
            pnlLeftGhe.Location = new Point(0, 0);
            pnlLeftGhe.Name = "pnlLeftGhe";
            pnlLeftGhe.Size = new Size(680, 536);
            pnlLeftGhe.TabIndex = 0;
            // 
            // grpDanhSachGhe
            // 
            grpDanhSachGhe.BackColor = Color.White;
            grpDanhSachGhe.Controls.Add(dgvGhe);
            grpDanhSachGhe.Dock = DockStyle.Fill;
            grpDanhSachGhe.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpDanhSachGhe.Location = new Point(0, 0);
            grpDanhSachGhe.Name = "grpDanhSachGhe";
            grpDanhSachGhe.Padding = new Padding(8);
            grpDanhSachGhe.Size = new Size(680, 536);
            grpDanhSachGhe.TabIndex = 0;
            grpDanhSachGhe.TabStop = false;
            grpDanhSachGhe.Text = "📋 Sơ đồ & Danh sách ghế ngồi trên tàu bay";
            // 
            // dgvGhe
            // 
            dgvGhe.AllowUserToAddRows = false;
            dgvGhe.AllowUserToDeleteRows = false;
            dgvGhe.BackgroundColor = Color.White;
            dgvGhe.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGhe.Dock = DockStyle.Fill;
            dgvGhe.Location = new Point(8, 25);
            dgvGhe.Name = "dgvGhe";
            dgvGhe.ReadOnly = true;
            dgvGhe.RowTemplate.Height = 36;
            dgvGhe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGhe.Size = new Size(664, 503);
            dgvGhe.TabIndex = 0;
            dgvGhe.CellClick += dgvGhe_CellClick;
            // 
            // pnlTopGhe
            // 
            pnlTopGhe.BackColor = Color.White;
            pnlTopGhe.Controls.Add(lblThongKeGhe);
            pnlTopGhe.Controls.Add(cboMayBayGhe);
            pnlTopGhe.Controls.Add(lblChonMayBayGhe);
            pnlTopGhe.Dock = DockStyle.Top;
            pnlTopGhe.Location = new Point(10, 10);
            pnlTopGhe.Name = "pnlTopGhe";
            pnlTopGhe.Size = new Size(1128, 65);
            pnlTopGhe.TabIndex = 0;
            // 
            // lblThongKeGhe
            // 
            lblThongKeGhe.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblThongKeGhe.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblThongKeGhe.ForeColor = Color.FromArgb(16, 185, 129);
            lblThongKeGhe.Location = new Point(620, 20);
            lblThongKeGhe.Name = "lblThongKeGhe";
            lblThongKeGhe.Size = new Size(495, 25);
            lblThongKeGhe.TabIndex = 2;
            lblThongKeGhe.Text = "● Đang tải dữ liệu ghế...";
            lblThongKeGhe.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cboMayBayGhe
            // 
            cboMayBayGhe.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMayBayGhe.Font = new Font("Segoe UI", 9.5F);
            cboMayBayGhe.FormattingEnabled = true;
            cboMayBayGhe.Location = new Point(160, 20);
            cboMayBayGhe.Name = "cboMayBayGhe";
            cboMayBayGhe.Size = new Size(300, 24);
            cboMayBayGhe.TabIndex = 1;
            cboMayBayGhe.SelectedIndexChanged += cboMayBayGhe_SelectedIndexChanged;
            // 
            // lblChonMayBayGhe
            // 
            lblChonMayBayGhe.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblChonMayBayGhe.Location = new Point(15, 20);
            lblChonMayBayGhe.Name = "lblChonMayBayGhe";
            lblChonMayBayGhe.Size = new Size(140, 24);
            lblChonMayBayGhe.TabIndex = 0;
            lblChonMayBayGhe.Text = "Chọn máy bay:";
            lblChonMayBayGhe.TextAlign = ContentAlignment.MiddleRight;
            // 
            // frmNhanVienQuanLyChuyenBay
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1180, 740);
            Controls.Add(pnlContainer);
            MinimumSize = new Size(1100, 700);
            Name = "frmNhanVienQuanLyChuyenBay";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bộ phận Quản lý Chuyến bay & Đội bay";
            Load += frmNhanVienQuanLyChuyenBay_Load;
            pnlContainer.ResumeLayout(false);
            tabCtrlQLCB.ResumeLayout(false);
            tabChuyenBay.ResumeLayout(false);
            pnlChuyenBayContent.ResumeLayout(false);
            pnlRightCb.ResumeLayout(false);
            grpDanhSachCb.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvChuyenBay).EndInit();
            pnlTimCb.ResumeLayout(false);
            pnlTimCb.PerformLayout();
            pnlLeftCb.ResumeLayout(false);
            grpThongTinCb.ResumeLayout(false);
            grpThongTinCb.PerformLayout();
            tabTinhTrangGhe.ResumeLayout(false);
            pnlGheContent.ResumeLayout(false);
            pnlRightGhe.ResumeLayout(false);
            grpThaoTacGhe.ResumeLayout(false);
            pnlLeftGhe.ResumeLayout(false);
            grpDanhSachGhe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvGhe).EndInit();
            pnlTopGhe.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlContainer;
        private TabControl tabCtrlQLCB;
        private TabPage tabChuyenBay;
        private Panel pnlChuyenBayContent;
        private Panel pnlLeftCb;
        private GroupBox grpThongTinCb;
        private Label lblMaCb;
        private TextBox txtMaChuyenBay;
        private Label lblMayBay;
        private ComboBox cboMaMayBay;
        private Label lblSanBayDi;
        private ComboBox cboSanBayDi;
        private Label lblSanBayDen;
        private ComboBox cboSanBayDen;
        private Label lblThoiGianDi;
        private DateTimePicker dtpThoiGianDi;
        private Label lblThoiGianDen;
        private DateTimePicker dtpThoiGianDen;
        private Label lblGiaVe;
        private TextBox txtGiaVe;
        private Label lblTrangThai;
        private ComboBox cboTrangThai;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Button btnCapNhatGioBay;
        private Panel pnlRightCb;
        private Panel pnlTimCb;
        private Label lblTimCb;
        private TextBox txtTimCb;
        private Button btnLamMoiTim;
        private GroupBox grpDanhSachCb;
        private DataGridView dgvChuyenBay;
        private TabPage tabTinhTrangGhe;
        private Panel pnlTopGhe;
        private Label lblChonMayBayGhe;
        private ComboBox cboMayBayGhe;
        private Label lblThongKeGhe;
        private Panel pnlGheContent;
        private Panel pnlLeftGhe;
        private GroupBox grpDanhSachGhe;
        private DataGridView dgvGhe;
        private Panel pnlRightGhe;
        private GroupBox grpThaoTacGhe;
        private Label lblGheDangChon;
        private Label lblChonTrangThaiGhe;
        private ComboBox cboTrangThaiGheMoi;
        private Button btnCapNhatGhe;
        private Button btnKhoiPhucTatCaGhe;
        private Button btnSinhGheMau;
        private Label lblHuongDanGhe;
    }
}
