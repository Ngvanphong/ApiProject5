using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.DB;
namespace ApiProject5.Helper
{
  public  class SelectionFilterCategory : ISelectionFilter
    {
        private ElementId _categoryId;
        public SelectionFilterCategory(Category category)
        {
            _categoryId = category.Id;
        }
        public bool AllowElement(Element elem)
        {
            bool isElemet = elem.Category.Id.Equals(_categoryId) && elem.Category != null;
            return isElemet;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            throw new NotImplementedException();
        }
    }
}
