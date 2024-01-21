using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRevitApi
{
    internal class ElementName
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value;}
        }


        private Element element;
        public Element Element
        { 
            get { return element; }
            set{element = value;}
        }
    }
}
