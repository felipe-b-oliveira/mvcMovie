using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vendasWebMvc.Models.Enums
{
    public enum StatusDeVenda : int
    {
        Pendente = 0,
        Faturado = 1,
        Cancelado = 2
    }
}
