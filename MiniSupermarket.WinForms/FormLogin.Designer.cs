namespace MiniSupermarket.WinForms
{
    partial class FormLogin
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
            panelBackground = new Panel();
            cboQuickAccounts = new ComboBox();
            lblQuick = new Label();
            lblTitle = new Label();
            lblLogo = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            lblUsername = new Label();
            lblPassword = new Label();
            btnLogin = new Button();
            btnExit = new Button();
            panelBackground.SuspendLayout();
            SuspendLayout();
            // 
            // panelBackground
            // 
            panelBackground.BackColor = Color.White;
            panelBackground.Controls.Add(cboQuickAccounts);
            panelBackground.Controls.Add(lblQuick);
            panelBackground.Controls.Add(lblTitle);
            panelBackground.Controls.Add(lblLogo);
            panelBackground.Controls.Add(txtUsername);
            panelBackground.Controls.Add(txtPassword);
            panelBackground.Controls.Add(lblUsername);
            panelBackground.Controls.Add(lblPassword);
            panelBackground.Controls.Add(btnLogin);
            panelBackground.Controls.Add(btnExit);
            panelBackground.Location = new Point(40, 30);
            panelBackground.Name = "panelBackground";
            panelBackground.Padding = new Padding(30);
            panelBackground.Size = new Size(460, 480);
            panelBackground.TabIndex = 0;
            // 
            // cboQuickAccounts
            // 
            cboQuickAccounts.DropDownStyle = ComboBoxStyle.DropDownList;
            cboQuickAccounts.Font = new Font("Segoe UI", 9.5F);
            cboQuickAccounts.FormattingEnabled = true;
            cboQuickAccounts.Location = new Point(30, 155);
            cboQuickAccounts.Name = "cboQuickAccounts";
            cboQuickAccounts.Size = new Size(400, 29);
            cboQuickAccounts.TabIndex = 2;
            cboQuickAccounts.SelectedIndexChanged += cboQuickAccounts_SelectedIndexChanged;
            // 
            // lblQuick
            // 
            lblQuick.AutoSize = true;
            lblQuick.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblQuick.ForeColor = Color.FromArgb(70, 70, 70);
            lblQuick.Location = new Point(30, 130);
            lblQuick.Name = "lblQuick";
            lblQuick.Size = new Size(215, 20);
            lblQuick.TabIndex = 1;
            lblQuick.Text = "Chọn nhanh tài khoản kiểm thử:";
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(40, 50, 75);
            lblTitle.Location = new Point(30, 75);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(400, 35);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "HỆ THỐNG QUẢN LÝ SIÊU THỊ MINI";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblLogo
            // 
            lblLogo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblLogo.ForeColor = Color.FromArgb(41, 100, 180);
            lblLogo.Location = new Point(30, 20);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(400, 50);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "🛒 MINIMART POS";
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 11F);
            txtUsername.Location = new Point(30, 225);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Nhập tên đăng nhập...";
            txtUsername.Size = new Size(400, 32);
            txtUsername.TabIndex = 4;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.Location = new Point(30, 305);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.PlaceholderText = "Nhập mật khẩu...";
            txtPassword.Size = new Size(400, 32);
            txtPassword.TabIndex = 6;
            txtPassword.KeyDown += txtPassword_KeyDown;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblUsername.ForeColor = Color.FromArgb(30, 41, 59);
            lblUsername.Location = new Point(30, 198);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(133, 23);
            lblUsername.TabIndex = 3;
            lblUsername.Text = "Tên đăng nhập:";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(30, 41, 59);
            lblPassword.Location = new Point(30, 278);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(91, 23);
            lblPassword.TabIndex = 5;
            lblPassword.Text = "Mật khẩu:";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(41, 100, 180);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(30, 365);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(400, 45);
            btnLogin.TabIndex = 7;
            btnLogin.Text = "ĐĂNG NHẬP";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Transparent;
            btnExit.Cursor = Cursors.Hand;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Segoe UI", 9.5F);
            btnExit.ForeColor = Color.FromArgb(100, 116, 139);
            btnExit.Location = new Point(30, 420);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(400, 35);
            btnExit.TabIndex = 8;
            btnExit.Text = "Thoát ứng dụng";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 30, 48);
            ClientSize = new Size(540, 540);
            Controls.Add(panelBackground);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập hệ thống - MiniMart POS";
            Load += FormLogin_Load;
            panelBackground.ResumeLayout(false);
            panelBackground.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelBackground;
        private Label lblLogo;
        private Label lblTitle;
        private Label lblQuick;
        private ComboBox cboQuickAccounts;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnExit;
    }
}
