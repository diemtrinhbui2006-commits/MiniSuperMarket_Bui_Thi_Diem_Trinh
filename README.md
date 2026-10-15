🛒 HỆ THỐNG QUẢN LÝ SIÊU THỊ MINI (MINISUPERMARKET SYSTEM)

Môn học: Lập trình Ứng dụng .NET Core (Mã môn: 229162)
Buổi thực hành: Buổi 3 - Xây dựng Web API quản lý danh mục, khách hàng và kết nối WinForms Client (CRUD)

🏗️ 1. Mô hình kiến trúc hệ thống

Dự án được xây dựng theo mô hình Client - Server:

MiniSupermarket.API: ASP.NET Core Web API xử lý API, nghiệp vụ, kết nối SQL Server và Entity Framework Core.

MiniSupermarket.WinForms: ứng dụng Windows Forms sử dụng HttpClient và System.Net.Http.Json để gọi API và hiển thị dữ liệu trên DataGridView.

🛠️ 2. Công nghệ sử dụng

C# / .NET 8.0

ASP.NET Core Web API

Entity Framework Core

SQL Server

Windows Forms

HttpClient / System.Net.Http.Json

Swagger UI

Visual Studio 2022

🗄️ 3. Cơ sở dữ liệu

Database: BuiThiDiemTrinhMiniSupermarketDb

Connection String:

"DefaultConnection": "Server=.;Database=BuiThiDiemTrinhMiniSupermarketDb;User Id=sa;Password=123456;MultipleActiveResultSets=true;TrustServerCertificate=True"

Các bảng hiện có:

Categories

Products

Customers

__EFMigrationsHistory

15 nhóm hàng mẫu

Bánh kẹo & Đồ ăn vặt

Nước giải khát

Sữa & Sản phẩm từ sữa

Mì & Thực phẩm ăn liền

Gia vị & Nấu ăn

Gạo & Ngũ cốc

Đồ hộp & Thực phẩm đóng gói

Cà phê & Trà

Nước chấm & Sốt

Đồ dùng gia đình

Hóa mỹ phẩm

Giấy & Đồ dùng cá nhân

Đồ dùng học tập

Thực phẩm đông lạnh

Đồ dùng trẻ em

3 khách hàng mẫu

Nguyễn Văn A - 0901122334 - Vàng - 150 điểm

Trần Thị B - 0918877665 - Bạc - 50 điểm

Lê Văn C - 0983344556 - Chuẩn - 10 điểm

Thông tin khách hàng:

CustomerId, CustomerName, PhoneNumber, Address, Ward, District, Province, RewardPoints, MembershipRank.

📂 4. Cấu trúc Solution

MiniSupermarketSystem/
├── MiniSupermarket.API/
│   ├── Controllers/
│   │   ├── CategoriesController.cs
│   │   └── CustomersController.cs
│   ├── Data/
│   │   └── SupermarketDbContext.cs
│   ├── Models/
│   │   ├── Category.cs
│   │   ├── Product.cs
│   │   └── Customer.cs
│   ├── Migrations/
│   │   ├── InitialCreateDatabase
│   │   └── AddCustomer
│   ├── Program.cs
│   └── appsettings.json
└── MiniSupermarket.WinForms/
    ├── FormCategoryManagement.cs
    ├── FormCategoryManagement.Designer.cs
    ├── FormCustomerManagement.cs
    ├── FormCustomerManagement.Designer.cs
    └── Program.cs

🔌 5. Cấu hình API

API hiện chạy tại:

https://localhost:7046/api/

WinForms:

private static readonly HttpClient _client = new HttpClient
{
    BaseAddress = new Uri("https://localhost:7046/api/")
};

Lưu ý: Không dùng port 7123. Nếu báo lỗi localhost:7123, sửa thành 7046.

🚀 6. Backend API

6.1. Categories

GET    /api/categories
GET    /api/categories/{id}
GET    /api/categories/search?keyword=...
POST   /api/categories
PUT    /api/categories/{id}
DELETE /api/categories/{id}

6.2. Customers

GET    /api/customers
GET    /api/customers/{id}
GET    /api/customers/search?keyword=...
POST   /api/customers
PUT    /api/customers/{id}
DELETE /api/customers/{id}

