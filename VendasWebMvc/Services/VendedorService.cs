using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vendasWebMvc.Models;
using Microsoft.EntityFrameworkCore;
using vendasWebMvc.Services.Exceptions;

namespace vendasWebMvc.Services
{
    public class VendedorService
    {
        //Impedir que a dependência seja alterada
        private readonly VendasWebMvcContext _context;

        // Dependência para o DbContext
        public VendedorService(VendasWebMvcContext context)
        {
            _context = context;
        }

        // Retorna uma lista com todos os vendedores do banco de dados
        // Operacao assincrona
        public async Task<List<Vendedor>> FindAllAsync()
        {
            return await _context.Vendedor.OrderBy(x => x.Nome).ToListAsync();
        }

        // Operacao assincrona
        public async Task InsertAsync(Vendedor obj)
        {
            // Operacao realizada em memoria
            _context.Add(obj);

            // Operacao realizada no banco
            await _context.SaveChangesAsync();
        }

        // Operacao assincrona
        public async Task<Vendedor> FindByIdAsync(int id)
        {
            return await _context.Vendedor.Include(obj => obj.Departamento).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        // Operacao assincrona
        public async Task RemoveAsync(int id)
        {
            // Operacao realizada no banco
            var obj = await _context.Vendedor.FindAsync(id);

            // Operacao realizada em memoria
            _context.Vendedor.Remove(obj);

            // Operacao realizada no banco
            await _context.SaveChangesAsync();
        }

        // Operacao assincrona
        public async Task UpdateAsync(Vendedor obj)
        {
            // Operacao realizada no banco
            // Código movido de dentro fo If para fora do mesmo e atribuido a variável booleana hasAny
            bool hasAny = await _context.Vendedor.AnyAsync(x => x.Id == obj.Id);
                        
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
            catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }

        }

    }
}
