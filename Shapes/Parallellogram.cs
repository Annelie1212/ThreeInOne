using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Parallellogram
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public DateTime CurrentDateTime { get; set; }
        public Parallellogram(double width, double height) 
        {
            CurrentDateTime = DateTime.Now;
            Width = width;
            Height = height;
        }
        public double Area()
        {
            return Width * Height;
        }
        public double perimeter() 
        {
            return (Width + Height) * 2;
        }
        public void Display()
        {
            Console.WriteLine($"{CurrentDateTime.ToString("yyyy-MM-dd HH:mm:ss")}");
            Console.WriteLine($"Parallellogrammets bas: {Width} l.e. och höjden: {Height} l.e.");
            Console.WriteLine($"Arian = {Area()} l.e.");
            Console.WriteLine($"Omkretsen = {perimeter()} l.e.");
        }

    }
}
