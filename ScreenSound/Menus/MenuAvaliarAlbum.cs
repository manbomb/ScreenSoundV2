using ScreenSound.Models;

namespace ScreenSound.Menus;

internal class MenuAvaliarAlbum : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        Console.Clear();
        ExibirTituloDaOpcao("Avaliar album");
        Console.Write("Digite o nome da banda do album: ");
        string nomeDaBanda = Console.ReadLine()!;

        if (!bandasRegistradas.ContainsKey(nomeDaBanda))
        {
            Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            return;
        }

        Banda banda = bandasRegistradas[nomeDaBanda];
        Console.Write("Digite o nome do album que deseja avaliar: ");
        string nomeDoAlbum = Console.ReadLine()!;
        Album album = banda.Albuns.First(a => a.Nome.Equals(nomeDoAlbum));

        if (banda.Albuns.Any(a => a.Nome.Equals(nomeDoAlbum)))
        {
            Console.WriteLine($"\nO album {nomeDoAlbum} não foi encontrada!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            return;
        }

        Console.Write($"Qual a nota que o album {nomeDoAlbum} merece: ");
        Avaliacao nota = Avaliacao.Parse(Console.ReadLine()!);
        album.AdicionarNota(nota);
        Console.WriteLine($"\nA nota {nota.Nota} foi registrada com sucesso para o album {nomeDoAlbum}");
        Thread.Sleep(2000);
        Console.Clear();

    }
}
