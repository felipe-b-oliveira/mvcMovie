namespace visitor.Dominio
{
    public interface IVisitor
    {
        void Accept(Monitor monitor);
        void Accept(Impressora impressora);
    }

}