using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
namespace ApiProject5.DynamoModel
{
   public static class AppPanelDynamoModel
    {
        public static frmDynamoModel myFormDynamoModel;
        public static bool chooseMainLine=true;
        public static Element MainLine = null;
        public static List<int> listBreak = null;
        public static void ShowDynamoModel()
        {
            listBreak = new List<int>();
            MainLine = null;
            chooseMainLine = true;
            AppPanelDynamoHandler handler = new AppPanelDynamoHandler();
            ExternalEvent eventDynamo = ExternalEvent.Create(handler);
            myFormDynamoModel = new frmDynamoModel(eventDynamo, handler);
            myFormDynamoModel.Show();
        }

    }
}
