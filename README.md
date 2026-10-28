# 🛒 MiniSupermarket — Bài thực hành buổi 6

**Môn học:** 229162 – Lập trình Ứng dụng .NET Core
**Sinh viên:** Bùi Thị Diễm Trinh · **MSSV:** 2124110287 · **Lớp:** CCQ2411D

## Tóm tắt buổi 6

Buổi 6 tập trung vào **Entity Framework Core nâng cao, phân trang LINQ và tích hợp WinForms–Web API**. Thay vì tải toàn bộ sản phẩm, ứng dụng chỉ lấy từng trang từ SQL Server và cập nhật giao diện bằng `async/await`.

- **Eager Loading:** dùng `Include(p => p.Category)` để lấy thông tin nhóm hàng, trả `CategoryName` trong DTO; `AsNoTracking()` tối ưu truy vấn chỉ đọc.
- **Phân trang tại máy chủ:** `OrderBy` → `Skip` → `Take`, mặc định 5 dòng/trang, tối đa 50. Kết quả có `currentPage`, `pageSize`, `totalItems`, `totalPages`, `items`.
- **Tìm kiếm và lọc:** tìm theo tên hoặc mã vạch, kết hợp lọc nhóm hàng trước khi đếm và phân trang.
- **WinForms:** màn hình quản lý sản phẩm hiển thị nhóm hàng, hỗ trợ trang trước/sau, tìm kiếm, lọc và thêm/sửa/xóa qua API.
- **HttpClient dùng chung:** `ApiClientService` quản lý địa chỉ API và Bearer Token, có thể gắn hoặc xóa token bằng `AttachToken`.
- **Bài mở rộng:** phân trang khách hàng theo điểm thưởng giảm dần và lọc sản phẩm theo danh mục.

Xem [hướng dẫn thực hành và kiểm thử buổi 6](docs/Buoi06.md) và [đề bài gốc](docs/Buoi06_DeBai.txt).

## Cấu trúc dự án

| Thành phần | Vai trò |
| --- | --- |
| `MiniSupermarket.API` | ASP.NET Core .NET 8, EF Core 8, SQL Server, Swagger; CRUD, phân trang và các API POS/báo cáo từ buổi trước |
| `MiniSupermarket.WinForms` | Giao diện Windows: đăng nhập mẫu, quản lý hàng hóa/khách hàng, POS, báo cáo |
| `ThucHanhAdoNet_Buoi05` | Bài console ADO.NET buổi 5 được giữ lại |
| `Scripts/Buoi05_Setup.sql` | Bảng hóa đơn, dữ liệu mẫu và stored procedure phục vụ POS/báo cáo |
| `MiniSupermarket.API.Tests` | Kiểm thử tích hợp HTTP bằng SQLite trong bộ nhớ, độc lập database thật |

## Chạy dự án

Cần .NET SDK 8, SQL Server và Windows để chạy giao diện WinForms. Có thể biên dịch API trên Linux.

1. Cấu hình kết nối bằng **User Secrets** hoặc biến môi trường `ConnectionStrings__DefaultConnection` cho API. Database mặc định: `BuiThiDiemTrinhMiniSupermarketDb`. Không đưa mật khẩu thật lên GitHub.
2. Tại thư mục gốc, cài EF CLI và áp dụng các migration hiện có:

   ```sh
   dotnet tool install --global dotnet-ef --version 8.0.1
   dotnet restore
   dotnet ef database update --project MiniSupermarket.API
   ```

   Nếu đã cài EF CLI, kiểm tra bằng `dotnet ef --version`. Để dùng POS/báo cáo buổi 5, chạy thêm `Scripts/Buoi05_Setup.sql` trong SQL Server sau migration.

3. Chạy API với profile HTTPS, cổng **7046**:

   ```sh
   dotnet dev-certs https --trust
   dotnet run --project MiniSupermarket.API --launch-profile https
   ```

   Swagger nằm tại đường dẫn `/swagger` của API. WinForms mặc định gọi `https://localhost:7046/api/`; có thể đổi bằng biến môi trường `MINISUPERMARKET_API_URL` trước khi chạy client.

4. Trên Windows, chạy:

   ```sh
   dotnet run --project MiniSupermarket.WinForms
   ```

   Chọn tài khoản mẫu quản trị hoặc kho trên màn hình đăng nhập, rồi mở **Quản lý sản phẩm** trong menu chính để thực hành buổi 6.

**Lưu ý JWT:** màn hình đăng nhập hiện có từ buổi trước tạo token mô phỏng; backend chưa có API cấp/xác minh JWT. `AttachToken` hỗ trợ gửi token khi tích hợp xác thực thật, chưa đồng nghĩa hệ thống đã được bảo vệ bằng JWT.

## API chính của buổi 6

| Phương thức | Đường dẫn | Chức năng |
| --- | --- | --- |
| GET | `/api/products/paged?keyword=Coca&pageNumber=1&pageSize=5` | Tìm kiếm và phân trang sản phẩm |
| GET | `/api/products/paged?categoryId=2&pageNumber=1&pageSize=5` | Lọc nhóm hàng và phân trang |
| GET | `/api/products/{id}` | Chi tiết sản phẩm |
| POST / PUT / DELETE | `/api/products` / `/api/products/{id}` | Thêm / sửa / xóa sản phẩm |
| GET | `/api/categories` | Danh mục cho ComboBox |
| GET | `/api/customers/paged?pageNumber=1&pageSize=5` | Khách hàng theo điểm thưởng giảm dần, hỗ trợ `keyword` |

Route cũ `/api/Product` vẫn được giữ tương thích. Không cần thêm migration cho buổi 6 vì không thay đổi cấu trúc bảng hoặc dữ liệu mẫu.

## Kiểm tra

```sh
dotnet build MiniSupermarket.API
dotnet build MiniSupermarket.WinForms -p:EnableWindowsTargeting=true
dotnet test MiniSupermarket.API.Tests
```

Kết quả kiểm tra trong môi trường Linux: toàn solution biên dịch thành công (0 lỗi, 0 cảnh báo), **15/15 kiểm thử tích hợp đạt**.

Bộ kiểm thử dùng SQLite để xác minh hợp đồng HTTP, truy vấn quan hệ, phân trang, tìm kiếm và CRUD. Cần kiểm tra thêm với **SQL Server thật và giao diện trên Windows** theo hướng dẫn trong [Buoi06.md](docs/Buoi06.md); bộ kiểm thử tự động không thay thế các bước này.
