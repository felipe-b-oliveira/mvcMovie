using System;
using System.Text;
using PedidoEnum.Entidades;
using PedidoEnum.Entidades.Enum;
using System.Collections.Generic;
using System.Globalization;

namespace PedidoEnum.Entidades
{
    public class Pedido
    {
        public DateTime HorarioPedido { get; set; }
        public StatusDoPedido Status { get; set; }
        public Cliente cliente { get; set; }
        public List<ItemPedido> Itens { get; private set; } = new List<ItemPedido>();

        public Pedido()
        {

        }

        public Pedido(DateTime horarioPedido, StatusDoPedido status, Cliente cliente)
        {
            HorarioPedido = horarioPedido;
            Status = status;
            this.cliente = cliente;
        }

        public void adicionarItem(ItemPedido item)
        {
            Itens.Add(item);
        }

        public void removerItem(ItemPedido item)
        {
            Itens.Remove(item);
        }

        public double Total()
        {

            double soma = 0.0;
            foreach (ItemPedido item in Itens)
            {
                soma += item.SubTotal();
            }
            return soma;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Horario do Pedido: " + HorarioPedido.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.AppendLine("Status do Pedido: " + Status);
            sb.AppendLine("Cliente: " + cliente);
            sb.AppendLine("Itens do Pedido:");
            foreach (ItemPedido item in Itens)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine("Valor Total: $" + Total().ToString("F2", CultureInfo.InvariantCulture));
            return sb.ToString();

        }
    }
}