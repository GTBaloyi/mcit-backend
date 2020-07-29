using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class Mcitv2db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    employee_number = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    surname = table.Column<string>(nullable: true),
                    position_fk = table.Column<int>(nullable: false),
                    email = table.Column<string>(nullable: true),
                    cell = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    created_on = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "employees_position",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    position = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees_position", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "employees_position",
                columns: new[] { "id", "position" },
                values: new object[] { 1, "Administrator" });

            migrationBuilder.InsertData(
                table: "employees_position",
                columns: new[] { "id", "position" },
                values: new object[] { 2, "General Staff" });

            migrationBuilder.InsertData(
                table: "employees_position",
                columns: new[] { "id", "position" },
                values: new object[] { 3, "Manager" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "employees_position");
        }
    }
}
