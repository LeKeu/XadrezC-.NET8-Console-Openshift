using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xadrez.Domain.Core.Enums;

namespace Xadrez.Domain.Core.Models.ModelTabuleiro
{
    abstract class Peca
    {
        public Posicao Posicao { get; set; }
        public EnumCor cor { get; protected set; }
        public int qntdMovimentos { get; protected set; }
        public Tabuleiro tabuleiro { get; protected set; }

        public Peca(Tabuleiro tab, EnumCor cor)
        {
            Posicao = null;
            tabuleiro = tab;
            this.cor = cor;
            qntdMovimentos = 0;
        }

        public void IncrementarQntdMovimentos() => qntdMovimentos++;
        public void DecrementarQntdMovimentos() => qntdMovimentos--;

        public bool ExisteMovimentosPossiveis()
        {
            bool[,] mat = MovimentosPossiveis();
            for (int i = 0; i < tabuleiro.Linhas; i++)
            {
                for(int j = 0; j < tabuleiro.Colunas; j++)
                {
                    if (mat[i, j])
                        return true;
                }
            }
            return false;
        }

        public bool MovimentoPossivel(Posicao pos) => MovimentosPossiveis()[pos.Linha, pos.Coluna];

        public abstract bool[,] MovimentosPossiveis();
    }
}
