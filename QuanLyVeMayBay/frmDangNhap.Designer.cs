namespace QuanLyVeMayBay
{
    partial class frmDangNhap
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
            pnlHeader = new Panel();
            lblSubtitle = new Label();
            lblTitle = new Label();
            pnlCard = new Panel();
            btnThoat = new Button();
            btnDangNhap = new Button();
            chkHienMatKhau = new CheckBox();
            txtMatKhau = new TextBox();
            lblMatKhau = new Label();
            txtTenDangNhap = new TextBox();
            lblTenDangNhap = new Label();
            lblFormTitle = new Label();
            grpDemo = new GroupBox();
            btnDemoAdmin = new Button();
            btnDemoCSKH = new Button();
            btnDemoKeToan = new Button();
            btnDemoDatVe = new Button();
            btnDemoQLCB = new Button();
            lblStatus = new Label();
            pnlHeader.SuspendLayout();
            pnlCard.SuspendLayout();
            grpDemo.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(15, 23, 42);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(720, 85);
            pnlHeader.TabIndex = 0;
            // 
            // lblSubtitle
            // 
            lblSubtitle.Font = new Font("Segoe UI", 9.5F);
            lblSubtitle.ForeColor = Color.FromArgb(148, 163, 184);
            lblSubtitle.Location = new Point(12, 45);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(696, 23);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Hệ thống Phân quyền Nhân viên & Nghiệp vụ Hàng không";
            lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(12, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(696, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "✈️ HỆ THỐNG QUẢN LÝ ĐẶT VÉ MÁY BAY";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlCard
            // 
            pnlCard.BackColor = Color.White;
            pnlCard.Controls.Add(btnThoat);
            pnlCard.Controls.Add(btnDangNhap);
            pnlCard.Controls.Add(chkHienMatKhau);
            pnlCard.Controls.Add(txtMatKhau);
            pnlCard.Controls.Add(lblMatKhau);
            pnlCard.Controls.Add(txtTenDangNhap);
            pnlCard.Controls.Add(lblTenDangNhap);
            pnlCard.Controls.Add(lblFormTitle);
            pnlCard.Location = new Point(40, 105);
            pnlCard.Name = "pnlCard";
            pnlCard.Size = new Size(640, 260);
            pnlCard.TabIndex = 1;
            // 
            // btnThoat
            // 
            btnThoat.Cursor = Cursors.Hand;
            btnThoat.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnThoat.Location = new Point(345, 195);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(130, 42);
            btnThoat.TabIndex = 7;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnDangNhap
            // 
            btnDangNhap.Cursor = Cursors.Hand;
            btnDangNhap.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDangNhap.Location = new Point(175, 195);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(150, 42);
            btnDangNhap.TabIndex = 6;
            btnDangNhap.Text = "🔑 ĐĂNG NHẬP";
            btnDangNhap.UseVisualStyleBackColor = true;
            btnDangNhap.Click += btnDangNhap_Click;
            // 
            // chkHienMatKhau
            // 
            chkHienMatKhau.AutoSize = true;
            chkHienMatKhau.Font = new Font("Segoe UI", 9F);
            chkHienMatKhau.ForeColor = Color.FromArgb(71, 85, 105);
            chkHienMatKhau.Location = new Point(175, 160);
            chkHienMatKhau.Name = "chkHienMatKhau";
            chkHienMatKhau.Size = new Size(104, 19);
            chkHienMatKhau.TabIndex = 5;
            chkHienMatKhau.Text = "Hiện mật khẩu";
            chkHienMatKhau.UseVisualStyleBackColor = true;
            chkHienMatKhau.CheckedChanged += chkHienMatKhau_CheckedChanged;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Font = new Font("Segoe UI", 10.5F);
            txtMatKhau.Location = new Point(175, 120);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(390, 26);
            txtMatKhau.TabIndex = 4;
            txtMatKhau.UseSystemPasswordChar = true;
            txtMatKhau.KeyDown += txtInput_KeyDown;
            // 
            // lblMatKhau
            // 
            lblMatKhau.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMatKhau.ForeColor = Color.FromArgb(30, 41, 59);
            lblMatKhau.Location = new Point(35, 120);
            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.Size = new Size(130, 26);
            lblMatKhau.TabIndex = 3;
            lblMatKhau.Text = "Mật khẩu:";
            lblMatKhau.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Font = new Font("Segoe UI", 10.5F);
            txtTenDangNhap.Location = new Point(175, 75);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(390, 26);
            txtTenDangNhap.TabIndex = 2;
            txtTenDangNhap.KeyDown += txtInput_KeyDown;
            // 
            // lblTenDangNhap
            // 
            lblTenDangNhap.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTenDangNhap.ForeColor = Color.FromArgb(30, 41, 59);
            lblTenDangNhap.Location = new Point(35, 75);
            lblTenDangNhap.Name = "lblTenDangNhap";
            lblTenDangNhap.Size = new Size(130, 26);
            lblTenDangNhap.TabIndex = 1;
            lblTenDangNhap.Text = "Tên đăng nhập:";
            lblTenDangNhap.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblFormTitle
            // 
            lblFormTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblFormTitle.ForeColor = Color.FromArgb(2, 132, 199);
            lblFormTitle.Location = new Point(20, 15);
            lblFormTitle.Name = "lblFormTitle";
            lblFormTitle.Size = new Size(600, 30);
            lblFormTitle.TabIndex = 0;
            lblFormTitle.Text = "ĐĂNG NHẬP TÀI KHOẢN NHÂN VIÊN";
            lblFormTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // grpDemo
            // 
            grpDemo.BackColor = Color.White;
            grpDemo.Controls.Add(btnDemoAdmin);
            grpDemo.Controls.Add(btnDemoCSKH);
            grpDemo.Controls.Add(btnDemoKeToan);
            grpDemo.Controls.Add(btnDemoDatVe);
            grpDemo.Controls.Add(btnDemoQLCB);
            grpDemo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpDemo.ForeColor = Color.FromArgb(30, 41, 59);
            grpDemo.Location = new Point(40, 380);
            grpDemo.Name = "grpDemo";
            grpDemo.Size = new Size(640, 95);
            grpDemo.TabIndex = 2;
            grpDemo.TabStop = false;
            grpDemo.Text = "⚡ Chọn nhanh tài khoản kiểm thử (Demo Fast Login)";
            // 
            // btnDemoAdmin
            // 
            btnDemoAdmin.Cursor = Cursors.Hand;
            btnDemoAdmin.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDemoAdmin.Location = new Point(15, 30);
            btnDemoAdmin.Name = "btnDemoAdmin";
            btnDemoAdmin.Size = new Size(110, 45);
            btnDemoAdmin.TabIndex = 0;
            btnDemoAdmin.Text = "👑 Admin\r\n(admin)";
            btnDemoAdmin.UseVisualStyleBackColor = true;
            btnDemoAdmin.Click += btnDemo_Click;
            // 
            // btnDemoCSKH
            // 
            btnDemoCSKH.Cursor = Cursors.Hand;
            btnDemoCSKH.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDemoCSKH.Location = new Point(135, 30);
            btnDemoCSKH.Name = "btnDemoCSKH";
            btnDemoCSKH.Size = new Size(115, 45);
            btnDemoCSKH.TabIndex = 1;
            btnDemoCSKH.Text = "🎧 CSKH\r\n(cskh)";
            btnDemoCSKH.UseVisualStyleBackColor = true;
            btnDemoCSKH.Click += btnDemo_Click;
            // 
            // btnDemoKeToan
            // 
            btnDemoKeToan.Cursor = Cursors.Hand;
            btnDemoKeToan.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDemoKeToan.Location = new Point(260, 30);
            btnDemoKeToan.Name = "btnDemoKeToan";
            btnDemoKeToan.Size = new Size(115, 45);
            btnDemoKeToan.TabIndex = 2;
            btnDemoKeToan.Text = "💰 Kế toán\r\n(ketoan)";
            btnDemoKeToan.UseVisualStyleBackColor = true;
            btnDemoKeToan.Click += btnDemo_Click;
            // 
            // btnDemoDatVe
            // 
            btnDemoDatVe.Cursor = Cursors.Hand;
            btnDemoDatVe.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDemoDatVe.Location = new Point(385, 30);
            btnDemoDatVe.Name = "btnDemoDatVe";
            btnDemoDatVe.Size = new Size(115, 45);
            btnDemoDatVe.TabIndex = 3;
            btnDemoDatVe.Text = "🎫 Đặt vé\r\n(datve)";
            btnDemoDatVe.UseVisualStyleBackColor = true;
            btnDemoDatVe.Click += btnDemo_Click;
            // 
            // btnDemoQLCB
            // 
            btnDemoQLCB.Cursor = Cursors.Hand;
            btnDemoQLCB.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDemoQLCB.Location = new Point(510, 30);
            btnDemoQLCB.Name = "btnDemoQLCB";
            btnDemoQLCB.Size = new Size(115, 45);
            btnDemoQLCB.TabIndex = 4;
            btnDemoQLCB.Text = "🛫 QL Ch.Bay\r\n(qlcb)";
            btnDemoQLCB.UseVisualStyleBackColor = true;
            btnDemoQLCB.Click += btnDemo_Click;
            // 
            // lblStatus
            // 
            lblStatus.Font = new Font("Segoe UI", 8.5F);
            lblStatus.ForeColor = Color.FromArgb(100, 116, 139);
            lblStatus.Location = new Point(40, 485);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(640, 20);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "● Đang kết nối cơ sở dữ liệu MySQL...";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // frmDangNhap
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            ClientSize = new Size(720, 520);
            Controls.Add(lblStatus);
            Controls.Add(grpDemo);
            Controls.Add(pnlCard);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmDangNhap";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập hệ thống - Quản lý vé máy bay";
            Load += frmDangNhap_Load;
            pnlHeader.ResumeLayout(false);
            pnlCard.ResumeLayout(false);
            pnlCard.PerformLayout();
            grpDemo.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblSubtitle;
        private Panel pnlCard;
        private Label lblFormTitle;
        private Label lblTenDangNhap;
        private TextBox txtTenDangNhap;
        private Label lblMatKhau;
        private TextBox txtMatKhau;
        private CheckBox chkHienMatKhau;
        private Button btnDangNhap;
        private Button btnThoat;
        private GroupBox grpDemo;
        private Button btnDemoAdmin;
        private Button btnDemoCSKH;
        private Button btnDemoKeToan;
        private Button btnDemoDatVe;
        private Button btnDemoQLCB;
        private Label lblStatus;
    }
}
