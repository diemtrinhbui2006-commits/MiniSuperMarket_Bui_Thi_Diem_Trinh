# 🛒 HỆ THỐNG QUẢN LÝ SIÊU THỊ MINI --- README BUỔI 3

**Môn học:** Lập trình Ứng dụng .NET Core (229162)\
**Sinh viên:** Bùi Thị Diễm Trinh\
**MSSV:** 2124110287\
**Lớp học phần:** CCQ2411D

## 1. Mục tiêu thực hành

-   Chuyển dữ liệu từ bộ nhớ tạm In-Memory sang SQL Server để dữ liệu
    được lưu lâu dài.
-   Sử dụng Entity Framework Core (EF Core) theo phương pháp Code-First.
-   Tạo và cập nhật cơ sở dữ liệu bằng EF Core Migrations.
-   Truy vấn dữ liệu bằng LINQ kết hợp `async/await`.
-   Kết nối Web API với ứng dụng WinForms để thực hiện CRUD.

## 2. Công nghệ sử dụng

-   C# / .NET 8.0
-   ASP.NET Core Web API
-   Entity Framework Core
-   Microsoft SQL Server
-   Windows Forms
-   `HttpClient`, `System.Net.Http.Json`
-   Swagger UI
-   Visual Studio 2022

## 3. Cài đặt NuGet Packages

Trong project `MiniSupermarket.API`, cài đặt:

-   `Microsoft.EntityFrameworkCore.SqlServer`
-   `Microsoft.EntityFrameworkCore.Tools`
-   `Microsoft.EntityFrameworkCore.Design`

Các gói này hỗ trợ kết nối SQL Server, tạo migration và thiết kế cấu
trúc cơ sở dữ liệu.

## 4. Model và DbContext

### `Category.cs`

-   `CategoryId`: khóa chính, tự tăng.
-   `CategoryName`: tên danh mục, bắt buộc, tối đa 100 ký tự.
-   `Description`: mô tả tùy chọn.
-   `Products`: quan hệ một danh mục có nhiều sản phẩm.

### `Product.cs`

-   `ProductId`: khóa chính, tự tăng.
-   `Barcode`: mã vạch sản phẩm.
-   `ProductName`: tên sản phẩm.
-   `Price`: giá bán kiểu `decimal(18,2)`.
-   `StockQuantity`: số lượng tồn kho.
-   `CategoryId`: khóa ngoại liên kết với `Category`.

### `SupermarketDbContext.cs`

-   Kế thừa `DbContext`.
-   Khai báo `DbSet<Category>`, `DbSet<Product>` và `DbSet<Customer>`.
-   Cấu hình dữ liệu mẫu bằng `HasData()` trong `OnModelCreating()`.

## 5. Cấu hình kết nối SQL Server

Trong `appsettings.json`, cấu hình chuỗi kết nối phù hợp với máy đang sử
dụng. Ví dụ dùng Windows Authentication:

