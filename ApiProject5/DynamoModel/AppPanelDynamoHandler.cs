using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApiProject5.Helper;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
namespace ApiProject5.DynamoModel
{
    public class AppPanelDynamoHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            Category cate = doc.Settings.Categories.get_Item(BuiltInCategory.OST_Lines);
            var categoryFilter = new SelectionFilterCategory(cate);
            if (AppPanelDynamoModel.chooseMainLine)
            {
                try
                {
                    var refMain = app.ActiveUIDocument.Selection.PickObject(ObjectType.Element, categoryFilter);
                    AppPanelDynamoModel.MainLine = doc.GetElement(refMain);
                    AppPanelDynamoModel.chooseMainLine = false;
                }
                catch
                {
                    MessageBox.Show("You must choose a main line");
                    AppPanelDynamoModel.chooseMainLine = true;
                    return;
                }
            }
            
            var selectLine = app.ActiveUIDocument.Selection.PickObjects(ObjectType.Element, categoryFilter);
            List<Element> listLine = new List<Element>();
            if (selectLine.Count>0)
            {
                foreach (var line in selectLine)
                {
                    Element el = doc.GetElement(line);
                    listLine.Add(el);
                }
                
                LocationCurve locationCurve = AppPanelDynamoModel.MainLine.Location as LocationCurve;
                Curve curve = locationCurve.Curve;
                IList<XYZ> listPoint = curve.Tessellate();
                List<int> listIndex = getPointRevit(listPoint, listLine);
                string[] row = new string[] { string.Empty, string.Empty, string.Empty,string.Empty };
                for(int k= 0; k < listPoint.Count; k++)
                {
                    if (listIndex.Exists(x=>x==k))
                    {
                        row = new string[] { listPoint[k].X.ToString(), listPoint[k].Y.ToString(), listPoint[k].Z.ToString(), k.ToString() };
                    }
                    else
                    {
                        row = new string[] { listPoint[k].X.ToString(), listPoint[k].Y.ToString(), listPoint[k].Z.ToString(), string.Empty };
                    }
                    
                    AppPanelDynamoModel.myFormDynamoModel.dataGridViewPoint.Rows.Add(row);
                }

            }
            else
            {
                MessageBox.Show("You must select lines");
                return;
            }
           

        }

        public string GetName()
        {
            return "DynamoPointHandler";
        }
        public List<int> getPointRevit(IList<XYZ> listPoints,List<Element> listElements)
        {
            List<int> listResult = new List<int>();
            foreach(Element el in listElements)
            {
                LocationCurve curegrLoca = el.Location as LocationCurve;
                Curve curegr = curegrLoca.Curve;
                XYZ g1 = curegr.GetEndPoint(0);
                XYZ g2 = curegr.GetEndPoint(1);
                XYZ u = (g1 - g2).Normalize();
                double hmin = 100000000000;
                XYZ Gsta = new XYZ(0, 0, 0);
                int start = 0;
                int startIndex = 0;
                foreach (var p in listPoints)
                {

                    double k = (u.X * p.X + u.Y * p.Y + u.Z * p.Z - u.X * g1.X - u.Y * g1.Y - u.Z * g1.Z) / (u.X * u.X + u.Y * u.Y + u.Z * u.Z);
                    XYZ H = new XYZ(g1.X + u.X * k, g1.Y + u.Y * k, g1.Z + u.Z * k);
                    double h = (p.X - H.X) * (p.X - H.X) + (p.Y - H.Y) * (p.Y - H.Y) + (p.Z - H.Z) * (p.Z - H.Z);
                    if (h < hmin)
                    {
                        hmin = h;
                        Gsta = H;
                        startIndex = start;
                    }
                    start += 1;
                }
                listResult.Add(startIndex);
            }

            return listResult;
        }
    }
}
