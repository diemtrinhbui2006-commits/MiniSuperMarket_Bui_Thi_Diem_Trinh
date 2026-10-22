BUỔI 6: ENTITY FRAMEWORK CORE NÂNG CAO, PHÂN TRANG LINQ VÀ TÍCH HỢP POS CLIENT–SERVER
Môn học: 229162 – Lập trình Ứng dụng .NET Core
Họ và tên: Bùi Thị Diễm Trinh
MSSV:2124110287
Thời lượng: 5 tiết thực hành phòng máy
Dự án: Hệ thống Quản lý Bán lẻ & Tồn kho Siêu thị Mini (MiniSupermarket)
1. MỤC TIÊU BÀI HỌC
1.1. Kiến thức
- Hiểu Eager Loading bằng .Include() và .ThenInclude() trong Entity Framework Core, giúp truy vấn dữ liệu quan hệ hiệu quả và hạn chế lỗi N+1 Query.
- Hiểu phân trang phía máy chủ bằng LINQ .Skip() và .Take(), kết hợp tìm kiếm gần đúng bằng .Contains().
- Hiểu quy trình WinForms Client gọi ASP.NET Core Web API qua HttpClient, trao đổi dữ liệu JSON và xác thực bằng JWT Bearer Token.
1.2. Kỹ năng
- Xây dựng API tìm kiếm và phân trang, trả về metadata gồm trang hiện tại, kích thước trang, tổng số bản ghi, tổng số trang và dữ liệu.
- Xây dựng ApiClientService dùng chung trong WinForms để quản lý HttpClient và gắn JWT.
- Hoàn thiện màn hình quản lý sản phẩm: tải danh mục vào ComboBox, hiển thị DataGridView, tìm kiếm, chuyển trang và thực hiện CRUD qua API.
2. TÌNH HUỐNG THỰC TẾ VÀ GIẢI PHÁP
Khi siêu thị có hàng nghìn sản phẩm, tải toàn bộ dữ liệu cùng lúc có thể làm chậm giao diện, tốn RAM và băng thông. Vì vậy, backend chỉ trả về một trang dữ liệu cần thiết. WinForms gọi API bất đồng bộ bằng async/await, sau đó hiển thị kết quả.

Luồng xử lý:

WinForms → HttpClient → ASP.NET Core Web API → Entity Framework Core/LINQ → SQL Server

Kết quả được trả về dạng JSON, sau đó WinForms chuyển JSON thành các DTO và gán vào giao diện.
3. DỮ LIỆU MẪU KIỂM THỬ
Dữ liệu dự kiến có 15 sản phẩm, chia thành 5 nhóm hàng:
STT	Tên sản phẩm	Đơn giá (VNĐ)	Tồn kho	Nhóm hàng
1	Snack Khoai Tây O'Star Gói 60g	12.500	150	Bánh kẹo & Đồ ăn vặt
2	Bánh Quy Bơ Danisa Hộp Thiếc 454g	135.000	40	Bánh kẹo & Đồ ăn vặt
3	Kẹo Dẻo Chupa Chups Trái Cây 90g	15.000	120	Bánh kẹo & Đồ ăn vặt
4	Bánh Chocopie Orion Hộp 12 Cái	54.000	60	Bánh kẹo & Đồ ăn vặt
5	Nước Ngọt Coca Cola Lon 320ml	10.000	320	Nước giải khát & Trà
6	Nước Khoáng Lavie Chai 500ml	6.000	200	Nước giải khát & Trà
7	Trà Xanh Không Độ Chai 455ml	11.000	180	Nước giải khát & Trà
8	Nước Tăng Lực Red Bull Lon 250ml	14.500	150	Nước giải khát & Trà
9	Sữa Tươi Tiệt Trùng Vinamilk 1L	34.500	85	Sữa & Sản phẩm từ sữa
10	Phô Mai Con Bò Cười Hộp 8 Miếng	39.000	60	Sữa & Sản phẩm từ sữa
11	Sữa Chua Vinamilk Có Đường Lốc 4	28.000	95	Sữa & Sản phẩm từ sữa
12	Sữa Đặc Có Đường Ông Thọ Lon 380g	26.000	110	Sữa & Sản phẩm từ sữa
13	Mì Tôm Hảo Hảo Chua Cay Gói 75g	4.500	500	Mì gói & Ăn liền
14	Phở Bò Đệ Nhất Gói 68g	8.500	140	Mì gói & Ăn liền
15	Dầu Ăn Simply Nguyên Chất Can 2L	125.000	45	Gia vị & Dầu ăn


