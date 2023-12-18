using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampSleepAwayAJA.Migrations
{
    /// <inheritdoc />
    public partial class Third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Counselors_Cabins_CabinID",
                table: "Counselors");

            migrationBuilder.DropIndex(
                name: "IX_Counselors_CabinID",
                table: "Counselors");

            migrationBuilder.DropColumn(
                name: "CabinID",
                table: "Counselors");

            migrationBuilder.AddColumn<int>(
                name: "CounselorID",
                table: "Cabins",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cabins_CounselorID",
                table: "Cabins",
                column: "CounselorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cabins_Counselors_CounselorID",
                table: "Cabins",
                column: "CounselorID",
                principalTable: "Counselors",
                principalColumn: "CounselorID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cabins_Counselors_CounselorID",
                table: "Cabins");

            migrationBuilder.DropIndex(
                name: "IX_Cabins_CounselorID",
                table: "Cabins");

            migrationBuilder.DropColumn(
                name: "CounselorID",
                table: "Cabins");

            migrationBuilder.AddColumn<int>(
                name: "CabinID",
                table: "Counselors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Counselors_CabinID",
                table: "Counselors",
                column: "CabinID",
                unique: true,
                filter: "[CabinID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Counselors_Cabins_CabinID",
                table: "Counselors",
                column: "CabinID",
                principalTable: "Cabins",
                principalColumn: "CabinID");
        }
    }
}
