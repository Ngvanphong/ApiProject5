using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
namespace ApiProject5.RenumberElement
{
    public class RenumberElementHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            throw new NotImplementedException();
        }

        public string GetName()
        {
            return "RenumberElementRev1";
        }
    }
}