Lưu ý: Đây là dữ liệu đối soát mong đợi. Cần kiểm tra dữ liệu thật trong SQL Server và tên thuộc tính entity hiện có trước khi chạy các đoạn code.
4. THỰC HÀNH BACKEND: DTO VÀ API PHÂN TRANG
4.1. Tạo DTO Models/PagedResponseDto.cs
Có thể đặt hai lớp DTO trong cùng một tệp như sau:
namespace MiniSupermarket.API.Models
{
    public class ProductItemDto
    {
        public int ProductId { get; set; }
        public string Barcode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }

    public class PagedResult<T>
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public List<T> Items { get; set; } = new();
    }
}
Ý nghĩa:
- ProductItemDto: dữ liệu sản phẩm trả về cho Client, có thêm tên nhóm hàng.
- PagedResult<T>: cấu trúc bao bọc dữ liệu phân trang.
- TotalItems: tổng số bản ghi sau khi áp dụng bộ lọc.
- TotalPages: tổng số trang, tính bằng Ceiling(TotalItems / PageSize).
4.2. Thêm action phân trang trong ProductsController.cs
Đoạn action bên dưới giả định entity có các thuộc tính ProductId, Barcode, ProductName, Price, StockQuantity, CategoryId, quan hệ Category và CategoryName. Nếu project hiện tại dùng tên khác, cần đổi theo entity thực tế.
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniSupermarket.API.Data;
using MiniSupermarket.API.Models;

namespace MiniSupermarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly SupermarketDbContext _context;

        public ProductsController(SupermarketDbContext context)
        {
            _context = context;
        }

        // GET: api/products/paged?keyword=sua&pageNumber=1&pageSize=5
        [HttpGet("paged")]
        public async Task<IActionResult> GetPagedProducts(
            [FromQuery] string? keyword,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 5)
        {
            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1 || pageSize > 50) pageSize = 5;

            var query = _context.Products
                .Include(p => p.Category)
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                string search = keyword.Trim();
                query = query.Where(p =>
                    p.ProductName.Contains(search) ||
                    p.Barcode.Contains(search));
            }

            int totalItems = await query.CountAsync();
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            var items = await query
                .OrderBy(p => p.ProductId)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new ProductItemDto
                {
                    ProductId = p.ProductId,
                    Barcode = p.Barcode,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    StockQuantity = p.StockQuantity,
                    CategoryId = p.CategoryId,
                    CategoryName = p.Category != null
                        ? p.Category.CategoryName
                        : string.Empty
                })
                .ToListAsync();

            return Ok(new PagedResult<ProductItemDto>
            {
                CurrentPage = pageNumber,
                PageSize = pageSize,
                TotalItems = totalItems,
                TotalPages = totalPages,
                Items = items
            });
        }
    }
}
Giải thích các thành phần:
1. Include(p => p.Category): nạp quan hệ danh mục cùng truy vấn sản phẩm.
2. AsNoTracking(): phù hợp với truy vấn chỉ đọc, giảm chi phí theo dõi entity.
3. Where(...): tìm sản phẩm theo tên hoặc mã vạch.
4. CountAsync(): đếm tổng số bản ghi phù hợp bộ lọc.
5. OrderBy(...): đảm bảo thứ tự ổn định trước khi phân trang.
6. Skip((pageNumber - 1) * pageSize): bỏ qua các dòng ở trang trước.
7. Take(pageSize): lấy số dòng cần hiển thị.
8. Select(...): ánh xạ entity sang DTO.
9. ToListAsync(): thực thi truy vấn bất đồng bộ.
Lưu ý: Trong mẫu này, Include thể hiện Eager Loading; khi truy vấn chỉ chọn DTO và lấy thuộc tính điều hướng trong Select, EF Core thường tự tạo JOIN cần thiết. Tránh kết luận rằng Include luôn bắt buộc trong mọi truy vấn projection.
4.3. Kiểm tra bằng Swagger
Chạy MiniSupermarket.API, mở Swagger và gọi:
GET /api/products/paged?pageNumber=1&pageSize=5
Kết quả kỳ vọng nếu cơ sở dữ liệu có 15 sản phẩm:
{
  "currentPage": 1,
  "pageSize": 5,
  "totalItems": 15,
  "totalPages": 3,
  "items": [
    {
      "productId": 1,
      "barcode": "893456789001",
      "productName": "Snack Khoai Tây O'Star Gói 60g",
      "price": 12500,
      "stockQuantity": 150,
      "categoryId": 1,
      "categoryName": "Bánh kẹo & Đồ ăn vặt"
    }
  ]
}
Ví dụ trên rút gọn mảng items để minh họa; API cần trả tối đa 5 sản phẩm ở trang đầu khi pageSize=5.

