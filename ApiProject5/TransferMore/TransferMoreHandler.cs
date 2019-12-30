using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
namespace ApiProject5.TransferMore
{
    public class TransferMoreHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            throw new NotImplementedException();
        }

        public string GetName()
        {
            return "TransferMoreHandler";
        }
    }
}
