
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
      new CompareElevationDuctButton().CompareElevationDuct(a);
      return Result.Succeeded;
    }

    public Result OnShutdown(UIControlledApplication a)
    {
      return Result.Succeeded;
    }
  }
}
