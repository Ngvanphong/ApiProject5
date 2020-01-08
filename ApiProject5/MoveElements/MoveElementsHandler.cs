using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiProject5.MoveElements
{
    public class MoveElementsHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            double x = double.Parse(AppPenalMoveElements.myFormMoveElements.textBoxDistanceX.Text) / 304.8;
            double y = double.Parse(AppPenalMoveElements.myFormMoveElements.textBoxDistanceY.Text) / 304.8;
            double z = double.Parse(AppPenalMoveElements.myFormMoveElements.textBoxDistanceZ.Text) / 304.8;
            XYZ vector = new XYZ(x, y, z);
            var allElements = new FilteredElementCollector(doc).WhereElementIsNotElementType().ToElementIds();
            var allElementsPin = new FilteredElementCollector(doc).WhereElementIsNotElementType().ToElements().Where(k => k.Pinned == true && k.CanBeLocked());
            List<ElementId> listPinActiion = new List<ElementId>();
            foreach (var pinEle in allElementsPin)
            {
                using (Transaction t3 = new Transaction(doc, "UnpinProject1"))
                {
                    t3.Start();
                    try
                    {
                        if (!Constants.CategoryName.Exists(n => n == pinEle.Category.Name))
                        {
                            pinEle.Pinned = false;
                            listPinActiion.Add(pinEle.Id);
                            t3.Commit();
                        }
                    }
                    catch
                    {
                        t3.RollBack();
                    }
                }
            }
            using (Transaction t = new Transaction(doc, "MoveElementsRevit"))
            {
                t.Start();
                try
                {
                    Autodesk.Revit.DB.ElementTransformUtils.MoveElements(doc, allElements, vector);
                    t.Commit();
                }
                catch (Exception e) { t.RollBack(); }
            }

            foreach (var pinEleId in listPinActiion)
            {
                using (Transaction t4 = new Transaction(doc, "PinProject2"))
                {
                    t4.Start();
                    try
                    {
                        Element el = doc.GetElement(pinEleId);
                        el.Pinned = true;
                        t4.Commit();
                    }
                    catch
                    {
                        t4.RollBack();
                    }
                }
            }
        }
        public string GetName()
        {
            return "MoveElementsHanndler2";
        }
    }
}