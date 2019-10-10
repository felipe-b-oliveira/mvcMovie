using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vendasWebMvc.Models;

namespace vendasWebMvc.Services
{
    public class RegistroDeVendaService
    {
        private readonly VendasWebMvcContext _context;

        public RegistroDeVendaService(VendasWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<RegistroDeVendas>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.RegistroDeVendas select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Data >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Data <= maxDate.Value);
            }

            // Efetuando os JOINs das tabelas Vendedor e Departamento
            return await result
                .Include(x => x.Vendedor)
                .Include(x => x.Vendedor.Departamento)
                .OrderByDescending(x => x.Data)
                .ToListAsync();
        }
    }
}
