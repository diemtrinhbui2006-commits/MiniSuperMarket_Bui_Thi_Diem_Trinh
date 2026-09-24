# 🛒 HỆ THỐNG QUẢN LÝ SIÊU THỊ MINI
## MINI SUPERMARKET SYSTEM

> **Môn học:** Lập trình Ứng dụng .NET Core  
> **Buổi thực hành:** Buổi 2 - Xây dựng chức năng đăng nhập và phân quyền người dùng

---

## 📌 1. Giới thiệu

Ở Buổi 2, dự án MiniSupermarket được phát triển thêm chức năng:

- Đăng nhập hệ thống.
- Xác thực tài khoản thông qua Web API.
- Sinh và lưu JWT Token.
- Phân quyền người dùng theo Role.
- Kết nối ứng dụng WinForms với Web API.
- Hiển thị giao diện quản lý phù hợp với quyền đăng nhập.

Hệ thống tiếp tục sử dụng mô hình Client - Server:

- `MiniSupermarket.API`: Backend Web API.
- `MiniSupermarket.WinForms`: Ứng dụng Windows Forms Client.

---

## 🏗️ 2. Mô hình kiến trúc

```text
                  CLIENT - SERVER
                       │
          ┌────────────┴────────────┐
          │                         │
          ▼                         ▼
MiniSupermarket.WinForms     MiniSupermarket.API
       (Client)                    (Server)
          │                         │
          │      HTTP Request       │
          ├────────────────────────►│
          │                         │
          │      JSON Response      │
          │◄────────────────────────┤
          │                         │
          ▼                         ▼
      WinForms                 Controllers
                                Models
                                JWT
                                Role

👨‍💻 5. Tác giả
Họ tên sinh viên: Bùi Thị Diễm Trinh

Mã sinh viên: 2124110287


Lớp học phần: CCQ2411D

