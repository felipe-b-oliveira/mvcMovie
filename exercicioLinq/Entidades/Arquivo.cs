using System;
using System.IO;

namespace exercicioLinq.Entidades
{
    public class Arquivo
    {
        public string Caminho { get; set; }

        public Arquivo()
        {
        }

        public bool testarCaminho()
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

