using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "access_levels",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    level = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_access_levels", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    registration_number = table.Column<string>(nullable: true),
                    company_profile = table.Column<string>(nullable: true),
                    isCompanyPresent = table.Column<bool>(nullable: false),
                    quarter = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "company_representative",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    surname = table.Column<string>(nullable: true),
                    gender = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    company_fk = table.Column<int>(nullable: false),
                    date_captured = table.Column<DateTime>(nullable: false),
                    avatar_path = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company_representative", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "email_templates",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    code = table.Column<string>(nullable: true),
                    email_type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_email_templates", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "enquiry",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    focus_area_fk = table.Column<int>(nullable: false),
                    enquiry_date = table.Column<DateTime>(nullable: false),
                    quarter = table.Column<string>(nullable: true),
                    company = table.Column<string>(nullable: true),
                    company_registration_number = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    service_tech_fk = table.Column<int>(nullable: false),
                    socio_economic_impact_fk = table.Column<int>(nullable: false),
                    product_expectation_fk = table.Column<int>(nullable: false),
                    project_budget = table.Column<double>(nullable: false),
                    expected_completion = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enquiry", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_status",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    username = table.Column<string>(nullable: false),
                    password = table.Column<string>(nullable: true),
                    retry = table.Column<int>(nullable: false),
                    user_status_fk = table.Column<int>(nullable: false),
                    access_fk = table.Column<int>(nullable: false),
                    company_rep_fk = table.Column<int>(nullable: false),
                    last_login = table.Column<DateTime>(nullable: false),
                    otp = table.Column<string>(nullable: true),
                    location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.username);
                });

            migrationBuilder.CreateTable(
                name: "invoice",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    reference = table.Column<string>(nullable: true),
                    invoice_date = table.Column<DateTime>(nullable: false),
                    date_due = table.Column<DateTime>(nullable: false),
                    title = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    vat_number = table.Column<string>(nullable: true),
                    bill_to_id = table.Column<int>(nullable: false),
                    Vat = table.Column<string>(nullable: true),
                    terms = table.Column<string>(nullable: true),
                    total = table.Column<double>(nullable: false),
                    subtotal = table.Column<double>(nullable: false),
                    quantity = table.Column<int>(nullable: false),
                    total_due = table.Column<double>(nullable: false),
                    user_id = table.Column<int>(nullable: false),
                    usersusername = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoice", x => x.id);
                    table.ForeignKey(
                        name: "FK_invoice_users_usersusername",
                        column: x => x.usersusername,
                        principalTable: "users",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_invoice_usersusername",
                table: "invoice",
                column: "usersusername");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "access_levels");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "company_representative");

            migrationBuilder.DropTable(
                name: "email_templates");

            migrationBuilder.DropTable(
                name: "enquiry");

            migrationBuilder.DropTable(
                name: "invoice");

            migrationBuilder.DropTable(
                name: "user_status");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
