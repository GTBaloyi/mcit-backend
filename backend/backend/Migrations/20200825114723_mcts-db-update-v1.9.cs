using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class mctsdbupdatev19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "assigned_employees",
                table: "project",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "assigned_employees",
                table: "project");
        }
    }
}
