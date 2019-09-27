namespace formasInterface.Entities
{
    abstract class Forma
    {
        public Cor cor { get; set; }

        public abstract double Area ();
    }
}