using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.DataContext.Migrations
{
    public partial class Table_Bateau_MiseEnUnique_DuChamp_AncreId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Bateaux_AncreId",
                table: "Bateaux");

            migrationBuilder.CreateIndex(
                name: "IX_Bateaux_AncreId",
                table: "Bateaux",
                column: "AncreId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Bateaux_AncreId",
                table: "Bateaux");

            migrationBuilder.CreateIndex(
                name: "IX_Bateaux_AncreId",
                table: "Bateaux",
                column: "AncreId");
        }
    }
}
