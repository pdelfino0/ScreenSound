using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenSound.Migrations
{
    /// <inheritdoc />
    public partial class PopularTabela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.InsertData("Artistas", new string[] { "Nome", "Bio", "FotoPerfil" }, new object[]
            {
                "Dua Lipa",
                "Dua Lipa é uma cantora e compositora britânica de origem albanesa. Iniciou sua carreira musical em 2015, quando assinou contrato com a Warner Music Group e lançou seu primeiro single, New Love.",
                "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png"
            });

            migrationBuilder.InsertData("Artistas", new string[] { "Nome", "Bio", "FotoPerfil" }, new object[]
            {
                "Ariana Grande",
                "Ariana Grande-Butera, conhecida profissionalmente como Ariana Grande, é uma cantora, compositora e atriz estadunidense. Nasceu em Boca Raton, Flórida, Grande começou sua carreira em 2008 no musical da Broadway 13.",
                "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png"
            });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Artistas");
        }
    }
}
