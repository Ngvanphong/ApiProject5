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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnTransferOK_Click(object sender, EventArgs e)
        {
            _eventTransfer.Raise();
        }

        private void btnShowAllTransfer_Click(object sender, EventArgs e)
        {
            AppPenalTransferMore.myFormTransferMore.treeViewElementTransfer.ExpandAll();
        }

        private void btnHideTransfer_Click(object sender, EventArgs e)
        {
            AppPenalTransferMore.myFormTransferMore.treeViewElementTransfer.CollapseAll();
        }

        private void treeViewElementTransfer_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                if (e.Node.Nodes.Count > 0)
                {
                    /* Calls the CheckAllChildNodes method, passing in the current 
                    Checked value of the TreeNode whose checked state changed. */
                    this.CheckAllChildNodes(e.Node, e.Node.Checked);
                }
            }
        }
        private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
                if (node.Nodes.Count > 0)
                {
                    // If the current node has child nodes, call the CheckAllChildsNodes method recursively.
                    this.CheckAllChildNodes(node, nodeChecked);
                }
            }
        }

        private void checkBoxAllOrNonetra_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
