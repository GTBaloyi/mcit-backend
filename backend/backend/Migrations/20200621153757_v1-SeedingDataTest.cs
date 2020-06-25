using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class v1SeedingDataTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "user_status",
                columns: new[] { "id", "status" },
                values: new object[,]
                {
                    { 1, "Active" },
                    { 2, "InActive" },
                    { 3, "Suspended" },
                    { 4, "Deactivated" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "user_status",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "user_status",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "user_status",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "user_status",
                keyColumn: "id",
                keyValue: 4);
        }
    }
}
