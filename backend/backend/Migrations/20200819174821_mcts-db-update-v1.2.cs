using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class mctsdbupdatev12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "quotation_item");

            migrationBuilder.AddColumn<double>(
                name: "numberOfTests",
                table: "quotation_item",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "numberOfTests",
                table: "quotation_item");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "quotation_item",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
