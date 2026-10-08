using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniSupermarket.API.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

        [Required]
        [MaxLength(100)]
        public string CustomerName { get; set; } = string.Empty;

        [Required]
        [MaxLength(15)]
        public string PhoneNumber { get; set; } = string.Empty;

        [MaxLength(200)]
        public string? Address { get; set; }

        [MaxLength(100)]
        public string? Ward { get; set; }

        [MaxLength(100)]
        public string? District { get; set; }

        [MaxLength(100)]
        public string? Province { get; set; }

        public int RewardPoints { get; set; } = 0;

        [MaxLength(50)]
        public string MembershipRank { get; set; } = "Chuẩn";
    }
}