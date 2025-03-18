using Xadrez.Domain.Core.Exceptions;

namespace Xadrez.Domain.Core.Models.ModelTabuleiro
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
        
        public Peca RetornarPecaNaPosicao(Posicao pos) => _pecas[pos.Linha, pos.Coluna];

        public void ColocarPeca(Peca peca, Posicao pos)
        {
            if(ExistePecaNaPosicao(pos))
                throw new TabuleiroException($"Já existe uma peça na posição {pos}");

            _pecas[pos.Linha, pos.Coluna] = peca; 
            peca.Posicao = pos;
        }

        public Peca RetirarPeca(Posicao pos)
        {
            if (RetornarPecaNaPosicao(pos) == null)
                return null;

            Peca pecaAux = RetornarPecaNaPosicao(pos);
            pecaAux.Posicao = null;
            _pecas[pos.Linha, pos.Coluna] = null;
            return pecaAux;
        }

        #region Checagens
        public bool ExistePecaNaPosicao(Posicao pos)
        {
            ValidarPosicao(pos);
            return RetornarPecaNaPosicao(pos) != null;
        }

        public bool PosicaoEValida(Posicao pos) => 
            (pos.Linha < 0 || pos.Linha >= Linhas || pos.Coluna < 0 || pos.Coluna >= Colunas) ? false : true;

        public void ValidarPosicao(Posicao pos)
        {
            if (!PosicaoEValida(pos))
                throw new TabuleiroException($"Posição {pos} inválida!");
        }
        #endregion
    }
}
