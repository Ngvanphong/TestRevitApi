using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Plumbing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRevitApi
{
    public class FamilyData
    {
        public ElementId Id { set; get; }
        public string FamilyName { set; get; }
        
        public List<TypeData> TypeDatas { set; get; }
        
        public FamilyData(ElementId id, string familyName)
        {
            (Id, FamilyName) = (id, familyName);
        }

    }

    public class TypeData
    {
        public string TypeName { set; get; }
        public ElementId TypeId { set; get; }
        public TypeData(string typeName, ElementId typeId)
        {
            (TypeName, TypeId)= (typeName, typeId);
        }
    }

}
