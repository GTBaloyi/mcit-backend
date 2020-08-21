using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class mctsdbupdatev16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "quotation",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "reason",
                table: "quotation",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "quotation");

            migrationBuilder.DropColumn(
                name: "reason",
                table: "quotation");
        }
    }
}
