# 🛒 HỆ THỐNG QUẢN LÝ SIÊU THỊ MINI --- BUỔI 4

**Môn học:** Lập trình Ứng dụng .NET Core (229162)\
**Sinh viên:** Bùi Thị Diễm Trinh\
**MSSV:** 2124110287\
**Lớp học phần:** CCQ2411D

## 1. Mục tiêu

-   Xây dựng `FormMainShell` theo kiến trúc Single-Form Architecture.
-   Dùng `panelSidebar` làm thanh điều hướng và `panelMainContent` làm
    vùng hiển thị nghiệp vụ.
-   Nhúng Form con bằng `TopLevel = false`, `FormBorderStyle = None`,
    `Dock = Fill`.
-   Phân quyền giao diện theo ba vai trò: `Admin`, `Cashier`,
    `Warehouse`.
-   Hiển thị thông tin người dùng, tiêu đề màn hình và chức năng đăng
    xuất.

## 2. Công nghệ

C# / .NET 8.0, Windows Forms, ASP.NET Core Web API, Entity Framework
Core, SQL Server, `HttpClient`, `System.Net.Http.Json`, Visual Studio
2022.

## 3. Kiến trúc giao diện

-   `panelSidebar`: thanh chức năng bên trái, rộng khoảng 230 px.
-   `panelTopHeader`: hiển thị tiêu đề màn hình và thông tin người dùng.
-   `panelMainContent`: vùng nhúng Form con.
-   `panelUserFooter`: khu vực đăng xuất ở cuối Sidebar.

  Nút               Chức năng
  ----------------- -------------------------
  `btnPOS`          Bán hàng
  `btnCategory`     Quản lý danh mục
  `btnProduct`      Quản lý sản phẩm và kho
  `btnCustomer`     Quản lý khách hàng
  `btnReports`      Báo cáo doanh thu
  `btnUserManage`   Quản trị tài khoản
  `btnLogout`       Đăng xuất

## 4. Nhúng Form con

Hàm `OpenChildForm()` đóng Form con cũ, làm nổi bật nút đang chọn, đặt
`TopLevel = false`, `FormBorderStyle = None`, `Dock = Fill`, thêm Form
vào `panelMainContent`, cập nhật `lblTitle` và gọi `Show()`. Nhờ đó, các
màn hình nghiệp vụ chạy trong cùng cửa sổ chính.

## 5. Phân quyền RBAC

  Chức năng               Admin   Cashier   Warehouse
  ---------------------- ------- --------- -----------
  Bán hàng POS              ✓        ✓         ---
  Quản lý danh mục          ✓       ---         ✓
  Quản lý sản phẩm/kho      ✓       ---         ✓
  Quản lý khách hàng        ✓        ✓         ---
  Báo cáo doanh thu         ✓       ---        ---
  Quản trị tài khoản        ✓       ---        ---

-   **Admin:** toàn quyền.
-   **Cashier (Thu ngân):** POS và khách hàng.
-   **Warehouse (Thủ kho):** danh mục và sản phẩm/kho.
-   **Vai trò không hợp lệ:** hiển thị cảnh báo và đóng màn hình.

Ẩn nút chỉ là kiểm soát phía Client. Backend/API cũng phải xác thực và
kiểm tra quyền để bảo vệ dữ liệu.

## 6. Màn hình mặc định

Theo bảng tổng kết của bài thực hành: - Admin →
`FormCategoryManagement`. - Cashier → `FormPOS`. - Warehouse →
`FormProductManagement`.

Lưu ý: phần hướng dẫn ban đầu có lựa chọn màn hình mặc định khác; cần
thống nhất theo lựa chọn trên trong mã nguồn.

## 7. Các Form nghiệp vụ

-   **`FormCategoryManagement`:** tải, thêm, sửa, xóa và tìm kiếm danh
    mục.
-   **`FormCustomerManagement`:** quản lý thông tin khách hàng, địa chỉ,
    điểm tích lũy và hạng thành viên; hỗ trợ CRUD và tìm kiếm.
-   **`FormPOS`:** quét mã vạch, quản lý giỏ hàng, tính tổng tiền/tiền
    thừa và gửi yêu cầu thanh toán. Cần có API tra cứu sản phẩm theo mã
    vạch và API `orders/checkout`.
-   **`FormProductManagement`:** tìm kiếm, thêm, sửa, xóa sản phẩm, chọn
    danh mục và quản lý tồn kho.
-   **`FormUserManagement`:** hiển thị/tạo tài khoản và quản lý vai trò;
    chỉ Admin được truy cập. Chức năng khóa tài khoản/đặt lại mật khẩu
    cần API tương ứng.
-   **`FormQuickReport`:** chọn ngày, hiển thị số hóa đơn, doanh thu và
    mặt hàng bán chạy; chỉ Admin được xem, cần API báo cáo tương ứng.

## 8. Đăng xuất

Khi nhấn `btnLogout`, ứng dụng hỏi xác nhận. Nếu đồng ý, xóa `JwtToken`,
`CurrentUsername`, `CurrentRole`, ẩn Form chính và mở `FormLogin`.

## 9. Kiểm thử phân quyền

  Tài khoản mẫu   Vai trò     Kết quả mong đợi
  --------------- ----------- -------------------------------
  `admin01`       Admin       Hiển thị đầy đủ chức năng
  `cashier01`     Cashier     Chỉ hiện POS và Khách hàng
  `ware01`        Warehouse   Chỉ hiện Danh mục và Sản phẩm

Mật khẩu mẫu trong tài liệu: `123456` (chỉ dùng cho bài tập).

Checklist: - \[ \] Ứng dụng chỉ có một cửa sổ chính. - \[ \] Form con
lấp đầy `panelMainContent`. - \[ \] Nút đang chọn đổi màu; tiêu đề cập
nhật đúng. - \[ \] Menu hiển thị đúng theo vai trò. - \[ \] Chức năng
không được cấp quyền bị chặn ở cả Client và API. - \[ \] CRUD hoạt động
và dữ liệu được lưu trong SQL Server. - \[ \] Đăng xuất xóa thông tin
phiên người dùng.

## 10. Cấu hình và thứ tự chạy

API: `https://localhost:7046/api/`\
Swagger: `https://localhost:7046/swagger`

1.  Khởi động SQL Server và kiểm tra database
    `BuiThiDiemTrinhMiniSupermarketDb`.
2.  Chạy `MiniSupermarket.API`.
3.  Kiểm tra API qua Swagger.
4.  Chạy `MiniSupermarket.WinForms`.
5.  Đăng nhập bằng tài khoản thử nghiệm và kiểm tra từng vai trò.

Nếu WinForms gọi `localhost:7123`, đổi sang
`https://localhost:7046/api/`.

## 11. Kết quả mong đợi

Hoàn thành giao diện quản lý tập trung, nhúng động Form con, điều hướng
theo vai trò và hiển thị các chức năng phù hợp. POS, quản lý sản phẩm,
tài khoản và báo cáo chỉ hoạt động đầy đủ khi API nghiệp vụ tương ứng đã
được triển khai.

------------------------------------------------------------------------

**Ghi chú:** Trong hệ thống thực tế, không được chỉ dựa vào việc ẩn nút
trên giao diện; Backend/API phải kiểm tra quyền truy cập.
