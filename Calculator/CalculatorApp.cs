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

namespace Calculator
{
    internal class CalculatorApp
    {

        public static bool ErrorMessageDiplay(ValidationResult validationResults)
        {
            if (validationResults.IsValid == false)
            {
                foreach (ValidationFailure failure in validationResults.Errors)
                {
                    Console.WriteLine($"{failure.PropertyName}:{failure.ErrorMessage}");
                }
            }

            return validationResults.IsValid;
        }


        public string[] GetUserInput()
        {

            Console.WriteLine("Ange tal 1: ");
            string value1 = Console.ReadLine();
            Console.WriteLine("Ange tal 2: ");
            string value2 = Console.ReadLine();

            string[] userInput = { value1, value2 };


            return userInput;
        }
        public void Run() 
        {
            while (true)
            {
                Menu calculatorMenu = new Menu();
                calculatorMenu.NrChoices = new List<string> { "1", "2", "3", "4", "5", "6", "0" };
                calculatorMenu.TextChoices = new List<string> {
                    "Addition",
                    "Subtraktion",
                    "Multiplikation",
                    "Division",
                    "Roten Ur",
                    "Modulo",
                    "AVSLUTA"
                };
                calculatorMenu.Display();


                string choice = Console.ReadLine();

                MenuModel myMenuModel = new MenuModel(calculatorMenu.NrChoices.ToArray(), choice);
                MenuValidator myMenuValidator = new MenuValidator();
                ValidationResult validationResults = myMenuValidator.Validate(myMenuModel);
                bool isMenuInputValid = ErrorMessageDiplay(validationResults);


                if (isMenuInputValid)

                {

                    if (choice == "0")
                    {
                        break;
                    }

                    DateTime currentDateTime = DateTime.Now;
                    Console.WriteLine($"{currentDateTime.ToString("yyyy-MM-dd HH:mm:ss")}");

                    string[] userInput = GetUserInput();


                    CalculatorModel myCalculatorModel = new CalculatorModel(userInput[0], userInput[1]);
                    CalculatorValidator myCalculatorValidator = new CalculatorValidator();
                    ValidationResult ValidationResults = myCalculatorValidator.Validate(myCalculatorModel);
                    bool isInputValid = ErrorMessageDiplay(ValidationResults);


                    if (isInputValid)
                    {
                        #region Kommentar rektangelobjekt
                        //Skapar ett rektangelobjekt från klassen Rectangle. För att använda rektangeln till att tex beräkna dess area.(uträkningen)
                        #endregion

                        double userValue1 = double.Parse(userInput[0]);
                        double userValue2 = double.Parse(userInput[1]);
                        double[] userValues = new double[] { userValue1, userValue2 };

                        Calculator myCalculator = new Calculator(userValues, currentDateTime);

                        Console.WriteLine();

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

                                break;

                            case 4:

                                myCalculator.Divide();
                                myCalculator.Display();

                                break;

                            case 5:

                                myCalculator.Square();
                                myCalculator.Display();

                                break;

                            case 6:

                                myCalculator.Modulus();
                                myCalculator.Display();

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
}
