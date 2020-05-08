using ApiProject5.Helper;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Linq;

namespace ApiProject5.DuctPipe
{
    [Transaction(TransactionMode.Manual)]
    public class DuctPipeBinding : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            UIDocument activeUiDocument = commandData.Application.ActiveUIDocument;
            Document document = activeUiDocument.Document;
            double angle = 45.0;
            try
            {
                angle = double.Parse(StatisAngleViewer.StatisViewerShow);
            }
            catch
            {
            }
            Element element1;
            try
            {
                element1 = document.GetElement(activeUiDocument.Selection.GetElementIds().First<ElementId>());
            }
            catch
            {
                TaskDialog.Show("Error", "You must choose a duct or pipe");
                return Result.Succeeded;
            }
            Category category = element1.Category;
            LocationCurve location1 = element1.Location as LocationCurve;
            XYZ endPoint1 = location1.Curve.GetEndPoint(0);
            XYZ endPoint2 = location1.Curve.GetEndPoint(1);
            Element element2;
            LocationCurve location2=null;
            try
            {
                Reference reference = activeUiDocument.Selection.PickObject(ObjectType.Element, (ISelectionFilter)new SelectionFilterCategory(category));
                element2 = document.GetElement(reference);
                location2 = document.GetElement(reference).Location as LocationCurve;
            }
            catch
            {
                return Result.Succeeded;
            }
            XYZ endPoint3 = location2.Curve.GetEndPoint(0);
            XYZ endPoint4 = location2.Curve.GetEndPoint(1);
            XYZ xyz1 = (endPoint2 - endPoint1).Normalize();
            XYZ source = (endPoint4 - endPoint3).Normalize();
            double num3 = endPoint2.X - endPoint1.X;
            double num4 = endPoint2.Y - endPoint1.Y;
            double num5 = endPoint4.X - endPoint3.X;
            double num6 = endPoint4.Y - endPoint3.Y;
            XYZ xyz2;
            XYZ xyz3;
            if (xyz1.IsAlmostEqualTo(source) || xyz1.IsAlmostEqualTo(-source))
            {
                double num2 = Math.Sqrt((endPoint1.X - endPoint2.X) * (endPoint1.X - endPoint2.X) + (endPoint1.Y - endPoint2.Y) * (endPoint1.Y - endPoint2.Y));
                double num7 = Math.Sqrt((endPoint1.X - endPoint3.X) * (endPoint1.X - endPoint3.X) + (endPoint1.Y - endPoint3.Y) * (endPoint1.Y - endPoint3.Y));
                double num8 = Math.Sqrt((endPoint2.X - endPoint3.X) * (endPoint2.X - endPoint3.X) + (endPoint2.Y - endPoint3.Y) * (endPoint2.Y - endPoint3.Y));
                xyz2 = Math.Abs(num7 - num2 - num8) >= 0.0001 ? endPoint1 : endPoint2;
                double num9 = Math.Sqrt((endPoint2.X - endPoint4.X) * (endPoint2.X - endPoint4.X) + (endPoint2.Y - endPoint4.Y) * (endPoint2.Y - endPoint4.Y));
                double num10 = Math.Sqrt((endPoint3.X - endPoint4.X) * (endPoint3.X - endPoint4.X) + (endPoint3.Y - endPoint4.Y) * (endPoint3.Y - endPoint4.Y));
                xyz3 = Math.Abs(num9 - num8 - num10) >= 0.0001 ? endPoint4 : endPoint3;
            }
            else
            {
                double num2 = (num3 * endPoint3.Y + num4 * endPoint1.X - endPoint1.Y * num3 - endPoint3.X * num4) / (num4 * num5 - num3 * num6);
                xyz3 = new XYZ(endPoint3.X + num5 * num2, endPoint3.Y + num6 * num2, endPoint3.Z);
                double num7 = Math.Sqrt((endPoint1.X - endPoint2.X) * (endPoint1.X - endPoint2.X) + (endPoint1.Y - endPoint2.Y) * (endPoint1.Y - endPoint2.Y));
                double num8 = Math.Sqrt((endPoint1.X - xyz3.X) * (endPoint1.X - xyz3.X) + (endPoint1.Y - xyz3.Y) * (endPoint1.Y - xyz3.Y));
                double num9 = Math.Sqrt((endPoint2.X - xyz3.X) * (endPoint2.X - xyz3.X) + (endPoint2.Y - xyz3.Y) * (endPoint2.Y - xyz3.Y));
                xyz2 = Math.Abs(num8 - num7 - num9) >= 0.0001 ? endPoint1 : endPoint2;
            }
            double x;
            double y;
            if (angle != 90.0)
            {
                double num2 = Math.Abs(endPoint1.Z - endPoint3.Z) / Math.Tan(angle * Math.PI / 180.0);
                double num7 = num3 * num3 + num4 * num4;
                double num8 = 2.0 * num3 * (endPoint1.X - xyz2.X) + 2.0 * num4 * (endPoint1.Y - xyz2.Y);
                double num9 = (endPoint1.X - xyz2.X) * (endPoint1.X - xyz2.X) + (endPoint1.Y - xyz2.Y) * (endPoint1.Y - xyz2.Y) - num2 * num2;
                double num10 = (-num8 + Math.Sqrt(num8 * num8 - 4.0 * num7 * num9)) / (2.0 * num7);
                double num11 = (-num8 - Math.Sqrt(num8 * num8 - 4.0 * num7 * num9)) / (2.0 * num7);
                double num12 = endPoint1.X + num3 * num10;
                double num13 = endPoint1.Y + num4 * num10;
                double num14 = endPoint1.X + num3 * num11;
                double num15 = endPoint1.Y + num4 * num11;
                if (Math.Abs(Math.Sqrt((endPoint2.X - num12) * (endPoint2.X - num12) + (endPoint2.Y - num13) * (endPoint2.Y - num13)) - Math.Sqrt((xyz2.X - endPoint2.X) * (xyz2.X - endPoint2.X) + (xyz2.Y - endPoint2.Y) * (xyz2.Y - endPoint2.Y)) - Math.Sqrt((xyz2.X - num12) * (xyz2.X - num12) + (xyz2.Y - num13) * (xyz2.Y - num13))) < 0.0001)
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
                x = xyz2.X;
                y = xyz2.Y;
            }
            XYZ xyz4 = new XYZ(x, y, endPoint1.Z);
            XYZ xyz5 = new XYZ(x, y, endPoint3.Z);
            ElementId levelId = element1.GetParameters("Reference Level").First<Parameter>().AsElementId();
            double width = 0.0;
            double height = 0.0;
            double diameter1 = 0.0;
            if (category.Id.IntegerValue == int.Parse(BuiltInCategory.OST_DuctSystem.ToString()))
            {
                Duct duct2_1 = element2 as Duct;
                Duct duct = element1 as Duct;
                try
                {
                    diameter1 = duct.Diameter;
                }
                catch
                {
                    width = duct.Width;
                    height = duct.Height;
                }
                DuctType ductType = duct.DuctType;
                ElementId ductSystem = duct.get_Parameter(BuiltInParameter.RBS_DUCT_SYSTEM_TYPE_PARAM).AsElementId();
                Duct newDuctCus1 = this.CreateNewDuctCus(document, xyz2, xyz5, ductSystem, levelId, ductType);
                this.ChangeSizeDuct(document, diameter1, width, height, newDuctCus1);
                Duct duct2_2 = duct;
                if (newDuctCus1 != null)
                    this.CreateConnectEbow(document, newDuctCus1, xyz2, duct2_2, xyz2);
                try
                {
                    if (xyz1.IsAlmostEqualTo(source) || xyz1.IsAlmostEqualTo(-source))
                    {
                        this.CreateConnectEbow(document, newDuctCus1, xyz5, duct2_1, xyz3);
                    }
                    else
                    {
                        try
                        {
                            Duct newDuctCus2 = CreateNewDuctCus(document, xyz5, xyz3, ductSystem, levelId, ductType);
                            ChangeSizeDuct(document, diameter1, width, height, newDuctCus2);
                            if (newDuctCus2 != null && !xyz1.IsAlmostEqualTo(source) && !xyz1.IsAlmostEqualTo(-source))
                            {
                                CreateConnectEbow(document, newDuctCus2, xyz5, newDuctCus1, xyz5);
                                using (TransactionGroup transactionGroup = new TransactionGroup(document, "groupConnectDuctTee"))
                                {
                                    int num2 = (int)transactionGroup.Start();
                                    try
                                    {
                                        CreateConectTree(document, newDuctCus2, xyz3, duct2_1);
                                        int num7 = (int)transactionGroup.Commit();
                                    }
                                    catch
                                    {
                                        int num7 = (int)transactionGroup.RollBack();
                                    }
                                }
                            }
                        }
                        catch
                        {
                            if (!xyz1.IsAlmostEqualTo(source) && !xyz1.IsAlmostEqualTo(-source))
                            {
                                using (TransactionGroup transactionGroup = new TransactionGroup(document, "groupConnectDuctTee90"))
                                {
                                    int num2 = (int)transactionGroup.Start();
                                    try
                                    {
                                        this.CreateConectTree(document, newDuctCus1, xyz3, duct2_1);
                                        int num7 = (int)transactionGroup.Commit();
                                    }
                                    catch
                                    {
                                        int num7 = (int)transactionGroup.RollBack();
                                    }
                                }
                            }
                        }
                    }
                }
                catch
                {
                }
            }
            else
            {
                Pipe pipe2_1 = element2 as Pipe;
                Pipe pipe = element1 as Pipe;
                double diameter2 = pipe.Diameter;
                PipeType pipeType = pipe.PipeType;
                ElementId pipeSystem = pipe.get_Parameter(BuiltInParameter.RBS_PIPING_SYSTEM_TYPE_PARAM).AsElementId();
                Pipe newPipeCus1 = CreateNewPipeCus(document, xyz2, xyz5, pipeSystem, levelId, pipeType);
                ChangeSizePipe(document, diameter2, width, height, newPipeCus1);
                Pipe pipe2_2 = pipe;
                if (newPipeCus1 != null)
                    CreateConnectEbowPipe(document, newPipeCus1, xyz2, pipe2_2, xyz2);
                try
                {
                    if (xyz1.IsAlmostEqualTo(source) || xyz1.IsAlmostEqualTo(-source))
                    {
                        CreateConnectEbowPipe(document, newPipeCus1, xyz5, pipe2_1, xyz3);
                    }
                    else
                    {
                        try
                        {
                            Pipe newPipeCus2 = this.CreateNewPipeCus(document, xyz5, xyz3, pipeSystem, levelId, pipeType);
                            this.ChangeSizePipe(document, diameter2, width, height, newPipeCus2);
                            if (newPipeCus2 != null && !xyz1.IsAlmostEqualTo(source) && !xyz1.IsAlmostEqualTo(-source))
                            {
                                this.CreateConnectEbowPipe(document, newPipeCus2, xyz5, newPipeCus1, xyz5);
                                using (TransactionGroup transactionGroup = new TransactionGroup(document, "groupConnectPipeTee"))
                                {
                                    int num2 = (int)transactionGroup.Start();
                                    try
                                    {
                                        CreateConectTreePipe(document, newPipeCus2, xyz3, pipe2_1);
                                        int num7 = (int)transactionGroup.Commit();
                                    }
                                    catch
                                    {
                                        int num7 = (int)transactionGroup.RollBack();
                                    }
                                }
                            }
                        }
                        catch
                        {
                            if (!xyz1.IsAlmostEqualTo(source) && !xyz1.IsAlmostEqualTo(-source))
                            {
                                using (TransactionGroup transactionGroup = new TransactionGroup(document, "groupConnectPipeTee90"))
                                {
                                    int num2 = (int)transactionGroup.Start();
                                    try
                                    {
                                        this.CreateConectTreePipe(document, newPipeCus1, xyz3, pipe2_1);
                                        int num7 = (int)transactionGroup.Commit();
                                    }
                                    catch
                                    {
                                        int num7 = (int)transactionGroup.RollBack();
                                    }
                                }
                            }
                        }
                    }
                }
                catch
                {
                }
            }
            return Result.Succeeded;
        }

        public Duct CreateNewDuctCus(
          Document doc,
          XYZ p1,
          XYZ p2,
          ElementId ductSystem,
          ElementId levelId,
          DuctType ductType = null)
        {
            Duct duct = (Duct)null;
            using (Transaction t5 = new Transaction(doc, "CreateDuctPipe2"))
            {
                t5.Start();
                duct = Duct.Create(doc, ductSystem, ductType.Id, levelId, p1, p2);
                t5.Commit();
            }
            return duct;
        }

        public Pipe CreateNewPipeCus(
          Document doc,
          XYZ p1,
          XYZ p2,
          ElementId pipeSystem,
          ElementId levelId,
          PipeType pipeType = null)
        {
            Pipe pipe = (Pipe)null;
            using (Transaction t15 = new Transaction(doc, "CreateDuctPipe3"))
            {
                t15.Start();
                pipe = Pipe.Create(doc, pipeSystem, pipeType.Id, levelId, p1, p2);
                t15.Commit();
            }
            return pipe;
        }

        public void CreateConnectEbow(Document doc, Duct duct1, XYZ M, Duct duct2, XYZ E)
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
            using (Transaction transaction = new Transaction(doc, "Connector2"))
            {
                int num1 = (int)transaction.Start();
                doc.Create.NewElbowFitting(connector1, connector2);
                int num2 = (int)transaction.Commit();
            }
        }

        public void CreateConectTree(Document doc, Duct duct1, XYZ G, Duct duct2)
        {
            Duct duct = (Duct)null;
            Curve curve = (duct2.Location as LocationCurve).Curve;
            XYZ endPoint1 = curve.GetEndPoint(0);
            XYZ endPoint2 = curve.GetEndPoint(1);
            double num1 = Math.Sqrt((endPoint1.X - G.X) * (endPoint1.X - G.X) + (endPoint1.Y - G.Y) * (endPoint1.Y - G.Y));
            XYZ xyz = endPoint2.Subtract(endPoint1).Normalize();
            XYZ ptBreak = endPoint1.Add(xyz.Multiply(num1));
            using (Transaction transaction = new Transaction(doc, "DevieDuct"))
            {
                int num2 = (int)transaction.Start();
                ElementId id = MechanicalUtils.BreakCurve(doc, duct2.Id, ptBreak);
                duct = doc.GetElement(id) as Duct;
                int num3 = (int)transaction.Commit();
            }
            Connector connector3 = (Connector)null;
            ConnectorSetIterator connectorSetIterator1 = duct1.ConnectorManager.Connectors.ForwardIterator();
            while (connectorSetIterator1.MoveNext())
            {
                connector3 = connectorSetIterator1.Current as Connector;
                if (connector3.Origin.IsAlmostEqualTo(G))
                    break;
            }
            Connector connector1 = (Connector)null;
            ConnectorSetIterator connectorSetIterator2 = duct2.ConnectorManager.Connectors.ForwardIterator();
            while (connectorSetIterator2.MoveNext())
            {
                connector1 = connectorSetIterator2.Current as Connector;
                if (connector1.Origin.IsAlmostEqualTo(G))
                    break;
            }
            Connector connector2 = (Connector)null;
            ConnectorSetIterator connectorSetIterator3 = duct.ConnectorManager.Connectors.ForwardIterator();
            while (connectorSetIterator3.MoveNext())
            {
                connector2 = connectorSetIterator3.Current as Connector;
                if (connector2.Origin.IsAlmostEqualTo(G))
                    break;
            }
            using (Transaction t14 = new Transaction(doc, "TreeDuctConnect"))
            {
                t14.Start();
                doc.Create.NewTeeFitting(connector1, connector2, connector3);
                t14.Commit();
            }
        }

        public void CreateConnectEbowPipe(Document doc, Pipe pipe1, XYZ M, Pipe pipe2, XYZ E)
        {
            Connector connector1 = (Connector)null;
            ConnectorSetIterator connectorSetIterator1 = pipe1.ConnectorManager.Connectors.ForwardIterator();
            while (connectorSetIterator1.MoveNext())
            {
                connector1 = connectorSetIterator1.Current as Connector;
                if (connector1.Origin.IsAlmostEqualTo(M))
                    break;
            }
            Connector connector2 = (Connector)null;
            ConnectorSetIterator connectorSetIterator2 = pipe2.ConnectorManager.Connectors.ForwardIterator();
            while (connectorSetIterator2.MoveNext())
            {
                connector2 = connectorSetIterator2.Current as Connector;
                if (connector2.Origin.IsAlmostEqualTo(E))
                    break;
            }
            using (Transaction t13 = new Transaction(doc, "Connector2"))
            {
                t13.Start();
                doc.Create.NewElbowFitting(connector1, connector2);
                t13.Commit();
            }
        }

        public void CreateConectTreePipe(Document doc, Pipe pipe1, XYZ G, Pipe pipe2)
        {
            Pipe pipe = (Pipe)null;
            Curve curve = (pipe2.Location as LocationCurve).Curve;
            XYZ endPoint1 = curve.GetEndPoint(0);
            XYZ endPoint2 = curve.GetEndPoint(1);
            double num1 = Math.Sqrt((endPoint1.X - G.X) * (endPoint1.X - G.X) + (endPoint1.Y - G.Y) * (endPoint1.Y - G.Y));
            XYZ xyz = endPoint2.Subtract(endPoint1).Normalize();
            XYZ ptBreak = endPoint1.Add(xyz.Multiply(num1));
            using (Transaction t9= new Transaction(doc, "DeviePipe"))
            {
                t9.Start();
                ElementId id = PlumbingUtils.BreakCurve(doc, pipe2.Id, ptBreak);
                pipe = doc.GetElement(id) as Pipe;
                t9.Commit();
            }
            Connector connector3 = (Connector)null;
            ConnectorSetIterator connectorSetIterator1 = pipe1.ConnectorManager.Connectors.ForwardIterator();
            while (connectorSetIterator1.MoveNext())
            {
                connector3 = connectorSetIterator1.Current as Connector;
                if (connector3.Origin.IsAlmostEqualTo(G))
                    break;
            }
            Connector connector1 = (Connector)null;
            ConnectorSetIterator connectorSetIterator2 = pipe2.ConnectorManager.Connectors.ForwardIterator();
            while (connectorSetIterator2.MoveNext())
            {
                connector1 = connectorSetIterator2.Current as Connector;
                if (connector1.Origin.IsAlmostEqualTo(G))
                    break;
            }
            Connector connector2 = (Connector)null;
            ConnectorSetIterator connectorSetIterator3 = pipe.ConnectorManager.Connectors.ForwardIterator();
            while (connectorSetIterator3.MoveNext())
            {
                connector2 = connectorSetIterator3.Current as Connector;
                if (connector2.Origin.IsAlmostEqualTo(G))
                    break;
            }
            using (Transaction t10 = new Transaction(doc, "TreePipeConnect"))
            {
                t10.Start();
                doc.Create.NewTeeFitting(connector1, connector2, connector3);
                t10.Commit();
            }
        }

        public void ChangeSizeDuct(
          Document doc,
          double diameter,
          double width,
          double height,
          Duct element)
        {
            using (Transaction t11 = new Transaction(doc, "SetSizeDuct"))
            {
                t11.Start();
                if (diameter != 0.0)
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

        public void ChangeSizePipe(
          Document doc,
          double diameter,
          double width,
          double height,
          Pipe element)
        {
            using (Transaction t12 = new Transaction(doc, "SetSizeDuct"))
            {
                t12.Start();
                element.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM).Set(diameter);
                t12.Commit();
            }
        }
    }
}