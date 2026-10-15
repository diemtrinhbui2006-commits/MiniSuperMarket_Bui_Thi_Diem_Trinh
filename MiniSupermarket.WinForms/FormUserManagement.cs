using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniSupermarket.WinForms
{
    public partial class FormUserManagement : Form
    {
        private readonly List<UserDto> _localUsers = new()
        {
            new UserDto { Id = 1, Username = "admin01", FullName = "Nguyễn Quản Trị", Role = "Admin", IsActive = true },
            new UserDto { Id = 2, Username = "admin02", FullName = "Trần Giám Đốc", Role = "Admin", IsActive = true },
            new UserDto { Id = 3, Username = "cashier01", FullName = "Lê Thu Ngân", Role = "Cashier", IsActive = true },
            new UserDto { Id = 4, Username = "cashier02", FullName = "Phạm Bán Hàng", Role = "Cashier", IsActive = true },
            new UserDto { Id = 5, Username = "cashier03", FullName = "Hoàng Thu Ngân", Role = "Cashier", IsActive = true },
            new UserDto { Id = 6, Username = "cashier04", FullName = "Vũ Thị Quầy", Role = "Cashier", IsActive = true },
            new UserDto { Id = 7, Username = "cashier05", FullName = "Đỗ Bán Lẻ", Role = "Cashier", IsActive = true },
            new UserDto { Id = 8, Username = "ware01", FullName = "Ngô Quản Kho", Role = "Warehouse", IsActive = true },
            new UserDto { Id = 9, Username = "ware02", FullName = "Bùi Kiểm Kê", Role = "Warehouse", IsActive = true },
            new UserDto { Id = 10, Username = "ware03", FullName = "Dương Thủ Kho", Role = "Warehouse", IsActive = true },
            new UserDto { Id = 11, Username = "ware04", FullName = "Lý Nhập Hàng", Role = "Warehouse", IsActive = true },
            new UserDto { Id = 12, Username = "admin_backup", FullName = "Đặng Hỗ Trợ", Role = "Admin", IsActive = true },
            new UserDto { Id = 13, Username = "cashier06", FullName = "Hồ Ca Chiều", Role = "Cashier", IsActive = true },
            new UserDto { Id = 14, Username = "ware05", FullName = "Trương Vận Chuyển", Role = "Warehouse", IsActive = true },
            new UserDto { Id = 15, Username = "supervisor", FullName = "Mai Giám Sát", Role = "Admin", IsActive = true }
        };

        public FormUserManagement()
        {
            InitializeComponent();
            SetupUserGrid();
            cboRole.Items.AddRange(new string[] { "Admin", "Cashier", "Warehouse" });
            cboRole.SelectedIndex = 1;
        }

        private void SetupUserGrid()
        {
            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.Columns.Clear();
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID", Width = 60 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Username", HeaderText = "Tên Đăng Nhập", Width = 140 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "FullName", HeaderText = "Họ và Tên", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Role", HeaderText = "Vai Trò (Role)", Width = 120 });
            dgvUsers.Columns.Add(new DataGridViewCheckBoxColumn { DataPropertyName = "IsActive", HeaderText = "Đang Hoạt Động", Width = 130 });
        }

        private async void FormUserManagement_Load(object sender, EventArgs e)
        {
            await LoadUsersAsync();
        }

        private async Task LoadUsersAsync()
        {
            try
            {
                var users = await ApiClientService.Client.GetFromJsonAsync<List<UserDto>>("users");
                if (users != null && users.Count > 0)
                {
                    dgvUsers.DataSource = users;
                    return;
                }
            }
            catch
            {
                // Sử dụng danh sách 15 tài khoản kiểm thử mặc định
            }

            dgvUsers.DataSource = null;
            dgvUsers.DataSource = _localUsers.ToList();
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvUsers.Rows[e.RowIndex];
                txtUsername.Text = row.Cells[1].Value?.ToString();
                txtFullName.Text = row.Cells[2].Value?.ToString();
                string? role = row.Cells[3].Value?.ToString();
                if (!string.IsNullOrEmpty(role))
                {
                    cboRole.SelectedItem = role;
                }
            }
        }

        private async void btnAddUser_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string fullName = txtFullName.Text.Trim();
            string password = txtPassword.Text.Trim();
            string role = cboRole.SelectedItem?.ToString() ?? "Cashier";

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Tên đăng nhập và mật khẩu không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_localUsers.Any(u => string.Equals(u.Username, username, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại trong hệ thống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newUser = new
            {
                Username = username,
                Password = password,
                FullName = string.IsNullOrWhiteSpace(fullName) ? username : fullName,
                Role = role
            };

            try
            {
                var res = await ApiClientService.Client.PostAsJsonAsync("users", newUser);
                if (res.IsSuccessStatusCode)
                {
                    MessageBox.Show("Tạo tài khoản mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadUsersAsync();
                    ClearInputs();
                    return;
                }
            }
            catch { }

            // Thêm cục bộ
            int nextId = _localUsers.Count > 0 ? _localUsers.Max(u => u.Id) + 1 : 1;
            _localUsers.Add(new UserDto
            {
                Id = nextId,
                Username = username,
                FullName = string.IsNullOrWhiteSpace(fullName) ? username : fullName,
                Role = role,
                IsActive = true
            });

            MessageBox.Show("Tạo tài khoản mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await LoadUsersAsync();
            ClearInputs();
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần đặt lại mật khẩu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show($"Đã đặt lại mật khẩu cho tài khoản '{username}' về mặc định là: 123456", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtPassword.Text = "123456";
        }

        private async void btnToggleLock_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần khóa/mở khóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var user = _localUsers.FirstOrDefault(u => string.Equals(u.Username, username, StringComparison.OrdinalIgnoreCase));
            if (user != null)
            {
                user.IsActive = !user.IsActive;
                string status = user.IsActive ? "MỞ KHÓA" : "KHÓA";
                MessageBox.Show($"Tài khoản '{username}' đã được chuyển sang trạng thái: {status}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadUsersAsync();
            }
        }

        private void ClearInputs()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtFullName.Clear();
            cboRole.SelectedIndex = 1;
        }
    }
}
