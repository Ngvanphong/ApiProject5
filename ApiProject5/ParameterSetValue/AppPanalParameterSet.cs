using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
namespace ApiProject5.ParameterSetValue
{
  public static  class AppPanalParameterSet
    {
        public static frmParameterSet myFormParameterSet;
        public static void ShowParameterSet()
        {
            ParameterValueHandler handlerParameterSet = new ParameterValueHandler();
            ExternalEvent eventParameterSet = ExternalEvent.Create(handlerParameterSet);
            myFormParameterSet = new frmParameterSet(eventParameterSet, handlerParameterSet);
            myFormParameterSet.Show();
        }

    }
}
