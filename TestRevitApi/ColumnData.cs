using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRevitApi
{
    public class ColumnData
    {
        public ColumnData(string type, string commentColumn,ElementId id)
        {
            (TypeName, CommentColumn, ElementId) = (type, commentColumn, id);
        }
        public string TypeName { set; get; }
        public string CommentColumn { set; get; }

        public ElementId ElementId { set; get; }

    }
}
