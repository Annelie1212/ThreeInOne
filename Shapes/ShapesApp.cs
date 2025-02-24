using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    internal class ShapesApp
    {
        public void Run() 
        {
            while (true)
            {
                Console.WriteLine("MENY\nVälj en siffra ur menyn");
                Console.WriteLine("1 Rektangel");
                Console.WriteLine("2 Parallellogram");
                Console.WriteLine("3 Triangel");
                Console.WriteLine("4 Romb");
                Console.WriteLine("0 AVSLUTA\n");

                string choice = Console.ReadLine();

                switch (int.Parse(choice))
                {
                    case 1:

                        Console.WriteLine("Ange Basenheten: ");
                        double width1 = double.Parse(Console.ReadLine());
                        Console.WriteLine("Ange Höjdenheten: ");
                        double height1 = double.Parse(Console.ReadLine());
                        Console.WriteLine();
                        //Skapar ett rektangelobjekt från klassen Rectangle.För att använda rektangeln till att tex beräkna dess area.(uträkningen)
                        Rectangle myRectangle = new Rectangle(width1, height1);
                        myRectangle.Display();
                        Console.WriteLine();
                        SendToDatabase();
                        break;

                    case 2:
                        Console.WriteLine("Ange Basenheten: ");
                        double width2 = double.Parse(Console.ReadLine());
                        Console.WriteLine("Ange Höjdenheten: ");
                        double height2 = double.Parse(Console.ReadLine());
                        Console.WriteLine();
                        Parallellogram myParallellogram = new Parallellogram(width2, height2);
                        myParallellogram.Display();
                        Console.WriteLine();
                        SendToDatabase();
                        break;

                    case 3:
                        Console.WriteLine("Ange Basenheten: ");
                        double width3 = double.Parse(Console.ReadLine());
                        Console.WriteLine("Ange Höjdenheten: ");
                        double height3 = double.Parse(Console.ReadLine());
                        Console.WriteLine();
                        Console.WriteLine("Ange Triangelns sida A: ");
                        double sidaA = double.Parse(Console.ReadLine());
                        Console.WriteLine("Ange Triangelns sida B: ");
                        double sidaB = double.Parse(Console.ReadLine());
                        Console.WriteLine("Ange Triangelns sida C: ");
                        double sidaC = double.Parse(Console.ReadLine());
                        Console.WriteLine();
                        Triangle myTriangle = new Triangle(width3, height3, sidaA, sidaB, sidaC);
                        myTriangle.Display();
                        Console.WriteLine();
                        SendToDatabase();
                        break;

                    case 4:
                        Console.WriteLine("Ange Basenheten: ");
                        double width4 = double.Parse(Console.ReadLine());
                        Console.WriteLine("Ange Höjdenheten: ");
                        double height4 = double.Parse(Console.ReadLine());
                        Console.WriteLine();
                        Console.WriteLine("Ange Rombens första diagonal: ");
                        double diagonal1 = double.Parse(Console.ReadLine());
                        Console.WriteLine("Ange andra diagonalen: ");
                        double diagonal2 = double.Parse(Console.ReadLine());
                        Console.WriteLine();
                        Rhombus myRhombus = new Rhombus(width4, height4, diagonal1, diagonal2);
                        myRhombus.Display();
                        Console.WriteLine();
                        SendToDatabase();
                        break;

                    default:
                        break;
                }
                if (choice == "0") 
                {
                    break;
                }
            }
        }   

        static public void SendToDatabase()
        {

        }
    }
}
