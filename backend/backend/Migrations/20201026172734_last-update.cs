using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class lastupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "q1_actual",
                table: "target_settings",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "q2_actual",
                table: "target_settings",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "q3_actual",
                table: "target_settings",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "q4_actual",
                table: "target_settings",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "sPGetAllProjects",
                columns: table => new
                {
                    project_id = table.Column<int>(nullable: false),
                    project_number = table.Column<string>(nullable: true),
                    project_name = table.Column<string>(nullable: true),
                    project_description = table.Column<string>(nullable: true),
                    invoice_reference = table.Column<string>(nullable: true),
                    company_registration = table.Column<string>(nullable: true),
                    project_createdOn = table.Column<DateTime>(nullable: false),
                    project_satisfaction = table.Column<double>(nullable: false),
                    project_leader = table.Column<string>(nullable: true),
                    pe_id = table.Column<int>(nullable: false),
                    pe_focusArea = table.Column<string>(nullable: true),
                    pe_item = table.Column<string>(nullable: true),
                    pe_actualCost = table.Column<double>(nullable: false),
                    pe_targetCost = table.Column<double>(nullable: false),
                    pg_id = table.Column<int>(nullable: false),
                    pg_targetStartDate = table.Column<DateTime>(nullable: false),
                    pg_targetDuration = table.Column<int>(nullable: false),
                    pg_actualStartDate = table.Column<DateTime>(nullable: false),
                    pg_actualEndDate = table.Column<DateTime>(nullable: false),
                    pg_projectStatus = table.Column<string>(nullable: true),
                    pg_projectStatusPercentage = table.Column<double>(nullable: false),
                    pg_StartQuarter = table.Column<string>(nullable: true),
                    pg_currentQuarter = table.Column<string>(nullable: true),
                    pg_targetEndQuarter = table.Column<string>(nullable: true),
                    pt_id = table.Column<int>(nullable: false),
                    pt_sequence = table.Column<int>(nullable: false),
                    pt_isSequential = table.Column<bool>(nullable: false),
                    pt_focusArea = table.Column<string>(nullable: true),
                    pt_item = table.Column<string>(nullable: true),
                    pt_dateStarted = table.Column<DateTime>(nullable: false),
                    pt_dateEnded = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sPGetAllProjects");

            migrationBuilder.DropColumn(
                name: "q1_actual",
                table: "target_settings");

            migrationBuilder.DropColumn(
                name: "q2_actual",
                table: "target_settings");

            migrationBuilder.DropColumn(
                name: "q3_actual",
                table: "target_settings");

            migrationBuilder.DropColumn(
                name: "q4_actual",
                table: "target_settings");
        }
    }
}
