using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuMostrarMusicaPorLancamento : Menu
{
    public override void Executar(Dal<Artista> artistaDal)
    {
        base.Executar(artistaDal);
        ExibirTituloDaOpcao("Exibir músicas por lançamento");
        Console.Write("Digite o ano de lançamento que deseja pesquisar: ");
        string anoDeLancamento = Console.ReadLine()!;
        var musicaDal = new Dal<Musica>(new ScreenSoundContext());
        var musicasPorLancamento = musicaDal.ListarPor(m => m.AnoLancamento == int.Parse(anoDeLancamento));
        if (musicasPorLancamento.Any())
        {
            Console.WriteLine("\nMúsicas lançadas em " + anoDeLancamento + ":");
            foreach (var musica in musicasPorLancamento)
            {
                Console.WriteLine(musica);
            }

            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
        else
        {
            Console.WriteLine($"\nNenhuma música lançada em {anoDeLancamento} foi encontrada!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
    }
}