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
            double angle = 45;
            try
            {
                angle = double.Parse(StatisAngleViewer.StatisViewerShow);
            }
            catch
            {
            }
            Element element1=null;
            try
            {
                element1 = document.GetElement(activeUiDocument.Selection.GetElementIds().First());
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
            Element element2=null;
            LocationCurve location2=null;
            try
            {
                Reference reference = activeUiDocument.Selection.PickObject(ObjectType.Element, new SelectionFilterCategory(category));
                element2 = document.GetElement(reference);
                location2 = document.GetElement(reference).Location as LocationCurve;
            }
            catch
            {
                return Result.Succeeded;
            }
            XYZ endPoint3 = location2.Curve.GetEndPoint(0);
            XYZ endPoint4 = location2.Curve.GetEndPoint(1);
            XYZ v1 = (endPoint2 - endPoint1).Normalize();
            XYZ v2 = (endPoint4 - endPoint3).Normalize();
            double num3 = endPoint2.X - endPoint1.X;
            double num4 = endPoint2.Y - endPoint1.Y;
            double num5 = endPoint4.X - endPoint3.X;
            double num6 = endPoint4.Y - endPoint3.Y;
            XYZ M;
            XYZ G;
            if (v1.IsAlmostEqualTo(v2) || v1.IsAlmostEqualTo(-v2))
            {
                double AB = Math.Sqrt((endPoint1.X - endPoint2.X) * (endPoint1.X - endPoint2.X) + (endPoint1.Y - endPoint2.Y) * (endPoint1.Y - endPoint2.Y));
                double AC = Math.Sqrt((endPoint1.X - endPoint3.X) * (endPoint1.X - endPoint3.X) + (endPoint1.Y - endPoint3.Y) * (endPoint1.Y - endPoint3.Y));
                double CB = Math.Sqrt((endPoint2.X - endPoint3.X) * (endPoint2.X - endPoint3.X) + (endPoint2.Y - endPoint3.Y) * (endPoint2.Y - endPoint3.Y));
                M = Math.Abs(AC - AB - CB) >= 0.0001 ? endPoint1 : endPoint2;
                double BD = Math.Sqrt((endPoint2.X - endPoint4.X) * (endPoint2.X - endPoint4.X) + (endPoint2.Y - endPoint4.Y) * (endPoint2.Y - endPoint4.Y));
                double CD = Math.Sqrt((endPoint3.X - endPoint4.X) * (endPoint3.X - endPoint4.X) + (endPoint3.Y - endPoint4.Y) * (endPoint3.Y - endPoint4.Y));
                G = Math.Abs(BD - CB - CD) >= 0.0001 ? endPoint4 : endPoint3;
            }
            else
            {
                double num2 = (num3 * endPoint3.Y + num4 * endPoint1.X - endPoint1.Y * num3 - endPoint3.X * num4) / (num4 * num5 - num3 * num6);
                G = new XYZ(endPoint3.X + num5 * num2, endPoint3.Y + num6 * num2, endPoint3.Z);
                double num7 = Math.Sqrt((endPoint1.X - endPoint2.X) * (endPoint1.X - endPoint2.X) + (endPoint1.Y - endPoint2.Y) * (endPoint1.Y - endPoint2.Y));
                double num8 = Math.Sqrt((endPoint1.X - G.X) * (endPoint1.X - G.X) + (endPoint1.Y - G.Y) * (endPoint1.Y - G.Y));
                double num9 = Math.Sqrt((endPoint2.X - G.X) * (endPoint2.X - G.X) + (endPoint2.Y - G.Y) * (endPoint2.Y - G.Y));
                M = Math.Abs(num8 - num7 - num9) >= 0.0001 ? endPoint1 : endPoint2;
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
            XYZ N = new XYZ(x, y, endPoint3.Z);
            ElementId levelId = element1.get_Parameter(BuiltInParameter.RBS_START_LEVEL_PARAM).AsElementId();
            double width = 0.0;
            double height = 0.0;
            double diameter1 = 0.0;
            if (category.Id == document.Settings.Categories.get_Item(BuiltInCategory.OST_DuctCurves).Id)
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
                Duct newDuctCus1 = this.CreateNewDuctCus(document, M, N, ductSystem, levelId, ductType);
                this.ChangeSizeDuct(document, diameter1, width, height, newDuctCus1);
                Duct duct2_2 = duct;
                if (newDuctCus1 != null)
                    this.CreateConnectEbow(document, newDuctCus1, M, duct2_2, M);
                try
                {
                    if (v1.IsAlmostEqualTo(v2) || v1.IsAlmostEqualTo(-v2))
                    {
                        this.CreateConnectEbow(document, newDuctCus1, N, duct2_1, G);
                    }
                    else
                    {
                        try
                        {
                            Duct newDuctCus2 = CreateNewDuctCus(document, N, G, ductSystem, levelId, ductType);
                            ChangeSizeDuct(document, diameter1, width, height, newDuctCus2);
                            if (newDuctCus2 != null && !v1.IsAlmostEqualTo(v2) && !v1.IsAlmostEqualTo(-v2))
                            {
                                CreateConnectEbow(document, newDuctCus2, N, newDuctCus1, N);
                                using (TransactionGroup tg8 = new TransactionGroup(document, "groupConnectDuctTee"))
                                {
                                    tg8.Start();
                                    try
                                    {
                                        double CG = G.DistanceTo(endPoint3);
                                        double DG = endPoint4.DistanceTo(G);
                                        double CD = endPoint3.DistanceTo(endPoint4);
                                        if (Math.Abs(DG+CG-CD)>0.0001||CG<0.0001||DG<0.0001)
                                        {
                                            XYZ pointCon = GetPointConnect(endPoint3, endPoint4, G);
                                            CreateConnectEbow(document, newDuctCus2, G, duct2_1, pointCon);
                                        }
                                        else
                                        {
                                            CreateConectTree(document, newDuctCus2, G, duct2_1);
                                        }
                                        tg8.Commit();
                                    }
                                    catch
                                    {
                                        tg8.RollBack();
                                    }
                                }
                            }
                        }
                        catch
                        {
                            if (!v1.IsAlmostEqualTo(v2) && !v1.IsAlmostEqualTo(-v2))
                            {
                                using (TransactionGroup tg = new TransactionGroup(document, "groupConnectDuctTee90"))
                                {
                                    tg.Start();
                                    try
                                    {
                                        double CG = G.DistanceTo(endPoint3);
                                        double DG = endPoint4.DistanceTo(G);
                                        double CD = endPoint3.DistanceTo(endPoint4);
                                        if (Math.Abs(DG + CG - CD) > 0.0001 || CG < 0.0001 || DG < 0.0001)
                                        {
                                            XYZ pointCon = GetPointConnect(endPoint3, endPoint4, G);
                                            CreateConnectEbow(document, newDuctCus1, G, duct2_1, pointCon);
                                        }
                                        else
                                        {
                                            this.CreateConectTree(document, newDuctCus1, G, duct2_1);
                                        } 
                                        tg.Commit();
                                    }
                                    catch
                                    {
                                        tg.RollBack();
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
                Pipe newPipeCus1 = CreateNewPipeCus(document, M, N, pipeSystem, levelId, pipeType);
                ChangeSizePipe(document, diameter2, newPipeCus1);
                Pipe pipe2_2 = pipe;
                if (newPipeCus1 != null)
                    CreateConnectEbowPipe(document, newPipeCus1, M, pipe2_2, M);
                try
                {
                    if (v1.IsAlmostEqualTo(v2) || v1.IsAlmostEqualTo(-v2))
                    {
                        CreateConnectEbowPipe(document, newPipeCus1, N, pipe2_1, G);
                    }
                    else
                    {
                        try
                        {
                            Pipe newPipeCus2 = this.CreateNewPipeCus(document, N, G, pipeSystem, levelId, pipeType);
                            this.ChangeSizePipe(document, diameter2, newPipeCus2);
                            if (newPipeCus2 != null && !v1.IsAlmostEqualTo(v2) && !v1.IsAlmostEqualTo(-v2))
                            {
                                this.CreateConnectEbowPipe(document, newPipeCus2, N, newPipeCus1, N);
                                using (TransactionGroup tg3 = new TransactionGroup(document, "groupConnectPipeTee"))
                                {
                                    tg3.Start();
                                    try
                                    {
                                        double CG = G.DistanceTo(endPoint3);
                                        double DG = endPoint4.DistanceTo(G);
                                        double CD = endPoint3.DistanceTo(endPoint4);
                                        if (Math.Abs(DG + CG - CD) > 0.0001 || CG < 0.0001 || DG < 0.0001)
                                        {
                                            XYZ pointCon = GetPointConnect(endPoint3, endPoint4, G);
                                            CreateConnectEbowPipe(document, newPipeCus2, G, pipe2_1, pointCon);
                                        }
                                        else
                                        {
                                            CreateConectTreePipe(document, newPipeCus2, G, pipe2_1);
                                        }
                                        tg3.Commit();
                                    }
                                    catch
                                    {
                                        tg3.RollBack();
                                    }
                                }
                            }
                        }
                        catch
                        {
                            if (!v1.IsAlmostEqualTo(v2) && !v1.IsAlmostEqualTo(-v2))
                            {
                                using (TransactionGroup tg2 = new TransactionGroup(document, "groupConnectPipeTee90"))
                                {
                                    tg2.Start();
                                    try
                                    {
                                        double CG = G.DistanceTo(endPoint3);
                                        double DG = endPoint4.DistanceTo(G);
                                        double CD = endPoint3.DistanceTo(endPoint4);
                                        if (Math.Abs(DG + CG - CD) > 0.0001 || CG < 0.0001 || DG < 0.0001)
                                        {
                                            XYZ pointCon = GetPointConnect(endPoint3, endPoint4, G);
                                            CreateConnectEbowPipe(document, newPipeCus1, G, pipe2_1, pointCon);
                                        }
                                        else
                                        {
                                            this.CreateConectTreePipe(document, newPipeCus1, G, pipe2_1);
                                        }
                                        
                                        tg2.Commit();
                                    }
                                    catch
                                    {
                                        tg2.RollBack();
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

        public Duct CreateNewDuctCus(Document doc,XYZ p1,XYZ p2, ElementId ductSystem, ElementId levelId,DuctType ductType = null)
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

        public Pipe CreateNewPipeCus(Document doc, XYZ p1, XYZ p2, ElementId pipeSystem,ElementId levelId, PipeType pipeType = null)
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
            using (Transaction t32 = new Transaction(doc, "Connector2"))
            {
                t32.Start();
                doc.Create.NewElbowFitting(connector1, connector2);
                t32.Commit();
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
            using (Transaction t31 = new Transaction(doc, "DevieDuct"))
            {
                t31.Start();
                ElementId id = MechanicalUtils.BreakCurve(doc, duct2.Id, ptBreak);
                duct = doc.GetElement(id) as Duct;
                t31.Commit();
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

        public void ChangeSizeDuct(Document doc,double diameter,double width,double height,Duct element)
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

        public void ChangeSizePipe( Document doc,double diameter,Pipe element)
        {
            using (Transaction t12 = new Transaction(doc, "SetSizeDuct"))
            {
                t12.Start();
                element.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM).Set(diameter);
                t12.Commit();
            }
        }

        public XYZ GetPointConnect(XYZ C, XYZ D, XYZ G)
        {
            XYZ result=null;
            double CG = C.DistanceTo(G);
            double DG = D.DistanceTo(G);
            double CD = C.DistanceTo(D);
            if (CG < 0.0001)
            {
                result = C;
            }else if (DG < 0.0001)
            {
                result = D;
            }else if (Math.Abs(CG - DG - CD) < 0.0001&&CG>=CD)
            {
                result = D;
            }else if (Math.Abs(DG - CD - CG) < 0.0001&&DG>=CD)
            {
                result = C;
            }
            return result;
        }
    }
}