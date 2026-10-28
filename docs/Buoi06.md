# Buổi 6: EF Core nâng cao, phân trang LINQ và tích hợp Client–Server

**Sinh viên:** Bùi Thị Diễm Trinh — 2124110287 — CCQ2411D
**Môn:** 229162 · **Thời lượng:** 5 tiết thực hành

## 1. Mục tiêu và luồng dữ liệu

```text
WinForms → ApiClientService / HttpClient → Web API → EF Core / LINQ → SQL Server
         ← DTO / JSON                  ← kết quả của một trang dữ liệu
```

Sản phẩm được hiển thị từng trang để giảm dữ liệu truyền qua mạng và tránh tải toàn bộ bảng về giao diện. Truy vấn lấy tên nhóm hàng qua quan hệ `Product.Category`. `.ThenInclude()` phù hợp với quan hệ nhiều cấp; mô hình hiện tại chỉ cần `.Include()`.

## 2. Tiết 1–2: API phân trang

Các tệp chính:

- `MiniSupermarket.API/Models/PagedResponseDto.cs`: `ProductItemDto` và `PagedResult<T>`.
- `MiniSupermarket.API/Controllers/ProductController.cs`: `GetPagedProducts`.
- `MiniSupermarket.API/Controllers/CustomersController.cs`: phân trang khách hàng mở rộng.

Thứ tự xử lý:

1. Chuẩn hóa `pageNumber < 1` thành `1`; `pageSize` ngoài khoảng `1..50` về `5`.
2. Tạo `IQueryable` với `Include` và `AsNoTracking`.
3. Lọc theo `keyword` đã bỏ khoảng trắng thừa, kết hợp `categoryId` nếu có.
4. `CountAsync()` sau khi lọc để tính tổng số dòng và `Ceiling(totalItems / pageSize)`.
5. Sắp xếp ổn định bằng `ProductId`, rồi `Skip((pageNumber - 1) * pageSize).Take(pageSize)`.
6. Chiếu sang DTO có `CategoryName` và trả metadata cùng dữ liệu.

Truy vấn trên SQL Server được dịch thành JOIN và `ORDER BY ... OFFSET ... FETCH NEXT ...`. Việc đếm là một truy vấn riêng; lấy dữ liệu một trang không cần truy vấn thêm từng danh mục, tránh N+1 Query.

Ví dụ request:

```http
GET /api/products/paged?keyword=Coca&categoryId=2&pageNumber=1&pageSize=5
```

Ví dụ response với dữ liệu mẫu hiện có trong dự án:

```json
{
  "currentPage": 1,
  "pageSize": 5,
  "totalItems": 1,
  "totalPages": 1,
  "items": [
    {
      "productId": 2,
      "barcode": "8934567890002",
      "productName": "Nước ngọt Coca Cola lon 330ml",
      "price": 10000,
      "stockQuantity": 120,
      "categoryId": 2,
      "categoryName": "Nước giải khát"
    }
  ]
}
```

Không có kết quả: `totalItems = 0`, `totalPages = 0`, `items = []`. Trang vượt phạm vi trả danh sách rỗng, vẫn giữ tổng và số trang được yêu cầu; tính offset bằng `long` để tránh tràn số.

**Dữ liệu:** giữ 15 sản phẩm và 15 danh mục đã seed từ các buổi trước. Bảng minh họa của đề buổi 6 dùng tên, mã vạch và nhóm khác; không ghi đè dữ liệu cũ chỉ để khớp ví dụ trong đề. Với database mới áp dụng migration, 15 sản phẩm chia thành 3 trang, mỗi trang 5 dòng.

## 3. Tiết 3: kiểm tra API và SQL

Sau khi cấu hình SQL Server và chạy migration theo README:

| Tình huống | Kết quả mong đợi |
| --- | --- |
| Không từ khóa, trang 1, kích thước 5 | 5 dòng, tổng 15 dòng / 3 trang với database mẫu mới |
| Trang 2 rồi trang 3 | Sản phẩm có ID kế tiếp, không trùng giữa các trang |
| `keyword=Coca` | Chỉ các tên/mã vạch phù hợp, tổng dòng và tổng trang tính lại |
| `keyword=8934567890002` | Tìm theo mã vạch |
| `categoryId=2` và từ khóa | Kết hợp cả hai điều kiện trước khi phân trang |
| Từ khóa không tồn tại | Danh sách rỗng, tổng dòng/trang bằng 0 |
| `pageNumber=0&pageSize=51` | Chuẩn hóa về trang 1, kích thước 5 |
| `pageNumber=2147483647` | Không tràn số; danh sách rỗng |

