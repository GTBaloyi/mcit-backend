using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class mctsdbupdatev17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "approvedBy",
                table: "quotation",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "generatedBy",
                table: "quotation",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "project",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    project_number = table.Column<string>(nullable: true),
                    project_name = table.Column<string>(nullable: true),
                    isSequential = table.Column<bool>(nullable: false),
                    project_description = table.Column<string>(nullable: true),
                    invoice_reference = table.Column<string>(nullable: true),
                    company_registration = table.Column<string>(nullable: true),
                    createdOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_project", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "project_expenditure",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    project_number = table.Column<string>(nullable: true),
                    focus_area = table.Column<string>(nullable: true),
                    item = table.Column<string>(nullable: true),
                    actual_cost = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_project_expenditure", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "project_progress",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    project_number = table.Column<string>(nullable: true),
                    target_start_date = table.Column<DateTime>(nullable: false),
                    target_duration = table.Column<DateTime>(nullable: false),
                    actual_start_date = table.Column<DateTime>(nullable: false),
                    actual_end_date = table.Column<DateTime>(nullable: false),
                    project_status = table.Column<string>(nullable: true),
                    project_status_percentage = table.Column<double>(nullable: false),
                    start_quarter = table.Column<string>(nullable: true),
                    current_quarter = table.Column<string>(nullable: true),
                    target_end_quarter = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_project_progress", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "project_todo",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    project_number = table.Column<string>(nullable: true),
                    sequence = table.Column<int>(nullable: false),
                    isSequential = table.Column<bool>(nullable: false),
                    focus_area = table.Column<string>(nullable: true),
                    item = table.Column<string>(nullable: true),
                    date_started = table.Column<DateTime>(nullable: false),
                    date_ended = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_project_todo", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "project");

            migrationBuilder.DropTable(
                name: "project_expenditure");

            migrationBuilder.DropTable(
                name: "project_progress");

            migrationBuilder.DropTable(
                name: "project_todo");

            migrationBuilder.DropColumn(
                name: "approvedBy",
                table: "quotation");

            migrationBuilder.DropColumn(
                name: "generatedBy",
                table: "quotation");
        }
    }
}
