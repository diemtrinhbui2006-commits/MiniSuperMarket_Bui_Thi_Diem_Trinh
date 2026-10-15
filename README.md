# 🛒 HỆ THỐNG QUẢN LÝ SIÊU THỊ MINI  
**Buổi 5: ADO.NET nâng cao, Stored Procedure & Giao dịch POS Checkout**

**Môn học:** Lập trình Ứng dụng .NET Core (Mã môn: 229162)  
**Sinh viên:** Bùi Thị Diễm Trinh  
**MSSV:** 2124110287  
**Lớp học phần:** CCQ2411D  

---

## 🎯 Mục tiêu
- Nắm vững kiến trúc phân tầng kết nối dữ liệu và 5 thành phần cốt lõi của ADO.NET: `SqlConnection`, `SqlCommand`, `SqlParameter`, `SqlDataReader`, `DataTable`.
- Phân biệt và áp dụng đúng 3 phương thức: `ExecuteScalar()`, `ExecuteNonQuery()`, `ExecuteReader()`.
- Hiểu rõ SQL Injection và cách dùng `SqlParameter` để ngăn chặn.
- Ứng dụng **Connected Mode** (`SqlDataReader`) cho API tra cứu mã vạch siêu tốc (<100ms).
- Ứng dụng **Disconnected Mode** (`DataTable`, `SqlDataAdapter`) để cache dữ liệu trên RAM.
- Tối ưu hóa bằng Stored Procedure trên SQL Server.
- Làm chủ 4 đặc tính **ACID** (Atomicity, Consistency, Isolation, Durability).
- Điều khiển giao dịch POS Checkout bằng `SqlTransaction` (Orders → OrderDetails → Products → Customers) và rollback khi lỗi.
- Xây dựng API hủy đơn hàng và hoàn trả tồn kho an toàn.

---

## ⚙️ Công nghệ sử dụng
- C# / .NET 8.0  
- ASP.NET Core Web API  
- ADO.NET (Microsoft.Data.SqlClient)  
- SQL Server, T-SQL (Stored Procedures)  
- Swagger UI  
- Windows Forms, Visual Studio 2022  

---

## 🔄 Mô hình ADO.NET
| Tiêu chí | Connected Mode | Disconnected Mode |
|----------|----------------|-------------------|
| Đối tượng | SqlDataReader | DataTable, DataSet |
| Trung gian | SqlCommand | SqlDataAdapter |
| Trạng thái | Giữ kết nối mở | Đóng kết nối sau Fill() |
| RAM | Ít | Nhiều |
| Tốc độ | Siêu tốc | Trung bình |
| Ứng dụng | Quét mã vạch, báo cáo | DataGridView, cache ngoại tuyến |

---

## 📌 Phân biệt 3 phương thức SqlCommand
| Phương thức | Kiểu trả về | Khi dùng | Ví dụ |
|-------------|-------------|----------|-------|
| ExecuteScalar() | object | Truy vấn trả về 1 ô | COUNT, lấy OrderId |
| ExecuteNonQuery() | int | Ghi/sửa dữ liệu | UPDATE, INSERT, DELETE |
| ExecuteReader() | SqlDataReader | SELECT nhiều dòng | Tra cứu Barcode, báo cáo |

---

## 🗄️ Stored Procedures
- `sp_GetRevenueByCashier`: Doanh thu theo thu ngân.  
- `sp_GetRevenueByDateRange`: Doanh thu theo khoảng ngày.  
- `sp_GetTop5SellingProducts`: Top 5 sản phẩm bán chạy.  

---

## 🧾 Chuẩn ACID & SqlTransaction
- **Atomicity**: Tất cả hoặc không gì.  
- **Consistency**: Dữ liệu luôn nhất quán.  
- **Isolation**: Các giao dịch không ảnh hưởng nhau.  
- **Durability**: Commit là vĩnh viễn.  

---

## 🌐 Các Endpoint API
- **AdoProduct**  
  - `GET /api/ado-products/barcode/{barcode}` → tra cứu sản phẩm.  
  - `GET /api/ado-products/disconnected-cache` → cache sản phẩm.  
  - `GET /api/ado-products/filter-stock` → lọc tồn kho thấp.  
  - `GET /api/ado-products/category-summary` → thống kê theo danh mục.  

- **Reports**  
  - `GET /api/reports/revenue-by-cashier`  
  - `GET /api/reports/revenue-by-date`  
  - `GET /api/reports/top-selling-products`  

- **Checkout**  
  - `POST /api/checkout` → thanh toán POS.  
  - `DELETE /api/checkout/cancel/{orderId}` → hủy đơn, hoàn trả tồn kho.  

---

## 🖥️ Dự án Console Thực hành
- Bài 1: `ExecuteScalar()` → đếm sản phẩm.  
- Bài 2: `ExecuteNonQuery()` → cập nhật tồn kho.  
- Bài 3: `ExecuteReader()` → duyệt bảng sản phẩm.  
- Bài 4: `SqlTransaction` → rollback khi lỗi.  

---

## ✅ Kết quả mong đợi
- Phân biệt và áp dụng thành thạo ADO.NET.  
- Ngăn chặn SQL Injection bằng `SqlParameter`.  
- Hoàn thành API tra cứu Barcode, cache dữ liệu, báo cáo doanh thu.  
- Hiện thực hóa API Checkout & Cancel với `SqlTransaction`.  
- Đảm bảo tính toàn vẹn dữ liệu theo chuẩn ACID.  

---

📌 **Ghi chú:** Trong hệ thống giao dịch tài chính và bán lẻ tốc độ cao, ADO.NET thuần kết hợp `SqlTransaction` và `SqlDataReader` là giải pháp tối ưu về tốc độ, RAM và tính toàn vẹn dữ liệu.
