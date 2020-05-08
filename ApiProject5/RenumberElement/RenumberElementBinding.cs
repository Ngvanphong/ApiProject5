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
            GetInforRenumber();
            return Result.Succeeded;
        }
        public void GetInforRenumber()
        {
            AppPenalRenumberElement.myFormRenumberElement.comboBoxTypeElementRenumber.DisplayMember = "Text";
            AppPenalRenumberElement.myFormRenumberElement.comboBoxTypeElementRenumber.ValueMember = "Value";
            foreach(string text in Constants.ListCate)
            {
                AppPenalRenumberElement.myFormRenumberElement.comboBoxTypeElementRenumber.Items.Add(new { Text = text, Value = text });
            }
        }
    }
}
