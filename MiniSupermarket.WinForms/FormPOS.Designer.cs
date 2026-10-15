namespace MiniSupermarket.WinForms
{
    partial class FormPOS
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
            panelCart = new Panel();
            dgvCart = new DataGridView();
            panelBarcode = new Panel();
            lblBarcode = new Label();
            txtBarcode = new TextBox();
            panelCheckout = new Panel();
            btnClearCart = new Button();
            btnCheckout = new Button();
            lblChange = new Label();
            lblChangeTitle = new Label();
            txtCashReceived = new TextBox();
            lblCashTitle = new Label();
            lblTotalAmount = new Label();
            lblTotalTitle = new Label();
            lblCustomerName = new Label();
            txtCustomerPhone = new TextBox();
            lblCustomerPhone = new Label();
            panelCart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            panelBarcode.SuspendLayout();
            panelCheckout.SuspendLayout();
            SuspendLayout();
            // 
            // panelCart
            // 
            panelCart.Controls.Add(dgvCart);
            panelCart.Controls.Add(panelBarcode);
            panelCart.Dock = DockStyle.Fill;
            panelCart.Location = new Point(0, 0);
            panelCart.Name = "panelCart";
            panelCart.Padding = new Padding(15);
            panelCart.Size = new Size(680, 660);
            panelCart.TabIndex = 0;
            // 
            // dgvCart
            // 
            dgvCart.AllowUserToAddRows = false;
            dgvCart.BackgroundColor = Color.White;
            dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCart.Dock = DockStyle.Fill;
            dgvCart.Location = new Point(15, 75);
            dgvCart.Name = "dgvCart";
            dgvCart.ReadOnly = true;
            dgvCart.RowHeadersWidth = 51;
            dgvCart.RowTemplate.Height = 29;
            dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCart.Size = new Size(650, 570);
            dgvCart.TabIndex = 1;
            // 
            // panelBarcode
            // 
            panelBarcode.Controls.Add(lblBarcode);
            panelBarcode.Controls.Add(txtBarcode);
            panelBarcode.Dock = DockStyle.Top;
            panelBarcode.Location = new Point(15, 15);
            panelBarcode.Name = "panelBarcode";
            panelBarcode.Size = new Size(650, 60);
            panelBarcode.TabIndex = 0;
            // 
            // lblBarcode
            // 
            lblBarcode.AutoSize = true;
            lblBarcode.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblBarcode.ForeColor = Color.FromArgb(30, 41, 59);
            lblBarcode.Location = new Point(3, 14);
            lblBarcode.Name = "lblBarcode";
            lblBarcode.Size = new Size(168, 25);
            lblBarcode.TabIndex = 0;
            lblBarcode.Text = "Quét mã Barcode:";
            // 
            // txtBarcode
            // 
            txtBarcode.Font = new Font("Segoe UI", 12F);
            txtBarcode.Location = new Point(180, 10);
            txtBarcode.Name = "txtBarcode";
            txtBarcode.PlaceholderText = "Nhập mã vạch và nhấn ENTER...";
            txtBarcode.Size = new Size(460, 34);
            txtBarcode.TabIndex = 1;
            txtBarcode.KeyDown += txtBarcode_KeyDown;
            // 
            // panelCheckout
            // 
            panelCheckout.BackColor = Color.White;
            panelCheckout.Controls.Add(btnClearCart);
            panelCheckout.Controls.Add(btnCheckout);
            panelCheckout.Controls.Add(lblChange);
            panelCheckout.Controls.Add(lblChangeTitle);
            panelCheckout.Controls.Add(txtCashReceived);
            panelCheckout.Controls.Add(lblCashTitle);
            panelCheckout.Controls.Add(lblTotalAmount);
            panelCheckout.Controls.Add(lblTotalTitle);
            panelCheckout.Controls.Add(lblCustomerName);
            panelCheckout.Controls.Add(txtCustomerPhone);
            panelCheckout.Controls.Add(lblCustomerPhone);
            panelCheckout.Dock = DockStyle.Right;
            panelCheckout.Location = new Point(680, 0);
            panelCheckout.Name = "panelCheckout";
            panelCheckout.Padding = new Padding(20);
            panelCheckout.Size = new Size(370, 660);
            panelCheckout.TabIndex = 1;
            // 
            // btnClearCart
            // 
            btnClearCart.BackColor = Color.FromArgb(239, 68, 68);
            btnClearCart.Cursor = Cursors.Hand;
            btnClearCart.FlatAppearance.BorderSize = 0;
            btnClearCart.FlatStyle = FlatStyle.Flat;
            btnClearCart.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClearCart.ForeColor = Color.White;
            btnClearCart.Location = new Point(20, 580);
            btnClearCart.Name = "btnClearCart";
            btnClearCart.Size = new Size(330, 45);
            btnClearCart.TabIndex = 10;
            btnClearCart.Text = "🗑  HỦY GIỎ HÀNG";
            btnClearCart.UseVisualStyleBackColor = false;
            btnClearCart.Click += btnClearCart_Click;
            // 
            // btnCheckout
            // 
            btnCheckout.BackColor = Color.FromArgb(16, 185, 129);
            btnCheckout.Cursor = Cursors.Hand;
            btnCheckout.FlatAppearance.BorderSize = 0;
            btnCheckout.FlatStyle = FlatStyle.Flat;
            btnCheckout.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCheckout.ForeColor = Color.White;
            btnCheckout.Location = new Point(20, 510);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(330, 55);
            btnCheckout.TabIndex = 9;
            btnCheckout.Text = "💳  THANH TOÁN (F9)";
            btnCheckout.UseVisualStyleBackColor = false;
            btnCheckout.Click += btnCheckout_Click;
            // 
            // lblChange
            // 
            lblChange.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblChange.ForeColor = Color.FromArgb(30, 41, 59);
            lblChange.Location = new Point(20, 440);
            lblChange.Name = "lblChange";
            lblChange.Size = new Size(330, 35);
            lblChange.TabIndex = 8;
            lblChange.Text = "0 đ";
            lblChange.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblChangeTitle
            // 
            lblChangeTitle.AutoSize = true;
            lblChangeTitle.Font = new Font("Segoe UI", 10F);
            lblChangeTitle.Location = new Point(20, 415);
            lblChangeTitle.Name = "lblChangeTitle";
            lblChangeTitle.Size = new Size(134, 23);
            lblChangeTitle.TabIndex = 7;
            lblChangeTitle.Text = "Tiền thừa trả lại:";
            // 
            // txtCashReceived
            // 
            txtCashReceived.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            txtCashReceived.Location = new Point(20, 360);
            txtCashReceived.Name = "txtCashReceived";
            txtCashReceived.Size = new Size(330, 39);
            txtCashReceived.TabIndex = 6;
            txtCashReceived.TextAlign = HorizontalAlignment.Right;
            txtCashReceived.TextChanged += txtCashReceived_TextChanged;
            // 
            // lblCashTitle
            // 
            lblCashTitle.AutoSize = true;
            lblCashTitle.Font = new Font("Segoe UI", 10F);
            lblCashTitle.Location = new Point(20, 330);
            lblCashTitle.Name = "lblCashTitle";
            lblCashTitle.Size = new Size(125, 23);
            lblCashTitle.TabIndex = 5;
            lblCashTitle.Text = "Tiền khách đưa:";
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTotalAmount.ForeColor = Color.FromArgb(220, 38, 38);
            lblTotalAmount.Location = new Point(20, 240);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(330, 60);
            lblTotalAmount.TabIndex = 4;
            lblTotalAmount.Text = "0 đ";
            lblTotalAmount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalTitle
            // 
            lblTotalTitle.AutoSize = true;
            lblTotalTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTotalTitle.Location = new Point(20, 210);
            lblTotalTitle.Name = "lblTotalTitle";
            lblTotalTitle.Size = new Size(155, 25);
            lblTotalTitle.TabIndex = 3;
            lblTotalTitle.Text = "Tổng thanh toán:";
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblCustomerName.ForeColor = Color.FromArgb(71, 85, 105);
            lblCustomerName.Location = new Point(20, 115);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(182, 23);
            lblCustomerName.TabIndex = 2;
            lblCustomerName.Text = "Khách hàng: Khách lẻ";
            // 
            // txtCustomerPhone
            // 
            txtCustomerPhone.Font = new Font("Segoe UI", 11F);
            txtCustomerPhone.Location = new Point(20, 65);
            txtCustomerPhone.Name = "txtCustomerPhone";
            txtCustomerPhone.PlaceholderText = "Nhập SĐT khách hàng...";
            txtCustomerPhone.Size = new Size(330, 32);
            txtCustomerPhone.TabIndex = 1;
            // 
            // lblCustomerPhone
            // 
            lblCustomerPhone.AutoSize = true;
            lblCustomerPhone.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCustomerPhone.Location = new Point(20, 35);
            lblCustomerPhone.Name = "lblCustomerPhone";
            lblCustomerPhone.Size = new Size(157, 23);
            lblCustomerPhone.TabIndex = 0;
            lblCustomerPhone.Text = "Khách thành viên:";
            // 
            // FormPOS
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1050, 660);
            Controls.Add(panelCart);
            Controls.Add(panelCheckout);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormPOS";
            Text = "Quầy Bán hàng POS";
            panelCart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            panelBarcode.ResumeLayout(false);
            panelBarcode.PerformLayout();
            panelCheckout.ResumeLayout(false);
            panelCheckout.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelCart;
        private DataGridView dgvCart;
        private Panel panelBarcode;
        private Label lblBarcode;
        private TextBox txtBarcode;
        private Panel panelCheckout;
        private Label lblCustomerPhone;
        private TextBox txtCustomerPhone;
        private Label lblCustomerName;
        private Label lblTotalTitle;
        private Label lblTotalAmount;
        private Label lblCashTitle;
        private TextBox txtCashReceived;
        private Label lblChangeTitle;
        private Label lblChange;
        private Button btnCheckout;
        private Button btnClearCart;
    }
}
