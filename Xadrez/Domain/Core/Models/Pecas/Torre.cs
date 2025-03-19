using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xadrez.Domain.Core.Enums;
using Xadrez.Domain.Core.Models.ModelTabuleiro;

namespace Xadrez.Domain.Core.Models.Pecas
{
    internal class Torre : Peca // KING
    {
        public Torre(Tabuleiro tab, EnumCor cor) : base(tab, cor) { }

        public override string ToString() => "T";

        private bool PodeMover(Posicao pos)
        {
            Peca p = tabuleiro.RetornarPecaNaPosicao(pos);
            return p == null || p.cor != cor;
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] matriz = new bool[tabuleiro.Linhas, tabuleiro.Colunas];
            Posicao pos = new Posicao(0, 0);

            // cima
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            while(tabuleiro.PosicaoEValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
                if(tabuleiro.RetornarPecaNaPosicao(pos) != null && tabuleiro.RetornarPecaNaPosicao(pos).cor != cor)
                    break;
                pos.Linha = pos.Linha - 1;
            }

            // baixo
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            while (tabuleiro.PosicaoEValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
                if (tabuleiro.RetornarPecaNaPosicao(pos) != null && tabuleiro.RetornarPecaNaPosicao(pos).cor != cor)
                    break;
                pos.Linha = pos.Linha + 1;
            }

            // direita
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            while (tabuleiro.PosicaoEValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
                if (tabuleiro.RetornarPecaNaPosicao(pos) != null && tabuleiro.RetornarPecaNaPosicao(pos).cor != cor)
                    break;
                pos.Coluna = pos.Coluna + 1;
            }

            // esquerda
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            while (tabuleiro.PosicaoEValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
                if (tabuleiro.RetornarPecaNaPosicao(pos) != null && tabuleiro.RetornarPecaNaPosicao(pos).cor != cor)
                    break;
                pos.Coluna = pos.Coluna - 1;
            }

            return matriz;
        }
    }
}
