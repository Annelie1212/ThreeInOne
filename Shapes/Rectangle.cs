using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Rectangle
    {
        // Deklarerar vidd och höjd
        public double Width { get; set; }
        public double Height { get; set; }

        public DateTime CurrentDateTime { get; set; }
        public Rectangle(double width, double height)
        {
            //ger dem värde uteifrån nu i shapesAppen 
            CurrentDateTime = DateTime.Now;
            Width = width;
            Height = height;
        }
        public double Area()
        {
           // Här använder jag dem
            return Width * Height;
        }
        public double Perimeter()
        {
            return (Height + Width) * 2;
        }
        public void Display()
        {
           
            Console.WriteLine($"{CurrentDateTime.ToString("yyyy-MM-dd HH:mm:ss")}");
            Console.WriteLine($"Rektangelns Bas: = {Width} l.e., Höjd: = {Height} l.e.");
            Console.WriteLine($"Arean är = {Area()} l.e.");
            Console.WriteLine($"Omkretsen är = {Perimeter()} l.e.");
        }



    }
}

