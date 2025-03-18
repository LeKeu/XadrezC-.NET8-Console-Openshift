// See https://aka.ms/new-console-template for more information
using Xadrez.Domain.Application.UseCases;
using Xadrez.Domain.Application.UseCases.Xadrez;
using Xadrez.Domain.Core.Enums;
using Xadrez.Domain.Core.Exceptions;
using Xadrez.Domain.Core.Models.ModelTabuleiro;
using Xadrez.Domain.Core.Models.Pecas;


try
{
    PartidaDeXadrez partida = new PartidaDeXadrez();

    while (!partida.Terminada)
    {
        Console.Clear();
        Tela.ImprimirTabuleiro(partida.Tabuleiro);

        Console.WriteLine();
        Console.Write("Origem: ");
        Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
        Console.Write("Destino: ");
        Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();

        partida.ExecutaMovimento(origem, destino);
    }
}
catch(TabuleiroException ex)
{
    Console.WriteLine(ex.Message);
    Console.WriteLine(ex.ToString());
}

