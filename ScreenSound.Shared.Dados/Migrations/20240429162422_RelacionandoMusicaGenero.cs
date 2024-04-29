using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenSound.Shared.Dados.Migrations
{
    /// <inheritdoc />
    public partial class RelacionandoMusicaGenero : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GeneroMusica",
                columns: table => new
                {
                    MusicasId = table.Column<int>(type: "int", nullable: false),
                    generosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneroMusica", x => new { x.MusicasId, x.generosId });
                    table.ForeignKey(
                        name: "FK_GeneroMusica_Generos_generosId",
                        column: x => x.generosId,
                        principalTable: "Generos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneroMusica_Musicas_MusicasId",
                        column: x => x.MusicasId,
                        principalTable: "Musicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GeneroMusica_generosId",
                table: "GeneroMusica",
                column: "generosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeneroMusica");
        }
    }
}
