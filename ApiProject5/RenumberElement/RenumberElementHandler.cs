using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using System.Text.RegularExpressions;
namespace ApiProject5.RenumberElement
{
    public class RenumberElementHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            int mainNumber =int.Parse(AppPenalRenumberElement.myFormRenumberElement.textBoxMainRenumber.Text);
            string prefixNumber = AppPenalRenumberElement.myFormRenumberElement.textBoxPrefitRenumber.Text;
            string subffixNumber = AppPenalRenumberElement.myFormRenumberElement.textBoxSubffixRenumber.Text;
            while (!AppPenalRenumberElement.StopRenumber)
            {
                try
                {
                    var referElement = app.ActiveUIDocument.Selection.PickObject(ObjectType.Element);
                    var id = doc.GetElement(referElement).Id;


                    
                }
                catch { break; }
            }
        }

        public string GetName()
        {
            return "RenumberElementRev1";
        }
    }
}
