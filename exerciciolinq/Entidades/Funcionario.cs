namespace exercicioLambda_2.Entidades
{
    public class Funcionario
    {
        public string nome { get; set; }
        public string email { get; set; }
        public double salario { get; set; }

        public Funcionario(string nome, string email, double salario)
        {
            this.nome = nome;
            this.email = email;
            this.salario = salario;
        }
    }
}