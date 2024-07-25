using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kemkas.Web.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddOsztalyToV2KarakterVarazslat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Osztaly",
                table: "V2KarakterVarazslat",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Osztaly",
                table: "V2KarakterVarazslat");
        }
    }
}
