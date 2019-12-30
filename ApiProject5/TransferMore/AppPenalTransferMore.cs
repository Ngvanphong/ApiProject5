using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
namespace ApiProject5.TransferMore
{
   public static class AppPenalTransferMore
    {
        public static frmTransferMore myFormTransferMore;
        public static void ShowTransferMore()
        {
            TransferMoreHandler handlerTransfer = new TransferMoreHandler();
            ExternalEvent eventTransefer = ExternalEvent.Create(handlerTransfer);
            myFormTransferMore = new frmTransferMore(eventTransefer, handlerTransfer);
            myFormTransferMore.Show();
        }
    }
}
