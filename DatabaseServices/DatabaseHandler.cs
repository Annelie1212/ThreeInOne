using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ThreeInOne.Data;

namespace ThreeInOne.DatabaseServices
{
    public class DatabaseHandler
    {
        static public DbContextOptionsBuilder<ThreeInOneAppDbContext> options { get; set; }

        public List<string> GetIds()
        {
            //READ
            List<string> Ids = new List<string>();
            using (var dbContext = new ThreeInOneAppDbContext(DatabaseHandler.options.Options))
            {
                foreach (var calculatorData in dbContext.CalculatorData)
                {
                    Ids.Add(calculatorData.CalculatorId.ToString());
                }
            }
            return Ids;
        }

        public string IdToCalculationName(string Id)
        {
            string operationName = "";
            using (var dbContext = new ThreeInOneAppDbContext(DatabaseHandler.options.Options))
            {

                foreach (var calculatorData in dbContext.CalculatorData)
                {
                    if (calculatorData.CalculatorId == int.Parse(Id))
                    {
                        operationName = calculatorData.Operation;
                        Console.WriteLine("Found operation" + calculatorData.Operation + "!");
                    }
                }
            }
            return operationName;
        }
    }
}
