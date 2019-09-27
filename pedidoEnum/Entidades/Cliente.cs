using System;

namespace PedidoEnum.Entidades
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNasc { get; set; }

        public Cliente()
        {

        }
        public Cliente(string nome, string email, DateTime dataNasc)
        {
            Nome = nome;
            Email = email;
            DataNasc = dataNasc;
        }

        public override string ToString() {
            return Nome 
                + ", (" 
                + DataNasc.ToString("dd/MM/yyyy") 
                + ") - " 
                + Email;
        }


    }
}