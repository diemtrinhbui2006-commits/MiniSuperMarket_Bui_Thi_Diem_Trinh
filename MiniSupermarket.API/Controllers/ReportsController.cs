/*
 * Họ tên sinh viên: Bùi Thị Diễm Trinh
 * Mã sinh viên: 2124110287
 * Lớp: CCQ2411D
 * Buổi 5 - Tiết 3: Controller ADO.NET thực thi Stored Procedure xuất báo cáo ca bán và top sản phẩm
 */
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MiniSupermarket.API.Models;
using System.Data;

namespace MiniSupermarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        // Dependency Injection lấy chuỗi kết nối từ appsettings.json
        public ReportsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // =========================================================================
        // GET: api/reports/revenue-by-cashier
        // Chức năng: Gọi Stored Procedure sp_GetRevenueByCashier qua SqlDataReader
        // =========================================================================
        [HttpGet("revenue-by-cashier")]
        public IActionResult GetRevenueByCashier()
        {
            var reportList = new List<CashierRevenueDto>();
            string connectionString = _configuration.GetConnectionString("DefaultConnection")!;

            // 1. Khởi tạo SqlConnection trong khối using đảm bảo tự động đóng kết nối
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // 2. Gán CommandText là CHÍNH XÁC tên Stored Procedure trên SQL Server
                using (SqlCommand command = new SqlCommand("sp_GetRevenueByCashier", connection))
                {
                    // 3. ĐIỂM KHOA HỌC QUAN TRỌNG: Thiết lập CommandType là StoredProcedure
                    // Nếu thiếu dòng này, SQL Server sẽ hiểu nhầm đây là chuỗi SQL thường và báo lỗi cú pháp!
                    command.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        // 4. Mở kết nối vật lý tới SQL Server
                        connection.Open();

                        // 5. Thực thi bằng ExecuteReader(): Nhận về luồng dữ liệu forward-only
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // 6. Vòng lặp đọc từng dòng kết quả của Stored Procedure
                            while (reader.Read())
                            {
                                // Ánh xạ từng cột dữ liệu từ reader vào đối tượng DTO
                                var item = new CashierRevenueDto
                                {
                                    CashierUsername = reader["CashierUsername"].ToString() ?? string.Empty,
                                    TotalOrders = Convert.ToInt32(reader["TotalOrders"]),
                                    TotalRevenue = Convert.ToDecimal(reader["TotalRevenue"]),
                                    TotalPointsAwarded = reader["TotalPointsAwarded"] != DBNull.Value 
                                        ? Convert.ToInt32(reader["TotalPointsAwarded"]) 
                                        : 0
                                };

                                reportList.Add(item);
                            }
                        } // reader tự động Close() tại đây
                    }
                    catch (SqlException ex)
                    {
                        // Bắt lỗi nếu quên tạo Stored Procedure trên CSDL hoặc sai chuỗi kết nối
                        return StatusCode(500, new 
                        { 
                            success = false,
                            message = "Lỗi thực thi Stored Procedure trên SQL Server: " + ex.Message 
                        });
                    }
                }
            } // connection tự động Close() và Dispose() tại đây

            // 7. Trả về mã 200 OK kèm danh sách báo cáo đã tổng hợp
            return Ok(new
            {
                success = true,
                generatedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                totalCashiers = reportList.Count,
                grandTotalRevenue = reportList.Sum(x => x.TotalRevenue),
                data = reportList
            });
        }

        // =========================================================================
        // BÀI TẬP 3.1: BÁO CÁO DOANH THU THEO KHOẢNG NGÀY (CÓ THAM SỐ)
        // GET: api/reports/revenue-by-date?fromDate=2026-08-01&toDate=2026-08-31
        // =========================================================================
        [HttpGet("revenue-by-date")]
        public IActionResult GetRevenueByDateRange([FromQuery] DateTime fromDate, [FromQuery] DateTime toDate)
        {
            var reportList = new List<CashierRevenueDto>();
            string connectionString = _configuration.GetConnectionString("DefaultConnection")!;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_GetRevenueByDateRange", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    // Truyền tham số an toàn cho Stored Procedure
                    command.Parameters.AddWithValue("@FromDate", fromDate);
                    command.Parameters.AddWithValue("@ToDate", toDate.Date.AddDays(1).AddTicks(-1)); // Đến hết ngày toDate

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                reportList.Add(new CashierRevenueDto
                                {
                                    CashierUsername = reader["CashierUsername"].ToString() ?? string.Empty,
                                    TotalOrders = Convert.ToInt32(reader["TotalOrders"]),
                                    TotalRevenue = Convert.ToDecimal(reader["TotalRevenue"]),
                                    TotalPointsAwarded = reader["TotalPointsAwarded"] != DBNull.Value 
                                        ? Convert.ToInt32(reader["TotalPointsAwarded"]) 
                                        : 0
                                });
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        return StatusCode(500, new 
                        { 
                            success = false, 
                            message = "Lỗi thực thi Stored Procedure theo khoảng ngày: " + ex.Message 
                        });
                    }
                }
            }

            return Ok(new
            {
                success = true,
                fromDate = fromDate.ToString("yyyy-MM-dd"),
                toDate = toDate.ToString("yyyy-MM-dd"),
                totalCashiers = reportList.Count,
                grandTotalRevenue = reportList.Sum(x => x.TotalRevenue),
                data = reportList
            });
        }

        // =========================================================================
        // BÀI TẬP 3.2: TOP 5 SẢN PHẨM BÁN CHẠY NHẤT
        // GET: api/reports/top-selling-products
        // =========================================================================
        [HttpGet("top-selling-products")]
        public IActionResult GetTop5SellingProducts()
        {
            var topList = new List<TopSellingProductDto>();
            string connectionString = _configuration.GetConnectionString("DefaultConnection")!;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_GetTop5SellingProducts", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                topList.Add(new TopSellingProductDto
                                {
                                    ProductId = Convert.ToInt32(reader["ProductId"]),
                                    Barcode = reader["Barcode"].ToString() ?? string.Empty,
                                    ProductName = reader["ProductName"].ToString() ?? string.Empty,
                                    TotalQuantitySold = Convert.ToInt32(reader["TotalQuantitySold"]),
                                    TotalRevenue = Convert.ToDecimal(reader["TotalRevenue"])
                                });
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        return StatusCode(500, new 
                        { 
                            success = false, 
                            message = "Lỗi thực thi Stored Procedure Top 5 sản phẩm: " + ex.Message 
                        });
                    }
                }
            }

            return Ok(new
            {
                success = true,
                generatedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                count = topList.Count,
                data = topList
            });
        }
    }
}
