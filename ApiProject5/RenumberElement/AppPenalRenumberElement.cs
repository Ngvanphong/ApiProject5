using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
namespace ApiProject5.RenumberElement
{
   public static class AppPenalRenumberElement
    {
        public static frmRenumberElement myFormRenumberElement;
        public static void ShowRenumberElement()
        {
            RenumberElementHandler handlerRenumber = new RenumberElementHandler();
            ExternalEvent eventRenumber = ExternalEvent.Create(handlerRenumber);
            myFormRenumberElement = new frmRenumberElement(eventRenumber, handlerRenumber);
            myFormRenumberElement.Show();
        }
    }
}
