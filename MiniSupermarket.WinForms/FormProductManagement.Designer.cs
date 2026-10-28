namespace MiniSupermarket.WinForms
{
    partial class FormProductManagement
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
            panelTop = new Panel();
            btnReload = new Button();
            btnSearch = new Button();
            cboFilterCategory = new ComboBox();
            txtSearchBarcode = new TextBox();
            panelDetail = new Panel();
            btnClear = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            cboCategory = new ComboBox();
            nudStock = new NumericUpDown();
            nudPrice = new NumericUpDown();
            txtProductName = new TextBox();
            txtBarcode = new TextBox();
            txtId = new TextBox();
            lblCategory = new Label();
            lblStock = new Label();
            lblPrice = new Label();
            lblProductName = new Label();
            lblBarcode = new Label();
            lblId = new Label();
            dgvProducts = new DataGridView();
            panelPaging = new FlowLayoutPanel();
            btnPrev = new Button();
            lblPaging = new Label();
            btnNext = new Button();
            panelTop.SuspendLayout();
            panelDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.White;
            panelTop.Controls.Add(btnReload);
            panelTop.Controls.Add(btnSearch);
            panelTop.Controls.Add(cboFilterCategory);
            panelTop.Controls.Add(txtSearchBarcode);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Padding = new Padding(15);
            panelTop.Size = new Size(1050, 60);
            panelTop.TabIndex = 0;
            // 
            // btnReload
            // 
            btnReload.BackColor = Color.FromArgb(71, 85, 105);
            btnReload.Cursor = Cursors.Hand;
            btnReload.FlatAppearance.BorderSize = 0;
            btnReload.FlatStyle = FlatStyle.Flat;
            btnReload.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnReload.ForeColor = Color.White;
            btnReload.Location = new Point(660, 14);
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(100, 32);
            btnReload.TabIndex = 3;
            btnReload.Text = "🔄 Tải lại";
            btnReload.UseVisualStyleBackColor = false;
            btnReload.Click += btnReload_Click;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(41, 100, 180);
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(540, 14);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(110, 32);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "🔍 Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // cboFilterCategory
            // 
            cboFilterCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFilterCategory.FormattingEnabled = true;
            cboFilterCategory.Location = new Point(280, 16);
            cboFilterCategory.Name = "cboFilterCategory";
            cboFilterCategory.Size = new Size(240, 28);
            cboFilterCategory.TabIndex = 1;
            cboFilterCategory.SelectedIndexChanged += cboFilterCategory_SelectedIndexChanged;
            // 
            // txtSearchBarcode
            // 
            txtSearchBarcode.Location = new Point(15, 16);
            txtSearchBarcode.Name = "txtSearchBarcode";
            txtSearchBarcode.PlaceholderText = "Nhập mã vạch hoặc tên sản phẩm...";
            txtSearchBarcode.Size = new Size(250, 27);
            txtSearchBarcode.TabIndex = 0;
            txtSearchBarcode.KeyDown += txtSearchBarcode_KeyDown;
            // 
            // panelDetail
            // 
            panelDetail.BackColor = Color.White;
            panelDetail.Controls.Add(btnClear);
            panelDetail.Controls.Add(btnDelete);
            panelDetail.Controls.Add(btnUpdate);
            panelDetail.Controls.Add(btnAdd);
            panelDetail.Controls.Add(cboCategory);
            panelDetail.Controls.Add(nudStock);
            panelDetail.Controls.Add(nudPrice);
            panelDetail.Controls.Add(txtProductName);
            panelDetail.Controls.Add(txtBarcode);
            panelDetail.Controls.Add(txtId);
            panelDetail.Controls.Add(lblCategory);
            panelDetail.Controls.Add(lblStock);
            panelDetail.Controls.Add(lblPrice);
            panelDetail.Controls.Add(lblProductName);
            panelDetail.Controls.Add(lblBarcode);
            panelDetail.Controls.Add(lblId);
            panelDetail.Dock = DockStyle.Right;
            panelDetail.Location = new Point(710, 60);
            panelDetail.Name = "panelDetail";
            panelDetail.Padding = new Padding(20);
            panelDetail.Size = new Size(340, 600);
            panelDetail.TabIndex = 1;
            // 
            // btnClear
            // 
            btnClear.Cursor = Cursors.Hand;
            btnClear.Location = new Point(180, 440);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(140, 42);
            btnClear.TabIndex = 15;
            btnClear.Text = "Làm mới";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(239, 68, 68);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(20, 440);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(140, 42);
            btnDelete.TabIndex = 14;
            btnDelete.Text = "🗑  Xóa SP";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(245, 158, 11);
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(180, 380);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(140, 42);
            btnUpdate.TabIndex = 13;
            btnUpdate.Text = "✏  Cập nhật";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(16, 185, 129);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(20, 380);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(140, 42);
            btnAdd.TabIndex = 12;
            btnAdd.Text = "➕  Thêm mới";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // cboCategory
            // 
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.FormattingEnabled = true;
            cboCategory.Location = new Point(20, 320);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(300, 28);
            cboCategory.TabIndex = 11;
            // 
            // nudStock
            // 
            nudStock.Location = new Point(20, 260);
            nudStock.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudStock.Name = "nudStock";
            nudStock.Size = new Size(300, 27);
            nudStock.TabIndex = 10;
            // 
            // nudPrice
            // 
            nudPrice.DecimalPlaces = 0;
            nudPrice.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            nudPrice.Location = new Point(20, 200);
            nudPrice.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            nudPrice.Name = "nudPrice";
            nudPrice.Size = new Size(300, 27);
            nudPrice.TabIndex = 9;
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(20, 142);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(300, 27);
            txtProductName.TabIndex = 8;
            // 
            // txtBarcode
            // 
            txtBarcode.Location = new Point(20, 85);
            txtBarcode.Name = "txtBarcode";
            txtBarcode.Size = new Size(300, 27);
            txtBarcode.TabIndex = 7;
            // 
            // txtId
            // 
            txtId.Location = new Point(20, 28);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(300, 27);
            txtId.TabIndex = 6;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCategory.Location = new Point(20, 295);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(130, 20);
            lblCategory.TabIndex = 5;
            lblCategory.Text = "Danh mục nhóm:";
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStock.Location = new Point(20, 235);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(103, 20);
            lblStock.TabIndex = 4;
            lblStock.Text = "Số lượng tồn:";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPrice.Location = new Point(20, 175);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(69, 20);
            lblPrice.TabIndex = 3;
            lblPrice.Text = "Đơn giá:";
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblProductName.Location = new Point(20, 118);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(110, 20);
            lblProductName.TabIndex = 2;
            lblProductName.Text = "Tên sản phẩm:";
            // 
            // lblBarcode
            // 
            lblBarcode.AutoSize = true;
            lblBarcode.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblBarcode.Location = new Point(20, 60);
            lblBarcode.Name = "lblBarcode";
            lblBarcode.Size = new Size(72, 20);
            lblBarcode.TabIndex = 1;
            lblBarcode.Text = "Mã vạch:";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblId.Location = new Point(20, 5);
            lblId.Name = "lblId";
            lblId.Size = new Size(106, 20);
            lblId.TabIndex = 0;
            lblId.Text = "Mã Sản phẩm:";
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.BackgroundColor = Color.White;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Dock = DockStyle.Fill;
            dgvProducts.Location = new Point(0, 60);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.RowTemplate.Height = 29;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(710, 600);
            dgvProducts.TabIndex = 2;
            dgvProducts.CellClick += dgvProducts_CellClick;
            //
            // panelPaging
            //
            panelPaging.BackColor = Color.White;
            panelPaging.Dock = DockStyle.Bottom;
            panelPaging.Height = 52;
            panelPaging.Padding = new Padding(12, 8, 12, 8);
            panelPaging.Controls.Add(btnPrev);
            panelPaging.Controls.Add(lblPaging);
            panelPaging.Controls.Add(btnNext);
            //
            // btnPrev
            //
            btnPrev.Name = "btnPrev";
            btnPrev.Text = "<< Trang trước";
            btnPrev.AutoSize = true;
            btnPrev.Enabled = false;
            btnPrev.Click += btnPrev_Click;
            //
            // lblPaging
            //
            lblPaging.Name = "lblPaging";
            lblPaging.Text = "Chưa tải dữ liệu";
            lblPaging.AutoSize = true;
            lblPaging.Padding = new Padding(8, 7, 8, 0);
            //
            // btnNext
            //
            btnNext.Name = "btnNext";
            btnNext.Text = "Trang sau >>";
            btnNext.AutoSize = true;
            btnNext.Enabled = false;
            btnNext.Click += btnNext_Click;
            // 
            // FormProductManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1050, 660);
            Controls.Add(dgvProducts);
            Controls.Add(panelDetail);
            Controls.Add(panelTop);
            Controls.Add(panelPaging);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormProductManagement";
            Text = "Quản lý Sản phẩm";
            Load += FormProductManagement_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelDetail.ResumeLayout(false);
            panelDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private TextBox txtSearchBarcode;
        private ComboBox cboFilterCategory;
        private Button btnSearch;
        private Button btnReload;
        private Panel panelDetail;
        private Label lblId;
        private Label lblBarcode;
        private Label lblProductName;
        private Label lblPrice;
        private Label lblStock;
        private Label lblCategory;
        private TextBox txtId;
        private TextBox txtBarcode;
        private TextBox txtProductName;
        private NumericUpDown nudPrice;
        private NumericUpDown nudStock;
        private ComboBox cboCategory;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private DataGridView dgvProducts;
        private FlowLayoutPanel panelPaging;
        private Button btnPrev;
        private Label lblPaging;
        private Button btnNext;
    }
}
