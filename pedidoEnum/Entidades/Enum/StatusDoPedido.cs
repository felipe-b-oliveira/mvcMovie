using System;

namespace PedidoEnum.Entidades.Enum
{
    public enum StatusDoPedido : int
    {
        PagamentoPendente = 0,
        Processamento = 1,
        Enviado = 2,
        Entregue = 3
    }
}