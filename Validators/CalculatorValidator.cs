using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ThreeInOne
{
    public class CalculatorValidator : AbstractValidator<CalculatorModel>
    {
        public CalculatorValidator()
        {

            RuleFor(calculator => calculator.UserValue1)
                .Cascade(CascadeMode.Stop)
                .Must(IsValidDouble).WithMessage("Input is not a valid number!")
                .Must(BeValidRange2).WithMessage("Input is not a valid number!");
            RuleFor(calculator => calculator.UserValue2)
                .Cascade(CascadeMode.Stop)
                .Must(IsValidDouble).WithMessage("Input is not a valid number!")
                .Must(BeValidRange).WithMessage("Input is not a valid number!");
        }

        private bool IsValidDouble(string input)
        {
            return double.TryParse(input, out _);
        }

        private bool BeValidRange(string input)
        {
            double value = double.Parse(input);
            if ((value == 0) || (value > 10000) || (value < -10000) )
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool BeValidRange2(string input)
        {
            double value = double.Parse(input);
            if ( (value > 10000) || (value < -10000))
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
