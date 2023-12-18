using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampSleepAwayAJA.Migrations
{
    /// <inheritdoc />
    public partial class fifth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NextOfKins_Counselors_CounselorID",
                table: "NextOfKins");

            migrationBuilder.DropIndex(
                name: "IX_NextOfKins_CounselorID",
                table: "NextOfKins");

            migrationBuilder.DropColumn(
                name: "CounselorID",
                table: "NextOfKins");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CounselorID",
                table: "NextOfKins",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_NextOfKins_CounselorID",
                table: "NextOfKins",
                column: "CounselorID");

            migrationBuilder.AddForeignKey(
                name: "FK_NextOfKins_Counselors_CounselorID",
                table: "NextOfKins",
                column: "CounselorID",
                principalTable: "Counselors",
                principalColumn: "CounselorID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
