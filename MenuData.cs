using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeInOne
{
    public class MenuData
    {
        public static List<string> CalculatorMainMenuNr  = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "0" };
        public static List<string> CalculatorMainMenu = new List<string> {
                    ". Addition",
                    ". Subtraktion",
                    ". Multiplikation",
                    ". Division",
                    ". Roten Ur",
                    ". Modulo",
                    ". Update",
                    ". Delete",
                    ". AVSLUTA"
                    };
        public static List<string> CalculatorCalculationMenuNr1 = new List<string> { "" };
        public static List<string> CalculatorCalculationMenu1 = new List<string> { "Ange tal 1:" };
        public static List<string> CalculatorCalculationMenuNr2 = new List<string> { "" };
        public static List<string> CalculatorCalculationMenu2 = new List<string> { "Ange tal 2:" };

        public static string ExtraCalculationName = "Vill du göra en till?" + "\n";
        public static List<string> ExtraCalculationNr = new List<string> { "1","0" };
        public static List<string> ExtraCalculationMenu = new List<string> { ". Ja",". Nej" };

        public static string UpdateCalculationName = "UPDATE";
        public static List<string> UpdateCalculationNr = new List<string> { "" };
        public static List<string> UpdateCalculationMenu = new List<string> { "Välj ID att uppdatera:" };

        public static string ExtraCalculationUpdateName = "Vill du göra om uppdateringen?" + "\n";
        public static List<string> ExtraCalculationUpdateNr = new List<string> { "1", "0" };
        public static List<string> ExtraCalculationUpdateMenu = new List<string> { ". Ja", ". Nej" };

        public static string DeleteCalculationName = "DELETE";
        public static List<string> DeleteCalculationNr = new List<string> { "" };
        public static List<string> DeleteCalculationMenu = new List<string> { "Välj ID att radera:" };
    }
}
