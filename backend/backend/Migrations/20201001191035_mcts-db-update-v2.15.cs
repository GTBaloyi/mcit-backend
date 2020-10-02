using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class mctsdbupdatev215 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Quote_reference",
                table: "quotation",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "quarter",
                table: "quarter",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "responsible_employees",
                table: "project_todo",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "project_number",
                table: "project_progress",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "reference",
                table: "invoice",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "quotation_reference",
                table: "invoice",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "employee_number",
                table: "employees",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "employees",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "company_representative",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "registration_number",
                table: "Company",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_quotation_Quote_reference",
                table: "quotation",
                column: "Quote_reference",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_quarter_quarter",
                table: "quarter",
                column: "quarter",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_project_progress_project_number",
                table: "project_progress",
                column: "project_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_invoice_quotation_reference",
                table: "invoice",
                column: "quotation_reference",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_invoice_reference",
                table: "invoice",
                column: "reference",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_employees_email",
                table: "employees",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_employees_employee_number",
                table: "employees",
                column: "employee_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_company_representative_email",
                table: "company_representative",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Company_registration_number",
                table: "Company",
                column: "registration_number",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_quotation_Quote_reference",
                table: "quotation");

            migrationBuilder.DropIndex(
                name: "IX_quarter_quarter",
                table: "quarter");

            migrationBuilder.DropIndex(
                name: "IX_project_progress_project_number",
                table: "project_progress");

            migrationBuilder.DropIndex(
                name: "IX_invoice_quotation_reference",
                table: "invoice");

            migrationBuilder.DropIndex(
                name: "IX_invoice_reference",
                table: "invoice");

            migrationBuilder.DropIndex(
                name: "IX_employees_email",
                table: "employees");

            migrationBuilder.DropIndex(
                name: "IX_employees_employee_number",
                table: "employees");

            migrationBuilder.DropIndex(
                name: "IX_company_representative_email",
                table: "company_representative");

            migrationBuilder.DropIndex(
                name: "IX_Company_registration_number",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "responsible_employees",
                table: "project_todo");

            migrationBuilder.AlterColumn<string>(
                name: "Quote_reference",
                table: "quotation",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "quarter",
                table: "quarter",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "project_number",
                table: "project_progress",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "reference",
                table: "invoice",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "quotation_reference",
                table: "invoice",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "employee_number",
                table: "employees",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "employees",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "company_representative",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "registration_number",
                table: "Company",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
