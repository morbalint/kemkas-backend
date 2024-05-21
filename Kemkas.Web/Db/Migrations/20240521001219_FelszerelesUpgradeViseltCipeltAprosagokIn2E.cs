using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kemkas.Web.Db.Migrations
{
    /// <inheritdoc />
    public partial class FelszerelesUpgradeViseltCipeltAprosagokIn2E : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "Felszerelesek2E",
                type: "integer",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<bool>(
                name: "IsAprosag",
                table: "Felszerelesek2E",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCipelt",
                table: "Felszerelesek2E",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsViselt",
                table: "Felszerelesek2E",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "Felszerelesek2E");

            migrationBuilder.DropColumn(
                name: "IsAprosag",
                table: "Felszerelesek2E");

            migrationBuilder.DropColumn(
                name: "IsCipelt",
                table: "Felszerelesek2E");

            migrationBuilder.DropColumn(
                name: "IsViselt",
                table: "Felszerelesek2E");
        }
    }
}
