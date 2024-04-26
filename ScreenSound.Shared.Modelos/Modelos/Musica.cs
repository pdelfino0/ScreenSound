namespace ScreenSound.Modelos;

public class Musica
{
    public Musica(string nome, string anoLancamento)
    {
        Nome = nome;
        AnoLancamento = Convert.ToInt32(anoLancamento);
    }

    public Musica()
    {
    }

    public string Nome { get; set; }
    public int Id { get; set; }
    public int? AnoLancamento { get; set; }
    public virtual Artista? Artista { get; set; }

    public void ExibirFichaTecnica()
    {
        Console.WriteLine($"Nome: {Nome}");
    }

    public override string ToString()
    {
        return @$"Id: {Id}
        Nome: {Nome}";
    }
}