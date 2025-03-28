﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Xadrez.Domain.Application.UseCases.Xadrez;
using Xadrez.Domain.Core.Enums;
using Xadrez.Domain.Core.Models.ModelTabuleiro;

namespace Xadrez.Domain.Core.Models.Pecas
{
    internal class Peao : Peca
    {
        private PartidaDeXadrez partida;
        public Peao(Tabuleiro tab, EnumCor cor, PartidaDeXadrez partida) : base(tab, cor) 
        { this.partida = partida; }

        public override string ToString() => "P";

        private bool ExisteInimigo(Posicao pos)
        {
            Peca p = tabuleiro.RetornarPecaNaPosicao(pos);
            return p != null && p.cor != cor;
        }

        private bool Livre(Posicao pos)
        {
            return tabuleiro.RetornarPecaNaPosicao(pos) == null;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] matriz = new bool[tabuleiro.Linhas, tabuleiro.Colunas];
            Posicao pos = new Posicao(0, 0);

            if (cor == EnumCor.Branca)
            {
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
                if (tabuleiro.PosicaoEValida(pos) && Livre(pos))
                {
                    matriz[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna);
                Posicao p2 = new Posicao(Posicao.Linha - 1, Posicao.Coluna);
                if (tabuleiro.PosicaoEValida(p2) && Livre(p2) && tabuleiro.PosicaoEValida(pos) && Livre(pos) && qntdMovimentos == 0)
                {
                    matriz[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
                if (tabuleiro.PosicaoEValida(pos) && ExisteInimigo(pos))
                {
                    matriz[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
                if (tabuleiro.PosicaoEValida(pos) && ExisteInimigo(pos))
                {
                    matriz[pos.Linha, pos.Coluna] = true;
                }

                //checando en passant
                if(Posicao.Linha == 3)
                {
                    Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    if(tabuleiro.PosicaoEValida(esquerda) && ExisteInimigo(esquerda) && tabuleiro.RetornarPecaNaPosicao(esquerda) == partida.VulneravelEnPassant)
                    {
                        matriz[esquerda.Linha - 1, esquerda.Coluna] = true;
                    }

                    Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    if (tabuleiro.PosicaoEValida(direita) && ExisteInimigo(direita) && tabuleiro.RetornarPecaNaPosicao(direita) == partida.VulneravelEnPassant)
                    {
                        matriz[direita.Linha - 1, direita.Coluna] = true;
                    }
                }
            }
            else
            {
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
                if (tabuleiro.PosicaoEValida(pos) && Livre(pos))
                {
                    matriz[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna);
                Posicao p2 = new Posicao(Posicao.Linha + 1, Posicao.Coluna);
                if (tabuleiro.PosicaoEValida(p2) && Livre(p2) && tabuleiro.PosicaoEValida(pos) && Livre(pos) && qntdMovimentos == 0)
                {
                    matriz[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
                if (tabuleiro.PosicaoEValida(pos) && ExisteInimigo(pos))
                {
                    matriz[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
                if (tabuleiro.PosicaoEValida(pos) && ExisteInimigo(pos))
                {
                    matriz[pos.Linha, pos.Coluna] = true;
                }

                //checando en passant
                if (Posicao.Linha == 4)
                {
                    Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    if (tabuleiro.PosicaoEValida(esquerda) && ExisteInimigo(esquerda) && tabuleiro.RetornarPecaNaPosicao(esquerda) == partida.VulneravelEnPassant)
                    {
                        matriz[esquerda.Linha + 1, esquerda.Coluna] = true;
                    }

                    Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    if (tabuleiro.PosicaoEValida(direita) && ExisteInimigo(direita) && tabuleiro.RetornarPecaNaPosicao(direita) == partida.VulneravelEnPassant)
                    {
                        matriz[direita.Linha + 1, direita.Coluna] = true;
                    }
                }
            }

            return matriz;
        }
    }
}
