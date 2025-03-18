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
}
catch(TabuleiroException ex)
{
    Console.WriteLine(ex.Message);
    Console.WriteLine(ex.ToString());
}

