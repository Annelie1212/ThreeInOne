using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    internal class Rhombus
    {
        public string Name1 { get; set; } = "Rhombus1";
        public string Name2 { get; set; } = "Rhombus2";

        public double Width1 { get; set; }
        public double Height1 { get; set; }
        public double Diagonal1 { get; set; }
        public double Diagonal2 { get; set; }

        //public double Width2 { get; set; }
        //public double Height2 { get; set; }
        //public double Diagonal3 { get; set; }
        //public double Diagonal4 { get; set; }

        public DateTime CurrentDateTime { get; set; }

        public double PerimeterResult { get; set; }
        public double DiagonalPerimeterResult {  get; set; }
        public double AreaResult { get; set; }
        public double DiagonalAreaResult {  get; set; }

        public Rhombus(double widht4, double height4, double diagonal1, double diagonal2)
        {
            Width1 = widht4;  
            Height1 = height4;
            Diagonal1 = diagonal1;
            Diagonal2 = diagonal2;
            CurrentDateTime = DateTime.Now;
        }

        //Vi kan inte beräkna diagonaler utifrån bara höjd och bredd.
        //Vi behöver i sådana fall höjd och bredd och ena diagonalen.
        public void HeightWidthToDiagonals()
        {
        }

        //Vi kan beräkna höjd och bredd utifrån diagonaler men ej tvärtom.
        public void DiagonalsToHeightWidth()
        {
        }
        public double Area() 
        {
            AreaResult = Math.Round(Width1 * Height1,2);
            return AreaResult;
        }
        public double Perimeter()
        {
            
            PerimeterResult = Math.Round( (Width1 + Height1) * 2,2);
            return PerimeterResult;
        }
        public double DiagonalArea()
        {
            DiagonalAreaResult = Math.Round( (Diagonal1 * Diagonal2) / 2,2);
            return DiagonalAreaResult;
        }
        public double DiagonalPerimeter()
        {
            DiagonalPerimeterResult = Math.Round( 2 * Math.Sqrt(Diagonal1 * Diagonal1 + Diagonal2 * Diagonal2),2);
            return DiagonalPerimeterResult;
        }
        public void Display1()
        {
            Console.WriteLine($"{CurrentDateTime.ToString("yyyy-MM-dd HH:mm:ss")}");
            Console.WriteLine($"Första rombens bas är: {Width1} och höjden är: {Height1}");
            Console.WriteLine($"Arean = {Area()} l.e.");
            Console.WriteLine($"Omkretsen = {Perimeter()} l.e.");
            Console.WriteLine();
        }
        public void Display2()
        {
            Console.WriteLine($"{CurrentDateTime.ToString("yyyy-MM-dd HH:mm:ss")}");
            Console.WriteLine($"Andra rombens första diagonal är: {Diagonal1} och andra diagonalen är: {Diagonal2}");
            Console.WriteLine($"Arean = {DiagonalArea()} l.e.");
            Console.WriteLine($"Omkretsen = {DiagonalPerimeter()} l.e.");
            Console.WriteLine();
        }
    }
}
