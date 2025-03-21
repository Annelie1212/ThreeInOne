using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeInOne.Data
{
    public class RockPaperScissorsRoundData
    {
        [Key]
        public int RoundId { get; set; }
        [Required]
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

        public string PlayerMove { get; set; }
        [Required]
        public string ComputerMove { get; set; }

        public RockPaperScissorsMatchData Match { get; set; }
    }
}
