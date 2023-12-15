using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampSleepAwayAJA.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactInfos_Campers_CamperID",
                table: "ContactInfos");

            migrationBuilder.DropIndex(
                name: "IX_NextOfKins_ContactInfoID",
                table: "NextOfKins");

            migrationBuilder.DropIndex(
                name: "IX_Counselors_ContactInfoID",
                table: "Counselors");

            migrationBuilder.DropIndex(
                name: "IX_ContactInfos_CamperID",
                table: "ContactInfos");

            migrationBuilder.DropColumn(
                name: "CamperID",
                table: "ContactInfos");

            migrationBuilder.CreateIndex(
                name: "IX_NextOfKins_ContactInfoID",
                table: "NextOfKins",
                column: "ContactInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_Counselors_ContactInfoID",
                table: "Counselors",
                column: "ContactInfoID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_NextOfKins_ContactInfoID",
                table: "NextOfKins");

            migrationBuilder.DropIndex(
                name: "IX_Counselors_ContactInfoID",
                table: "Counselors");

            migrationBuilder.AddColumn<int>(
                name: "CamperID",
                table: "ContactInfos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_NextOfKins_ContactInfoID",
                table: "NextOfKins",
                column: "ContactInfoID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Counselors_ContactInfoID",
                table: "Counselors",
                column: "ContactInfoID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContactInfos_CamperID",
                table: "ContactInfos",
                column: "CamperID");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactInfos_Campers_CamperID",
                table: "ContactInfos",
                column: "CamperID",
                principalTable: "Campers",
                principalColumn: "CamperID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
