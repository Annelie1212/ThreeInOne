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
                Menu rpsMenu = new Menu(MenuData.RPSMenuNr, MenuData.RPSMenu);
                rpsMenu.AppName = MenuData.RPSMenuName;
                rpsMenu.Display();
                string choice = Console.ReadLine();

                MenuModel myMenuModel = new MenuModel(rpsMenu.NrChoices.ToArray(), choice);
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
                            bool gameOver = false;
                            while (gameOver != true)
                            { 
                                gameOver = myRockPaperScissors.PlayMatch();
                                Console.Write(MenuData.pressEnter);
                                Console.ReadLine();
                                Console.Clear();
                            }
                            break;
                        case 2:
                            myRockPaperScissors.ShowTotalRounds();
                            Console.Write(MenuData.pressEnter);
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case 3:
                            myRockPaperScissors.ShowTotalResults();
                            Console.Write(MenuData.pressEnter);
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case 4:
                            myRockPaperScissors.ShowPlayerResults();
                            Console.Write(MenuData.pressEnter);
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
