using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xadrez.Domain.Core.Models.ModelTabuleiro;

namespace Xadrez.Domain.Application.UseCases.Xadrez
{
    class PosicaoXadrez
    {
        public char Coluna {  get; set; }
        public int Linha {  get; set; }

        public PosicaoXadrez(char coluna, int linha)
        {
            this.Coluna = coluna;
            this.Linha = linha;
        }

        public Posicao ToPosicao() => new Posicao(8 - Linha, Coluna - 'a');

        public override string ToString() => "" + Coluna + Linha;
    }
}
