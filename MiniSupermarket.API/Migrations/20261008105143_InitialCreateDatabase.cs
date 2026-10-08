using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniSupermarket.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Barcode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[,]
                {
                    { 1, "Bánh kẹo & Đồ ăn vặt", "Bánh quy, kẹo, snack, rong biển" },
                    { 2, "Nước giải khát", "Nước ngọt, nước khoáng, nước tăng lực" },
                    { 3, "Sữa & Sản phẩm từ sữa", "Sữa tươi, sữa chua, phô mai, sữa đặc" },
                    { 4, "Mì & Thực phẩm ăn liền", "Mì gói, phở khô, cháo ăn liền, miến" },
                    { 5, "Gia vị & Nấu ăn", "Nước mắm, nước tương, dầu ăn, hạt nêm" },
                    { 6, "Gạo & Ngũ cốc", "Gạo, đậu, ngũ cốc, yến mạch" },
                    { 7, "Đồ hộp & Thực phẩm đóng gói", "Cá hộp, thịt hộp, pate, thực phẩm đóng gói" },
                    { 8, "Cà phê & Trà", "Cà phê hòa tan, cà phê rang xay, trà túi lọc" },
                    { 9, "Nước chấm & Sốt", "Tương ớt, tương cà, sốt mayonnaise, nước chấm" },
                    { 10, "Đồ dùng gia đình", "Chổi, khăn lau, móc áo, đồ dùng nhà bếp" },
                    { 11, "Hóa mỹ phẩm", "Dầu gội, sữa tắm, kem đánh răng, xà phòng" },
                    { 12, "Giấy & Đồ dùng cá nhân", "Giấy vệ sinh, khăn giấy, khẩu trang, bông tẩy trang" },
                    { 13, "Đồ dùng học tập", "Bút, vở, thước, tập, dụng cụ học tập" },
                    { 14, "Thực phẩm đông lạnh", "Xúc xích, cá viên, bò viên, thực phẩm đông lạnh" },
                    { 15, "Đồ dùng trẻ em", "Sữa trẻ em, bánh ăn dặm, khăn và đồ dùng cho bé" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
