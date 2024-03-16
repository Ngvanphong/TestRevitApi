using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Plumbing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRevitApi
{
    public class FamilyType
    {
        public ElementId Id { set; get; }
        public string FamilyName { set; get; }
        public string TypeName { set; get; }
        public ElementId TypeId { set; get; }
        public int CountTypes { set; get; }
        public FamilyType(ElementId id, string familyName, string typeName, ElementId typeId)
        {
            (Id,FamilyName,TypeName,TypeId)= (id, familyName,typeName, typeId);
        }
        
    }
}
