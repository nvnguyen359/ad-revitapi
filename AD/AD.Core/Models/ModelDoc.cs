using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace AD.Core.Models
{
    public class ModelDoc
    {
        public UIDocument AdUiDoc { get; set; }
        public Document AdDocument { get; set; }
        public View ActiveView { get; set; }
    }
}
