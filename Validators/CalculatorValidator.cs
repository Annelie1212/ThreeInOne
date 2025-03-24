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
        public static Dictionary<string, string> IntegerToOperation = new Dictionary<string, string>
        {
            {"1","Summan" },
            {"2","Differensen"},
            {"3","Produkten"},
            {"4","Kvoten"},
            {"5","X:te roten ur" },
            {"6","Modulo"}
        };
        public CalculatorValidator()
        {

            RuleFor(calculator => calculator)
                .Cascade(CascadeMode.Stop)
                .Must(IsValidDouble).WithMessage("Det inmatade valet är inte ett giltigt tal!")
                .Must(BeValidRange).WithMessage("Det inmatade valet är inte inom det giltiga spannet!")
                .Must(NotBeZeroForDivision).WithMessage("Du kan inte dela med noll!");

        }

        private bool IsValidDouble(CalculatorModel calculator)
        {
            bool isValue1Double = double.TryParse(calculator.UserValue1, out _);
            bool isValue2Double = double.TryParse(calculator.UserValue2, out _);
            if( (isValue2Double) && (isValue2Double))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool BeValidRange(CalculatorModel calculator)
        {
            double value = double.Parse(calculator.UserValue2);
            if ( (value > 10000) || (value < -10000))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool NotBeZeroForDivision(CalculatorModel calculator)
        {
            string calculationChoice = IntegerToOperation[calculator.CalculationChoice];
            if( (calculationChoice == "Kvoten") && ( double.Parse(calculator.UserValue2) == 0) )
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
