
using ApiProject5.DuctPipe;
using ApiProject5.Helper;
using ApiProject5.Properties;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Media;

namespace ApiProject5.Button
{
  public class DuctPipeButton
  {
    public void DuctPipeCreate(UIControlledApplication application)
    {
      try
      {
        application.CreateRibbonTab("ArmoApiVn2");
      }
      catch
      {
      }
      RibbonPanel ribbonPanel1 = (RibbonPanel) null;
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
      ImageSource imageSource = (ImageSource) Extension.GetImageSource((Image) Resources.icons8_water_pipe_32);
      PushButtonData pushButtonData1 = new PushButtonData("DuctPipe", "Duct \r Pipe", Assembly.GetExecutingAssembly().Location, "ApiProject5.DuctPipe.DuctPipeBinding");
      pushButtonData1.ToolTip = "Create duct and pipe for connect";
      pushButtonData1.LongDescription = "Create duct and pipe for connect";
      pushButtonData1.Image = imageSource;
      pushButtonData1.LargeImage = imageSource;
      PushButtonData pushButtonData2 = pushButtonData1;
      (ribbonPanel1.AddItem((RibbonItemData) pushButtonData2) as PushButton).Enabled = true;
      TextBoxData textBoxData = new TextBoxData("textBoxDuctPipeAngle");
      TextBox textBox = ribbonPanel1.AddItem((RibbonItemData) textBoxData) as TextBox;
      textBox.Width = 70.0;
      textBox.Value = "45";
      textBox.EnterPressed += new EventHandler<TextBoxEnterPressedEventArgs>(this.SetTextBoxValue);
    }

    public void SetTextBoxValue(object sender, TextBoxEnterPressedEventArgs args)
    {
      StatisAngleViewer.StatisViewerShow = (sender as TextBox).Value as string;
    }
  }
}