Quan sát log `Microsoft.EntityFrameworkCore.Database.Command` để đối chiếu JOIN, COUNT và OFFSET/FETCH trên SQL Server. Tên nhóm hàng phải khớp dữ liệu bảng `Categories`, không chỉ kiểm tra trường tồn tại.

## 4. Tiết 4–5: WinForms

Mở **Quản lý sản phẩm** từ giao diện chính đã có. `FormProductManagement` sử dụng:

- ComboBox nhóm hàng để nhập sản phẩm và ComboBox riêng để lọc danh sách.
- DataGridView hiển thị ID, mã vạch, tên, giá, tồn kho và tên nhóm hàng.
- Nút trang trước/sau, số trang hiện tại và tổng sản phẩm; mỗi lần gọi API chỉ nhận 5 dòng.
- Tìm kiếm theo tên/mã vạch; tìm kiếm hoặc đổi nhóm sẽ quay về trang 1.
- Thêm, sửa, xóa qua `POST`, `PUT`, `DELETE`; chọn dòng để đưa dữ liệu vào ô nhập.
- Sau khi xóa phần tử cuối của trang cuối, tải lại trang còn hợp lệ.
- `async/await`, xử lý lỗi HTTP/kết nối và ngăn các thao tác tải chồng nhau.

`ApiClientService` dùng chung một `HttpClient`, mặc định cổng `7046`, hỗ trợ cấu hình `MINISUPERMARKET_API_URL`. Khi có token thật từ dịch vụ đăng nhập, gọi:

```csharp
ApiClientService.AttachToken(token);
// Xóa Authorization khi kết thúc phiên:
ApiClientService.AttachToken(null);
```

Đăng nhập hiện tại là mô phỏng từ buổi trước. Buổi 6 bổ sung cơ chế gửi Bearer Token phía client; cấp token và xác minh JWT phía API vẫn cần triển khai riêng nếu yêu cầu xác thực thật.

## 5. Bài mở rộng

- **6.1:** `GET /api/customers/paged` tìm kiếm khách hàng và sắp xếp `RewardPoints` giảm dần; nếu cùng điểm thì `CustomerId` tăng dần để phân trang ổn định.
- **6.2:** `categoryId` trong API sản phẩm và ComboBox lọc nhóm; chọn “Tất cả” để bỏ lọc. Từ khóa và nhóm hàng được lọc cùng lúc tại máy chủ.

## 6. Nghiệm thu trên SQL Server và Windows

Các mục sau là checklist kiểm tra thủ công, chưa tự đánh dấu hoàn tất bằng kết quả SQLite:

- [ ] Swagger trả đúng metadata và 5 dòng/trang trên SQL Server.
- [ ] `CategoryName` đúng với danh mục trong database.
- [ ] Từ khóa và bộ lọc nhóm hoạt động cùng nhau, tổng số trang cập nhật đúng.
- [ ] Chuyển trang WinForms và trạng thái nút đầu/cuối đúng.
- [ ] Thêm một sản phẩm thử, kiểm tra bản ghi mới trong SQL Server.
- [ ] Sửa tên, giá, tồn kho hoặc nhóm hàng, kiểm tra dữ liệu lưu lại.
- [ ] Xóa sản phẩm thử, kiểm tra bảng và trang cuối được cập nhật.
- [ ] Mất kết nối API hiển thị lỗi và cho phép thao tác lại.
- [ ] Nếu tích hợp xác thực thật: token hợp lệ được gửi, đăng xuất xóa token.

Chạy kiểm thử tự động từ thư mục gốc bằng `dotnet test MiniSupermarket.API.Tests`. SQLite kiểm tra được hợp đồng HTTP và truy vấn quan hệ, nhưng không xác nhận migration, collation hoặc cú pháp thực thi riêng của SQL Server. WinForms cần Windows để kiểm tra trực tiếp giao diện.
