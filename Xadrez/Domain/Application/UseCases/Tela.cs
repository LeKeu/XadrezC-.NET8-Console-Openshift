using Xadrez.Domain.Application.UseCases.Xadrez;
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
                    ImprimirPeca(Tab.RetornarPecaNaPosicao(i, j));

                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void ImprimirPeca(Peca peca)
        {
            if (peca == null)
                Console.Write("- ");
            else
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
                Console.Write(" ");
            }
            
        }

        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }
    }
}
