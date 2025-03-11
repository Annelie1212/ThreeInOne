using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    internal class Triangle
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }
        public DateTime CurrentDateTime { get; set; }
        public Triangle(double width,double height, double sideA, double sideB, double sideC) 
        {
            CurrentDateTime = DateTime.Now;
            Width = width;
            Height = height;
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;


       
        }
        public double Area()
        {
            return (Width * Height) / 2;
        }
        public double Perimeter() 
        {
            return SideA + SideB + SideC;    
        }
        public void Display()
        {
            Console.WriteLine($"{CurrentDateTime.ToString("yyyy-MM-dd HH:mm:ss")}");
            Console.WriteLine($"Triangelns bas: {Width} l.e. och höjden: {Height} l.e.");
            Console.WriteLine($"Arean = {Area()} l.e.");
            Console.WriteLine($"Omkretsen = {Perimeter()} l.e.");
        }



    }
}
