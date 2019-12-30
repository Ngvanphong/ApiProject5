using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
namespace ApiProject5.TransferMore
{
    [Transaction(TransactionMode.Manual)]
    public class TransferMoreBinding : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Document doc = commandData.Application.ActiveUIDocument.Document;
            AppPenalTransferMore.ShowTransferMore();
            return Result.Succeeded;
        }
    }
}
