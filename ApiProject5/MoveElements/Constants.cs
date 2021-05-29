using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
namespace ApiProject5.MoveElements
{
   public static class Constants
    {
        public static List<BuiltInCategory> CategoryBuilt { get {return new List<BuiltInCategory>{
                    BuiltInCategory.OST_CurtainGridsWall,BuiltInCategory.OST_CurtainWallMullions,BuiltInCategory.OST_CurtainWallPanels
                }; } }
    }
}
