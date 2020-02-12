using Autodesk.Revit.UI;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Media;


namespace ApiProject5.Button
{
    class ChangeRotateButton
    {
        public void ChangeRotate(UIControlledApplication application)
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
            Image img = ApiProject5.Properties.Resources.icons8_no_rotate_left_32;
            ImageSource imgSrc = Helper.Extension.GetImageSource(img);
            PushButtonData btnData = new PushButtonData("MatchRotate", "  Match \r Rotation",
                Assembly.GetExecutingAssembly().Location, "ApiProject5.ChangeRotate.ChangeRotateBinding")
            {
                ToolTip = "Rotate element follow a curve",
                LongDescription = "Rotate element follow a curve",
                Image = imgSrc,
                LargeImage = imgSrc,
            };
            PushButton button = panel.AddItem(btnData) as PushButton;
            button.Enabled = true;
        }
    }
}
