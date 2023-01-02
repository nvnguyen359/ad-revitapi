using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;

namespace AD.Core
{
    public class ADSelectionFilterByCategory : ISelectionFilter
    {
        private readonly string _category;
        public ADSelectionFilterByCategory(string category)
        {
            this._category = category;
        }
        bool ISelectionFilter.AllowElement(Element elem)
        {
            if (elem.Category!=null && elem.Category.Name.Equals(_category))
            {
                return true;
            }
            return false;
        }

        bool ISelectionFilter.AllowReference(Reference reference, XYZ position)
        {
            return false;
        }
    }
}
