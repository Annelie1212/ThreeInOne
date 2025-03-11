using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeInOne
{
    public class Menu
    {
        public List<string> NrChoices { get; set; }
        public List<string> TextChoices { get; set; }
        public void Display()
        {
            for (int i = 0; i < NrChoices.Count; i++)
            {
                Console.WriteLine($"{NrChoices[i]}. {TextChoices[i]}");
            }
        }
    
}

}
