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
namespace ApiProject5.RenumberElement
{
    public partial class frmRenumberElement : Form
    {
        private RenumberElementHandler _handlerRenumber;
        private ExternalEvent _eventRenumber;
        public frmRenumberElement(ExternalEvent eventRenumber, RenumberElementHandler handlerRenumber)
        {
            InitializeComponent();
            _eventRenumber = eventRenumber;
            _handlerRenumber = handlerRenumber;
        }
    }
}
