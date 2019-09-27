namespace visitor.Dominio
{
    public class Impressora : ILoja
    {
        public string ModeloImpressora { get; set; }
        public double Preco { get; set; }
        public string ImpressoraTipo { get; set; }

        public void Visit(IVisitor visitor)
        {
            visitor.Accept(this);
        }
    }
}