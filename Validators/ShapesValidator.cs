using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ThreeInOne
{
    public class ShapesValidator : AbstractValidator<ShapesModel>
    {
    }

    public class RectangleValidator : AbstractValidator<RectangleModel>
    {
        public RectangleValidator()
        {

            RuleFor(rectangle => rectangle.Width)
                .Cascade(CascadeMode.Stop)
                .Must(IsValidDouble).WithMessage("Input is not a valid number!")
                .Must(BeValidRange).WithMessage("Input is not a valid number!");
            RuleFor(rectangle => rectangle.Height)
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
            if ((value <= 0) || (value > 1000))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    public class ParallellogramValidator : AbstractValidator<ParallellogramModel>
    {
        public ParallellogramValidator()
        {

            RuleFor(paralellogram => paralellogram.Width)
                .Cascade(CascadeMode.Stop)
                .Must(IsValidDouble).WithMessage("Input is not a valid number!")
                .Must(BeValidRange).WithMessage("Input is not a valid number!");
            RuleFor(paralellogram => paralellogram.Height)
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
            if ((value <= 0) || (value > 1000))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    public class TriangleValidator : AbstractValidator<TriangleModel>
    {
        public TriangleValidator()
        {

            RuleFor(triangle => triangle.Width)
                .Cascade(CascadeMode.Stop)
                .Must(IsValidDouble).WithMessage("Input is not a valid number!")
                .Must(BeValidRange).WithMessage("Input is not a valid number!");
            RuleFor(triangle => triangle.Height)
                .Cascade(CascadeMode.Stop)
                .Must(IsValidDouble).WithMessage("Input is not a valid number!")
                .Must(BeValidRange).WithMessage("Input is not a valid number!");
            RuleFor(triangle => triangle.SideA)
                .Cascade(CascadeMode.Stop)
                .Must(IsValidDouble).WithMessage("Input is not a valid number!")
                .Must(BeValidRange).WithMessage("Input is not a valid number!");
            RuleFor(triangle => triangle.SideB)
                .Cascade(CascadeMode.Stop)
                .Must(IsValidDouble).WithMessage("Input is not a valid number!")
                .Must(BeValidRange).WithMessage("Input is not a valid number!");
            RuleFor(triangle => triangle.SideC)
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
            if ((value <= 0) || (value > 1000))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
    public class RhombusValidator : AbstractValidator<RhombusModel>
    {
        public RhombusValidator()
        {

            RuleFor(rhombus => rhombus.Width)
                .Cascade(CascadeMode.Stop)
                .Must(IsValidDouble).WithMessage("Input is not a valid number!")
                .Must(BeValidRange).WithMessage("Input is not a valid number!");
            RuleFor(rhombus => rhombus.Height)
                .Cascade(CascadeMode.Stop)
                .Must(IsValidDouble).WithMessage("Input is not a valid number!")
                .Must(BeValidRange).WithMessage("Input is not a valid number!");
            RuleFor(rhombus => rhombus.Diagonal1)
                .Cascade(CascadeMode.Stop)
                .Must(IsValidDouble).WithMessage("Input is not a valid number!")
                .Must(BeValidRange).WithMessage("Input is not a valid range!");
            RuleFor(rhombus => rhombus.Diagonal2)
                .Cascade(CascadeMode.Stop)
                .Must(IsValidDouble).WithMessage("Input is not a valid number!")
                .Must(BeValidRange).WithMessage("Input is not a valid range!");
        }

        private bool IsValidDouble(string input)
        {
            return double.TryParse(input, out _);
        }

        private bool BeValidRange(string input)
        {
            double value = double.Parse(input);
            if ((value <= 0) || (value > 1000))
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
