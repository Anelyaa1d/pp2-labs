using System;

namespace circle
{
    public class Circle
    {
        public double Radius, Area, Length;
        public Circle()
        {
            Radius = 0;
            Area = 0;
            Length = 0;
        }
        public double FindArea(double r)
        {
            return Math.PI * r * r;
        }
        public double FindLength(double r)
        {
            return Math.PI * r * 2;
        }
        public Circle(double r)
        {
            Radius = r;
            Area = FindArea(r);
            Length = FindLength(r);
        }
        public override string ToString()
        {
            return Radius + " " + Area + " " + Length;
        }
    }

class Program
{
    static void Main(string[] args)
    {
        Circle C = new Circle(3);
            Console.WriteLine(C);
    }
}
}