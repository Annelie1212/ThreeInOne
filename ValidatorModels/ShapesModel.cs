using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeInOne
{
    public class ShapesModel
    {
    }

    public class RectangleModel
    {
        public string Width { get; set; }
        public string Height { get; set; }
        public RectangleModel(string width, string height)
        {
            Width = width;
            Height = height;
        }
    }
    public class ParallellogramModel
    {
        public string Width { get; set; }
        public string Height { get; set; }
        public ParallellogramModel(string width, string height)
        {
            Width = width;
            Height = height;
        }
    }
    public class TriangleModel
    {
        public string Width { get; set; }
        public string Height { get; set; }
        public string SideA { get; set; }
        public string SideB { get; set; }
        public string SideC { get; set; }
        public TriangleModel(string width, string height, string sideA, string sideB, string sideC)
        {
            Width = width;
            Height = height;
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }
    }
    public class RhombusModel
    {
        public string Width { get; set; }
        public string Height { get; set; }

        public string Diagonal1 { get; set; }
        public string Diagonal2 { get; set; }
        public RhombusModel(string width, string height, string diagonal1, string diagonal2)
        {
            Width = width;
            Height = height;
            Diagonal1 = diagonal1;
            Diagonal2 = diagonal2;
        }
    }
}
