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

namespace ApiProject5.ParameterSetValue
{
    public partial class frmParameterSet : Form
    {
        private ParameterValueHandler _parameterValueHandler;
        private ExternalEvent _parameterValueEvent;
        public frmParameterSet(ExternalEvent parameterValueEvent, ParameterValueHandler parameterValueHandler)
        {
            InitializeComponent();
            _parameterValueHandler = parameterValueHandler;
            _parameterValueEvent = parameterValueEvent;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnParameterSetValue_Click(object sender, EventArgs e)
        {
            _parameterValueEvent.Raise();
        }
    }
}
