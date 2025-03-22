using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xadrez.Domain.Application.UseCases.Xadrez;
using Xadrez.Domain.Core.Enums;
using Xadrez.Domain.Core.Models.ModelTabuleiro;

namespace Xadrez.Domain.Core.Models.Pecas
{
    internal class Rei : Peca
    {
        private PartidaDeXadrez partida;

        public Rei(Tabuleiro tab, EnumCor cor, PartidaDeXadrez partida) : base(tab, cor) 
        { this.partida = partida; }

        public override string ToString() => "R";

        private bool PodeMover(Posicao pos)
        {
            Peca p = tabuleiro.RetornarPecaNaPosicao(pos);
            return p == null || p.cor != cor;
        }

        private bool TesteTorreParaRoque(Posicao pos)
        {
            Peca p = tabuleiro.RetornarPecaNaPosicao(pos);
            return p != null && p is Torre && p.cor == cor && p.qntdMovimentos == 0;
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

            if(qntdMovimentos == 0 && !partida.Xeque)
            {
                Posicao posT1 = new Posicao(pos.Linha, pos.Coluna + 3);
                if(TesteTorreParaRoque(posT1))
                {
                    Posicao p1 = new Posicao(pos.Linha, pos.Coluna + 1);
                    Posicao p2 = new Posicao(pos.Linha, pos.Coluna + 2);

                    if (tabuleiro.RetornarPecaNaPosicao(p1) == null && tabuleiro.RetornarPecaNaPosicao(p2) == null)
                        matriz[pos.Linha, pos.Coluna + 2] = true;
                }
            }

            return matriz;
        }
    }
}
