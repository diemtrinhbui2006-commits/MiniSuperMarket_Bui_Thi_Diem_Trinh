namespace MiniSupermarket.WinForms
{
    partial class FormRoleManagement
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
            dgvRoles = new DataGridView();
            txtId = new TextBox();
            txtRoleName = new TextBox();
            txtDescription = new TextBox();
            btnLoad = new Button();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            lblTitle = new Label();
            lblId = new Label();
            lblRoleName = new Label();
            lblDescription = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvRoles).BeginInit();
            SuspendLayout();
            // 
            // dgvRoles
            // 
            dgvRoles.AllowUserToAddRows = false;
            dgvRoles.AllowUserToDeleteRows = false;
            dgvRoles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRoles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRoles.Location = new Point(12, 95);
            dgvRoles.MultiSelect = false;
            dgvRoles.Name = "dgvRoles";
            dgvRoles.ReadOnly = true;
            dgvRoles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRoles.Size = new Size(500, 300);
            dgvRoles.TabIndex = 2;
            dgvRoles.CellClick += dgvRoles_CellClick;
            // 
            // txtId
            // 
            txtId.Location = new Point(540, 120);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(230, 23);
            txtId.TabIndex = 4;
            txtId.TextChanged += txtId_TextChanged;
            // 
            // txtRoleName
            // 
            txtRoleName.Location = new Point(540, 180);
            txtRoleName.Name = "txtRoleName";
            txtRoleName.Size = new Size(230, 23);
            txtRoleName.TabIndex = 6;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(540, 240);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(230, 70);
            txtDescription.TabIndex = 8;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(420, 50);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(90, 30);
            btnLoad.TabIndex = 1;
            btnLoad.Text = "Tải lại";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(540, 335);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(65, 30);
            btnAdd.TabIndex = 9;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(615, 335);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 30);
            btnUpdate.TabIndex = 10;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(700, 335);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(70, 30);
            btnDelete.TabIndex = 11;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(12, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(172, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ VAI TRÒ";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(540, 100);
            lblId.Name = "lblId";
            lblId.Size = new Size(41, 15);
            lblId.TabIndex = 3;
            lblId.Text = "Mã ID:";
            // 
            // lblRoleName
            // 
            lblRoleName.AutoSize = true;
            lblRoleName.Location = new Point(540, 160);
            lblRoleName.Name = "lblRoleName";
            lblRoleName.Size = new Size(64, 15);
            lblRoleName.TabIndex = 5;
            lblRoleName.Text = "Tên vai trò:";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(540, 220);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(41, 15);
            lblDescription.TabIndex = 7;
            lblDescription.Text = "Mô tả:";
            // 
            // FormRoleManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 430);
            Controls.Add(lblTitle);
            Controls.Add(btnLoad);
            Controls.Add(dgvRoles);
            Controls.Add(lblId);
            Controls.Add(txtId);
            Controls.Add(lblRoleName);
            Controls.Add(txtRoleName);
            Controls.Add(lblDescription);
            Controls.Add(txtDescription);
            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Name = "FormRoleManagement";
            Text = "Quản lý vai trò";
            Load += FormRoleManagement_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRoles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvRoles;

        private TextBox txtId;
        private TextBox txtRoleName;
        private TextBox txtDescription;

        private Button btnLoad;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;

        private Label lblTitle;
        private Label lblId;
        private Label lblRoleName;
        private Label lblDescription;
    }
}
