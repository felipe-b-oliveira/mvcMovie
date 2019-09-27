using System;
using System.Globalization;
using PedidoEnum.Entidades;
using PedidoEnum.Entidades.Enum;
using System.Collections.Generic;

namespace PedidoEnum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite os dados do Cliente: ");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Data de Nascimento (DD/MM/AAAA): ");
            DateTime dataNasc = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Digite os dados do Pedido: ");
            Console.Write("Status: ");
            string status = Console.ReadLine();
            StatusDoPedido ped;
            Enum.TryParse(status, true, out ped);

            Cliente cliente = new Cliente(nome, email, dataNasc);
            Pedido pedido = new Pedido(DateTime.Now, ped, cliente);

            Console.WriteLine();

            Console.Write("Quantos itens terá esse pedido? ");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine();

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Digite os dados do item #{i}");
                Console.Write("Nome do Produto: ");
                string nomeProd = Console.ReadLine();
                Console.Write("Preço do Produto: ");
                double precoProd = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantidade: ");
                int qtd = int.Parse(Console.ReadLine());
                
                Produto produto = new Produto (nomeProd, precoProd);
                ItemPedido itemPedido = new ItemPedido (qtd, precoProd, produto);

                pedido.adicionarItem(itemPedido);

            }
            
            Console.WriteLine();
            Console.Write("Sumário do Pedido: ");
            Console.Write(pedido);

        }
    }
}