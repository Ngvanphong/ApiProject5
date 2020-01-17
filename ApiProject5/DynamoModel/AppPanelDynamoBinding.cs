using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;

namespace ApiProject5.DynamoModel
{
    [Transaction(TransactionMode.Manual)]
    public class AppPanelDynamoBinding : IExternalCommand
    {
       
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            AppPanelDynamoModel.ShowDynamoModel();
            return Result.Succeeded;
        }
    }
}