Thử tìm kiếm:
GET /api/products/paged?keyword=Coca&pageNumber=1&pageSize=5
Kiểm tra totalItems, totalPages và categoryName có đúng không.
4.4. SQL tương đương về mặt ý tưởng
EF Core có thể sinh SQL tương tự:
SELECT ...
FROM [Products] AS [p]
LEFT JOIN [Categories] AS [c]
    ON [p].[CategoryId] = [c].[CategoryId]
ORDER BY [p].[ProductId]
OFFSET 0 ROWS FETCH NEXT 5 ROWS ONLY;
SQL thực tế có thể khác tùy phiên bản EF Core, cấu hình và biểu thức LINQ. Skip(0).Take(5) tương ứng với việc lấy 5 dòng đầu sau khi sắp xếp; SQL Server thường dùng OFFSET ... FETCH.
5. THỰC HÀNH WINFORMS CLIENT
5.1. Tạo Services/ApiClientService.cs
Trong project MiniSupermarket.WinForms, tạo thư mục Services nếu chưa có, rồi tạo tệp:
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MiniSupermarket.WinForms.Services
{
    public static class ApiClientService
    {
        public static readonly HttpClient Client = new HttpClient
        {
            // Đổi thành đúng URL/port đang hiển thị khi chạy API.
            BaseAddress = new Uri("https://localhost:7123/api/")
        };

        public static void AttachToken(string token)
        {
            Client.DefaultRequestHeaders.Authorization = null;

            if (!string.IsNullOrWhiteSpace(token))
            {
                Client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
            }
        }
    }
}
Quan trọng: Port 7123 chỉ là ví dụ trong tài liệu. Kiểm tra Properties/launchSettings.json hoặc URL Swagger thực tế của project. Nếu API đang chạy tại https://localhost:7046, hãy dùng đúng địa chỉ đó và thêm /api/.

Sau khi đăng nhập thành công, gọi ApiClientService.AttachToken(token) với JWT thực tế do API trả về. Nếu endpoint không yêu cầu [Authorize], token có thể không bắt buộc; nếu được bảo vệ, phải gửi token hợp lệ.
5.2. Thiết kế Form FormProductManagement
Tạo Windows Form mới có tên FormProductManagement. Thêm các điều khiển trong Designer và đặt Name đúng như sau:
Điều khiển	Name	Công dụng
TextBox	txtBarcode	Nhập mã vạch
TextBox	txtProductName	Nhập tên sản phẩm
ComboBox	cboCategory	Chọn danh mục
NumericUpDown	nudPrice	Nhập giá
NumericUpDown	nudStock	Nhập tồn kho
Button	btnCreate	Thêm mới
Button	btnUpdate	Cập nhật
Button	btnDelete	Xóa
TextBox	txtSearch	Nhập từ khóa
Button	btnSearch	Tìm kiếm
DataGridView	dgvProducts	Hiển thị sản phẩm
Label	lblPaging	Hiển thị trang hiện tại
Button	btnPrev	Trang trước
Button	btnNext	Trang sau


Gợi ý bố cục: thông tin sản phẩm ở trên, nút CRUD kế tiếp, ô tìm kiếm và bảng ở giữa, điều khiển phân trang ở dưới.
5.3. DTO phía Client và tải dữ liệu
Tạo các DTO phía WinForms (có thể đặt trong Models hoặc tệp riêng):
namespace MiniSupermarket.WinForms
{
    public class ProductItemViewDto
    {
        public int ProductId { get; set; }
        public string Barcode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }

    public class CategoryComboDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }

    public class PagedViewResult<T>
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public List<T> Items { get; set; } = new();
    }
}
Trong FormProductManagement.cs, thêm phần tải danh mục và danh sách phân trang. Đoạn này giả định API danh mục trả trực tiếp một mảng JSON; nếu API trả { "data": [...] }, cần tạo DTO bao bọc tương ứng.
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniSupermarket.WinForms.Services;

namespace MiniSupermarket.WinForms
{
    public partial class FormProductManagement : Form
    {
        private int _currentPage = 1;
        private readonly int _pageSize = 5;
        private int _totalPages = 1;

        public FormProductManagement()
        {
            InitializeComponent();
        }

        private async void FormProductManagement_Load(object sender, EventArgs e)
        {
            await LoadCategoriesComboAsync();
            await LoadProductsPagedAsync();
        }

