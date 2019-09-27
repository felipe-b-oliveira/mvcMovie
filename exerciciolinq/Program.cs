using System;
using exercicioLambda_2.Entidades;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace exercicioLambda_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite o caminho completo do arquivo: ");
            string caminho = Console.ReadLine();

            List<Funcionario> listaFunc = new List<Funcionario>();

            using (StreamReader sr = File.OpenText(caminho))
            {
                while (!sr.EndOfStream)
                {
                    string[] campos = sr.ReadLine().Split(',');
                    string nome = campos[0];
                    string email = campos[1];
                    double salario = double.Parse(campos[2], CultureInfo.InvariantCulture);
                    listaFunc.Add(new Funcionario(nome, email, salario));
                }
            }

            Console.WriteLine("Digite o salario: ");
            double salarioFiltro = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            var emails = listaFunc.Where(f => f.salario > salarioFiltro).OrderBy(f => f.email).Select(f => f.email);
            foreach (string email in emails) {
                Console.WriteLine(email);
            }



        }
    }
}
