using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
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
                    Reference refSelect = uiDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element);
                    listSelectIds.Add(doc.GetElement(refSelect).Id);
                }
                ElementId mainElementId = doc.GetElement(uiDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element)).Id;
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
                            Transform tTran = bouding.Transform;
                            XYZ boxMin = bouding.Min;
                            XYZ boxMax = bouding.Max;
                            View view = doc.GetElement(new ElementId(int.Parse(elRotate.Id.ToString()) + 1)) as View;
                            XYZ vectorRo = view.RightDirection;
                            RotateElement(doc, boxMin, boxMax, vectorMain, vectorRo, id);
                        }
                        else if (elRotate.Category.Name == Category.GetCategory(doc, BuiltInCategory.OST_SectionBox).Name)
                        {
                            View3D view3d = doc.ActiveView as View3D;
                            BoundingBoxXYZ bouding = view3d.GetSectionBox();
                            XYZ boxMin = bouding.Min;
                            XYZ boxMax = bouding.Max;


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