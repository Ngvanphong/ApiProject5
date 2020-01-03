using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
namespace ApiProject5.RenumberElement
{
    [Transaction(TransactionMode.Manual)]
    public class RenumberElementBinding : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            AppPenalRenumberElement.ShowRenumberElement();
            return Result.Succeeded;
        }
    }
}
