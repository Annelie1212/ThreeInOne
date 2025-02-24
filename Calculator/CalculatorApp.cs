using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class CalculatorApp
    {

        
        public double[] GetUserInput()
        {

            Console.WriteLine("Ange tal 1: ");
            double value1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Ange tal 2: ");
            double value2 = double.Parse(Console.ReadLine());

            double[] userInput = { value1, value2 };

            return userInput;
        }
        public void Run() 
        {
            while (true)
            {
                Console.WriteLine("MENY\nVälj en siffra ur menyn");
                Console.WriteLine("1 Addition");
                Console.WriteLine("2 Subtraktion");
                Console.WriteLine("3 Multiplikation");
                Console.WriteLine("4 Division");
                Console.WriteLine("5 Roten Ur");
                Console.WriteLine("6 Procent");
                Console.WriteLine("0 AVSLUTA\n");

                string choice = Console.ReadLine();

                DateTime currentDateTime = DateTime.Now;
                Console.WriteLine($"{currentDateTime.ToString("yyyy-MM-dd HH:mm:ss")}");

                double[] userInput = GetUserInput();

                Calculator myCalculator = new Calculator(userInput,currentDateTime);
                
                switch (int.Parse(choice))
                {

                    case 1:
                      
                        myCalculator.Add();
                        myCalculator.Display();
                        break;

                    case 2:

                        myCalculator.Subtract();
                        myCalculator.Display();
                        break;
                       

                    case 3:

                        myCalculator.Multiply();
                        myCalculator.Display();
                        //SendToDatabase();
                        break;

                    case 4:

                        myCalculator.Divide();
                        myCalculator.Display();
                        //SendToDatabase();
                        break;

                    case 5:

                        myCalculator.Square();
                        myCalculator.Display();
                    //SendToDatabase();
                        break;

                    case 6:

                        myCalculator.Modulus();
                        myCalculator.Display();
                        //SendToDatabase();
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
