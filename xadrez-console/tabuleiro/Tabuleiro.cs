﻿using System;

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
        //criado sobrecarga para o metodo peça, para o tabuleiro saber a posição das peças
        public Peca peca(Posicao pos)
        {
            return pecas[pos.linha, pos.coluna];
        }
        //método para verificar se possui peça nesta posição
        public bool existePeca(Posicao pos)
        {
            validarPosicao(pos); //primeiro ele valida a posição informada
            return peca(pos) != null; //depois verifica se possui peça na posição
        }

        //metodo pra inserir a peça na posição
        public void colocarPeca(Peca p, Posicao pos)//passando o parametro peça e posição da peça
        {
            if (existePeca(pos))//aqui ele valida se existe uma peça na posição informada antes de inserir
            {
                throw new TabuleiroExcecao("Já existe uma peça nesta posição!");
            }
            pecas[pos.linha, pos.coluna] = p; //aqui informa  a posição que a "variavel" p vai permanecer
            p.posicao = pos; //a "variável" p vai receber como posição a matriz(linha e coluna) indicada pelo usuario
        }
        //metodo para retirar a peça da posição
        public Peca retirarPeca(Posicao pos)
        {
            if(peca(pos) == null) //se não tiver nenhuma peça na posição retorna nula
            {
                return null;
            }
            Peca aux = peca(pos);//se tiver uma peça, necessário criar uma variável auxiliar e atribuir este valor que tinha nesta posição a esta variável
            aux.posicao = null; //depois de atribuir o valor a variável, é necessário informar que esta peça não está mais no tabuleiro, ou seja, ela é nula
            pecas[pos.linha, pos.coluna] = null; //depois de "salvar" o valor que tinha no campo informado, é necessário deixar o campo no tabuleiro nulo, para ele poder receber outra peça
            return aux; //por fim, retorna a auxiliar, pra poder colocar ela em outro local
        }


        //método para validar se uma posição é válida
        public bool posicaoValida(Posicao pos)
        {
            if (pos.linha<0 || pos.linha>=linhas || pos.coluna<0 || pos.coluna >= colunas)
            {
                return false;
            }
            return true;
        }
        //exceção para não informar uma posição inválida, fora da matriz
        public void validarPosicao(Posicao pos)
        {
            if (!posicaoValida(pos))//se a posição de pos não for válida pelo metodo "posicaoValida" então ele faz a excecao
            {
                throw new TabuleiroExcecao("Posição Inválida!");//exibe esta mensagem e corta a execução
            }
        }
    }
}
