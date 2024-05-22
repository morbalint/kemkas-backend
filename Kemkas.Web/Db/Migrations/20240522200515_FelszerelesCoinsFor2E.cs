using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kemkas.Web.Db.Migrations
{
    /// <inheritdoc />
    public partial class FelszerelesCoinsFor2E : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AranyTaller",
                table: "Karakterek2E",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ElektrumTaller",
                table: "Karakterek2E",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EzustTaller",
                table: "Karakterek2E",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AranyTaller",
                table: "Karakterek2E");

            migrationBuilder.DropColumn(
                name: "ElektrumTaller",
                table: "Karakterek2E");

            migrationBuilder.DropColumn(
                name: "EzustTaller",
                table: "Karakterek2E");
        }
    }
}
