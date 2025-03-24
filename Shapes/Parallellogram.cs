using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Parallellogram
    {
        public string Name { get; set; } = "Parallellogram";
        public double Width { get; set; }
        public double Height { get; set; }
        public DateTime CurrentDateTime { get; set; }

        public double PerimeterResult { get; set; }
        public double AreaResult { get; set; }
        public Parallellogram(double width, double height) 
        {
            CurrentDateTime = DateTime.Now;
            Width = width;
            Height = height;
        }
        public double Area()
        {
            AreaResult = Math.Round(Width * Height, 2);
            return AreaResult;
        }
        public double Perimeter() 
        {
            PerimeterResult = Math.Round((Width + Height) * 2, 2);
            return PerimeterResult;
        }
        public void Display()
        {
            Console.WriteLine($"\n{CurrentDateTime.ToString("yyyy-MM-dd HH:mm:ss")}");
            Console.WriteLine($"Parallellogrammets bas: {Width} l.e. och höjden: {Height} l.e.");
            Console.WriteLine($"Arian = {Area()} l.e.");
            Console.WriteLine($"Omkretsen = {Perimeter()} l.e.");
        }

    }
}
