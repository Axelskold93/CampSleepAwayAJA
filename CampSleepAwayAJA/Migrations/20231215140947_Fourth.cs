using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampSleepAwayAJA.Migrations
{
    /// <inheritdoc />
    public partial class Fourth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Counselors_ContactInfos_ContactInfoID",
                table: "Counselors");

            migrationBuilder.DropForeignKey(
                name: "FK_NextOfKins_Campers_CamperID",
                table: "NextOfKins");

            migrationBuilder.DropForeignKey(
                name: "FK_NextOfKins_ContactInfos_ContactInfoID",
                table: "NextOfKins");

            migrationBuilder.DropForeignKey(
                name: "FK_NextOfKins_Counselors_CounselorID",
                table: "NextOfKins");

            migrationBuilder.DropIndex(
                name: "IX_Counselors_ContactInfoID",
                table: "Counselors");

            migrationBuilder.DropColumn(
                name: "ContactInfoID",
                table: "Counselors");

            migrationBuilder.AlterColumn<int>(
                name: "CounselorID",
                table: "NextOfKins",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ContactInfoID",
                table: "NextOfKins",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CamperID",
                table: "NextOfKins",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Relation",
                table: "NextOfKins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CounselorInfoID",
                table: "Counselors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CounselorInfos",
                columns: table => new
                {
                    CounselorInfoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CounselorInfos", x => x.CounselorInfoID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Counselors_CounselorInfoID",
                table: "Counselors",
                column: "CounselorInfoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Counselors_CounselorInfos_CounselorInfoID",
                table: "Counselors",
                column: "CounselorInfoID",
                principalTable: "CounselorInfos",
                principalColumn: "CounselorInfoID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NextOfKins_Campers_CamperID",
                table: "NextOfKins",
                column: "CamperID",
                principalTable: "Campers",
                principalColumn: "CamperID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NextOfKins_ContactInfos_ContactInfoID",
                table: "NextOfKins",
                column: "ContactInfoID",
                principalTable: "ContactInfos",
                principalColumn: "ContactInfoID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NextOfKins_Counselors_CounselorID",
                table: "NextOfKins",
                column: "CounselorID",
                principalTable: "Counselors",
                principalColumn: "CounselorID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Counselors_CounselorInfos_CounselorInfoID",
                table: "Counselors");

            migrationBuilder.DropForeignKey(
                name: "FK_NextOfKins_Campers_CamperID",
                table: "NextOfKins");

            migrationBuilder.DropForeignKey(
                name: "FK_NextOfKins_ContactInfos_ContactInfoID",
                table: "NextOfKins");

            migrationBuilder.DropForeignKey(
                name: "FK_NextOfKins_Counselors_CounselorID",
                table: "NextOfKins");

            migrationBuilder.DropTable(
                name: "CounselorInfos");

            migrationBuilder.DropIndex(
                name: "IX_Counselors_CounselorInfoID",
                table: "Counselors");

            migrationBuilder.DropColumn(
                name: "Relation",
                table: "NextOfKins");

            migrationBuilder.DropColumn(
                name: "CounselorInfoID",
                table: "Counselors");

            migrationBuilder.AlterColumn<int>(
                name: "CounselorID",
                table: "NextOfKins",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ContactInfoID",
                table: "NextOfKins",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CamperID",
                table: "NextOfKins",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ContactInfoID",
                table: "Counselors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Counselors_ContactInfoID",
                table: "Counselors",
                column: "ContactInfoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Counselors_ContactInfos_ContactInfoID",
                table: "Counselors",
                column: "ContactInfoID",
                principalTable: "ContactInfos",
                principalColumn: "ContactInfoID");

            migrationBuilder.AddForeignKey(
                name: "FK_NextOfKins_Campers_CamperID",
                table: "NextOfKins",
                column: "CamperID",
                principalTable: "Campers",
                principalColumn: "CamperID");

            migrationBuilder.AddForeignKey(
                name: "FK_NextOfKins_ContactInfos_ContactInfoID",
                table: "NextOfKins",
                column: "ContactInfoID",
                principalTable: "ContactInfos",
                principalColumn: "ContactInfoID");

            migrationBuilder.AddForeignKey(
                name: "FK_NextOfKins_Counselors_CounselorID",
                table: "NextOfKins",
                column: "CounselorID",
                principalTable: "Counselors",
                principalColumn: "CounselorID");
        }
    }
}
