using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    internal class RockPaperScissors
    {
        public string Operator { get; set; }
        public double UserValue1 { get; set; }
        public double UserValue2 { get; set; }
        public static int computerPoints { get; set; }
        public static int playerPoints { get; set; }
        public DateTime CurrentDateTime { get; set; }

        public RockPaperScissors(int[] userValues)
        {
            UserValue1 = userValues[0];
            UserValue2 = userValues[1];
            CurrentDateTime = DateTime.Now;
        }
        public static string Winner(string userValue, string computerValue) 
        {
            if (userValue == computerValue)
            {
                computerPoints += 0;
                playerPoints += 0;
                return "Ställningen blev lika";
            }   
            else if ( userValue == "sten" && computerValue == "sax")
            {
                computerPoints += 0;
                playerPoints += 1;
                return "spelaren vann";
            }
            else if (userValue == "sax" && computerValue == "påse")
            {
                computerPoints += 0;
                playerPoints += 1;
                return "Spelaren vann";
            }
            else if (userValue == "påse" && computerValue == "sten")
            {
                computerPoints += 0;
                playerPoints += 1;
                return "Spelaren vann";
            }
            else
            {
                computerPoints += 1;
                playerPoints += 0;
                return "Datorn vann";
            }            
        }

        public static void ShowResults()
        {
            Console.WriteLine("SLUTRESULTAT");

            Console.WriteLine($"Spelaren vann!{playerPoints} gånger.");
            Console.WriteLine($"Datorns vann! {computerPoints} gånger.");

            if (computerPoints > playerPoints)
            {

                Console.Write("Datorn vann!");
            }
            else if (computerPoints < playerPoints)
            {
                Console.Write("Spelaren vann!");
            }
            else 
            {
                Console.Write("Det blev lika!");
            }Console.WriteLine();


            
        }
        public double Add()
        {

            return UserValue1;
        }
        public void Display()
        {
            Console.WriteLine($"{CurrentDateTime.ToString("yyyy-MM-dd HH:mm:ss")}");
            Console.WriteLine($"första talet är är: {UserValue1} och andra talet är: {UserValue2}");
            Console.WriteLine($"Summan = {Add()} ");
            Console.WriteLine();

        }

    }
}
