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
            //Boiler plate kod som behövs för att initiera (starta) databasen och synka migreringar.
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
                //Skapar ett menyobjekt.
                Menu mainMenu = new Menu(MenuData.MainMenuNr, MenuData.MainMenu);
                //Settar menytiteln.
                mainMenu.AppName = MenuData.MainMenuName;
                //VIsar menyn.
                mainMenu.Display();
                string choice = Console.ReadLine();
                Console.Clear();

                //Skickar in menymodel och användarinmatning till FluentValidation.
                AppValidation appValidation = new AppValidation(new MenuModel(mainMenu.NrChoices.ToArray(),
                                                                              choice));
                bool isMenuInputValid = appValidation.ValidateMenuModel();

                if (isMenuInputValid)
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
