using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesiAPI.Migrations
{
    /// <inheritdoc />
    public partial class TryUpdateAF30 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_apartment_facilities_apartments_ApartmentID",
                table: "apartment_facilities");

            migrationBuilder.DropForeignKey(
                name: "FK_apartment_facilities_ref_facility_types_FacilityTypeID",
                table: "apartment_facilities");

            migrationBuilder.RenameColumn(
                name: "FacilityTypeID",
                table: "apartment_facilities",
                newName: "facility_type_id");

            migrationBuilder.RenameColumn(
                name: "ApartmentID",
                table: "apartment_facilities",
                newName: "apartment_id");

            migrationBuilder.RenameIndex(
                name: "IX_apartment_facilities_FacilityTypeID",
                table: "apartment_facilities",
                newName: "IX_apartment_facilities_facility_type_id");

            migrationBuilder.AddForeignKey(
                name: "FK_apartment_facilities_apartments_apartment_id",
                table: "apartment_facilities",
                column: "apartment_id",
                principalTable: "apartments",
                principalColumn: "apartment_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_apartment_facilities_ref_facility_types_facility_type_id",
                table: "apartment_facilities",
                column: "facility_type_id",
                principalTable: "ref_facility_types",
                principalColumn: "facility_type_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_apartment_facilities_apartments_apartment_id",
                table: "apartment_facilities");

            migrationBuilder.DropForeignKey(
                name: "FK_apartment_facilities_ref_facility_types_facility_type_id",
                table: "apartment_facilities");

            migrationBuilder.RenameColumn(
                name: "facility_type_id",
                table: "apartment_facilities",
                newName: "FacilityTypeID");

            migrationBuilder.RenameColumn(
                name: "apartment_id",
                table: "apartment_facilities",
                newName: "ApartmentID");

            migrationBuilder.RenameIndex(
                name: "IX_apartment_facilities_facility_type_id",
                table: "apartment_facilities",
                newName: "IX_apartment_facilities_FacilityTypeID");

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
    }
}
