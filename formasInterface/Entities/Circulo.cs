namespace formasInterface.Entities
{
    public class Circulo : Forma
    {
        public double raio { get; set; }

        public override double Area() {
            return Math.PI * raio * raio;
        }

        public override string ToString() {
            
        }

    }
}