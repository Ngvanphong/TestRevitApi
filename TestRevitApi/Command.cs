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
            UIDocument uiDoc = commandData.Application.ActiveUIDocument;
            Document doc = uiDoc.Document;
            IEnumerable<FamilyInstance> colleciton = new FilteredElementCollector(doc, doc.ActiveView.Id)
                .OfCategory(BuiltInCategory.OST_StructuralColumns).OfClass(typeof(FamilyInstance)).
                WhereElementIsNotElementType().Cast<FamilyInstance>();


            List<ColumnData> columns = new List<ColumnData>();
            foreach (var item in colleciton)
            {
                string comment = item.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS).AsString();
                ColumnData columnData = new ColumnData(item.Name, comment, item.Id);
                columns.Add(columnData);
            }

            ListBoxColumn form = new ListBoxColumn();
            form.listViewColumn.ItemsSource = columns;
            form.Show();


            return Result.Succeeded;
        }
        
    }


}
