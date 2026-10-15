namespace MiniSupermarket.API.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public string CustomerName { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public int RewardPoints { get; set; } = 0;

        public string MembershipRank { get; set; } = "Chuẩn";
    }
}