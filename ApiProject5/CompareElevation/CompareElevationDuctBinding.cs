using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.UI;
using System;
using System.Linq;

namespace ApiProject5.CompareElevation
{
    [Transaction(TransactionMode.Manual)]
    public class CompareElevationDuctBinding : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uiDoc = commandData.Application.ActiveUIDocument;
            Document doc = uiDoc.Document;
            Element elementMain = null;
            try
            {
                elementMain = doc.GetElement(uiDoc.Selection.GetElementIds().First());
            }
            catch
            {
                TaskDialog.Show("Error", "You must choose a duct or pipe");
                return Result.Succeeded;
            }
            XYZ M = null;
            XYZ N = null;
            try
            {
                M = uiDoc.Selection.PickPoint();
                N = uiDoc.Selection.PickPoint();
            }
            catch
            {
                TaskDialog.Show("Error", "You must choose points");
                return Result.Succeeded;
            }

            double angle = 45;
            double elevationNew = 500;
            try
            {
                angle = double.Parse(AngleAndElevationDuct.AngleDuct);
            }
            catch { }
            try
            {
                elevationNew = double.Parse(AngleAndElevationDuct.ElevationDuct);
            }
            catch { }

            if (elementMain.Category.Id == doc.Settings.Categories.get_Item(BuiltInCategory.OST_DuctCurves).Id)
            {
                Duct duct1 = elementMain as Duct;
                Duct duct2 = DevideDuctPoint(doc, M, duct1);

                Duct ductM = null;
                Duct ductDevide = PointMidDuct(doc, duct1, duct2, N, out ductM);
                Duct ductAfterDevide2 = DevideDuctPoint(doc, N, ductDevide);
                Duct ductN = null;
                Duct ductChange = FindDuctChange(doc, ductDevide, ductAfterDevide2, M, N, out ductN);

                using (Transaction t3 = new Transaction(doc, "ChangeElevationDuct"))
                {
                    t3.Start();
                    Parameter paraEle = ductChange.get_Parameter(BuiltInParameter.RBS_OFFSET_PARAM);
                    double offset = paraEle.AsDouble();
                    offset += elevationNew / 304.8;
                    paraEle.Set(offset);
                    t3.Commit();
                }
                LocationCurve location1 = ductChange.Location as LocationCurve;
                XYZ endPoint1 = location1.Curve.GetEndPoint(0);
                XYZ endPoint2 = location1.Curve.GetEndPoint(1);

                LocationCurve location2 = ductM.Location as LocationCurve;
                XYZ endPoint3 = location2.Curve.GetEndPoint(0);
                XYZ endPoint4 = location2.Curve.GetEndPoint(1);
                
                double num3 = endPoint2.X - endPoint1.X;
                double num4 = endPoint2.Y - endPoint1.Y;
                double num5 = endPoint4.X - endPoint3.X;
                double num6 = endPoint4.Y - endPoint3.Y;

                XYZ G;
                double AB = Math.Sqrt((endPoint1.X - endPoint2.X) * (endPoint1.X - endPoint2.X) + (endPoint1.Y - endPoint2.Y) * (endPoint1.Y - endPoint2.Y));
                double AC = Math.Sqrt((endPoint1.X - endPoint3.X) * (endPoint1.X - endPoint3.X) + (endPoint1.Y - endPoint3.Y) * (endPoint1.Y - endPoint3.Y));
                double CB = Math.Sqrt((endPoint2.X - endPoint3.X) * (endPoint2.X - endPoint3.X) + (endPoint2.Y - endPoint3.Y) * (endPoint2.Y - endPoint3.Y));
                M = Math.Abs(AC - AB - CB) >= 0.0001 ? endPoint1 : endPoint2;
                double BD = Math.Sqrt((endPoint2.X - endPoint4.X) * (endPoint2.X - endPoint4.X) + (endPoint2.Y - endPoint4.Y) * (endPoint2.Y - endPoint4.Y));
                double CD = Math.Sqrt((endPoint3.X - endPoint4.X) * (endPoint3.X - endPoint4.X) + (endPoint3.Y - endPoint4.Y) * (endPoint3.Y - endPoint4.Y));
                G = Math.Abs(BD - CB - CD) >= 0.0001 ? endPoint4 : endPoint3;
                double x;
                double y;
                if (angle != 90.0)
                {
                    double num2 = Math.Abs(endPoint1.Z - endPoint3.Z) / Math.Tan(angle * Math.PI / 180.0);
                    double num7 = num3 * num3 + num4 * num4;
                    double num8 = 2.0 * num3 * (endPoint1.X - M.X) + 2.0 * num4 * (endPoint1.Y - M.Y);
                    double num9 = (endPoint1.X - M.X) * (endPoint1.X - M.X) + (endPoint1.Y - M.Y) * (endPoint1.Y - M.Y) - num2 * num2;
                    double num10 = (-num8 + Math.Sqrt(num8 * num8 - 4.0 * num7 * num9)) / (2.0 * num7);
                    double num11 = (-num8 - Math.Sqrt(num8 * num8 - 4.0 * num7 * num9)) / (2.0 * num7);
                    double num12 = endPoint1.X + num3 * num10;
                    double num13 = endPoint1.Y + num4 * num10;
                    double num14 = endPoint1.X + num3 * num11;
                    double num15 = endPoint1.Y + num4 * num11;
                    if (Math.Abs(Math.Sqrt((endPoint2.X - num12) * (endPoint2.X - num12) + (endPoint2.Y - num13) * (endPoint2.Y - num13))
                        - Math.Sqrt((M.X - endPoint2.X) * (M.X - endPoint2.X) + (M.Y - endPoint2.Y) * (M.Y - endPoint2.Y)) - Math.Sqrt((M.X - num12) * (M.X - num12) + (M.Y - num13) * (M.Y - num13))) < 0.0001)
                    {
                        x = num12;
                        y = num13;
                    }
                    else
                    {
                        x = num14;
                        y = num15;
                    }
                }
                else
                {
                    x = M.X;
                    y = M.Y;
                }
                XYZ K = new XYZ(x, y, endPoint3.Z);
                ChangeCurveAtPoint(doc, ductM, M, K);
                



            }
            else
            {
            }

