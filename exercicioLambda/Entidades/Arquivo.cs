using System.IO;

namespace exercicioLambda_1.Entidades
{
    public class Arquivo
    {
        public string Caminho { get; set; }

        public Arquivo()
        {
            
        }

        public bool testeCaminho()
        {
            if (File.Exists(Caminho))
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