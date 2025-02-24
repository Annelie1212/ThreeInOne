using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shapes;
using Calculator;
using RockPaperScissors;

namespace ThreeInOne
{
    internal class ThreeInOneApp
    {
        public void Run()
        {
            while (true)
            {
                Console.WriteLine("MENY\nVälj en siffra ur menyn");
                Console.WriteLine("1 Shapes App");
                Console.WriteLine("2 Calculator App");
                Console.WriteLine("3 Rock Paper Scissors App");
                Console.WriteLine("0 AVSLUTA\n");

                string choice = Console.ReadLine();

                           
                switch (int.Parse(choice))
                {

                    case 1:

                        ShapesApp app1 = new ShapesApp();
                        app1.Run(); 
                        break;

                    case 2:

                        CalculatorApp app2 = new CalculatorApp();
                        app2.Run();
                        break;


                    case 3:

                        RockPaperScissorsApp app3 = new RockPaperScissorsApp();
                        app3.Run();
                        
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
    }
}
