using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRevitApi;

namespace TestRevitApi
{
    //    internal class Test1
    //    {
    //        //Element[] arrayElement = new Element[10];

    //        //List<Element> listElement= new List<Element>();
    //        //IList<Element> listElement2= new List<Element>();
    //        //IEnumerable<Element> listElement3 = new List<Element>();
    //        //ICollection<Element> listElement4 = new List<Element>();

    //        //Dictionary<string,double> dictionaryPeople= new Dictionary<string,double>();
    //        //dictionaryPeople.Add("A", 20);
    //        //dictionaryPeople.Add("B", 30);
    //        //dictionaryPeople.Add("C", 40);
    //        //double age = dictionaryPeople["B"];

    //        //foreach(string key in dictionaryPeople.Keys)
    //        //{

    //        //}

    //        //foreach(double value in dictionaryPeople.Values)
    //        //{

    //        //}


    //        ICollection<ElementId> selectedId = uiDoc.Selection.GetElementIds();

    //        List<Element> listSelectedElement = new List<Element>();

    //            foreach(ElementId id in selectedId)
    //            {
    //                Element element = doc.GetElement(id); // lay element tu id co duoc


    //        listSelectedElement.Add(element); // them du lieu vao list;
    //            }

    //    IEnumerable<Element> listWall = listSelectedElement
    //        .Where(y => (y.Category != null) && (y.Category.Id.Value == (long)BuiltInCategory.OST_Walls));


    //    List<Wall> listByType = listSelectedElement.OfType<Wall>().ToList();

    //    listByType = listByType.OrderBy(x=>  x.Width).ToList();

    //    listByType = listByType.OrderBy(x =>
    //            {
    //                Parameter parameter = x.get_Parameter(BuiltInParameter.CURVE_ELEM_LENGTH);
    //                return parameter.AsDouble();
    //            }).ToList();

    //List<Wall> listWall2 = listByType.OrderByDescending(x => x.Name).ThenBy(x => x.Width).ToList();

    //var groupByWidth = listWall2.GroupBy(x => x.Width);

    //foreach (var groupItem in groupByWidth)
    //{
    //    double with = groupItem.Key;
    //    foreach (var wall in groupItem)
    //    {

    //    }
    //}

    //IEnumerable<string> listName = listWall2.Select(x => x.Name);


    //IEnumerable<object> listNameIDObejct = listWall2.Select(x => new
    //{
    //    x.Id,
    //    x.Name,
    //    x.Width
    //});
    //IEnumerable<IDName> listNameID = listWall2.Select(x => new IDName(x.Name, x.Id));

    //IEnumerable<IDName> listNameID2 = listWall2.Select(x => new IDName { Id = x.Id, Name = x.Name });

    //IEnumerable<IDName> listNameID3 = listWall2.Select(x =>
    //{
    //    var item = new IDName();
    //    item.Id = x.Id;
    //    item.Name = x.Name;
    //    return item;
    //});

    //var item1 = new IDName("Wall1", new ElementId(1L));

    //var item2 = new IDName();
    //item2.Name = "Wall2";
    //item2.Id = new ElementId(1L);

    //listName = listName.Distinct();

    //string nameFirstWall = listName.First();

    //bool isExist = listWall.Any(x => x.Name == nameFirstWall);

    //bool isAll = listWall.All(x => x.Name == nameFirstWall);

    //Wall wallFirst = listWall2.First();

    //bool isContain = listWall2.Contains(wallFirst);

    //bool isContain2 = listName.Contains("1");

    //int count = listWall2.Count();

    //double widthMax = listWall2.Max(x => x.Width);

    //var second = listWall2[0];
    //var third = listWall2.ElementAt(0);


    //Wall firsstWall = listWall2.First(x => x.Width > 5000);
    //Wall firstWall2 = listWall2.FirstOrDefault(x => x.Width > 500);
    //Wall lastWall = listWall2.Last(x => x.Width > 5000);
    //Wall lastWall2 = listWall2.LastOrDefault(x => x.Width > 500);

    //Wall signle = listWall2.Single(x => x.Width == 100);

    //var listWall23 = listWall2.Skip(3).Take(2);


    //var listWall3 = from w in listWall2
    //                where (w.Width > 10 && w.Width < 20)
    //                orderby w.Name, w.Width
    //                select new IDName(w.Name, w.Id);




    //ElementName elmentName = new ElementName();
    //elmentName.Name = "Thing";

    //string gnam = elmentName.Name;

    //    }
    //}


    //UIDocument uiDoc = commandData.Application.ActiveUIDocument;
    //Autodesk.Revit.DB.Document doc = uiDoc.Document;

    //var ids = uiDoc.Selection.GetElementIds();

    //var beams = new FilteredElementCollector(doc)
    //     .OfCategory(BuiltInCategory.OST_StructuralFraming).WhereElementIsNotElementType();


    //var idMains = beams
    //    .Where(x => x.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS).AsString() == "Main")
    //    .Select(x => x.Id).ToList();


    //// filter theo revit dung de add filter cho bang filter
    //ElementId elementId = new ElementId(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS);
    //ParameterValueProvider parameterValueProvider = new ParameterValueProvider(elementId); // fiilter tren parameter nao
    //var filterRule = new FilterStringRule(parameterValueProvider, new FilterStringEquals(), "Main");
    //ElementParameterFilter parameterFilter = new ElementParameterFilter(filterRule);
    //// Dung de tao filter bo filter

    //var pattern = new FilteredElementCollector(doc).OfClass(typeof(FillPatternElement)).Cast<FillPatternElement>().First();

    //IList<ElementId> categoryIds = new List<ElementId>();
    //categoryIds.Add(new ElementId(BuiltInCategory.OST_StructuralFraming));

    //        using(Transaction tr=new Transaction(doc, "AddFilter"))
    //        {
    //            tr.Start();
    //            ParameterFilterElement filterInVG = ParameterFilterElement.Create(doc, "FilterComment", categoryIds);
    //filterInVG.SetElementFilter(parameterFilter);

    //            doc.ActiveView.AddFilter(filterInVG.Id);
    //            doc.ActiveView.SetFilterVisibility(filterInVG.Id, false);
    //            OverrideGraphicSettings overColor = new OverrideGraphicSettings();
    //overColor.SetSurfaceForegroundPatternColor(new Color(255, 0, 0));  
    //            overColor.SetSurfaceForegroundPatternId(pattern.Id);
    //            doc.ActiveView.SetFilterOverrides(filterInVG.Id, overColor);
                
    //            tr.Commit();
    //        }

    //        //var idMainRevit = beams.WherePasses(parameterFilter).Select(x=>x.Id).ToList();

    //        //Element element = null;
    //        //Parameter para = element.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS);// Par;
    //        //string valueComment= para.AsString();// 
    //        //uiDoc.Selection.SetElementIds(idMainRevit);//
}
