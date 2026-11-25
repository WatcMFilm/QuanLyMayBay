namespace QuanLyVeMayBay
{
    partial class frmNhanVienKeToan
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
            tabCtrlKeToan = new TabControl();
            tabThanhToan = new TabPage();
            pnlThanhToanContent = new Panel();
            pnlRightTT = new Panel();
            grpThaoTacTT = new GroupBox();
            btnLapHoaDonBoSung = new Button();
            btnXacNhanThanhToan = new Button();
            chkLapHoaDonNgay = new CheckBox();
            cboPhuongThuc = new ComboBox();
            lblPhuongThuc = new Label();
            grpChiTietVeTT = new GroupBox();
            lblChiTietVeTTText = new Label();
            pnlLeftTT = new Panel();
            grpDanhSachVeTT = new GroupBox();
            dgvVeTT = new DataGridView();
            pnlFilterTT = new Panel();
            btnLamMoiVeTT = new Button();
            cboLocTrangThaiTT = new ComboBox();
            lblLocTrangThaiTT = new Label();
            txtTimVeTT = new TextBox();
            lblTimVeTT = new Label();
            tabQuanLyHoaDon = new TabPage();
            pnlHoaDonContent = new Panel();
            grpDanhSachHoaDon = new GroupBox();
            dgvHoaDon = new DataGridView();
            pnlActionsHoaDon = new Panel();
            btnInHoaDon = new Button();
            btnLamMoiHoaDon = new Button();
            grpFilterHoaDon = new GroupBox();
            btnTraCuuHoaDon = new Button();
            dtpDenNgay = new DateTimePicker();
            lblDenNgay = new Label();
            dtpTuNgay = new DateTimePicker();
            lblTuNgay = new Label();
            chkLocTheoNgay = new CheckBox();
            txtTimHoaDon = new TextBox();
            lblTimHoaDon = new Label();
            tabThongKe = new TabPage();
            pnlThongKeContent = new Panel();
            grpDoanhThuTuyenBay = new GroupBox();
            dgvDoanhThuTuyenBay = new DataGridView();
            grpDoanhThuPhuongThuc = new GroupBox();
            dgvDoanhThuPhuongThuc = new DataGridView();
            pnlCardsThongKe = new Panel();
            cardTrungBinh = new Panel();
            lblValTrungBinh = new Label();
            lblTitleTrungBinh = new Label();
            cardHoaDon = new Panel();
            lblValHoaDon = new Label();
            lblTitleHoaDon = new Label();
            cardVe = new Panel();
            lblValVe = new Label();
            lblTitleVe = new Label();
            cardDoanhThu = new Panel();
            lblValDoanhThu = new Label();
            lblTitleDoanhThu = new Label();
            pnlFilterThongKe = new Panel();
            btnXuatBaoCaoDoanhThu = new Button();
            cboMocThoiGian = new ComboBox();
            lblMocThoiGian = new Label();
            pnlContainer.SuspendLayout();
            tabCtrlKeToan.SuspendLayout();
            tabThanhToan.SuspendLayout();
            pnlThanhToanContent.SuspendLayout();
            pnlRightTT.SuspendLayout();
            grpThaoTacTT.SuspendLayout();
            grpChiTietVeTT.SuspendLayout();
            pnlLeftTT.SuspendLayout();
            grpDanhSachVeTT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVeTT).BeginInit();
            pnlFilterTT.SuspendLayout();
            tabQuanLyHoaDon.SuspendLayout();
            pnlHoaDonContent.SuspendLayout();
            grpDanhSachHoaDon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).BeginInit();
            pnlActionsHoaDon.SuspendLayout();
            grpFilterHoaDon.SuspendLayout();
            tabThongKe.SuspendLayout();
            pnlThongKeContent.SuspendLayout();
            grpDoanhThuTuyenBay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDoanhThuTuyenBay).BeginInit();
            grpDoanhThuPhuongThuc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDoanhThuPhuongThuc).BeginInit();
            pnlCardsThongKe.SuspendLayout();
            cardTrungBinh.SuspendLayout();
            cardHoaDon.SuspendLayout();
            cardVe.SuspendLayout();
            cardDoanhThu.SuspendLayout();
            pnlFilterThongKe.SuspendLayout();
            SuspendLayout();
            // 
            // pnlContainer
            // 
            pnlContainer.Controls.Add(tabCtrlKeToan);
            pnlContainer.Dock = DockStyle.Fill;
            pnlContainer.Location = new Point(0, 65);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Padding = new Padding(12);
            pnlContainer.Size = new Size(1180, 675);
            pnlContainer.TabIndex = 0;
            // 
            // tabCtrlKeToan
            // 
            tabCtrlKeToan.Controls.Add(tabThanhToan);
            tabCtrlKeToan.Controls.Add(tabQuanLyHoaDon);
            tabCtrlKeToan.Controls.Add(tabThongKe);
            tabCtrlKeToan.Dock = DockStyle.Fill;
            tabCtrlKeToan.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            tabCtrlKeToan.Location = new Point(12, 12);
            tabCtrlKeToan.Name = "tabCtrlKeToan";
            tabCtrlKeToan.SelectedIndex = 0;
            tabCtrlKeToan.Size = new Size(1156, 651);
            tabCtrlKeToan.TabIndex = 0;
            // 
            // tabThanhToan
            // 
            tabThanhToan.BackColor = Color.FromArgb(241, 245, 249);
            tabThanhToan.Controls.Add(pnlThanhToanContent);
            tabThanhToan.Location = new Point(4, 26);
            tabThanhToan.Name = "tabThanhToan";
            tabThanhToan.Padding = new Padding(10);
            tabThanhToan.Size = new Size(1148, 621);
            tabThanhToan.TabIndex = 0;
            tabThanhToan.Text = "💳 Kiểm tra & Xác nhận Thanh toán";
            // 
            // pnlThanhToanContent
            // 
            pnlThanhToanContent.Controls.Add(pnlRightTT);
            pnlThanhToanContent.Controls.Add(pnlLeftTT);
            pnlThanhToanContent.Dock = DockStyle.Fill;
            pnlThanhToanContent.Location = new Point(10, 10);
            pnlThanhToanContent.Name = "pnlThanhToanContent";
            pnlThanhToanContent.Size = new Size(1128, 601);
            pnlThanhToanContent.TabIndex = 0;
            // 
            // pnlRightTT
            // 
            pnlRightTT.Controls.Add(grpThaoTacTT);
            pnlRightTT.Controls.Add(grpChiTietVeTT);
            pnlRightTT.Dock = DockStyle.Fill;
            pnlRightTT.Location = new Point(710, 0);
            pnlRightTT.Name = "pnlRightTT";
            pnlRightTT.Padding = new Padding(10, 0, 0, 0);
            pnlRightTT.Size = new Size(418, 601);
            pnlRightTT.TabIndex = 1;
            // 
            // grpThaoTacTT
            // 
            grpThaoTacTT.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpThaoTacTT.BackColor = Color.White;
            grpThaoTacTT.Controls.Add(btnLapHoaDonBoSung);
            grpThaoTacTT.Controls.Add(btnXacNhanThanhToan);
            grpThaoTacTT.Controls.Add(chkLapHoaDonNgay);
            grpThaoTacTT.Controls.Add(cboPhuongThuc);
            grpThaoTacTT.Controls.Add(lblPhuongThuc);
            grpThaoTacTT.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpThaoTacTT.Location = new Point(10, 310);
            grpThaoTacTT.Name = "grpThaoTacTT";
            grpThaoTacTT.Size = new Size(408, 280);
            grpThaoTacTT.TabIndex = 1;
            grpThaoTacTT.TabStop = false;
            grpThaoTacTT.Text = "⚙️ Nghiệp vụ Xác nhận & Hóa đơn";
            // 
            // btnLapHoaDonBoSung
            // 
            btnLapHoaDonBoSung.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnLapHoaDonBoSung.Cursor = Cursors.Hand;
            btnLapHoaDonBoSung.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnLapHoaDonBoSung.Location = new Point(20, 205);
            btnLapHoaDonBoSung.Name = "btnLapHoaDonBoSung";
            btnLapHoaDonBoSung.Size = new Size(368, 48);
            btnLapHoaDonBoSung.TabIndex = 4;
            btnLapHoaDonBoSung.Text = "🧾 LẬP HÓA ĐƠN BỔ SUNG (Cho vé đã TT)";
            btnLapHoaDonBoSung.UseVisualStyleBackColor = true;
            btnLapHoaDonBoSung.Click += btnLapHoaDonBoSung_Click;
            // 
            // btnXacNhanThanhToan
            // 
            btnXacNhanThanhToan.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnXacNhanThanhToan.Cursor = Cursors.Hand;
            btnXacNhanThanhToan.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnXacNhanThanhToan.Location = new Point(20, 140);
            btnXacNhanThanhToan.Name = "btnXacNhanThanhToan";
            btnXacNhanThanhToan.Size = new Size(368, 52);
            btnXacNhanThanhToan.TabIndex = 3;
            btnXacNhanThanhToan.Text = "💰 XÁC NHẬN THANH TOÁN VÉ";
            btnXacNhanThanhToan.UseVisualStyleBackColor = true;
            btnXacNhanThanhToan.Click += btnXacNhanThanhToan_Click;
            // 
            // chkLapHoaDonNgay
            // 
            chkLapHoaDonNgay.AutoSize = true;
            chkLapHoaDonNgay.Checked = true;
            chkLapHoaDonNgay.CheckState = CheckState.Checked;
            chkLapHoaDonNgay.Font = new Font("Segoe UI", 9.5F);
            chkLapHoaDonNgay.ForeColor = Color.FromArgb(15, 23, 42);
            chkLapHoaDonNgay.Location = new Point(20, 95);
            chkLapHoaDonNgay.Name = "chkLapHoaDonNgay";
            chkLapHoaDonNgay.Size = new Size(244, 21);
            chkLapHoaDonNgay.TabIndex = 2;
            chkLapHoaDonNgay.Text = "Tự động lập hóa đơn sau khi thu tiền";
            chkLapHoaDonNgay.UseVisualStyleBackColor = true;
            // 
            // cboPhuongThuc
            // 
            cboPhuongThuc.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboPhuongThuc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPhuongThuc.Font = new Font("Segoe UI", 9.5F);
            cboPhuongThuc.FormattingEnabled = true;
            cboPhuongThuc.Location = new Point(20, 55);
            cboPhuongThuc.Name = "cboPhuongThuc";
            cboPhuongThuc.Size = new Size(368, 24);
            cboPhuongThuc.TabIndex = 1;
            // 
            // lblPhuongThuc
            // 
            lblPhuongThuc.Font = new Font("Segoe UI", 9F);
            lblPhuongThuc.Location = new Point(20, 30);
            lblPhuongThuc.Name = "lblPhuongThuc";
            lblPhuongThuc.Size = new Size(300, 20);
            lblPhuongThuc.TabIndex = 0;
            lblPhuongThuc.Text = "Phương thức thu tiền:";
            // 
            // grpChiTietVeTT
            // 
            grpChiTietVeTT.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpChiTietVeTT.BackColor = Color.White;
            grpChiTietVeTT.Controls.Add(lblChiTietVeTTText);
            grpChiTietVeTT.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpChiTietVeTT.Location = new Point(10, 0);
            grpChiTietVeTT.Name = "grpChiTietVeTT";
            grpChiTietVeTT.Padding = new Padding(12);
            grpChiTietVeTT.Size = new Size(408, 295);
            grpChiTietVeTT.TabIndex = 0;
            grpChiTietVeTT.TabStop = false;
            grpChiTietVeTT.Text = "📋 Thông tin Chi tiết Vé";
            // 
            // lblChiTietVeTTText
            // 
            lblChiTietVeTTText.Dock = DockStyle.Fill;
            lblChiTietVeTTText.Font = new Font("Segoe UI", 9.5F);
            lblChiTietVeTTText.ForeColor = Color.FromArgb(15, 23, 42);
            lblChiTietVeTTText.Location = new Point(12, 30);
            lblChiTietVeTTText.Name = "lblChiTietVeTTText";
            lblChiTietVeTTText.Size = new Size(384, 253);
            lblChiTietVeTTText.TabIndex = 0;
            lblChiTietVeTTText.Text = "Vui lòng chọn 1 vé trong bảng bên trái để kiểm tra thông tin và thực hiện xác nhận thanh toán.";
            // 
            // pnlLeftTT
            // 
            pnlLeftTT.Controls.Add(grpDanhSachVeTT);
            pnlLeftTT.Controls.Add(pnlFilterTT);
            pnlLeftTT.Dock = DockStyle.Left;
            pnlLeftTT.Location = new Point(0, 0);
            pnlLeftTT.Name = "pnlLeftTT";
            pnlLeftTT.Size = new Size(710, 601);
            pnlLeftTT.TabIndex = 0;
            // 
            // grpDanhSachVeTT
            // 
            grpDanhSachVeTT.BackColor = Color.White;
            grpDanhSachVeTT.Controls.Add(dgvVeTT);
            grpDanhSachVeTT.Dock = DockStyle.Fill;
            grpDanhSachVeTT.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpDanhSachVeTT.Location = new Point(0, 70);
            grpDanhSachVeTT.Name = "grpDanhSachVeTT";
            grpDanhSachVeTT.Padding = new Padding(8);
            grpDanhSachVeTT.Size = new Size(710, 531);
            grpDanhSachVeTT.TabIndex = 1;
            grpDanhSachVeTT.TabStop = false;
            grpDanhSachVeTT.Text = "📋 Danh sách Vé cần kiểm tra & thu tiền";
            // 
            // dgvVeTT
            // 
            dgvVeTT.AllowUserToAddRows = false;
            dgvVeTT.AllowUserToDeleteRows = false;
            dgvVeTT.BackgroundColor = Color.White;
            dgvVeTT.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVeTT.Dock = DockStyle.Fill;
            dgvVeTT.Location = new Point(8, 25);
            dgvVeTT.Name = "dgvVeTT";
            dgvVeTT.ReadOnly = true;
            dgvVeTT.RowTemplate.Height = 36;
            dgvVeTT.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVeTT.Size = new Size(694, 498);
            dgvVeTT.TabIndex = 0;
            dgvVeTT.CellClick += dgvVeTT_CellClick;
            // 
            // pnlFilterTT
            // 
            pnlFilterTT.BackColor = Color.White;
            pnlFilterTT.Controls.Add(btnLamMoiVeTT);
            pnlFilterTT.Controls.Add(cboLocTrangThaiTT);
            pnlFilterTT.Controls.Add(lblLocTrangThaiTT);
            pnlFilterTT.Controls.Add(txtTimVeTT);
            pnlFilterTT.Controls.Add(lblTimVeTT);
            pnlFilterTT.Dock = DockStyle.Top;
            pnlFilterTT.Location = new Point(0, 0);
            pnlFilterTT.Name = "pnlFilterTT";
            pnlFilterTT.Size = new Size(710, 70);
            pnlFilterTT.TabIndex = 0;
            // 
            // btnLamMoiVeTT
            // 
            btnLamMoiVeTT.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLamMoiVeTT.Cursor = Cursors.Hand;
            btnLamMoiVeTT.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLamMoiVeTT.Location = new Point(590, 18);
            btnLamMoiVeTT.Name = "btnLamMoiVeTT";
            btnLamMoiVeTT.Size = new Size(105, 34);
            btnLamMoiVeTT.TabIndex = 4;
            btnLamMoiVeTT.Text = "🔄 Làm mới";
            btnLamMoiVeTT.UseVisualStyleBackColor = true;
            btnLamMoiVeTT.Click += btnLamMoiVeTT_Click;
            // 
            // cboLocTrangThaiTT
            // 
            cboLocTrangThaiTT.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLocTrangThaiTT.Font = new Font("Segoe UI", 9F);
            cboLocTrangThaiTT.FormattingEnabled = true;
            cboLocTrangThaiTT.Location = new Point(410, 24);
            cboLocTrangThaiTT.Name = "cboLocTrangThaiTT";
            cboLocTrangThaiTT.Size = new Size(160, 23);
            cboLocTrangThaiTT.TabIndex = 3;
            cboLocTrangThaiTT.SelectedIndexChanged += cboLocTrangThaiTT_SelectedIndexChanged;
            // 
            // lblLocTrangThaiTT
            // 
            lblLocTrangThaiTT.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblLocTrangThaiTT.Location = new Point(325, 24);
            lblLocTrangThaiTT.Name = "lblLocTrangThaiTT";
            lblLocTrangThaiTT.Size = new Size(80, 23);
            lblLocTrangThaiTT.TabIndex = 2;
            lblLocTrangThaiTT.Text = "Trạng thái:";
            lblLocTrangThaiTT.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtTimVeTT
            // 
            txtTimVeTT.Font = new Font("Segoe UI", 9.5F);
            txtTimVeTT.Location = new Point(125, 24);
            txtTimVeTT.Name = "txtTimVeTT";
            txtTimVeTT.PlaceholderText = "Mã vé, tên khách, SĐT...";
            txtTimVeTT.Size = new Size(185, 24);
            txtTimVeTT.TabIndex = 1;
            txtTimVeTT.TextChanged += txtTimVeTT_TextChanged;
            // 
            // lblTimVeTT
            // 
            lblTimVeTT.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTimVeTT.Location = new Point(10, 24);
            lblTimVeTT.Name = "lblTimVeTT";
            lblTimVeTT.Size = new Size(110, 24);
            lblTimVeTT.TabIndex = 0;
            lblTimVeTT.Text = "Kiểm tra vé:";
            lblTimVeTT.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tabQuanLyHoaDon
            // 
            tabQuanLyHoaDon.BackColor = Color.FromArgb(241, 245, 249);
            tabQuanLyHoaDon.Controls.Add(pnlHoaDonContent);
            tabQuanLyHoaDon.Controls.Add(grpFilterHoaDon);
            tabQuanLyHoaDon.Location = new Point(4, 26);
            tabQuanLyHoaDon.Name = "tabQuanLyHoaDon";
            tabQuanLyHoaDon.Padding = new Padding(10);
            tabQuanLyHoaDon.Size = new Size(1148, 621);
            tabQuanLyHoaDon.TabIndex = 1;
            tabQuanLyHoaDon.Text = "🧾 Lập & Quản lý Hóa đơn";
            // 
            // pnlHoaDonContent
            // 
            pnlHoaDonContent.Controls.Add(grpDanhSachHoaDon);
            pnlHoaDonContent.Controls.Add(pnlActionsHoaDon);
            pnlHoaDonContent.Dock = DockStyle.Fill;
            pnlHoaDonContent.Location = new Point(10, 95);
            pnlHoaDonContent.Name = "pnlHoaDonContent";
            pnlHoaDonContent.Size = new Size(1128, 516);
            pnlHoaDonContent.TabIndex = 1;
            // 
            // grpDanhSachHoaDon
            // 
            grpDanhSachHoaDon.BackColor = Color.White;
            grpDanhSachHoaDon.Controls.Add(dgvHoaDon);
            grpDanhSachHoaDon.Dock = DockStyle.Fill;
            grpDanhSachHoaDon.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpDanhSachHoaDon.Location = new Point(0, 0);
            grpDanhSachHoaDon.Name = "grpDanhSachHoaDon";
            grpDanhSachHoaDon.Padding = new Padding(8);
            grpDanhSachHoaDon.Size = new Size(1128, 456);
            grpDanhSachHoaDon.TabIndex = 0;
            grpDanhSachHoaDon.TabStop = false;
            grpDanhSachHoaDon.Text = "📋 Danh sách Hóa đơn tài chính đã lập";
            // 
            // dgvHoaDon
            // 
            dgvHoaDon.AllowUserToAddRows = false;
            dgvHoaDon.AllowUserToDeleteRows = false;
            dgvHoaDon.BackgroundColor = Color.White;
            dgvHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoaDon.Dock = DockStyle.Fill;
            dgvHoaDon.Location = new Point(8, 25);
            dgvHoaDon.Name = "dgvHoaDon";
            dgvHoaDon.ReadOnly = true;
            dgvHoaDon.RowTemplate.Height = 36;
            dgvHoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHoaDon.Size = new Size(1112, 423);
            dgvHoaDon.TabIndex = 0;
            // 
            // pnlActionsHoaDon
            // 
            pnlActionsHoaDon.BackColor = Color.White;
            pnlActionsHoaDon.Controls.Add(btnInHoaDon);
            pnlActionsHoaDon.Controls.Add(btnLamMoiHoaDon);
            pnlActionsHoaDon.Dock = DockStyle.Bottom;
            pnlActionsHoaDon.Location = new Point(0, 456);
            pnlActionsHoaDon.Name = "pnlActionsHoaDon";
            pnlActionsHoaDon.Size = new Size(1128, 60);
            pnlActionsHoaDon.TabIndex = 1;
            // 
            // btnInHoaDon
            // 
            btnInHoaDon.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnInHoaDon.Cursor = Cursors.Hand;
            btnInHoaDon.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnInHoaDon.Location = new Point(888, 10);
            btnInHoaDon.Name = "btnInHoaDon";
            btnInHoaDon.Size = new Size(225, 42);
            btnInHoaDon.TabIndex = 1;
            btnInHoaDon.Text = "🖨️ Xem & In Hóa đơn điện tử";
            btnInHoaDon.UseVisualStyleBackColor = true;
            btnInHoaDon.Click += btnInHoaDon_Click;
            // 
            // btnLamMoiHoaDon
            // 
            btnLamMoiHoaDon.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLamMoiHoaDon.Cursor = Cursors.Hand;
            btnLamMoiHoaDon.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnLamMoiHoaDon.Location = new Point(740, 10);
            btnLamMoiHoaDon.Name = "btnLamMoiHoaDon";
            btnLamMoiHoaDon.Size = new Size(135, 42);
            btnLamMoiHoaDon.TabIndex = 0;
            btnLamMoiHoaDon.Text = "🔄 Làm mới";
            btnLamMoiHoaDon.UseVisualStyleBackColor = true;
            btnLamMoiHoaDon.Click += btnLamMoiHoaDon_Click;
            // 
            // grpFilterHoaDon
            // 
            grpFilterHoaDon.BackColor = Color.White;
            grpFilterHoaDon.Controls.Add(btnTraCuuHoaDon);
            grpFilterHoaDon.Controls.Add(dtpDenNgay);
            grpFilterHoaDon.Controls.Add(lblDenNgay);
            grpFilterHoaDon.Controls.Add(dtpTuNgay);
            grpFilterHoaDon.Controls.Add(lblTuNgay);
            grpFilterHoaDon.Controls.Add(chkLocTheoNgay);
            grpFilterHoaDon.Controls.Add(txtTimHoaDon);
            grpFilterHoaDon.Controls.Add(lblTimHoaDon);
            grpFilterHoaDon.Dock = DockStyle.Top;
            grpFilterHoaDon.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpFilterHoaDon.Location = new Point(10, 10);
            grpFilterHoaDon.Name = "grpFilterHoaDon";
            grpFilterHoaDon.Size = new Size(1128, 85);
            grpFilterHoaDon.TabIndex = 0;
            grpFilterHoaDon.TabStop = false;
            grpFilterHoaDon.Text = "🔍 Tra cứu & Lọc hóa đơn";
            // 
            // btnTraCuuHoaDon
            // 
            btnTraCuuHoaDon.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTraCuuHoaDon.Cursor = Cursors.Hand;
            btnTraCuuHoaDon.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnTraCuuHoaDon.Location = new Point(998, 28);
            btnTraCuuHoaDon.Name = "btnTraCuuHoaDon";
            btnTraCuuHoaDon.Size = new Size(115, 36);
            btnTraCuuHoaDon.TabIndex = 7;
            btnTraCuuHoaDon.Text = "🔍 Tra cứu";
            btnTraCuuHoaDon.UseVisualStyleBackColor = true;
            btnTraCuuHoaDon.Click += btnTraCuuHoaDon_Click;
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            dtpDenNgay.Font = new Font("Segoe UI", 9F);
            dtpDenNgay.Format = DateTimePickerFormat.Custom;
            dtpDenNgay.Location = new Point(780, 35);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(140, 23);
            dtpDenNgay.TabIndex = 6;
            // 
            // lblDenNgay
            // 
            lblDenNgay.Font = new Font("Segoe UI", 9F);
            lblDenNgay.Location = new Point(705, 35);
            lblDenNgay.Name = "lblDenNgay";
            lblDenNgay.Size = new Size(70, 23);
            lblDenNgay.TabIndex = 5;
            lblDenNgay.Text = "Đến ngày:";
            lblDenNgay.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            dtpTuNgay.Font = new Font("Segoe UI", 9F);
            dtpTuNgay.Format = DateTimePickerFormat.Custom;
            dtpTuNgay.Location = new Point(555, 35);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(140, 23);
            dtpTuNgay.TabIndex = 4;
            // 
            // lblTuNgay
            // 
            lblTuNgay.Font = new Font("Segoe UI", 9F);
            lblTuNgay.Location = new Point(485, 35);
            lblTuNgay.Name = "lblTuNgay";
            lblTuNgay.Size = new Size(65, 23);
            lblTuNgay.TabIndex = 3;
            lblTuNgay.Text = "Từ ngày:";
            lblTuNgay.TextAlign = ContentAlignment.MiddleRight;
            // 
            // chkLocTheoNgay
            // 
            chkLocTheoNgay.AutoSize = true;
            chkLocTheoNgay.Font = new Font("Segoe UI", 9F);
            chkLocTheoNgay.Location = new Point(365, 37);
            chkLocTheoNgay.Name = "chkLocTheoNgay";
            chkLocTheoNgay.Size = new Size(100, 19);
            chkLocTheoNgay.TabIndex = 2;
            chkLocTheoNgay.Text = "Lọc theo ngày";
            chkLocTheoNgay.UseVisualStyleBackColor = true;
            // 
            // txtTimHoaDon
            // 
            txtTimHoaDon.Font = new Font("Segoe UI", 9.5F);
            txtTimHoaDon.Location = new Point(140, 35);
            txtTimHoaDon.Name = "txtTimHoaDon";
            txtTimHoaDon.PlaceholderText = "Mã HĐ, tên khách, SĐT...";
            txtTimHoaDon.Size = new Size(205, 24);
            txtTimHoaDon.TabIndex = 1;
            // 
            // lblTimHoaDon
            // 
            lblTimHoaDon.Font = new Font("Segoe UI", 9F);
            lblTimHoaDon.Location = new Point(15, 35);
            lblTimHoaDon.Name = "lblTimHoaDon";
            lblTimHoaDon.Size = new Size(120, 24);
            lblTimHoaDon.TabIndex = 0;
            lblTimHoaDon.Text = "Từ khóa hóa đơn:";
            lblTimHoaDon.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tabThongKe
            // 
            tabThongKe.BackColor = Color.FromArgb(241, 245, 249);
            tabThongKe.Controls.Add(pnlThongKeContent);
            tabThongKe.Controls.Add(pnlCardsThongKe);
            tabThongKe.Controls.Add(pnlFilterThongKe);
            tabThongKe.Location = new Point(4, 26);
            tabThongKe.Name = "tabThongKe";
            tabThongKe.Padding = new Padding(10);
            tabThongKe.Size = new Size(1148, 621);
            tabThongKe.TabIndex = 2;
            tabThongKe.Text = "📊 Thống kê Doanh thu";
            // 
            // pnlThongKeContent
            // 
            pnlThongKeContent.Controls.Add(grpDoanhThuTuyenBay);
            pnlThongKeContent.Controls.Add(grpDoanhThuPhuongThuc);
            pnlThongKeContent.Dock = DockStyle.Fill;
            pnlThongKeContent.Location = new Point(10, 175);
            pnlThongKeContent.Name = "pnlThongKeContent";
            pnlThongKeContent.Size = new Size(1128, 436);
            pnlThongKeContent.TabIndex = 2;
            // 
            // grpDoanhThuTuyenBay
            // 
            grpDoanhThuTuyenBay.BackColor = Color.White;
            grpDoanhThuTuyenBay.Controls.Add(dgvDoanhThuTuyenBay);
            grpDoanhThuTuyenBay.Dock = DockStyle.Fill;
            grpDoanhThuTuyenBay.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpDoanhThuTuyenBay.Location = new Point(540, 0);
            grpDoanhThuTuyenBay.Name = "grpDoanhThuTuyenBay";
            grpDoanhThuTuyenBay.Padding = new Padding(8);
            grpDoanhThuTuyenBay.Size = new Size(588, 436);
            grpDoanhThuTuyenBay.TabIndex = 1;
            grpDoanhThuTuyenBay.TabStop = false;
            grpDoanhThuTuyenBay.Text = "✈️ Doanh thu theo Tuyến bay";
            // 
            // dgvDoanhThuTuyenBay
            // 
            dgvDoanhThuTuyenBay.AllowUserToAddRows = false;
            dgvDoanhThuTuyenBay.AllowUserToDeleteRows = false;
            dgvDoanhThuTuyenBay.BackgroundColor = Color.White;
            dgvDoanhThuTuyenBay.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDoanhThuTuyenBay.Dock = DockStyle.Fill;
            dgvDoanhThuTuyenBay.Location = new Point(8, 25);
            dgvDoanhThuTuyenBay.Name = "dgvDoanhThuTuyenBay";
            dgvDoanhThuTuyenBay.ReadOnly = true;
            dgvDoanhThuTuyenBay.RowTemplate.Height = 36;
            dgvDoanhThuTuyenBay.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDoanhThuTuyenBay.Size = new Size(572, 403);
            dgvDoanhThuTuyenBay.TabIndex = 0;
            // 
            // grpDoanhThuPhuongThuc
            // 
            grpDoanhThuPhuongThuc.BackColor = Color.White;
            grpDoanhThuPhuongThuc.Controls.Add(dgvDoanhThuPhuongThuc);
            grpDoanhThuPhuongThuc.Dock = DockStyle.Left;
            grpDoanhThuPhuongThuc.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpDoanhThuPhuongThuc.Location = new Point(0, 0);
            grpDoanhThuPhuongThuc.Name = "grpDoanhThuPhuongThuc";
            grpDoanhThuPhuongThuc.Padding = new Padding(8);
            grpDoanhThuPhuongThuc.Size = new Size(540, 436);
            grpDoanhThuPhuongThuc.TabIndex = 0;
            grpDoanhThuPhuongThuc.TabStop = false;
            grpDoanhThuPhuongThuc.Text = "💳 Phân bổ theo Phương thức Thanh toán";
            // 
            // dgvDoanhThuPhuongThuc
            // 
            dgvDoanhThuPhuongThuc.AllowUserToAddRows = false;
            dgvDoanhThuPhuongThuc.AllowUserToDeleteRows = false;
            dgvDoanhThuPhuongThuc.BackgroundColor = Color.White;
            dgvDoanhThuPhuongThuc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDoanhThuPhuongThuc.Dock = DockStyle.Fill;
            dgvDoanhThuPhuongThuc.Location = new Point(8, 25);
            dgvDoanhThuPhuongThuc.Name = "dgvDoanhThuPhuongThuc";
            dgvDoanhThuPhuongThuc.ReadOnly = true;
            dgvDoanhThuPhuongThuc.RowTemplate.Height = 36;
            dgvDoanhThuPhuongThuc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDoanhThuPhuongThuc.Size = new Size(524, 403);
            dgvDoanhThuPhuongThuc.TabIndex = 0;
            // 
            // pnlCardsThongKe
            // 
            pnlCardsThongKe.Controls.Add(cardTrungBinh);
            pnlCardsThongKe.Controls.Add(cardHoaDon);
            pnlCardsThongKe.Controls.Add(cardVe);
            pnlCardsThongKe.Controls.Add(cardDoanhThu);
            pnlCardsThongKe.Dock = DockStyle.Top;
            pnlCardsThongKe.Location = new Point(10, 65);
            pnlCardsThongKe.Name = "pnlCardsThongKe";
            pnlCardsThongKe.Size = new Size(1128, 110);
            pnlCardsThongKe.TabIndex = 1;
            // 
            // cardTrungBinh
            // 
            cardTrungBinh.BackColor = Color.White;
            cardTrungBinh.Controls.Add(lblValTrungBinh);
            cardTrungBinh.Controls.Add(lblTitleTrungBinh);
            cardTrungBinh.Location = new Point(845, 10);
            cardTrungBinh.Name = "cardTrungBinh";
            cardTrungBinh.Size = new Size(265, 85);
            cardTrungBinh.TabIndex = 3;
            // 
            // lblValTrungBinh
            // 
            lblValTrungBinh.Font = new Font("Segoe UI", 13.5F, FontStyle.Bold);
            lblValTrungBinh.ForeColor = Color.FromArgb(14, 165, 233);
            lblValTrungBinh.Location = new Point(15, 38);
            lblValTrungBinh.Name = "lblValTrungBinh";
            lblValTrungBinh.Size = new Size(235, 32);
            lblValTrungBinh.TabIndex = 1;
            lblValTrungBinh.Text = "0 VNĐ";
            // 
            // lblTitleTrungBinh
            // 
            lblTitleTrungBinh.AutoSize = true;
            lblTitleTrungBinh.Font = new Font("Segoe UI", 9F);
            lblTitleTrungBinh.ForeColor = Color.FromArgb(100, 116, 139);
            lblTitleTrungBinh.Location = new Point(15, 15);
            lblTitleTrungBinh.Name = "lblTitleTrungBinh";
            lblTitleTrungBinh.Size = new Size(130, 15);
            lblTitleTrungBinh.TabIndex = 0;
            lblTitleTrungBinh.Text = "📈 Doanh thu TB / vé:";
            // 
            // cardHoaDon
            // 
            cardHoaDon.BackColor = Color.White;
            cardHoaDon.Controls.Add(lblValHoaDon);
            cardHoaDon.Controls.Add(lblTitleHoaDon);
            cardHoaDon.Location = new Point(565, 10);
            cardHoaDon.Name = "cardHoaDon";
            cardHoaDon.Size = new Size(265, 85);
            cardHoaDon.TabIndex = 2;
            // 
            // lblValHoaDon
            // 
            lblValHoaDon.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblValHoaDon.ForeColor = Color.FromArgb(245, 158, 11);
            lblValHoaDon.Location = new Point(15, 38);
            lblValHoaDon.Name = "lblValHoaDon";
            lblValHoaDon.Size = new Size(235, 32);
            lblValHoaDon.TabIndex = 1;
            lblValHoaDon.Text = "0";
            // 
            // lblTitleHoaDon
            // 
            lblTitleHoaDon.AutoSize = true;
            lblTitleHoaDon.Font = new Font("Segoe UI", 9F);
            lblTitleHoaDon.ForeColor = Color.FromArgb(100, 116, 139);
            lblTitleHoaDon.Location = new Point(15, 15);
            lblTitleHoaDon.Name = "lblTitleHoaDon";
            lblTitleHoaDon.Size = new Size(137, 15);
            lblTitleHoaDon.TabIndex = 0;
            lblTitleHoaDon.Text = "🧾 Hóa đơn đã xuất:";
            // 
            // cardVe
            // 
            cardVe.BackColor = Color.White;
            cardVe.Controls.Add(lblValVe);
            cardVe.Controls.Add(lblTitleVe);
            cardVe.Location = new Point(285, 10);
            cardVe.Name = "cardVe";
            cardVe.Size = new Size(265, 85);
            cardVe.TabIndex = 1;
            // 
            // lblValVe
            // 
            lblValVe.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblValVe.ForeColor = Color.FromArgb(2, 132, 199);
            lblValVe.Location = new Point(15, 38);
            lblValVe.Name = "lblValVe";
            lblValVe.Size = new Size(235, 32);
            lblValVe.TabIndex = 1;
            lblValVe.Text = "0";
            // 
            // lblTitleVe
            // 
            lblTitleVe.AutoSize = true;
            lblTitleVe.Font = new Font("Segoe UI", 9F);
            lblTitleVe.ForeColor = Color.FromArgb(100, 116, 139);
            lblTitleVe.Location = new Point(15, 15);
            lblTitleVe.Name = "lblTitleVe";
            lblTitleVe.Size = new Size(128, 15);
            lblTitleVe.TabIndex = 0;
            lblTitleVe.Text = "🎫 Vé đã thanh toán:";
            // 
            // cardDoanhThu
            // 
            cardDoanhThu.BackColor = Color.White;
            cardDoanhThu.Controls.Add(lblValDoanhThu);
            cardDoanhThu.Controls.Add(lblTitleDoanhThu);
            cardDoanhThu.Location = new Point(5, 10);
            cardDoanhThu.Name = "cardDoanhThu";
            cardDoanhThu.Size = new Size(265, 85);
            cardDoanhThu.TabIndex = 0;
            // 
            // lblValDoanhThu
            // 
            lblValDoanhThu.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblValDoanhThu.ForeColor = Color.FromArgb(16, 185, 129);
            lblValDoanhThu.Location = new Point(15, 38);
            lblValDoanhThu.Name = "lblValDoanhThu";
            lblValDoanhThu.Size = new Size(235, 32);
            lblValDoanhThu.TabIndex = 1;
            lblValDoanhThu.Text = "0 VNĐ";
            // 
            // lblTitleDoanhThu
            // 
            lblTitleDoanhThu.AutoSize = true;
            lblTitleDoanhThu.Font = new Font("Segoe UI", 9F);
            lblTitleDoanhThu.ForeColor = Color.FromArgb(100, 116, 139);
            lblTitleDoanhThu.Location = new Point(15, 15);
            lblTitleDoanhThu.Name = "lblTitleDoanhThu";
            lblTitleDoanhThu.Size = new Size(117, 15);
            lblTitleDoanhThu.TabIndex = 0;
            lblTitleDoanhThu.Text = "💰 Tổng Doanh thu:";
            // 
            // pnlFilterThongKe
            // 
            pnlFilterThongKe.BackColor = Color.White;
            pnlFilterThongKe.Controls.Add(btnXuatBaoCaoDoanhThu);
            pnlFilterThongKe.Controls.Add(cboMocThoiGian);
            pnlFilterThongKe.Controls.Add(lblMocThoiGian);
            pnlFilterThongKe.Dock = DockStyle.Top;
            pnlFilterThongKe.Location = new Point(10, 10);
            pnlFilterThongKe.Name = "pnlFilterThongKe";
            pnlFilterThongKe.Size = new Size(1128, 55);
            pnlFilterThongKe.TabIndex = 0;
            // 
            // btnXuatBaoCaoDoanhThu
            // 
            btnXuatBaoCaoDoanhThu.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnXuatBaoCaoDoanhThu.Cursor = Cursors.Hand;
            btnXuatBaoCaoDoanhThu.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnXuatBaoCaoDoanhThu.Location = new Point(888, 8);
            btnXuatBaoCaoDoanhThu.Name = "btnXuatBaoCaoDoanhThu";
            btnXuatBaoCaoDoanhThu.Size = new Size(225, 38);
            btnXuatBaoCaoDoanhThu.TabIndex = 2;
            btnXuatBaoCaoDoanhThu.Text = "📋 Xuất Bảng kê Doanh thu";
            btnXuatBaoCaoDoanhThu.UseVisualStyleBackColor = true;
            btnXuatBaoCaoDoanhThu.Click += btnXuatBaoCaoDoanhThu_Click;
            // 
            // cboMocThoiGian
            // 
            cboMocThoiGian.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMocThoiGian.Font = new Font("Segoe UI", 9.5F);
            cboMocThoiGian.FormattingEnabled = true;
            cboMocThoiGian.Location = new Point(170, 15);
            cboMocThoiGian.Name = "cboMocThoiGian";
            cboMocThoiGian.Size = new Size(220, 24);
            cboMocThoiGian.TabIndex = 1;
            cboMocThoiGian.SelectedIndexChanged += cboMocThoiGian_SelectedIndexChanged;
            // 
            // lblMocThoiGian
            // 
            lblMocThoiGian.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMocThoiGian.Location = new Point(15, 15);
            lblMocThoiGian.Name = "lblMocThoiGian";
            lblMocThoiGian.Size = new Size(150, 24);
            lblMocThoiGian.TabIndex = 0;
            lblMocThoiGian.Text = "Mốc thời gian báo cáo:";
            lblMocThoiGian.TextAlign = ContentAlignment.MiddleRight;
            // 
            // frmNhanVienKeToan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1180, 740);
            Controls.Add(pnlContainer);
            MinimumSize = new Size(1100, 700);
            Name = "frmNhanVienKeToan";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bộ phận Kế toán & Tài chính - Hệ thống Quản lý Bán vé";
            Load += frmNhanVienKeToan_Load;
            pnlContainer.ResumeLayout(false);
            tabCtrlKeToan.ResumeLayout(false);
            tabThanhToan.ResumeLayout(false);
            pnlThanhToanContent.ResumeLayout(false);
            pnlRightTT.ResumeLayout(false);
            grpThaoTacTT.ResumeLayout(false);
            grpThaoTacTT.PerformLayout();
            grpChiTietVeTT.ResumeLayout(false);
            pnlLeftTT.ResumeLayout(false);
            grpDanhSachVeTT.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvVeTT).EndInit();
            pnlFilterTT.ResumeLayout(false);
            pnlFilterTT.PerformLayout();
            tabQuanLyHoaDon.ResumeLayout(false);
            pnlHoaDonContent.ResumeLayout(false);
            grpDanhSachHoaDon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).EndInit();
            pnlActionsHoaDon.ResumeLayout(false);
            grpFilterHoaDon.ResumeLayout(false);
            grpFilterHoaDon.PerformLayout();
            tabThongKe.ResumeLayout(false);
            pnlThongKeContent.ResumeLayout(false);
            grpDoanhThuTuyenBay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDoanhThuTuyenBay).EndInit();
            grpDoanhThuPhuongThuc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDoanhThuPhuongThuc).EndInit();
            pnlCardsThongKe.ResumeLayout(false);
            cardTrungBinh.ResumeLayout(false);
            cardTrungBinh.PerformLayout();
            cardHoaDon.ResumeLayout(false);
            cardHoaDon.PerformLayout();
            cardVe.ResumeLayout(false);
            cardVe.PerformLayout();
            cardDoanhThu.ResumeLayout(false);
            cardDoanhThu.PerformLayout();
            pnlFilterThongKe.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlContainer;
        private TabControl tabCtrlKeToan;
        private TabPage tabThanhToan;
        private Panel pnlThanhToanContent;
        private Panel pnlLeftTT;
        private Panel pnlFilterTT;
        private Label lblTimVeTT;
        private TextBox txtTimVeTT;
        private Label lblLocTrangThaiTT;
        private ComboBox cboLocTrangThaiTT;
        private Button btnLamMoiVeTT;
        private GroupBox grpDanhSachVeTT;
        private DataGridView dgvVeTT;
        private Panel pnlRightTT;
        private GroupBox grpChiTietVeTT;
        private Label lblChiTietVeTTText;
        private GroupBox grpThaoTacTT;
        private Label lblPhuongThuc;
        private ComboBox cboPhuongThuc;
        private CheckBox chkLapHoaDonNgay;
        private Button btnXacNhanThanhToan;
        private Button btnLapHoaDonBoSung;
        private TabPage tabQuanLyHoaDon;
        private GroupBox grpFilterHoaDon;
        private Label lblTimHoaDon;
        private TextBox txtTimHoaDon;
        private CheckBox chkLocTheoNgay;
        private Label lblTuNgay;
        private DateTimePicker dtpTuNgay;
        private Label lblDenNgay;
        private DateTimePicker dtpDenNgay;
        private Button btnTraCuuHoaDon;
        private Panel pnlHoaDonContent;
        private GroupBox grpDanhSachHoaDon;
        private DataGridView dgvHoaDon;
        private Panel pnlActionsHoaDon;
        private Button btnLamMoiHoaDon;
        private Button btnInHoaDon;
        private TabPage tabThongKe;
        private Panel pnlFilterThongKe;
        private Label lblMocThoiGian;
        private ComboBox cboMocThoiGian;
        private Button btnXuatBaoCaoDoanhThu;
        private Panel pnlCardsThongKe;
        private Panel cardDoanhThu;
        private Label lblTitleDoanhThu;
        private Label lblValDoanhThu;
        private Panel cardVe;
        private Label lblTitleVe;
        private Label lblValVe;
        private Panel cardHoaDon;
        private Label lblTitleHoaDon;
        private Label lblValHoaDon;
        private Panel cardTrungBinh;
        private Label lblTitleTrungBinh;
        private Label lblValTrungBinh;
        private Panel pnlThongKeContent;
        private GroupBox grpDoanhThuPhuongThuc;
        private DataGridView dgvDoanhThuPhuongThuc;
        private GroupBox grpDoanhThuTuyenBay;
        private DataGridView dgvDoanhThuTuyenBay;
    }
}
