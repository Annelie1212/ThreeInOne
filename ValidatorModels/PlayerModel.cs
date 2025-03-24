using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeInOne
{
    public class PlayerModel
    {
        public string PlayerName { get; set; }
        public PlayerModel(string playerName)
        {
            this.PlayerName = playerName;
        }
    }
}