        private async Task LoadCategoriesComboAsync()
        {
            try
            {
                var categories = await ApiClientService.Client
                    .GetFromJsonAsync<List<CategoryComboDto>>("categories");

                cboCategory.DataSource = categories ?? new List<CategoryComboDto>();
                cboCategory.DisplayMember = "CategoryName";
                cboCategory.ValueMember = "CategoryId";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục: " + ex.Message);
            }
        }

        private async Task LoadProductsPagedAsync()
        {
            try
            {
                string keyword = Uri.EscapeDataString(txtSearch.Text.Trim());
                string url = $"products/paged?keyword={keyword}&pageNumber={_currentPage}&pageSize={_pageSize}";

                var result = await ApiClientService.Client
                    .GetFromJsonAsync<PagedViewResult<ProductItemViewDto>>(url);

                if (result == null) return;

                _currentPage = result.CurrentPage;
                _totalPages = Math.Max(1, result.TotalPages);

                dgvProducts.AutoGenerateColumns = true;
                dgvProducts.DataSource = result.Items;

                lblPaging.Text = $"Trang {_currentPage} / {_totalPages} (Tổng: {result.TotalItems} SP)";
                btnPrev.Enabled = _currentPage > 1;
                btnNext.Enabled = _currentPage < _totalPages;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu sản phẩm: " + ex.Message);
            }
        }

