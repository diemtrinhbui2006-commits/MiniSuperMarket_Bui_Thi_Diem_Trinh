
using System.Net.Http.Json;
using System.Text.Json;

namespace MiniSupermarket.WinForms
{
    public partial class FormLogin : Form
    {
        // Kết nối đến Web API
        private static readonly HttpClient _client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7046/api/")
        };

        public FormLogin()
        {
            InitializeComponent();
        }

        // =========================================================
        // ĐĂNG NHẬP
        // =========================================================
        private async void btnLogin_Click(object? sender, EventArgs e)
        {
            string username = txtUser.Text.Trim();
            string password = txtPass.Text.Trim();

            // Kiểm tra dữ liệu nhập
            if (string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(password))
            {
                MessageBox.Show(
                    "Vui lòng nhập đầy đủ tài khoản và mật khẩu!",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                // Dữ liệu gửi lên API
                var loginData = new
                {
                    Username = username,
                    Password = password
                };

                // Gọi API: POST /api/auth/login
                var response = await _client.PostAsJsonAsync(
                    "auth/login",
                    loginData);

                if (response.IsSuccessStatusCode)
                {
                    // Đọc JSON trả về
                    string jsonString =
                        await response.Content.ReadAsStringAsync();

                    using var doc =
                        JsonDocument.Parse(jsonString);

                    // Lưu JWT Token
                    if (doc.RootElement.TryGetProperty(
                        "token", out JsonElement tokenElement))
                    {
                        SessionManager.JwtToken =
                            tokenElement.GetString() ?? string.Empty;
                    }

                    // Lưu Role
                    if (doc.RootElement.TryGetProperty(
                        "role", out JsonElement roleElement))
                    {
                        SessionManager.CurrentRole =
                            roleElement.GetString() ?? string.Empty;
                    }

                    MessageBox.Show(
                        $"Đăng nhập thành công với quyền: {SessionManager.CurrentRole}",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // Mở Form chính
                    FormCategoryManagement mainForm =
                        new FormCategoryManagement();

                    this.Hide();

                    mainForm.ShowDialog();

                    // Đóng Form Login
                    this.Close();
                }
                else
                {
                    // Lấy nội dung lỗi từ API
                    string errorMessage =
                        await response.Content.ReadAsStringAsync();

                    MessageBox.Show(
                        "Sai tài khoản hoặc mật khẩu!\n\n" +
                        $"API trả về: {errorMessage}",
                        "Đăng nhập thất bại",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(
                    "Không thể kết nối đến Web API!\n\n" +
                    "Hãy kiểm tra API đã chạy chưa.\n\n" +
                    $"Chi tiết: {ex.Message}",
                    "Lỗi kết nối",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Đã xảy ra lỗi:\n\n" +
                    ex.Message,
                    "Lỗi hệ thống",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // CÁC EVENT KHÁC
        // =========================================================

        private void FormLogin_Load(object? sender, EventArgs e)
        {
        }

        private void label1_Click(object? sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object? sender, EventArgs e)
        {
        }

        private void button1_Click(object? sender, EventArgs e)
        {
        }
    }
}
