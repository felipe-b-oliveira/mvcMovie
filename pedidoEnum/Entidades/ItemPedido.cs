using System;
using PedidoEnum.Entidades;
using System.Globalization;

namespace PedidoEnum.Entidades
{
    public class ItemPedido
    {
        public int Quantidade { get; set; }
        public double Preco { get; set; }
        public Produto Produto { get; set; }

        public ItemPedido()
        {

        }

        public ItemPedido(int quantidade, double preco, Produto produto)
        {
            Quantidade = quantidade;
            Preco = preco;
            Produto = produto;
        }

        public double SubTotal()
        {
            return Preco *= Quantidade;
        }

        public override string ToString()
        {
            return Produto.NomeProd
                + ", $"
                + Preco.ToString("F2", CultureInfo.InvariantCulture)
                + ", Quantidade: "
                + Quantidade
                + ", Subtotal: $"
                + SubTotal().ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}