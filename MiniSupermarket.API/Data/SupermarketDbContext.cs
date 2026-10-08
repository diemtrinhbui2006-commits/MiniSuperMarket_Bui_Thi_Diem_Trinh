using Microsoft.EntityFrameworkCore;
using MiniSupermarket.API.Models;

namespace MiniSupermarket.API.Data
{
    // DbContext đại diện cho phiên làm việc với cơ sở dữ liệu SQL Server
    public class SupermarketDbContext : DbContext
    {
        public SupermarketDbContext(
            DbContextOptions<SupermarketDbContext> options
        ) : base(options)
        {
        }

        // Khai báo các bảng dữ liệu ánh xạ từ Model
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        // BẢNG KHÁCH HÀNG
        public DbSet<Customer> Customers { get; set; }

        // Cấu hình dữ liệu mồi ban đầu (Data Seeding)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ==============================
            // 1. SEED 15 DANH MỤC
            // ==============================
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "Bánh kẹo & Đồ ăn vặt",
                    Description = "Bánh quy, kẹo, snack, rong biển"
                },

                new Category
                {
                    CategoryId = 2,
                    CategoryName = "Nước giải khát",
                    Description = "Nước ngọt, nước khoáng, nước tăng lực"
                },

                new Category
                {
                    CategoryId = 3,
                    CategoryName = "Sữa & Sản phẩm từ sữa",
                    Description = "Sữa tươi, sữa chua, phô mai, sữa đặc"
                },

                new Category
                {
                    CategoryId = 4,
                    CategoryName = "Mì & Thực phẩm ăn liền",
                    Description = "Mì gói, phở khô, cháo ăn liền, miến"
                },

                new Category
                {
                    CategoryId = 5,
                    CategoryName = "Gia vị & Nấu ăn",
                    Description = "Nước mắm, nước tương, dầu ăn, hạt nêm"
                },

                new Category
                {
                    CategoryId = 6,
                    CategoryName = "Gạo & Ngũ cốc",
                    Description = "Gạo, đậu, ngũ cốc, yến mạch"
                },

                new Category
                {
                    CategoryId = 7,
                    CategoryName = "Đồ hộp & Thực phẩm đóng gói",
                    Description = "Cá hộp, thịt hộp, pate, thực phẩm đóng gói"
                },

                new Category
                {
                    CategoryId = 8,
                    CategoryName = "Cà phê & Trà",
                    Description = "Cà phê hòa tan, cà phê rang xay, trà túi lọc"
                },

                new Category
                {
                    CategoryId = 9,
                    CategoryName = "Nước chấm & Sốt",
                    Description = "Tương ớt, tương cà, sốt mayonnaise, nước chấm"
                },

                new Category
                {
                    CategoryId = 10,
                    CategoryName = "Đồ dùng gia đình",
                    Description = "Chổi, khăn lau, móc áo, đồ dùng nhà bếp"
                },

                new Category
                {
                    CategoryId = 11,
                    CategoryName = "Hóa mỹ phẩm",
                    Description = "Dầu gội, sữa tắm, kem đánh răng, xà phòng"
                },

                new Category
                {
                    CategoryId = 12,
                    CategoryName = "Giấy & Đồ dùng cá nhân",
                    Description = "Giấy vệ sinh, khăn giấy, khẩu trang, bông tẩy trang"
                },

                new Category
                {
                    CategoryId = 13,
                    CategoryName = "Đồ dùng học tập",
                    Description = "Bút, vở, thước, tập, dụng cụ học tập"
                },

                new Category
                {
                    CategoryId = 14,
                    CategoryName = "Thực phẩm đông lạnh",
                    Description = "Xúc xích, cá viên, bò viên, thực phẩm đông lạnh"
                },

                new Category
                {
                    CategoryId = 15,
                    CategoryName = "Đồ dùng trẻ em",
                    Description = "Sữa trẻ em, bánh ăn dặm, khăn và đồ dùng cho bé"
                }
            );

            // ==============================
            // 2. SEED 3 KHÁCH HÀNG
            // ==============================
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    CustomerId = 1,
                    CustomerName = "Nguyễn Văn A",
                    PhoneNumber = "0901122334",
                    Address = "25 Nguyễn Huệ",
                    Ward = "Phường 1",
                    District = "Thành phố Cao Lãnh",
                    Province = "Đồng Tháp",
                    MembershipRank = "Vàng",
                    RewardPoints = 150
                },

                new Customer
                {
                    CustomerId = 2,
                    CustomerName = "Trần Thị B",
                    PhoneNumber = "0918877665",
                    Address = "50 Lê Lợi",
                    Ward = "Phường 2",
                    District = "Thành phố Cao Lãnh",
                    Province = "Đồng Tháp",
                    MembershipRank = "Bạc",
                    RewardPoints = 50
                },

                new Customer
                {
                    CustomerId = 3,
                    CustomerName = "Lê Văn C",
                    PhoneNumber = "0983344556",
                    Address = "10 Nguyễn Trãi",
                    Ward = "Phường 1",
                    District = "Thành phố Cao Lãnh",
                    Province = "Đồng Tháp",
                    MembershipRank = "Chuẩn",
                    RewardPoints = 10
                }
            );
        }
    }
}