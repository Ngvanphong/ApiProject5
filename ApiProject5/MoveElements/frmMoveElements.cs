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
namespace ApiProject5.MoveElements
{
    public partial class frmMoveElements : Form
    {
        private MoveElementsHandler _handlerMoveElements;
        private ExternalEvent _eventMoveElements;
        public frmMoveElements(ExternalEvent eventMoveElements, MoveElementsHandler handlerMoveElements)
        {
            InitializeComponent();
            _handlerMoveElements = handlerMoveElements;
            _eventMoveElements = eventMoveElements;
        }

        private void frmMoveElements_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _eventMoveElements.Raise();
        }
    }
}
