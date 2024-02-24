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
            Autodesk.Revit.DB.Document doc = uiDoc.Document;

            var ids = uiDoc.Selection.GetElementIds();

            var beams = new FilteredElementCollector(doc)
                 .OfCategory(BuiltInCategory.OST_StructuralFraming).WhereElementIsNotElementType();
                 

            var idMains = beams
                .Where(x => x.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS).AsString() == "Main")
                .Select(x=>x.Id).ToList();


            // filter theo revit dung de add filter cho bang filter
            ElementId elementId = new ElementId(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS); 
            ParameterValueProvider parameterValueProvider = new ParameterValueProvider(elementId); // fiilter tren parameter nao
            var filterRule = new FilterStringRule(parameterValueProvider, new FilterStringEquals(), "Main");
            ElementParameterFilter parameterFilter = new ElementParameterFilter(filterRule);
            // Dung de tao filter bo filter

            var pattern = new FilteredElementCollector(doc).OfClass(typeof(FillPatternElement)).Cast<FillPatternElement>().First(); 

            IList<ElementId> categoryIds= new List<ElementId>();
            categoryIds.Add(new ElementId(BuiltInCategory.OST_StructuralFraming));

            using(Transaction tr=new Transaction(doc, "AddFilter"))
            {
                tr.Start();
                ParameterFilterElement filterInVG = ParameterFilterElement.Create(doc, "FilterComment", categoryIds);
                filterInVG.SetElementFilter(parameterFilter);

                doc.ActiveView.AddFilter(filterInVG.Id);
                doc.ActiveView.SetFilterVisibility(filterInVG.Id, false);
                OverrideGraphicSettings overColor= new OverrideGraphicSettings();
                overColor.SetSurfaceForegroundPatternColor(new Color(255, 0, 0));  
                overColor.SetSurfaceForegroundPatternId(pattern.Id);
                doc.ActiveView.SetFilterOverrides(filterInVG.Id,overColor);
                
                tr.Commit();
            }

            //var idMainRevit = beams.WherePasses(parameterFilter).Select(x=>x.Id).ToList();




            //Element element = null;
            //Parameter para = element.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS);// Par;
            //string valueComment= para.AsString();// 
            //uiDoc.Selection.SetElementIds(idMainRevit);//




            return Result.Succeeded;
        }
        
        public bool IsNumer(string text,out double number)
        {
            double numberInput = 0;
            bool isNumber= double.TryParse(text,out numberInput);
            number = numberInput;
            return isNumber;
        }
        public bool RefNumber(string text,ref double number)
        {
            double numberInput = 0;
            bool isNumber = double.TryParse(text, out numberInput);
            return isNumber;
        }
    }


}
