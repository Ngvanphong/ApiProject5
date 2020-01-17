using Autodesk.Revit.UI;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Media;


namespace ApiProject5.Button
{
   public class DynamoModelButton
    {
        public void DynamoPoint(UIControlledApplication application)
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
            Image img = ApiProject5.Properties.Resources.icons8_pain_point_32;
            ImageSource imgSrc = Helper.Extension.GetImageSource(img);
            PushButtonData btnData = new PushButtonData("DynamoPoint", "Dynamo \r Point",
                Assembly.GetExecutingAssembly().Location, "ApiProject5.DynamoModel.AppPanelDynamoBinding")
            {
                ToolTip = "Get point to export excel",
                LongDescription = "Get point to export excel",
                Image = imgSrc,
                LargeImage = imgSrc,
            };
            PushButton button = panel.AddItem(btnData) as PushButton;
            button.Enabled = true;
        }
    }
}
