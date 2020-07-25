using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class ProductsRedesignv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "foundry_tech_equipment");

            migrationBuilder.DropTable(
                name: "moulding_tech_equipment");

            migrationBuilder.DropTable(
                name: "physical_metallurgy_equipment");

            migrationBuilder.DropTable(
                name: "support_equipment");

            migrationBuilder.DeleteData(
                table: "broader_mcts_rates",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "broader_mcts_rates",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "broader_mcts_rates",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "broader_mcts_rates",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "broader_mcts_rates",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "broader_mcts_rates",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "broader_mcts_rates",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "broader_mcts_rates",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    time_study_per_test = table.Column<double>(nullable: false),
                    rate_per_hour = table.Column<double>(nullable: false),
                    focus_area_fk = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "quotation",
                columns: table => new
                {
                    Quote_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Quote_reference = table.Column<int>(nullable: false),
                    Date_generated = table.Column<DateTime>(nullable: false),
                    Quote_expiryDate = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Company_name = table.Column<string>(nullable: true),
                    Bill_address = table.Column<string>(nullable: true),
                    Phone_Number = table.Column<string>(nullable: true),
                    Grand_total = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quotation", x => x.Quote_id);
                });

            migrationBuilder.CreateTable(
                name: "terms_and_conditions",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_terms_and_conditions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "quotation_item",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FocusArea = table.Column<string>(nullable: true),
                    Item = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Unit_Price = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Total = table.Column<double>(nullable: false),
                    QuotationEntityQuote_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quotation_item", x => x.id);
                    table.ForeignKey(
                        name: "FK_quotation_item_quotation_QuotationEntityQuote_id",
                        column: x => x.QuotationEntityQuote_id,
                        principalTable: "quotation",
                        principalColumn: "Quote_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "focus_area",
                keyColumn: "id",
                keyValue: 4,
                column: "name",
                value: "SupportEquipment");

            migrationBuilder.UpdateData(
                table: "focus_area",
                keyColumn: "id",
                keyValue: 5,
                column: "name",
                value: "Support");

            migrationBuilder.InsertData(
                table: "focus_area",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 6, "Other" },
                    { 7, "BroaderMCTSRates" }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "id", "focus_area_fk", "name", "rate_per_hour", "time_study_per_test" },
                values: new object[,]
                {
                    { 63, 2, "TGA Analysis", 21.0, 120.0 },
                    { 62, 2, "Oolitization", 300.0, 60.0 },
                    { 61, 2, "Mould Coating", 400.0, 60.0 },
                    { 60, 2, "Calibration", 400.0, 60.0 },
                    { 59, 2, "Core Making", 400.0, 260.0 },
                    { 58, 2, "Full Ref San Anal", 400.0, 1720.0 },
                    { 57, 2, "Full Bentonite Anal", 400.0, 1240.0 },
                    { 56, 2, "Full Resin Sand Aval", 400.0, 480.0 },
                    { 64, 2, "Sample Preparation", 84.0, 180.0 },
                    { 55, 2, "Full Green Sand Anal", 400.0, 2270.0 },
                    { 53, 2, "ADV", 41.840000000000003, 180.0 },
                    { 52, 2, "Sintering", 72.319999999999993, 480.0 },
                    { 51, 2, "Grain Sha", 14.779999999999999, 60.0 },
                    { 50, 2, "Sieve Ana", 27.66, 60.0 },
                    { 49, 2, "XRD Sand", 66.510000000000005, 180.0 },
                    { 48, 2, "XRF", 66.510000000000005, 180.0 },
                    { 47, 2, "PH", 47.229999999999997, 120.0 },
                    { 46, 2, "CEC", 47.229999999999997, 120.0 },
                    { 54, 2, "Core Preparation", 42.0, 20.0 },
                    { 2, 3, "MDX", 550.0, 60.0 },
                    { 65, 2, "Total Gas Evolution", 600.0, 120.0 },
                    { 67, 1, "Macr Vick", 75.0, 15.0 },
                    { 85, 1, "Non Testing Act (Phys)", 953.29999999999995, 60.0 },
                    { 84, 1, "XRF", 500.0, 60.0 },
                    { 83, 1, "Stereo", 80.0, 30.0 },
                    { 82, 1, "Mill&M", 250.0, 60.0 },
                    { 81, 1, "SEM", 250.0, 60.0 },
                    { 80, 1, "XRD", 500.0, 60.0 },
                    { 79, 1, "Lecco", 200.0, 80.0 },
                    { 78, 1, "Spectro", 200.0, 60.0 },
                    { 66, 2, "Non Testing Act", 1233.6400000000001, 60.0 },
                    { 77, 1, "Metallog", 400.0, 80.0 },
                    { 75, 1, "AI Furn", 118.75, 60.0 },
                    { 74, 1, "HT Fur Big", 118.75, 60.0 },
                    { 73, 1, "HT Fur 1", 118.75, 60.0 },
                    { 72, 1, "Tensile", 450.0, 80.0 },
                    { 71, 1, "Charpy", 490.0, 80.0 },
                    { 70, 1, "Brinell", 75.0, 60.0 },
                    { 69, 1, "Rockewell", 75.0, 15.0 },
                    { 68, 1, "Micr Vick", 75.0, 15.0 },
                    { 76, 1, "Ind Furn", 400.0, 60.0 },
                    { 45, 2, "Visco", 27.629999999999999, 60.0 },
                    { 44, 2, "Swe Ind", 47.229999999999997, 120.0 },
                    { 42, 2, "Tensile", 179.0, 120.0 },
                    { 19, 7, "Testing & Analysis", 224.38, 0.0 },
                    { 18, 4, "Non Testing Act (Sup)", 687.73000000000002, 60.0 },
                    { 17, 4, "Design Software", 50.0, 60.0 },
                    { 16, 4, "Lazer Cutter", 20.0, 60.0 },
                    { 15, 4, "SLP / Tail Dem4", 0.0, 0.0 },
                    { 14, 4, "SLP / Tail Dem3", 0.0, 0.0 },
                    { 13, 4, "SLP / Tail Dem2", 0.0, 0.0 },
                    { 12, 4, "SLP / Tail Dem1", 18.199999999999999, 1.0 },
                    { 11, 4, "Host Interns", 0.0, 60.0 },
                    { 10, 4, "Valcanizer", 250.0, 60.0 },
                    { 9, 4, "Ind Coil Furn", 250.0, 60.0 },
                    { 8, 4, "Spin Cast", 250.0, 60.0 },
                    { 7, 3, "Non Testing Act(Ftec)", 772.32000000000005, 60.0 },
                    { 6, 3, "Click To Cast", 550.0, 60.0 },
                    { 5, 3, "3DP", 550.0, 60.0 },
                    { 4, 3, "ALIA", 937.5, 9600.0 },
                    { 3, 3, "AutoD", 550.0, 60.0 },
                    { 20, 7, "Prototyping & Manufacturing", 800.0, 0.0 },
                    { 21, 7, "Consult / Technology Audit", 500.0, 0.0 },
                    { 22, 7, "Product and Process Development", 800.0, 0.0 },
                    { 23, 7, "Research and Development", 800.0, 0.0 },
                    { 41, 2, "LOl", 28.0, 160.0 },
                    { 40, 2, "Clay Wash", 32.0, 180.0 },
                    { 39, 2, "Activ C", 18.0, 90.0 },
                    { 38, 2, "Voliti", 28.0, 160.0 },
                    { 37, 2, "Moisture", 42.0, 240.0 },
                    { 36, 2, "Compress", 21.0, 120.0 },
                    { 35, 2, "Compact", 21.0, 120.0 },
                    { 34, 2, "Wet Ten", 21.0, 120.0 },
                    { 1, 3, "ProE", 550.0, 60.0 },
                    { 33, 2, "Shatter In", 21.0, 120.0 },
                    { 31, 2, "Green Shea", 21.0, 120.0 },
                    { 30, 2, "Permeab", 21.0, 120.0 },
                    { 29, 2, "Friability", 21.0, 120.0 },
                    { 28, 2, "Dry Stren", 42.0, 240.0 },
                    { 27, 2, "Green Stren", 21.0, 120.0 },
                    { 26, 7, "Investigative Projects (Failure / Defect)", 0.0, 0.0 },
                    { 25, 7, "Knowledge Transfer / SLP", 250.0, 0.0 },
                    { 24, 7, "Technology Demonstration / Transfer", 800.0, 0.0 },
                    { 32, 2, "Dry Shea", 42.0, 240.0 },
                    { 43, 2, "Transv Stre", 179.0, 120.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_quotation_item_QuotationEntityQuote_id",
                table: "quotation_item",
                column: "QuotationEntityQuote_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "quotation_item");

            migrationBuilder.DropTable(
                name: "terms_and_conditions");

            migrationBuilder.DropTable(
                name: "quotation");

            migrationBuilder.DeleteData(
                table: "focus_area",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "focus_area",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.CreateTable(
                name: "foundry_tech_equipment",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    rate_per_hour = table.Column<double>(type: "double", nullable: false),
                    time_study_per_test = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_foundry_tech_equipment", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "moulding_tech_equipment",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    rate_per_hour = table.Column<double>(type: "double", nullable: false),
                    time_study_per_test = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_moulding_tech_equipment", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "physical_metallurgy_equipment",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    rate_per_hour = table.Column<double>(type: "double", nullable: false),
                    time_study_per_test = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_physical_metallurgy_equipment", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "support_equipment",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    rate_per_hour = table.Column<double>(type: "double", nullable: false),
                    time_study_per_test = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_support_equipment", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "broader_mcts_rates",
                columns: new[] { "id", "name", "rate_per_hour", "time_study_per_test" },
                values: new object[,]
                {
                    { 1, "Testing & Analysis", 224.38, 0.0 },
                    { 2, "Prototyping & Manufacturing", 800.0, 0.0 },
                    { 3, "Consult / Technology Audit", 500.0, 0.0 },
                    { 4, "Product and Process Development", 800.0, 0.0 },
                    { 5, "Research and Development", 800.0, 0.0 },
                    { 6, "Technology Demonstration / Transfer", 800.0, 0.0 },
                    { 7, "Knowledge Transfer / SLP", 250.0, 0.0 },
                    { 8, "Investigative Projects (Failure / Defect)", 0.0, 0.0 }
                });

            migrationBuilder.UpdateData(
                table: "focus_area",
                keyColumn: "id",
                keyValue: 4,
                column: "name",
                value: "Support");

            migrationBuilder.UpdateData(
                table: "focus_area",
                keyColumn: "id",
                keyValue: 5,
                column: "name",
                value: "Other");

            migrationBuilder.InsertData(
                table: "foundry_tech_equipment",
                columns: new[] { "id", "name", "rate_per_hour", "time_study_per_test" },
                values: new object[,]
                {
                    { 3, "AutoD", 550.0, 60.0 },
                    { 4, "ALIA", 937.5, 9600.0 },
                    { 5, "3DP", 550.0, 60.0 },
                    { 6, "Click To Cast", 550.0, 60.0 },
                    { 7, "Non Testing Act(Ftec)", 772.32000000000005, 60.0 },
                    { 2, "MDX", 550.0, 60.0 },
                    { 1, "ProE", 550.0, 60.0 }
                });

            migrationBuilder.InsertData(
                table: "moulding_tech_equipment",
                columns: new[] { "id", "name", "rate_per_hour", "time_study_per_test" },
                values: new object[,]
                {
                    { 23, "XRD Sand", 66.510000000000005, 180.0 },
                    { 24, "Sieve Ana", 27.66, 60.0 },
                    { 25, "Grain Sha", 14.779999999999999, 60.0 },
                    { 26, "Sintering", 72.319999999999993, 480.0 },
                    { 27, "ADV", 41.840000000000003, 180.0 },
                    { 28, "Core Preparation", 42.0, 20.0 },
                    { 30, "Full Resin Sand Aval", 400.0, 480.0 },
                    { 33, "Core Making", 400.0, 260.0 },
                    { 32, "Full Ref San Anal", 400.0, 1720.0 },
                    { 22, "XRF", 66.510000000000005, 180.0 },
                    { 35, "Mould Coating", 400.0, 60.0 },
                    { 36, "Oolitization", 300.0, 60.0 },
                    { 37, "TGA Analysis", 21.0, 120.0 },
                    { 38, "Sample Preparation", 84.0, 180.0 },
                    { 39, "Total Gas Evolution", 600.0, 120.0 },
                    { 40, "Non Testing Act", 1233.6400000000001, 60.0 },
                    { 31, "Full Bentonite Anal", 400.0, 1240.0 },
                    { 21, "PH", 47.229999999999997, 120.0 },
                    { 34, "Calibration", 400.0, 60.0 },
                    { 19, "Visco", 27.629999999999999, 60.0 },
                    { 20, "CEC", 47.229999999999997, 120.0 },
                    { 1, "Green Stren", 21.0, 120.0 },
                    { 2, "Dry Stren", 42.0, 240.0 },
                    { 3, "Friability", 21.0, 120.0 },
                    { 4, "Permeab", 21.0, 120.0 },
                    { 5, "Green Shea", 21.0, 120.0 },
                    { 6, "Dry Shea", 42.0, 240.0 },
                    { 7, "Shatter In", 21.0, 120.0 },
                    { 8, "Wet Ten", 21.0, 120.0 },
                    { 29, "Full Green Sand Anal", 400.0, 2270.0 },
                    { 10, "Compress", 21.0, 120.0 },
                    { 11, "Moisture", 42.0, 240.0 },
                    { 12, "Voliti", 28.0, 160.0 },
                    { 13, "Activ C", 18.0, 90.0 },
                    { 14, "Clay Wash", 32.0, 180.0 },
                    { 15, "LOl", 28.0, 160.0 },
                    { 16, "Tensile", 179.0, 120.0 },
                    { 17, "Transv Stre", 179.0, 120.0 },
                    { 9, "Compact", 21.0, 120.0 },
                    { 18, "Swe Ind", 47.229999999999997, 120.0 }
                });

            migrationBuilder.InsertData(
                table: "physical_metallurgy_equipment",
                columns: new[] { "id", "name", "rate_per_hour", "time_study_per_test" },
                values: new object[,]
                {
                    { 13, "Lecco", 200.0, 80.0 },
                    { 14, "XRD", 500.0, 60.0 },
                    { 19, "Non Testing Act (Phys)", 953.29999999999995, 60.0 },
                    { 16, "Mill&M", 250.0, 60.0 },
                    { 17, "Stereo", 80.0, 30.0 },
                    { 18, "XRF", 500.0, 60.0 },
                    { 15, "SEM", 250.0, 60.0 },
                    { 11, "Metallog", 400.0, 80.0 },
                    { 12, "Spectro", 200.0, 60.0 },
                    { 9, "AI Furn", 118.75, 60.0 },
                    { 10, "Ind Furn", 400.0, 60.0 },
                    { 1, "Macr Vick", 75.0, 15.0 },
                    { 2, "Micr Vick", 75.0, 15.0 },
                    { 3, "Rockewell", 75.0, 15.0 },
                    { 7, "HT Fur 1", 118.75, 60.0 },
                    { 5, "Charpy", 490.0, 80.0 },
                    { 6, "Tensile", 450.0, 80.0 },
                    { 8, "HT Fur Big", 118.75, 60.0 },
                    { 4, "Brinell", 75.0, 60.0 }
                });

            migrationBuilder.InsertData(
                table: "support_equipment",
                columns: new[] { "id", "name", "rate_per_hour", "time_study_per_test" },
                values: new object[,]
                {
                    { 1, "Spin Cast", 250.0, 60.0 },
                    { 2, "Ind Coil Furn", 250.0, 60.0 },
                    { 4, "Host Interns", 0.0, 60.0 },
                    { 5, "SLP / Tail Dem1", 18.199999999999999, 1.0 },
                    { 6, "SLP / Tail Dem2", 0.0, 0.0 },
                    { 7, "SLP / Tail Dem3", 0.0, 0.0 },
                    { 8, "SLP / Tail Dem4", 0.0, 0.0 },
                    { 9, "Lazer Cutter", 20.0, 60.0 },
                    { 10, "Design Software", 50.0, 60.0 },
                    { 11, "Non Testing Act (Sup)", 687.73000000000002, 60.0 },
                    { 3, "Valcanizer", 250.0, 60.0 }
                });
        }
    }
}
