using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class mctsdbv22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isSequential",
                table: "project");

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "project_todo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "project_todo");

            migrationBuilder.AddColumn<bool>(
                name: "isSequential",
                table: "project",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
