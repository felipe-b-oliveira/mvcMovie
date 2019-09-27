using exercicioLinq.Entidades;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace exercicioLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            string caminho;

            do
            {
                Console.WriteLine("Digite o caminho completo do arquivo: ");
                caminho = Console.ReadLine();

            } while (testarCaminho() == false);

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

            var emails = listaFunc.Where(f => f.Salario > salarioFiltro).OrderBy(f => f.Email).Select(f => f.Email);
            foreach (string email in emails)
            {
                Console.WriteLine(email);
            }

            bool testarCaminho()
            {
                if (File.Exists(caminho))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
