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
            IList<FamilyType> familyTypes = new List<FamilyType>();
            foreach(var family in  columnBeamCollection)
            {
                var typeIds = family.GetFamilySymbolIds();
                foreach(ElementId typeId in typeIds)
                {
                    Element type= doc.GetElement(typeId);
                    FamilyType familyType = new FamilyType(family.Id, family.Name, type.Name, typeId);
                    familyTypes.Add(familyType);
                }
                
            }
            var form = new ListBoxColumn();
            form.listViewColumn.ItemsSource= familyTypes;
            form.ShowDialog();

            return Result.Succeeded;
        }
        
    }


}
