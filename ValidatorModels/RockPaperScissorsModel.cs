using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeInOne
{
    public class RockPaperScissorsModel
    {
        public string UserValue1 { get; set; }
        public RockPaperScissorsModel(string userValue1)
        {
            this.UserValue1 = userValue1;
        }
    }


}

