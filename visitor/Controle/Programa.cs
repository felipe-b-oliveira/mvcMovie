using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using visitor.Dominio;

namespace visitor.Controle
{
    class Programa
    {
        static void Main(string[] args)
        {
            List<ILoja> loja = new List<ILoja>();
            loja.Add(new Monitor() { ModeloMonitor = "LG23LED", Preco = 500.0, Polegada = "23" });
            loja.Add(new Monitor() { ModeloMonitor = "SAMS25LED", Preco = 650.0, Polegada = "25" });

            loja.Add(new Impressora() { ModeloImpressora = "HP3150", Preco = 500.0, ImpressoraTipo = "Jato de Tinta" });
            loja.Add(new Impressora() { ModeloImpressora = "EPSON350", Preco = 1650.0, ImpressoraTipo = "Laser" });

            //Exibir preço de cada produto
            VisitorPreco visitorPreco = new VisitorPreco();
            foreach (var elemento in loja)
            {
                elemento.Visit(visitorPreco);
            }

            //Exibe o preço de cada produto
            VisitorPeso visitorPeso = new VisitorPeso();
            foreach (var elemento in loja)
            {
                elemento.Visit(visitorPeso);
            }

            Console.ReadLine();
        }
    }
}
