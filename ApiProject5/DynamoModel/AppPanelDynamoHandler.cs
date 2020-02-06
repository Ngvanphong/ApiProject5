using ApiProject5.Helper;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System.Collections.Generic;
using System.Windows.Forms;

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
            if (selectLine.Count > 0)
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
                List<PointLength> listPointPara = getPointPara(curve, 0.000001);
                List<PointLength> listPointLengthExport = getPointLengthExport(listPoint, listPointPara);
                string[] row = new string[] { string.Empty, string.Empty, string.Empty, string.Empty };
                for (int k = 0; k < listPoint.Count; k++)
                {
                    if (listIndex.Exists(x => x == k))
                    {
                        row = new string[] { listPointLengthExport[k].Point.X.ToString(),listPointLengthExport[k].Point.Y.ToString(),
                            listPointLengthExport[k].Point.Z.ToString(),listPointLengthExport[k].Length.ToString(), k.ToString() };
                    }
                    else
                    {
                        row = new string[] { listPointLengthExport[k].Point.X.ToString(), listPointLengthExport[k].Point.Y.ToString(),
                            listPointLengthExport[k].Point.Z.ToString(),listPointLengthExport[k].Length.ToString(), string.Empty };
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

        public List<int> getPointRevit(IList<XYZ> listPoints, List<Element> listElements)
        {
            List<int> listResult = new List<int>();
            foreach (Element el in listElements)
            {
                LocationCurve curegrLoca = el.Location as LocationCurve;
                Curve curegr = curegrLoca.Curve;
                XYZ g1 = curegr.GetEndPoint(0);
                XYZ g2 = curegr.GetEndPoint(1);
                XYZ u = (g1 - g2).Normalize();
                double hmin = 100000000000;
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
                        startIndex = start;
                    }
                    start += 1;
                }
                listResult.Add(startIndex);
            }
            return listResult;
        }

        public List<PointLength> getPointPara(Curve splLine, double parameterCacula)
        {
            int nPoint = int.Parse((1 / parameterCacula).ToString());
            List<PointLength> listPointResult = new List<PointLength>();
            double curveLength = splLine.Length;
            double param1 = splLine.GetEndParameter(0);
            double param2 = splLine.GetEndParameter(1);

            for (int i = 0; i < nPoint; i++)
            {
                PointLength pointL = new PointLength();
                double paramCalc = param1 + ((param2 - param1) * parameterCacula * i);
                if (splLine.IsInside(paramCalc))
                {
                    double normParam = splLine.ComputeNormalizedParameter(paramCalc);
                    pointL.Point = splLine.Evaluate(normParam, true);
                    pointL.Length = (parameterCacula * i) * curveLength * 304.8;
                    listPointResult.Add(pointL);
                }
            }
            return listPointResult;
        }

        public List<PointLength> getPointLengthExport(IList<XYZ> listPointMain, List<PointLength> listPointPara)
        {
            List<PointLength> listResult = new List<PointLength>();
            foreach (var item in listPointMain)
            {
                PointLength pointLengthAdd = new PointLength();
                pointLengthAdd.Point = item;
                double lengthMin = double.MaxValue;
                foreach (var subitem in listPointPara)
                {
                    double length = item.DistanceTo(subitem.Point);
                    if (length < lengthMin)
                    {
                        lengthMin = length;
                        pointLengthAdd.Length = subitem.Length;
                    }
                }
                listResult.Add(pointLengthAdd);
            }
            return listResult;
        }
    }

    public class PointLength
    {
        public XYZ Point { set; get; }

        public double Length { set; get; }
    }
}