using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class mctsdbupdatev13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "quantity",
                table: "invoice");

            migrationBuilder.DropColumn(
                name: "total_due",
                table: "invoice");

            migrationBuilder.DropColumn(
                name: "vat_number",
                table: "invoice");

            migrationBuilder.AddColumn<double>(
                name: "discount",
                table: "invoice",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "grand_total",
                table: "invoice",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "vat_percentage",
                table: "invoice",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "discount",
                table: "invoice");

            migrationBuilder.DropColumn(
                name: "grand_total",
                table: "invoice");

            migrationBuilder.DropColumn(
                name: "vat_percentage",
                table: "invoice");

            migrationBuilder.AddColumn<int>(
                name: "quantity",
                table: "invoice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "total_due",
                table: "invoice",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "vat_number",
                table: "invoice",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
