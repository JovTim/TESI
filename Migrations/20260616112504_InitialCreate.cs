using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesiAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ref_apartment_types",
                columns: table => new
                {
                    apartment_type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    apartment_type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ref_apartment_types", x => x.apartment_type_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "apartments",
                columns: table => new
                {
                    apartment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    apartment_type_id = table.Column<int>(type: "int", nullable: false),
                    seller_id = table.Column<int>(type: "int", nullable: false),
                    apartment_no = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    bathroom_count = table.Column<int>(type: "int", nullable: false),
                    bedroom_count = table.Column<int>(type: "int", nullable: false),
                    apartment_size = table.Column<int>(type: "int", nullable: false),
                    rent_price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    apartment_details = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_apartments", x => x.apartment_id);
                    table.ForeignKey(
                        name: "FK_apartments_ref_apartment_types_apartment_type_id",
                        column: x => x.apartment_type_id,
                        principalTable: "ref_apartment_types",
                        principalColumn: "apartment_type_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_apartments_apartment_type_id",
                table: "apartments",
                column: "apartment_type_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "apartments");

            migrationBuilder.DropTable(
                name: "ref_apartment_types");
        }
    }
}
