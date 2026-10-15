/*
 * =========================================================================
 * BÀI TẬP THỰC HÀNH BUỔI 5: ADO.NET NÂNG CAO & GIAO DỊCH DỮ LIỆU
 * Sinh viên: Bùi Thị Diễm Trinh
 * Mã sinh viên: 2124110287
 * Lớp: CCQ2411D
 * Trường: Cao đẳng Công thương TP.HCM (HITC)
 * =========================================================================
 */
using System;
using System.Text;
using Microsoft.Data.SqlClient;

namespace ThucHanhAdoNet_Buoi05
{
    internal class Program
    {
        // Chuỗi kết nối tới CSDL SQL Server của sinh viên Bùi Thị Diễm Trinh
        private static readonly string connString = 
            "Server=LAPTOP-R0664U5V\\SQLEXPRESS;Database=BuiThiDiemTrinhMiniSupermarketDb;Trusted_Connection=True;TrustServerCertificate=True;";

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            if (args.Length > 0)
            {
                if (args[0] == "1") { RunBaiTap1(); return; }
                if (args[0] == "2") { RunBaiTap2(); return; }
                if (args[0] == "3") { RunBaiTap3(); return; }
                if (args[0] == "4") { RunBaiTapTiet4(); return; }
                if (args[0] == "all" || args[0] == "5")
                {
                    RunBaiTap1();
                    Console.WriteLine();
                    RunBaiTap2();
                    Console.WriteLine();
                    RunBaiTap3();
                    Console.WriteLine();
                    RunBaiTapTiet4();
                    return;
                }
            }

