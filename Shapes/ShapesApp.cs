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
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using ThreeInOne.Data;
using ThreeInOne.DatabaseServices;
using System.Drawing;
using System.Reflection.Metadata;
using Microsoft.Extensions.Options;

namespace Shapes
{
    internal class ShapesApp
    {
        public string CalculateExtraShape()
        {
            Menu shapesMenuContinue = new Menu();
            shapesMenuContinue.AppName = "Vill du göra en till?" + "\n";
            shapesMenuContinue.NrChoices = new List<string> { "1", "0" };
            shapesMenuContinue.TextChoices = new List<string> {
                            "Ja",
                            "Nej"
            };
            shapesMenuContinue.Display();
            string choiceContinue = Console.ReadLine();

            if (choiceContinue == "1")
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
        public void Run() 
        {
            string choice = "";
            while (choice!="0")
            {

                Menu shapesMenu = new Menu();
                shapesMenu.NrChoices = new List<string> { "1", "2", "3", "4", "5","6","7","0" };
                shapesMenu.TextChoices = new List<string> {
                    "Rektangel",
                    "Parallellogram",
                    "Triangel",
                    "Romb1",
                    "Romb2",
                    "Update",
                    "Delete",
                    "AVSLUTA"
                };
                shapesMenu.Display();


                choice = Console.ReadLine();

                MenuModel myMenuModel = new MenuModel(shapesMenu.NrChoices.ToArray(), choice);
                MenuValidator myMenuValidator = new MenuValidator();
                ValidationResult validationResults = myMenuValidator.Validate(myMenuModel);
                bool isInputValid = Menu.ErrorMessageDiplay(validationResults);

                if (isInputValid) 
                {
                    string choiceContinue = "";
                    while ( (choiceContinue!="0") && (choice!="0") )
                    {
                        //update=false och Id = 0 (som inte existerar!)
                        CalculateShape(choice,false,0);
                        
                        choiceContinue = CalculateExtraShape();
                    }

                }
            }
        }
        public void ShowData()
        {
            using (ThreeInOneAppDbContext dbContext = new ThreeInOneAppDbContext(DatabaseHandler.options.Options))
            {
                foreach (var shapesData in dbContext.ShapesData)
                {
                    Console.WriteLine($"ID: {shapesData.ShapesId}");
                    Console.WriteLine($"Tid: {shapesData.DateTime}");
                    Console.WriteLine($"Form: {shapesData.Shape}");
                    Console.WriteLine($"Bredd: {shapesData.Width}");
                    Console.WriteLine($"Höjd: {shapesData.Height}");
                    Console.WriteLine($"Diagonal 1: {shapesData.Diagonal1}");
                    Console.WriteLine($"Diagonal 2: {shapesData.Diagonal2}");
                    Console.WriteLine($"Sida A: {shapesData.SideA}");
                    Console.WriteLine($"Sida B: {shapesData.SideB}");
                    Console.WriteLine($"Sida C: {shapesData.SideC}");
                    Console.WriteLine($"Omkrets: {shapesData.Perimeter}");
                    Console.WriteLine($"Area: {shapesData.Area}");
                    Console.WriteLine($"Vinkel: {shapesData.AngleInDegrees}");

                    Console.WriteLine("====================");
                }
            }
        }
        public List<string> GetIds()
        {
            //READ
            List<string> Ids = new List<string>();
            using (var dbContext = new ThreeInOneAppDbContext(DatabaseHandler.options.Options))
            {
                foreach (var shapesData in dbContext.ShapesData)
                {
                    Ids.Add(shapesData.ShapesId.ToString());
                }
            }
            return Ids;
        }

        public string IdToShapeName(string Id)
        {
            string shapeName = "";
            using (var dbContext = new ThreeInOneAppDbContext(DatabaseHandler.options.Options))
            {
                
                foreach (var shapesData in dbContext.ShapesData)
                {
                    if (shapesData.ShapesId == int.Parse(Id))
                    {
                        shapeName = shapesData.Shape;
                        Console.WriteLine("Found shape"+shapesData.Shape+"!");
                    }
                }
            }
            return shapeName;
        }

        public void UpdateRow(int shapesId, DateTime dateTime, string shape, double width, double height, double diagonal1, double diagonal2,
                              double sideA, double sideB, double sideC, double perimeter, double area, double angleInDegrees)
        {
            using (var dbContext = new ThreeInOneAppDbContext(DatabaseHandler.options.Options))
            {
                var rowToUpdate = dbContext.ShapesData.First(shape => shape.ShapesId == shapesId);
                rowToUpdate.DateTime = dateTime;
                rowToUpdate.Shape = shape;
                rowToUpdate.Width = width;
                rowToUpdate.Height = height;
                rowToUpdate.Diagonal1 = diagonal1;
                rowToUpdate.Diagonal2 = diagonal2;
                rowToUpdate.SideA = sideA;
                rowToUpdate.SideB = sideB;
                rowToUpdate.SideC = sideC;
                rowToUpdate.Perimeter = perimeter;
                rowToUpdate.Area = area;
                rowToUpdate.AngleInDegrees = angleInDegrees;

                dbContext.SaveChanges();
            }
            
        }
        public void CalculateShape(string choice,bool update,int Id)
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
                    bool isInputValid1 = Menu.ErrorMessageDiplay(validationResults1);

                    if (isInputValid1)
                    {
                        #region Kommentar rektangelobjekt
                        //Skapar ett rektangelobjekt från klassen Rectangle. För att använda rektangeln till att tex beräkna dess area.(uträkningen)
                        #endregion
                        Rectangle myRectangle = new Rectangle(double.Parse(width1), double.Parse(height1));
                        myRectangle.Display();
                        Console.WriteLine();

                        DateTime dtC1 = myRectangle.CurrentDateTime;
                        string shapeC1 = myRectangle.Name;
                        double widthC1 = myRectangle.Width;
                        double heightC1 = myRectangle.Height;
                        double diagonal1C1 = 0;
                        double diagonal2C1 = 0;
                        double sideAC1 = 0;
                        double sideBC1 = 0;
                        double sideCC1 = 0;
                        double perimeterC1 = myRectangle.PerimeterResult;
                        double areaC1 = myRectangle.AreaResult;
                        double angleInDegreesC1 = 0;



                        //DATABASE CREATE
                        using (var dbContext = new ThreeInOneAppDbContext(DatabaseHandler.options.Options))
                        {

                            //UPDATE
                            if (update == true)
                            {
                                UpdateRow(Id,dtC1,shapeC1,widthC1,heightC1,diagonal1C1,diagonal2C1,sideAC1,sideBC1,sideCC1,perimeterC1,areaC1,angleInDegreesC1);
                            }
                            //CREATE
                            else
                            {
                                dbContext.ShapesData.Add(new ShapesData
                                {
                                    DateTime = myRectangle.CurrentDateTime,
                                    Shape = myRectangle.Name,
                                    Width = myRectangle.Width,
                                    Height = myRectangle.Height,
                                    Diagonal1 = 0,
                                    Diagonal2 = 0,
                                    SideA = 0,
                                    SideB = 0,
                                    SideC = 0,
                                    Perimeter = myRectangle.PerimeterResult,
                                    Area = myRectangle.AreaResult,
                                    AngleInDegrees = 0

                                });
                                dbContext.SaveChanges();
                            }
                        }
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
                    bool isInputValid2 = Menu.ErrorMessageDiplay(validationResults2);

                    if (isInputValid2)
                    {
                        #region Kommentar rektangelobjekt
                        //Skapar ett rektangelobjekt från klassen Rectangle. För att använda rektangeln till att tex beräkna dess area.(uträkningen)
                        #endregion
                        Parallellogram myParallellogram = new Parallellogram(double.Parse(width2), double.Parse(height2));
                        myParallellogram.Display();
                        Console.WriteLine();

                        DateTime dtC1 = myParallellogram.CurrentDateTime;
                        string shapeC1 = myParallellogram.Name;
                        double widthC1 = myParallellogram.Width;
                        double heightC1 = myParallellogram.Height;
                        double diagonal1C1 = 0;
                        double diagonal2C1 = 0;
                        double sideAC1 = 0;
                        double sideBC1 = 0;
                        double sideCC1 = 0;
                        double perimeterC1 = myParallellogram.PerimeterResult;
                        double areaC1 = myParallellogram.AreaResult;
                        double angleInDegreesC1 = 0;

                        //DATABASE CREATE
                        using (var dbContext = new ThreeInOneAppDbContext(DatabaseHandler.options.Options))
                        {

                            //UPDATE
                            if (update == true)
                            {
                                UpdateRow(Id, dtC1, shapeC1, widthC1, heightC1, diagonal1C1, diagonal2C1, sideAC1, sideBC1, sideCC1, perimeterC1, areaC1, angleInDegreesC1);
                            }
                            //CREATE
                            else
                            {
                                dbContext.ShapesData.Add(new ShapesData
                                {
                                    DateTime = myParallellogram.CurrentDateTime,
                                    Shape = myParallellogram.Name,
                                    Width = myParallellogram.Width,
                                    Height = myParallellogram.Height,
                                    Diagonal1 = 0,
                                    Diagonal2 = 0,
                                    SideA = 0,
                                    SideB = 0,
                                    SideC = 0,
                                    Perimeter = myParallellogram.PerimeterResult,
                                    Area = myParallellogram.AreaResult,
                                    AngleInDegrees = 0

                                });
                                dbContext.SaveChanges();
                            }
                        }
                    }

                    break;

                case 3:

                    Console.WriteLine("Ange Triangelns sida A: ");
                    string sideA = Console.ReadLine();
                    Console.WriteLine("Ange Triangelns sida B: ");
                    string sideB = Console.ReadLine();
                    Console.WriteLine("Ange vinkeln mellan sidorn i grader: ");
                    string angleInDegrees = Console.ReadLine();
                    Console.WriteLine();

                    Console.WriteLine();

                    TriangleModel triangleModel = new TriangleModel(sideA, sideB, angleInDegrees);
                    TriangleValidator triangleValidator = new TriangleValidator();
                    ValidationResult validationResults3 = triangleValidator.Validate(triangleModel);
                    bool isInputValid3 = Menu.ErrorMessageDiplay(validationResults3);

                    if (isInputValid3)
                    {
                        Triangle myTriangle = new Triangle(double.Parse(sideA), double.Parse(sideB), double.Parse(angleInDegrees));
                        myTriangle.Display();
                        Console.WriteLine();

                        DateTime dtC1 = myTriangle.CurrentDateTime;
                        string shapeC1 = myTriangle.Name;
                        double widthC1 = 0;
                        double heightC1 = 0;
                        double diagonal1C1 = 0;
                        double diagonal2C1 = 0;
                        double sideAC1 = myTriangle.SideA;
                        double sideBC1 = myTriangle.SideB;
                        double sideCC1 = myTriangle.SideC;
                        double perimeterC1 = myTriangle.PerimeterResult;
                        double areaC1 = myTriangle.AreaResult;
                        double angleInDegreesC1 = myTriangle.AngleInDegrees;

                        //DATABASE CREATE
                        using (var dbContext = new ThreeInOneAppDbContext(DatabaseHandler.options.Options))
                        {
                            //UPDATE
                            if (update == true)
                            {
                                UpdateRow(Id, dtC1, shapeC1, widthC1, heightC1, diagonal1C1, diagonal2C1, sideAC1, sideBC1, sideCC1, perimeterC1, areaC1, angleInDegreesC1);
                            }
                            //CREATE
                            else
                            {
                                dbContext.ShapesData.Add(new ShapesData
                                {
                                    DateTime = myTriangle.CurrentDateTime,
                                    Shape = myTriangle.Name,
                                    Width = 0,
                                    Height = 0,
                                    Diagonal1 = 0,
                                    Diagonal2 = 0,
                                    SideA = myTriangle.SideA,
                                    SideB = myTriangle.SideB,
                                    SideC = myTriangle.SideC,
                                    AngleInDegrees = myTriangle.AngleInDegrees,
                                    Perimeter = myTriangle.PerimeterResult,
                                    Area = myTriangle.AreaResult,
                                });
                                dbContext.SaveChanges();
                            }
                        }
                    }

                    break;

                case 4:
                    Console.WriteLine("Första romben");
                    Console.WriteLine("Ange Basenheten: ");
                    string width4 = Console.ReadLine();
                    Console.WriteLine("Ange Höjdenheten: ");
                    string height4 = Console.ReadLine();

                    Console.WriteLine();

                    string diagonal1 = "1";
                    string diagonal2 = "1";
                    RhombusModel rhombusModel = new RhombusModel(width4, height4, diagonal1, diagonal2);
                    RhombusValidator rhombusValidator = new RhombusValidator();
                    ValidationResult validationResults4 = rhombusValidator.Validate(rhombusModel);
                    bool isInputValid4 = Menu.ErrorMessageDiplay(validationResults4);

                    if (isInputValid4)
                    {
                        #region Kommentar rektangelobjekt
                        //Skapar ett rektangelobjekt från klassen Rectangle. För att använda rektangeln till att tex beräkna dess area.(uträkningen)
                        #endregion
                        Rhombus myRhombus = new Rhombus(double.Parse(width4), double.Parse(height4), double.Parse(diagonal1), double.Parse(diagonal2));
                        myRhombus.Display1();
                        Console.WriteLine();

                        DateTime dtC1 = myRhombus.CurrentDateTime;
                        string shapeC1 = myRhombus.Name1;
                        double widthC1 = myRhombus.Width1;
                        double heightC1 = myRhombus.Height1;
                        double diagonal1C1 = 0;
                        double diagonal2C1 = 0;
                        double sideAC1 = 0;
                        double sideBC1 = 0;
                        double sideCC1 = 0;
                        double perimeterC1 = myRhombus.PerimeterResult;
                        double areaC1 = myRhombus.AreaResult;
                        double angleInDegreesC1 = 0;

                        //DATABASE CREATE
                        using (var dbContext = new ThreeInOneAppDbContext(DatabaseHandler.options.Options))
                        {

                            //UPDATE
                            if (update == true)
                            {
                                UpdateRow(Id, dtC1, shapeC1, widthC1, heightC1, diagonal1C1, diagonal2C1, sideAC1, sideBC1, sideCC1, perimeterC1, areaC1, angleInDegreesC1);
                            }
                            //CREATE
                            else
                            {
                                dbContext.ShapesData.Add(new ShapesData
                                {
                                    DateTime = myRhombus.CurrentDateTime,
                                    Shape = myRhombus.Name1,
                                    Width = myRhombus.Width1,
                                    Height = myRhombus.Height1,
                                    Diagonal1 = 0,
                                    Diagonal2 = 0,
                                    SideA = 0,
                                    SideB = 0,
                                    SideC = 0,
                                    Perimeter = myRhombus.PerimeterResult,
                                    Area = myRhombus.AreaResult,
                                    AngleInDegrees = 0

                                });
                                dbContext.SaveChanges();
                            }
                        }
                    }
                    break;

                case 6:
                    //READ

                    ShowData();

                    Menu updateMenu = new Menu();
                    updateMenu.NrChoices = new List<string> { "0" };
                    updateMenu.TextChoices = new List<string> {
                                    "Choose ID:",
                                };
                    updateMenu.Display();
                    //Lägger existerande ID-nummer i menyobjektet.
                    updateMenu.NrChoices = GetIds();

                    string myID = Console.ReadLine();

                    MenuModel myUpdateMenuModel = new MenuModel(updateMenu.NrChoices.ToArray(), myID);
                    MenuValidator myUpdateMenuValidator = new MenuValidator();
                    ValidationResult updateMenuValidationResults = myUpdateMenuValidator.Validate(myUpdateMenuModel);
                    bool isIDValid = Menu.ErrorMessageDiplay(updateMenuValidationResults);

                    if (isIDValid)
                    {
                        string myShape = IdToShapeName(myID);
                        Dictionary<string,int> shapeNameToShapeCaseNr = new Dictionary<string, int>
                        {
                            {"Rectangle",1 },
                            {"Parallellogram",2 },
                            {"Triangle",3 },
                            {"Rhombus1",4 },
                            {"Rhombus2",5 }
                        };
                        //Parameters: (shapeCaseNr,update,myID)
                        CalculateShape(shapeNameToShapeCaseNr[myShape].ToString(), true, int.Parse(myID));
                    }
                    Console.WriteLine();
                    break;

                case 7:
                    //READ

                    ShowData();

                    Menu deleteMenu = new Menu();
                    deleteMenu.NrChoices = new List<string> { "0" };
                    deleteMenu.TextChoices = new List<string> {
                                    "Choose ID:",
                                };
                    deleteMenu.Display();
                    //Lägger existerande ID-nummer i menyobjektet.
                    deleteMenu.NrChoices = GetIds();

                    string myIDdelete = Console.ReadLine();

                    MenuModel myDeleteMenuModel = new MenuModel(deleteMenu.NrChoices.ToArray(), myIDdelete);
                    MenuValidator myDeleteMenuValidator = new MenuValidator();
                    ValidationResult deleteMenuValidationResults = myDeleteMenuValidator.Validate(myDeleteMenuModel);
                    bool isIDValidDelete = Menu.ErrorMessageDiplay(deleteMenuValidationResults);

                    if (isIDValidDelete)
                    {
                        string myShape = IdToShapeName(myIDdelete);
                        Dictionary<string, int> shapeNameToShapeCaseNr = new Dictionary<string, int>
                        {
                            {"Rectangle",1 },
                            {"Parallellogram",2 },
                            {"Triangle",3 },
                            {"Rhombus1",4 },
                            {"Rhombus2",5 }
                        };
                        //Parameters: (shapeCaseNr,update,myID)
                        //CalculateShape(shapeNameToShapeCaseNr[myShape].ToString(), true, int.Parse(myID));
                        using (var dbContext = new ThreeInOneAppDbContext(DatabaseHandler.options.Options))
                        {
                            var rowToDelete = dbContext.ShapesData.First(shape => shape.ShapesId == int.Parse(myIDdelete));
                            dbContext.ShapesData.Remove(rowToDelete);

                            dbContext.SaveChanges();
                        }
                    }
                    Console.WriteLine();
                    break;

                case 5:

                    Console.WriteLine("Andra romben");
                    Console.WriteLine("Ange rombens första diagonal: ");
                    string diagonal12 = Console.ReadLine();
                    Console.WriteLine("Ange andra diagonalen: ");
                    string diagonal22 = Console.ReadLine();
                    Console.WriteLine();

                    Console.WriteLine();

                    //1 och 1 är dummy-ettor
                    string width42 = "1";
                    string height42 = "1";
                    RhombusModel rhombusModel2 = new RhombusModel(width42, height42, diagonal12, diagonal22);
                    RhombusValidator rhombusValidator2 = new RhombusValidator();
                    ValidationResult validationResults42 = rhombusValidator2.Validate(rhombusModel2);
                    bool isInputValid42 = Menu.ErrorMessageDiplay(validationResults42);

                    if (isInputValid42)
                    {
                        #region Kommentar rektangelobjekt
                        //Skapar ett rektangelobjekt från klassen Rectangle. För att använda rektangeln till att tex beräkna dess area.(uträkningen)
                        #endregion
                        Rhombus myRhombus = new Rhombus(double.Parse(width42), double.Parse(height42), double.Parse(diagonal12), double.Parse(diagonal22));
                        myRhombus.Display2();
                        Console.WriteLine();

                        DateTime dtC1 = myRhombus.CurrentDateTime;
                        string shapeC1 = myRhombus.Name2;
                        double widthC1 = 0;
                        double heightC1 = 0;
                        double diagonal1C1 = myRhombus.Diagonal1;
                        double diagonal2C1 = myRhombus.Diagonal2;
                        double sideAC1 = 0;
                        double sideBC1 = 0;
                        double sideCC1 = 0;
                        double perimeterC1 = myRhombus.PerimeterResult;
                        double areaC1 = myRhombus.AreaResult;
                        double angleInDegreesC1 = 0;

                        //DATABASE CREATE
                        using (var dbContext = new ThreeInOneAppDbContext(DatabaseHandler.options.Options))
                        {

                            //UPDATE
                            if (update == true)
                            {
                                UpdateRow(Id, dtC1, shapeC1, widthC1, heightC1, diagonal1C1, diagonal2C1, sideAC1, sideBC1, sideCC1, perimeterC1, areaC1, angleInDegreesC1);
                            }
                            //CREATE
                            else
                            {
                                dbContext.ShapesData.Add(new ShapesData
                                {
                                    DateTime = myRhombus.CurrentDateTime,
                                    Shape = myRhombus.Name2,
                                    Width = 0,
                                    Height = 0,
                                    Diagonal1 = myRhombus.Diagonal1,
                                    Diagonal2 = myRhombus.Diagonal2,
                                    SideA = 0,
                                    SideB = 0,
                                    SideC = 0,
                                    Perimeter = myRhombus.DiagonalPerimeterResult,
                                    Area = myRhombus.DiagonalAreaResult,
                                    AngleInDegrees = 0
                                });
                                dbContext.SaveChanges();
                            }
                        }
                    }
                    break;

                default:
                    break;
            }
        }

    }
}
