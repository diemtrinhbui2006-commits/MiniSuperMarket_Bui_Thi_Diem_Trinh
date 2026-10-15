using System.Net.Http.Json;

namespace MiniSupermarket.WinForms
{
    public partial class FormCustomerManagement : Form
    {
        private static readonly HttpClient _client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7046/api/")
        };

        public FormCustomerManagement()
        {
            InitializeComponent();
        }

        // ==============================
        // LOAD FORM
        // ==============================
        private async void FormCustomerManagement_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        // ==============================
        // LOAD DATA
        // ==============================
        private async Task LoadDataAsync()
        {
            try
            {
                var customers =
                    await _client.GetFromJsonAsync<List<CustomerDto>>("customers");

                if (customers != null)
                {
                    dgvCustomers.DataSource = customers;
                }
                else
                {
                    MessageBox.Show(
                        "Không có dữ liệu khách hàng!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi kết nối Server: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ==============================
        // LOAD BUTTON
        // ==============================
        private async void btnLoad_Click(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        // ==============================
        // CLICK DATA GRID VIEW
        // ==============================
        private void dgvCustomers_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvCustomers.Rows[e.RowIndex];

            txtCustomerId.Text =
                row.Cells["CustomerId"].Value?.ToString() ?? "";

            txtCustomerName.Text =
                row.Cells["CustomerName"].Value?.ToString() ?? "";

            txtPhoneNumber.Text =
                row.Cells["PhoneNumber"].Value?.ToString() ?? "";

            txtAddress.Text =
                row.Cells["Address"].Value?.ToString() ?? "";

            txtWard.Text =
                row.Cells["Ward"].Value?.ToString() ?? "";

            txtDistrict.Text =
                row.Cells["District"].Value?.ToString() ?? "";

            txtProvince.Text =
                row.Cells["Province"].Value?.ToString() ?? "";

            txtRewardPoints.Text =
                row.Cells["RewardPoints"].Value?.ToString() ?? "0";

            txtMembershipRank.Text =
                row.Cells["MembershipRank"].Value?.ToString() ?? "Chuẩn";
        }

        // ==============================
        // ADD CUSTOMER
        // ==============================
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập tên khách hàng!",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập số điện thoại!",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int rewardPoints = 0;

            if (!string.IsNullOrWhiteSpace(txtRewardPoints.Text))
            {
                if (!int.TryParse(txtRewardPoints.Text, out rewardPoints))
                {
                    MessageBox.Show(
                        "Điểm tích lũy phải là số!",
                        "Cảnh báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
            }

            var newCustomer = new
            {
                CustomerName = txtCustomerName.Text.Trim(),
                PhoneNumber = txtPhoneNumber.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                Ward = txtWard.Text.Trim(),
                District = txtDistrict.Text.Trim(),
                Province = txtProvince.Text.Trim(),
                RewardPoints = rewardPoints,
                MembershipRank = string.IsNullOrWhiteSpace(txtMembershipRank.Text)
                    ? "Chuẩn"
                    : txtMembershipRank.Text.Trim()
            };

            try
            {
                var response =
                    await _client.PostAsJsonAsync(
                        "customers",
                        newCustomer);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show(
                        "Thêm khách hàng thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    await LoadDataAsync();
                    ClearInputs();
                }
                else
                {
                    string error =
                        await response.Content.ReadAsStringAsync();

                    MessageBox.Show(
                        "Thêm khách hàng thất bại!\n" + error,
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi kết nối Server: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ==============================
        // UPDATE CUSTOMER
        // ==============================
        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustomerId.Text))
            {
                MessageBox.Show(
                    "Vui lòng chọn khách hàng cần sửa!",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtCustomerId.Text, out int id))
            {
                MessageBox.Show(
                    "Customer ID không hợp lệ!",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int rewardPoints = 0;

            if (!string.IsNullOrWhiteSpace(txtRewardPoints.Text))
            {
                if (!int.TryParse(txtRewardPoints.Text, out rewardPoints))
                {
                    MessageBox.Show(
                        "Điểm tích lũy phải là số!",
                        "Cảnh báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
            }

            var updateCustomer = new
            {
                CustomerId = id,
                CustomerName = txtCustomerName.Text.Trim(),
                PhoneNumber = txtPhoneNumber.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                Ward = txtWard.Text.Trim(),
                District = txtDistrict.Text.Trim(),
                Province = txtProvince.Text.Trim(),
                RewardPoints = rewardPoints,
                MembershipRank = string.IsNullOrWhiteSpace(txtMembershipRank.Text)
                    ? "Chuẩn"
                    : txtMembershipRank.Text.Trim()
            };

            try
            {
                var response =
                    await _client.PutAsJsonAsync(
                        $"customers/{id}",
                        updateCustomer);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show(
                        "Cập nhật khách hàng thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    await LoadDataAsync();
                    ClearInputs();
                }
                else
                {
                    string error =
                        await response.Content.ReadAsStringAsync();

                    MessageBox.Show(
                        "Cập nhật thất bại!\n" + error,
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi kết nối Server: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ==============================
        // DELETE CUSTOMER
        // ==============================
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustomerId.Text))
            {
                MessageBox.Show(
                    "Vui lòng chọn khách hàng cần xóa!",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtCustomerId.Text, out int id))
            {
                MessageBox.Show(
                    "Customer ID không hợp lệ!",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc muốn xóa khách hàng ID = {id}?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                var response =
                    await _client.DeleteAsync($"customers/{id}");

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show(
                        "Xóa khách hàng thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    await LoadDataAsync();
                    ClearInputs();
                }
                else
                {
                    string error =
                        await response.Content.ReadAsStringAsync();

                    MessageBox.Show(
                        "Xóa khách hàng thất bại!\n" + error,
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi kết nối Server: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ==============================
        // SEARCH
        // ==============================
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtKeyword.Text.Trim();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                await LoadDataAsync();
                return;
            }

            try
            {
                var result =
                    await _client.GetFromJsonAsync<List<CustomerDto>>(
                        $"customers/search?keyword={Uri.EscapeDataString(keyword)}");

                if (result != null)
                {
                    dgvCustomers.DataSource = result;
                }
                else
                {
                    dgvCustomers.DataSource = new List<CustomerDto>();

                    MessageBox.Show(
                        "Không tìm thấy khách hàng phù hợp!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi tìm kiếm: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ==============================
        // CLEAR INPUT
        // ==============================
        private void ClearInputs()
        {
            txtCustomerId.Clear();
            txtCustomerName.Clear();
            txtPhoneNumber.Clear();
            txtAddress.Clear();
            txtWard.Clear();
            txtDistrict.Clear();
            txtProvince.Clear();
            txtRewardPoints.Text = "0";
            txtMembershipRank.Text = "Chuẩn";
        }

        // ==============================
        // CELL CONTENT CLICK
        // ==============================
        private void dgvCustomers_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
        }
    }

    // ==============================
    // CUSTOMER DTO
    // ==============================
    public class CustomerDto
    {
        public int CustomerId { get; set; }

        public string CustomerName { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string? Address { get; set; }

        public string? Ward { get; set; }

        public string? District { get; set; }

        public string? Province { get; set; }

        public int RewardPoints { get; set; }

        public string MembershipRank { get; set; } = "Chuẩn";
    }
}