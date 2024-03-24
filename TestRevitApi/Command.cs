using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Forms;

namespace TestRevitApi
{

    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Document doc = commandData.Application.ActiveUIDocument.Document;
            IEnumerable<Family> allFamilyCollection = new FilteredElementCollector(doc)
                .OfClass(typeof(Family)).Cast<Family>();

            IEnumerable<Family> columnBeamCollection = allFamilyCollection.Where(
            x => x.FamilyCategory != null
            &&
            (x.FamilyCategory.Id.Value == (int)BuiltInCategory.OST_StructuralColumns
            || x.FamilyCategory.Id.Value == (int)BuiltInCategory.OST_StructuralFraming)
            );
            IList<FamilyData> familyTypes = new List<FamilyData>();
            foreach(var family in  columnBeamCollection)
            {
                FamilyData familyData = new FamilyData(family.Id,family.Name);
                var typeIds = family.GetFamilySymbolIds();
                List<TypeData> listTypeData = new List<TypeData>();
                foreach(ElementId typeId in typeIds)
                {
                    Element type= doc.GetElement(typeId);
                    TypeData typeData = new TypeData(type.Name, typeId);
                    listTypeData.Add(typeData); 
                }
                familyData.TypeDatas = listTypeData;
                familyTypes.Add(familyData);  
            }
            var form = new DataGridFrom();
            form.dataGrid.ItemsSource= familyTypes;
            form.Show();
            return Result.Succeeded;
        }
        
    }


}
