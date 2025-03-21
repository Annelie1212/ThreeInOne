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
using System.Xml.Serialization;
using Microsoft.Identity.Client;
using System.Runtime.InteropServices;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using ThreeInOne.Data;
using ThreeInOne.DatabaseServices;
using System.ComponentModel.Design;

namespace Calculator
{
    internal class CalculatorApp
    {

        public void CalculateExtraCalculation(Calculator myCalculator,string choice)
        {
            while (true)
            {
                Menu calculatorMenuContinue = new Menu(MenuData.ExtraCalculationNr,
                                                       MenuData.ExtraCalculationMenu);
                calculatorMenuContinue.AppName = MenuData.ExtraCalculationName;
                calculatorMenuContinue.Display();

                string choiceContinue = Console.ReadLine();
                AppValidation userInputIsValid = new AppValidation(new MenuModel(calculatorMenuContinue.NrChoices.ToArray(),
                                                                choiceContinue));
                //bool isMenuInputValid = userInputIsValid.ValidateMenuModel();

                if (userInputIsValid.ValidateMenuModel())
                {
                    if (choiceContinue == "0")
                    {
                        break;
                    }
                    myCalculator.Calculate(choice,GetUserInput());
                }
            }
        }
        public void CalculateExtraCalculationUpdate(Calculator myCalculator, string choice)
        {
            while (true)
            {
                Menu calculatorMenuUpdateContinue = new Menu(MenuData.ExtraCalculationUpdateNr,
                                                       MenuData.ExtraCalculationUpdateMenu);
                calculatorMenuUpdateContinue.AppName = MenuData.ExtraCalculationUpdateName;
                calculatorMenuUpdateContinue.Display();

                string choiceUpdateContinue = Console.ReadLine();
                AppValidation userInputIsValid = new AppValidation(new MenuModel(calculatorMenuUpdateContinue.NrChoices.ToArray(),
                                                                choiceUpdateContinue));
                //bool isMenuInputValid = userInputIsValid.ValidateMenuModel();

                if (userInputIsValid.ValidateMenuModel())
                {
                    if (choiceUpdateContinue == "0")
                    {
                        break;
                    }
                    myCalculator.Calculate(choice, GetUserInput());
                }
            }
        }
        public string[] GetUserInput()
        {
            Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");

            Menu calculationMenu1 = new Menu(MenuData.CalculatorCalculationMenuNr1, MenuData.CalculatorCalculationMenu1);
            calculationMenu1.Display();
            string value1 = Console.ReadLine();

            Menu calculationMenu2 = new Menu(MenuData.CalculatorCalculationMenuNr2, MenuData.CalculatorCalculationMenu2);
            calculationMenu2.Display();
            string value2 = Console.ReadLine();

            return new string[] { value1, value2 };
        }

        
        public void Run() 
        {
            string choice = "";
            while (choice!="0")
            {
                Menu calculatorMenu = new Menu(MenuData.CalculatorMainMenuNr, MenuData.CalculatorMainMenu);
                calculatorMenu.Display();

                choice = Console.ReadLine();

                AppValidation appValidation = new AppValidation(new MenuModel(calculatorMenu.NrChoices.ToArray(),
                                                                choice));
                bool isMenuInputValid = appValidation.ValidateMenuModel();

                if (isMenuInputValid && choice!="0")
                {
                    if (choice == "7")
                    {
                        //READ AND UPDATE
                        Calculator.Read();

                        Menu updateMenu = new Menu(MenuData.UpdateCalculationNr, MenuData.UpdateCalculationMenu);
                        updateMenu.AppName = MenuData.UpdateCalculationName;
                        updateMenu.Display();
                        string choiceId = Console.ReadLine();

                        //SKicka in alla tal i array från databas
                        DatabaseHandler calculationDatabaseHandler = new DatabaseHandler();
                        List<string> dataBaseIds = calculationDatabaseHandler.GetIds();

                        AppValidation updateValidation = new AppValidation(new MenuModel(dataBaseIds.ToArray(),
                                                                choiceId));
                        bool isUpdateInputValid = updateValidation.ValidateMenuModel();
                        if (isUpdateInputValid)
                        {
                            Calculator myCalculator = new Calculator();

                            string calcName = calculationDatabaseHandler.IdToCalculationName(choiceId);

                            Dictionary<string, int> calcNameToCalcCaseNr = new Dictionary<string, int>
                            {
                                {"Summan",1 },
                                {"Differensen",2 },
                                {"Produkten",3 },
                                {"Kvoten",4 },
                                {"X:te roten ur",5 },
                                {"Modulo",6 }
                            };
                            choice = calcNameToCalcCaseNr[calcName].ToString();

                            //Ingen ny variabel. Beräkningen sparas ju direkt i kalkylatorobjektet här!
                            myCalculator.Calculate(choice, GetUserInput());
                            CalculateExtraCalculationUpdate(myCalculator, choice);
                            myCalculator.UpdateRow(int.Parse(choiceId));
                        }

                    }
                    else if(choice == "8")

                        //Delite
                    {
                        Calculator.Read();

                        Menu deleteMenu = new Menu(MenuData.DeleteCalculationNr, MenuData.DeleteCalculationMenu);
                        deleteMenu.AppName = MenuData.DeleteCalculationName;
                        deleteMenu.Display();
                        string choiceId = Console.ReadLine();

                        DatabaseHandler calculationDatabaseHandler = new DatabaseHandler();
                        List<string> dataBaseIds = calculationDatabaseHandler.GetIds();

                        AppValidation deleteValidation = new AppValidation(new MenuModel(dataBaseIds.ToArray(),
                                                                choiceId));
                        bool isDeleteInputValid = deleteValidation.ValidateMenuModel();
                        if (isDeleteInputValid)
                        {
                            Calculator myCalculator = new Calculator();
                            myCalculator.DeleteRow(int.Parse(choiceId));
                        }

                    }

                    else
                    {
                        Calculator myCalculator = new Calculator();
                        myCalculator.Calculate(choice, GetUserInput());
                        CalculateExtraCalculation(myCalculator, choice);
                    }
                }
            }
        }
    }
}
