using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Creation_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Numeros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valeur = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Numeros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiragesLoto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiragesLoto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NumeroTirageLoto",
                columns: table => new
                {
                    NumerosId = table.Column<int>(type: "int", nullable: false),
                    TiragesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumeroTirageLoto", x => new { x.NumerosId, x.TiragesId });
                    table.ForeignKey(
                        name: "FK_NumeroTirageLoto_Numeros_NumerosId",
                        column: x => x.NumerosId,
                        principalTable: "Numeros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NumeroTirageLoto_TiragesLoto_TiragesId",
                        column: x => x.TiragesId,
                        principalTable: "TiragesLoto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Numeros_Valeur",
                table: "Numeros",
                column: "Valeur",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NumeroTirageLoto_TiragesId",
                table: "NumeroTirageLoto",
                column: "TiragesId");

            migrationBuilder.CreateIndex(
                name: "IX_TiragesLoto_Date",
                table: "TiragesLoto",
                column: "Date",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NumeroTirageLoto");

            migrationBuilder.DropTable(
                name: "Numeros");

            migrationBuilder.DropTable(
                name: "TiragesLoto");
        }
    }
}
