using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.DataContext.EF.Migrations
{
    public partial class Creation_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ancres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Poids = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ancres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Capitaines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Capitaines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Diplomes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Intitule = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diplomes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Villes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CapitainesDiplomes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CapitaineId = table.Column<int>(type: "int", nullable: false),
                    DiplomeId = table.Column<int>(type: "int", nullable: false),
                    AnneeObtention = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapitainesDiplomes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CapitainesDiplomes_Capitaines_CapitaineId",
                        column: x => x.CapitaineId,
                        principalTable: "Capitaines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CapitainesDiplomes_Diplomes_DiplomeId",
                        column: x => x.DiplomeId,
                        principalTable: "Diplomes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VilleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ports_Villes_VilleId",
                        column: x => x.VilleId,
                        principalTable: "Villes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bateaux",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PortId = table.Column<int>(type: "int", nullable: false),
                    AncreId = table.Column<int>(type: "int", nullable: false),
                    CapitaineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bateaux", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bateaux_Ancres_AncreId",
                        column: x => x.AncreId,
                        principalTable: "Ancres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bateaux_Capitaines_CapitaineId",
                        column: x => x.CapitaineId,
                        principalTable: "Capitaines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bateaux_Ports_PortId",
                        column: x => x.PortId,
                        principalTable: "Ports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bateaux_AncreId",
                table: "Bateaux",
                column: "AncreId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bateaux_CapitaineId",
                table: "Bateaux",
                column: "CapitaineId");

            migrationBuilder.CreateIndex(
                name: "IX_Bateaux_PortId",
                table: "Bateaux",
                column: "PortId");

            migrationBuilder.CreateIndex(
                name: "IX_CapitainesDiplomes_CapitaineId_DiplomeId",
                table: "CapitainesDiplomes",
                columns: new[] { "CapitaineId", "DiplomeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CapitainesDiplomes_DiplomeId",
                table: "CapitainesDiplomes",
                column: "DiplomeId");

            migrationBuilder.CreateIndex(
                name: "IX_Diplomes_Intitule",
                table: "Diplomes",
                column: "Intitule",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ports_VilleId",
                table: "Ports",
                column: "VilleId");

            migrationBuilder.CreateIndex(
                name: "IX_Villes_Nom",
                table: "Villes",
                column: "Nom",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bateaux");

            migrationBuilder.DropTable(
                name: "CapitainesDiplomes");

            migrationBuilder.DropTable(
                name: "Ancres");

            migrationBuilder.DropTable(
                name: "Ports");

            migrationBuilder.DropTable(
                name: "Capitaines");

            migrationBuilder.DropTable(
                name: "Diplomes");

            migrationBuilder.DropTable(
                name: "Villes");
        }
    }
}
