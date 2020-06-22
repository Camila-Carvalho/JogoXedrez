using System;

namespace tabuleiro
{
    class Posicao
    {
        public int linha { get; set; }
        public int coluna { get; set; }
        //construtor
        public Posicao(int linha, int coluna)
        {
            this.linha = linha;
            this.coluna = coluna;
        }
        //metodo igual ao construtor, criado para facilitar os metodos das peças (rei, torre...)
        public void definirValores(int linha, int coluna)
        {
            this.linha = linha;
            this.coluna = coluna;
        }
        
        public override string ToString()
        {
            return linha + ", " + coluna;
        }

    }
}
