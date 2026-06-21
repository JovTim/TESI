using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesiAPI.Migrations
{
    /// <inheritdoc />
    public partial class TryUpdateAF20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApartmentFacilities_apartments_ApartmentID",
                table: "ApartmentFacilities");

            migrationBuilder.DropForeignKey(
                name: "FK_ApartmentFacilities_ref_facility_types_FacilityTypeID",
                table: "ApartmentFacilities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApartmentFacilities",
                table: "ApartmentFacilities");

            migrationBuilder.RenameTable(
                name: "ApartmentFacilities",
                newName: "apartment_facilities");

            migrationBuilder.RenameIndex(
                name: "IX_ApartmentFacilities_FacilityTypeID",
                table: "apartment_facilities",
                newName: "IX_apartment_facilities_FacilityTypeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_apartment_facilities",
                table: "apartment_facilities",
                columns: new[] { "ApartmentID", "FacilityTypeID" });

            migrationBuilder.AddForeignKey(
                name: "FK_apartment_facilities_apartments_ApartmentID",
                table: "apartment_facilities",
                column: "ApartmentID",
                principalTable: "apartments",
                principalColumn: "apartment_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_apartment_facilities_ref_facility_types_FacilityTypeID",
                table: "apartment_facilities",
                column: "FacilityTypeID",
                principalTable: "ref_facility_types",
                principalColumn: "facility_type_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_apartment_facilities_apartments_ApartmentID",
                table: "apartment_facilities");

            migrationBuilder.DropForeignKey(
                name: "FK_apartment_facilities_ref_facility_types_FacilityTypeID",
                table: "apartment_facilities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_apartment_facilities",
                table: "apartment_facilities");

            migrationBuilder.RenameTable(
                name: "apartment_facilities",
                newName: "ApartmentFacilities");

            migrationBuilder.RenameIndex(
                name: "IX_apartment_facilities_FacilityTypeID",
                table: "ApartmentFacilities",
                newName: "IX_ApartmentFacilities_FacilityTypeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApartmentFacilities",
                table: "ApartmentFacilities",
                columns: new[] { "ApartmentID", "FacilityTypeID" });

            migrationBuilder.AddForeignKey(
                name: "FK_ApartmentFacilities_apartments_ApartmentID",
                table: "ApartmentFacilities",
                column: "ApartmentID",
                principalTable: "apartments",
                principalColumn: "apartment_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApartmentFacilities_ref_facility_types_FacilityTypeID",
                table: "ApartmentFacilities",
                column: "FacilityTypeID",
                principalTable: "ref_facility_types",
                principalColumn: "facility_type_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
