using System.Runtime.ConstrainedExecution;
using Xadrez.Domain.Core.Enums;
using Xadrez.Domain.Core.Exceptions;
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

        private HashSet<Peca> PecasDaPartida;
        private HashSet<Peca> PecasCapturadas;

        public bool Xeque {  get; private set; }

        public PartidaDeXadrez()
        {
            Tabuleiro = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = EnumCor.Branca;
            Terminada = false;

            PecasDaPartida = new HashSet<Peca>();
            PecasCapturadas = new HashSet<Peca>();

            Xeque = false;

            ColocarPecas();
        }

        public Peca ExecutaMovimento(Posicao origem, Posicao Destino)
        {
            Peca p = Tabuleiro.RetirarPeca(origem);
            p.IncrementarQntdMovimentos();
            Peca pecaCapturada = Tabuleiro.RetirarPeca(Destino);
            Tabuleiro.ColocarPeca(p, Destino);

            if(pecaCapturada != null)
            {
                PecasCapturadas.Add(pecaCapturada);
            }
            return pecaCapturada;
        }

        private void DesfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = Tabuleiro.RetirarPeca(destino);
            p.DecrementarQntdMovimentos();
            if(pecaCapturada != null)
            {
                Tabuleiro.ColocarPeca(pecaCapturada, destino);
                PecasCapturadas.Remove(pecaCapturada);
            }
            Tabuleiro.ColocarPeca(p, origem);
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = ExecutaMovimento(origem, destino);
            if (EstaEmXeque(JogadorAtual)){
                DesfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Não pode fazer xeque em vc mesmoo");
            }

            Xeque = EstaEmXeque(CorAdversaria(JogadorAtual)) ? true : false;

            if (TestarXequeMate(CorAdversaria(JogadorAtual)))
                Terminada = true;
            else
            {
                Turno++;
                MudaJogador();
            }
        }

        private void MudaJogador()
        {
            if (JogadorAtual == EnumCor.Branca)
                JogadorAtual = EnumCor.Preta;
            else
                JogadorAtual = EnumCor.Branca;
        }

        public void ValidarPosicaoDeOrigem(Posicao pos)
        {
            if (Tabuleiro.RetornarPecaNaPosicao(pos) == null)
                throw new TabuleiroException("Não existe peça nessa posição!");

            if (JogadorAtual != Tabuleiro.RetornarPecaNaPosicao(pos).cor)
                throw new TabuleiroException("Essa peça não é sua!");

            if (!Tabuleiro.RetornarPecaNaPosicao(pos).ExisteMovimentosPossiveis())
                throw new TabuleiroException("Não há movimentos possíveis para essa peça!");
        }

        public void ValidarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!Tabuleiro.RetornarPecaNaPosicao(origem).MovimentoPossivel(destino))
                throw new TabuleiroException("Destino inválido...");
        }

        public HashSet<Peca> ChecarPecasCapturadas(EnumCor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in PecasCapturadas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> PecasEmJogo(EnumCor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in PecasDaPartida)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(ChecarPecasCapturadas(cor));
            return aux;
        }

        private EnumCor CorAdversaria(EnumCor cor) 
            => cor == EnumCor.Branca ? EnumCor.Preta : EnumCor.Branca;

        private Peca ChecarRei(EnumCor cor)
        {
            foreach(Peca x in PecasEmJogo(cor))
            {
                if (x is Rei) return x;
            }
            return null;
        }

        public bool EstaEmXeque(EnumCor cor)
        {
            Peca R = ChecarRei(cor);
            if (R == null) throw new TabuleiroException($"Não tem rei da cor {cor} no tabuleiro!");

            foreach (Peca x in PecasEmJogo(CorAdversaria(cor)))
            {
                bool[,] matriz = x.MovimentosPossiveis();
                if (matriz[R.Posicao.Linha, R.Posicao.Coluna]) return true;
            }
            return false;
        }

        public bool TestarXequeMate(EnumCor cor)
        {
            if (!EstaEmXeque(cor)) return false;

            foreach(Peca x in PecasEmJogo(cor))
            {
                bool[,] matriz = x.MovimentosPossiveis();
                for(int i = 0; i < Tabuleiro.Linhas; i++)
                {
                    for (int j = 0; j < Tabuleiro.Colunas; j++)
                    {
                        if (matriz[i, j])
                        {
                            Posicao origem = x.Posicao;
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = ExecutaMovimento(origem, destino);
                            bool testeXeque = EstaEmXeque(cor);
                            DesfazMovimento(origem, destino, pecaCapturada);

                            if(!testeXeque) return false;
                        }
                    }
                }
            }

            return true;
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tabuleiro.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            PecasDaPartida.Add(peca);
        }

        private void ColocarPecas()
        {
            ColocarNovaPeca('c', 1, new Torre(Tabuleiro, EnumCor.Branca));
            ColocarNovaPeca('c', 2, new Torre(Tabuleiro, EnumCor.Branca));
            ColocarNovaPeca('d', 2, new Torre(Tabuleiro, EnumCor.Branca));
            ColocarNovaPeca('e', 2, new Torre(Tabuleiro, EnumCor.Branca));
            ColocarNovaPeca('e', 1, new Torre(Tabuleiro, EnumCor.Branca));
            ColocarNovaPeca('d', 1, new Rei(Tabuleiro, EnumCor.Branca));

            ColocarNovaPeca('c', 7, new Torre(Tabuleiro, EnumCor.Preta));
            ColocarNovaPeca('c', 8, new Torre(Tabuleiro, EnumCor.Preta));
            ColocarNovaPeca('d', 7, new Torre(Tabuleiro, EnumCor.Preta));
            ColocarNovaPeca('e', 7, new Torre(Tabuleiro, EnumCor.Preta));
            ColocarNovaPeca('e', 8, new Torre(Tabuleiro, EnumCor.Preta));
            ColocarNovaPeca('d', 8, new Rei(Tabuleiro, EnumCor.Preta));
        }
    }
}
