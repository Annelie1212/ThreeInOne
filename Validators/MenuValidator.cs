using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ThreeInOne
{
    public class MenuValidator : AbstractValidator<MenuModel>
    {
        public MenuValidator()
        {
            //menuModel = ett MenuModel-klass-objekt skapat utanför.
            RuleFor(menuModel => menuModel)
                .Cascade(CascadeMode.Stop)
                .Must(BeValidInt).WithMessage("Det inmatade valet är inte en siffra, försök igen!")
                .Must(BeValidChoice).WithMessage("Det inmatade valet finns inte i menyn, försök igen!");
        }

        //menuModel tas in som parameter, men jag använder property:t menuModel.UserChoice för att kolla om den är en int.
        private bool BeValidInt(MenuModel menuModel)

        {//kolla upp förklarin//
            return int.TryParse(menuModel.UserNrChoice, out _);
        }


        //övaöva
        private bool BeValidChoice(MenuModel menuModel)
        {
            //menuChoices ur menymodellen
            string userChoice = menuModel.UserNrChoice;
            List<string> menuChoices = menuModel.MenuNrChoices.ToList();

            if (menuChoices.Contains(userChoice))
            {
                return true;
            }
            else { return false; }
        }
    }
}

