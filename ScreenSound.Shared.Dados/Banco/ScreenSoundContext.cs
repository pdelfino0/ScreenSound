using Microsoft.EntityFrameworkCore;
using ScreenSound.Modelos;
using ScreenSound.Shared.Modelos.Modelos;

namespace ScreenSound.Shared.Dados.Banco;

public class ScreenSoundContext : DbContext
{
    public DbSet<Artista> Artistas { get; set; }
    public DbSet<Musica> Musicas { get; set; }

    private const string ConnectionString =
        "Server=localhost\\SQLEXPRESS;Database=Alura;Integrated Security=True;TrustServerCertificate=true;Initial Catalog=ScreenSoundV0;";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer(ConnectionString)
            .UseLazyLoadingProxies();
    }
}