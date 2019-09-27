namespace visitor.Dominio
{
    public class Monitor : ILoja
    {
        public string ModeloMonitor { get; set; }
        public double Preco { get; set; }
        public string Polegada { get; set; }

        public void Visit(IVisitor visitor)
        {
            visitor.Accept(this);
        }
    }
}