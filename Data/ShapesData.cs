using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeInOne.Data
{
    public class ShapesData
    {
        [Key]
        public int ShapesId { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public string Shape {  get; set; }
        [Required]
        public double Width { get; set; }
        [Required]
        public double Height { get; set; }
        [Required]
        public double Diagonal1 { get; set; }
        [Required]
        public double Diagonal2 { get; set; }
        [Required]
        public double SideA { get; set; }
        [Required]
        public double SideB { get; set; }
        [Required]
        public double SideC { get; set; }
        [Required]
        public double AngleInDegrees { get; set; }
        [Required]
        public double Perimeter { get; set; }
        [Required]
        public double Area { get; set; }

    }
}