``` json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=BuiThiDiemTrinhMiniSupermarketDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

Nếu giảng viên yêu cầu SQL Server Authentication, có thể dùng
`User Id=sa;Password=...` với thông tin được cấp cho máy thực hành.
Không nên tự ý đổi mật khẩu `sa` trên máy dùng chung. Nếu dùng SQL
Express, tên Server có thể là `Server=.\\SQLEXPRESS;`.

Đăng ký `SupermarketDbContext` trong `Program.cs` bằng `AddDbContext` và
`UseSqlServer` trước `builder.Build()`.

## 6. EF Core Migrations

Trong Package Manager Console, chọn `MiniSupermarket.API` ở ô Default
project rồi chạy:

``` powershell
Add-Migration InitialCreateDatabase
Update-Database
```

Khi thêm bảng khách hàng, chạy migration mới, ví dụ:

``` powershell
Add-Migration AddCustomersTable
Update-Database
```

Chỉ tạo migration mới khi model đã thay đổi và kiểm tra xem migration
tương ứng đã tồn tại hay chưa. Nếu dự án đã có migration, không tạo lại
`InitialCreateDatabase` một cách tùy tiện.

## 7. Categories API

`CategoriesController` sử dụng `SupermarketDbContext` thông qua
constructor injection và thao tác dữ liệu trực tiếp với SQL Server.

  HTTP     Endpoint                               Chức năng
  -------- -------------------------------------- -------------------
  GET      `/api/categories`                      Lấy danh sách
  GET      `/api/categories/{id}`                 Xem chi tiết
  GET      `/api/categories/search?keyword=...`   Tìm kiếm theo tên
  POST     `/api/categories`                      Thêm danh mục
  PUT      `/api/categories/{id}`                 Cập nhật
  DELETE   `/api/categories/{id}`                 Xóa

Các phương thức bất đồng bộ tiêu biểu: `ToListAsync()`, `FindAsync()`,
`SaveChangesAsync()`. `AsNoTracking()` phù hợp với truy vấn chỉ đọc.

## 8. Bài tập mở rộng: Customers

### Model `Customer.cs`

Các trường chính:

-   `CustomerId`: khóa chính, tự tăng.
-   `CustomerName`: tên khách hàng, bắt buộc.
-   `PhoneNumber`: số điện thoại, bắt buộc.
-   `Address`: địa chỉ, tùy chọn.
-   `RewardPoints`: điểm tích lũy, mặc định 0.
-   `MembershipRank`: hạng thành viên, mặc định `Chuẩn`.

Có thể bổ sung `Ward`, `District`, `Province` nếu mô hình của dự án hiện
tại đang sử dụng các trường địa chỉ chi tiết này.

### Dữ liệu mẫu

  Khách hàng     Số điện thoại   Hạng      Điểm
  -------------- --------------- ------- ------
  Nguyễn Văn A   0901122334      Vàng       150
  Trần Thị B     0918877665      Bạc         50
  Lê Văn C       0983344556      Chuẩn       10

Để seed dữ liệu bằng `HasData()`, cần gán `CustomerId` cố định cho từng
bản ghi.

### Customers API

  -------------------------------------------------------------------------------------
  HTTP                    Endpoint                              Chức năng
  ----------------------- ------------------------------------- -----------------------
  GET                     `/api/customers`                      Lấy danh sách

  GET                     `/api/customers/{id}`                 Xem chi tiết

  GET                     `/api/customers/search?keyword=...`   Tìm theo tên/số điện
                                                                thoại

  POST                    `/api/customers`                      Thêm khách hàng

  PUT                     `/api/customers/{id}`                 Cập nhật khách hàng

  DELETE                  `/api/customers/{id}`                 Xóa khách hàng
  -------------------------------------------------------------------------------------

## 9. WinForms Client

`FormCategoryManagement` và `FormCustomerManagement` sử dụng
`HttpClient` để gọi Web API.

Các thao tác cần kiểm thử: - Tải danh sách vào `DataGridView`. - Chọn
một dòng để hiển thị dữ liệu lên các ô nhập. - Thêm mới, cập nhật, xóa
và tìm kiếm. - Hiển thị thông báo khi API trả về lỗi hoặc thao tác thất
bại.

Cần đảm bảo địa chỉ API và cổng trong WinForms khớp với cổng đang chạy
của project API. Trong cấu hình hiện tại của dự án, API dùng
`https://localhost:7046/api/`; không dùng cổng cũ `7123` nếu API không
chạy ở cổng đó.

## 10. Kiểm thử và xác nhận dữ liệu

1.  Chạy `MiniSupermarket.API`.
2.  Mở Swagger để thử các endpoint.
3.  Mở SSMS, chọn đúng database và kiểm tra dữ liệu:

``` sql
USE BuiThiDiemTrinhMiniSupermarketDb;
GO
SELECT * FROM dbo.Categories;
SELECT * FROM dbo.Products;
SELECT * FROM dbo.Customers;
```

4.  Chạy WinForms, thử CRUD.
5.  Tắt rồi mở lại API và WinForms; dữ liệu đã lưu phải vẫn còn trong
    SQL Server.

## 11. Checklist nghiệm thu

-   [ ] Cài đủ các gói EF Core cần thiết.
-   [ ] Cấu hình chuỗi kết nối đúng với SQL Server đang dùng.
-   [ ] Đăng ký `SupermarketDbContext` trong `Program.cs`.
-   [ ] Migration tạo/cập nhật đúng các bảng.
-   [ ] Categories API đọc và ghi dữ liệu SQL Server.
-   [ ] Customers API hoàn thành CRUD và tìm kiếm.
-   [ ] WinForms gọi đúng API và hiển thị kết quả.
-   [ ] Dữ liệu vẫn còn sau khi khởi động lại ứng dụng.

## 12. Kết luận

Buổi 3 giúp sinh viên tích hợp SQL Server với ASP.NET Core Web API bằng
EF Core Code-First, quản lý thay đổi cấu trúc cơ sở dữ liệu bằng
Migrations và thực hiện CRUD bất đồng bộ. Phần mở rộng Customers áp dụng
cùng quy trình cho dữ liệu khách hàng thân thiết, làm nền tảng cho chức
năng tích điểm và thanh toán tại quầy POS.

**Định hướng tiếp theo:** hoàn thiện quản lý sản phẩm và kho, lọc theo
danh mục, tìm kiếm theo mã vạch và sử dụng `Include()` khi cần lấy dữ
liệu quan hệ.
