using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
namespace ThreeInOne
{
    public class Menu
    {
        public string AppName { get; set; }
        public List<string> NrChoices { get; set; }
        public List<string> TextChoices { get; set; }
        public Menu() { }
        public Menu(List<string> nrChoices,List<string> textChoices) 
        {
            NrChoices = nrChoices;
            TextChoices = textChoices;
        }
        public void Display()
        {
            Console.WriteLine(AppName);
            for (int i = 0; i < NrChoices.Count; i++)
            {
                Console.WriteLine($"{NrChoices[i]}{TextChoices[i]}");
            }
        }
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

    }

}
