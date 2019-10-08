using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vendasWebMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace vendasWebMvc.Services
{
    public class DepartamentoService
    {
        private readonly VendasWebMvcContext _context;

        public DepartamentoService(VendasWebMvcContext context)
        {
            _context = context;
        }

        // Operacao assincrona
        // Retorna um Task de List<Departamento>
        public async Task<List<Departamento>> FindAllAsync()
        {
            // A expressao link só executada pela chamada ToList
            // O ToList normalmente é assíncrona
            // O ToList Async é pertecente ao Entity Framework

            var deptos = await _context.Departamento.ToListAsync();
            return deptos;
        }
    }
}
