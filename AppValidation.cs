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
        public RectangleModel RectangleModel { get; set; }
        public ParallellogramModel ParallellogramModel { get; set; }
        public TriangleModel TriangleModel { get; set; }
        public RhombusModel RhombusModel{ get; set; }
        public PlayerModel PlayerModel { get; set; }

        public AppValidation(MenuModel menuModel) 
        {
            MenuModel = menuModel;
        }
        public AppValidation(CalculatorModel calculatorModel)
        {
            CalculatorModel = calculatorModel;
        }
        public AppValidation(RectangleModel rectangleModel)
        {
            RectangleModel = rectangleModel;
        }
        public AppValidation(ParallellogramModel parallellogramModel)
        {
            ParallellogramModel = parallellogramModel;
        }
        public AppValidation(RhombusModel rhombusModel)
        {
            RhombusModel = rhombusModel;
        }

        public AppValidation(PlayerModel playerModel)
        {
            PlayerModel = playerModel;
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

        public bool ValidatePlayerModel()
        {
            PlayerValidator myPlayerValidator = new PlayerValidator();
            ValidationResult validationResults = myPlayerValidator.Validate(PlayerModel);
            bool isInputValid = Menu.ErrorMessageDiplay(validationResults);
            return isInputValid;
        }

        public bool ValidateRectangleModel()
        {
            RectangleValidator myRectangleValidator = new RectangleValidator();
            ValidationResult validationResults = myRectangleValidator.Validate(RectangleModel);
            bool isInputValid = Menu.ErrorMessageDiplay(validationResults);
            return isInputValid;
        }
        public bool ValidateParallellogramModel()
        {
            ParallellogramValidator myParallellogramValidator = new ParallellogramValidator();
            ValidationResult validationResults = myParallellogramValidator.Validate(ParallellogramModel);
            bool isInputValid = Menu.ErrorMessageDiplay(validationResults);
            return isInputValid;
        }
        public bool ValidateTriangleModel()
        {
            TriangleValidator myTriangleValidator = new TriangleValidator();
            ValidationResult validationResults = myTriangleValidator.Validate(TriangleModel);
            bool isInputValid = Menu.ErrorMessageDiplay(validationResults);
            return isInputValid;
        }
        public bool ValidateRhombusModel()
        {
            RhombusValidator myRhombusValidator = new RhombusValidator();
            ValidationResult validationResults = myRhombusValidator.Validate(RhombusModel);
            bool isInputValid = Menu.ErrorMessageDiplay(validationResults);
            return isInputValid;
        }
    }
}
