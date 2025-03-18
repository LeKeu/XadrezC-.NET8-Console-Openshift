using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez.Domain.Application.Tabuleiro
{
    class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor cor {  get; protected set; }
        public int qntdMovimentos { get; protected set; }
        public Tabuleiro tabuleiro { get; protected set; }

        public Peca(Posicao pos, Tabuleiro tab, Cor cor)
        {
            this.Posicao = pos;
            this.tabuleiro = tab;
            this.cor = cor;
            this.qntdMovimentos = 0;
        }
    }
}
