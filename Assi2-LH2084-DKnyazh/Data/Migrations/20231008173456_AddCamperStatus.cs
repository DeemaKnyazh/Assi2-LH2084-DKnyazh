using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assi2_LH2084_DKnyazh.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCamperStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Campers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Campers");
        }
    }
}
