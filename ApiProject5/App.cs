// Decompiled with JetBrains decompiler
// Type: ApiProject5.App
// Assembly: ApiProject5, Version=2019.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C3D4D4B7-6EF2-4F20-A28D-362DDA07E142
// Assembly location: C:\Program Files\Autodesk\Revit 2019\AddIns\ApiProject5.dll

using ApiProject5.Button;
using Autodesk.Revit.UI;

namespace ApiProject5
{
  internal class App : IExternalApplication
  {
    public Result OnStartup(UIControlledApplication a)
    {
      new ParameterSetButton().ParameterSet(a);
      new TransferMoreButton().TransferMoreFuc(a);
      new RenumberElementButton().RenumberElementFuc(a);
      new MoveElementsButton().MoveElements(a);
      new DynamoModelButton().DynamoPoint(a);
      new ChangeRotateButton().ChangeRotate(a);
      new DuctPipeButton().DuctPipeCreate(a);
      return Result.Succeeded;
    }

    public Result OnShutdown(UIControlledApplication a)
    {
      return Result.Succeeded;
    }
  }
}
