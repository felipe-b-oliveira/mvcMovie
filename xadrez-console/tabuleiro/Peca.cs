using System;
using xadrez;

namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }

        public int qtdMovimentos { get; protected set; }

        public Tabuleiro tab { get; protected set; }

        public Peca(Tabuleiro tabuleiro, Cor cor)
        {
            this.posicao = null;
            this.tab = tabuleiro;
            this.cor = cor;
            this.qtdMovimentos = 0;
        }

        public void incrementarMovimentos()
        {
            qtdMovimentos++;
        }

        public void decrementarMovimentos()
        {
            qtdMovimentos--;
        }

        public bool existeMovimentosPossiveis()
        {
            bool[,] mat = movimentosPossiveis();
            for (int lin = 0; lin < tab.linhas; lin++) //Percorrendo a matriz - linha
            {
                for (int col = 0; col < tab.colunas; col++) //Percorrendo a matriz - coluna
                {
                    if(mat[lin, col]) {
                        return true;
                    }
                }
            }
            return false;
        }

        //Verifica se uma peca pode se mover para uma dada posicao
        public bool movimentoPossivel(Posicao pos) {
            return movimentosPossiveis()[pos.linha, pos.coluna];
        }

        public abstract bool[,] movimentosPossiveis();

    }
}