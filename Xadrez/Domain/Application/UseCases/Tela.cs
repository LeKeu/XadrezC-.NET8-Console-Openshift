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
                    Console.Write((pecaAUX == null ? "-" : pecaAUX) + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
    }
}
