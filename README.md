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
