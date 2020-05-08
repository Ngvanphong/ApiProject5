// Decompiled with JetBrains decompiler
// Type: ApiProject5.Button.MoveElementsButton
// Assembly: ApiProject5, Version=2019.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C3D4D4B7-6EF2-4F20-A28D-362DDA07E142
// Assembly location: C:\Program Files\Autodesk\Revit 2019\AddIns\ApiProject5.dll

using ApiProject5.Helper;
using ApiProject5.Properties;
using Autodesk.Revit.UI;
using System.Drawing;
using System.Reflection;
using System.Windows.Media;

namespace ApiProject5.Button
{
  public class MoveElementsButton
  {
    public void MoveElements(UIControlledApplication application)
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
        if (ribbonPanel2.Name == "Element2")
        {
          ribbonPanel1 = ribbonPanel2;
          break;
        }
      }
      if (ribbonPanel1 == null)
        ribbonPanel1 = application.CreateRibbonPanel("ArmoApiVn2", "Element2");
      ImageSource imageSource = (ImageSource) Extension.GetImageSource((Image) Resources.icons8_move_32);
      PushButtonData pushButtonData1 = new PushButtonData("MoveProject", "Move Rotate \r Project", Assembly.GetExecutingAssembly().Location, "ApiProject5.MoveElements.MoveElementsBinding");
      pushButtonData1.ToolTip = "Move all elements in project";
      pushButtonData1.LongDescription = "Move all elements in project";
      pushButtonData1.Image = imageSource;
      pushButtonData1.LargeImage = imageSource;
      PushButtonData pushButtonData2 = pushButtonData1;
      (ribbonPanel1.AddItem((RibbonItemData) pushButtonData2) as PushButton).Enabled = true;
    }
  }
}
