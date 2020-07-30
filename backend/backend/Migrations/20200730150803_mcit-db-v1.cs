using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class mcitdbv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_quotation_item_quotation_QuotationEntityQuote_id",
                table: "quotation_item");

            migrationBuilder.DropIndex(
                name: "IX_quotation_item_QuotationEntityQuote_id",
                table: "quotation_item");

            migrationBuilder.DropColumn(
                name: "QuotationEntityQuote_id",
                table: "quotation_item");

            migrationBuilder.AddColumn<int>(
                name: "quote_fk",
                table: "quotation_item",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Quote_reference",
                table: "quotation",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "quote_fk",
                table: "quotation_item");

            migrationBuilder.AddColumn<int>(
                name: "QuotationEntityQuote_id",
                table: "quotation_item",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Quote_reference",
                table: "quotation",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_quotation_item_QuotationEntityQuote_id",
                table: "quotation_item",
                column: "QuotationEntityQuote_id");

            migrationBuilder.AddForeignKey(
                name: "FK_quotation_item_quotation_QuotationEntityQuote_id",
                table: "quotation_item",
                column: "QuotationEntityQuote_id",
                principalTable: "quotation",
                principalColumn: "Quote_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
