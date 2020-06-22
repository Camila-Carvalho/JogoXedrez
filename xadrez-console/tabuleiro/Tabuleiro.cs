using System;
using System.Collections.Generic;
using System.Text;

namespace tabuleiro
{
    class Tabuleiro
    {
        public int linhas { get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas,colunas];
        }

        public Peca peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }
        //metodo pra inserir a peça na posição
        public void colocarPeca(Peca p, Posicao pos)//passando o parametro peça e posição da peça
        {
            pecas[pos.linha, pos.coluna] = p; //informando que a matriz pecas vai receber aquela "variavel" p na posição informada pelo usuário
            p.posicao = pos; //a "variável" p vai receber como posição a matriz(linha e coluna) indicada pelo usuario
        }

    }
}
