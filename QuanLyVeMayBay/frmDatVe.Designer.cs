namespace QuanLyVeMayBay
{
    partial class frmDatVe
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
            grpTimKiem = new GroupBox();
            lblSanBayDi = new Label();
            cboSanBayDi = new ComboBox();
            lblSanBayDen = new Label();
            cboSanBayDen = new ComboBox();
            lblNgayDi = new Label();
            dtpNgayDi = new DateTimePicker();
            btnTimKiem = new Button();
            grpDanhSach = new GroupBox();
            dgvChuyenBay = new DataGridView();
            grpChuyenBayChon = new GroupBox();
            lblChiTietChuyenBay = new Label();
            grpKhachHang = new GroupBox();
            lblHoTen = new Label();
            txtHoTen = new TextBox();
            lblCCCD = new Label();
            txtCCCD = new TextBox();
            lblSDT = new Label();
            txtSDT = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            grpGhe = new GroupBox();
            lblGheTrong = new Label();
            cboGhe = new ComboBox();
            lblGiaVe = new Label();
            txtGiaVe = new TextBox();
            btnDatVe = new Button();
            grpTimKiem.SuspendLayout();
            grpDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChuyenBay).BeginInit();
            grpChuyenBayChon.SuspendLayout();
            grpKhachHang.SuspendLayout();
            grpGhe.SuspendLayout();
            SuspendLayout();
            // 
            // lblTieuDe
            // 
            lblTieuDe.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTieuDe.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTieuDe.ForeColor = Color.FromArgb(15, 23, 42);
            lblTieuDe.Location = new Point(12, 12);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(956, 38);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "✈️ HỆ THỐNG ĐẶT VÉ MÁY BAY";
            lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // grpTimKiem
            // 
            grpTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpTimKiem.Controls.Add(lblSanBayDi);
            grpTimKiem.Controls.Add(cboSanBayDi);
            grpTimKiem.Controls.Add(lblSanBayDen);
            grpTimKiem.Controls.Add(cboSanBayDen);
            grpTimKiem.Controls.Add(lblNgayDi);
            grpTimKiem.Controls.Add(dtpNgayDi);
            grpTimKiem.Controls.Add(btnTimKiem);
            grpTimKiem.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpTimKiem.Location = new Point(12, 55);
            grpTimKiem.Name = "grpTimKiem";
            grpTimKiem.Size = new Size(956, 105);
            grpTimKiem.TabIndex = 1;
            grpTimKiem.TabStop = false;
            grpTimKiem.Text = "TÌM KIẾM CHUYẾN BAY";
            // 
            // lblSanBayDi
            // 
            lblSanBayDi.AutoSize = true;
            lblSanBayDi.Font = new Font("Segoe UI", 9F);
            lblSanBayDi.Location = new Point(15, 35);
            lblSanBayDi.Name = "lblSanBayDi";
            lblSanBayDi.Size = new Size(80, 20);
            lblSanBayDi.TabIndex = 0;
            lblSanBayDi.Text = "Sân bay đi:";
            // 
            // cboSanBayDi
            // 
            cboSanBayDi.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSanBayDi.Font = new Font("Segoe UI", 9F);
            cboSanBayDi.FormattingEnabled = true;
            cboSanBayDi.Location = new Point(100, 32);
            cboSanBayDi.Name = "cboSanBayDi";
            cboSanBayDi.Size = new Size(230, 28);
            cboSanBayDi.TabIndex = 1;
            // 
            // lblSanBayDen
            // 
            lblSanBayDen.AutoSize = true;
            lblSanBayDen.Font = new Font("Segoe UI", 9F);
            lblSanBayDen.Location = new Point(345, 35);
            lblSanBayDen.Name = "lblSanBayDen";
            lblSanBayDen.Size = new Size(90, 20);
            lblSanBayDen.TabIndex = 2;
            lblSanBayDen.Text = "Sân bay đến:";
            // 
            // cboSanBayDen
            // 
            cboSanBayDen.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSanBayDen.Font = new Font("Segoe UI", 9F);
            cboSanBayDen.FormattingEnabled = true;
            cboSanBayDen.Location = new Point(440, 32);
            cboSanBayDen.Name = "cboSanBayDen";
            cboSanBayDen.Size = new Size(230, 28);
            cboSanBayDen.TabIndex = 3;
            // 
            // lblNgayDi
            // 
            lblNgayDi.AutoSize = true;
            lblNgayDi.Font = new Font("Segoe UI", 9F);
            lblNgayDi.Location = new Point(690, 35);
            lblNgayDi.Name = "lblNgayDi";
            lblNgayDi.Size = new Size(65, 20);
            lblNgayDi.TabIndex = 4;
            lblNgayDi.Text = "Ngày đi:";
            // 
            // dtpNgayDi
            // 
            dtpNgayDi.Font = new Font("Segoe UI", 9F);
            dtpNgayDi.Format = DateTimePickerFormat.Short;
            dtpNgayDi.Location = new Point(760, 32);
            dtpNgayDi.Name = "dtpNgayDi";
            dtpNgayDi.Size = new Size(130, 27);
            dtpNgayDi.TabIndex = 5;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnTimKiem.Location = new Point(370, 68);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(220, 30);
            btnTimKiem.TabIndex = 6;
            btnTimKiem.Text = "🔍 Tìm kiếm chuyến bay";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // grpDanhSach
            // 
            grpDanhSach.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpDanhSach.Controls.Add(dgvChuyenBay);
            grpDanhSach.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpDanhSach.Location = new Point(12, 168);
            grpDanhSach.Name = "grpDanhSach";
            grpDanhSach.Size = new Size(956, 185);
            grpDanhSach.TabIndex = 2;
            grpDanhSach.TabStop = false;
            grpDanhSach.Text = "DANH SÁCH CHUYẾN BAY";
            // 
            // dgvChuyenBay
            // 
            dgvChuyenBay.AllowUserToAddRows = false;
            dgvChuyenBay.AllowUserToDeleteRows = false;
            dgvChuyenBay.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvChuyenBay.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChuyenBay.BackgroundColor = Color.White;
            dgvChuyenBay.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChuyenBay.Font = new Font("Segoe UI", 9F);
            dgvChuyenBay.Location = new Point(15, 27);
            dgvChuyenBay.MultiSelect = false;
            dgvChuyenBay.Name = "dgvChuyenBay";
            dgvChuyenBay.ReadOnly = true;
            dgvChuyenBay.RowHeadersVisible = false;
            dgvChuyenBay.RowHeadersWidth = 51;
            dgvChuyenBay.RowTemplate.Height = 28;
            dgvChuyenBay.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChuyenBay.Size = new Size(926, 143);
            dgvChuyenBay.TabIndex = 0;
            dgvChuyenBay.CellClick += dgvChuyenBay_CellClick;
            // 
            // grpChuyenBayChon
            // 
            grpChuyenBayChon.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpChuyenBayChon.Controls.Add(lblChiTietChuyenBay);
            grpChuyenBayChon.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpChuyenBayChon.Location = new Point(12, 360);
            grpChuyenBayChon.Name = "grpChuyenBayChon";
            grpChuyenBayChon.Size = new Size(956, 60);
            grpChuyenBayChon.TabIndex = 3;
            grpChuyenBayChon.TabStop = false;
            grpChuyenBayChon.Text = "CHUYẾN BAY ĐÃ CHỌN";
            // 
            // lblChiTietChuyenBay
            // 
            lblChiTietChuyenBay.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblChiTietChuyenBay.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblChiTietChuyenBay.ForeColor = Color.FromArgb(24, 76, 120);
            lblChiTietChuyenBay.Location = new Point(15, 27);
            lblChiTietChuyenBay.Name = "lblChiTietChuyenBay";
            lblChiTietChuyenBay.Size = new Size(926, 25);
            lblChiTietChuyenBay.TabIndex = 0;
            lblChiTietChuyenBay.Text = "(Chưa chọn chuyến bay)";
            // 
            // grpKhachHang
            // 
            grpKhachHang.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpKhachHang.Controls.Add(lblHoTen);
            grpKhachHang.Controls.Add(txtHoTen);
            grpKhachHang.Controls.Add(lblCCCD);
            grpKhachHang.Controls.Add(txtCCCD);
            grpKhachHang.Controls.Add(lblSDT);
            grpKhachHang.Controls.Add(txtSDT);
            grpKhachHang.Controls.Add(lblEmail);
            grpKhachHang.Controls.Add(txtEmail);
            grpKhachHang.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpKhachHang.Location = new Point(12, 428);
            grpKhachHang.Name = "grpKhachHang";
            grpKhachHang.Size = new Size(956, 105);
            grpKhachHang.TabIndex = 4;
            grpKhachHang.TabStop = false;
            grpKhachHang.Text = "THÔNG TIN KHÁCH HÀNG";
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Font = new Font("Segoe UI", 9F);
            lblHoTen.Location = new Point(15, 35);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(76, 20);
            lblHoTen.TabIndex = 0;
            lblHoTen.Text = "Họ và tên:";
            // 
            // txtHoTen
            // 
            txtHoTen.Font = new Font("Segoe UI", 9F);
            txtHoTen.Location = new Point(100, 32);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(190, 27);
            txtHoTen.TabIndex = 1;
            // 
            // lblCCCD
            // 
            lblCCCD.AutoSize = true;
            lblCCCD.Font = new Font("Segoe UI", 9F);
            lblCCCD.Location = new Point(310, 35);
            lblCCCD.Name = "lblCCCD";
            lblCCCD.Size = new Size(50, 20);
            lblCCCD.TabIndex = 2;
            lblCCCD.Text = "CCCD:";
            // 
            // txtCCCD
            // 
            txtCCCD.Font = new Font("Segoe UI", 9F);
            txtCCCD.Location = new Point(365, 32);
            txtCCCD.Name = "txtCCCD";
            txtCCCD.Size = new Size(160, 27);
            txtCCCD.TabIndex = 3;
            // 
            // lblSDT
            // 
            lblSDT.AutoSize = true;
            lblSDT.Font = new Font("Segoe UI", 9F);
            lblSDT.Location = new Point(545, 35);
            lblSDT.Name = "lblSDT";
            lblSDT.Size = new Size(100, 20);
            lblSDT.TabIndex = 4;
            lblSDT.Text = "Số điện thoại:";
            // 
            // txtSDT
            // 
            txtSDT.Font = new Font("Segoe UI", 9F);
            txtSDT.Location = new Point(650, 32);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(140, 27);
            txtSDT.TabIndex = 5;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9F);
            lblEmail.Location = new Point(15, 70);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(49, 20);
            lblEmail.TabIndex = 6;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 9F);
            txtEmail.Location = new Point(100, 67);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(290, 27);
            txtEmail.TabIndex = 7;
            // 
            // grpGhe
            // 
            grpGhe.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpGhe.Controls.Add(lblGheTrong);
            grpGhe.Controls.Add(cboGhe);
            grpGhe.Controls.Add(lblGiaVe);
            grpGhe.Controls.Add(txtGiaVe);
            grpGhe.Controls.Add(btnDatVe);
            grpGhe.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpGhe.Location = new Point(12, 541);
            grpGhe.Name = "grpGhe";
            grpGhe.Size = new Size(956, 75);
            grpGhe.TabIndex = 5;
            grpGhe.TabStop = false;
            grpGhe.Text = "CHỌN GHẾ ĐẶT VÉ";
            // 
            // lblGheTrong
            // 
            lblGheTrong.AutoSize = true;
            lblGheTrong.Font = new Font("Segoe UI", 9F);
            lblGheTrong.Location = new Point(15, 35);
            lblGheTrong.Name = "lblGheTrong";
            lblGheTrong.Size = new Size(77, 20);
            lblGheTrong.TabIndex = 0;
            lblGheTrong.Text = "Ghế trống:";
            // 
            // cboGhe
            // 
            cboGhe.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGhe.Font = new Font("Segoe UI", 9F);
            cboGhe.FormattingEnabled = true;
            cboGhe.Location = new Point(100, 32);
            cboGhe.Name = "cboGhe";
            cboGhe.Size = new Size(210, 28);
            cboGhe.TabIndex = 1;
            // 
            // lblGiaVe
            // 
            lblGiaVe.AutoSize = true;
            lblGiaVe.Font = new Font("Segoe UI", 9F);
            lblGiaVe.Location = new Point(325, 35);
            lblGiaVe.Name = "lblGiaVe";
            lblGiaVe.Size = new Size(54, 20);
            lblGiaVe.TabIndex = 2;
            lblGiaVe.Text = "Giá vé:";
            // 
            // txtGiaVe
            // 
            txtGiaVe.Font = new Font("Segoe UI", 9F);
            txtGiaVe.Location = new Point(385, 32);
            txtGiaVe.Name = "txtGiaVe";
            txtGiaVe.ReadOnly = true;
            txtGiaVe.Size = new Size(200, 27);
            txtGiaVe.TabIndex = 3;
            // 
            // btnDatVe
            // 
            btnDatVe.BackColor = Color.FromArgb(16, 185, 129);
            btnDatVe.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnDatVe.ForeColor = Color.White;
            btnDatVe.Location = new Point(750, 24);
            btnDatVe.Name = "btnDatVe";
            btnDatVe.Size = new Size(190, 42);
            btnDatVe.TabIndex = 4;
            btnDatVe.Text = "✈️ ĐẶT VÉ NGAY";
            btnDatVe.UseVisualStyleBackColor = false;
            btnDatVe.Click += btnDatVe_Click;
            // 
            // frmDatVe
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(980, 630);
            Controls.Add(lblTieuDe);
            Controls.Add(grpTimKiem);
            Controls.Add(grpDanhSach);
            Controls.Add(grpChuyenBayChon);
            Controls.Add(grpKhachHang);
            Controls.Add(grpGhe);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(800, 680);
            Name = "frmDatVe";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HỆ THỐNG ĐẶT VÉ MÁY BAY";
            Load += frmDatVe_Load;
            grpTimKiem.ResumeLayout(false);
            grpTimKiem.PerformLayout();
            grpDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvChuyenBay).EndInit();
            grpChuyenBayChon.ResumeLayout(false);
            grpKhachHang.ResumeLayout(false);
            grpKhachHang.PerformLayout();
            grpGhe.ResumeLayout(false);
            grpGhe.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTieuDe;
        private GroupBox grpTimKiem;
        private Label lblSanBayDi;
        private ComboBox cboSanBayDi;
        private Label lblSanBayDen;
        private ComboBox cboSanBayDen;
        private Label lblNgayDi;
        private DateTimePicker dtpNgayDi;
        private Button btnTimKiem;
        private GroupBox grpDanhSach;
        private DataGridView dgvChuyenBay;
        private GroupBox grpChuyenBayChon;
        private Label lblChiTietChuyenBay;
        private GroupBox grpKhachHang;
        private Label lblHoTen;
        private TextBox txtHoTen;
        private Label lblCCCD;
        private TextBox txtCCCD;
        private Label lblSDT;
        private TextBox txtSDT;
        private Label lblEmail;
        private TextBox txtEmail;
        private GroupBox grpGhe;
        private Label lblGheTrong;
        private ComboBox cboGhe;
        private Label lblGiaVe;
        private TextBox txtGiaVe;
        private Button btnDatVe;
    }
}
