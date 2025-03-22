using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xadrez.Domain.Core.Enums;
using Xadrez.Domain.Core.Models.ModelTabuleiro;

namespace Xadrez.Domain.Core.Models.Pecas
{
    internal class Bispo : Peca
    {
        public Bispo(Tabuleiro tab, EnumCor cor) : base(tab, cor) { }

        public override string ToString() => "B";

        private bool PodeMover(Posicao pos)
        {
            Peca p = tabuleiro.RetornarPecaNaPosicao(pos);
            return p == null || p.cor != cor;
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] matriz = new bool[tabuleiro.Linhas, tabuleiro.Colunas];
            Posicao pos = new Posicao(0, 0);

            // NO
            pos.DefinirValores(base.Posicao.Linha - 1, base.Posicao.Coluna - 1);
            while (tabuleiro.PosicaoEValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
                if (tabuleiro.RetornarPecaNaPosicao(pos) != null && tabuleiro.RetornarPecaNaPosicao(pos).cor != cor)
                {
                    break;
                }
                pos.DefinirValores(pos.Linha - 1, pos.Coluna - 1);
            }

            // NE
            pos.DefinirValores(base.Posicao.Linha - 1, base.Posicao.Coluna + 1);
            while (tabuleiro.PosicaoEValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
                if (tabuleiro.RetornarPecaNaPosicao(pos) != null && tabuleiro.RetornarPecaNaPosicao(pos).cor != cor)
                {
                    break;
                }
                pos.DefinirValores(pos.Linha - 1, pos.Coluna + 1);
            }

            // SE
            pos.DefinirValores(base.Posicao.Linha + 1, base.Posicao.Coluna + 1);
            while (tabuleiro.PosicaoEValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
                if (tabuleiro.RetornarPecaNaPosicao(pos) != null && tabuleiro.RetornarPecaNaPosicao(pos).cor != cor)
                {
                    break;
                }
                pos.DefinirValores(pos.Linha + 1, pos.Coluna + 1);
            }

            // SO
            pos.DefinirValores(base.Posicao.Linha + 1, base.Posicao.Coluna - 1);
            while (tabuleiro.PosicaoEValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
                if (tabuleiro.RetornarPecaNaPosicao(pos) != null && tabuleiro.RetornarPecaNaPosicao(pos).cor != cor)
                {
                    break;
                }
                pos.DefinirValores(pos.Linha + 1, pos.Coluna - 1);
            }

            return matriz;
        }
    }
}