Tìm kiếm khách hàng theo tên, số điện thoại, địa chỉ, phường, quận/huyện hoặc tỉnh/thành phố.

🖥️ 7. WinForms Client

FormCategoryManagement

Chức năng:

Tải danh sách

Thêm

Cập nhật

Xóa

Tìm kiếm

Chọn dòng trên DataGridView để sửa

FormCustomerManagement

Các trường:

Mã khách hàng

Tên khách hàng

Số điện thoại

Địa chỉ

Phường

Quận/Huyện

Tỉnh/TP

Điểm tích lũy

Hạng thành viên

Tìm kiếm

Chức năng:

Tải dữ liệu

Thêm khách hàng

Cập nhật khách hàng

Xóa khách hàng

Tìm kiếm khách hàng

Chọn dòng để đưa dữ liệu lên ô nhập

Program.cs hiện có thể chạy Form khách hàng bằng:

Application.Run(new FormCustomerManagement());

🧩 8. Entity Framework Core và Migration

Migration ban đầu:

Add-Migration InitialCreateDatabase
Update-Database

Migration thêm khách hàng:

Add-Migration AddCustomer
Update-Database

Kiểm tra database:

USE BuiThiDiemTrinhMiniSupermarketDb;

SELECT * FROM dbo.Categories;
SELECT * FROM dbo.Products;
SELECT * FROM dbo.Customers;

🧪 9. Kiểm thử Swagger

Chạy MiniSupermarket.API, sau đó mở:

https://localhost:7046/swagger

Kiểm tra:

Categories: GET, POST, PUT, DELETE, Search

Customers: GET, POST, PUT, DELETE, Search

🧪 10. Kiểm thử WinForms

Chạy MiniSupermarket.API.

Kiểm tra API tại port 7046.

Chạy MiniSupermarket.WinForms.

Kiểm tra tải dữ liệu.

Thử thêm, cập nhật, xóa và tìm kiếm khách hàng.

Có thể kiểm tra tương tự với nhóm hàng.

Dữ liệu được lưu trong SQL Server nên sau khi tắt và mở lại ứng dụng, dữ liệu vẫn còn.

⚠️ 11. Các lỗi đã gặp và cách xử lý

Lỗi port 7123

Nếu WinForms báo:

No connection could be made... localhost:7123

sửa:

https://localhost:7123/api/

thành:

https://localhost:7046/api/

Lỗi file WinForms.exe đang được sử dụng

Nếu Build báo file đang bị process MiniSupermarket.WinForms khóa:

Shift + F5

Mở Task Manager

End Task MiniSupermarket.WinForms

Build → Rebuild Solution

Lỗi SQL Server không tìm thấy dbo.Categories

Do đang ở database master. Chạy:

USE BuiThiDiemTrinhMiniSupermarketDb;
SELECT * FROM dbo.Categories;

Package Manager Console hỏi Name

Nếu nhập:

Add-Migration

PMC hỏi Name: thì nhập:

AddCustomer

sau đó:

Update-Database

▶️ 12. Thứ tự chạy

SQL Server
    ↓
MiniSupermarket.API
    ↓
https://localhost:7046/swagger
    ↓
MiniSupermarket.WinForms
    ↓
CRUD + Search

👨‍💻 13. Thông tin sinh viên

Họ tên: Bùi Thị Diễm Trinh
Mã sinh viên: 2124110287
Lớp học phần: CCQ2411D

---

# 🚀 BUỔI 5: ADO.NET NÂNG CAO, STORED PROCEDURE & GIAO DỊCH POS CHECKOUT

## 📌 1. Tổng quan nội dung đã hoàn thành
Toàn bộ mã nguồn cũ được **giữ nguyên 100%**, bổ sung đầy đủ các bài tập theo đề cương Buổi 5:

### 🔹 Tiết 1: 3 Bài tập nền tảng ADO.NET (Console App `ThucHanhAdoNet_Buoi05`)
- **Bài tập 1**: Đếm tổng số mặt hàng bằng `ExecuteScalar()`.
- **Bài tập 2**: Cập nhật tồn kho sản phẩm an toàn bằng `ExecuteNonQuery()` và `SqlParameter` (chống SQL Injection).
- **Bài tập 3**: Duyệt danh sách sản phẩm tốc độ cao bằng `SqlDataReader` (Forward-Only).

