using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assi2_LH2084_DKnyazh.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialBuild : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "Campers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "Campers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
