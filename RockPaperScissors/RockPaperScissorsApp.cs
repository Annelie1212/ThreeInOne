using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors

{
    internal class RockPaperScissorsApp

    {

        public int[] GetUserInput()
        {
            Dictionary<int, string> move = new Dictionary<int, string>();
            move[1] = "sten";
            move[2] = "sax";
            move[3] = "påse";

            Console.WriteLine("Välj ditt drag ur menyn\n");
            Console.WriteLine("1 Sten");
            Console.WriteLine("2 Sax");
            Console.WriteLine("3 Påse\n");

            Random random = new Random();
            Console.Write("Ange ditt första drag: " + "\n");
            int value1 = int.Parse(Console.ReadLine());
            Console.WriteLine("spelarens drag: "+move[value1]+"\n");

            int randomNumber1 = random.Next(1, 4);
            Console.WriteLine("Datorns drag: "+move[randomNumber1]+"\n");
            Console.WriteLine(RockPaperScissors.Winner(move[value1],move[randomNumber1]));


            Console.Write("Ange ditt andra drag: ");
            int value2 = int.Parse(Console.ReadLine());
            Console.WriteLine("spelarens drag: " + move[value2]+"\n");

            int randomNumber2 = random.Next(1, 4);
            Console.WriteLine("Datorns drag: "+move[randomNumber2]+"\n");
            Console.WriteLine(RockPaperScissors.Winner(move[value2], move[randomNumber2]));

            Console.Write("Ange ditt tredje drag: ");
            int value3 = int.Parse(Console.ReadLine());
            Console.WriteLine("spelarens drag: " + move[value3]+"\n");

            int randomNumber3 = random.Next(1, 4);
            Console.WriteLine("Datorns drag: "+move[randomNumber3]+"\n");
            Console.WriteLine(RockPaperScissors.Winner(move[value3], move[randomNumber3]));


            int[] userInput = { value1, randomNumber1, value2, randomNumber2, value3, randomNumber3, };

            RockPaperScissors.ShowResults();

            return userInput;
        }
        public void Run()
        {
            
            while (true)
            {
                Console.WriteLine("MENY\nVälj en siffra ur menyn");
                Console.WriteLine("1 Play Game");
                Console.WriteLine("2 Show latest result");
                Console.WriteLine("3 Show total results");
                Console.WriteLine("0 AVSLUTA\n");

                string choice = Console.ReadLine();

                switch (int.Parse(choice))
                {
                    case 1:
                        //double[] userinput = GetUserInput();
                        //Istället för att skapa en array så matar vi direkt in det som GetUserInput returnerar.
                        Console.Clear();
                        RockPaperScissors myRockPaperScissors = new RockPaperScissors(GetUserInput());
                        
                        //RockPaperScissors myRockPaperScissors = new RockPaperScissors();
                        //myRockPaperScissors.RunGame();
                        //myRockPaperScissors.ShowResult();

                        //myRockPaperScissors.Display();
                        break;

                    /*                    case 2:
                                            Console.WriteLine("Ange : ");
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
                                            break;*/

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
