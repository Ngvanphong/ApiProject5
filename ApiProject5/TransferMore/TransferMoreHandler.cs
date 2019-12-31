using Autodesk.Revit.UI;
using System.Collections.Generic;
using System.Windows.Forms;

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
            List<Node1> checked_nodes = FindCheckedNodes(AppPenalTransferMore.myFormTransferMore.treeViewElementTransfer);
        }

        private List<Node1> FindCheckedNodes(TreeView treeView)
        {
            List<Node1> listResult = new List<Node1>();
            foreach (TreeNode node in treeView.Nodes)
            {
                Node1 nodeAdd = new Node1();
                List<Node2> listNode2 = new List<Node2>();
                foreach(TreeNode node2 in node.Nodes)
                {
                    List<string> listTypeChecked = new List<string>();
                    foreach(TreeNode node3 in node2.Nodes)
                    {
                        if (node3.Checked == true&&!listTypeChecked.Exists(x=>x==node3.Text))
                        {
                            listTypeChecked.Add(node3.Text);
                        }
                    }
                    if (listTypeChecked.Count > 0)
                    {
                        Node2 node2Add = new Node2();
                        node2Add.FamilyName = node2.Text;
                        node2Add.ListType = listTypeChecked;
                        listNode2.Add(node2Add);
                    }
                }
                if (listNode2.Count > 0)
                {
                    nodeAdd.ListFamilyType = listNode2;
                    nodeAdd.NameCategory = node.Text;
                    listResult.Add(nodeAdd);
                } 
            }
            return listResult;
        }

        
    }
    public class Node1
    {
        public string NameCategory { set; get; }
        public List<Node2> ListFamilyType { set; get; }
        public Node1()
        {
            ListFamilyType = new List<Node2>();
        }
    }
    public class Node2
    {
        public string FamilyName { set; get; }
        public List<string> ListType { set; get; }
        public Node2()
        {
            ListType = new List<string>();
        }
    }
}