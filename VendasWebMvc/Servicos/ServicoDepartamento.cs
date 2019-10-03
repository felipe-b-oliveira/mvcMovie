using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vendasWebMvc.Models;

namespace vendasWebMvc.Servicos
{
    public class ServicoDepartamento
    {
        private readonly vendasWebMvcContext _context;

        public ServicoDepartamento(vendasWebMvcContext context)
        {
            _context = context;
        }

        public List<Departamento> FindAll()
        {
            return _context.Departamento.OrderBy(x => x.Nome).ToList();
        }
    }
}