        private async void btnPrev_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                await LoadProductsPagedAsync();
            }
        }

        private async void btnNext_Click(object sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                await LoadProductsPagedAsync();
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            _currentPage = 1;
            await LoadProductsPagedAsync();
        }
    }
}
Gắn sự kiện trong Designer: chọn Form → biểu tượng tia sét Events → Load → chọn FormProductManagement_Load. Làm tương tự với Click của btnPrev, btnNext, btnSearch. Hoặc nhấp đúp vào nút để Visual Studio tạo event handler, sau đó bảo đảm tên hàm khớp với code.
5.4. Thêm, sửa và xóa qua API
Các thao tác CRUD cần endpoint tương ứng ở backend. Mẫu thêm sản phẩm:
private async void btnCreate_Click(object sender, EventArgs e)
{
    if (cboCategory.SelectedValue == null)
    {
        MessageBox.Show("Vui lòng chọn danh mục.");
        return;
    }

    var newProduct = new
    {
        Barcode = txtBarcode.Text.Trim(),
        ProductName = txtProductName.Text.Trim(),
        Price = nudPrice.Value,
        StockQuantity = (int)nudStock.Value,
        CategoryId = Convert.ToInt32(cboCategory.SelectedValue)
    };

    try
    {
        var response = await ApiClientService.Client
            .PostAsJsonAsync("products", newProduct);

        if (response.IsSuccessStatusCode)
        {
            MessageBox.Show("Thêm sản phẩm thành công.");
            _currentPage = 1;
            await LoadProductsPagedAsync();
        }
        else
        {
            string detail = await response.Content.ReadAsStringAsync();
            MessageBox.Show($"Thêm thất bại: {(int)response.StatusCode}\n{detail}");
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show("Lỗi kết nối API: " + ex.Message);
    }
}
Mẫu xóa sản phẩm theo dòng đang chọn:
private async void btnDelete_Click(object sender, EventArgs e)
{
    if (dgvProducts.CurrentRow?.DataBoundItem is not ProductItemViewDto selected)
    {
        MessageBox.Show("Vui lòng chọn sản phẩm cần xóa.");
        return;
    }

    var confirm = MessageBox.Show(
        $"Bạn có chắc muốn xóa sản phẩm #{selected.ProductId}?",
        "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

    if (confirm != DialogResult.Yes) return;

    try
    {
        var response = await ApiClientService.Client
            .DeleteAsync($"products/{selected.ProductId}");

        if (response.IsSuccessStatusCode)
        {
            MessageBox.Show("Xóa sản phẩm thành công.");
            await LoadProductsPagedAsync();
        }
        else
        {
            MessageBox.Show($"Xóa thất bại: {(int)response.StatusCode}");
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show("Lỗi kết nối API: " + ex.Message);
    }
}
Phần cập nhật: cần thêm btnUpdate_Click, dùng PUT hoặc PATCH theo đúng endpoint backend. Ví dụ nếu API hỗ trợ PUT /api/products/{id}, gọi PutAsJsonAsync($"products/{id}", updateProduct). Kiểm tra cấu trúc DTO đầu vào và phản hồi API hiện có trước khi sử dụng. Sau CRUD, nên tải lại dữ liệu và kiểm tra các trường nhập.
Không thể đảm bảo CRUD hoạt động chỉ bằng code WinForms nếu backend chưa có các endpoint POST/PUT/DELETE tương ứng hoặc tên thuộc tính JSON không khớp model.

6. BÀI TẬP MỞ RỘNG
6.1. Phân trang khách hàng theo điểm thưởng giảm dần
Tạo endpoint GET /api/customers/paged. Ví dụ truy vấn cơ sở:
var query = _context.Customers
    .AsNoTracking()
    .OrderByDescending(c => c.RewardPoints);
Tiếp tục tính CountAsync(), rồi dùng Skip() và Take() tương tự API sản phẩm. Cần tạo DTO khách hàng và xác nhận tên thuộc tính đúng với entity Customer trong dự án.
6.2. Lọc sản phẩm theo danh mục
Bổ sung tham số tùy chọn:
[FromQuery] int? categoryId
Sau đó thêm điều kiện trước CountAsync() và phân trang:
if (categoryId.HasValue && categoryId.Value > 0)
{
    query = query.Where(p => p.CategoryId == categoryId.Value);
}
Client truyền thêm categoryId vào URL. Khi thay đổi danh mục, nên đặt _currentPage = 1 rồi tải lại dữ liệu. Nếu muốn chọn tất cả danh mục, có thể bổ sung mục “Tất cả” với giá trị quy ước 0.
7. KIỂM THỬ VÀ NGHIỆM THU
- [ ] Backend paging: GET /api/products/paged?pageNumber=1&pageSize=5 trả 200 OK và đúng metadata.
- [ ] Eager Loading/DTO: dữ liệu có CategoryName hợp lệ.
- [ ] Tìm kiếm: từ khóa Coca chỉ trả sản phẩm phù hợp; tổng số bản ghi và trang được tính lại.
- [ ] Phân trang WinForms: nút Trang trước/Trang sau hoạt động, không tải toàn bộ bảng về Client.
- [ ] Thêm: tạo sản phẩm từ WinForms và xác minh dữ liệu trong SQL Server.
- [ ] Sửa: cập nhật sản phẩm và xác minh dữ liệu trong SQL Server.
- [ ] Xóa: xóa sản phẩm sau khi xác nhận và tải lại danh sách.
- [ ] JWT: nếu API được bảo vệ, Client gửi Bearer Token hợp lệ.
- [ ] Danh mục: ComboBox nạp dữ liệu đúng định dạng API trả về.
8. LỖI THƯỜNG GẶP VÀ CÁCH KIỂM TRA
1. Sai port hoặc URL: xem URL khi chạy API và cập nhật BaseAddress.
2. 401 Unauthorized: chưa đăng nhập, token hết hạn hoặc chưa gọi AttachToken.
3. 403 Forbidden: tài khoản không đủ quyền hoặc policy không cho phép.
4. 404 Not Found: kiểm tra route controller, route action và đường dẫn gọi từ Client.
5. Lỗi JSON: đối chiếu tên trường, kiểu dữ liệu và cấu trúc JSON thật với DTO.
6. ComboBox không có dữ liệu: kiểm tra endpoint categories, định dạng JSON và tên trường CategoryId, CategoryName.
7. Không thấy event chạy: kiểm tra sự kiện Load/Click đã được gắn trong Designer chưa.
8. Tên thuộc tính không khớp: đối chiếu Product, Category và SupermarketDbContext thực tế trước khi sao chép code.
9. Tìm kiếm không phân biệt hoa thường: cách so sánh phụ thuộc collation của SQL Server; kiểm tra cấu hình cơ sở dữ liệu nếu cần.
10. Tổng số trang bằng 0: khi không có kết quả, API có thể trả TotalPages = 0; Client có thể hiển thị trang 1 / 1 để giao diện dễ dùng, nhưng vẫn cần thể hiện danh sách rỗng.
9. KẾT LUẬN
Buổi 6 giúp sinh viên kết hợp truy vấn EF Core, Eager Loading, tìm kiếm LINQ, phân trang phía máy chủ và giao tiếp WinForms–Web API. Khi hoàn thành, màn hình quản lý sản phẩm có thể lấy dữ liệu từng trang, tìm kiếm theo từ khóa và thực hiện các thao tác CRUD qua API. Kết quả cuối cùng cần được kiểm chứng trên chính cấu trúc entity, route, port và cơ sở dữ liệu của dự án MiniSupermarket.
