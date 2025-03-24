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
                .Must(IsValidDouble).WithMessage("Det inmatade valet är inte ett giltigt tal!")
                .Must(BeValidRange).WithMessage("Det inmatade valet är inte ett giltigt tal!");
            RuleFor(rectangle => rectangle.Height)
                .Cascade(CascadeMode.Stop)
                .Must(IsValidDouble).WithMessage("Det inmatade valet är inte ett giltigt tal!")
                .Must(BeValidRange).WithMessage("Det inmatade valet är inte ett giltigt tal!");
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
                .Must(IsValidDouble).WithMessage("Det inmatade valet är inte ett giltigt tal!")
                .Must(BeValidRange).WithMessage("Det inmatade valet är inte ett giltigt tal");
            RuleFor(paralellogram => paralellogram.Height)
                .Cascade(CascadeMode.Stop)
                .Must(IsValidDouble).WithMessage("Det inmatade valet är inte ett giltigt tal!")
                .Must(BeValidRange).WithMessage("Det inmatade valet är inte ett giltigt tal!");
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

            RuleFor(triangle => triangle.SideA)
                .Cascade(CascadeMode.Stop)
                .Must(IsValidDouble).WithMessage("Det inmatade valet är inte ett giltigt tal!")
                .Must(BeValidRange).WithMessage("Det inmatade valet är inte ett giltigt tal!");
            RuleFor(triangle => triangle.SideB)
                .Cascade(CascadeMode.Stop)
                .Must(IsValidDouble).WithMessage("Det inmatade valet är inte ett giltigt tal!")
                .Must(BeValidRange).WithMessage("Det inmatade valet är inte ett giltigt tal!");
            RuleFor(triangle => triangle.AngleInDegrees)
                .Cascade(CascadeMode.Stop)
                .Must(IsValidDouble).WithMessage("Det inmatade valet är inte ett giltigt tal!")
                .Must(BeValidRange).WithMessage("Det inmatade valet är inte ett giltigt tal!")
                .Must(BeValidDegree).WithMessage("Du måste ange ett gradantal mellan 0 och 360!");
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
        private bool BeValidDegree(string input)
        {
            double value = double.Parse(input);
            if ((value <= 0) || (value >= 360))
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
                .Must(IsValidDouble).WithMessage("Det inmatade valet är inte ett giltigt tal!")
                .Must(BeValidRange).WithMessage("Det inmatade valet är inte ett giltigt tal!");
            RuleFor(rhombus => rhombus.Height)
                .Cascade(CascadeMode.Stop)
                .Must(IsValidDouble).WithMessage("Det inmatade valet är inte ett giltigt tal!")
                .Must(BeValidRange).WithMessage("Det inmatade valet är inte ett giltigt tal!");
            RuleFor(rhombus => rhombus.Diagonal1)
                .Cascade(CascadeMode.Stop)
                .Must(IsValidDouble).WithMessage("Det inmatade valet är inte ett giltigt tal!")
                .Must(BeValidRange).WithMessage("Det inmatade talet är inte inom det giltiga spannet!");
            RuleFor(rhombus => rhombus.Diagonal2)
                .Cascade(CascadeMode.Stop)
                .Must(IsValidDouble).WithMessage("Det inmatade valet är inte ett giltigt tal!")
                .Must(BeValidRange).WithMessage("Det inmatade valet är inte inom det giltiga spannet!");
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
