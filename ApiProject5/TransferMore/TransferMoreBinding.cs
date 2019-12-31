using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ApiProject5.TransferMore
{
    [Transaction(TransactionMode.Manual)]
    public class TransferMoreBinding : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Document doc = commandData.Application.ActiveUIDocument.Document;
            AppPenalTransferMore.ShowTransferMore();
            GetInfromationTree(doc);
            TransferAdvance(doc);
            GetAllProject(commandData.Application);

            return Result.Succeeded;
        }

        public void GetInfromationTree(Document doc)
        {
            var allCate = doc.Settings.Categories;
            foreach (Category item in allCate)
            {
                var typeCate = new FilteredElementCollector(doc).WherePasses(new ElementCategoryFilter(item.Id)).
                    WherePasses(new ElementClassFilter(typeof(FamilySymbol))).Cast<FamilySymbol>().GroupBy(e => e.FamilyName)
                    .ToDictionary(e => e.Key, e => e.ToList());
                if (typeCate.Count > 0)
                {
                    TreeNode node = AppPenalTransferMore.myFormTransferMore.treeViewElementTransfer.Nodes.Add(item.Name);
                    foreach (KeyValuePair<string, List<FamilySymbol>> child in typeCate)
                    {
                        TreeNode nodeChild = node.Nodes.Add(child.Key);
                        foreach (FamilySymbol childType in child.Value)
                        {
                            nodeChild.Nodes.Add(childType.Name);
                        }
                    }
                }
            }
        }

        public void TransferAdvance(Document doc)
        {
            var legendsAll = new FilteredElementCollector(doc).OfClass(typeof(Autodesk.Revit.DB.View)).
                Cast<Autodesk.Revit.DB.View>().Where(x => x.ViewType == ViewType.Legend);
            TreeNode node = AppPenalTransferMore.myFormTransferMore.treeViewElementTransfer.Nodes.Add(Constants.LegendView);
            foreach (var item in legendsAll.OrderBy(x => x.Name))
            {
                node.Nodes.Add(item.Name);
            }
            var allViewTemplate = new FilteredElementCollector(doc).OfClass(typeof(Autodesk.Revit.DB.View))
                .Cast<Autodesk.Revit.DB.View>().Where(x => x.IsTemplate);
            if (allViewTemplate.Count() > 0)
            {
                TreeNode nodeTem = AppPenalTransferMore.myFormTransferMore.treeViewElementTransfer.Nodes.Add(Constants.TemplateView);
                foreach (var viewTem in allViewTemplate.OrderBy(x => x.Name))
                {
                    nodeTem.Nodes.Add(viewTem.Name);
                }
            }
            var fillPatten = new FilteredElementCollector(doc).OfClass(typeof(FillPatternElement));
            if (fillPatten.Count() > 0)
            {
                TreeNode nodePa = AppPenalTransferMore.myFormTransferMore.treeViewElementTransfer.Nodes.Add(Constants.Pattern);
                foreach (var patten in fillPatten.OrderBy(x => x.Name))
                {
                    nodePa.Nodes.Add(patten.Name);
                }
            }
            var lineStyle = doc.Settings.Categories.get_Item(BuiltInCategory.OST_Lines);
            TreeNode nodeLineSty = AppPenalTransferMore.myFormTransferMore.treeViewElementTransfer.Nodes.Add(Constants.LineStyle);
            foreach (Category line in lineStyle.SubCategories)
            {
                nodeLineSty.Nodes.Add(line.Name);
            }

            var allMaterial = new FilteredElementCollector(doc).OfClass(typeof(Material)).OrderBy(x => x.Name);
            TreeNode nodeMater = AppPenalTransferMore.myFormTransferMore.treeViewElementTransfer.Nodes.Add(Constants.Material);
            foreach (Material mat in allMaterial)
            {
                nodeMater.Nodes.Add(mat.Name);
            }
        }

        public void GetAllProject(UIApplication app)
        {
            Document docActive = app.ActiveUIDocument.Document;
            string nameActive = docActive.Title;
            var allDoc = app.Application.Documents;
            AppPenalTransferMore.myFormTransferMore.comboBoxToProject.DisplayMember = "Text";
            AppPenalTransferMore.myFormTransferMore.comboBoxToProject.ValueMember = "Value";
            foreach (Document docItem in allDoc)
            {
                if (docItem.Title != nameActive)
                {
                    AppPenalTransferMore.myFormTransferMore.comboBoxToProject.Items.Add(new { Text = docItem.Title, Value = docItem.Title });
                }
            }

        }
    }
}