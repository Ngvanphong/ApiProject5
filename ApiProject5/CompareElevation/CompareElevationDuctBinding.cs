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
            XYZ M1 = null;
            XYZ N1 = null;
            try
            {
                M1 = uiDoc.Selection.PickPoint();
                N1 = uiDoc.Selection.PickPoint();
            }
            catch
            {
                TaskDialog.Show("Error", "You must choose points");
                return Result.Succeeded;
            }
            LocationCurve locationMain = elementMain.Location as LocationCurve;
            XYZ pointMain1 = locationMain.Curve.GetEndPoint(0);
            XYZ M = new XYZ(M1.X,M1.Y,pointMain1.Z);
            XYZ N = new XYZ(N1.X, N1.Y, pointMain1.Z);

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
            ElementId levelId = elementMain.get_Parameter(BuiltInParameter.RBS_START_LEVEL_PARAM).AsElementId();
            
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
                CreateConnectDuctMain(doc, angle, ductChange, ductM, M,levelId);
                CreateConnectDuctMain(doc, angle, ductChange, ductN, N,levelId);


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

        private Duct CreateNewDuctCus(Document doc, XYZ p1, XYZ p2, ElementId ductSystem, ElementId levelId, DuctType ductType = null)
        {
            Duct duct = null;
            using (Transaction t5 = new Transaction(doc, "CreateDuctPipe2"))
            {
                t5.Start();
                duct = Duct.Create(doc, ductSystem, ductType.Id, levelId, p1, p2);
                t5.Commit();
            }
            return duct;
        }

        private void ChangeSizeDuct(Document doc, double diameter, double width, double height, Duct element)
        {
            using (Transaction t11 = new Transaction(doc, "SetSizeDuct"))
            {
                t11.Start();
                if (diameter != 0)
                {
                    element.get_Parameter(BuiltInParameter.RBS_CURVE_DIAMETER_PARAM).Set(diameter);
                }
                else
                {
                    element.get_Parameter(BuiltInParameter.RBS_CURVE_WIDTH_PARAM).Set(width);
                    element.get_Parameter(BuiltInParameter.RBS_CURVE_HEIGHT_PARAM).Set(height);
                }
                t11.Commit();
            }
        }

        private void CreateConnectDuctMain(Document doc, double angle,Duct ductChange,Duct ductM,XYZ M,ElementId levelId)
        {
            double width = 0.0;
            double height = 0.0;
            double diameter = 0.0;
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
            if (Math.Abs(M.X - endPoint1.X) < 0.0001 && Math.Abs(M.Y - endPoint1.Y) < 0.0001)
            {
                M = endPoint1;
            }
            else
            {
                M = endPoint2;
            }
            if (Math.Abs(M.X - endPoint3.X) < 0.0001 && Math.Abs(M.Y - endPoint3.Y) < 0.0001)
            {
                G = endPoint3;
            }
            else
            {
                G = endPoint4;
            }

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
            if (angle != 90)
            {
                ChangeCurveAtPoint(doc, ductM, G, K);
            }
            DuctType ductType = ductChange.DuctType;
            ElementId ductSystem = ductChange.get_Parameter(BuiltInParameter.RBS_DUCT_SYSTEM_TYPE_PARAM).AsElementId();
            Duct newDuctCus1 = CreateNewDuctCus(doc, M, K, ductSystem, levelId, ductType);
            try
            {
                diameter = ductChange.Diameter;
            }
            catch
            {
                width = ductChange.Width;
                height = ductChange.Height;
            }
            ChangeSizeDuct(doc, diameter, width, height, newDuctCus1);
            CreateConnectEbow(doc, ductChange, M, newDuctCus1, M);
            CreateConnectEbow(doc, ductM, K, newDuctCus1, K);
        }
    }
}