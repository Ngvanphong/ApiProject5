using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using System.Windows.Forms;
using System.Linq;
namespace ApiProject5.TransferMore
{
    public class TransferMoreHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            GetCheckListElement();
        }

        public string GetName()
        {
            return "TransferMoreHandler";
        }
        public void GetCheckListElement()
        {
            List<TreeNode> checked_nodes = CheckedNodes(AppPenalTransferMore.myFormTransferMore.treeViewElementTransfer);
        }
        private void FindCheckedNodes(List<TreeNode> checked_nodes, TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                // Add this node.
                if (node.Checked) checked_nodes.Add(node);
                // Check the node's descendants.
                FindCheckedNodes(checked_nodes, node.Nodes);
            }
        }

        private List<TreeNode> CheckedNodes(TreeView trv)
        {
            List<TreeNode> checked_nodes = new List<TreeNode>();
            FindCheckedNodes(checked_nodes, trv.Nodes);
            return checked_nodes;
        }



    }
    
}
