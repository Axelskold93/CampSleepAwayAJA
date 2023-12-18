using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampSleepAwayAJA.Migrations
{
    /// <inheritdoc />
    public partial class fourth1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NextOfKins_ContactInfos_ContactInfoID",
                table: "NextOfKins");

            migrationBuilder.DropIndex(
                name: "IX_NextOfKins_ContactInfoID",
                table: "NextOfKins");

            migrationBuilder.DropColumn(
                name: "ContactInfoID",
                table: "NextOfKins");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContactInfoID",
                table: "NextOfKins",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_NextOfKins_ContactInfoID",
                table: "NextOfKins",
                column: "ContactInfoID");

            migrationBuilder.AddForeignKey(
                name: "FK_NextOfKins_ContactInfos_ContactInfoID",
                table: "NextOfKins",
                column: "ContactInfoID",
                principalTable: "ContactInfos",
                principalColumn: "ContactInfoID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
