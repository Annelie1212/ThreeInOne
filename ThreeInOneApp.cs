using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;
using FluentValidation.Results;

using Shapes;
using Calculator;
using RockPaperScissors;

using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using ThreeInOne.Data;
using ThreeInOne.DatabaseServices;

namespace ThreeInOne
{
    internal class ThreeInOneApp
    {
        public static bool ErrorMessageDiplay(ValidationResult validationResults)
        {
            if (validationResults.IsValid == false)
            {
                foreach (ValidationFailure failure in validationResults.Errors)
                {
                    Console.WriteLine($"{failure.ErrorMessage}");
                }
            }

            return validationResults.IsValid;
        }
        public void Run()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
            IConfigurationRoot config = builder.Build();
            DatabaseHandler.options = new DbContextOptionsBuilder<ThreeInOneAppDbContext>();
            string connectionString = config.GetConnectionString("DefaultConnection");
            DatabaseHandler.options.UseSqlServer(connectionString);

            using (var dbContext = new ThreeInOneAppDbContext(DatabaseHandler.options.Options))
            {
                dbContext.Database.Migrate();
            }

            while (true)
            {
                Console.WriteLine("Three In One App");
                Menu mainMenu = new Menu();
                mainMenu.NrChoices = new List<string> { "1","2","3","0" };
                mainMenu.TextChoices = new List<string> {
                    "Shapes App",
                    "Calculator App",
                    "Rock Paper Scissors App",
                    "AVSULTA"
                };
                mainMenu.Display();



                //Console.WriteLine("MENY\nVälj en siffra ur menyn");
                //Console.WriteLine("1 Shapes App");
                //Console.WriteLine("2 Calculator App");
                //Console.WriteLine("3 Rock Paper Scissors App");
                //Console.WriteLine("0 AVSLUTA\n");

                string choice = Console.ReadLine();
                Console.Clear();

                MenuModel myMenuModel = new MenuModel(mainMenu.NrChoices.ToArray(),choice);
                MenuValidator myMenuValidator = new MenuValidator();
                ValidationResult ValidationResults = myMenuValidator.Validate(myMenuModel);
                bool isInputValid = ErrorMessageDiplay(ValidationResults);
                if (isInputValid)
                {

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
