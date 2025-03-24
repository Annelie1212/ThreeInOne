using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeInOne;
using ThreeInOne.Data;
using ThreeInOne.DatabaseServices;

namespace Calculator
{

    internal class Calculator
    {

        public string Operator { get; set; }
        public double UserValue1 { get; set; }
        public double UserValue2 { get; set; }

        public double Result {  get; set; }
        public DateTime CurrentDateTime { get; set; }

        public Calculator() { }
        //public Calculator(string[] userValues,DateTime currentDateTime) 
        //{
        //    this.UserValue1 = double.Parse(userValues[0]);
        //    this.UserValue2 = double.Parse(userValues[1]); 
        //    this.CurrentDateTime = currentDateTime;
        //    this.Operator = "";
        //}
        public double Add() 
        {
            this.Operator = "Summan";
            this.Result = UserValue1 + UserValue2;
            return Result;
        }
        public double Subtract()
        {
            this.Operator = "Differensen";
            this.Result = UserValue1 - UserValue2;
            return Result;
        }
        public double Multiply()
        {
            this.Operator = "Produkten";
            this.Result = UserValue1 * UserValue2;
            return Result;
        }
        public double Divide()
        {
            this.Operator = "Kvoten";
            this.Result = UserValue1 / UserValue2;
            return Result;
        }
        public double Square()
        {
            Console.WriteLine("Tal 1 = basen");
            Console.WriteLine("Tal 2 = x:te roten ur tal 1");
            this.Operator = "X:te roten ur";
            this.Result = Math.Pow(UserValue1, 1/UserValue2);
            return Result;
        }
        public double Modulus()
        {
            this.Operator = "Modulo";
            //I c-sharp måste man ändra lite i moduloberäkningen för att få riktig moduloberäkning.
            //Från GeeksForGeeks:
            this.Result = ( UserValue1 % UserValue2 + UserValue2 ) % UserValue2;
            return Result;
        }
        public void DisplayDate()
        {
            Console.WriteLine($"{CurrentDateTime.ToString("yyyy-MM-dd HH:mm:ss")}");
        }
        public void Display()
        {
            Console.WriteLine();
      
            Console.WriteLine($"första talet är: {UserValue1} och andra talet är: {UserValue2}");
            Console.WriteLine($"{Operator} = {Result} ");
            Console.WriteLine();
          
        }
        public void Calculate(string choice,string[] userInput)
        {


            CurrentDateTime = DateTime.Now;
            Console.WriteLine($"{CurrentDateTime.ToString("yyyy-MM-dd HH:mm:ss")}");

            AppValidation userInputValidation = new AppValidation(new CalculatorModel(userInput[0], 
                                                                                      userInput[1],
                                                                                      choice));
            bool isUserInputValid = userInputValidation.ValidateCalculatorModel();

            if (isUserInputValid)
            {
                this.UserValue1 = double.Parse(userInput[0]);
                this.UserValue2 = double.Parse(userInput[1]); 
                switch (int.Parse(choice))
                {
                    case 1:
                        Add();
                        break;
                    case 2:
                        Subtract();
                        break;
                    case 3:
                        Multiply();
                        break;
                    case 4:
                        Divide();
                        break;
                    case 5:
                        Square();
                        break;
                    case 6:
                        Modulus();
                        break;
                    default:
                        break;
                }
                this.Result = Math.Round(this.Result, 2);
                Display();
                Create();
            }
        }

        public void Create()
        {
            using (var dbContext = new ThreeInOneAppDbContext(DatabaseHandler.options.Options))
            {
                dbContext.CalculatorData.Add(new CalculatorData
                {
                    DateTime = this.CurrentDateTime,
                    Operation = this.Operator,
                    UserValue1 = this.UserValue1,
                    UserValue2 = this.UserValue2,
                    Result = this.Result
                });
                dbContext.SaveChanges();
            }
        }
        public static void Read()
        {
            using (ThreeInOneAppDbContext dbContext = new ThreeInOneAppDbContext(DatabaseHandler.options.Options))
            {
                foreach (var @this in dbContext.CalculatorData)
                {
                    Console.WriteLine($"ID: {@this.CalculatorId}");
                    Console.WriteLine($"Tid: {@this.DateTime}");
                    Console.WriteLine($"Räknesätt: {@this.Operation}");
                    Console.WriteLine($"Tal 1: {@this.UserValue1}");
                    Console.WriteLine($"Tal 2: {@this.UserValue2}");
                    Console.WriteLine($"Resultat: {@this.Result}");
                    
                    Console.WriteLine("====================");
                }
            }
        }

        public void UpdateRow(int calculatorId)
        {
            using (var dbContext = new ThreeInOneAppDbContext(DatabaseHandler.options.Options))
            {
                var rowToUpdate = dbContext.CalculatorData.First(calculate => calculate.CalculatorId == calculatorId);
                rowToUpdate.DateTime = this.CurrentDateTime;
                rowToUpdate.Operation = this.Operator;
                rowToUpdate.UserValue1 = this.UserValue1;
                rowToUpdate.UserValue2 = this.UserValue2;
                rowToUpdate.Result = this.Result;

                dbContext.SaveChanges();
            }

        }
        public void DeleteRow(int calculatorId) 
        {
            using (var dbContext = new ThreeInOneAppDbContext(DatabaseHandler.options.Options))
            {
                var rowToDelete = dbContext.CalculatorData.First(calculator => calculator.CalculatorId == calculatorId);
                dbContext.CalculatorData.Remove(rowToDelete);

                dbContext.SaveChanges();
            }
        }

    }
     
}
