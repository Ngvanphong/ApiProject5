using Autodesk.Revit.UI;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Media;

namespace ApiProject5.Button
{
    public class ParameterSetButton
    {
        public void ParameterSet(UIControlledApplication application)
        {
            const string ribbonTag = "ArmoApiVn2";
            const string ribbonPanel = "Element2";
            try
            {
                application.CreateRibbonTab(ribbonTag);
            }
            catch { }
            RibbonPanel panel = null;
            List<RibbonPanel> panels = application.GetRibbonPanels(ribbonTag);
            foreach (RibbonPanel pl in panels)
            {
                if (pl.Name == ribbonPanel)
                {
                    panel = pl;
                    break;
                }
            }
            if (panel == null)
            {
                panel = application.CreateRibbonPanel(ribbonTag, ribbonPanel);
            }
            Image img = ApiProject5.Properties.Resources.icons8_set_as_resume_32;
            ImageSource imgSrc = Helper.Extension.GetImageSource(img);
            PushButtonData btnData = new PushButtonData("ParameterValue", "Parameter \r Value",
                Assembly.GetExecutingAssembly().Location, "ApiProject5.ParameterSetValue.ParameterValueBinding")
            {
                ToolTip = "Set value for parameter",
                LongDescription = "Set value for parameter",
                Image = imgSrc,
                LargeImage = imgSrc,
            };

            PushButton button = panel.AddItem(btnData) as PushButton;
            button.Enabled = true;
        }
    }
}