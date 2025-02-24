using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    internal class Rhombus
    {
        public double Widht { get; set; }
        public double Height { get; set; }
        public double Diagonal1 { get; set; }
        public double Diagonal2 { get; set; }
        public DateTime CurrentDateTime { get; set; }
        public Rhombus(double widht4, double height4, double diagonal1, double diagonal2)
        {
            Widht = widht4;  
            Height = height4;
            Diagonal1 = diagonal1;
            Diagonal2 = diagonal2;
            CurrentDateTime = DateTime.Now;
        }
        public double Area() 
        {
            return Widht * Height;
        }
        public double Perimeter()
        {
            return (Widht + Height) * 2;
        }
        public double DiagonalArea()
        {
            return Diagonal1 * Diagonal2 / 2;
        }
        public double DiagonalPerimeter()
        {
            return 2 * Math.Sqrt(Diagonal1 * Diagonal1 + Diagonal2 * Diagonal2);
        }
        public void Display()
        {
            Console.WriteLine($"{CurrentDateTime.ToString("yyyy-MM-dd HH:mm:ss")}");
            Console.WriteLine($"Rombens bas är: {Widht} och höjden är: {Height}");
            Console.WriteLine($"Arean = {Area()} l.e.");
            Console.WriteLine($"Omkretsen = {Perimeter()} l.e.");
            Console.WriteLine();
            Console.WriteLine($"Rombens första diagonal är: {Diagonal1} och andra diagonalen är: {Diagonal2}");
            Console.WriteLine($"Arean = {DiagonalArea()} l.e.");
            Console.WriteLine($"Omkretsen = {DiagonalPerimeter()} l.e.");
        }
    }
}
