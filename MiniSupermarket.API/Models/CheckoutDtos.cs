/*
 * Họ tên sinh viên: Bùi Thị Diễm Trinh
 * Mã sinh viên: 2124110287
 * Lớp: CCQ2411D
 * Buổi 5 - Tiết 5: Các lớp DTO phục vụ nghiệp vụ thanh toán giỏ lẻ quầy POS bọc trong SqlTransaction
 */
namespace MiniSupermarket.API.Models
{
    // DTO biểu diễn từng dòng sản phẩm trong giỏ hàng
    public class CartItemCheckoutDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }

    // DTO nhận yêu cầu thanh toán tổng thể từ quầy POS
    public class CheckoutRequestDto
    {
        // Tài khoản thu ngân đang đứng ca trực
        public string CashierUsername { get; set; } = string.Empty;

        // Mã định danh khách hàng (nếu là khách vãng lai, truyền CustomerId = 15 hoặc mã khách lẻ)
        public int CustomerId { get; set; }

        // Danh sách các món hàng cần thanh toán
        public List<CartItemCheckoutDto> Items { get; set; } = new();
    }
}
