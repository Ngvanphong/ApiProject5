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
        private ParameterElementHandler _handlerParameter;
        private ExternalEvent _eventParameter;
        public frmRenumberElement(ExternalEvent eventRenumber, RenumberElementHandler handlerRenumber, ExternalEvent eventParameter, ParameterElementHandler handlerParameter)
        {
            InitializeComponent();
            _eventRenumber = eventRenumber;
            _handlerRenumber = handlerRenumber;
            _eventParameter = eventParameter;
            _handlerParameter = handlerParameter;
        }

        private void frmRenumberElement_Load(object sender, EventArgs e)
        {

        }

        private void frmRenumberElement_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void btnStartRenumberElement_Click(object sender, EventArgs e)
        {
            AppPenalRenumberElement.StopRenumber = false;
            _eventRenumber.Raise();
        }

        private void comboBoxTypeElementRenumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            _eventParameter.Raise();
        }
    }
}
