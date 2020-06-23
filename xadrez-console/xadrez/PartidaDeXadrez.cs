using System.Collections.Generic;
using tabuleiro;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; }//para uma partida de xadrez é necessário o tabuleiro (que ja possui as peças)
        public int turno { get; private set; }//necessário o turno
        public Cor jogadorAtual { get; private set; }//necessário saber o jogador atual
        public bool terminada { get; private set; }
        private HashSet<Peca> pecas;//aqui é uma variável do tipo CONJUNTO de PEÇAS
        private HashSet<Peca> capturadas;

        //construtor com parametros
        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);//aqui já está instanciando o tabuleiro e informando o tamanho dele
            turno = 1; //aqui que inicia no primeiro turno
            jogadorAtual = Cor.Branca; //todos os jogos de xadrez inicia com a peça branca
            terminada = false;
            pecas = new HashSet<Peca>();//necessário declarar o conjunto antes de colocar as peças
            capturadas = new HashSet<Peca>();
            colocarPecas();
        }

        //metodo para executar os movimentos da peça
        public void executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQteMovimentos();
            Peca pecaCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);
            if(pecaCapturada != null)//se tiver peça na posição
            {
                capturadas.Add(pecaCapturada);//adiciona ela no conjunto de peças capturas, independente da cor
            }
        }

        public void realizaJogada(Posicao origem, Posicao destino)
        {
            executaMovimento(origem, destino);
            turno++;
            mudaJogador();
        }
        public void validarPosicaoDeOrigem(Posicao pos)
        {
            if(tab.peca(pos) == null)
            {
                throw new TabuleiroExcecao("Não existe peça na posição de origem escolhida!");
            }
            if (jogadorAtual != tab.peca(pos).cor)
            {
                throw new TabuleiroExcecao("A peça de origem não é sua!");
            }
            if (!tab.peca(pos).existeMovimentosPossiveis())
            {
                throw new TabuleiroExcecao("Não há movimento possíveis para a peça de origem escolhida!");
            }
        }

        public void validarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!tab.peca(origem).podeMoverPara(destino))
            {
                throw new TabuleiroExcecao("Posição de destino inválida!");
            }
        }

        public void mudaJogador()
        {
            if (jogadorAtual == Cor.Branca)
            {
                jogadorAtual = Cor.Preta;
            }
            else
            {
                jogadorAtual = Cor.Branca;
            }
        }
        //separar as peças capturadas apenas cor que for informada
        public HashSet<Peca> pecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in capturadas)
            {
                if(x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> pecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in pecas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));//aqui é para retirar do conjunto todas as peças capturadas da cor informada, assim, da pra saber quais as peças que ainda estão em jogo
            return aux;
        }

        public void colocarNovaPeca(char coluna, int linha, Peca peca)
        {
            tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());//no tabuleiro da partida deve-se colocar a peça
            pecas.Add(peca);//no conjunto peças da partida, deve-se adicionar uma peça
        }


        private void colocarPecas()
        {
            colocarNovaPeca('c', 1, new Torre(tab, Cor.Branca));
            colocarNovaPeca('c', 2, new Torre(tab, Cor.Branca));
            colocarNovaPeca('d', 2, new Torre(tab, Cor.Branca));
            colocarNovaPeca('e', 2, new Torre(tab, Cor.Branca));
            colocarNovaPeca('e', 1, new Torre(tab, Cor.Branca));
            colocarNovaPeca('d', 1, new Rei(tab, Cor.Branca));

            colocarNovaPeca('c', 7, new Torre(tab, Cor.Preta));
            colocarNovaPeca('c', 8, new Torre(tab, Cor.Preta));
            colocarNovaPeca('d', 7, new Torre(tab, Cor.Preta));
            colocarNovaPeca('e', 7, new Torre(tab, Cor.Preta));
            colocarNovaPeca('e', 8, new Torre(tab, Cor.Preta));
            colocarNovaPeca('d', 8, new Rei(tab, Cor.Preta));
        }

    }
}
