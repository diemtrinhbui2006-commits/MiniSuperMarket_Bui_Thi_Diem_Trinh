using System.Net.Http.Json;
using System.Text.Json;

namespace MiniSupermarket.WinForms
{
    // Bùi Thị Diễm Trinh - 2124110287: phân trang, tìm kiếm và CRUD qua Web API.
    public partial class FormProductManagement : Form
    {
        private const int PageSize = 5;
        private int _currentPage = 1;
        private int _totalPages;
        private string _keyword = string.Empty;
        private int? _categoryFilterId;
        private bool _bindingCategories;
        private bool _busy;

        public FormProductManagement()
        {
            InitializeComponent();
            SetupGridColumns();
            txtBarcode.MaxLength = 50;
            txtProductName.MaxLength = 150;
            nudPrice.Maximum = 9999999999999999.99m;
            nudPrice.DecimalPlaces = 2;
            nudPrice.ThousandsSeparator = true;
            nudStock.Maximum = int.MaxValue;
            dgvProducts.MultiSelect = false;
            dgvProducts.SelectionChanged += (_, _) => PopulateSelectedProduct();
            UpdateButtons();
        }

        private void SetupGridColumns()
        {
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.Columns.Clear();
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(ProductDto.ProductId), HeaderText = "Mã SP", Width = 70 });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(ProductDto.Barcode), HeaderText = "Mã vạch", Width = 130 });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(ProductDto.ProductName), HeaderText = "Tên sản phẩm", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(ProductDto.Price), HeaderText = "Đơn giá", Width = 110, DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" } });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(ProductDto.StockQuantity), HeaderText = "Tồn kho", Width = 80 });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(ProductDto.CategoryName), HeaderText = "Nhóm hàng", Width = 170 });
            foreach (DataGridViewColumn column in dgvProducts.Columns)
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private async void FormProductManagement_Load(object sender, EventArgs e)
        {
            await RunAsync(async () =>
            {
                await LoadCategoriesToComboAsync();
                await LoadProductsAsync();
            });
        }

        // Không cho hai yêu cầu ghi/chuyển trang chạy đồng thời; bắt lỗi ở mọi sự kiện async.
        private async Task RunAsync(Func<Task> action)
        {
            if (_busy) return;
            _busy = true;
            panelTop.Enabled = panelDetail.Enabled = dgvProducts.Enabled = false;
            UseWaitCursor = true;
            UpdateButtons();
            try { await action(); }
            catch (Exception ex)
            {
                if (!IsDisposed) MessageBox.Show(this, ex.Message, "Lỗi xử lý API", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _busy = false;
                if (!IsDisposed)
                {
                    panelTop.Enabled = panelDetail.Enabled = dgvProducts.Enabled = true;
                    UseWaitCursor = false;
                    UpdateButtons();
                }
            }
        }

        private async Task LoadCategoriesToComboAsync()
        {
            var categories = await ApiClientService.Client.GetFromJsonAsync<List<CategoryDto>>("categories")
                ?? throw new InvalidOperationException("API không trả về danh sách nhóm hàng.");
            if (IsDisposed) return;
            _bindingCategories = true;
            try
            {
                cboCategory.DisplayMember = nameof(CategoryDto.CategoryName);
                cboCategory.ValueMember = nameof(CategoryDto.CategoryId);
                cboCategory.DataSource = categories;
                cboFilterCategory.DisplayMember = nameof(CategoryDto.CategoryName);
                cboFilterCategory.ValueMember = nameof(CategoryDto.CategoryId);
                cboFilterCategory.DataSource = new[] { new CategoryDto { CategoryName = "-- Tất cả danh mục --" } }.Concat(categories).ToList();
                if (_categoryFilterId.HasValue && categories.Any(c => c.CategoryId == _categoryFilterId.Value))
                    cboFilterCategory.SelectedValue = _categoryFilterId.Value;
                else
                {
                    _categoryFilterId = null;
                    cboFilterCategory.SelectedValue = 0;
                }
            }
            finally { _bindingCategories = false; }
        }

        private async Task LoadProductsAsync(int? page = null)
        {
            int targetPage = page ?? _currentPage;
            while (true)
            {
                string url = $"products/paged?keyword={Uri.EscapeDataString(_keyword)}&pageNumber={targetPage}&pageSize={PageSize}";
                if (_categoryFilterId.HasValue) url += $"&categoryId={_categoryFilterId.Value}";
                var result = await ApiClientService.Client.GetFromJsonAsync<PagedViewResult<ProductDto>>(url)
                    ?? throw new InvalidOperationException("API không trả về kết quả phân trang.");
                if (IsDisposed) return;
                // Xóa dòng cuối của trang cuối: tự động quay về trang còn dữ liệu.
                int lastPage = Math.Max(1, result.TotalPages);
                if (targetPage > lastPage)
                {
                    targetPage = lastPage;
                    continue;
                }
                _currentPage = result.CurrentPage;
                _totalPages = result.TotalPages;
                dgvProducts.DataSource = result.Items;
                dgvProducts.ClearSelection();
                ClearInputs();
                lblPaging.Text = result.TotalItems == 0
                    ? "Không có sản phẩm (Tổng: 0 SP)"
                    : $"Trang {_currentPage} / {_totalPages} (Tổng: {result.TotalItems} SP)";
                UpdateButtons();
                break;
            }
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) PopulateSelectedProduct();
        }

        private void PopulateSelectedProduct()
        {
            if (dgvProducts.SelectedRows.Count == 0 || dgvProducts.SelectedRows[0].DataBoundItem is not ProductDto product)
            {
                txtId.Clear();
                UpdateButtons();
                return;
            }
            txtId.Text = product.ProductId.ToString();
            txtBarcode.Text = product.Barcode;
            txtProductName.Text = product.ProductName;
            nudPrice.Value = Math.Clamp(product.Price, nudPrice.Minimum, nudPrice.Maximum);
            nudStock.Value = Math.Clamp(product.StockQuantity, (int)nudStock.Minimum, (int)nudStock.Maximum);
            cboCategory.SelectedValue = product.CategoryId;
            UpdateButtons();
        }

        private async void btnAdd_Click(object sender, EventArgs e) => await RunAsync(() => SaveProductAsync(false));

        private async void btnUpdate_Click(object sender, EventArgs e) => await RunAsync(() => SaveProductAsync(true));

        private async Task SaveProductAsync(bool update)
        {
            int.TryParse(txtId.Text, out int id);
            if (update && id <= 0) throw new InvalidOperationException("Vui lòng chọn sản phẩm cần cập nhật.");
            if (string.IsNullOrWhiteSpace(txtBarcode.Text) || string.IsNullOrWhiteSpace(txtProductName.Text))
                throw new InvalidOperationException("Vui lòng nhập đầy đủ mã vạch và tên sản phẩm.");
            if (cboCategory.SelectedItem is not CategoryDto category || category.CategoryId <= 0)
                throw new InvalidOperationException("Vui lòng chọn nhóm hàng.");
            var product = new
            {
                ProductId = update ? id : 0,
                Barcode = txtBarcode.Text.Trim(),
                ProductName = txtProductName.Text.Trim(),
                Price = nudPrice.Value,
                StockQuantity = (int)nudStock.Value,
                CategoryId = category.CategoryId
            };
            using var response = update
                ? await ApiClientService.Client.PutAsJsonAsync($"products/{id}", product)
                : await ApiClientService.Client.PostAsJsonAsync("products", product);
            await EnsureSuccessAsync(response);
            await LoadProductsAsync();
            if (!IsDisposed) MessageBox.Show(this, update ? "Cập nhật sản phẩm thành công!" : "Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            await RunAsync(async () =>
            {
                if (!int.TryParse(txtId.Text, out int id) || id <= 0) return;
                if (MessageBox.Show(this, $"Xóa sản phẩm: {txtProductName.Text} (ID = {id})?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                using var response = await ApiClientService.Client.DeleteAsync($"products/{id}");
                await EnsureSuccessAsync(response);
                await LoadProductsAsync();
                if (!IsDisposed) MessageBox.Show(this, "Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            });
        }

        private void btnClear_Click(object sender, EventArgs e) => ClearInputs();

        private async void btnReload_Click(object sender, EventArgs e)
        {
            await RunAsync(async () =>
            {
                txtSearchBarcode.Clear();
                _keyword = string.Empty;
                _categoryFilterId = null;
                await LoadCategoriesToComboAsync();
                await LoadProductsAsync(1);
            });
        }

        private async void btnSearch_Click(object sender, EventArgs e) => await ExecuteSearchAsync();

        private async void txtSearchBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            e.SuppressKeyPress = true;
            await ExecuteSearchAsync();
        }

        private async Task ExecuteSearchAsync()
        {
            await RunAsync(async () =>
            {
                _keyword = txtSearchBarcode.Text.Trim();
                await LoadProductsAsync(1);
            });
        }

        private async void cboFilterCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_bindingCategories) return;
            await RunAsync(async () =>
            {
                int id = (cboFilterCategory.SelectedItem as CategoryDto)?.CategoryId ?? 0;
                _categoryFilterId = id > 0 ? id : null;
                _keyword = txtSearchBarcode.Text.Trim();
                await LoadProductsAsync(1);
            });
        }

        private async void btnPrev_Click(object sender, EventArgs e)
        {
            await RunAsync(async () =>
            {
                if (_currentPage > 1) await LoadProductsAsync(_currentPage - 1);
            });
        }

        private async void btnNext_Click(object sender, EventArgs e)
        {
            await RunAsync(async () =>
            {
                if (_currentPage < _totalPages) await LoadProductsAsync(_currentPage + 1);
            });
        }

        private void ClearInputs()
        {
            txtId.Clear();
            txtBarcode.Clear();
            txtProductName.Clear();
            nudPrice.Value = nudStock.Value = 0;
            if (cboCategory.Items.Count > 0) cboCategory.SelectedIndex = 0;
            dgvProducts.ClearSelection();
            UpdateButtons();
        }

        private void UpdateButtons()
        {
            btnPrev.Enabled = !_busy && _currentPage > 1;
            btnNext.Enabled = !_busy && _currentPage < _totalPages;
            btnAdd.Enabled = !_busy && cboCategory.Items.Count > 0;
            btnUpdate.Enabled = btnDelete.Enabled = !_busy && !string.IsNullOrEmpty(txtId.Text);
        }

        private static async Task EnsureSuccessAsync(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode) return;
            string message = $"API trả về lỗi {(int)response.StatusCode} ({response.StatusCode}).";
            string body = await response.Content.ReadAsStringAsync();
            try
            {
                using var document = JsonDocument.Parse(body);
                if (document.RootElement.TryGetProperty("message", out var detail)) message += " " + detail.GetString();
                else if (document.RootElement.TryGetProperty("title", out var title)) message += " " + title.GetString();
            }
            catch (JsonException) { /* Phản hồi không phải JSON: giữ nguyên mã lỗi HTTP. */ }
            throw new HttpRequestException(message, null, response.StatusCode);
        }
    }
}
