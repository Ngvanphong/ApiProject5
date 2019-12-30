using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.UI;
namespace ApiProject5.TransferMore
{
    public partial class frmTransferMore : Form
    {
        private TransferMoreHandler _handlerTransfer;
        private ExternalEvent _eventTransfer;
        public frmTransferMore(ExternalEvent eventTransfer,TransferMoreHandler handlerTransfer)
        {
            InitializeComponent();
            _eventTransfer = eventTransfer;
            _handlerTransfer = handlerTransfer;
        }
    }
}
