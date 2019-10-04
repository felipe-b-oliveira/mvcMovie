using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vendasWebMvc.Models.ViewModels
{
    public class FormViewModelVendedor
    {
        public Vendedor vendedor { get; set; }

        // Lista de departamentos para a criação da seleção
        public ICollection<Departamento> Departamentos { get; set; }
    }
}
