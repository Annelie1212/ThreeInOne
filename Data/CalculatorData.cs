using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeInOne.Data
{
    public class CalculatorData
    {
        [Key]
        public int CalculatorId { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public string Operation { get; set; }
        [Required]
        public double UserValue1 { get; set; }
        [Required]
        public double UserValue2 { get; set; }
        [Required]
        public double Result { get; set; }
        

    }
}
