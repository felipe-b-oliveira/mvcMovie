namespace tabuleiro
{
    class Tabuleiro
    {
        public int linhas { get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas;

        public Tabuleiro (int linhas, int colunas) {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }

        public Peca peca (int linha, int coluna) {
            return pecas[linha, coluna];
        }

        public Peca peca (Posicao pos) {
            return pecas[pos.linha, pos.coluna];
        }

        public bool existePeca(Posicao pos) {
            validarPosicao(pos);
            return peca(pos) != null;
        }

        public void colocarPeca(Peca p, Posicao pos) {
            if(existePeca(pos)) {
                throw new TabuleiroException ("Já existe uma peça nesta posição!");
            }
            pecas[pos.linha, pos.coluna] = p;
            p.posicao = pos;
        }

        public Peca retirarPeca (Posicao pos) {
            if (peca(pos) == null) { // Nenhuma peça, não faz nada
                return null;
            }
            Peca aux = peca(pos); //Variavel auxiliar recebendo a peça na posição informada
            aux.posicao = null; //Variavel retirando a peça da posição
            pecas[pos.linha, pos.coluna] = null; //Atribuindo nulo ao tabuleiro
            return aux; //Retornando a peça ao aux
        }

        public bool posicaoValida(Posicao pos) {
            if(pos.linha<0 || pos.linha>=linhas || pos.coluna<0 || pos.coluna>=colunas) {
                return false;
            }
            else {
                return true;
            }
        }

        public void validarPosicao (Posicao pos) {
            if (!posicaoValida(pos)) {
                throw new TabuleiroException("Posição inválida!");
            }
        }
    }
}