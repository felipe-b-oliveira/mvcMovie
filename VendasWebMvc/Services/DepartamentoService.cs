using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vendasWebMvc.Models;
using Microsoft.EntityFrameworkCore;
using vendasWebMvc.Services.Exceptions;

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

            var deptos = await _context.Departamento.OrderBy(d => d.Nome).ToListAsync();
            return deptos;
        }

        // Operacao assincrona
        public async Task InsertAsync(Departamento obj)
        {
            // Operacao realizada em memoria
            _context.Add(obj);

            // Operacao realizada no banco
            await _context.SaveChangesAsync();
        }

        public async Task<Departamento> FindByIdAsync(int id)
        {
            return await _context.Departamento.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        // Operacao assincrona
        public async Task RemoveAsync(int id)
        {
            // Operacao realizada no banco
            var obj = await _context.Departamento.FindAsync(id);

            // Operacao realizada em memoria
            _context.Departamento.Remove(obj);

            // Operacao realizada no banco
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Departamento obj)
        {
            // Operacao realizada no banco
            // Código movido de dentro fo If para fora do mesmo e atribuido a variável booleana hasAny
            bool hasAny = await _context.Departamento.AnyAsync(x => x.Id == obj.Id);

            if (!hasAny)
            {
                throw new NotFoundException("Id não encontrado");
            }
            try
            {
                // Operacao realizada em memoria
                _context.Update(obj);

                // Operacao realizada no banco
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
        public bool DepartamentoExists(int id)
        {
            return _context.Departamento.Any(e => e.Id == id);
        }
    }
}
