namespace MiniSupermarket.WinForms
{
    partial class FormQuickReport
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
            panelHeader = new Panel();
            btnRunReport = new Button();
            lblPickDate = new Label();
            dtpReportDate = new DateTimePicker();
            panelCards = new TableLayoutPanel();
            card1 = new Panel();
            lblTotalOrders = new Label();
            lblTitleCard1 = new Label();
            card2 = new Panel();
            lblTotalRevenue = new Label();
            lblTitleCard2 = new Label();
            card3 = new Panel();
            lblBestSeller = new Label();
            lblTitleCard3 = new Label();
            panelHeader.SuspendLayout();
            panelCards.SuspendLayout();
            card1.SuspendLayout();
            card2.SuspendLayout();
            card3.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.White;
            panelHeader.Controls.Add(btnRunReport);
            panelHeader.Controls.Add(lblPickDate);
            panelHeader.Controls.Add(dtpReportDate);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(20);
            panelHeader.Size = new Size(1050, 75);
            panelHeader.TabIndex = 0;
            // 
            // btnRunReport
            // 
            btnRunReport.BackColor = Color.FromArgb(41, 100, 180);
            btnRunReport.Cursor = Cursors.Hand;
            btnRunReport.FlatAppearance.BorderSize = 0;
            btnRunReport.FlatStyle = FlatStyle.Flat;
            btnRunReport.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnRunReport.ForeColor = Color.White;
            btnRunReport.Location = new Point(360, 18);
            btnRunReport.Name = "btnRunReport";
            btnRunReport.Size = new Size(180, 40);
            btnRunReport.TabIndex = 2;
            btnRunReport.Text = "📊  Xem Báo Cáo";
            btnRunReport.UseVisualStyleBackColor = false;
            btnRunReport.Click += btnRunReport_Click;
            // 
            // lblPickDate
            // 
            lblPickDate.AutoSize = true;
            lblPickDate.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            lblPickDate.Location = new Point(25, 25);
            lblPickDate.Name = "lblPickDate";
            lblPickDate.Size = new Size(109, 25);
            lblPickDate.TabIndex = 1;
            lblPickDate.Text = "Chọn ngày:";
            // 
            // dtpReportDate
            // 
            dtpReportDate.CustomFormat = "dd/MM/yyyy";
            dtpReportDate.Font = new Font("Segoe UI", 10.8F);
            dtpReportDate.Format = DateTimePickerFormat.Custom;
            dtpReportDate.Location = new Point(140, 22);
            dtpReportDate.Name = "dtpReportDate";
            dtpReportDate.Size = new Size(200, 31);
            dtpReportDate.TabIndex = 0;
            // 
            // panelCards
            // 
            panelCards.ColumnCount = 3;
            panelCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            panelCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            panelCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.34F));
            panelCards.Controls.Add(card1, 0, 0);
            panelCards.Controls.Add(card2, 1, 0);
            panelCards.Controls.Add(card3, 2, 0);
            panelCards.Dock = DockStyle.Top;
            panelCards.Location = new Point(0, 75);
            panelCards.Name = "panelCards";
            panelCards.Padding = new Padding(20);
            panelCards.RowCount = 1;
            panelCards.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            panelCards.Size = new Size(1050, 200);
            panelCards.TabIndex = 1;
            // 
            // card1
            // 
            card1.BackColor = Color.FromArgb(59, 130, 246);
            card1.Controls.Add(lblTotalOrders);
            card1.Controls.Add(lblTitleCard1);
            card1.Dock = DockStyle.Fill;
            card1.Location = new Point(23, 23);
            card1.Margin = new Padding(3, 3, 15, 3);
            card1.Name = "card1";
            card1.Padding = new Padding(15);
            card1.Size = new Size(318, 154);
            card1.TabIndex = 0;
            // 
            // lblTotalOrders
            // 
            lblTotalOrders.Dock = DockStyle.Fill;
            lblTotalOrders.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblTotalOrders.ForeColor = Color.White;
            lblTotalOrders.Location = new Point(15, 45);
            lblTotalOrders.Name = "lblTotalOrders";
            lblTotalOrders.Size = new Size(288, 94);
            lblTotalOrders.TabIndex = 1;
            lblTotalOrders.Text = "0";
            lblTotalOrders.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitleCard1
            // 
            lblTitleCard1.Dock = DockStyle.Top;
            lblTitleCard1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTitleCard1.ForeColor = Color.White;
            lblTitleCard1.Location = new Point(15, 15);
            lblTitleCard1.Name = "lblTitleCard1";
            lblTitleCard1.Size = new Size(288, 30);
            lblTitleCard1.TabIndex = 0;
            lblTitleCard1.Text = "TỔNG SỐ HÓA ĐƠN";
            // 
            // card2
            // 
            card2.BackColor = Color.FromArgb(16, 185, 129);
            card2.Controls.Add(lblTotalRevenue);
            card2.Controls.Add(lblTitleCard2);
            card2.Dock = DockStyle.Fill;
            card2.Location = new Point(359, 23);
            card2.Margin = new Padding(3, 3, 15, 3);
            card2.Name = "card2";
            card2.Padding = new Padding(15);
            card2.Size = new Size(318, 154);
            card2.TabIndex = 1;
            // 
            // lblTotalRevenue
            // 
            lblTotalRevenue.Dock = DockStyle.Fill;
            lblTotalRevenue.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTotalRevenue.ForeColor = Color.White;
            lblTotalRevenue.Location = new Point(15, 45);
            lblTotalRevenue.Name = "lblTotalRevenue";
            lblTotalRevenue.Size = new Size(288, 94);
            lblTotalRevenue.TabIndex = 1;
            lblTotalRevenue.Text = "0 đ";
            lblTotalRevenue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitleCard2
            // 
            lblTitleCard2.Dock = DockStyle.Top;
            lblTitleCard2.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTitleCard2.ForeColor = Color.White;
            lblTitleCard2.Location = new Point(15, 15);
            lblTitleCard2.Name = "lblTitleCard2";
            lblTitleCard2.Size = new Size(288, 30);
            lblTitleCard2.TabIndex = 0;
            lblTitleCard2.Text = "TỔNG DOANH THU";
            // 
            // card3
            // 
            card3.BackColor = Color.FromArgb(245, 158, 11);
            card3.Controls.Add(lblBestSeller);
            card3.Controls.Add(lblTitleCard3);
            card3.Dock = DockStyle.Fill;
            card3.Location = new Point(695, 23);
            card3.Name = "card3";
            card3.Padding = new Padding(15);
            card3.Size = new Size(332, 154);
            card3.TabIndex = 2;
            // 
            // lblBestSeller
            // 
            lblBestSeller.Dock = DockStyle.Fill;
            lblBestSeller.Font = new Font("Segoe UI", 13.5F, FontStyle.Bold);
            lblBestSeller.ForeColor = Color.White;
            lblBestSeller.Location = new Point(15, 45);
            lblBestSeller.Name = "lblBestSeller";
            lblBestSeller.Size = new Size(302, 94);
            lblBestSeller.TabIndex = 1;
            lblBestSeller.Text = "Chưa có dữ liệu";
            lblBestSeller.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitleCard3
            // 
            lblTitleCard3.Dock = DockStyle.Top;
            lblTitleCard3.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTitleCard3.ForeColor = Color.White;
            lblTitleCard3.Location = new Point(15, 15);
            lblTitleCard3.Name = "lblTitleCard3";
            lblTitleCard3.Size = new Size(302, 30);
            lblTitleCard3.TabIndex = 0;
            lblTitleCard3.Text = "MẶT HÀNG BÁN CHẠY NHẤT";
            // 
            // FormQuickReport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1050, 660);
            Controls.Add(panelCards);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormQuickReport";
            Text = "Báo cáo Doanh thu";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelCards.ResumeLayout(false);
            card1.ResumeLayout(false);
            card2.ResumeLayout(false);
            card3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private DateTimePicker dtpReportDate;
        private Label lblPickDate;
        private Button btnRunReport;
        private TableLayoutPanel panelCards;
        private Panel card1;
        private Label lblTitleCard1;
        private Label lblTotalOrders;
        private Panel card2;
        private Label lblTitleCard2;
        private Label lblTotalRevenue;
        private Panel card3;
        private Label lblTitleCard3;
        private Label lblBestSeller;
    }
}
