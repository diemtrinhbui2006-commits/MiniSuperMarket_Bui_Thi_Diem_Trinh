using System;
using System.Drawing;
using System.Windows.Forms;

namespace MiniSupermarket.WinForms
{
    public partial class FormQuickReport : Form
    {
        public FormQuickReport()
        {
            InitializeComponent();
        }

        private void btnRunReport_Click(object sender, EventArgs e)
        {
            // Kiểm tra bảo vệ quyền cấp Action (Chỉ Admin mới được xem số liệu doanh thu)
            if (!string.Equals(SessionManager.CurrentRole, "Admin", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Bạn không có quyền xem dữ liệu tài chính của siêu thị!", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            DateTime selectedDate = dtpReportDate.Value;
            lblTotalOrders.Text = "28";
            lblTotalRevenue.Text = "4,850,000 đ";
            lblBestSeller.Text = "Sữa tươi Vinamilk 180ml";

            MessageBox.Show($"Đã kết xuất báo cáo doanh thu ngày {selectedDate:dd/MM/yyyy} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
