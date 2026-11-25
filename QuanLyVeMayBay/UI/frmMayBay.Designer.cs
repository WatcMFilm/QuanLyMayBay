namespace QuanLyVeMayBay
{
    partial class frmMayBay
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
            lblMaMayBay = new Label();
            txtMaMayBay = new TextBox();
            lblTenMayBay = new Label();
            txtTenMayBay = new TextBox();
            lblTrangThai = new Label();
            cboTrangThai = new ComboBox();
            lblTimKiem = new Label();
            txtTimKiem = new TextBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            grpDanhSach = new GroupBox();
            dgvMayBay = new DataGridView();
            grpThongTin.SuspendLayout();
            grpDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMayBay).BeginInit();
            SuspendLayout();
            //
            // grpThongTin
            //
            grpThongTin.Controls.Add(lblMaMayBay);
            grpThongTin.Controls.Add(txtMaMayBay);
            grpThongTin.Controls.Add(lblTenMayBay);
            grpThongTin.Controls.Add(txtTenMayBay);
            grpThongTin.Controls.Add(lblTrangThai);
            grpThongTin.Controls.Add(cboTrangThai);
            grpThongTin.Controls.Add(lblTimKiem);
            grpThongTin.Controls.Add(txtTimKiem);
            grpThongTin.Controls.Add(btnThem);
            grpThongTin.Controls.Add(btnSua);
            grpThongTin.Controls.Add(btnXoa);
            grpThongTin.Controls.Add(btnLamMoi);
            grpThongTin.Dock = DockStyle.Top;
            grpThongTin.Location = new Point(10, 10);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Size = new Size(1080, 140);
            grpThongTin.TabIndex = 0;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "✈️ Thông tin máy bay";
            //
            // lblMaMayBay
            //
            lblMaMayBay.Location = new Point(20, 38);
            lblMaMayBay.Name = "lblMaMayBay";
            lblMaMayBay.Size = new Size(110, 25);
            lblMaMayBay.Text = "Mã máy bay:";
            //
            // txtMaMayBay
            //
            txtMaMayBay.Location = new Point(130, 35);
            txtMaMayBay.Name = "txtMaMayBay";
            txtMaMayBay.ReadOnly = true;
            txtMaMayBay.Size = new Size(150, 25);
            txtMaMayBay.TabIndex = 0;
            //
            // lblTenMayBay
            //
            lblTenMayBay.Location = new Point(300, 38);
            lblTenMayBay.Name = "lblTenMayBay";
            lblTenMayBay.Size = new Size(100, 25);
            lblTenMayBay.Text = "Tên máy bay:";
            //
            // txtTenMayBay
            //
            txtTenMayBay.Location = new Point(400, 35);
            txtTenMayBay.Name = "txtTenMayBay";
            txtTenMayBay.Size = new Size(300, 25);
            txtTenMayBay.TabIndex = 1;
            //
            // lblTrangThai
            //
            lblTrangThai.Location = new Point(20, 88);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(110, 25);
            lblTrangThai.Text = "Trạng thái:";
            //
            // cboTrangThai
            //
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.Location = new Point(130, 85);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(150, 25);
            cboTrangThai.TabIndex = 2;
            //
            // lblTimKiem
            //
            lblTimKiem.Location = new Point(300, 88);
            lblTimKiem.Name = "lblTimKiem";
            lblTimKiem.Size = new Size(100, 25);
            lblTimKiem.Text = "Tìm kiếm:";
            //
            // txtTimKiem
            //
            txtTimKiem.Location = new Point(400, 85);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Nhập mã hoặc tên máy bay...";
            txtTimKiem.Size = new Size(300, 25);
            txtTimKiem.TabIndex = 3;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            //
            // btnThem
            //
            btnThem.Location = new Point(730, 30);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(120, 38);
            btnThem.TabIndex = 4;
            btnThem.Text = "➕ Thêm";
            btnThem.Click += btnThem_Click;
            //
            // btnSua
            //
            btnSua.Location = new Point(860, 30);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(120, 38);
            btnSua.TabIndex = 5;
            btnSua.Text = "✏️ Sửa";
            btnSua.Click += btnSua_Click;
            //
            // btnXoa
            //
            btnXoa.Location = new Point(730, 80);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(120, 38);
            btnXoa.TabIndex = 6;
            btnXoa.Text = "🗑️ Xóa";
            btnXoa.Click += btnXoa_Click;
            //
            // btnLamMoi
            //
            btnLamMoi.Location = new Point(860, 80);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(120, 38);
            btnLamMoi.TabIndex = 7;
            btnLamMoi.Text = "🔄 Làm mới";
            btnLamMoi.Click += btnLamMoi_Click;
            //
            // grpDanhSach
            //
            grpDanhSach.Controls.Add(dgvMayBay);
            grpDanhSach.Dock = DockStyle.Fill;
            grpDanhSach.Location = new Point(10, 150);
            grpDanhSach.Name = "grpDanhSach";
            grpDanhSach.Padding = new Padding(10);
            grpDanhSach.Size = new Size(1080, 440);
            grpDanhSach.TabIndex = 1;
            grpDanhSach.TabStop = false;
            grpDanhSach.Text = "📋 Danh sách máy bay";
            //
            // dgvMayBay
            //
            dgvMayBay.AllowUserToAddRows = false;
            dgvMayBay.AllowUserToDeleteRows = false;
            dgvMayBay.Dock = DockStyle.Fill;
            dgvMayBay.Name = "dgvMayBay";
            dgvMayBay.ReadOnly = true;
            dgvMayBay.TabIndex = 0;
            dgvMayBay.CellClick += dgvMayBay_CellClick;
            //
            // frmMayBay
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 600);
            Controls.Add(grpDanhSach);
            Controls.Add(grpThongTin);
            Name = "frmMayBay";
            Padding = new Padding(10);
            Text = "Quản lý máy bay";
            Load += frmMayBay_Load;
            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            grpDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMayBay).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpThongTin;
        private Label lblMaMayBay;
        private TextBox txtMaMayBay;
        private Label lblTenMayBay;
        private TextBox txtTenMayBay;
        private Label lblTrangThai;
        private ComboBox cboTrangThai;
        private Label lblTimKiem;
        private TextBox txtTimKiem;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private GroupBox grpDanhSach;
        private DataGridView dgvMayBay;
    }
}
