using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeInOne
{
    

    public class MenuData
    {

        public static string ShapesMenuName = "Shapes App\n";
        public static List<string> ShapesMenuNr = new List<string> { "1", "2", "3", "4", "5", "6", "7","0","" };
        public static List<string> ShapesMenu = new List<string> {
                    ". Rektangel",
                    ". Parallellogram",
                    ". Triangel",
                    ". Romb 1 (bredd och höjd)",
                    ". Romb 2 (diagonaler)",
                    ". Update",
                    ". Delete",
                    ". AVSLUTA/BACKA",
                    "\nVal:"
                    };

        public static string RectangleMenuName = "Rektangel\n";
        public static List<string> RectangleMenuNr1 = new List<string> { ""};
        public static List<string> RectangleMenu1 = new List<string> {
                    "Ange basen:"
                    };
        public static List<string> RectangleMenuNr2 = new List<string> { "" };
        public static List<string> RectangleMenu2 = new List<string> {
                    "Ange höjden:"
                    };

        public static string ParallellogramMenuName = "Parallellogram\n";
        public static List<string> ParallellogramMenuNr1 = new List<string> { "" };
        public static List<string> ParallellogramMenu1 = new List<string> {
                    "Ange basen:"
                    };
        public static List<string> ParallellogramMenuNr2 = new List<string> { "" };
        public static List<string> ParallellogramMenu2 = new List<string> {
                    "Ange höjden:"
                    };

        public static string TriangleMenuName = "Triangel\n";
        public static List<string> TriangleMenuNr1 = new List<string> { "" };
        public static List<string> TriangleMenu1 = new List<string> {
                    "Ange sida A:"
                    };
        public static List<string> TriangleMenuNr2 = new List<string> { "" };
        public static List<string> TriangleMenu2 = new List<string> {
                    "Ange sida B:"
                    };
        public static List<string> TriangleMenuNr3 = new List<string> { "" };
        public static List<string> TriangleMenu3 = new List<string> {
                    "Ange vinkeln mellan sidorna i grader:"
                    };

        public static string Romb1MenuName = "Romb 1\n";
        public static List<string> Romb1MenuNr1 = new List<string> { "" };
        public static List<string> Romb1Menu1 = new List<string> {
                    "Ange basen:"
                    };
        public static List<string> Romb1MenuNr2 = new List<string> { "" };
        public static List<string> Romb1Menu2 = new List<string> {
                    "Ange höjden:"
                    };
        public static string Romb2MenuName = "Romb 2\n";
        public static List<string> Romb2MenuNr1 = new List<string> { "" };
        public static List<string> Romb2Menu1 = new List<string> {
                    "Ange diagonal 1:"
                    };
        public static List<string> Romb2MenuNr2 = new List<string> { "" };
        public static List<string> Romb2Menu2 = new List<string> {
                    "Ange diagonal 2:"
                    };


        public static string CalculatorMenuName = "Kalkylator\n";
        public static List<string> CalculatorMainMenuNr  = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "0","" };
        public static List<string> CalculatorMainMenu = new List<string> {
                    ". Addition",
                    ". Subtraktion",
                    ". Multiplikation",
                    ". Division",
                    ". Roten Ur",
                    ". Modulo",
                    ". Update",
                    ". Delete",
                    ". AVSLUTA/BACKA",
                    "\nVal:"
                    };

        public static string MainMenuName = "Three In One App\n";
        public static List<string> MainMenuNr = new List<string> { "1", "2", "3", "0","" };
        public static List<string> MainMenu = new List<string> {
                    ". Shapes App",
                    ". Calculator App",
                    ". Rock Paper Scissors",
                    ". AVSLUTA",
                    "\nVal:"
                    };

        public static List<string> CalculatorCalculationMenuNr1 = new List<string> { "" };
        public static List<string> CalculatorCalculationMenu1 = new List<string> { "Ange tal 1:" };
        public static List<string> CalculatorCalculationMenuNr2 = new List<string> { "" };
        public static List<string> CalculatorCalculationMenu2 = new List<string> { "Ange tal 2:" };

        public static string ExtraCalculationName = "Vill du göra en till?" + "\n";
        public static List<string> ExtraCalculationNr = new List<string> { "1","0","" };
        public static List<string> ExtraCalculationMenu = new List<string> { ". Ja",". Nej","\nVal:" };

        public static string UpdateCalculationName = "UPDATE";
        public static List<string> UpdateCalculationNr = new List<string> { "" };
        public static List<string> UpdateCalculationMenu = new List<string> { "Välj ID att uppdatera:" };

        public static string ExtraCalculationUpdateName = "Vill du göra om uppdateringen?" + "\n";
        public static List<string> ExtraCalculationUpdateNr = new List<string> { "1", "0","" };
        public static List<string> ExtraCalculationUpdateMenu = new List<string> { ". Ja", ". Nej","nVal:" };

        public static string DeleteCalculationName = "DELETE";
        public static List<string> DeleteCalculationNr = new List<string> { "" };
        public static List<string> DeleteCalculationMenu = new List<string> { "Välj ID att radera:" };

        public static string InsertNameName = "";
        public static List<string> InsertNameNr = new List<string> { "" };
        public static List<string> InsertNameMenu = new List<string> { "Skriv ditt namn:" };

        public static string RPSMenuName = "Rock Paper Scissors App\n";
        public static List<string> RPSMenuNr = new List<string> { "1", "2", "3","4", "0", "" };
        public static List<string> RPSMenu = new List<string> {
                    ". Spela",
                    ". Visa resultat från alla rundor",
                    ". Visa resultat från alla matcher ",
                    ". Visa resultat för alla spelare",
                    ". AVSLUTA/BACKA",
                    "\nVal:"
                    };

        public static string pressEnter = "\n" + "Tryck på Enter för att fortsätta...";

        public static string RPSMatchMenuName = "Rock Paper Scissors App\n";
        public static List<string> RPSMatchMenuNr = new List<string> { "1", "2", "3","" };
        public static List<string> RPSMatchMenu = new List<string> {
                    ". Sten",
                    ". Sax",
                    ". Påse",
                    "\nAnge ditt drag:"
                    };

        public static string playersMove = "Spelarens drag: ";
        public static string computersMove = "Datorns drag: ";
        public static string playerWins = "Spelaren vann!";
        public static string computerWins = "Datorn vann";
        public static string tie = "Ställningen blev lika";
    }

}
