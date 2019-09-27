using System;
using System.Collections.Generic;
using System.Text;

namespace exercicioLinq.Entidades
{
    class Funcionario
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public double Salario { get; set; }

        public Funcionario(string nome, string email, double salario)
        {
            this.Nome = nome;
            this.Email = email;
            this.Salario = salario;
        }
    }
}
