namespace MiniSupermarket.WinForms
{
    partial class FormCategoryManagement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            dgvCategories = new DataGridView();
            txtKeyword = new TextBox();
            btnSearch = new Button();
            btnLoad = new Button();
            txtId = new TextBox();
            txtCategoryName = new TextBox();
            txtDescription = new TextBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            lblSearch = new Label();
            lblId = new Label();
            lblCategoryName = new Label();
            lblDescription = new Label();
            lblTitle = new Label();
            lblInfo = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvCategories).BeginInit();
            SuspendLayout();
            // 
            // dgvCategories
            // 
            dgvCategories.AllowUserToAddRows = false;
            dgvCategories.AllowUserToDeleteRows = false;
            dgvCategories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCategories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCategories.Location = new Point(12, 95);
            dgvCategories.MultiSelect = false;
            dgvCategories.Name = "dgvCategories";
            dgvCategories.ReadOnly = true;
            dgvCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategories.Size = new Size(560, 300);
            dgvCategories.TabIndex = 5;
            dgvCategories.CellClick += dgvCategories_CellClick;
            dgvCategories.CellContentClick += dgvCategories_CellContentClick;
            // 
            // txtKeyword
            // 
            txtKeyword.Location = new Point(81, 52);
            txtKeyword.Name = "txtKeyword";
            txtKeyword.Size = new Size(230, 23);
            txtKeyword.TabIndex = 2;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(320, 51);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(80, 25);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(406, 51);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(80, 25);
            btnLoad.TabIndex = 4;
            btnLoad.Text = "Tải lại";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // txtId
            // 
            txtId.Location = new Point(595, 155);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(190, 23);
            txtId.TabIndex = 8;
            // 
            // txtCategoryName
            // 
            txtCategoryName.Location = new Point(595, 215);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.Size = new Size(190, 23);
            txtCategoryName.TabIndex = 10;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(595, 275);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(190, 70);
            txtDescription.TabIndex = 12;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(595, 370);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(58, 30);
            btnAdd.TabIndex = 13;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(661, 370);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(65, 30);
            btnUpdate.TabIndex = 14;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(732, 370);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(53, 30);
            btnDelete.TabIndex = 15;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(12, 55);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(59, 15);
            lblSearch.TabIndex = 1;
            lblSearch.Text = "Tìm kiếm:";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(595, 135);
            lblId.Name = "lblId";
            lblId.Size = new Size(41, 15);
            lblId.TabIndex = 7;
            lblId.Text = "Mã ID:";
            // 
            // lblCategoryName
            // 
            lblCategoryName.AutoSize = true;
            lblCategoryName.Location = new Point(595, 195);
            lblCategoryName.Name = "lblCategoryName";
            lblCategoryName.Size = new Size(93, 15);
            lblCategoryName.TabIndex = 9;
            lblCategoryName.Text = "Tên nhóm hàng:";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(595, 255);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(41, 15);
            lblDescription.TabIndex = 11;
            lblDescription.Text = "Mô tả:";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(223, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ NHÓM HÀNG";
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblInfo.Location = new Point(595, 95);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(161, 20);
            lblInfo.TabIndex = 6;
            lblInfo.Text = "Thông tin nhóm hàng";
            // 
            // FormCategoryManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(820, 430);
            Controls.Add(lblTitle);
            Controls.Add(lblSearch);
            Controls.Add(txtKeyword);
            Controls.Add(btnSearch);
            Controls.Add(btnLoad);
            Controls.Add(dgvCategories);
            Controls.Add(lblInfo);
            Controls.Add(lblId);
            Controls.Add(txtId);
            Controls.Add(lblCategoryName);
            Controls.Add(txtCategoryName);
            Controls.Add(lblDescription);
            Controls.Add(txtDescription);
            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Name = "FormCategoryManagement";
            Text = "Quản lý nhóm hàng";
            Load += FormCategoryManagement_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCategories).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvCategories;

        private TextBox txtKeyword;
        private TextBox txtId;
        private TextBox txtCategoryName;
        private TextBox txtDescription;

        private Button btnSearch;
        private Button btnLoad;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;

        private Label lblTitle;
        private Label lblSearch;
        private Label lblInfo;
        private Label lblId;
        private Label lblCategoryName;
        private Label lblDescription;
    }
}
