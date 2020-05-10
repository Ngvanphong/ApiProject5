using ApiProject5.CompareElevation;
using ApiProject5.DuctPipe;
using ApiProject5.Helper;
using ApiProject5.Properties;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Media;

namespace ApiProject5.Button
{
   public class CompareElevationDuctButton
    {
        public void CompareElevationDuct(UIControlledApplication application)
        {
            try
            {
                application.CreateRibbonTab("ArmoApiVn2");
            }
            catch
            {
            }
            RibbonPanel ribbonPanel1 = null;
            foreach (RibbonPanel ribbonPanel2 in application.GetRibbonPanels("ArmoApiVn2"))
            {
                if (ribbonPanel2.Name == "MEP")
                {
                    ribbonPanel1 = ribbonPanel2;
                    break;
                }
            }
            if (ribbonPanel1 == null)
                ribbonPanel1 = application.CreateRibbonPanel("ArmoApiVn2", "MEP");
            ImageSource imageSource = Extension.GetImageSource((Image)Resources.icons8_sun_elevation_32);
            PushButtonData pushButtonData1 = new PushButtonData("CompareElevation", "Compare \r Elevation", Assembly.GetExecutingAssembly().Location, "ApiProject5.CompareElevation.CompareElevationDuctBinding");
            pushButtonData1.ToolTip = "Change elevation for duct";
            pushButtonData1.LongDescription = "Change elevation for duct";
            pushButtonData1.Image = imageSource;
            pushButtonData1.LargeImage = imageSource;
            PushButtonData pushButtonData2 = pushButtonData1;
            (ribbonPanel1.AddItem(pushButtonData2) as PushButton).Enabled = true;
            TextBoxData textBoxData = new TextBoxData("textBoxChangeAngle");
            TextBoxData textBoxData2 = new TextBoxData("textBoxChangeElevation");
            var listTexbox = ribbonPanel1.AddStackedItems(textBoxData, textBoxData2);

            foreach(var item1 in listTexbox)
            {
                TextBox item = item1 as TextBox;
                string name = item.Name;
                if(name== "textBoxChangeAngle")
                {
                    item.Width = 70.0;
                    item.Value = "45";
                    item.EnterPressed += new EventHandler<TextBoxEnterPressedEventArgs>(SetTextBoxValueAngle);
                }
                else
                {
                    item.Width = 70.0;
                    item.Value = "500";
                    item.EnterPressed += new EventHandler<TextBoxEnterPressedEventArgs>(SetTextBoxValueElevation);
                }
            } 
        }

        private void SetTextBoxValueAngle(object sender, TextBoxEnterPressedEventArgs args)
        {
            AngleAndElevationDuct.AngleDuct = (sender as TextBox).Value as string;
        }
        private void SetTextBoxValueElevation(object sender, TextBoxEnterPressedEventArgs args)
        {
            AngleAndElevationDuct.ElevationDuct = (sender as TextBox).Value as string;
        }
    }
}
