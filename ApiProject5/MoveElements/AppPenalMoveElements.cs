using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
namespace ApiProject5.MoveElements
{
  public static  class AppPenalMoveElements
    {
        public static frmMoveElements myFormMoveElements;
        public static void ShowMoveElements()
        {
            MoveElementsHandler handlerMoveElements = new MoveElementsHandler();
            ExternalEvent eventMoveElements = ExternalEvent.Create(handlerMoveElements);
            myFormMoveElements = new frmMoveElements(eventMoveElements, handlerMoveElements);
            myFormMoveElements.Show();
        }
    }
}
