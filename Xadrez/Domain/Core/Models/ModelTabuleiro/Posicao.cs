﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez.Domain.Core.Models.ModelTabuleiro
{
    class Posicao
    {
        public int Linha { get; set; }
        public int Coluna { get; set; }

        public Posicao(int linha, int coluna)
        {
            Linha = linha;
            Coluna = coluna;
        }

        public override string ToString() => $"{Linha}, {Coluna}";

        public void DefinirValores(int linha, int coluna)
        {
            this.Linha = linha;
            this.Coluna = coluna;
        }
    }
}
