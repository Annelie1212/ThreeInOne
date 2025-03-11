using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeInOne
{
    public class CalculatorModel
    {
        public string UserValue1 { get; set; }
        public string UserValue2 { get; set; }
        public CalculatorModel(string userValue1, string userValue2)
        {
            this.UserValue1 = userValue1;
            this.UserValue2 = userValue2;
        }
    }
    
    
}
