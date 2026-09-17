using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace MiniSupermarket.WinForms
{
    public partial class FormCategoryManagement : Form
    {
        // =========================================================
        // HTTP CLIENT
        // =========================================================
        private static readonly HttpClient _client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7046/api/")
        };

        // =========================================================
        // CONSTRUCTOR
        // =========================================================
        public FormCategoryManagement()
        {
            InitializeComponent();

            // Đăng ký sự kiện Load
            this.Load += FormCategoryManagement_Load;

            // Cho phép DataGridView tự tạo cột
            dgvCategories.AutoGenerateColumns = true;

            // Đăng ký sự kiện click dòng
            dgvCategories.CellClick += dgvCategories_CellClick;
        }

        // =========================================================
        // TẠO HTTP CLIENT CÓ TOKEN
        // =========================================================
        private HttpClient GetAuthenticatedClient()
        {
            // Xóa Authorization cũ nếu có
            _client.DefaultRequestHeaders.Authorization = null;

            // Kiểm tra Token
            if (!string.IsNullOrWhiteSpace(SessionManager.JwtToken))
            {
                _client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue(
                        "Bearer",
                        SessionManager.JwtToken
                    );
            }

            return _client;
        }

        // =========================================================
        // FORM LOAD
        // =========================================================
        private async void FormCategoryManagement_Load(
            object? sender,
            EventArgs e)
        {
            await LoadDataAsync();
        }

        // =========================================================
        // LOAD DATA
        // GET: /api/categories
        // =========================================================
        private async Task LoadDataAsync()
        {
            try
            {
                // Lấy HttpClient có gắn JWT Token
                var client = GetAuthenticatedClient();

                var response = await client.GetAsync("categories");

                string json =
                    await response.Content.ReadAsStringAsync();

                // 401 = chưa đăng nhập / Token không hợp lệ
                if (response.StatusCode ==
                    System.Net.HttpStatusCode.Unauthorized)
                {
                    MessageBox.Show(
                        "Bạn chưa đăng nhập hoặc Token đã hết hạn!",
                        "Không được phép truy cập",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                // Nếu API trả lỗi
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show(
                        $"API trả về lỗi!\n\n" +
                        $"Status: {(int)response.StatusCode} - {response.StatusCode}\n\n" +
                        $"Response:\n{json}",
                        "Lỗi API",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    return;
                }

                // Chuyển JSON thành List
                var categories =
                    JsonSerializer.Deserialize<List<CategoryDto>>(
                        json,
                        new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        }
                    );

                if (categories == null)
                {
                    MessageBox.Show(
                        "Không đọc được dữ liệu từ API!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                // Hiển thị lên DataGridView
                dgvCategories.DataSource = null;
                dgvCategories.DataSource = categories;

                if (categories.Count == 0)
                {
                    MessageBox.Show(
                        "Không có dữ liệu nhóm hàng!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(
                    "Không thể kết nối đến Web API!\n\n" +
                    "Hãy kiểm tra Web API đã chạy chưa.\n\n" +
                    $"Chi tiết:\n{ex.Message}",
                    "Lỗi kết nối",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (JsonException ex)
            {
                MessageBox.Show(
                    "JSON API trả về không đúng định dạng!\n\n" +
                    $"Chi tiết:\n{ex.Message}",
                    "Lỗi JSON",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Đã xảy ra lỗi:\n\n{ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =========================================================
        // BUTTON LOAD
        // =========================================================
        private async void btnLoad_Click(
            object? sender,
            EventArgs e)
        {
            await LoadDataAsync();
        }

        // =========================================================
        // CLICK DATA GRID VIEW
        // =========================================================
        private void dgvCategories_CellClick(
            object? sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            try
            {
                DataGridViewRow row =
                    dgvCategories.Rows[e.RowIndex];

                // CategoryId
                if (row.Cells["CategoryId"].Value != null)
                {
                    txtId.Text =
                        row.Cells["CategoryId"].Value.ToString();
                }

                // CategoryName
                if (row.Cells["CategoryName"].Value != null)
                {
                    txtCategoryName.Text =
                        row.Cells["CategoryName"].Value.ToString();
                }

                // Description
                if (row.Cells["Description"].Value != null)
                {
                    txtDescription.Text =
                        row.Cells["Description"].Value.ToString();
                }
                else
                {
                    txtDescription.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Không thể lấy dữ liệu dòng đã chọn!\n\n{ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =========================================================
        // CREATE
        // POST: /api/categories
        // =========================================================
        private async void btnAdd_Click(
            object? sender,
            EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập tên nhóm hàng!",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtCategoryName.Focus();
                return;
            }

            try
            {
                var newCat = new
                {
                    CategoryName =
                        txtCategoryName.Text.Trim(),

                    Description =
                        txtDescription.Text.Trim()
                };

                var client = GetAuthenticatedClient();

                var response =
                    await client.PostAsJsonAsync(
                        "categories",
                        newCat
                    );

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show(
                        "Thêm mới thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    await LoadDataAsync();
                    ClearInputs();
                }
                else
                {
                    string error =
                        await response.Content.ReadAsStringAsync();

                    MessageBox.Show(
                        $"Thêm mới thất bại!\n\n" +
                        $"Status: {(int)response.StatusCode}\n\n" +
                        error,
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Lỗi khi thêm nhóm hàng:\n\n{ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =========================================================
        // UPDATE
        // PUT: /api/categories/{id}
        // =========================================================
        private async void btnUpdate_Click(
            object? sender,
            EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show(
                    "Vui lòng chọn nhóm hàng cần sửa!",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show(
                    "Tên nhóm hàng không được để trống!",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtCategoryName.Focus();
                return;
            }

            try
            {
                var updateCat = new
                {
                    CategoryId = id,

                    CategoryName =
                        txtCategoryName.Text.Trim(),

                    Description =
                        txtDescription.Text.Trim()
                };

                var client = GetAuthenticatedClient();

                var response =
                    await client.PutAsJsonAsync(
                        $"categories/{id}",
                        updateCat
                    );

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show(
                        "Cập nhật thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    await LoadDataAsync();
                    ClearInputs();
                }
                else
                {
                    string error =
                        await response.Content.ReadAsStringAsync();

                    MessageBox.Show(
                        $"Cập nhật thất bại!\n\n" +
                        $"Status: {(int)response.StatusCode}\n\n" +
                        error,
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Lỗi khi cập nhật:\n\n{ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =========================================================
        // DELETE
        // DELETE: /api/categories/{id}
        // =========================================================
        private async void btnDelete_Click(
            object? sender,
            EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show(
                    "Vui lòng chọn nhóm hàng cần xóa!",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            var confirm = MessageBox.Show(
                $"Bạn có chắc muốn xóa nhóm hàng ID = {id}?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                var client = GetAuthenticatedClient();

                var response =
                    await client.DeleteAsync(
                        $"categories/{id}"
                    );

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show(
                        "Xóa thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    await LoadDataAsync();
                    ClearInputs();
                }
                else
                {
                    string error =
                        await response.Content.ReadAsStringAsync();

                    MessageBox.Show(
                        $"Xóa thất bại!\n\n" +
                        $"Status: {(int)response.StatusCode}\n\n" +
                        error,
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Lỗi khi xóa:\n\n{ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =========================================================
        // SEARCH
        // GET: /api/categories/search?keyword=...
        // =========================================================
        private async void btnSearch_Click(
            object? sender,
            EventArgs e)
        {
            string keyword =
                txtKeyword.Text.Trim();

            // Không nhập từ khóa
            if (string.IsNullOrWhiteSpace(keyword))
            {
                await LoadDataAsync();
                return;
            }

            try
            {
                string encodedKeyword =
                    Uri.EscapeDataString(keyword);

                var client = GetAuthenticatedClient();

                var response =
                    await client.GetAsync(
                        $"categories/search?keyword={encodedKeyword}"
                    );

                string json =
                    await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show(
                        $"Tìm kiếm thất bại!\n\n" +
                        $"Status: {(int)response.StatusCode}\n\n" +
                        json,
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                var result =
                    JsonSerializer.Deserialize<List<CategoryDto>>(
                        json,
                        new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        }
                    );

                dgvCategories.DataSource = null;
                dgvCategories.DataSource = result;

                if (result == null ||
                    result.Count == 0)
                {
                    MessageBox.Show(
                        "Không tìm thấy nhóm hàng phù hợp!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Lỗi tìm kiếm:\n\n{ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =========================================================
        // CLEAR INPUT
        // =========================================================
        private void ClearInputs()
        {
            txtId.Clear();
            txtCategoryName.Clear();
            txtDescription.Clear();
        }

        // =========================================================
        // CELL CONTENT CLICK
        // =========================================================
        private void dgvCategories_CellContentClick(
            object? sender,
            DataGridViewCellEventArgs e)
        {
            // Không cần xử lý
        }
    }

    // =============================================================
    // DTO
    // =============================================================
    public class CategoryDto
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
            = string.Empty;

        public string? Description { get; set; }
    }
}
