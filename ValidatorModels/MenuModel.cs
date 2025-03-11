using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeInOne
{
    public class MenuModel
    {
        public string[] MenuNrChoices { get; set; }
        public string UserNrChoice { get; set; }
        public MenuModel(string[] menuNrChoices, string userNrChoice)
        {
            this.MenuNrChoices = menuNrChoices;
            this.UserNrChoice = userNrChoice;
        }
    }
}   

