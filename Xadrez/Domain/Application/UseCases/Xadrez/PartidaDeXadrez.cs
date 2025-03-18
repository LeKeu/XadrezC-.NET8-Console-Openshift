﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xadrez.Domain.Core.Enums;
using Xadrez.Domain.Core.Models.ModelTabuleiro;
using Xadrez.Domain.Core.Models.Pecas;

namespace Xadrez.Domain.Application.UseCases.Xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro Tabuleiro {  get; private set; }
        private int Turno;
        private EnumCor JogadorAtual;

        public PartidaDeXadrez()
        {
            Tabuleiro = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = EnumCor.Branca;
            ColocarPecas();
        }

        public void ExecutaMovimento(Posicao origem, Posicao Destino)
        {
            Peca p = Tabuleiro.RetirarPeca(origem);
            p.IncrementarQntdMovimentos();
            Peca pecaCapturada = Tabuleiro.RetirarPeca(Destino);
            Tabuleiro.ColocarPeca(p, Destino);
        }

        private void ColocarPecas()
        {
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, EnumCor.Branca), new PosicaoXadrez('c', 1).ToPosicao());
            Tabuleiro.ColocarPeca(new Rei(Tabuleiro, EnumCor.Preta), new PosicaoXadrez('d', 8).ToPosicao());
        }
    }
}
