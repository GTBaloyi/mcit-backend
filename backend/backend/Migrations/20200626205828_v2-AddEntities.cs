using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class v2AddEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "rate_per_hour",
                table: "support_equipment",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "time_study_per_test",
                table: "support_equipment",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "rate_per_hour",
                table: "physical_metallurgy_equipment",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "time_study_per_test",
                table: "physical_metallurgy_equipment",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "rate_per_hour",
                table: "moulding_tech_equipment",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "time_study_per_test",
                table: "moulding_tech_equipment",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "rate_per_hour",
                table: "foundry_tech_equipment",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "time_study_per_test",
                table: "foundry_tech_equipment",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "broader_mcts_rates",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    time_study_per_test = table.Column<double>(nullable: false),
                    rate_per_hour = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_broader_mcts_rates", x => x.id);
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
                table: "foundry_tech_equipment",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 550.0, 60.0 });

            migrationBuilder.UpdateData(
                table: "foundry_tech_equipment",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 550.0, 60.0 });

            migrationBuilder.UpdateData(
                table: "foundry_tech_equipment",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 550.0, 60.0 });

            migrationBuilder.UpdateData(
                table: "foundry_tech_equipment",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 937.5, 9600.0 });

            migrationBuilder.UpdateData(
                table: "foundry_tech_equipment",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 550.0, 60.0 });

            migrationBuilder.UpdateData(
                table: "foundry_tech_equipment",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 550.0, 60.0 });

            migrationBuilder.UpdateData(
                table: "foundry_tech_equipment",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 772.32000000000005, 60.0 });

            migrationBuilder.UpdateData(
                table: "moulding_tech_equipment",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 21.0, 120.0 });

            migrationBuilder.UpdateData(
                table: "moulding_tech_equipment",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 42.0, 240.0 });

            migrationBuilder.UpdateData(
                table: "moulding_tech_equipment",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 21.0, 120.0 });

            migrationBuilder.UpdateData(
                table: "moulding_tech_equipment",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 21.0, 120.0 });

            migrationBuilder.UpdateData(
                table: "moulding_tech_equipment",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 21.0, 120.0 });

            migrationBuilder.UpdateData(
                table: "moulding_tech_equipment",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 42.0, 240.0 });

            migrationBuilder.UpdateData(
                table: "moulding_tech_equipment",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 21.0, 120.0 });

            migrationBuilder.UpdateData(
                table: "moulding_tech_equipment",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 21.0, 120.0 });

            migrationBuilder.UpdateData(
                table: "moulding_tech_equipment",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 21.0, 120.0 });

            migrationBuilder.UpdateData(
                table: "moulding_tech_equipment",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 21.0, 120.0 });

            migrationBuilder.UpdateData(
                table: "moulding_tech_equipment",
                keyColumn: "id",
                keyValue: 11,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 42.0, 240.0 });

            migrationBuilder.UpdateData(
                table: "moulding_tech_equipment",
                keyColumn: "id",
                keyValue: 12,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 28.0, 160.0 });

            migrationBuilder.UpdateData(
                table: "moulding_tech_equipment",
                keyColumn: "id",
                keyValue: 13,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 18.0, 90.0 });

            migrationBuilder.UpdateData(
                table: "moulding_tech_equipment",
                keyColumn: "id",
                keyValue: 14,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 32.0, 180.0 });

            migrationBuilder.UpdateData(
                table: "moulding_tech_equipment",
                keyColumn: "id",
                keyValue: 15,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 28.0, 160.0 });

            migrationBuilder.UpdateData(
                table: "moulding_tech_equipment",
                keyColumn: "id",
                keyValue: 16,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 179.0, 120.0 });

            migrationBuilder.UpdateData(
                table: "moulding_tech_equipment",
                keyColumn: "id",
                keyValue: 17,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 179.0, 120.0 });

            migrationBuilder.UpdateData(
                table: "moulding_tech_equipment",
                keyColumn: "id",
                keyValue: 18,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 47.229999999999997, 120.0 });

            migrationBuilder.UpdateData(
                table: "moulding_tech_equipment",
                keyColumn: "id",
                keyValue: 19,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 27.629999999999999, 60.0 });

            migrationBuilder.UpdateData(
                table: "moulding_tech_equipment",
                keyColumn: "id",
                keyValue: 20,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 47.229999999999997, 120.0 });

            migrationBuilder.UpdateData(
                table: "moulding_tech_equipment",
                keyColumn: "id",
                keyValue: 21,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 47.229999999999997, 120.0 });

            migrationBuilder.UpdateData(
                table: "moulding_tech_equipment",
                keyColumn: "id",
                keyValue: 22,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 66.510000000000005, 180.0 });

            migrationBuilder.UpdateData(
                table: "moulding_tech_equipment",
                keyColumn: "id",
                keyValue: 23,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 66.510000000000005, 180.0 });

            migrationBuilder.UpdateData(
                table: "moulding_tech_equipment",
                keyColumn: "id",
                keyValue: 24,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 27.66, 60.0 });

            migrationBuilder.UpdateData(
                table: "moulding_tech_equipment",
                keyColumn: "id",
                keyValue: 25,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 14.779999999999999, 60.0 });

            migrationBuilder.UpdateData(
                table: "moulding_tech_equipment",
                keyColumn: "id",
                keyValue: 26,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 72.319999999999993, 480.0 });

            migrationBuilder.UpdateData(
                table: "moulding_tech_equipment",
                keyColumn: "id",
                keyValue: 27,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 41.840000000000003, 180.0 });

            migrationBuilder.UpdateData(
                table: "moulding_tech_equipment",
                keyColumn: "id",
                keyValue: 28,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 42.0, 20.0 });

            migrationBuilder.UpdateData(
                table: "moulding_tech_equipment",
                keyColumn: "id",
                keyValue: 29,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 400.0, 2270.0 });

            migrationBuilder.UpdateData(
                table: "moulding_tech_equipment",
                keyColumn: "id",
                keyValue: 30,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 400.0, 480.0 });

            migrationBuilder.UpdateData(
                table: "moulding_tech_equipment",
                keyColumn: "id",
                keyValue: 31,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 400.0, 1240.0 });

            migrationBuilder.UpdateData(
                table: "moulding_tech_equipment",
                keyColumn: "id",
                keyValue: 32,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 400.0, 1720.0 });

            migrationBuilder.UpdateData(
                table: "moulding_tech_equipment",
                keyColumn: "id",
                keyValue: 33,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 400.0, 260.0 });

            migrationBuilder.UpdateData(
                table: "moulding_tech_equipment",
                keyColumn: "id",
                keyValue: 34,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 400.0, 60.0 });

            migrationBuilder.UpdateData(
                table: "moulding_tech_equipment",
                keyColumn: "id",
                keyValue: 35,
                columns: new[] { "name", "rate_per_hour", "time_study_per_test" },
                values: new object[] { "Mould Coating", 400.0, 60.0 });

            migrationBuilder.UpdateData(
                table: "moulding_tech_equipment",
                keyColumn: "id",
                keyValue: 36,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 300.0, 60.0 });

            migrationBuilder.UpdateData(
                table: "moulding_tech_equipment",
                keyColumn: "id",
                keyValue: 37,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 21.0, 120.0 });

            migrationBuilder.UpdateData(
                table: "moulding_tech_equipment",
                keyColumn: "id",
                keyValue: 38,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 84.0, 180.0 });

            migrationBuilder.UpdateData(
                table: "moulding_tech_equipment",
                keyColumn: "id",
                keyValue: 39,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 600.0, 120.0 });

            migrationBuilder.InsertData(
                table: "moulding_tech_equipment",
                columns: new[] { "id", "name", "rate_per_hour", "time_study_per_test" },
                values: new object[] { 40, "Non Testing Act", 1233.6400000000001, 60.0 });

            migrationBuilder.UpdateData(
                table: "physical_metallurgy_equipment",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 75.0, 15.0 });

            migrationBuilder.UpdateData(
                table: "physical_metallurgy_equipment",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 75.0, 15.0 });

            migrationBuilder.UpdateData(
                table: "physical_metallurgy_equipment",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 75.0, 15.0 });

            migrationBuilder.UpdateData(
                table: "physical_metallurgy_equipment",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 75.0, 60.0 });

            migrationBuilder.UpdateData(
                table: "physical_metallurgy_equipment",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 490.0, 80.0 });

            migrationBuilder.UpdateData(
                table: "physical_metallurgy_equipment",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 450.0, 80.0 });

            migrationBuilder.UpdateData(
                table: "physical_metallurgy_equipment",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 118.75, 60.0 });

            migrationBuilder.UpdateData(
                table: "physical_metallurgy_equipment",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 118.75, 60.0 });

            migrationBuilder.UpdateData(
                table: "physical_metallurgy_equipment",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 118.75, 60.0 });

            migrationBuilder.UpdateData(
                table: "physical_metallurgy_equipment",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 400.0, 60.0 });

            migrationBuilder.UpdateData(
                table: "physical_metallurgy_equipment",
                keyColumn: "id",
                keyValue: 11,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 400.0, 80.0 });

            migrationBuilder.UpdateData(
                table: "physical_metallurgy_equipment",
                keyColumn: "id",
                keyValue: 12,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 200.0, 60.0 });

            migrationBuilder.UpdateData(
                table: "physical_metallurgy_equipment",
                keyColumn: "id",
                keyValue: 13,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 200.0, 80.0 });

            migrationBuilder.UpdateData(
                table: "physical_metallurgy_equipment",
                keyColumn: "id",
                keyValue: 14,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 500.0, 60.0 });

            migrationBuilder.UpdateData(
                table: "physical_metallurgy_equipment",
                keyColumn: "id",
                keyValue: 15,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 250.0, 60.0 });

            migrationBuilder.UpdateData(
                table: "physical_metallurgy_equipment",
                keyColumn: "id",
                keyValue: 16,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 250.0, 60.0 });

            migrationBuilder.UpdateData(
                table: "physical_metallurgy_equipment",
                keyColumn: "id",
                keyValue: 17,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 80.0, 30.0 });

            migrationBuilder.UpdateData(
                table: "physical_metallurgy_equipment",
                keyColumn: "id",
                keyValue: 18,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 500.0, 60.0 });

            migrationBuilder.UpdateData(
                table: "physical_metallurgy_equipment",
                keyColumn: "id",
                keyValue: 19,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 953.29999999999995, 60.0 });

            migrationBuilder.UpdateData(
                table: "support_equipment",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 250.0, 60.0 });

            migrationBuilder.UpdateData(
                table: "support_equipment",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 250.0, 60.0 });

            migrationBuilder.UpdateData(
                table: "support_equipment",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 250.0, 60.0 });

            migrationBuilder.UpdateData(
                table: "support_equipment",
                keyColumn: "id",
                keyValue: 4,
                column: "time_study_per_test",
                value: 60.0);

            migrationBuilder.UpdateData(
                table: "support_equipment",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 18.199999999999999, 1.0 });

            migrationBuilder.UpdateData(
                table: "support_equipment",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 20.0, 60.0 });

            migrationBuilder.UpdateData(
                table: "support_equipment",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 50.0, 60.0 });

            migrationBuilder.UpdateData(
                table: "support_equipment",
                keyColumn: "id",
                keyValue: 11,
                columns: new[] { "rate_per_hour", "time_study_per_test" },
                values: new object[] { 687.73000000000002, 60.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "broader_mcts_rates");

            migrationBuilder.DeleteData(
                table: "moulding_tech_equipment",
                keyColumn: "id",
                keyValue: 40);

            migrationBuilder.DropColumn(
                name: "rate_per_hour",
                table: "support_equipment");

            migrationBuilder.DropColumn(
                name: "time_study_per_test",
                table: "support_equipment");

            migrationBuilder.DropColumn(
                name: "rate_per_hour",
                table: "physical_metallurgy_equipment");

            migrationBuilder.DropColumn(
                name: "time_study_per_test",
                table: "physical_metallurgy_equipment");

            migrationBuilder.DropColumn(
                name: "rate_per_hour",
                table: "moulding_tech_equipment");

            migrationBuilder.DropColumn(
                name: "time_study_per_test",
                table: "moulding_tech_equipment");

            migrationBuilder.DropColumn(
                name: "rate_per_hour",
                table: "foundry_tech_equipment");

            migrationBuilder.DropColumn(
                name: "time_study_per_test",
                table: "foundry_tech_equipment");

            migrationBuilder.UpdateData(
                table: "moulding_tech_equipment",
                keyColumn: "id",
                keyValue: 35,
                column: "name",
                value: "Mould Coating ");
        }
    }
}
