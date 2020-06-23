using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {

        public Rei(Tabuleiro tab, Cor cor) : base(tab, cor)
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

            Posicao pos = new Posicao(0, 0);//aqui é somente para instanciar e iniciar com algo para os testes

            // acima
            pos.definirValores(posicao.linha - 1, posicao.coluna);//aqui é pra pegar a posição da peça de acordo com a função definir valores da classe posiçao
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))//aqui é para testar se a posição que foi pega anteriormente é válida e se pode mover
            {
                mat[pos.linha, pos.coluna] = true;
            }
            // nordeste
            pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            // direita
            pos.definirValores(posicao.linha, posicao.coluna + 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            // se
            pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            // abaixo
            pos.definirValores(posicao.linha + 1, posicao.coluna);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            // so
            pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            // esquerda
            pos.definirValores(posicao.linha, posicao.coluna - 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            // no
            pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            return mat;
        }
    }
}