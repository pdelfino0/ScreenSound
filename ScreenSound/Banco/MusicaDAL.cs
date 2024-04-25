using ScreenSound.Modelos;

namespace ScreenSound.Banco;

internal class MusicaDAL
{
    public MusicaDAL(ScreenSoundContext context)
    {
        this.context = context;
    }

    private readonly ScreenSoundContext context;

    public IEnumerable<Musica> Listar()
    {
        return context.Musicas.ToList();
    }

    public void Adicionar(Musica musica)
    {
        context.Musicas.Add(musica);
        context.SaveChanges();
    }

    public Musica RecuperarPeloNome(string nome)
    {
        return context.Musicas.FirstOrDefault(m => m.Nome == nome);
    }

    public void Atualizar(Musica musica)
    {
        context.Musicas.Update(musica);
        context.SaveChanges();
    }

    public void Deletar(Musica musica)
    {
        context.Musicas.Remove(musica);
        context.SaveChanges();
    }
}