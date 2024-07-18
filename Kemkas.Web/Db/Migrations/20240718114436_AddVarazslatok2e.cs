using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kemkas.Web.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddVarazslatok2e : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "V2KarakterVarazslat",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    KarakterId = table.Column<Guid>(type: "uuid", nullable: false),
                    VarazslatId = table.Column<string>(type: "text", nullable: false),
                    Bekeszitve = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_V2KarakterVarazslat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_V2KarakterVarazslat_Karakterek2E_KarakterId",
                        column: x => x.KarakterId,
                        principalTable: "Karakterek2E",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_V2KarakterVarazslat_KarakterId",
                table: "V2KarakterVarazslat",
                column: "KarakterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "V2KarakterVarazslat");
        }
    }
}
