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

        public PartidaDeXadrez()
        {
            Tabuleiro = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = EnumCor.Branca;
            Terminada = false;

            PecasDaPartida = new HashSet<Peca>();
            PecasCapturadas = new HashSet<Peca>();

            ColocarPecas();
        }

        public void ExecutaMovimento(Posicao origem, Posicao Destino)
        {
            Peca p = Tabuleiro.RetirarPeca(origem);
            p.IncrementarQntdMovimentos();
            Peca pecaCapturada = Tabuleiro.RetirarPeca(Destino);
            Tabuleiro.ColocarPeca(p, Destino);

            if(pecaCapturada != null)
            {
                PecasCapturadas.Add(pecaCapturada);
            }
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            ExecutaMovimento(origem, destino);
            Turno++;
            MudaJogador();
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
            if (!Tabuleiro.RetornarPecaNaPosicao(origem).PodeMoverPara(destino))
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