            while (true)
            {
                if (!Console.IsOutputRedirected)
                {
                    try { Console.Clear(); } catch { }
                }
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("========================================================================");
                Console.WriteLine("   BÀI TẬP THỰC HÀNH BUỔI 5: ADO.NET NÂNG CAO - BÙI THỊ DIỄM TRINH      ");
                Console.WriteLine("   MÃ SINH VIÊN: 2124110287 | LỚP: CCQ2411D                             ");
                Console.WriteLine("========================================================================");
                Console.ResetColor();

                Console.WriteLine(" [1] TIẾT 1 - BÀI TẬP 1: Đếm tổng số mặt hàng (ExecuteScalar)");
                Console.WriteLine(" [2] TIẾT 1 - BÀI TẬP 2: Cập nhật tồn kho an toàn (ExecuteNonQuery & SqlParameter)");
                Console.WriteLine(" [3] TIẾT 1 - BÀI TẬP 3: Duyệt danh sách sản phẩm (SqlDataReader)");
                Console.WriteLine(" [4] TIẾT 4 - THỬ NGHIỆM: Mô phỏng ACID & Rollback với SqlTransaction");
                Console.WriteLine(" [5] CHẠY LIÊN HOÀN TOÀN BỘ CÁC BÀI TẬP");
                Console.WriteLine(" [0] Thoát chương trình");
                Console.WriteLine("------------------------------------------------------------------------");
                Console.Write(" >> Nhập lựa chọn của bạn (0-5): ");

                string? choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        RunBaiTap1();
                        Pause();
                        break;
                    case "2":
                        RunBaiTap2();
                        Pause();
                        break;
                    case "3":
                        RunBaiTap3();
                        Pause();
                        break;
                    case "4":
                        RunBaiTapTiet4();
                        Pause();
                        break;
                    case "5":
                        RunBaiTap1();
                        Console.WriteLine();
                        RunBaiTap2();
                        Console.WriteLine();
                        RunBaiTap3();
                        Console.WriteLine();
                        RunBaiTapTiet4();
                        Pause();
                        break;
                    case "0":
                        Console.WriteLine("Tạm biệt! Kết thúc chương trình.");
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Lựa chọn không hợp lệ, vui lòng chọn lại!");
                        Console.ResetColor();
                        Pause();
                        break;
                }
            }
        }

        // =========================================================================
        // TIẾT 1 - BÀI TẬP 1: Đếm tổng số mặt hàng bằng ExecuteScalar()
        // =========================================================================
        public static void RunBaiTap1()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("=== BÀI TẬP 1: ĐẾM TỔNG SỐ LƯỢNG MẶT HÀNG (EXECUTESCALAR) ===");
            Console.ResetColor();

            // Khởi tạo đối tượng SqlConnection trong khối using để tự động giải phóng
            using (SqlConnection connection = new SqlConnection(connString))
            {
                try
                {
                    // Câu lệnh SQL đếm toàn bộ số dòng trong bảng Products
                    string query = "SELECT COUNT(*) FROM Products";

                    // Khởi tạo đối tượng SqlCommand gắn câu lệnh với kết nối
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Bắt buộc phải mở kết nối trước khi thực thi
                        connection.Open();
                        Console.WriteLine("-> Đã kết nối thành công tới SQL Server!");

                        // ExecuteScalar() trả về một đối tượng kiểu object (ô 1 dòng 1)
                        object result = command.ExecuteScalar()!;
                        int totalCount = Convert.ToInt32(result);

                        // Hiển thị kết quả ra màn hình
                        Console.WriteLine($"-> Tổng số mặt hàng hiện có trong kho siêu thị: {totalCount} sản phẩm.");
                    }
                }
                catch (SqlException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"[LỖI SQL]: Không thể truy vấn CSDL. Chi tiết: {ex.Message}");
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"[LỖI HỆ THỐNG]: {ex.Message}");
                    Console.ResetColor();
                }
            } // Kết thúc using, connection.Close() và connection.Dispose() tự động được gọi
        }

        // =========================================================================
        // TIẾT 1 - BÀI TẬP 2: Cập nhật tồn kho sản phẩm bằng ExecuteNonQuery() và SqlParameter
        // =========================================================================
        public static void RunBaiTap2()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("=== BÀI TẬP 2: CẬP NHẬT TỒN KHO AN TOÀN VỚI SQLPARAMETER ===");
            Console.ResetColor();

            int maSanPhamCanSua = 1;      // Mã sản phẩm Danisa
            int soLuongTonKhoMoi = 50;     // Số lượng cập nhật

            using (SqlConnection connection = new SqlConnection(connString))
            {
                try
                {
                    // 1. Viết câu lệnh UPDATE có chứa 2 tham số @Stock và @Id (Tuyệt đối không cộng chuỗi)
                    string updateSql = @"UPDATE Products 
                                         SET StockQuantity = @Stock 
                                         WHERE ProductId = @Id";

                    using (SqlCommand command = new SqlCommand(updateSql, connection))
                    {
                        // 2. Gán giá trị an toàn vào tham số thông qua AddWithValue chống SQL Injection
                        command.Parameters.AddWithValue("@Stock", soLuongTonKhoMoi);
                        command.Parameters.AddWithValue("@Id", maSanPhamCanSua);

                        // 3. Mở kết nối
                        connection.Open();

                        // 4. Thực thi ExecuteNonQuery() để nhận về số dòng bị thay đổi trong CSDL
                        int rowsAffected = command.ExecuteNonQuery();

                        // 5. Kiểm tra kết quả thực thi
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine($"-> THÀNH CÔNG: Đã cập nhật tồn kho cho Sản phẩm ID = {maSanPhamCanSua} thành {soLuongTonKhoMoi} đơn vị.");
                            Console.WriteLine($"-> Số dòng dữ liệu bị ảnh hưởng: {rowsAffected} dòng.");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"-> CẢNH BÁO: Không tìm thấy sản phẩm có ID = {maSanPhamCanSua} để cập nhật.");
                            Console.ResetColor();
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"[LỖI SQL]: {ex.Message}");
                    Console.ResetColor();
                }
            }
        }

        // =========================================================================
        // TIẾT 1 - BÀI TẬP 3: Đọc danh sách sản phẩm bằng SqlDataReader
        // =========================================================================
        public static void RunBaiTap3()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("=== BÀI TẬP 3: DUYỆT DANH SÁCH BẰNG SQLDATAREADER (FORWARD-ONLY) ===");
            Console.ResetColor();

            using (SqlConnection connection = new SqlConnection(connString))
            {
                try
                {
                    // 1. Câu truy vấn lấy danh sách mặt hàng
                    string query = @"SELECT ProductId, Barcode, ProductName, Price, StockQuantity 
                                     FROM Products 
                                     ORDER BY ProductId ASC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        // 2. Kích hoạt luồng đọc trực tiếp bằng ExecuteReader()
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            Console.WriteLine("--------------------------------------------------------------------------------------------------");
                            Console.WriteLine(string.Format("{0,-6} | {1,-15} | {2,-38} | {3,14} | {4,8}", 
                                "MÃ SP", "MÃ VẠCH", "TÊN SẢN PHẨM", "ĐƠN GIÁ", "TỒN KHO"));
                            Console.WriteLine("--------------------------------------------------------------------------------------------------");

                            // 3. Vòng lặp while(reader.Read()): Dịch chuyển con trỏ xuống từng dòng dữ liệu tiếp theo
                            int stt = 0;
                            while (reader.Read())
                            {
                                stt++;

                                int id = Convert.ToInt32(reader["ProductId"]);
                                string barcode = reader["Barcode"].ToString() ?? "";
                                string name = reader["ProductName"].ToString() ?? "";
                                decimal price = Convert.ToDecimal(reader["Price"]);
                                int stock = Convert.ToInt32(reader["StockQuantity"]);

                                Console.WriteLine(string.Format("{0,-6} | {1,-15} | {2,-38} | {3,12:N0} đ | {4,8}", 
                                    id, barcode, name, price, stock));
                            }

                            Console.WriteLine("--------------------------------------------------------------------------------------------------");
                            Console.WriteLine($"-> Tổng cộng đã đọc thành công: {stt} mặt hàng từ SQL Server.");
                        } // Kết thúc using, reader tự động đóng lại
                    }
                }
                catch (SqlException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"[LỖI SQL]: {ex.Message}");
                    Console.ResetColor();
                }
            }
        }

        // =========================================================================
        // TIẾT 4 - THỬ NGHIỆM: Mô phỏng ACID & Rollback với SqlTransaction
        // =========================================================================
        public static void RunBaiTapTiet4()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("=== TIẾT 4: THỬ NGHIỆM ĐIỀU KHIỂN SQLTRANSACTION (CHUẨN ACID) ===");
            Console.ResetColor();

            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();

                // Lấy số lượng tồn kho ban đầu của SP 1 để so sánh sau khi Rollback
                int stockBefore = 0;
                using (SqlCommand cmdGet = new SqlCommand("SELECT StockQuantity FROM Products WHERE ProductId = 1", connection))
                {
                    stockBefore = Convert.ToInt32(cmdGet.ExecuteScalar());
                }
                Console.WriteLine($"-> [TRƯỚC GIAO DỊCH]: Tồn kho SP 1 hiện tại = {stockBefore}");

                // 1. Khởi tạo Transaction từ connection đã mở
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    Console.WriteLine("-> Bắt đầu phiên giao dịch (connection.BeginTransaction())...");

                    // 2. Thao tác 1: Trừ 5 đơn vị tồn kho của Sản phẩm ID = 1 (Hợp lệ)
                    string sqlStep1 = "UPDATE Products SET StockQuantity = StockQuantity - @Qty WHERE ProductId = @Id";
                    using (SqlCommand cmd1 = new SqlCommand(sqlStep1, connection, transaction))
                    {
                        cmd1.Parameters.AddWithValue("@Qty", 5);
                        cmd1.Parameters.AddWithValue("@Id", 1);
                        int r1 = cmd1.ExecuteNonQuery();
                        Console.WriteLine($"-> Bước 1: Đã trừ 5 đơn vị tồn kho SP 1 (Số dòng tác động: {r1}).");
                    }

                    // 3. Thao tác 2: Cố tình gây lỗi logic kiểm tra kho
                    Console.WriteLine("-> Bước 2: Chuẩn bị thực thi kiểm tra mặt hàng thứ 2...");
                    
                    bool isInventoryShortage = true; // Giả lập mặt hàng thứ hai bị hết kho
                    if (isInventoryShortage)
                    {
                        throw new InvalidOperationException("Mặt hàng thứ hai đã hết tồn kho thực tế! Giao dịch không thể hoàn tất.");
                    }

                    // 4. Nếu không có lỗi thì mới Commit
                    transaction.Commit();
                    Console.WriteLine("-> GIAO DỊCH COMMIT THÀNH CÔNG!");
                }
                catch (Exception ex)
                {
                    // 5. Khi bắt được lỗi -> Lập tức Rollback
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\n[PHÁT SINH NGOẠI LỆ]: {ex.Message}");
                    transaction.Rollback();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("-> [HỆ THỐNG]: Đã kích hoạt transaction.Rollback()!");
                    Console.WriteLine("-> Toàn bộ thay đổi của Bước 1 đã được hoàn tác sạch sẽ.");
                    Console.ResetColor();
                }

                // Kiểm chứng lại tồn kho SP 1 sau Rollback
                int stockAfter = 0;
                using (SqlCommand cmdCheck = new SqlCommand("SELECT StockQuantity FROM Products WHERE ProductId = 1", connection))
                {
                    stockAfter = Convert.ToInt32(cmdCheck.ExecuteScalar());
                }
                Console.WriteLine($"-> [SAU ROLLBACK]: Tồn kho SP 1 trong CSDL = {stockAfter} (Không bị trừ, giữ nguyên {stockBefore}!)");
            }
        }

        private static void Pause()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("-> Nhấn phím bất kỳ để tiếp tục...");
            Console.ResetColor();
            if (!Console.IsInputRedirected)
            {
                Console.ReadKey();
            }
        }
    }
}
