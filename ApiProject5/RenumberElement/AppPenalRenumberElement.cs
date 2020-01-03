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
        public static bool StopRenumber = false;
        public static void ShowRenumberElement()
        {
            StopRenumber = false;
            RenumberElementHandler handlerRenumber = new RenumberElementHandler();
            ExternalEvent eventRenumber = ExternalEvent.Create(handlerRenumber);
            ParameterElementHandler handlerPara = new ParameterElementHandler();
            ExternalEvent eventPara = ExternalEvent.Create(handlerPara);
            myFormRenumberElement = new frmRenumberElement(eventRenumber, handlerRenumber,eventPara,handlerPara);
            myFormRenumberElement.Show();
        }
    }
}
