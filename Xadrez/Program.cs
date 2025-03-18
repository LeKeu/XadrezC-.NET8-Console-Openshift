// See https://aka.ms/new-console-template for more information
using Xadrez.Domain.Application.UseCases;
using Xadrez.Domain.Application.UseCases.Xadrez;
using Xadrez.Domain.Core.Enums;
using Xadrez.Domain.Core.Exceptions;
using Xadrez.Domain.Core.Models.Tabuleiro;

Console.WriteLine("Hello, World!");
try
{
    Tabuleiro tab = new(5, 5);

    tab.ColocarPeca(new Torre(tab, EnumCor.Vermelho), new Posicao(0, 0));
    tab.ColocarPeca(new Rei(tab, EnumCor.Vermelho), new Posicao(0, 9));
    tab.ColocarPeca(new Rei(tab, EnumCor.Amarela), new Posicao(3, 2));

    Tela.ImprimirTabuleiro(tab);
}
catch(TabuleiroException ex)
{
    Console.WriteLine(ex.Message);
    Console.WriteLine(ex.ToString());
}

