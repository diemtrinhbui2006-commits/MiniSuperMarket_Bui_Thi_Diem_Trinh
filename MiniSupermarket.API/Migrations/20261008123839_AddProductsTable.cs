using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniSupermarket.API.Migrations
{
    /// <inheritdoc />
    public partial class AddProductsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Barcode", "CategoryId", "Price", "ProductName", "StockQuantity" },
                values: new object[,]
                {
                    { 1, "8934567890001", 1, 125000m, "Bánh quy bơ Danisa 454g", 50 },
                    { 2, "8934567890002", 2, 10000m, "Nước ngọt Coca Cola lon 330ml", 120 },
                    { 3, "8934567890003", 3, 7500m, "Sữa tươi Vinamilk 180ml", 200 },
                    { 4, "8934567890004", 4, 4500m, "Mì Hảo Hảo tôm chua cay 75g", 300 },
                    { 5, "8934567890005", 5, 32000m, "Nước mắm Nam Ngư 500ml", 80 },
                    { 6, "8934567890006", 6, 145000m, "Gạo ST25 túi 5kg", 40 },
                    { 7, "8934567890007", 7, 28000m, "Cá hộp ba cô gái 155g", 60 },
                    { 8, "8934567890008", 8, 65000m, "Cà phê hòa tan Trung Nguyên 3in1", 70 },
                    { 9, "8934567890009", 9, 18000m, "Tương ớt Chinsu 250g", 90 },
                    { 10, "8934567890010", 10, 32000m, "Nước rửa chén Sunlight 750ml", 75 },
                    { 11, "8934567890011", 11, 115000m, "Dầu gội Clear 650g", 45 },
                    { 12, "8934567890012", 12, 28000m, "Khăn giấy Pulppy 3 lớp", 100 },
                    { 13, "8934567890013", 13, 5000m, "Bút bi Thiên Long TL-027", 150 },
                    { 14, "8934567890014", 14, 42000m, "Xúc xích CP gói 200g", 65 },
                    { 15, "8934567890015", 15, 68000m, "Bánh ăn dặm Gerber cho bé", 35 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 15);
        }
    }
}
