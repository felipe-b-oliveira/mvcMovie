using System;
using exemploDelegate.Services;

namespace exemploDelegate
{
    delegate double BinaryNumericOperation(double n1, double n2);
    class Program
    {
        static void Main(string[] args)
        {
            double a = 10;
            double b = 12;

            BinaryNumericOperation op = CalculationService.Sum;

            double resultSum = op(a, b);
            double resultMax = CalculationService.Max(a, b);
            double resultSqr = CalculationService.Square(a);

            Console.WriteLine("Sum:" + resultSum + " " + "Max:" + resultMax + " " + "Sqr:" + resultSqr);
        }
    }
}
