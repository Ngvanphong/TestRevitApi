using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRevitApi
{
    public class PipeSystemTypeData
    {
        public PipeSystemTypeData(string name)
        {
            Name = name;
        }
        public PipeSystemTypeData(string name , string diameter)
        {
            Name = name;
            Diameter = diameter;
        }
        public string Name { get; set; }
        public string Diameter { get; set; } 
    }
}
