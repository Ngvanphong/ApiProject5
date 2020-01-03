using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
namespace ApiProject5.RenumberElement
{
    public class ParameterElementHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            string cateChoice = AppPenalRenumberElement.myFormRenumberElement.comboBoxTypeElementRenumber
                .GetItemText(AppPenalRenumberElement.myFormRenumberElement.comboBoxTypeElementRenumber.SelectedItem);

        }

        public string GetName()
        {
            return "ParameterEleGetHandler";
        }
    }
}
