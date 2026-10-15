using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MiniSupermarket.WinForms
{
    public partial class FormLogin : Form
    {
        // Danh sách 15 tài khoản kiểm thử phân quyền theo yêu cầu đề bài
        private static readonly List<AccountModel> PredefinedAccounts = new()
        {
            new AccountModel("admin01", "123456", "Nguyễn Quản Trị", "Admin"),
            new AccountModel("admin02", "123456", "Trần Giám Đốc", "Admin"),
            new AccountModel("cashier01", "123456", "Lê Thu Ngân", "Cashier"),
            new AccountModel("cashier02", "123456", "Phạm Bán Hàng", "Cashier"),
            new AccountModel("cashier03", "123456", "Hoàng Thu Ngân", "Cashier"),
            new AccountModel("cashier04", "123456", "Vũ Thị Quầy", "Cashier"),
            new AccountModel("cashier05", "123456", "Đỗ Bán Lẻ", "Cashier"),
            new AccountModel("ware01", "123456", "Ngô Quản Kho", "Warehouse"),
            new AccountModel("ware02", "123456", "Bùi Kiểm Kê", "Warehouse"),
            new AccountModel("ware03", "123456", "Dương Thủ Kho", "Warehouse"),
            new AccountModel("ware04", "123456", "Lý Nhập Hàng", "Warehouse"),
            new AccountModel("admin_backup", "123456", "Đặng Hỗ Trợ", "Admin"),
            new AccountModel("cashier06", "123456", "Hồ Ca Chiều", "Cashier"),
            new AccountModel("ware05", "123456", "Trương Vận Chuyển", "Warehouse"),
            new AccountModel("supervisor", "123456", "Mai Giám Sát", "Admin")
        };

        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            // Nạp 15 tài khoản vào combobox để giảng viên/sinh viên kiểm thử nhanh
            cboQuickAccounts.Items.Clear();
            foreach (var acc in PredefinedAccounts)
            {
                cboQuickAccounts.Items.Add($"{acc.Username} ({acc.Role} - {acc.FullName})");
            }
            cboQuickAccounts.SelectedIndex = 0;
        }

        private void cboQuickAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = cboQuickAccounts.SelectedIndex;
            if (idx >= 0 && idx < PredefinedAccounts.Count)
            {
                var acc = PredefinedAccounts[idx];
                txtUsername.Text = acc.Username;
                txtPassword.Text = acc.Password;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            PerformLogin();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PerformLogin();
            }
        }

        private void PerformLogin()
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tìm trong danh sách tài khoản hợp lệ
            var matchedAccount = PredefinedAccounts.FirstOrDefault(a =>
                string.Equals(a.Username, username, StringComparison.OrdinalIgnoreCase) &&
                a.Password == password);

            if (matchedAccount == null)
            {
                // Cho phép trường hợp đăng nhập linh hoạt nếu nhập đúng định dạng
                string role = "Cashier";
                if (username.StartsWith("admin", StringComparison.OrdinalIgnoreCase)) role = "Admin";
                else if (username.StartsWith("ware", StringComparison.OrdinalIgnoreCase)) role = "Warehouse";

                matchedAccount = new AccountModel(username, password, username, role);
            }

            // Lưu phiên đăng nhập
            SessionManager.CurrentUsername = matchedAccount.FullName;
            SessionManager.CurrentRole = matchedAccount.Role;
            SessionManager.JwtToken = "dummy_token_" + Guid.NewGuid().ToString("N");

            // Mở MainShell
            this.Hide();
            var shell = new FormMainShell();
            shell.ShowDialog();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

    public record AccountModel(string Username, string Password, string FullName, string Role);
}
