using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
namespace ThreeInOne
{
    public class AppValidation
    {
        public MenuModel MenuModel { get; set; }
        public CalculatorModel CalculatorModel { get; set; }
        public AppValidation(MenuModel menuModel) 
        {
            MenuModel = menuModel;
        }
        public AppValidation(CalculatorModel calculatorModel)
        {
            CalculatorModel = calculatorModel;
        }
        public bool ValidateMenuModel() 
        {
            MenuValidator myMenuValidator = new MenuValidator();
            ValidationResult validationResults = myMenuValidator.Validate(MenuModel);
            bool isInputValid = Menu.ErrorMessageDiplay(validationResults);
            return isInputValid;
        }
        public bool ValidateCalculatorModel()
        {
            CalculatorValidator myCalculatorValidator = new CalculatorValidator();
            ValidationResult validationResults = myCalculatorValidator.Validate(CalculatorModel);
            bool isInputValid = Menu.ErrorMessageDiplay(validationResults);
            return isInputValid;
        }
    }
}
