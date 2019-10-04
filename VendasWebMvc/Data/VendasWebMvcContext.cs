using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace vendasWebMvc.Models
{    
    /* Implementacao do Entity Framework
     * DbContext: Objeto que encapsula uma sessao com o banco de dados
     */
    public class VendasWebMvcContext : DbContext
    {
        public VendasWebMvcContext (DbContextOptions<VendasWebMvcContext> options)
            : base(options)
        {
        }

        /*DbSet: Representa uma colecao de Entidades que representam as tabelas do banco de dados
         */
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Vendedor> Vendedor { get; set; }
        public DbSet<RegistroDeVendas> RegistroDeVendas { get; set; }

    }
}
