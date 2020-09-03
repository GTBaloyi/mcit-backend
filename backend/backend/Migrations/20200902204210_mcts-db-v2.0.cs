using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class mctsdbv20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "target_duration",
                table: "project_progress",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AddColumn<double>(
                name: "target_cost",
                table: "project_expenditure",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "target_cost",
                table: "project_expenditure");

            migrationBuilder.AlterColumn<DateTime>(
                name: "target_duration",
                table: "project_progress",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
