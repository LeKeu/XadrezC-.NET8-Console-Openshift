using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez.Domain.Core.Models.Tabuleiro
{
    internal class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Peca[,] _pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            _pecas = new Peca[linhas, colunas];
        }

        public Peca RetornarPecaNaPosicao(int linha, int coluna) => _pecas[linha, coluna];
        
        public void ColocarPeca(Peca peca, Posicao pos)
        {
            _pecas[pos.Linha, pos.Coluna] = peca; 
            peca.Posicao = pos;
        }
    }
}
