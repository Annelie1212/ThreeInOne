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

namespace Shapes
{
    internal class ShapesApp
    {


        public static bool ErrorMessageDiplay(ValidationResult vResults)
        {
            if (vResults.IsValid == false) {
                foreach (ValidationFailure failure in vResults.Errors)
                {
                    Console.WriteLine( $"{ failure.PropertyName }:{ failure.ErrorMessage}" );
                }
            }

            return vResults.IsValid;
        }
        public void Run() 
        {
            while (true)
            {

                Menu shapesMenu = new Menu();
                shapesMenu.NrChoices = new List<string> { "1", "2", "3", "4", "0" };
                shapesMenu.TextChoices = new List<string> {
                    "Rektangel",
                    "Parallellogram",
                    "Triangel",
                    "Romb",
                    "AVSLUTA"
                };
                shapesMenu.Display();


                string choice = Console.ReadLine();

                MenuModel myMenuModel = new MenuModel(shapesMenu.NrChoices.ToArray(), choice);
                MenuValidator myMenuValidator = new MenuValidator();
                ValidationResult validationResults = myMenuValidator.Validate(myMenuModel);
                bool isInputValid = ErrorMessageDiplay(validationResults);

                if (isInputValid) 
                { 

                    switch (int.Parse(choice))
                    {
                        case 1:

                            Console.WriteLine("Ange Basenheten: ");
                            string width1 = Console.ReadLine();
                            Console.WriteLine("Ange Höjdenheten: ");
                            string height1 = Console.ReadLine();
                            Console.WriteLine();

                            RectangleModel rectangleModel = new RectangleModel(width1, height1);
                            RectangleValidator rectangleValidator = new RectangleValidator();
                            ValidationResult validationResults1 = rectangleValidator.Validate(rectangleModel);
                            bool isInputValid1 = ErrorMessageDiplay(validationResults1);

                            if (isInputValid1)
                            {
                                #region Kommentar rektangelobjekt
                                //Skapar ett rektangelobjekt från klassen Rectangle. För att använda rektangeln till att tex beräkna dess area.(uträkningen)
                                #endregion
                                Rectangle myRectangle = new Rectangle(double.Parse(width1), double.Parse(height1));
                                myRectangle.Display();
                                Console.WriteLine();
                            }

                            break;

                        case 2:
                            Console.WriteLine("Ange Basenheten: ");
                            string width2 = Console.ReadLine();
                            Console.WriteLine("Ange Höjdenheten: ");
                            string height2 = Console.ReadLine();
                            Console.WriteLine();


                            Console.WriteLine();


                            ParallellogramModel paralellogramModel = new ParallellogramModel(width2, height2);
                            ParallellogramValidator parallellogramValidator = new ParallellogramValidator();
                            ValidationResult validationResults2 = parallellogramValidator.Validate(paralellogramModel);
                            bool isInputValid2 = ErrorMessageDiplay(validationResults2);

                            if (isInputValid2)
                            {
                                #region Kommentar rektangelobjekt
                                //Skapar ett rektangelobjekt från klassen Rectangle. För att använda rektangeln till att tex beräkna dess area.(uträkningen)
                                #endregion
                                Parallellogram myParallellogram = new Parallellogram(double.Parse(width2), double.Parse(height2));
                                myParallellogram.Display();
                                Console.WriteLine();
                            }

                            break;

                        case 3:
                            Console.WriteLine("Ange Basenheten: ");
                            string width3 = Console.ReadLine();
                            Console.WriteLine("Ange Höjdenheten: ");
                            string height3 = Console.ReadLine();
                            Console.WriteLine();
                            Console.WriteLine("Ange Triangelns sida A: ");
                            string sideA = Console.ReadLine();
                            Console.WriteLine("Ange Triangelns sida B: ");
                            string sideB = Console.ReadLine();
                            Console.WriteLine("Ange Triangelns sida C: ");
                            string sideC = Console.ReadLine();
                            Console.WriteLine();

                            Console.WriteLine();

                            TriangleModel triangleModel = new TriangleModel(width3, height3, sideA, sideB, sideC);
                            TriangleValidator triangleValidator = new TriangleValidator();
                            ValidationResult validationResults3 = triangleValidator.Validate(triangleModel);
                            bool isInputValid3 = ErrorMessageDiplay(validationResults3);

                            if (isInputValid3)
                            {
                                #region Kommentar rektangelobjekt
                                //Skapar ett rektangelobjekt från klassen Rectangle. För att använda rektangeln till att tex beräkna dess area.(uträkningen)
                                #endregion
                                Triangle myTriangle = new Triangle(double.Parse(width3), double.Parse(height3),
                                                                                     double.Parse(sideA), double.Parse(sideB), double.Parse(sideC));
                                myTriangle.Display();
                                Console.WriteLine();
                            }

                            break;

                        case 4:
                            Console.WriteLine("Ange Basenheten: ");
                            string width4 = Console.ReadLine();
                            Console.WriteLine("Ange Höjdenheten: ");
                            string height4 = Console.ReadLine();
                            Console.WriteLine();
                            Console.WriteLine("Ange Rombens första diagonal: ");
                            string diagonal1 = Console.ReadLine();
                            Console.WriteLine("Ange andra diagonalen: ");
                            string diagonal2 = Console.ReadLine();
                            Console.WriteLine();

                            Console.WriteLine();

                            RhombusModel rhombusModel = new RhombusModel(width4, height4, diagonal1, diagonal2);
                            RhombusValidator rhombusValidator = new RhombusValidator();
                            ValidationResult validationResults4 = rhombusValidator.Validate(rhombusModel);
                            bool isInputValid4 = ErrorMessageDiplay(validationResults4);

                            if (isInputValid4)
                            {
                                #region Kommentar rektangelobjekt
                                //Skapar ett rektangelobjekt från klassen Rectangle. För att använda rektangeln till att tex beräkna dess area.(uträkningen)
                                #endregion
                                Rhombus myRhombus = new Rhombus(double.Parse(width4), double.Parse(height4), double.Parse(diagonal1), double.Parse(diagonal2));
                                myRhombus.Display();
                                Console.WriteLine();
                            }

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
