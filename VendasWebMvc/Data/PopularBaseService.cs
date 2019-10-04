using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vendasWebMvc.Models;
using vendasWebMvc.Models.Enums;

namespace vendasWebMvc.Data
{
    public class PopularBaseService
    {
        private VendasWebMvcContext _context;

        // Quando um PopularBaseService for criado, ele automaticamente vai 
        // receber uma instância do context também para a persistência dos dados. 
        public PopularBaseService(VendasWebMvcContext context)
        {
            _context = context;
        }

        public void Popular()
        {
            //Verifica se já existe algum registro, caso existe não fara nada
            if(_context.Departamento.Any() || _context.Vendedor.Any() || _context.RegistroDeVendas.Any())
            {
                return; //O Banco já foi populado
            }

            //
            Departamento d1 = new Departamento(1, "Briquedos");
            Departamento d2 = new Departamento(2, "Casa, Mesa e Banho");
            Departamento d3 = new Departamento(3, "Cozinha");
            Departamento d4 = new Departamento(4, "Eletrônicos");
            Departamento d5 = new Departamento(5, "Eletrodomésticos");
            Departamento d6 = new Departamento(6, "Jardim");
            Departamento d7 = new Departamento(7, "Móveis");

            Vendedor v1 = new Vendedor(1, "Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 2500.0, d1);
            Vendedor v2 = new Vendedor(2, "Maria Green", "maria@gmail.com", new DateTime(1979, 12, 31), 1500.0, d2);
            Vendedor v3 = new Vendedor(3, "Alex Grey", "alex@gmail.com", new DateTime(1988, 1, 15), 1200.0, d1);
            Vendedor v4 = new Vendedor(4, "Martha Red", "martha@gmail.com", new DateTime(1993, 11, 30), 2200.0, d4);
            Vendedor v5 = new Vendedor(5, "Donald Blue", "donald@gmail.com", new DateTime(2000, 1, 9), 2000.0, d3);
            Vendedor v6 = new Vendedor(6, "Mark Pink", "mark@gmail.com", new DateTime(1997, 3, 4), 2500.0, d2);
            Vendedor v7 = new Vendedor(7, "Phillip Black", "phillip@gmail.com", new DateTime(1966, 11, 6), 1000.0, d5);
            Vendedor v8 = new Vendedor(8, "Amy Rose", "amy@gmail.com", new DateTime(1999, 12, 25), 1500.0, d6);
            Vendedor v9 = new Vendedor(9, "Frederick Shadow", "frederick@gmail.com", new DateTime(2001, 9, 7), 2000.0, d3);
            Vendedor v10 = new Vendedor(10, "Bob Purple", "bobp@gmail.com", new DateTime(1995, 1, 1), 1000.0, d7);

            RegistroDeVendas rv1 = new RegistroDeVendas(1, new DateTime(2019, 5, 25), 11000.0, StatusDeVenda.Faturado, v1);
            RegistroDeVendas rv2 = new RegistroDeVendas(2, new DateTime(2019, 5, 4), 7000.0, StatusDeVenda.Pendente, v2);
            RegistroDeVendas rv3 = new RegistroDeVendas(3, new DateTime(2019, 5, 13), 4000.0, StatusDeVenda.Faturado, v3);
            RegistroDeVendas rv4 = new RegistroDeVendas(4, new DateTime(2019, 5, 1), 8000.0, StatusDeVenda.Faturado, v4);
            RegistroDeVendas rv5 = new RegistroDeVendas(5, new DateTime(2019, 5, 19), 8000.0, StatusDeVenda.Cancelado, v5);
            RegistroDeVendas rv6 = new RegistroDeVendas(6, new DateTime(2019, 5, 17), 9000.0, StatusDeVenda.Pendente, v6);
            RegistroDeVendas rv7 = new RegistroDeVendas(7, new DateTime(2019, 5, 1), 15000.0, StatusDeVenda.Cancelado, v7);
            RegistroDeVendas rv8 = new RegistroDeVendas(8, new DateTime(2019, 5, 30), 10000.0, StatusDeVenda.Faturado, v1);
            RegistroDeVendas rv9 = new RegistroDeVendas(9, new DateTime(2019, 5, 4), 12000.0, StatusDeVenda.Pendente, v3);
            RegistroDeVendas rv10 = new RegistroDeVendas(10, new DateTime(2019, 5, 7), 13500.0, StatusDeVenda.Pendente, v8);
            RegistroDeVendas rv11 = new RegistroDeVendas(11, new DateTime(2019, 5, 7), 11200.0, StatusDeVenda.Faturado, v9);
            RegistroDeVendas rv12 = new RegistroDeVendas(12, new DateTime(2019, 5, 7), 10100.0, StatusDeVenda.Pendente, v5);
            RegistroDeVendas rv13 = new RegistroDeVendas(13, new DateTime(2019, 5, 20), 3000.0, StatusDeVenda.Cancelado, v2);
            RegistroDeVendas rv14 = new RegistroDeVendas(14, new DateTime(2019, 5, 19), 5000.0, StatusDeVenda.Faturado, v10);
            RegistroDeVendas rv15 = new RegistroDeVendas(15, new DateTime(2019, 5, 6), 7000.0, StatusDeVenda.Faturado, v10);
            RegistroDeVendas rv16 = new RegistroDeVendas(16, new DateTime(2019, 5, 9), 9000.0, StatusDeVenda.Faturado, v10);
            RegistroDeVendas rv17 = new RegistroDeVendas(17, new DateTime(2019, 5, 15), 4500.0, StatusDeVenda.Pendente, v7);
            RegistroDeVendas rv18 = new RegistroDeVendas(18, new DateTime(2019, 5, 27), 4000.0, StatusDeVenda.Faturado, v5);
            RegistroDeVendas rv19 = new RegistroDeVendas(19, new DateTime(2019, 5, 30), 8000.0, StatusDeVenda.Faturado, v9);
            RegistroDeVendas rv20 = new RegistroDeVendas(20, new DateTime(2019, 5, 1), 7000.0, StatusDeVenda.Faturado, v8);
            RegistroDeVendas rv21 = new RegistroDeVendas(21, new DateTime(2019, 5, 2), 5000.0, StatusDeVenda.Pendente, v8);
            RegistroDeVendas rv22 = new RegistroDeVendas(22, new DateTime(2019, 5, 7), 11000.0, StatusDeVenda.Cancelado, v8);
            RegistroDeVendas rv23 = new RegistroDeVendas(23, new DateTime(2019, 5, 22), 17000.0, StatusDeVenda.Pendente, v8);
            RegistroDeVendas rv24 = new RegistroDeVendas(24, new DateTime(2019, 5, 2), 12000.0, StatusDeVenda.Faturado, v8);
            RegistroDeVendas rv25 = new RegistroDeVendas(25, new DateTime(2019, 5, 19), 3000.0, StatusDeVenda.Faturado, v8);
            RegistroDeVendas rv26 = new RegistroDeVendas(26, new DateTime(2019, 5, 13), 2000.0, StatusDeVenda.Faturado, v8);
            RegistroDeVendas rv27 = new RegistroDeVendas(27, new DateTime(2019, 5, 2), 5000.0, StatusDeVenda.Pendente, v8);
            RegistroDeVendas rv28 = new RegistroDeVendas(28, new DateTime(2019, 5, 29), 8000.0, StatusDeVenda.Faturado, v8);
            RegistroDeVendas rv29 = new RegistroDeVendas(29, new DateTime(2019, 5, 30), 9000.0, StatusDeVenda.Faturado, v8);
            RegistroDeVendas rv30 = new RegistroDeVendas(30, new DateTime(2019, 5, 1), 10000.0, StatusDeVenda.Faturado, v8);

            _context.Departamento.AddRange(d1, d2, d3, d4, d5, d6, d7);
            _context.Vendedor.AddRange(v1, v2, v3, v4, v5, v6, v7, v8, v9, v10);
            _context.RegistroDeVendas.AddRange(
                rv1, rv2, rv3, rv4, rv5, rv6, rv7, rv8, rv9, rv10, 
                rv11, rv12, rv13,rv14, rv15, rv16, rv17, rv18, rv19, rv20,
                rv21, rv22, rv23, rv24, rv25, rv26, rv27, rv28, rv29, rv30);

            _context.SaveChanges();

        }
    }
}