            return Result.Succeeded;
        }

        private Duct DevideDuctPoint(Document doc, XYZ M, Duct duct)
        {
            Duct newDuct = null;
            LocationCurve locationCurve = duct.Location as LocationCurve;
            XYZ endPoint1 = locationCurve.Curve.GetEndPoint(0);
            XYZ endPoint2 = locationCurve.Curve.GetEndPoint(1);
            double distance = M.DistanceTo(endPoint1);
            XYZ xyz = endPoint2.Subtract(endPoint1).Normalize();
            XYZ ptBreak = endPoint1.Add(xyz.Multiply(distance));
            using (Transaction t1 = new Transaction(doc, "DevieDuct"))
            {
                t1.Start();
                ElementId id = MechanicalUtils.BreakCurve(doc, duct.Id, ptBreak);
                newDuct = doc.GetElement(id) as Duct;
                t1.Commit();
            }
            return newDuct;
        }

        private Duct PointMidDuct(Document doc, Duct duct1, Duct duct2, XYZ N, out Duct ductNotDevide)
        {
            Duct ductDevide = duct2;
            ductNotDevide = duct1;
            LocationCurve locationCurve = duct1.Location as LocationCurve;
            XYZ endPoint1 = locationCurve.Curve.GetEndPoint(0);
            XYZ endPoint2 = locationCurve.Curve.GetEndPoint(1);
            double d1 = N.DistanceTo(endPoint1);
            double d2 = N.DistanceTo(endPoint2);
            double d = endPoint1.DistanceTo(endPoint2);
            if (Math.Abs(d - d1 - d2) < 0.0001)
            {
                ductDevide = duct1;
                ductNotDevide = duct2;
            }
            return ductDevide;
        }

        private Duct FindDuctChange(Document doc, Duct duct1, Duct duct2, XYZ M, XYZ N, out Duct ductNotChange)
        {
            Duct ductChange = duct2;
            ductNotChange = duct1;
            if (CheckIsSample(doc, duct1, M, N))
            {
                ductChange = duct1;
                ductNotChange = duct2;
            }
            return ductChange;
        }

        public void ChangeCurveAtPoint(Document doc, Element element, XYZ M, XYZ G)
        {
            LocationCurve locationCurve = element.Location as LocationCurve;
            XYZ endPoint1 = locationCurve.Curve.GetEndPoint(0);
            XYZ endPoint2 = locationCurve.Curve.GetEndPoint(1);
            if (endPoint1.IsAlmostEqualTo(M))
            {
                using (Transaction t2 = new Transaction(doc, "ChangeCurve"))
                {
                    t2.Start();
                    Curve newCurve = Line.CreateBound(G, endPoint2);
                    locationCurve.Curve = newCurve;
                    t2.Commit();
                }
            }
            else
            {
                using (Transaction t2 = new Transaction(doc, "ChangeCurve"))
                {
                    t2.Start();
                    Curve newCurve = Line.CreateBound(endPoint1, G);
                    locationCurve.Curve = newCurve;
                    t2.Commit();
                }
            }
        }

        private bool CheckIsSample(Document doc, Element element, XYZ M, XYZ N)
        {
            bool result = false;
            LocationCurve locationCurve = element.Location as LocationCurve;
            XYZ endPoint1 = locationCurve.Curve.GetEndPoint(0);
            XYZ endPoint2 = locationCurve.Curve.GetEndPoint(1);
            if (endPoint1.IsAlmostEqualTo(M) && endPoint2.IsAlmostEqualTo(N))
            {
                result = true;
            }
            else if (endPoint1.IsAlmostEqualTo(N) && endPoint2.IsAlmostEqualTo(M))
            {
                result = true;
            }
            return result;
        }

        private void CreateConnectEbow(Document doc, Duct duct1, XYZ M, Duct duct2, XYZ E)
        {
            Connector connector1 = (Connector)null;
            ConnectorSetIterator connectorSetIterator1 = duct1.ConnectorManager.Connectors.ForwardIterator();
            while (connectorSetIterator1.MoveNext())
            {
                connector1 = connectorSetIterator1.Current as Connector;
                if (connector1.Origin.IsAlmostEqualTo(M))
                    break;
            }
            Connector connector2 = (Connector)null;
            ConnectorSetIterator connectorSetIterator2 = duct2.ConnectorManager.Connectors.ForwardIterator();
            while (connectorSetIterator2.MoveNext())
            {
                connector2 = connectorSetIterator2.Current as Connector;
                if (connector2.Origin.IsAlmostEqualTo(E))
                    break;
            }
            using (Transaction t32 = new Transaction(doc, "Connector2"))
            {
                t32.Start();
                doc.Create.NewElbowFitting(connector1, connector2);
                t32.Commit();
            }
        }
    }
}