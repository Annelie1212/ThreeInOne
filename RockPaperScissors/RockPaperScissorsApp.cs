using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeInOne;
using ThreeInOne.Data;

using FluentValidation;
using FluentValidation.Results;
using System.ComponentModel;
//using ThreeInOne;

using System.Windows;
using Microsoft.Extensions.Options;
using ThreeInOne.DatabaseServices;

namespace RockPaperScissors

{
    public class RockPaperScissorsApp
    {
        public void Run()
        {
            
            while (true)
            {
                Menu rockPaperScissorsMenu = new Menu();
                rockPaperScissorsMenu.AppName = "Sten Sax Påse"+"\n";
                rockPaperScissorsMenu.NrChoices = new List<string> { "1", "2", "3",  "0"};
                rockPaperScissorsMenu.TextChoices = new List<string> {
                    "Play Game",
                    "Show total round result",
                    "Show total match results",
                    "AVSLUTA"
                };
                rockPaperScissorsMenu.Display();


                string choice = Console.ReadLine();

                MenuModel myMenuModel = new MenuModel(rockPaperScissorsMenu.NrChoices.ToArray(), choice);
                MenuValidator myMenuValidator = new MenuValidator();
                ValidationResult validationResults = myMenuValidator.Validate(myMenuModel);
                bool isMenuInputValid = Menu.ErrorMessageDiplay(validationResults);


                if (isMenuInputValid)

                {

                    if (choice == "0")
                    {
                        break;
                    }



                    Console.Clear();
                    RockPaperScissors myRockPaperScissors = new RockPaperScissors();
                    switch (int.Parse(choice))
                    {
                        case 1:
                            myRockPaperScissors.PlayMatch();
                            Console.Write("\n" + "Tryck på valfri knapp för att fortsätta...");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case 2:
                            myRockPaperScissors.ShowTotalRounds();
                            Console.Write("\n" + "Tryck på valfri knapp för att fortsätta...");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case 3:
                            myRockPaperScissors.ShowTotalResults();
                            Console.Write("\n" + "Tryck på valfri knapp för att fortsätta...");
                            Console.ReadLine();
                            Console.Clear();
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
