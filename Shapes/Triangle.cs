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
        public string Name { get; set; } = "Triangle";
        public double Width { get; set; }
        public double Height { get; set; }
        public double SideA { get; set; }
        public double SideB { get; set; }

        public double SideC { get; set; }

        public double AngleInDegrees { get; set; }
        public DateTime CurrentDateTime { get; set; }

        public double PerimeterResult { get; set; }
        public double AreaResult { get; set; }
        public Triangle(double sideA, double sideB,double angleInDegrees) 
        {
            CurrentDateTime = DateTime.Now;
            SideA = sideA;
            SideB = sideB;
            AngleInDegrees = angleInDegrees;

        }
        public double Area()
        {
            double angleInDegrees = this.AngleInDegrees;
            double angleInRadians = angleInDegrees * (Math.PI / 180);
            //Law of Cosines
            double sideC = Math.Sqrt( SideA*SideA + SideB*SideB - 2*SideA*SideB*Math.Cos(angleInRadians) );
            SideC = sideC;

            //Herons formula
            double s = (SideA+SideB+SideC) / 2;
            double areaNoSquareRoot = s * (s - SideA) * (s - SideB) * (s - SideC);
            AreaResult = Math.Round( Math.Sqrt( areaNoSquareRoot ), 2 );
            return AreaResult;
        }
        public double Perimeter() 
        {
            PerimeterResult = Math.Round(SideA + SideB + SideC, 2);
            return PerimeterResult;    
        }
        public void Display()
        {
            Console.WriteLine($"\n{CurrentDateTime.ToString("yyyy-MM-dd HH:mm:ss")}");
            Console.WriteLine($"Arean = {Area()} l.e.");
            Console.WriteLine($"Omkretsen = {Perimeter()} l.e.");
        }



    }
}
