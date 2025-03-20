﻿using Xadrez.Domain.Core.Enums;
using Xadrez.Domain.Core.Models.ModelTabuleiro;
using Xadrez.Domain.Core.Models.Pecas;

namespace Xadrez.Domain.Application.UseCases.Xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro Tabuleiro {  get; private set; }
        public int Turno { get; private set; }
        public  EnumCor JogadorAtual { get; private set; }
        public bool Terminada {  get; private set; }

        public PartidaDeXadrez()
        {
            Tabuleiro = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = EnumCor.Branca;
            Terminada = false;

            ColocarPecas();
        }

        public void ExecutaMovimento(Posicao origem, Posicao Destino)
        {
            Peca p = Tabuleiro.RetirarPeca(origem);
            p.IncrementarQntdMovimentos();
            Peca pecaCapturada = Tabuleiro.RetirarPeca(Destino);
            Tabuleiro.ColocarPeca(p, Destino);
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            ExecutaMovimento(origem, destino);
            Turno++;

        }

        private void MudaJogador()
        {
            if (JogadorAtual == EnumCor.Branca)
                JogadorAtual = EnumCor.Preta;
            else
                JogadorAtual = EnumCor.Branca;
        }

        private void ColocarPecas()
        {
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, EnumCor.Branca), new PosicaoXadrez('c', 1).ToPosicao());
            Tabuleiro.ColocarPeca(new Rei(Tabuleiro, EnumCor.Preta), new PosicaoXadrez('d', 8).ToPosicao());
        }
    }
}
