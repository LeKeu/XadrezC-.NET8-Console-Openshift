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

        private void ColocarPecas()
        {
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, EnumCor.Branca), new PosicaoXadrez('c', 1).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, EnumCor.Branca), new PosicaoXadrez('c', 2).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, EnumCor.Branca), new PosicaoXadrez('d', 2).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, EnumCor.Branca), new PosicaoXadrez('e', 2).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, EnumCor.Branca), new PosicaoXadrez('e', 1).ToPosicao());
            Tabuleiro.ColocarPeca(new Rei(Tabuleiro, EnumCor.Branca), new PosicaoXadrez('d', 1).ToPosicao());

            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, EnumCor.Preta), new PosicaoXadrez('c', 7).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, EnumCor.Preta), new PosicaoXadrez('c', 8).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, EnumCor.Preta), new PosicaoXadrez('d', 7).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, EnumCor.Preta), new PosicaoXadrez('e', 7).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, EnumCor.Preta), new PosicaoXadrez('e', 8).ToPosicao());
            Tabuleiro.ColocarPeca(new Rei(Tabuleiro, EnumCor.Preta), new PosicaoXadrez('d', 8).ToPosicao());
        }
    }
}
