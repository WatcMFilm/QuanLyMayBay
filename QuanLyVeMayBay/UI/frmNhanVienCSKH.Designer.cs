namespace QuanLyVeMayBay
{
    partial class frmNhanVienCSKH
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
            tabCtrlCSKH = new TabControl();
            tabTraCuuVe = new TabPage();
            pnlTraCuuContent = new Panel();
            pnlRightVe = new Panel();
            grpThaoTacVe = new GroupBox();
            btnHuyVe = new Button();
            btnThayDoiGhe = new Button();
            btnThayDoiChuyenBay = new Button();
            grpChiTietVe = new GroupBox();
            lblChiTietVeText = new Label();
            pnlLeftVe = new Panel();
            grpDanhSachVe = new GroupBox();
            dgvVe = new DataGridView();
            pnlTimKiemVe = new Panel();
            btnLamMoiVe = new Button();
            btnTimKiemVe = new Button();
            cboLocTrangThai = new ComboBox();
            lblLocTrangThai = new Label();
            txtTimKiemVe = new TextBox();
            lblTimKiemVe = new Label();
            tabTiepNhanYeuCau = new TabPage();
            pnlYeuCauContent = new Panel();
            grpDanhSachYeuCau = new GroupBox();
            dgvYeuCau = new DataGridView();
            pnlActionsYeuCau = new Panel();
            btnLamMoiDsYc = new Button();
            btnTuChoiYc = new Button();
            btnXoaYc = new Button();
            btnXuLyHoanTat = new Button();
            grpTiepNhanMoi = new GroupBox();
            btnLamMoiNhapYc = new Button();
            btnLuuYeuCau = new Button();
            txtYcNoiDung = new TextBox();
            lblYcNoiDung = new Label();
            cboLoaiYeuCau = new ComboBox();
            lblLoaiYeuCau = new Label();
            txtYcTenKhach = new TextBox();
            lblYcTenKhach = new Label();
            txtYcMaVe = new TextBox();
            lblYcMaVe = new Label();
            pnlContainer.SuspendLayout();
            tabCtrlCSKH.SuspendLayout();
            tabTraCuuVe.SuspendLayout();
            pnlTraCuuContent.SuspendLayout();
            pnlRightVe.SuspendLayout();
            grpThaoTacVe.SuspendLayout();
            grpChiTietVe.SuspendLayout();
            pnlLeftVe.SuspendLayout();
            grpDanhSachVe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVe).BeginInit();
            pnlTimKiemVe.SuspendLayout();
            tabTiepNhanYeuCau.SuspendLayout();
            pnlYeuCauContent.SuspendLayout();
            grpDanhSachYeuCau.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvYeuCau).BeginInit();
            pnlActionsYeuCau.SuspendLayout();
            grpTiepNhanMoi.SuspendLayout();
            SuspendLayout();
            // 
            // pnlContainer
            // 
            pnlContainer.Controls.Add(tabCtrlCSKH);
            pnlContainer.Dock = DockStyle.Fill;
            pnlContainer.Location = new Point(0, 65);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Padding = new Padding(12);
            pnlContainer.Size = new Size(1180, 675);
            pnlContainer.TabIndex = 0;
            // 
            // tabCtrlCSKH
            // 
            tabCtrlCSKH.Controls.Add(tabTraCuuVe);
            tabCtrlCSKH.Controls.Add(tabTiepNhanYeuCau);
            tabCtrlCSKH.Dock = DockStyle.Fill;
            tabCtrlCSKH.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            tabCtrlCSKH.Location = new Point(12, 12);
            tabCtrlCSKH.Name = "tabCtrlCSKH";
            tabCtrlCSKH.SelectedIndex = 0;
            tabCtrlCSKH.Size = new Size(1156, 651);
            tabCtrlCSKH.TabIndex = 0;
            // 
            // tabTraCuuVe
            // 
            tabTraCuuVe.BackColor = Color.FromArgb(241, 245, 249);
            tabTraCuuVe.Controls.Add(pnlTraCuuContent);
            tabTraCuuVe.Location = new Point(4, 26);
            tabTraCuuVe.Name = "tabTraCuuVe";
            tabTraCuuVe.Padding = new Padding(10);
            tabTraCuuVe.Size = new Size(1148, 621);
            tabTraCuuVe.TabIndex = 0;
            tabTraCuuVe.Text = "🔍 Tra cứu vé & Xử lý Vé (Đổi / Hủy)";
            // 
            // pnlTraCuuContent
            // 
            pnlTraCuuContent.Controls.Add(pnlRightVe);
            pnlTraCuuContent.Controls.Add(pnlLeftVe);
            pnlTraCuuContent.Dock = DockStyle.Fill;
            pnlTraCuuContent.Location = new Point(10, 10);
            pnlTraCuuContent.Name = "pnlTraCuuContent";
            pnlTraCuuContent.Size = new Size(1128, 601);
            pnlTraCuuContent.TabIndex = 0;
            // 
            // pnlRightVe
            // 
            pnlRightVe.Controls.Add(grpThaoTacVe);
            pnlRightVe.Controls.Add(grpChiTietVe);
            pnlRightVe.Dock = DockStyle.Fill;
            pnlRightVe.Location = new Point(730, 0);
            pnlRightVe.Name = "pnlRightVe";
            pnlRightVe.Padding = new Padding(10, 0, 0, 0);
            pnlRightVe.Size = new Size(398, 601);
            pnlRightVe.TabIndex = 1;
            // 
            // grpThaoTacVe
            // 
            grpThaoTacVe.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpThaoTacVe.BackColor = Color.White;
            grpThaoTacVe.Controls.Add(btnHuyVe);
            grpThaoTacVe.Controls.Add(btnThayDoiGhe);
            grpThaoTacVe.Controls.Add(btnThayDoiChuyenBay);
            grpThaoTacVe.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpThaoTacVe.Location = new Point(10, 310);
            grpThaoTacVe.Name = "grpThaoTacVe";
            grpThaoTacVe.Size = new Size(388, 280);
            grpThaoTacVe.TabIndex = 1;
            grpThaoTacVe.TabStop = false;
            grpThaoTacVe.Text = "⚙️ Thao tác Nghiệp vụ Vé";
            // 
            // btnHuyVe
            // 
            btnHuyVe.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnHuyVe.Cursor = Cursors.Hand;
            btnHuyVe.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnHuyVe.Location = new Point(20, 185);
            btnHuyVe.Name = "btnHuyVe";
            btnHuyVe.Size = new Size(348, 55);
            btnHuyVe.TabIndex = 2;
            btnHuyVe.Text = "❌ HỦY VÉ & GIẢI PHÓNG GHẾ";
            btnHuyVe.UseVisualStyleBackColor = true;
            btnHuyVe.Click += btnHuyVe_Click;
            // 
            // btnThayDoiGhe
            // 
            btnThayDoiGhe.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnThayDoiGhe.Cursor = Cursors.Hand;
            btnThayDoiGhe.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnThayDoiGhe.Location = new Point(20, 115);
            btnThayDoiGhe.Name = "btnThayDoiGhe";
            btnThayDoiGhe.Size = new Size(348, 48);
            btnThayDoiGhe.TabIndex = 1;
            btnThayDoiGhe.Text = "💺 ĐỔI GHẾ NGỒI CHO VÉ";
            btnThayDoiGhe.UseVisualStyleBackColor = true;
            btnThayDoiGhe.Click += btnThayDoiGhe_Click;
            // 
            // btnThayDoiChuyenBay
            // 
            btnThayDoiChuyenBay.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnThayDoiChuyenBay.Cursor = Cursors.Hand;
            btnThayDoiChuyenBay.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnThayDoiChuyenBay.Location = new Point(20, 45);
            btnThayDoiChuyenBay.Name = "btnThayDoiChuyenBay";
            btnThayDoiChuyenBay.Size = new Size(348, 48);
            btnThayDoiChuyenBay.TabIndex = 0;
            btnThayDoiChuyenBay.Text = "🔄 ĐỔI SANG CHUYẾN BAY MỚI";
            btnThayDoiChuyenBay.UseVisualStyleBackColor = true;
            btnThayDoiChuyenBay.Click += btnThayDoiChuyenBay_Click;
            // 
            // grpChiTietVe
            // 
            grpChiTietVe.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpChiTietVe.BackColor = Color.White;
            grpChiTietVe.Controls.Add(lblChiTietVeText);
            grpChiTietVe.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpChiTietVe.Location = new Point(10, 0);
            grpChiTietVe.Name = "grpChiTietVe";
            grpChiTietVe.Padding = new Padding(12);
            grpChiTietVe.Size = new Size(388, 295);
            grpChiTietVe.TabIndex = 0;
            grpChiTietVe.TabStop = false;
            grpChiTietVe.Text = "📋 Chi tiết Vé đang chọn";
            // 
            // lblChiTietVeText
            // 
            lblChiTietVeText.Dock = DockStyle.Fill;
            lblChiTietVeText.Font = new Font("Segoe UI", 9.5F);
            lblChiTietVeText.ForeColor = Color.FromArgb(15, 23, 42);
            lblChiTietVeText.Location = new Point(12, 30);
            lblChiTietVeText.Name = "lblChiTietVeText";
            lblChiTietVeText.Size = new Size(364, 253);
            lblChiTietVeText.TabIndex = 0;
            lblChiTietVeText.Text = "Vui lòng chọn 1 vé trong danh sách bảng bên trái để xem thông tin chi tiết và thực hiện thay đổi vé hoặc hủy vé.";
            // 
            // pnlLeftVe
            // 
            pnlLeftVe.Controls.Add(grpDanhSachVe);
            pnlLeftVe.Controls.Add(pnlTimKiemVe);
            pnlLeftVe.Dock = DockStyle.Left;
            pnlLeftVe.Location = new Point(0, 0);
            pnlLeftVe.Name = "pnlLeftVe";
            pnlLeftVe.Size = new Size(730, 601);
            pnlLeftVe.TabIndex = 0;
            // 
            // grpDanhSachVe
            // 
            grpDanhSachVe.BackColor = Color.White;
            grpDanhSachVe.Controls.Add(dgvVe);
            grpDanhSachVe.Dock = DockStyle.Fill;
            grpDanhSachVe.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpDanhSachVe.Location = new Point(0, 70);
            grpDanhSachVe.Name = "grpDanhSachVe";
            grpDanhSachVe.Padding = new Padding(8);
            grpDanhSachVe.Size = new Size(730, 531);
            grpDanhSachVe.TabIndex = 1;
            grpDanhSachVe.TabStop = false;
            grpDanhSachVe.Text = "📋 Danh sách Vé máy bay";
            // 
            // dgvVe
            // 
            dgvVe.AllowUserToAddRows = false;
            dgvVe.AllowUserToDeleteRows = false;
            dgvVe.BackgroundColor = Color.White;
            dgvVe.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVe.Dock = DockStyle.Fill;
            dgvVe.Location = new Point(8, 25);
            dgvVe.Name = "dgvVe";
            dgvVe.ReadOnly = true;
            dgvVe.RowTemplate.Height = 36;
            dgvVe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVe.Size = new Size(714, 498);
            dgvVe.TabIndex = 0;
            dgvVe.CellClick += dgvVe_CellClick;
            // 
            // pnlTimKiemVe
            // 
            pnlTimKiemVe.BackColor = Color.White;
            pnlTimKiemVe.Controls.Add(btnLamMoiVe);
            pnlTimKiemVe.Controls.Add(btnTimKiemVe);
            pnlTimKiemVe.Controls.Add(cboLocTrangThai);
            pnlTimKiemVe.Controls.Add(lblLocTrangThai);
            pnlTimKiemVe.Controls.Add(txtTimKiemVe);
            pnlTimKiemVe.Controls.Add(lblTimKiemVe);
            pnlTimKiemVe.Dock = DockStyle.Top;
            pnlTimKiemVe.Location = new Point(0, 0);
            pnlTimKiemVe.Name = "pnlTimKiemVe";
            pnlTimKiemVe.Size = new Size(730, 70);
            pnlTimKiemVe.TabIndex = 0;
            // 
            // btnLamMoiVe
            // 
            btnLamMoiVe.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLamMoiVe.Cursor = Cursors.Hand;
            btnLamMoiVe.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLamMoiVe.Location = new Point(625, 17);
            btnLamMoiVe.Name = "btnLamMoiVe";
            btnLamMoiVe.Size = new Size(95, 34);
            btnLamMoiVe.TabIndex = 5;
            btnLamMoiVe.Text = "🔄 Làm mới";
            btnLamMoiVe.UseVisualStyleBackColor = true;
            btnLamMoiVe.Click += btnLamMoiVe_Click;
            // 
            // btnTimKiemVe
            // 
            btnTimKiemVe.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTimKiemVe.Cursor = Cursors.Hand;
            btnTimKiemVe.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnTimKiemVe.Location = new Point(520, 17);
            btnTimKiemVe.Name = "btnTimKiemVe";
            btnTimKiemVe.Size = new Size(95, 34);
            btnTimKiemVe.TabIndex = 4;
            btnTimKiemVe.Text = "🔍 Tìm kiếm";
            btnTimKiemVe.UseVisualStyleBackColor = true;
            btnTimKiemVe.Click += btnTimKiemVe_Click;
            // 
            // cboLocTrangThai
            // 
            cboLocTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLocTrangThai.Font = new Font("Segoe UI", 9F);
            cboLocTrangThai.FormattingEnabled = true;
            cboLocTrangThai.Location = new Point(370, 23);
            cboLocTrangThai.Name = "cboLocTrangThai";
            cboLocTrangThai.Size = new Size(135, 23);
            cboLocTrangThai.TabIndex = 3;
            cboLocTrangThai.SelectedIndexChanged += cboLocTrangThai_SelectedIndexChanged;
            // 
            // lblLocTrangThai
            // 
            lblLocTrangThai.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblLocTrangThai.Location = new Point(290, 23);
            lblLocTrangThai.Name = "lblLocTrangThai";
            lblLocTrangThai.Size = new Size(75, 23);
            lblLocTrangThai.TabIndex = 2;
            lblLocTrangThai.Text = "Trạng thái:";
            lblLocTrangThai.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtTimKiemVe
            // 
            txtTimKiemVe.Font = new Font("Segoe UI", 9.5F);
            txtTimKiemVe.Location = new Point(80, 23);
            txtTimKiemVe.Name = "txtTimKiemVe";
            txtTimKiemVe.PlaceholderText = "Nhập Mã vé, Tên khách, SĐT, CCCD...";
            txtTimKiemVe.Size = new Size(200, 24);
            txtTimKiemVe.TabIndex = 1;
            txtTimKiemVe.KeyDown += txtTimKiemVe_KeyDown;
            // 
            // lblTimKiemVe
            // 
            lblTimKiemVe.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTimKiemVe.Location = new Point(10, 23);
            lblTimKiemVe.Name = "lblTimKiemVe";
            lblTimKiemVe.Size = new Size(65, 24);
            lblTimKiemVe.TabIndex = 0;
            lblTimKiemVe.Text = "Tra cứu:";
            lblTimKiemVe.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tabTiepNhanYeuCau
            // 
            tabTiepNhanYeuCau.BackColor = Color.FromArgb(241, 245, 249);
            tabTiepNhanYeuCau.Controls.Add(pnlYeuCauContent);
            tabTiepNhanYeuCau.Location = new Point(4, 26);
            tabTiepNhanYeuCau.Name = "tabTiepNhanYeuCau";
            tabTiepNhanYeuCau.Padding = new Padding(10);
            tabTiepNhanYeuCau.Size = new Size(1148, 621);
            tabTiepNhanYeuCau.TabIndex = 1;
            tabTiepNhanYeuCau.Text = "🎧 Tiếp nhận & Quản lý Yêu cầu CSKH";
            // 
            // pnlYeuCauContent
            // 
            pnlYeuCauContent.Controls.Add(grpDanhSachYeuCau);
            pnlYeuCauContent.Controls.Add(grpTiepNhanMoi);
            pnlYeuCauContent.Dock = DockStyle.Fill;
            pnlYeuCauContent.Location = new Point(10, 10);
            pnlYeuCauContent.Name = "pnlYeuCauContent";
            pnlYeuCauContent.Size = new Size(1128, 601);
            pnlYeuCauContent.TabIndex = 0;
            // 
            // grpDanhSachYeuCau
            // 
            grpDanhSachYeuCau.BackColor = Color.White;
            grpDanhSachYeuCau.Controls.Add(dgvYeuCau);
            grpDanhSachYeuCau.Controls.Add(pnlActionsYeuCau);
            grpDanhSachYeuCau.Dock = DockStyle.Fill;
            grpDanhSachYeuCau.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpDanhSachYeuCau.Location = new Point(430, 0);
            grpDanhSachYeuCau.Name = "grpDanhSachYeuCau";
            grpDanhSachYeuCau.Padding = new Padding(8);
            grpDanhSachYeuCau.Size = new Size(698, 601);
            grpDanhSachYeuCau.TabIndex = 1;
            grpDanhSachYeuCau.TabStop = false;
            grpDanhSachYeuCau.Text = "📋 Danh sách Yêu cầu Khách hàng đã tiếp nhận";
            // 
            // dgvYeuCau
            // 
            dgvYeuCau.AllowUserToAddRows = false;
            dgvYeuCau.AllowUserToDeleteRows = false;
            dgvYeuCau.BackgroundColor = Color.White;
            dgvYeuCau.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvYeuCau.Dock = DockStyle.Fill;
            dgvYeuCau.Location = new Point(8, 25);
            dgvYeuCau.Name = "dgvYeuCau";
            dgvYeuCau.ReadOnly = true;
            dgvYeuCau.RowTemplate.Height = 36;
            dgvYeuCau.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvYeuCau.Size = new Size(682, 513);
            dgvYeuCau.TabIndex = 0;
            // 
            // pnlActionsYeuCau
            // 
            pnlActionsYeuCau.BackColor = Color.White;
            pnlActionsYeuCau.Controls.Add(btnLamMoiDsYc);
            pnlActionsYeuCau.Controls.Add(btnTuChoiYc);
            pnlActionsYeuCau.Controls.Add(btnXoaYc);
            pnlActionsYeuCau.Controls.Add(btnXuLyHoanTat);
            pnlActionsYeuCau.Dock = DockStyle.Bottom;
            pnlActionsYeuCau.Location = new Point(8, 538);
            pnlActionsYeuCau.Name = "pnlActionsYeuCau";
            pnlActionsYeuCau.Size = new Size(682, 55);
            pnlActionsYeuCau.TabIndex = 1;
            // 
            // btnLamMoiDsYc
            // 
            btnLamMoiDsYc.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLamMoiDsYc.Cursor = Cursors.Hand;
            btnLamMoiDsYc.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnLamMoiDsYc.Location = new Point(542, 8);
            btnLamMoiDsYc.Name = "btnLamMoiDsYc";
            btnLamMoiDsYc.Size = new Size(130, 40);
            btnLamMoiDsYc.TabIndex = 2;
            btnLamMoiDsYc.Text = "🔄 Làm mới";
            btnLamMoiDsYc.UseVisualStyleBackColor = true;
            btnLamMoiDsYc.Click += btnLamMoiDsYc_Click;
            // 
            // btnTuChoiYc
            // 
            btnTuChoiYc.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTuChoiYc.Cursor = Cursors.Hand;
            btnTuChoiYc.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnTuChoiYc.Location = new Point(390, 8);
            btnTuChoiYc.Name = "btnTuChoiYc";
            btnTuChoiYc.Size = new Size(140, 40);
            btnTuChoiYc.TabIndex = 1;
            btnTuChoiYc.Text = "⛔ Từ chối yêu cầu";
            btnTuChoiYc.UseVisualStyleBackColor = true;
            btnTuChoiYc.Click += btnTuChoiYc_Click;
            // 
            // btnXoaYc
            // 
            btnXoaYc.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnXoaYc.Cursor = Cursors.Hand;
            btnXoaYc.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnXoaYc.Location = new Point(80, 8);
            btnXoaYc.Name = "btnXoaYc";
            btnXoaYc.Size = new Size(120, 40);
            btnXoaYc.TabIndex = 3;
            btnXoaYc.Text = "🗑️ Xóa yêu cầu";
            btnXoaYc.UseVisualStyleBackColor = true;
            btnXoaYc.Click += btnXoaYc_Click;
            // 
            // btnXuLyHoanTat
            // 
            btnXuLyHoanTat.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnXuLyHoanTat.Cursor = Cursors.Hand;
            btnXuLyHoanTat.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnXuLyHoanTat.Location = new Point(210, 8);
            btnXuLyHoanTat.Name = "btnXuLyHoanTat";
            btnXuLyHoanTat.Size = new Size(170, 40);
            btnXuLyHoanTat.TabIndex = 0;
            btnXuLyHoanTat.Text = "✅ Đánh dấu ĐÃ XỬ LÝ";
            btnXuLyHoanTat.UseVisualStyleBackColor = true;
            btnXuLyHoanTat.Click += btnXuLyHoanTat_Click;
            // 
            // grpTiepNhanMoi
            // 
            grpTiepNhanMoi.BackColor = Color.White;
            grpTiepNhanMoi.Controls.Add(btnLamMoiNhapYc);
            grpTiepNhanMoi.Controls.Add(btnLuuYeuCau);
            grpTiepNhanMoi.Controls.Add(txtYcNoiDung);
            grpTiepNhanMoi.Controls.Add(lblYcNoiDung);
            grpTiepNhanMoi.Controls.Add(cboLoaiYeuCau);
            grpTiepNhanMoi.Controls.Add(lblLoaiYeuCau);
            grpTiepNhanMoi.Controls.Add(txtYcTenKhach);
            grpTiepNhanMoi.Controls.Add(lblYcTenKhach);
            grpTiepNhanMoi.Controls.Add(txtYcMaVe);
            grpTiepNhanMoi.Controls.Add(lblYcMaVe);
            grpTiepNhanMoi.Dock = DockStyle.Left;
            grpTiepNhanMoi.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpTiepNhanMoi.Location = new Point(0, 0);
            grpTiepNhanMoi.Name = "grpTiepNhanMoi";
            grpTiepNhanMoi.Size = new Size(430, 601);
            grpTiepNhanMoi.TabIndex = 0;
            grpTiepNhanMoi.TabStop = false;
            grpTiepNhanMoi.Text = "📥 Ghi nhận Yêu cầu mới từ Khách";
            // 
            // btnLamMoiNhapYc
            // 
            btnLamMoiNhapYc.Cursor = Cursors.Hand;
            btnLamMoiNhapYc.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnLamMoiNhapYc.Location = new Point(20, 395);
            btnLamMoiNhapYc.Name = "btnLamMoiNhapYc";
            btnLamMoiNhapYc.Size = new Size(125, 45);
            btnLamMoiNhapYc.TabIndex = 9;
            btnLamMoiNhapYc.Text = "🔄 Làm mới";
            btnLamMoiNhapYc.UseVisualStyleBackColor = true;
            btnLamMoiNhapYc.Click += btnLamMoiNhapYc_Click;
            // 
            // btnLuuYeuCau
            // 
            btnLuuYeuCau.Cursor = Cursors.Hand;
            btnLuuYeuCau.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLuuYeuCau.Location = new Point(155, 395);
            btnLuuYeuCau.Name = "btnLuuYeuCau";
            btnLuuYeuCau.Size = new Size(250, 45);
            btnLuuYeuCau.TabIndex = 8;
            btnLuuYeuCau.Text = "📥 TIẾP NHẬN YÊU CẦU";
            btnLuuYeuCau.UseVisualStyleBackColor = true;
            btnLuuYeuCau.Click += btnLuuYeuCau_Click;
            // 
            // txtYcNoiDung
            // 
            txtYcNoiDung.Font = new Font("Segoe UI", 9.5F);
            txtYcNoiDung.Location = new Point(20, 205);
            txtYcNoiDung.Multiline = true;
            txtYcNoiDung.Name = "txtYcNoiDung";
            txtYcNoiDung.ScrollBars = ScrollBars.Vertical;
            txtYcNoiDung.Size = new Size(385, 170);
            txtYcNoiDung.TabIndex = 7;
            // 
            // lblYcNoiDung
            // 
            lblYcNoiDung.Font = new Font("Segoe UI", 9F);
            lblYcNoiDung.Location = new Point(20, 180);
            lblYcNoiDung.Name = "lblYcNoiDung";
            lblYcNoiDung.Size = new Size(385, 20);
            lblYcNoiDung.TabIndex = 6;
            lblYcNoiDung.Text = "Nội dung chi tiết yêu cầu của khách hàng:";
            // 
            // cboLoaiYeuCau
            // 
            cboLoaiYeuCau.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiYeuCau.Font = new Font("Segoe UI", 9.5F);
            cboLoaiYeuCau.FormattingEnabled = true;
            cboLoaiYeuCau.Location = new Point(140, 130);
            cboLoaiYeuCau.Name = "cboLoaiYeuCau";
            cboLoaiYeuCau.Size = new Size(265, 24);
            cboLoaiYeuCau.TabIndex = 5;
            // 
            // lblLoaiYeuCau
            // 
            lblLoaiYeuCau.Font = new Font("Segoe UI", 9F);
            lblLoaiYeuCau.Location = new Point(15, 130);
            lblLoaiYeuCau.Name = "lblLoaiYeuCau";
            lblLoaiYeuCau.Size = new Size(115, 24);
            lblLoaiYeuCau.TabIndex = 4;
            lblLoaiYeuCau.Text = "Loại yêu cầu (*):";
            lblLoaiYeuCau.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtYcTenKhach
            // 
            txtYcTenKhach.Font = new Font("Segoe UI", 9.5F);
            txtYcTenKhach.Location = new Point(140, 85);
            txtYcTenKhach.Name = "txtYcTenKhach";
            txtYcTenKhach.Size = new Size(265, 24);
            txtYcTenKhach.TabIndex = 3;
            // 
            // lblYcTenKhach
            // 
            lblYcTenKhach.Font = new Font("Segoe UI", 9F);
            lblYcTenKhach.Location = new Point(15, 85);
            lblYcTenKhach.Name = "lblYcTenKhach";
            lblYcTenKhach.Size = new Size(115, 24);
            lblYcTenKhach.TabIndex = 2;
            lblYcTenKhach.Text = "Tên hành khách (*):";
            lblYcTenKhach.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtYcMaVe
            // 
            txtYcMaVe.Font = new Font("Segoe UI", 9.5F);
            txtYcMaVe.Location = new Point(140, 40);
            txtYcMaVe.Name = "txtYcMaVe";
            txtYcMaVe.Size = new Size(265, 24);
            txtYcMaVe.TabIndex = 1;
            // 
            // lblYcMaVe
            // 
            lblYcMaVe.Font = new Font("Segoe UI", 9F);
            lblYcMaVe.Location = new Point(15, 40);
            lblYcMaVe.Name = "lblYcMaVe";
            lblYcMaVe.Size = new Size(115, 24);
            lblYcMaVe.TabIndex = 0;
            lblYcMaVe.Text = "Mã vé (nếu có):";
            lblYcMaVe.TextAlign = ContentAlignment.MiddleRight;
            // 
            // frmNhanVienCSKH
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1180, 740);
            Controls.Add(pnlContainer);
            MinimumSize = new Size(1100, 700);
            Name = "frmNhanVienCSKH";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bộ phận Chăm sóc Khách hàng (CSKH) - Hệ thống Vé máy bay";
            Load += frmNhanVienCSKH_Load;
            pnlContainer.ResumeLayout(false);
            tabCtrlCSKH.ResumeLayout(false);
            tabTraCuuVe.ResumeLayout(false);
            pnlTraCuuContent.ResumeLayout(false);
            pnlRightVe.ResumeLayout(false);
            grpThaoTacVe.ResumeLayout(false);
            grpChiTietVe.ResumeLayout(false);
            pnlLeftVe.ResumeLayout(false);
            grpDanhSachVe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvVe).EndInit();
            pnlTimKiemVe.ResumeLayout(false);
            pnlTimKiemVe.PerformLayout();
            tabTiepNhanYeuCau.ResumeLayout(false);
            pnlYeuCauContent.ResumeLayout(false);
            grpDanhSachYeuCau.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvYeuCau).EndInit();
            pnlActionsYeuCau.ResumeLayout(false);
            grpTiepNhanMoi.ResumeLayout(false);
            grpTiepNhanMoi.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlContainer;
        private TabControl tabCtrlCSKH;
        private TabPage tabTraCuuVe;
        private Panel pnlTraCuuContent;
        private Panel pnlLeftVe;
        private Panel pnlTimKiemVe;
        private Label lblTimKiemVe;
        private TextBox txtTimKiemVe;
        private Label lblLocTrangThai;
        private ComboBox cboLocTrangThai;
        private Button btnTimKiemVe;
        private Button btnLamMoiVe;
        private GroupBox grpDanhSachVe;
        private DataGridView dgvVe;
        private Panel pnlRightVe;
        private GroupBox grpChiTietVe;
        private Label lblChiTietVeText;
        private GroupBox grpThaoTacVe;
        private Button btnThayDoiChuyenBay;
        private Button btnThayDoiGhe;
        private Button btnHuyVe;
        private TabPage tabTiepNhanYeuCau;
        private Panel pnlYeuCauContent;
        private GroupBox grpTiepNhanMoi;
        private Label lblYcMaVe;
        private TextBox txtYcMaVe;
        private Label lblYcTenKhach;
        private TextBox txtYcTenKhach;
        private Label lblLoaiYeuCau;
        private ComboBox cboLoaiYeuCau;
        private Label lblYcNoiDung;
        private TextBox txtYcNoiDung;
        private Button btnLuuYeuCau;
        private Button btnLamMoiNhapYc;
        private GroupBox grpDanhSachYeuCau;
        private DataGridView dgvYeuCau;
        private Panel pnlActionsYeuCau;
        private Button btnXuLyHoanTat;
        private Button btnTuChoiYc;
        private Button btnXoaYc;
        private Button btnLamMoiDsYc;
    }
}
