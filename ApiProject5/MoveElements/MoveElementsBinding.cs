using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
namespace ApiProject5.MoveElements
{
    [Transaction(TransactionMode.Manual)]
    public class MoveElementsBinding : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            AppPenalMoveElements.ShowMoveElements();
            return Result.Succeeded;
        }
    }
}
