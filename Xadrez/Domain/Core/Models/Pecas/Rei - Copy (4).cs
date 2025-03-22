using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xadrez.Domain.Core.Enums;
using Xadrez.Domain.Core.Models.ModelTabuleiro;

namespace Xadrez.Domain.Core.Models.Pecas
{
    internal class Rei : Peca
    {
        public Rei(Tabuleiro tab, EnumCor cor) : base(tab, cor) { }

        public override string ToString() => "R";

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
            if (tabuleiro.PosicaoEValida(pos) && PodeMover(pos))
                matriz[pos.Linha, pos.Coluna] = true;

            // ne
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            if (tabuleiro.PosicaoEValida(pos) && PodeMover(pos))
                matriz[pos.Linha, pos.Coluna] = true;

            // direita
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            if (tabuleiro.PosicaoEValida(pos) && PodeMover(pos))
                matriz[pos.Linha, pos.Coluna] = true;

            // se
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            if (tabuleiro.PosicaoEValida(pos) && PodeMover(pos))
                matriz[pos.Linha, pos.Coluna] = true;

            // baixo
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            if (tabuleiro.PosicaoEValida(pos) && PodeMover(pos))
                matriz[pos.Linha, pos.Coluna] = true;

            // so
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            if (tabuleiro.PosicaoEValida(pos) && PodeMover(pos))
                matriz[pos.Linha, pos.Coluna] = true;

            // esquerda
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            if (tabuleiro.PosicaoEValida(pos) && PodeMover(pos))
                matriz[pos.Linha, pos.Coluna] = true;

            // no
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (tabuleiro.PosicaoEValida(pos) && PodeMover(pos))
                matriz[pos.Linha, pos.Coluna] = true;

            return matriz;
        }
    }
}
