using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class fixtofinalDB1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "category",
                table: "target_settings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "category",
                table: "target_settings");
        }
    }
}
