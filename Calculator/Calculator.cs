using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{

    internal class Calculator
    {
        public string Operator { get; set; }
        public double UserValue1 { get; set; }
        public double UserValue2 { get; set; }

        public double Result {  get; set; }
        public DateTime CurrentDateTime { get; set; }

        public Calculator(double[] userValues,DateTime currentDateTime) 
        {
            this.UserValue1 = userValues[0];
            this.UserValue2 = userValues[1]; 
            this.CurrentDateTime = currentDateTime;
            this.Operator = "";
        }
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
        

    }
     
}
