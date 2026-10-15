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
            // 2. SEED 15 SẢN PHẨM TẠP HÓA
            // ==============================
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    Barcode = "8934567890001",
                    ProductName = "Bánh quy bơ Danisa 454g",
                    Price = 125000,
                    StockQuantity = 50,
                    CategoryId = 1
                },

                new Product
                {
                    ProductId = 2,
                    Barcode = "8934567890002",
                    ProductName = "Nước ngọt Coca Cola lon 330ml",
                    Price = 10000,
                    StockQuantity = 120,
                    CategoryId = 2
                },

                new Product
                {
                    ProductId = 3,
                    Barcode = "8934567890003",
                    ProductName = "Sữa tươi Vinamilk 180ml",
                    Price = 7500,
                    StockQuantity = 200,
                    CategoryId = 3
                },

                new Product
                {
                    ProductId = 4,
                    Barcode = "8934567890004",
                    ProductName = "Mì Hảo Hảo tôm chua cay 75g",
                    Price = 4500,
                    StockQuantity = 300,
                    CategoryId = 4
                },

                new Product
                {
                    ProductId = 5,
                    Barcode = "8934567890005",
                    ProductName = "Nước mắm Nam Ngư 500ml",
                    Price = 32000,
                    StockQuantity = 80,
                    CategoryId = 5
                },

                new Product
                {
                    ProductId = 6,
                    Barcode = "8934567890006",
                    ProductName = "Gạo ST25 túi 5kg",
                    Price = 145000,
                    StockQuantity = 40,
                    CategoryId = 6
                },

                new Product
                {
                    ProductId = 7,
                    Barcode = "8934567890007",
                    ProductName = "Cá hộp ba cô gái 155g",
                    Price = 28000,
                    StockQuantity = 60,
                    CategoryId = 7
                },

                new Product
                {
                    ProductId = 8,
                    Barcode = "8934567890008",
                    ProductName = "Cà phê hòa tan Trung Nguyên 3in1",
                    Price = 65000,
                    StockQuantity = 70,
                    CategoryId = 8
                },

                new Product
                {
                    ProductId = 9,
                    Barcode = "8934567890009",
                    ProductName = "Tương ớt Chinsu 250g",
                    Price = 18000,
                    StockQuantity = 90,
                    CategoryId = 9
                },

                new Product
                {
                    ProductId = 10,
                    Barcode = "8934567890010",
                    ProductName = "Nước rửa chén Sunlight 750ml",
                    Price = 32000,
                    StockQuantity = 75,
                    CategoryId = 10
                },

                new Product
                {
                    ProductId = 11,
                    Barcode = "8934567890011",
                    ProductName = "Dầu gội Clear 650g",
                    Price = 115000,
                    StockQuantity = 45,
                    CategoryId = 11
                },

                new Product
                {
                    ProductId = 12,
                    Barcode = "8934567890012",
                    ProductName = "Khăn giấy Pulppy 3 lớp",
                    Price = 28000,
                    StockQuantity = 100,
                    CategoryId = 12
                },

                new Product
                {
                    ProductId = 13,
                    Barcode = "8934567890013",
                    ProductName = "Bút bi Thiên Long TL-027",
                    Price = 5000,
                    StockQuantity = 150,
                    CategoryId = 13
                },

                new Product
                {
                    ProductId = 14,
                    Barcode = "8934567890014",
                    ProductName = "Xúc xích CP gói 200g",
                    Price = 42000,
                    StockQuantity = 65,
                    CategoryId = 14
                },

                new Product
                {
                    ProductId = 15,
                    Barcode = "8934567890015",
                    ProductName = "Bánh ăn dặm Gerber cho bé",
                    Price = 68000,
                    StockQuantity = 35,
                    CategoryId = 15
                }
            );
            // ==============================
            // 2. SEED 13 KHÁCH HÀNG (3 CŨ + 10 MỚI)
            // ==============================
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    CustomerId = 1,
                    CustomerName = "Nguyễn Thị Lan",
                    PhoneNumber = "0901234567",
                    Address = "Số 25, đường Nguyễn Huệ",
                    Ward = "Phường 1",
                    District = "Thành phố Cao Lãnh",
                    Province = "Đồng Tháp",
                    MembershipRank = "Vàng",
                    RewardPoints = 250
                },

                new Customer
                {
                    CustomerId = 2,
                    CustomerName = "Trần Văn Minh",
                    PhoneNumber = "0912345678",
                    Address = "Số 50, đường Lê Lợi",
                    Ward = "Phường 2",
                    District = "Thành phố Cao Lãnh",
                    Province = "Đồng Tháp",
                    MembershipRank = "Bạc",
                    RewardPoints = 120
                },

                new Customer
                {
                    CustomerId = 3,
                    CustomerName = "Lê Thị Hồng",
                    PhoneNumber = "0987654321",
                    Address = "Số 10, đường Nguyễn Trãi",
                    Ward = "Phường 1",
                    District = "Thành phố Cao Lãnh",
                    Province = "Đồng Tháp",
                    MembershipRank = "Chuẩn",
                    RewardPoints = 35
                },

                // 10 Khách hàng mới thêm
                new Customer
                {
                    CustomerId = 4,
                    CustomerName = "Phạm Hoàng Nam",
                    PhoneNumber = "0939112233",
                    Address = "Số 88, đường Lý Thường Kiệt",
                    Ward = "Phường 3",
                    District = "Thành phố Cao Lãnh",
                    Province = "Đồng Tháp",
                    MembershipRank = "Kim Cương",
                    RewardPoints = 680
                },

                new Customer
                {
                    CustomerId = 5,
                    CustomerName = "Đặng Thu Thảo",
                    PhoneNumber = "0945223344",
                    Address = "Số 15, đường Hùng Vương",
                    Ward = "Phường 2",
                    District = "Thành phố Sa Đéc",
                    Province = "Đồng Tháp",
                    MembershipRank = "Vàng",
                    RewardPoints = 310
                },

                new Customer
                {
                    CustomerId = 6,
                    CustomerName = "Võ Văn Tuấn",
                    PhoneNumber = "0978334455",
                    Address = "Số 102, đường Trần Hưng Đạo",
                    Ward = "Phường 1",
                    District = "Thành phố Sa Đéc",
                    Province = "Đồng Tháp",
                    MembershipRank = "Bạc",
                    RewardPoints = 150
                },

                new Customer
                {
                    CustomerId = 7,
                    CustomerName = "Bùi Thị Mai",
                    PhoneNumber = "0918445566",
                    Address = "Số 42, đường Điện Biên Phủ",
                    Ward = "Phường Mỹ Phú",
                    District = "Thành phố Cao Lãnh",
                    Province = "Đồng Tháp",
                    MembershipRank = "Chuẩn",
                    RewardPoints = 50
                },

                new Customer
                {
                    CustomerId = 8,
                    CustomerName = "Ngo Thanh Tung",
                    PhoneNumber = "0927556677",
                    Address = "Số 79, đường Nguyễn Sinh Cung",
                    Ward = "Phường 2",
                    District = "Thành phố Sa Đéc",
                    Province = "Đồng Tháp",
                    MembershipRank = "Vàng",
                    RewardPoints = 290
                },

                new Customer
                {
                    CustomerId = 9,
                    CustomerName = "Dương Quốc Bảo",
                    PhoneNumber = "0966667788",
                    Address = "Số 14, đường Võ Trường Toản",
                    Ward = "Phường 4",
                    District = "Thành phố Cao Lãnh",
                    Province = "Đồng Tháp",
                    MembershipRank = "Bạc",
                    RewardPoints = 180
                },

                new Customer
                {
                    CustomerId = 10,
                    CustomerName = "Hoàng Kim Ngân",
                    PhoneNumber = "0908778899",
                    Address = "Số 63, đường Phạm Hữu Lầu",
                    Ward = "Phường 6",
                    District = "Thành phố Cao Lãnh",
                    Province = "Đồng Tháp",
                    MembershipRank = "Chuẩn",
                    RewardPoints = 15
                },

                new Customer
                {
                    CustomerId = 11,
                    CustomerName = "Đỗ Duy Khoa",
                    PhoneNumber = "0931889900",
                    Address = "Số 05, đường Nguyễn Huệ",
                    Ward = "Phường An Thạnh",
                    District = "Thành phố Hồng Ngự",
                    Province = "Đồng Tháp",
                    MembershipRank = "Bạc",
                    RewardPoints = 95
                },

                new Customer
                {
                    CustomerId = 12,
                    CustomerName = "Trịnh Tuyết Mai",
                    PhoneNumber = "0949990011",
                    Address = "Số 118, đường Quốc Lộ 30",
                    Ward = "Phường Mỹ Trà",
                    District = "Thành phố Cao Lãnh",
                    Province = "Đồng Tháp",
                    MembershipRank = "Kim Cương",
                    RewardPoints = 820
                },

                new Customer
                {
                    CustomerId = 13,
                    CustomerName = "Lý Văn Đức",
                    PhoneNumber = "0981001122",
                    Address = "Số 200, đường Lê Đại Hành",
                    Ward = "Phường Mỹ Phú",
                    District = "Thành phố Cao Lãnh",
                    Province = "Đồng Tháp",
                    MembershipRank = "Chuẩn",
                    RewardPoints = 40
                }
            );
        }
    }
}