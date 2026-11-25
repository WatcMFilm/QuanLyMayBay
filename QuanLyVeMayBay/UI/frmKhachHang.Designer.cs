namespace QuanLyVeMayBay
{
    partial class frmKhachHang
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
            grpThongTin = new GroupBox();
            lblMaKH = new Label();
            txtMaKH = new TextBox();
            lblHoTen = new Label();
            txtHoTen = new TextBox();
            lblCCCD = new Label();
            txtCCCD = new TextBox();
            lblSDT = new Label();
            txtSDT = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblTimKiem = new Label();
            txtTimKiem = new TextBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            grpDanhSach = new GroupBox();
            dgvKhachHang = new DataGridView();
            grpThongTin.SuspendLayout();
            grpDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKhachHang).BeginInit();
            SuspendLayout();
            //
            // grpThongTin
            //
            grpThongTin.Controls.Add(lblMaKH);
            grpThongTin.Controls.Add(txtMaKH);
            grpThongTin.Controls.Add(lblHoTen);
            grpThongTin.Controls.Add(txtHoTen);
            grpThongTin.Controls.Add(lblCCCD);
            grpThongTin.Controls.Add(txtCCCD);
            grpThongTin.Controls.Add(lblSDT);
            grpThongTin.Controls.Add(txtSDT);
            grpThongTin.Controls.Add(lblEmail);
            grpThongTin.Controls.Add(txtEmail);
            grpThongTin.Controls.Add(lblTimKiem);
            grpThongTin.Controls.Add(txtTimKiem);
            grpThongTin.Controls.Add(btnThem);
            grpThongTin.Controls.Add(btnSua);
            grpThongTin.Controls.Add(btnXoa);
            grpThongTin.Controls.Add(btnLamMoi);
            grpThongTin.Dock = DockStyle.Top;
            grpThongTin.Location = new Point(10, 10);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Size = new Size(1080, 185);
            grpThongTin.TabIndex = 0;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "👤 Thông tin khách hàng";
            //
            // lblMaKH
            //
            lblMaKH.Location = new Point(20, 38);
            lblMaKH.Name = "lblMaKH";
            lblMaKH.Size = new Size(110, 25);
            lblMaKH.Text = "Mã khách hàng:";
            //
            // txtMaKH
            //
            txtMaKH.Location = new Point(130, 35);
            txtMaKH.Name = "txtMaKH";
            txtMaKH.ReadOnly = true;
            txtMaKH.Size = new Size(150, 25);
            txtMaKH.TabIndex = 0;
            //
            // lblHoTen
            //
            lblHoTen.Location = new Point(300, 38);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(100, 25);
            lblHoTen.Text = "Họ tên:";
            //
            // txtHoTen
            //
            txtHoTen.Location = new Point(400, 35);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(300, 25);
            txtHoTen.TabIndex = 1;
            //
            // lblCCCD
            //
            lblCCCD.Location = new Point(20, 83);
            lblCCCD.Name = "lblCCCD";
            lblCCCD.Size = new Size(110, 25);
            lblCCCD.Text = "CCCD:";
            //
            // txtCCCD
            //
            txtCCCD.Location = new Point(130, 80);
            txtCCCD.MaxLength = 12;
            txtCCCD.Name = "txtCCCD";
            txtCCCD.Size = new Size(150, 25);
            txtCCCD.TabIndex = 2;
            //
            // lblSDT
            //
            lblSDT.Location = new Point(300, 83);
            lblSDT.Name = "lblSDT";
            lblSDT.Size = new Size(100, 25);
            lblSDT.Text = "Số điện thoại:";
            //
            // txtSDT
            //
            txtSDT.Location = new Point(400, 80);
            txtSDT.MaxLength = 10;
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(300, 25);
            txtSDT.TabIndex = 3;
            //
            // lblEmail
            //
            lblEmail.Location = new Point(20, 128);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(110, 25);
            lblEmail.Text = "Email:";
            //
            // txtEmail
            //
            txtEmail.Location = new Point(130, 125);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(150, 25);
            txtEmail.TabIndex = 4;
            //
            // lblTimKiem
            //
            lblTimKiem.Location = new Point(300, 128);
            lblTimKiem.Name = "lblTimKiem";
            lblTimKiem.Size = new Size(100, 25);
            lblTimKiem.Text = "Tìm kiếm:";
            //
            // txtTimKiem
            //
            txtTimKiem.Location = new Point(400, 125);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Nhập tên, CCCD hoặc số điện thoại...";
            txtTimKiem.Size = new Size(300, 25);
            txtTimKiem.TabIndex = 5;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            //
            // btnThem
            //
            btnThem.Location = new Point(730, 35);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(120, 38);
            btnThem.TabIndex = 6;
            btnThem.Text = "➕ Thêm";
            btnThem.Click += btnThem_Click;
            //
            // btnSua
            //
            btnSua.Location = new Point(860, 35);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(120, 38);
            btnSua.TabIndex = 7;
            btnSua.Text = "✏️ Sửa";
            btnSua.Click += btnSua_Click;
            //
            // btnXoa
            //
            btnXoa.Location = new Point(730, 85);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(120, 38);
            btnXoa.TabIndex = 8;
            btnXoa.Text = "🗑️ Xóa";
            btnXoa.Click += btnXoa_Click;
            //
            // btnLamMoi
            //
            btnLamMoi.Location = new Point(860, 85);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(120, 38);
            btnLamMoi.TabIndex = 9;
            btnLamMoi.Text = "🔄 Làm mới";
            btnLamMoi.Click += btnLamMoi_Click;
            //
            // grpDanhSach
            //
            grpDanhSach.Controls.Add(dgvKhachHang);
            grpDanhSach.Dock = DockStyle.Fill;
            grpDanhSach.Location = new Point(10, 195);
            grpDanhSach.Name = "grpDanhSach";
            grpDanhSach.Padding = new Padding(10);
            grpDanhSach.Size = new Size(1080, 395);
            grpDanhSach.TabIndex = 1;
            grpDanhSach.TabStop = false;
            grpDanhSach.Text = "📋 Danh sách khách hàng";
            //
            // dgvKhachHang
            //
            dgvKhachHang.AllowUserToAddRows = false;
            dgvKhachHang.AllowUserToDeleteRows = false;
            dgvKhachHang.Dock = DockStyle.Fill;
            dgvKhachHang.Name = "dgvKhachHang";
            dgvKhachHang.ReadOnly = true;
            dgvKhachHang.TabIndex = 0;
            dgvKhachHang.CellClick += dgvKhachHang_CellClick;
            //
            // frmKhachHang
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 600);
            Controls.Add(grpDanhSach);
            Controls.Add(grpThongTin);
            Name = "frmKhachHang";
            Padding = new Padding(10);
            Text = "Quản lý khách hàng";
            Load += frmKhachHang_Load;
            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            grpDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvKhachHang).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpThongTin;
        private Label lblMaKH;
        private TextBox txtMaKH;
        private Label lblHoTen;
        private TextBox txtHoTen;
        private Label lblCCCD;
        private TextBox txtCCCD;
        private Label lblSDT;
        private TextBox txtSDT;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblTimKiem;
        private TextBox txtTimKiem;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private GroupBox grpDanhSach;
        private DataGridView dgvKhachHang;
    }
}
