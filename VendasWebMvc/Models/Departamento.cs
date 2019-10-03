using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vendasWebMvc.Models
{
    public class Departamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Vendedor> Vendedores { get; set; } = new List<Vendedor>();

        public Departamento()
        {
        }

        public Departamento(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public void AdicionaVendedor(Vendedor vendedor)
        {
            Vendedores.Add(vendedor);
        }

        public double TotalDeVendasDep(DateTime inicial, DateTime final)
        {
            return Vendedores.Sum(vendedor => vendedor.TotalDeVendas(inicial, final));
        }
    }
}
