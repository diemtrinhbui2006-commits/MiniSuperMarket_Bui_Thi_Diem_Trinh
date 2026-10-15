namespace MiniSupermarket.WinForms
{
    partial class FormCustomerManagement
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private Label lblCustomerId;
        private Label lblCustomerName;
        private Label lblPhoneNumber;
        private Label lblAddress;
        private Label lblWard;
        private Label lblDistrict;
        private Label lblProvince;
        private Label lblRewardPoints;
        private Label lblMembershipRank;
        private Label lblKeyword;

        private TextBox txtCustomerId;
        private TextBox txtCustomerName;
        private TextBox txtPhoneNumber;
        private TextBox txtAddress;
        private TextBox txtWard;
        private TextBox txtDistrict;
        private TextBox txtProvince;
        private TextBox txtRewardPoints;
        private TextBox txtMembershipRank;
        private TextBox txtKeyword;

        private Button btnLoad;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnSearch;

        private DataGridView dgvCustomers;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            lblTitle = new Label();
            lblCustomerId = new Label();
            lblCustomerName = new Label();
            lblPhoneNumber = new Label();
            lblAddress = new Label();
            lblWard = new Label();
            lblDistrict = new Label();
            lblProvince = new Label();
            lblRewardPoints = new Label();
            lblMembershipRank = new Label();
            lblKeyword = new Label();

            txtCustomerId = new TextBox();
            txtCustomerName = new TextBox();
            txtPhoneNumber = new TextBox();
            txtAddress = new TextBox();
            txtWard = new TextBox();
            txtDistrict = new TextBox();
            txtProvince = new TextBox();
            txtRewardPoints = new TextBox();
            txtMembershipRank = new TextBox();
            txtKeyword = new TextBox();

            btnLoad = new Button();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnSearch = new Button();

            dgvCustomers = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            SuspendLayout();

            // ==============================
            // TITLE
            // ==============================

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font(
                "Segoe UI",
                18F,
                FontStyle.Bold);

            lblTitle.Location = new Point(40, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(300, 32);
            lblTitle.Text = "QUẢN LÝ KHÁCH HÀNG";

            // ==============================
            // CUSTOMER ID
            // ==============================

            lblCustomerId.AutoSize = true;
            lblCustomerId.Location = new Point(40, 75);
            lblCustomerId.Name = "lblCustomerId";
            lblCustomerId.Size = new Size(90, 15);
            lblCustomerId.Text = "Mã khách hàng:";

            txtCustomerId.Location = new Point(150, 72);
            txtCustomerId.Name = "txtCustomerId";
            txtCustomerId.Size = new Size(200, 23);
            txtCustomerId.ReadOnly = true;

            // ==============================
            // CUSTOMER NAME
            // ==============================

            lblCustomerName.AutoSize = true;
            lblCustomerName.Location = new Point(40, 110);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(95, 15);
            lblCustomerName.Text = "Tên khách hàng:";

            txtCustomerName.Location = new Point(150, 107);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Size = new Size(200, 23);

            // ==============================
            // PHONE
            // ==============================

            lblPhoneNumber.AutoSize = true;
            lblPhoneNumber.Location = new Point(40, 145);
            lblPhoneNumber.Name = "lblPhoneNumber";
            lblPhoneNumber.Size = new Size(80, 15);
            lblPhoneNumber.Text = "Số điện thoại:";

            txtPhoneNumber.Location = new Point(150, 142);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(200, 23);

            // ==============================
            // ADDRESS
            // ==============================

            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(40, 180);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(50, 15);
            lblAddress.Text = "Địa chỉ:";

            txtAddress.Location = new Point(150, 177);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(200, 23);

            // ==============================
            // WARD
            // ==============================

            lblWard.AutoSize = true;
            lblWard.Location = new Point(390, 75);
            lblWard.Name = "lblWard";
            lblWard.Size = new Size(70, 15);
            lblWard.Text = "Phường:";

            txtWard.Location = new Point(475, 72);
            txtWard.Name = "txtWard";
            txtWard.Size = new Size(200, 23);

            // ==============================
            // DISTRICT
            // ==============================

            lblDistrict.AutoSize = true;
            lblDistrict.Location = new Point(390, 110);
            lblDistrict.Name = "lblDistrict";
            lblDistrict.Size = new Size(70, 15);
            lblDistrict.Text = "Quận/Huyện:";

            txtDistrict.Location = new Point(475, 107);
            txtDistrict.Name = "txtDistrict";
            txtDistrict.Size = new Size(200, 23);

            // ==============================
            // PROVINCE
            // ==============================

            lblProvince.AutoSize = true;
            lblProvince.Location = new Point(390, 145);
            lblProvince.Name = "lblProvince";
            lblProvince.Size = new Size(70, 15);
            lblProvince.Text = "Tỉnh/TP:";

            txtProvince.Location = new Point(475, 142);
            txtProvince.Name = "txtProvince";
            txtProvince.Size = new Size(200, 23);

            // ==============================
            // REWARD POINTS
            // ==============================

            lblRewardPoints.AutoSize = true;
            lblRewardPoints.Location = new Point(390, 180);
            lblRewardPoints.Name = "lblRewardPoints";
            lblRewardPoints.Size = new Size(75, 15);
            lblRewardPoints.Text = "Điểm tích lũy:";

            txtRewardPoints.Location = new Point(475, 177);
            txtRewardPoints.Name = "txtRewardPoints";
            txtRewardPoints.Size = new Size(200, 23);
            txtRewardPoints.Text = "0";

            // ==============================
            // MEMBERSHIP RANK
            // ==============================

            lblMembershipRank.AutoSize = true;
            lblMembershipRank.Location = new Point(720, 75);
            lblMembershipRank.Name = "lblMembershipRank";
            lblMembershipRank.Size = new Size(75, 15);
            lblMembershipRank.Text = "Hạng thành viên:";

            txtMembershipRank.Location = new Point(815, 72);
            txtMembershipRank.Name = "txtMembershipRank";
            txtMembershipRank.Size = new Size(200, 23);
            txtMembershipRank.Text = "Chuẩn";

            // ==============================
            // SEARCH
            // ==============================

            lblKeyword.AutoSize = true;
            lblKeyword.Location = new Point(720, 110);
            lblKeyword.Name = "lblKeyword";
            lblKeyword.Size = new Size(70, 15);
            lblKeyword.Text = "Tìm kiếm:";

            txtKeyword.Location = new Point(815, 107);
            txtKeyword.Name = "txtKeyword";
            txtKeyword.Size = new Size(200, 23);

            // ==============================
            // BUTTON LOAD
            // ==============================

            btnLoad.Location = new Point(720, 145);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(95, 35);
            btnLoad.Text = "Tải dữ liệu";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;

            // ==============================
            // BUTTON ADD
            // ==============================

            btnAdd.Location = new Point(825, 145);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(90, 35);
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;

            // ==============================
            // BUTTON UPDATE
            // ==============================

            btnUpdate.Location = new Point(925, 145);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(90, 35);
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;

            // ==============================
            // BUTTON DELETE
            // ==============================

            btnDelete.Location = new Point(720, 185);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(95, 35);
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;

            // ==============================
            // BUTTON SEARCH
            // ==============================

            btnSearch.Location = new Point(825, 185);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(90, 35);
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;

            // ==============================
            // DATA GRID VIEW
            // ==============================

            dgvCustomers.AllowUserToAddRows = false;
            dgvCustomers.AllowUserToDeleteRows = false;
            dgvCustomers.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvCustomers.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            dgvCustomers.Location = new Point(40, 265);
            dgvCustomers.MultiSelect = false;
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.ReadOnly = true;
            dgvCustomers.RowHeadersWidth = 51;
            dgvCustomers.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvCustomers.Size = new Size(1070, 350);

            dgvCustomers.CellClick += dgvCustomers_CellClick;
            dgvCustomers.CellContentClick += dgvCustomers_CellContentClick;

            // ==============================
            // FORM
            // ==============================

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;

            ClientSize = new Size(1150, 650);

            Controls.Add(lblTitle);

            Controls.Add(lblCustomerId);
            Controls.Add(txtCustomerId);

            Controls.Add(lblCustomerName);
            Controls.Add(txtCustomerName);

            Controls.Add(lblPhoneNumber);
            Controls.Add(txtPhoneNumber);

            Controls.Add(lblAddress);
            Controls.Add(txtAddress);

            Controls.Add(lblWard);
            Controls.Add(txtWard);

            Controls.Add(lblDistrict);
            Controls.Add(txtDistrict);

            Controls.Add(lblProvince);
            Controls.Add(txtProvince);

            Controls.Add(lblRewardPoints);
            Controls.Add(txtRewardPoints);

            Controls.Add(lblMembershipRank);
            Controls.Add(txtMembershipRank);

            Controls.Add(lblKeyword);
            Controls.Add(txtKeyword);

            Controls.Add(btnLoad);
            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(btnSearch);

            Controls.Add(dgvCustomers);

            Name = "FormCustomerManagement";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý khách hàng";

            Load += FormCustomerManagement_Load;

            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}