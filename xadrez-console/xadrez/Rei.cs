using System;
using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {
        public Rei(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {
        }
        public override string ToString()
        {
            return "R";
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
            pos.definirValores(posicao.linha - 1, pos.coluna);//aqui é pra pegar a posição da peça de acordo com a função definir valores da classe posiçao
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))//aqui é para testar se a posição que foi pega anteriormente é válida e se pode mover
            {
                mat[pos.linha, pos.coluna] = true;
            }
            //nordeste
            pos.definirValores(posicao.linha - 1, pos.coluna + 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            //leste
            pos.definirValores(posicao.linha, pos.coluna + 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            //sudeste
            pos.definirValores(posicao.linha + 1, pos.coluna + 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            //sul
            pos.definirValores(posicao.linha + 1, pos.coluna);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            //sudoeste
            pos.definirValores(posicao.linha + 1, pos.coluna - 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            //oeste
            pos.definirValores(posicao.linha, pos.coluna - 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            //noreoeste
            pos.definirValores(posicao.linha - 1, pos.coluna - 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            return mat;
        }

    }
}