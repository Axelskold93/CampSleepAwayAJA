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
            migrationBuilder.DropColumn(
                name: "NextOfKinID",
                table: "Campers");

            migrationBuilder.AddColumn<int>(
                name: "CounselorID",
                table: "ContactInfos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NextOfKinID",
                table: "ContactInfos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "ContactInfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ContactInfos_CounselorID",
                table: "ContactInfos",
                column: "CounselorID");

            migrationBuilder.CreateIndex(
                name: "IX_ContactInfos_NextOfKinID",
                table: "ContactInfos",
                column: "NextOfKinID");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactInfos_Counselors_CounselorID",
                table: "ContactInfos",
                column: "CounselorID",
                principalTable: "Counselors",
                principalColumn: "CounselorID");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactInfos_NextOfKins_NextOfKinID",
                table: "ContactInfos",
                column: "NextOfKinID",
                principalTable: "NextOfKins",
                principalColumn: "NextOfKinID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactInfos_Counselors_CounselorID",
                table: "ContactInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactInfos_NextOfKins_NextOfKinID",
                table: "ContactInfos");

            migrationBuilder.DropIndex(
                name: "IX_ContactInfos_CounselorID",
                table: "ContactInfos");

            migrationBuilder.DropIndex(
                name: "IX_ContactInfos_NextOfKinID",
                table: "ContactInfos");

            migrationBuilder.DropColumn(
                name: "CounselorID",
                table: "ContactInfos");

            migrationBuilder.DropColumn(
                name: "NextOfKinID",
                table: "ContactInfos");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "ContactInfos");

            migrationBuilder.AddColumn<int>(
                name: "NextOfKinID",
                table: "Campers",
                type: "int",
                nullable: true);
        }
    }
}
