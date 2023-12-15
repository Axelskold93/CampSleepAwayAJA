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
                name: "FK_Campers_Cabins_CabinID",
                table: "Campers");

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

            migrationBuilder.AlterColumn<int>(
                name: "ContactInfoID",
                table: "Counselors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "NextOfKinID",
                table: "Campers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CabinID",
                table: "Campers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Campers_Cabins_CabinID",
                table: "Campers",
                column: "CabinID",
                principalTable: "Cabins",
                principalColumn: "CabinID");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campers_Cabins_CabinID",
                table: "Campers");

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

            migrationBuilder.AlterColumn<int>(
                name: "ContactInfoID",
                table: "Counselors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NextOfKinID",
                table: "Campers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CabinID",
                table: "Campers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Campers_Cabins_CabinID",
                table: "Campers",
                column: "CabinID",
                principalTable: "Cabins",
                principalColumn: "CabinID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Counselors_ContactInfos_ContactInfoID",
                table: "Counselors",
                column: "ContactInfoID",
                principalTable: "ContactInfos",
                principalColumn: "ContactInfoID",
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
    }
}
