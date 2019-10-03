using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vendasWebMvc.Models;

namespace vendasWebMvc.Servicos
{
    public class VendedorServico
    {
        //Impedir que a dependência seja alterada
        private readonly vendasWebMvcContext _context;

        //Dependência para o DbContext
        public VendedorServico (vendasWebMvcContext context)
        {
            _context = context;
        }

        //Retorna uma lista com todos os vendedores do banco de dados
        public List<Vendedor> FindAll()
        {
            return _context.Vendedor.ToList();
        }

        public void Insert(Vendedor obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

    }
}
