using System;

namespace PedidoEnum.Entidades
{
    public class Produto
    {
        public string NomeProd { get; set; }
        public double Preco { get; set; }

        public Produto()
        {

        }

        public Produto(string nomeProd, double preco)
        {
            NomeProd = nomeProd;
            Preco = preco;
        }


    }
}