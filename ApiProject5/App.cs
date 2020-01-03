#region Namespaces

using ApiProject5.Button;
using Autodesk.Revit.UI;

#endregion Namespaces

namespace ApiProject5
{
    internal class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication a)
        {
            ParameterSetButton parameterButtonClass = new ParameterSetButton();
            parameterButtonClass.ParameterSet(a);
            TransferMoreButton transferButton = new TransferMoreButton();
            transferButton.TransferMoreFuc(a);
            RenumberElementButton renumberElementButton = new RenumberElementButton();
            renumberElementButton.RenumberElementFuc(a);
            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }
    }
}