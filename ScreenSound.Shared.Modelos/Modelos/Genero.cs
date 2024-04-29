namespace ScreenSound.Shared.Modelos.Modelos;

public class Genero
{
    public string? Nome { get; set; } = string.Empty;
    public int Id { get; set; }
    public string? Descricao { get; set; } = string.Empty;
    public virtual ICollection<Musica> Musicas { get; set; }

    public override string ToString()
    {
        return $@"Id: {Id}
            Nome: {Nome}
            Descrição: {Descricao}";
    }
}