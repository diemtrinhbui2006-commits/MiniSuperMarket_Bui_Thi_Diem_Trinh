namespace MiniSupermarket.WinForms
{
    partial class FormUserManagement
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
            panelDetail = new Panel();
            btnToggleLock = new Button();
            btnResetPassword = new Button();
            btnAddUser = new Button();
            cboRole = new ComboBox();
            txtPassword = new TextBox();
            txtFullName = new TextBox();
            txtUsername = new TextBox();
            lblRole = new Label();
            lblPassword = new Label();
            lblFullName = new Label();
            lblUsername = new Label();
            dgvUsers = new DataGridView();
            panelDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            SuspendLayout();
            // 
            // panelDetail
            // 
            panelDetail.BackColor = Color.White;
            panelDetail.Controls.Add(btnToggleLock);
            panelDetail.Controls.Add(btnResetPassword);
            panelDetail.Controls.Add(btnAddUser);
            panelDetail.Controls.Add(cboRole);
            panelDetail.Controls.Add(txtPassword);
            panelDetail.Controls.Add(txtFullName);
            panelDetail.Controls.Add(txtUsername);
            panelDetail.Controls.Add(lblRole);
            panelDetail.Controls.Add(lblPassword);
            panelDetail.Controls.Add(lblFullName);
            panelDetail.Controls.Add(lblUsername);
            panelDetail.Dock = DockStyle.Right;
            panelDetail.Location = new Point(680, 0);
            panelDetail.Name = "panelDetail";
            panelDetail.Padding = new Padding(20);
            panelDetail.Size = new Size(370, 660);
            panelDetail.TabIndex = 0;
            // 
            // btnToggleLock
            // 
            btnToggleLock.BackColor = Color.FromArgb(239, 68, 68);
            btnToggleLock.Cursor = Cursors.Hand;
            btnToggleLock.FlatAppearance.BorderSize = 0;
            btnToggleLock.FlatStyle = FlatStyle.Flat;
            btnToggleLock.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnToggleLock.ForeColor = Color.White;
            btnToggleLock.Location = new Point(20, 395);
            btnToggleLock.Name = "btnToggleLock";
            btnToggleLock.Size = new Size(330, 42);
            btnToggleLock.TabIndex = 10;
            btnToggleLock.Text = "🔒  Khóa / Mở Khóa Tài Khoản";
            btnToggleLock.UseVisualStyleBackColor = false;
            btnToggleLock.Click += btnToggleLock_Click;
            // 
            // btnResetPassword
            // 
            btnResetPassword.BackColor = Color.FromArgb(245, 158, 11);
            btnResetPassword.Cursor = Cursors.Hand;
            btnResetPassword.FlatAppearance.BorderSize = 0;
            btnResetPassword.FlatStyle = FlatStyle.Flat;
            btnResetPassword.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnResetPassword.ForeColor = Color.White;
            btnResetPassword.Location = new Point(20, 340);
            btnResetPassword.Name = "btnResetPassword";
            btnResetPassword.Size = new Size(330, 42);
            btnResetPassword.TabIndex = 9;
            btnResetPassword.Text = "🔑  Đặt Lại Mật Khẩu (123456)";
            btnResetPassword.UseVisualStyleBackColor = false;
            btnResetPassword.Click += btnResetPassword_Click;
            // 
            // btnAddUser
            // 
            btnAddUser.BackColor = Color.FromArgb(16, 185, 129);
            btnAddUser.Cursor = Cursors.Hand;
            btnAddUser.FlatAppearance.BorderSize = 0;
            btnAddUser.FlatStyle = FlatStyle.Flat;
            btnAddUser.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnAddUser.ForeColor = Color.White;
            btnAddUser.Location = new Point(20, 280);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(330, 48);
            btnAddUser.TabIndex = 8;
            btnAddUser.Text = "➕  Tạo Tài Khoản Mới";
            btnAddUser.UseVisualStyleBackColor = false;
            btnAddUser.Click += btnAddUser_Click;
            // 
            // cboRole
            // 
            cboRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRole.Font = new Font("Segoe UI", 10F);
            cboRole.FormattingEnabled = true;
            cboRole.Location = new Point(20, 225);
            cboRole.Name = "cboRole";
            cboRole.Size = new Size(330, 31);
            cboRole.TabIndex = 7;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 10F);
            txtPassword.Location = new Point(20, 160);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(330, 30);
            txtPassword.TabIndex = 5;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtFullName
            // 
            txtFullName.Font = new Font("Segoe UI", 10F);
            txtFullName.Location = new Point(20, 98);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(330, 30);
            txtFullName.TabIndex = 3;
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 10F);
            txtUsername.Location = new Point(20, 36);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(330, 30);
            txtUsername.TabIndex = 1;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRole.Location = new Point(20, 200);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(111, 20);
            lblRole.TabIndex = 6;
            lblRole.Text = "Vai trò (Role):";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPassword.Location = new Point(20, 135);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(79, 20);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Mật khẩu:";
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFullName.Location = new Point(20, 73);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(81, 20);
            lblFullName.TabIndex = 2;
            lblFullName.Text = "Họ và tên:";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUsername.Location = new Point(20, 11);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(119, 20);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Tên đăng nhập:";
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.BackgroundColor = Color.White;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Dock = DockStyle.Fill;
            dgvUsers.Location = new Point(0, 0);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.RowHeadersWidth = 51;
            dgvUsers.RowTemplate.Height = 29;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(680, 660);
            dgvUsers.TabIndex = 1;
            dgvUsers.CellClick += dgvUsers_CellClick;
            // 
            // FormUserManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1050, 660);
            Controls.Add(dgvUsers);
            Controls.Add(panelDetail);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormUserManagement";
            Text = "Quản trị Tài khoản";
            Load += FormUserManagement_Load;
            panelDetail.ResumeLayout(false);
            panelDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelDetail;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblFullName;
        private TextBox txtFullName;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblRole;
        private ComboBox cboRole;
        private Button btnAddUser;
        private Button btnResetPassword;
        private Button btnToggleLock;
        private DataGridView dgvUsers;
    }
}
