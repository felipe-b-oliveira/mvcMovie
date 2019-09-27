using System;

namespace visitor.Dominio
{
    public class VisitorPeso : IVisitor
    {
        public void Accept(Monitor monitor)
        {
            switch (monitor.Polegada)
            {
                case "23":
                    Console.WriteLine("Monitor {0} peso: {1} KG", monitor.ModeloMonitor, 2);
                    break;
                case "25":
                    Console.WriteLine("Monitor {0} peso: {1} KG", monitor.ModeloMonitor, 3.5);
                    break;
            }
        }

        public void Accept(Impressora impressora)
        {
            switch (impressora.ImpressoraTipo)
            {
                case "Jato de Tinta":
                    Console.WriteLine("Impressora {0} peso: {1} KG", impressora.ModeloImpressora, 4);
                    break;
                case "Laser":
                    Console.WriteLine("Impressora {0} peso: {1} KG", impressora.ModeloImpressora, 7);
                    break;
            }
        }
    }
}