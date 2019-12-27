using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Windows.Forms;

namespace ApiProject5.ParameterSetValue
{
    [Transaction(TransactionMode.Manual)]
    public class ParameterValueBinding : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Document doc = commandData.Application.ActiveUIDocument.Document;
            UIApplication app = commandData.Application;
            var  listIdSelects = app.ActiveUIDocument.Selection.GetElementIds();
            if (listIdSelects.Count == 0)
            {
                MessageBox.Show("You must select element set parameter");
                return Result.Succeeded;
            }
            Element elementFirst = doc.GetElement(listIdSelects.First());
            List<string> listParamterInstance = new List<string>();
            foreach(Parameter para in elementFirst.Parameters)
            {
                string nameParameter = para.Definition.Name;
                bool isInstancePara = CheckParameterInstance(elementFirst, nameParameter);
                if (isInstancePara &&!listParamterInstance.Exists(x=>x==nameParameter))
                {
                    listParamterInstance.Add(nameParameter);
                }
            }
            AppPanalParameterSet.ShowParameterSet();
            AppPanalParameterSet.myFormParameterSet.comboBoxNameParameterEle.DisplayMember = "Text";
            AppPanalParameterSet.myFormParameterSet.comboBoxNameParameterEle.ValueMember = "Value";
            foreach (var item in listParamterInstance.OrderBy(x=>x))
            {
                AppPanalParameterSet.myFormParameterSet.comboBoxNameParameterEle.Items.Add(new{ Text = item, Value = item });
            }
            return Result.Succeeded;
        }
        private bool CheckParameterInstance(Element el, string namePara)
        {
            bool result = true;
            Parameter parameter = null;
            try
            {
                parameter = el.LookupParameter(namePara);
            }
            catch { }
            if (parameter == null) result = false;
            return result;
        }
    }
    
}
