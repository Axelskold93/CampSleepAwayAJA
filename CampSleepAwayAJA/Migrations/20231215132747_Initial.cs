using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampSleepAwayAJA.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cabins",
                columns: table => new
                {
                    CabinID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CabinName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cabins", x => x.CabinID);
                });

            migrationBuilder.CreateTable(
                name: "Campers",
                columns: table => new
                {
                    CamperID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NextOfKinID = table.Column<int>(type: "int", nullable: false),
                    CabinID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campers", x => x.CamperID);
                    table.ForeignKey(
                        name: "FK_Campers_Cabins_CabinID",
                        column: x => x.CabinID,
                        principalTable: "Cabins",
                        principalColumn: "CabinID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactInfos",
                columns: table => new
                {
                    ContactInfoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CamperID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInfos", x => x.ContactInfoID);
                    table.ForeignKey(
                        name: "FK_ContactInfos_Campers_CamperID",
                        column: x => x.CamperID,
                        principalTable: "Campers",
                        principalColumn: "CamperID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Counselors",
                columns: table => new
                {
                    CounselorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CabinID = table.Column<int>(type: "int", nullable: true),
                    ContactInfoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Counselors", x => x.CounselorID);
                    table.ForeignKey(
                        name: "FK_Counselors_Cabins_CabinID",
                        column: x => x.CabinID,
                        principalTable: "Cabins",
                        principalColumn: "CabinID");
                    table.ForeignKey(
                        name: "FK_Counselors_ContactInfos_ContactInfoID",
                        column: x => x.ContactInfoID,
                        principalTable: "ContactInfos",
                        principalColumn: "ContactInfoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NextOfKins",
                columns: table => new
                {
                    NextOfKinID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CamperID = table.Column<int>(type: "int", nullable: false),
                    ContactInfoID = table.Column<int>(type: "int", nullable: false),
                    CounselorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NextOfKins", x => x.NextOfKinID);
                    table.ForeignKey(
                        name: "FK_NextOfKins_Campers_CamperID",
                        column: x => x.CamperID,
                        principalTable: "Campers",
                        principalColumn: "CamperID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NextOfKins_ContactInfos_ContactInfoID",
                        column: x => x.ContactInfoID,
                        principalTable: "ContactInfos",
                        principalColumn: "ContactInfoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NextOfKins_Counselors_CounselorID",
                        column: x => x.CounselorID,
                        principalTable: "Counselors",
                        principalColumn: "CounselorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campers_CabinID",
                table: "Campers",
                column: "CabinID");

            migrationBuilder.CreateIndex(
                name: "IX_ContactInfos_CamperID",
                table: "ContactInfos",
                column: "CamperID");

            migrationBuilder.CreateIndex(
                name: "IX_Counselors_CabinID",
                table: "Counselors",
                column: "CabinID",
                unique: true,
                filter: "[CabinID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Counselors_ContactInfoID",
                table: "Counselors",
                column: "ContactInfoID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NextOfKins_CamperID",
                table: "NextOfKins",
                column: "CamperID");

            migrationBuilder.CreateIndex(
                name: "IX_NextOfKins_ContactInfoID",
                table: "NextOfKins",
                column: "ContactInfoID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NextOfKins_CounselorID",
                table: "NextOfKins",
                column: "CounselorID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NextOfKins");

            migrationBuilder.DropTable(
                name: "Counselors");

            migrationBuilder.DropTable(
                name: "ContactInfos");

            migrationBuilder.DropTable(
                name: "Campers");

            migrationBuilder.DropTable(
                name: "Cabins");
        }
    }
}
