using Xadrez.Domain.Core.Enums;
using Xadrez.Domain.Core.Models.ModelTabuleiro;

namespace Xadrez.Domain.Application.UseCases
{
    class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro Tab)
        {
            Peca pecaAUX;
            for(int i = 0; i < Tab.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < Tab.Colunas; j++)
                {
                    pecaAUX = Tab.RetornarPecaNaPosicao(i, j);
                    if (pecaAUX == null)
                        Console.Write("- ");
                    else
                    {
                        ImprimirPeca(pecaAUX);
                        Console.Write(" ");
                    }
                    //Console.Write((pecaAUX == null ? "-" : pecaAUX) + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void ImprimirPeca(Peca peca)
        {
            if (peca.cor == EnumCor.Branca)
                Console.Write(peca);
            else
            {
                ConsoleColor corAux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(peca);
                Console.ForegroundColor = corAux;
            }
        }
    }
}
