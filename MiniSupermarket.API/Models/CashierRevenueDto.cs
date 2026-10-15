/*
 * Họ tên sinh viên: Bùi Thị Diễm Trinh
 * Mã sinh viên: 2124110287
 * Lớp: CCQ2411D
 * Buổi 5 - Tiết 3: DTO hứng dữ liệu kết quả thống kê doanh thu từ Stored Procedure sp_GetRevenueByCashier
 */
namespace MiniSupermarket.API.Models
{
    public class CashierRevenueDto
    {
        // Tên đăng nhập của thu ngân chịu trách nhiệm ca bán
        public string CashierUsername { get; set; } = string.Empty;

        // Tổng số lượng đơn hàng thu ngân đã xử lý thành công
        public int TotalOrders { get; set; }

        // Tổng số tiền thu về cho siêu thị (VNĐ)
        public decimal TotalRevenue { get; set; }

        // Tổng điểm thưởng đã tích lũy cho khách hàng
        public int TotalPointsAwarded { get; set; }
    }

    // DTO cho bài tập 3.2: Top 5 sản phẩm bán chạy nhất
    public class TopSellingProductDto
    {
        public int ProductId { get; set; }
        public string Barcode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public int TotalQuantitySold { get; set; }
        public decimal TotalRevenue { get; set; }
    }
}
