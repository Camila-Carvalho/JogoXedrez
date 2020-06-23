using System;
using tabuleiro;

namespace xadrez
{
    class Torre : Peca
    {
        public Torre(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {
        }

        public override string ToString()
        {
            return "T";
        }

        //metodo auxiliar pra ver se a posição de destino está livre ou se ela é ocupada por uma peça adversaria
        private bool podeMover(Posicao pos)
        {
            Peca p = tabuleiro.peca(pos);
            return p == null || p.cor != cor;
        }

        //implementação dos movimentos possíveis
        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tabuleiro.linhas, tabuleiro.colunas];//cria uma nova matriz para apresentar as posições possiveis
            Posicao pos = new Posicao(0, 0); //aqui é somente para instanciar e iniciar com algo para os testes

            //acima, norte
            pos.definirValores(posicao.linha - 1, posicao.coluna);
            while (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor)
                {
                    break;
                }
                pos.linha = pos.linha - 1;// se passou pelo if de cima, continua avançando casas acima
            }
            //abaixo
            pos.definirValores(posicao.linha + 1, posicao.coluna);
            while (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor)
                {
                    break;
                }
                pos.linha = pos.linha + 1;// se passou pelo if de cima, continua avançando casas abaixo
            }
            //direita
            pos.definirValores(posicao.linha, posicao.coluna + 1);
            while (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor)
                {
                    break;
                }
                pos.coluna = pos.coluna + 1;// se passou pelo if de cima, continua avançando casas a direita
            }
            //esquerda
            pos.definirValores(posicao.linha, posicao.coluna - 1);
            while (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor)
                {
                    break;
                }
                pos.coluna = pos.coluna - 1;// se passou pelo if de cima, continua avançando casas a esquerda
            }

            return mat;
        }
    }
}
