using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ApiProject5.TransferMore
{
    public class TransferMoreHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            if (doc.Title != AppPenalTransferMore.DocumentSource)
            {
                MessageBox.Show("You must go back to source project");
                return;
            }
            Document docTo = null;
            var listDoc = app.Application.Documents;
            string projectNameTo = AppPenalTransferMore.myFormTransferMore.comboBoxToProject
                .GetItemText(AppPenalTransferMore.myFormTransferMore.comboBoxToProject.SelectedItem);
            foreach (Document docItem in listDoc)
            {
                if (docItem.Title == projectNameTo)
                {
                    docTo = docItem;
                    break;
                }
            }

            List<Node1> checked_nodes = FindCheckedNodes(AppPenalTransferMore.myFormTransferMore.treeViewElementTransfer);
            List<ElementId> listIsCopy = new List<ElementId>();
            List<ElementId> listIdLegend = new List<ElementId>();
            foreach (var Cate in checked_nodes)
            {
                foreach (var Fami in Cate.ListFamilyType)
                {
                    foreach (string typeN in Fami.ListType)
                    {
                        if (CheckHasCategory(Cate.NameCategory))
                        {
                            var sourceCopy = new FilteredElementCollector(doc).OfClass(typeof(FamilySymbol)).Cast<FamilySymbol>().
                            Where(x => x.Name == typeN && x.FamilyName == Fami.FamilyName && x.Category.Name == Cate.NameCategory);
                            foreach (var item in sourceCopy)
                            {
                                listIsCopy.Add(item.Id);
                            }
                        }
                        else
                        {
                            ElementId idLegend = null;
                            ElementId idNewCopy = null;
                            idNewCopy = GetElementNoneCate(typeN, Cate.NameCategory, doc, out idLegend);
                            if (idNewCopy != null)
                            {
                                listIsCopy.Add(idNewCopy);
                            }
                            if (idLegend != null)
                            {
                                listIdLegend.Add(idLegend);
                            }
                        }
                    }
                }
            }
            CopyPasteOptions option = null;
            if (listIsCopy.Count > 0)
            {
                using (Transaction t = new Transaction(docTo, "TransferAction"))
                {
                    t.Start();
                    try
                    {
                        option = new CopyPasteOptions();
                        ElementTransformUtils.CopyElements(doc, listIsCopy, docTo, Transform.Identity, option);
                        t.Commit();
                    }
                    catch (Exception e)
                    {
                        t.Commit();
                    }
                }
                CheckUncheckTreeNode(AppPenalTransferMore.myFormTransferMore.treeViewElementTransfer.Nodes, false);
            }

            if (listIdLegend.Count > 0)
            {
                foreach (var id in listIdLegend)
                {
                    Autodesk.Revit.DB.View originView = doc.GetElement(id) as Autodesk.Revit.DB.View;
                    var allElmentInView = new FilteredElementCollector(doc, id).ToElementIds();
                    string nameOrigin = originView.Name;
                    using (Transaction t3 = new Transaction(docTo, "TransferLegend"))
                    {
                        t3.Start();
                        try
                        {
                            Autodesk.Revit.DB.View viewTo = new FilteredElementCollector(docTo).OfClass(typeof(Autodesk.Revit.DB.View))
                                .Cast<Autodesk.Revit.DB.View>().Where(x => x.ViewType == ViewType.Legend && x.Name == originView.Name).First();
                            viewTo.Name = "TemporateViewLegend100";
                            ElementTransformUtils.CopyElements(originView, allElmentInView, viewTo, Transform.Identity, option);
                            docTo.Delete(viewTo.Id);
                            t3.Commit();
                        }
                        catch (Exception e)
                        {
                            t3.RollBack();
                        }
                    }
                }
            }
        }

        public string GetName()
        {
            return "TransferMoreHandler";
        }

        private void CheckUncheckTreeNode(TreeNodeCollection trNodeCollection, bool isCheck)
        {
            foreach (TreeNode trNode in trNodeCollection)
            {
                trNode.Checked = isCheck;
                if (trNode.Nodes.Count > 0)
                    CheckUncheckTreeNode(trNode.Nodes, isCheck);
            }
        }

        private List<Node1> FindCheckedNodes(TreeView treeView)
        {
            List<Node1> listResult = new List<Node1>();
            foreach (TreeNode node in treeView.Nodes)
            {
                Node1 nodeAdd = new Node1();
                List<Node2> listNode2 = new List<Node2>();
                foreach (TreeNode node2 in node.Nodes)
                {
                    List<string> listTypeChecked = new List<string>();
                    foreach (TreeNode node3 in node2.Nodes)
                    {
                        if (node3.Checked == true && !listTypeChecked.Exists(x => x == node3.Text))
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

        private bool CheckHasCategory(string CatgoryName)
        {
            bool result = true;
            if (Constants.ListOtherCate.Exists(x => x == CatgoryName))
            {
                result = false;
            }
            return result;
        }

        private ElementId GetElementNoneCate(string typeName, string ortherCate, Document doc, out ElementId idLegend)
        {
            ElementId idResult = null;
            ElementId idOutput = null;
            if (ortherCate == Constants.LegendView)
            {
                idResult = new FilteredElementCollector(doc).OfClass(typeof(Autodesk.Revit.DB.View)).
                Cast<Autodesk.Revit.DB.View>().Where(x => x.ViewType == ViewType.Legend).Where(x => x.Name == typeName).First().Id;
                idOutput = idResult;
            }
            else if (ortherCate == Constants.LineStyle)
            {
                var lineStyle = doc.Settings.Categories.get_Item(BuiltInCategory.OST_Lines);
                foreach (Category line in lineStyle.SubCategories)
                {
                    if (line.Name == typeName&&line.Name.StartsWith("<")==false)
                    {
                        idResult = line.Id;
                        break;
                    }
                }
            }
            else if (ortherCate == Constants.Material)
            {
                idResult = new FilteredElementCollector(doc).OfClass(typeof(Material)).Where(x => x.Name == typeName).First().Id;
            }
            else if (ortherCate == Constants.Pattern)
            {
                idResult = new FilteredElementCollector(doc).OfClass(typeof(FillPatternElement)).Where(x => x.Name == typeName).First().Id;
            }
            else if (ortherCate == Constants.TemplateView)
            {
                idResult = new FilteredElementCollector(doc).OfClass(typeof(Autodesk.Revit.DB.View))
                    .Cast<Autodesk.Revit.DB.View>().Where(x => x.IsTemplate).Where(x => x.Name == typeName).First().Id;
            }
            idLegend = idOutput;
            return idResult;
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