namespace QuanLyVeMayBay
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTieuDe = new Label();
            grpThongTin = new GroupBox();
            lblMaChuyenBay = new Label();
            txtMaChuyenBay = new TextBox();
            lblMaMayBay = new Label();
            cboMaMayBay = new ComboBox();
            lblSanBayDi = new Label();
            cboSanBayDi = new ComboBox();
            lblSanBayDen = new Label();
            cboSanBayDen = new ComboBox();
            lblThoiGianDi = new Label();
            dtpThoiGianDi = new DateTimePicker();
            lblThoiGianDen = new Label();
            dtpThoiGianDen = new DateTimePicker();
            lblGiaVe = new Label();
            txtGiaVe = new TextBox();
            lblTrangThai = new Label();
            cboTrangThai = new ComboBox();
            pnlChucNang = new Panel();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            btnMoDatVe = new Button();
            btnMoThanhToan = new Button();
            grpDanhSach = new GroupBox();
            dgvChuyenBay = new DataGridView();
            grpThongTin.SuspendLayout();
            pnlChucNang.SuspendLayout();
            grpDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChuyenBay).BeginInit();
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
            lblTieuDe.Text = "✈️ HỆ THỐNG QUẢN LÝ CHUYẾN BAY";
            lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // grpThongTin
            // 
            grpThongTin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpThongTin.Controls.Add(lblMaChuyenBay);
            grpThongTin.Controls.Add(txtMaChuyenBay);
            grpThongTin.Controls.Add(lblMaMayBay);
            grpThongTin.Controls.Add(cboMaMayBay);
            grpThongTin.Controls.Add(lblSanBayDi);
            grpThongTin.Controls.Add(cboSanBayDi);
            grpThongTin.Controls.Add(lblSanBayDen);
            grpThongTin.Controls.Add(cboSanBayDen);
            grpThongTin.Controls.Add(lblThoiGianDi);
            grpThongTin.Controls.Add(dtpThoiGianDi);
            grpThongTin.Controls.Add(lblThoiGianDen);
            grpThongTin.Controls.Add(dtpThoiGianDen);
            grpThongTin.Controls.Add(lblGiaVe);
            grpThongTin.Controls.Add(txtGiaVe);
            grpThongTin.Controls.Add(lblTrangThai);
            grpThongTin.Controls.Add(cboTrangThai);
            grpThongTin.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpThongTin.Location = new Point(16, 53);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Size = new Size(948, 178);
            grpThongTin.TabIndex = 1;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "Thông tin chuyến bay";
            // 
            // lblMaChuyenBay
            // 
            lblMaChuyenBay.AutoSize = true;
            lblMaChuyenBay.Font = new Font("Segoe UI", 9F);
            lblMaChuyenBay.Location = new Point(25, 32);
            lblMaChuyenBay.Name = "lblMaChuyenBay";
            lblMaChuyenBay.Size = new Size(111, 20);
            lblMaChuyenBay.TabIndex = 0;
            lblMaChuyenBay.Text = "Mã chuyến bay:";
            // 
            // txtMaChuyenBay
            // 
            txtMaChuyenBay.Font = new Font("Segoe UI", 9F);
            txtMaChuyenBay.Location = new Point(145, 29);
            txtMaChuyenBay.Name = "txtMaChuyenBay";
            txtMaChuyenBay.ReadOnly = true;
            txtMaChuyenBay.Size = new Size(295, 27);
            txtMaChuyenBay.TabIndex = 1;
            // 
            // lblMaMayBay
            // 
            lblMaMayBay.AutoSize = true;
            lblMaMayBay.Font = new Font("Segoe UI", 9F);
            lblMaMayBay.Location = new Point(25, 68);
            lblMaMayBay.Name = "lblMaMayBay";
            lblMaMayBay.Size = new Size(92, 20);
            lblMaMayBay.TabIndex = 2;
            lblMaMayBay.Text = "Mã máy bay:";
            // 
            // cboMaMayBay
            // 
            cboMaMayBay.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMaMayBay.Font = new Font("Segoe UI", 9F);
            cboMaMayBay.FormattingEnabled = true;
            cboMaMayBay.Location = new Point(145, 65);
            cboMaMayBay.Name = "cboMaMayBay";
            cboMaMayBay.Size = new Size(295, 28);
            cboMaMayBay.TabIndex = 3;
            // 
            // lblSanBayDi
            // 
            lblSanBayDi.AutoSize = true;
            lblSanBayDi.Font = new Font("Segoe UI", 9F);
            lblSanBayDi.Location = new Point(25, 104);
            lblSanBayDi.Name = "lblSanBayDi";
            lblSanBayDi.Size = new Size(81, 20);
            lblSanBayDi.TabIndex = 4;
            lblSanBayDi.Text = "Sân bay đi:";
            // 
            // cboSanBayDi
            // 
            cboSanBayDi.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSanBayDi.Font = new Font("Segoe UI", 9F);
            cboSanBayDi.FormattingEnabled = true;
            cboSanBayDi.Location = new Point(145, 101);
            cboSanBayDi.Name = "cboSanBayDi";
            cboSanBayDi.Size = new Size(295, 28);
            cboSanBayDi.TabIndex = 5;
            // 
            // lblSanBayDen
            // 
            lblSanBayDen.AutoSize = true;
            lblSanBayDen.Font = new Font("Segoe UI", 9F);
            lblSanBayDen.Location = new Point(25, 140);
            lblSanBayDen.Name = "lblSanBayDen";
            lblSanBayDen.Size = new Size(93, 20);
            lblSanBayDen.TabIndex = 6;
            lblSanBayDen.Text = "Sân bay đến:";
            // 
            // cboSanBayDen
            // 
            cboSanBayDen.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSanBayDen.Font = new Font("Segoe UI", 9F);
            cboSanBayDen.FormattingEnabled = true;
            cboSanBayDen.Location = new Point(145, 137);
            cboSanBayDen.Name = "cboSanBayDen";
            cboSanBayDen.Size = new Size(295, 28);
            cboSanBayDen.TabIndex = 7;
            // 
            // lblThoiGianDi
            // 
            lblThoiGianDi.AutoSize = true;
            lblThoiGianDi.Font = new Font("Segoe UI", 9F);
            lblThoiGianDi.Location = new Point(480, 32);
            lblThoiGianDi.Name = "lblThoiGianDi";
            lblThoiGianDi.Size = new Size(91, 20);
            lblThoiGianDi.TabIndex = 8;
            lblThoiGianDi.Text = "Thời gian đi:";
            // 
            // dtpThoiGianDi
            // 
            dtpThoiGianDi.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtpThoiGianDi.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpThoiGianDi.Font = new Font("Segoe UI", 9F);
            dtpThoiGianDi.Format = DateTimePickerFormat.Custom;
            dtpThoiGianDi.Location = new Point(600, 29);
            dtpThoiGianDi.Name = "dtpThoiGianDi";
            dtpThoiGianDi.Size = new Size(325, 27);
            dtpThoiGianDi.TabIndex = 9;
            // 
            // lblThoiGianDen
            // 
            lblThoiGianDen.AutoSize = true;
            lblThoiGianDen.Font = new Font("Segoe UI", 9F);
            lblThoiGianDen.Location = new Point(480, 68);
            lblThoiGianDen.Name = "lblThoiGianDen";
            lblThoiGianDen.Size = new Size(103, 20);
            lblThoiGianDen.TabIndex = 10;
            lblThoiGianDen.Text = "Thời gian đến:";
            // 
            // dtpThoiGianDen
            // 
            dtpThoiGianDen.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtpThoiGianDen.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpThoiGianDen.Font = new Font("Segoe UI", 9F);
            dtpThoiGianDen.Format = DateTimePickerFormat.Custom;
            dtpThoiGianDen.Location = new Point(600, 65);
            dtpThoiGianDen.Name = "dtpThoiGianDen";
            dtpThoiGianDen.Size = new Size(325, 27);
            dtpThoiGianDen.TabIndex = 11;
            // 
            // lblGiaVe
            // 
            lblGiaVe.AutoSize = true;
            lblGiaVe.Font = new Font("Segoe UI", 9F);
            lblGiaVe.Location = new Point(480, 104);
            lblGiaVe.Name = "lblGiaVe";
            lblGiaVe.Size = new Size(54, 20);
            lblGiaVe.TabIndex = 12;
            lblGiaVe.Text = "Giá vé:";
            // 
            // txtGiaVe
            // 
            txtGiaVe.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtGiaVe.Font = new Font("Segoe UI", 9F);
            txtGiaVe.Location = new Point(600, 101);
            txtGiaVe.Name = "txtGiaVe";
            txtGiaVe.Size = new Size(325, 27);
            txtGiaVe.TabIndex = 13;
            // 
            // lblTrangThai
            // 
            lblTrangThai.AutoSize = true;
            lblTrangThai.Font = new Font("Segoe UI", 9F);
            lblTrangThai.Location = new Point(480, 140);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(78, 20);
            lblTrangThai.TabIndex = 14;
            lblTrangThai.Text = "Trạng thái:";
            // 
            // cboTrangThai
            // 
            cboTrangThai.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboTrangThai.Font = new Font("Segoe UI", 9F);
            cboTrangThai.FormattingEnabled = true;
            cboTrangThai.Location = new Point(600, 137);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(325, 28);
            cboTrangThai.TabIndex = 15;
            // 
            // pnlChucNang
            // 
            pnlChucNang.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlChucNang.Controls.Add(btnThem);
            pnlChucNang.Controls.Add(btnSua);
            pnlChucNang.Controls.Add(btnXoa);
            pnlChucNang.Controls.Add(btnLamMoi);
            pnlChucNang.Controls.Add(btnMoDatVe);
            pnlChucNang.Controls.Add(btnMoThanhToan);
            pnlChucNang.Location = new Point(16, 237);
            pnlChucNang.Name = "pnlChucNang";
            pnlChucNang.Size = new Size(948, 48);
            pnlChucNang.TabIndex = 2;
            // 
            // btnThem
            // 
            btnThem.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnThem.Location = new Point(12, 6);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(118, 36);
            btnThem.TabIndex = 0;
            btnThem.Text = "➕ Thêm mới";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnSua.Location = new Point(138, 6);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(118, 36);
            btnSua.TabIndex = 1;
            btnSua.Text = "✏️ Cập nhật";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnXoa.Location = new Point(264, 6);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(118, 36);
            btnXoa.TabIndex = 2;
            btnXoa.Text = "🗑️ Xóa chuyến";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnLamMoi.Location = new Point(390, 6);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(118, 36);
            btnLamMoi.TabIndex = 3;
            btnLamMoi.Text = "🔄 Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnMoDatVe
            // 
            btnMoDatVe.BackColor = Color.FromArgb(0, 122, 204);
            btnMoDatVe.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnMoDatVe.ForeColor = Color.White;
            btnMoDatVe.Location = new Point(516, 6);
            btnMoDatVe.Name = "btnMoDatVe";
            btnMoDatVe.Size = new Size(175, 36);
            btnMoDatVe.TabIndex = 4;
            btnMoDatVe.Text = "✈️ Đặt vé máy bay";
            btnMoDatVe.UseVisualStyleBackColor = false;
            btnMoDatVe.Click += btnMoDatVe_Click;
            // 
            // btnMoThanhToan
            // 
            btnMoThanhToan.BackColor = Color.FromArgb(16, 185, 129);
            btnMoThanhToan.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnMoThanhToan.ForeColor = Color.White;
            btnMoThanhToan.Location = new Point(699, 6);
            btnMoThanhToan.Name = "btnMoThanhToan";
            btnMoThanhToan.Size = new Size(235, 36);
            btnMoThanhToan.TabIndex = 5;
            btnMoThanhToan.Text = "💳 Thanh toán && Hóa đơn";
            btnMoThanhToan.UseVisualStyleBackColor = false;
            btnMoThanhToan.Click += btnMoThanhToan_Click;
            // 
            // grpDanhSach
            // 
            grpDanhSach.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpDanhSach.Controls.Add(dgvChuyenBay);
            grpDanhSach.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpDanhSach.Location = new Point(16, 291);
            grpDanhSach.Name = "grpDanhSach";
            grpDanhSach.Size = new Size(948, 335);
            grpDanhSach.TabIndex = 3;
            grpDanhSach.TabStop = false;
            grpDanhSach.Text = "Danh sách chuyến bay";
            // 
            // dgvChuyenBay
            // 
            dgvChuyenBay.AllowUserToAddRows = false;
            dgvChuyenBay.AllowUserToDeleteRows = false;
            dgvChuyenBay.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
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
            dgvChuyenBay.Size = new Size(918, 293);
            dgvChuyenBay.TabIndex = 0;
            dgvChuyenBay.CellClick += dgvChuyenBay_CellClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(980, 640);
            Controls.Add(grpDanhSach);
            Controls.Add(pnlChucNang);
            Controls.Add(grpThongTin);
            Controls.Add(lblTieuDe);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(800, 500);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "QUẢN LÝ CHUYẾN BAY";
            Load += Form1_Load;
            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            pnlChucNang.ResumeLayout(false);
            grpDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvChuyenBay).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTieuDe;
        private GroupBox grpThongTin;
        private Label lblMaChuyenBay;
        private TextBox txtMaChuyenBay;
        private Label lblMaMayBay;
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
        private Panel pnlChucNang;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Button btnMoDatVe;
        private Button btnMoThanhToan;
        private GroupBox grpDanhSach;
        private DataGridView dgvChuyenBay;
    }
}
