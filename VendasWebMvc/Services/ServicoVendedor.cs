using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vendasWebMvc.Models;

namespace vendasWebMvc.Services
{
    public class ServicoVendedor
    {
        //Impedir que a dependência seja alterada
        private readonly VendasWebMvcContext _context;

        //Dependência para o DbContext
        public ServicoVendedor (VendasWebMvcContext context)
        {
            _context = context;
        }

        //Retorna uma lista com todos os vendedores do banco de dados
        public List<Vendedor> FindAll()
        {
            return _context.Vendedor.OrderBy(x => x.Nome).ToList();
        }

        public void Insert(Vendedor obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
        public Vendedor FindById(int id)
        {
            return _context.Vendedor.FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Vendedor.Find(id);
            _context.Vendedor.Remove(obj);
            _context.SaveChanges();
        }

    }
}
