using System;
using System.Collections.Generic;
using exercicioLambda_1.Entidades;
using System.IO;
using System.Globalization;
using System.Linq;

namespace exercicioLambda_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Arquivo x = new Arquivo();

            try
            {
                do
                {
                    Console.WriteLine("Digite o caminho completo do arquivo:");
                    x.Caminho = Console.ReadLine();

                } while(x.testeCaminho() == false);

                List<Produto> listaProd = new List<Produto>();

                using (StreamReader sr = File.OpenText(x.Caminho))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] campos = sr.ReadLine().Split(',');
                        string nome = campos[0];
                        double preco = double.Parse(campos[1], CultureInfo.InvariantCulture);
                        listaProd.Add(new Produto(nome, preco));
                    }
                }

                var media = listaProd.Select(p => p.Preco).DefaultIfEmpty(0.0).Average();
                Console.WriteLine("Preço médio: " + media.ToString("F2", CultureInfo.InvariantCulture));

                var nomes = listaProd.Where(p => p.Preco < media).OrderByDescending(p => p.Nome).Select(p => p.Nome);
                foreach (string nome in nomes)
                {
                    Console.WriteLine(nome);
                }

            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Arquivo não encontrado");

            }

        }
    }
}
