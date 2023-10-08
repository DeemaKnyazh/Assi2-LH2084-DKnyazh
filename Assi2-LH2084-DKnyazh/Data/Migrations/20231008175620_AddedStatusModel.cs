using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assi2_LH2084_DKnyazh.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedStatusModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Campers");

            migrationBuilder.AddColumn<int>(
                name: "statusId",
                table: "Campers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    statusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    statusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.statusId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campers_statusId",
                table: "Campers",
                column: "statusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Campers_Status_statusId",
                table: "Campers",
                column: "statusId",
                principalTable: "Status",
                principalColumn: "statusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campers_Status_statusId",
                table: "Campers");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Campers_statusId",
                table: "Campers");

            migrationBuilder.DropColumn(
                name: "statusId",
                table: "Campers");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Campers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
