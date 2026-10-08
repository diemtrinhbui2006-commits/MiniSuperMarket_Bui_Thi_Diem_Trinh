using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniSupermarket.API.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "CustomerName", "District", "MembershipRank", "PhoneNumber", "Province", "RewardPoints", "Ward" },
                values: new object[,]
                {
                    { 4, "Số 88, đường Lý Thường Kiệt", "Phạm Hoàng Nam", "Thành phố Cao Lãnh", "Kim Cương", "0939112233", "Đồng Tháp", 680, "Phường 3" },
                    { 5, "Số 15, đường Hùng Vương", "Đặng Thu Thảo", "Thành phố Sa Đéc", "Vàng", "0945223344", "Đồng Tháp", 310, "Phường 2" },
                    { 6, "Số 102, đường Trần Hưng Đạo", "Võ Văn Tuấn", "Thành phố Sa Đéc", "Bạc", "0978334455", "Đồng Tháp", 150, "Phường 1" },
                    { 7, "Số 42, đường Điện Biên Phủ", "Bùi Thị Mai", "Thành phố Cao Lãnh", "Chuẩn", "0918445566", "Đồng Tháp", 50, "Phường Mỹ Phú" },
                    { 8, "Số 79, đường Nguyễn Sinh Cung", "Ngo Thanh Tung", "Thành phố Sa Đéc", "Vàng", "0927556677", "Đồng Tháp", 290, "Phường 2" },
                    { 9, "Số 14, đường Võ Trường Toản", "Dương Quốc Bảo", "Thành phố Cao Lãnh", "Bạc", "0966667788", "Đồng Tháp", 180, "Phường 4" },
                    { 10, "Số 63, đường Phạm Hữu Lầu", "Hoàng Kim Ngân", "Thành phố Cao Lãnh", "Chuẩn", "0908778899", "Đồng Tháp", 15, "Phường 6" },
                    { 11, "Số 05, đường Nguyễn Huệ", "Đỗ Duy Khoa", "Thành phố Hồng Ngự", "Bạc", "0931889900", "Đồng Tháp", 95, "Phường An Thạnh" },
                    { 12, "Số 118, đường Quốc Lộ 30", "Trịnh Tuyết Mai", "Thành phố Cao Lãnh", "Kim Cương", "0949990011", "Đồng Tháp", 820, "Phường Mỹ Trà" },
                    { 13, "Số 200, đường Lê Đại Hành", "Lý Văn Đức", "Thành phố Cao Lãnh", "Chuẩn", "0981001122", "Đồng Tháp", 40, "Phường Mỹ Phú" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 13);
        }
    }
}
