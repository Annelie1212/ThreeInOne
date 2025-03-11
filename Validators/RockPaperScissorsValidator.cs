using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace ThreeInOne
{
    public class RockPaperScissorsValidator : AbstractValidator<RockPaperScissorsModel>
    {
        public RockPaperScissorsValidator()
        {

            RuleFor(rps => rps.UserValue1)
                .Cascade(CascadeMode.Stop)
                .Must(IsValidDouble).WithMessage("Input is not a valid number!")
                .Must(BeValidRange).WithMessage("Input is not a valid range!");
        }

        private bool IsValidDouble(string input)
        {//kolla upp förklarin//
            return double.TryParse(input, out _);




        }

        private bool BeValidRange(string input)
        {
            double value = double.Parse(input);
            if ((value > 3) || (value < 1))
            {
                return false;
            }
            else
            {
                return true;
            }
        }


    }
}
