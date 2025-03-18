using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez.Domain.Application.Tabuleiro
{
    internal class Tabuleiro
    {
        public int Linhas {  get; set; }
        public int Colunas {  get; set; }
        private Peca[,] _pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            this.Linhas = linhas;
            this.Colunas = colunas;
            _pecas = new Peca[linhas, colunas];
        }
    }
}
