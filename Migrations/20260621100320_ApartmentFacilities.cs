using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesiAPI.Migrations
{
    /// <inheritdoc />
    public partial class ApartmentFacilities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ref_facility_types",
                columns: table => new
                {
                    facility_type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    facility_type = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ref_facility_types", x => x.facility_type_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ApartmentFacilities",
                columns: table => new
                {
                    ApartmentID = table.Column<int>(type: "int", nullable: false),
                    FacilityTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentFacilities", x => new { x.ApartmentID, x.FacilityTypeID });
                    table.ForeignKey(
                        name: "FK_ApartmentFacilities_apartments_ApartmentID",
                        column: x => x.ApartmentID,
                        principalTable: "apartments",
                        principalColumn: "apartment_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApartmentFacilities_ref_facility_types_FacilityTypeID",
                        column: x => x.FacilityTypeID,
                        principalTable: "ref_facility_types",
                        principalColumn: "facility_type_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentFacilities_FacilityTypeID",
                table: "ApartmentFacilities",
                column: "FacilityTypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApartmentFacilities");

            migrationBuilder.DropTable(
                name: "ref_facility_types");
        }
    }
}
