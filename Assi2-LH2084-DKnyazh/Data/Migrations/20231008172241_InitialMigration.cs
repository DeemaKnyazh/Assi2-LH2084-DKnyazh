using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assi2_LH2084_DKnyazh.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CampSessions",
                columns: table => new
                {
                    campSessionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    maxCampers = table.Column<int>(type: "int", nullable: false),
                    numberCampers = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampSessions", x => x.campSessionId);
                });

            migrationBuilder.CreateTable(
                name: "Campers",
                columns: table => new
                {
                    camperId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    campSessionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campers", x => x.camperId);
                    table.ForeignKey(
                        name: "FK_Campers_CampSessions_campSessionId",
                        column: x => x.campSessionId,
                        principalTable: "CampSessions",
                        principalColumn: "campSessionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campers_campSessionId",
                table: "Campers",
                column: "campSessionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Campers");

            migrationBuilder.DropTable(
                name: "CampSessions");
        }
    }
}