### 🔹 Tiết 2: Tra cứu Barcode siêu tốc & Mô hình ngắt kết nối (`AdoProductController.cs`)
- `GET /api/ado-products/barcode/{barcode}`: Tra cứu thông tin sản phẩm theo mã vạch bằng `SqlDataReader` (Connected Mode, phản hồi < 100ms).
- `GET /api/ado-products/disconnected-cache`: Nạp dữ liệu vào `DataTable` qua `SqlDataAdapter.Fill()` và ngắt kết nối ngay (Disconnected Mode).
- **Bài tập 2.1**: `GET /api/ado-products/filter-stock?minStock=50`: Tra cứu sản phẩm có tồn kho thấp để cảnh báo nhập hàng.
- **Bài tập 2.2**: `GET /api/ado-products/category-summary`: Đếm số lượng sản phẩm theo từng nhóm danh mục bằng `DataTable`.

### 🔹 Tiết 3: Stored Procedure & Báo cáo doanh thu ca trực (`ReportsController.cs`)
- Đã khởi tạo script CSDL `Scripts/Buoi05_Setup.sql` gồm bảng `Orders`, `OrderDetails`, seed 15 hóa đơn mẫu chuẩn xác.
- `GET /api/reports/revenue-by-cashier`: Gọi Stored Procedure `sp_GetRevenueByCashier` trả về thống kê 5 thu ngân (khớp 100% 4,822,000 đ).
- **Bài tập 3.1**: `GET /api/reports/revenue-by-date?fromDate=...&toDate=...`: Thực thi Stored Procedure `sp_GetRevenueByDateRange`.
- **Bài tập 3.2**: `GET /api/reports/top-selling-products`: Thực thi Stored Procedure `sp_GetTop5SellingProducts` tìm top 5 sản phẩm bán chạy nhất.

### 🔹 Tiết 4: Chuẩn ACID & Mô phỏng Rollback (`ThucHanhAdoNet_Buoi05`)
- Kiểm chứng vòng đời `BeginTransaction()` -> `Commit()` -> `Rollback()`.
- Mô phỏng ngoại lệ thiếu hàng kho tại Bước 2, tự động Rollback hoàn trả dữ liệu Bước 1, bảo đảm tồn kho không bị trừ sai.

### 🔹 Tiết 5: API Checkout đa bảng bọc SqlTransaction (`CheckoutController.cs`)
- `POST /api/checkout`:
  1. Tạo hóa đơn `Orders` và nhận lại `OrderId` bằng `OUTPUT INSERTED.OrderId` với `ExecuteScalar()`.
  2. Kiểm tra tồn kho từng sản phẩm với `SqlDataReader`, lưu `OrderDetails`, trừ tồn kho `Products`.
  3. Cộng điểm thưởng cho khách hàng `Customers`.
  4. Xác nhận `transaction.Commit()`.
  5. Nếu có lỗi (hết hàng): tự động `transaction.Rollback()`, không để lại dữ liệu rác.
- **Bài tập mở rộng**: `DELETE /api/checkout/cancel/{orderId}`:
  1. Đọc lại chi tiết đơn hàng, cộng hoàn trả tồn kho `Products`.
  2. Khấu trừ lại điểm thưởng khách hàng `Customers`.
  3. Xóa `OrderDetails` và `Orders` được bọc toàn diện trong `SqlTransaction`.

## 🛠️ 2. Hướng dẫn chạy & Kiểm thử

### Chạy kiểm tra Console App Buổi 5 (Tiết 1 & Tiết 4):
```bash
dotnet run --project ThucHanhAdoNet_Buoi05
# Hoặc chạy nhanh toàn bộ các bài tập:
dotnet run --project ThucHanhAdoNet_Buoi05 -- all
```

### Chạy Web API và Swagger UI (Tiết 2, Tiết 3, Tiết 5):
```bash
dotnet run --project MiniSupermarket.API
```
Mở trình duyệt: `https://localhost:7046/swagger` hoặc `http://localhost:5017/swagger` để kiểm thử tương tác trực quan các nhóm API:
- `AdoProduct`
- `Reports`
- `Checkout`

