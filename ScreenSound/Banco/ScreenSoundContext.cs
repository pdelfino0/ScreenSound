using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ScreenSound.Modelos;

namespace ScreenSound.Banco;

internal class ScreenSoundContext : DbContext
{
    public DbSet<Artista> Artistas { get; set; }

    private const string ConnectionString =
        "Server=localhost\\SQLEXPRESS;Database=Alura;Integrated Security=True;TrustServerCertificate=true;";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionString);
    }
}