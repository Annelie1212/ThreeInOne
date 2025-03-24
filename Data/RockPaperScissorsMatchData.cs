using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeInOne.Data
{
    public class RockPaperScissorsMatchData
    {
        [Key]
        public int MatchId { get; set; }
        [Required]
        
        public DateTime DateTime { get; set; }
        [Required]
        public int Win { get; set; }
        [Required]
        public int Loss { get; set; }
        [Required]
        public int Tie { get; set; }
        [Required]
        public double AverageWin { get; set; }
        public List<RockPaperScissorsRoundData> Rounds { get; set; } = new List<RockPaperScissorsRoundData>();
        [Required]

        public string PlayerName { get; set; }
    }
}
