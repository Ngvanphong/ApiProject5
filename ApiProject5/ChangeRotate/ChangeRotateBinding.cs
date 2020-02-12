using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiProject5.ChangeRotate
{
    [Transaction(TransactionMode.Manual)]
    public class ChangeRotateBinding : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uiDoc = commandData.Application.ActiveUIDocument;
            Document doc = uiDoc.Document;
            try
            {
                List<ElementId> listSelectIds = uiDoc.Selection.GetElementIds().ToList();
                if (listSelectIds.Count == 0)
                {
                    Reference refSelect = uiDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element, "Select element allign");
                    listSelectIds.Add(doc.GetElement(refSelect).Id);
                }

                ElementId mainElementId = doc.GetElement(uiDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element, "Select a reference element")).Id;
                Element mainElement = doc.GetElement(mainElementId);
                LocationCurve curve = mainElement.Location as LocationCurve;
                XYZ m1 = curve.Curve.GetEndPoint(0);
                XYZ m2 = curve.Curve.GetEndPoint(1);
                XYZ vectorMain = m2 - m1;
                foreach (ElementId id in listSelectIds)
                {
                    try
                    {
                        Element elRotate = doc.GetElement(id);
                        if (elRotate.Category.Name == Category.GetCategory(doc, BuiltInCategory.OST_Views).Name)
                        {
                            BoundingBoxXYZ bouding = elRotate.get_BoundingBox(doc.ActiveView);
                            XYZ boxMin = bouding.Min;
                            XYZ boxMax = bouding.Max;
                            View view = doc.GetElement(new ElementId(int.Parse(elRotate.Id.ToString()) + 1)) as View;
                            XYZ vectorRo = view.RightDirection;
                            RotateElement(doc, boxMin, boxMax, vectorMain, vectorRo, id);
                        }
                        else if (elRotate.Category.Name == Category.GetCategory(doc, BuiltInCategory.OST_VolumeOfInterest).Name)
                        {
                            BoundingBoxXYZ bouding = elRotate.get_BoundingBox(doc.ActiveView);
                            XYZ boxMin = bouding.Min;
                            XYZ boxMax = bouding.Max;
                            var pointElement = uiDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.PointOnElement, "Choose a point on edge of element allign");
                            XYZ pointM = pointElement.GlobalPoint;
                            Options option = new Options();
                            GeometryElement geo = elRotate.get_Geometry(option);
                            XYZ vectorRo = null;
                            foreach (GeometryObject obj in geo)
                            {
                                Line line = obj as Line;
                                XYZ p = line.GetEndPoint(0);
                                XYZ q = line.GetEndPoint(1);
                                double l1 = p.DistanceTo(pointM);
                                double l2 = q.DistanceTo(pointM);
                                double l = p.DistanceTo(q);
                                if (l1 + l2 == l)
                                {
                                    vectorRo = (q - p).Normalize();
                                    break;
                                }
                            }
                            RotateElement(doc, boxMin, boxMax, vectorMain, vectorRo, id);
                        }
                        else if (elRotate.Category.Name == Category.GetCategory(doc, BuiltInCategory.OST_SectionBox).Name)
                        {
                            View3D view3d = doc.ActiveView as View3D;
                            var box = view3d.GetSectionBox();
                            var points = new[]
                               {
                                    box.Max,
                                    new XYZ(box.Min.X, box.Max.Y, box.Max.Z),
                                    new XYZ(box.Min.X, box.Min.Y, box.Max.Z),
                                    new XYZ(box.Max.X, box.Min.Y, box.Max.Z)
                                }.Select(box.Transform.OfPoint).ToList();
                            var lines = new[]
                                {
                                    Line.CreateBound(points[0], points[1]),
                                    Line.CreateBound(points[1], points[2]),
                                    Line.CreateBound(points[2], points[3]),
                                    Line.CreateBound(points[3], points[0])
                                };
                            var pointElement = uiDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.PointOnElement, "Choose a point near center on the edge of element allign");
                            XYZ pointM = pointElement.GlobalPoint;
                            XYZ vectorRo = null;
                            foreach (Line line in lines)
                            {
                                XYZ p = line.GetEndPoint(0);
                                XYZ q = line.GetEndPoint(1);
                                XYZ middle = (p + q) / 2;
                                double minDistance = double.MaxValue;
                                double distance = pointM.DistanceTo(middle);
                                if (minDistance>distance)
                                {
                                    minDistance = distance;
                                    vectorRo = (q - p).Normalize();
                                }
                            }
                            RotateElement(doc, box.Min, box.Max, vectorMain, vectorRo, id);
                        }
                        else
                        {
                            LocationCurve curveRo = elRotate.Location as LocationCurve;
                            XYZ p1 = curveRo.Curve.GetEndPoint(0);
                            XYZ p2 = curveRo.Curve.GetEndPoint(1);
                            XYZ vectorRo = p2 - p1;
                            RotateElement(doc, p1, p2, vectorMain, vectorRo, id);
                        }
                    }
                    catch { continue; }
                }
            }
            catch { }
            return Result.Succeeded;
        }

        public void RotateElement(Document doc, XYZ p1, XYZ p2, XYZ vectorMain, XYZ vectorRo, ElementId id)
        {
            double angleRo = vectorRo.AngleTo(vectorMain);
            if (angleRo > Math.PI / 2)
            {
                angleRo = -Math.PI + angleRo;
            }
            bool isClock = false;
            //This is the main code(Clock)
            if (vectorRo.X * vectorMain.Y > vectorRo.Y * vectorMain.X)
            {
                isClock = true;
            }
            using (Transaction t2 = new Transaction(doc, "RotateMatchLine"))
            {
                t2.Start();
                var vecter = doc.ActiveView.ViewDirection.Normalize();
                Line axis = null;
                XYZ midlePoint = (p1 + p2) / 2;
                if (vecter.Z != 0)
                {
                    axis = Line.CreateBound(midlePoint, new XYZ(midlePoint.X, midlePoint.Y, midlePoint.Z + 10));
                }
                if (isClock == false) angleRo = -angleRo;
                ElementTransformUtils.RotateElement(doc, id, axis, angleRo);
                t2.Commit();
            }
        }
    }
}