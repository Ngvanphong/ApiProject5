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
            double deg = double.Parse(AppPenalMoveElements.myFormMoveElements.textBoxRotateProject.Text) * Math.PI / 180.0;
            XYZ vector = new XYZ(x, y, z);
            var filter = new FilteredElementCollector(doc);
            var viewSheetFilter = new FilteredElementCollector(doc).OfClass(typeof(ViewSheet)).Cast<ViewSheet>().ToList();
            var viewLegend = new FilteredElementCollector(doc).OfClass(typeof(View)).Cast<View>().ToList();
            List<ElementId> listIdExcept = new List<ElementId>();
            foreach (ViewSheet viewSheet in viewSheetFilter)
            {
                if (viewSheet != null)
                {
                    var listIdDependent = viewSheet.GetDependentElements(null);
                    listIdExcept.AddRange(listIdDependent);
                }
            }
            foreach (View item in viewLegend)
            {
                if (item.ViewType == ViewType.Legend || item.ViewType == ViewType.DraftingView)
                {
                    var listIdDependent = item.GetDependentElements(null);
                    listIdExcept.AddRange(listIdDependent);
                }
            }

            var allElement3D = new List<ElementId>();
            Autodesk.Revit.DB.View viewCurrent = doc.ActiveView;
            if (viewCurrent.ViewType != ViewType.ThreeD)
            {
                System.Windows.Forms.MessageBox.Show("You must go to 3D View");
                return;
            }
            
            var allElementsPin = filter.WhereElementIsNotElementType().ToElements().Where(k => k.Pinned == true && k.CanBeLocked());
            List<ElementId> listPinActiion = new List<ElementId>();
            foreach (var pinEle in allElementsPin)
            {
                using (Transaction t3 = new Transaction(doc, "UnpinProject1"))
                {
                    t3.Start();
                    try
                    {
                        if (!Constants.CategoryBuilt.Exists(n => n == (BuiltInCategory)pinEle.Category.Id.IntegerValue))
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

            var all3 = new FilteredElementCollector(doc, viewCurrent.Id).WhereElementIsNotElementType().ToElementIds().ToList();
            var sectionBox = new FilteredElementCollector(doc, viewCurrent.Id).WhereElementIsNotElementType()
                            .OfCategory(BuiltInCategory.OST_SectionBox).ToElementIds().ToList();
            allElement3D = all3.Except(sectionBox).ToList();
            Group group = null;
            using (Transaction t = new Transaction(doc, "groupElement"))
            {
                t.Start();
                group = doc.Create.NewGroup(allElement3D);
                t.Commit();
            }

            var allElements = filter.WhereElementIsNotElementType().ToElementIds();
            allElements = allElements.Except(listIdExcept).Except(allElement3D).ToList();
            allElements.Add(group.Id);


            if (x != 0 || y != 0 || z != 0)
            {
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
            }
            if (deg != 0)
            {
                using (Transaction t2 = new Transaction(doc, "RotateElementsRevit"))
                {
                    t2.Start();
                    try
                    {
                        Line line = Line.CreateBound(new XYZ(0, 0, 0), new XYZ(0, 0, 1));
                        Autodesk.Revit.DB.ElementTransformUtils.RotateElements(doc, allElements, line, deg);
                        t2.Commit();
                    }
                    catch (Exception e) { t2.RollBack(); }
                }
            }

            using (Transaction t7 = new Transaction(doc, "UpgroupElement"))
            {
                t7.Start();
                group.UngroupMembers();
                t7.Commit();
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