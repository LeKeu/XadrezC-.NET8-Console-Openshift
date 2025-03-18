// See https://aka.ms/new-console-template for more information
using Xadrez.Domain.Application.UseCases;
using Xadrez.Domain.Application.UseCases.Xadrez;
using Xadrez.Domain.Core.Enums;
using Xadrez.Domain.Core.Exceptions;
using Xadrez.Domain.Core.Models.ModelTabuleiro;
using Xadrez.Domain.Core.Models.Pecas;


try
{
    PosicaoXadrez pos = new('c', 7);
    Console.WriteLine(pos);
    Console.WriteLine(pos.ToPosicao());

    Tabuleiro tab = new(8, 8);

    tab.ColocarPeca(new Torre(tab, EnumCor.Preta), new Posicao(0, 0));
    tab.ColocarPeca(new Rei(tab, EnumCor.Branca), new Posicao(0, 4));
    tab.ColocarPeca(new Rei(tab, EnumCor.Branca), new Posicao(3, 2));
    tab.ColocarPeca(new Rei(tab, EnumCor.Branca), new Posicao(5, 7));

    Tela.ImprimirTabuleiro(tab);
}
catch(TabuleiroException ex)
{
    Console.WriteLine(ex.Message);
    Console.WriteLine(ex.ToString());
}

