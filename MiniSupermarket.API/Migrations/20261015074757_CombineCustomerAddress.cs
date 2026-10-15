using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniSupermarket.API.Migrations
{
    /// <inheritdoc />
    public partial class CombineCustomerAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "District",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Ward",
                table: "Customers");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "Address",
                value: "Số 25, đường Nguyễn Huệ, Phường 1, Thành phố Cao Lãnh, Đồng Tháp");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                column: "Address",
                value: "Số 50, đường Lê Lợi, Phường 2, Thành phố Cao Lãnh, Đồng Tháp");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3,
                column: "Address",
                value: "Số 10, đường Nguyễn Trãi, Phường 1, Thành phố Cao Lãnh, Đồng Tháp");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 4,
                column: "Address",
                value: "Số 88, đường Lý Thường Kiệt, Phường 3, Thành phố Cao Lãnh, Đồng Tháp");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 5,
                column: "Address",
                value: "Số 15, đường Hùng Vương, Phường 2, Thành phố Sa Đéc, Đồng Tháp");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 6,
                column: "Address",
                value: "Số 102, đường Trần Hưng Đạo, Phường 1, Thành phố Sa Đéc, Đồng Tháp");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 7,
                column: "Address",
                value: "Số 42, đường Điện Biên Phủ, Phường Mỹ Phú, Thành phố Cao Lãnh, Đồng Tháp");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 8,
                columns: new[] { "Address", "CustomerName" },
                values: new object[] { "Số 79, đường Nguyễn Sinh Cung, Phường 2, Thành phố Sa Đéc, Đồng Tháp", "Ngô Thanh Tùng" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 9,
                column: "Address",
                value: "Số 14, đường Võ Trường Toản, Phường 4, Thành phố Cao Lãnh, Đồng Tháp");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 10,
                column: "Address",
                value: "Số 63, đường Phạm Hữu Lầu, Phường 6, Thành phố Cao Lãnh, Đồng Tháp");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 11,
                column: "Address",
                value: "Số 05, đường Nguyễn Huệ, Phường An Thạnh, Thành phố Hồng Ngự, Đồng Tháp");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 12,
                column: "Address",
                value: "Số 118, đường Quốc Lộ 30, Phường Mỹ Trà, Thành phố Cao Lãnh, Đồng Tháp");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 13,
                column: "Address",
                value: "Số 200, đường Lê Đại Hành, Phường Mỹ Phú, Thành phố Cao Lãnh, Đồng Tháp");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Ward",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                columns: new[] { "Address", "District", "Province", "Ward" },
                values: new object[] { "Số 25, đường Nguyễn Huệ", "Thành phố Cao Lãnh", "Đồng Tháp", "Phường 1" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                columns: new[] { "Address", "District", "Province", "Ward" },
                values: new object[] { "Số 50, đường Lê Lợi", "Thành phố Cao Lãnh", "Đồng Tháp", "Phường 2" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3,
                columns: new[] { "Address", "District", "Province", "Ward" },
                values: new object[] { "Số 10, đường Nguyễn Trãi", "Thành phố Cao Lãnh", "Đồng Tháp", "Phường 1" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 4,
                columns: new[] { "Address", "District", "Province", "Ward" },
                values: new object[] { "Số 88, đường Lý Thường Kiệt", "Thành phố Cao Lãnh", "Đồng Tháp", "Phường 3" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 5,
                columns: new[] { "Address", "District", "Province", "Ward" },
                values: new object[] { "Số 15, đường Hùng Vương", "Thành phố Sa Đéc", "Đồng Tháp", "Phường 2" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 6,
                columns: new[] { "Address", "District", "Province", "Ward" },
                values: new object[] { "Số 102, đường Trần Hưng Đạo", "Thành phố Sa Đéc", "Đồng Tháp", "Phường 1" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 7,
                columns: new[] { "Address", "District", "Province", "Ward" },
                values: new object[] { "Số 42, đường Điện Biên Phủ", "Thành phố Cao Lãnh", "Đồng Tháp", "Phường Mỹ Phú" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 8,
                columns: new[] { "Address", "CustomerName", "District", "Province", "Ward" },
                values: new object[] { "Số 79, đường Nguyễn Sinh Cung", "Ngo Thanh Tung", "Thành phố Sa Đéc", "Đồng Tháp", "Phường 2" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 9,
                columns: new[] { "Address", "District", "Province", "Ward" },
                values: new object[] { "Số 14, đường Võ Trường Toản", "Thành phố Cao Lãnh", "Đồng Tháp", "Phường 4" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 10,
                columns: new[] { "Address", "District", "Province", "Ward" },
                values: new object[] { "Số 63, đường Phạm Hữu Lầu", "Thành phố Cao Lãnh", "Đồng Tháp", "Phường 6" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 11,
                columns: new[] { "Address", "District", "Province", "Ward" },
                values: new object[] { "Số 05, đường Nguyễn Huệ", "Thành phố Hồng Ngự", "Đồng Tháp", "Phường An Thạnh" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 12,
                columns: new[] { "Address", "District", "Province", "Ward" },
                values: new object[] { "Số 118, đường Quốc Lộ 30", "Thành phố Cao Lãnh", "Đồng Tháp", "Phường Mỹ Trà" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 13,
                columns: new[] { "Address", "District", "Province", "Ward" },
                values: new object[] { "Số 200, đường Lê Đại Hành", "Thành phố Cao Lãnh", "Đồng Tháp", "Phường Mỹ Phú" });
        }
    }
}
