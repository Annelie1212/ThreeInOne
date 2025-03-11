using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeInOne;

using FluentValidation;
using FluentValidation.Results;
using System.ComponentModel;
//using ThreeInOne;

using System.Windows;

namespace RockPaperScissors

{
    internal class RockPaperScissorsApp
    {

        public static bool ErrorMessageDiplay(ValidationResult ValidationResults)
        {
            if (ValidationResults.IsValid == false)
            {
                foreach (ValidationFailure failure in ValidationResults.Errors)
                {
                    Console.WriteLine($"{failure.PropertyName}:{failure.ErrorMessage}");
                }
            }

            return ValidationResults.IsValid;
        }
        public bool playRound(Dictionary<int,string>move,Random random ,int j) 
        {
            Console.Write("Ange ditt drag: " + "\n");
            string value1 = Console.ReadLine();


            RockPaperScissorsModel rockPaperScissorsModel = new RockPaperScissorsModel( value1 );
            RockPaperScissorsValidator rockPaperScissorsValidator = new RockPaperScissorsValidator();
            ValidationResult validationResults = rockPaperScissorsValidator.Validate(rockPaperScissorsModel);
            bool isInputValid = ErrorMessageDiplay(validationResults);

            if (isInputValid)
            {
                #region Kommentar rektangelobjekt
                //Skapar ett rektangelobjekt från klassen Rectangle. För att använda rektangeln till att tex beräkna dess area.(uträkningen)
                #endregion

                int valueInt = int.Parse(value1);
                

                Console.WriteLine("spelarens drag: " + move[valueInt] + "\n");

                int randomNumber1 = random.Next(1, 4);
                Console.WriteLine("Datorns drag: " + move[randomNumber1] + "\n");
                Console.WriteLine(RockPaperScissors.Winner(move[valueInt], move[randomNumber1]));

                RockPaperScissors.playerComputerMoves[j] = valueInt;
                RockPaperScissors.playerComputerMoves[j + 1] = randomNumber1;
                Console.WriteLine();

                return true;
            }

            return false;
            

        }

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
            for (int i = 0; i < 3; i++)
            {
                bool playRoundBool = playRound(move, random , i*2);
                if (playRoundBool== false)
                {
                    i--;
                }
            }

            #region all rounds
            //Console.Write("Ange ditt första drag: " + "\n");
            //int value1 = int.Parse(Console.ReadLine());
            //Console.WriteLine("spelarens drag: "+move[value1]+"\n");

            //int randomNumber1 = random.Next(1, 4);
            //Console.WriteLine("Datorns drag: "+move[randomNumber1]+"\n");
            //Console.WriteLine(RockPaperScissors.Winner(move[value1],move[randomNumber1]));


            //Console.Write("Ange ditt andra drag: ");
            //int value2 = int.Parse(Console.ReadLine());
            //Console.WriteLine("spelarens drag: " + move[value2]+"\n");

            //int randomNumber2 = random.Next(1, 4);
            //Console.WriteLine("Datorns drag: "+move[randomNumber2]+"\n");
            //Console.WriteLine(RockPaperScissors.Winner(move[value2], move[randomNumber2]));

            //Console.Write("Ange ditt tredje drag: ");
            //int value3 = int.Parse(Console.ReadLine());
            //Console.WriteLine("spelarens drag: " + move[value3]+"\n");

            //int randomNumber3 = random.Next(1, 4);
            //Console.WriteLine("Datorns drag: "+move[randomNumber3]+"\n");
            //Console.WriteLine(RockPaperScissors.Winner(move[value3], move[randomNumber3]));
            #endregion

            RockPaperScissors.ShowResults();

            return RockPaperScissors.playerComputerMoves;
        }
        public void Run()
        {
            
            while (true)
            {
                Menu rockPaperScissorsMenu = new Menu();
                rockPaperScissorsMenu.NrChoices = new List<string> { "1", "2", "3",  "0"};
                rockPaperScissorsMenu.TextChoices = new List<string> {
                    "Play Game",
                    "Show latest result",
                    "Show total results",
                    "AVSLUTA"
                };
                rockPaperScissorsMenu.Display();


                string choice = Console.ReadLine();

                MenuModel myMenuModel = new MenuModel(rockPaperScissorsMenu.NrChoices.ToArray(), choice);
                MenuValidator myMenuValidator = new MenuValidator();
                ValidationResult validationResults = myMenuValidator.Validate(myMenuModel);
                bool isMenuInputValid = ErrorMessageDiplay(validationResults);


                if (isMenuInputValid)

                {

                    if (choice == "0")
                    {
                        break;
                    }




                    switch (int.Parse(choice))
                    {
                        case 1:
                            //double[] userinput = GetUserInput();
                            //Istället för att skapa en array så matar vi direkt in det som GetUserInput returnerar.
                            Console.Clear();
                            RockPaperScissors myRockPaperScissors = new RockPaperScissors(GetUserInput());

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
}
