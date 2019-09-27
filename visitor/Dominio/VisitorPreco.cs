using System;

namespace visitor.Dominio
{
    public class VisitorPreco : IVisitor
    {
        private const int DESCONTO_MON = 5;
        private const int DESCONTO_IMP = 10;

        public void Accept(Monitor monitor)
        {
            double precoMonDesconto = monitor.Preco - ((monitor.Preco / 100) * DESCONTO_MON);
            Console.WriteLine("Monitor {0} preco: {1}", monitor.ModeloMonitor, precoMonDesconto);
        }

        public void Accept(Impressora impressora)
        {
            double precoImpDesconto = impressora.Preco - ((impressora.Preco / 100) * DESCONTO_IMP);
            Console.WriteLine("Impressora {0} preco: {1}", impressora.ModeloImpressora, precoImpDesconto);
        }
    }
}