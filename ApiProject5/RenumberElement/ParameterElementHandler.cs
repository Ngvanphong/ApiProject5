using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
namespace ApiProject5.RenumberElement
{
    public class ParameterElementHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            string cateChoice = AppPenalRenumberElement.myFormRenumberElement.comboBoxTypeElementRenumber
                .GetItemText(AppPenalRenumberElement.myFormRenumberElement.comboBoxTypeElementRenumber.SelectedItem);
            List<string> listParmeter = new List<string>();
            AppPenalRenumberElement.myFormRenumberElement.comboBoxParameterRenumerElement.DisplayMember = "Text";
            AppPenalRenumberElement.myFormRenumberElement.comboBoxParameterRenumerElement.ValueMember = "Value";
            if (cateChoice == Constants.Room)
            {
               
                AppPenalRenumberElement.myFormRenumberElement.comboBoxParameterRenumerElement.Items.Clear();
                AppPenalRenumberElement.myFormRenumberElement.comboBoxParameterRenumerElement.Items.Add(new { Text = "Number", Value = "Number" });
                AppPenalRenumberElement.myFormRenumberElement.comboBoxParameterRenumerElement.SelectedIndex = 0;
            }
            else if (cateChoice == Constants.Pile)
            {
                var elList = new FilteredElementCollector(doc).WherePasses(new ElementCategoryFilter(BuiltInCategory.OST_StructuralFoundation));
                List<FamilyInstance> listOther = new List<FamilyInstance>();
                List<string> listParaName = new List<string>();
                foreach(Element elItem in elList)
                {
                    try
                    {
                        FamilyInstance faIs = elItem as FamilyInstance;
                        if (!listOther.Exists(x => x.Symbol.Name == faIs.Symbol.Name)&&faIs!=null){
                            listOther.Add(faIs);
                        }
                    }
                    catch { continue; }
                }

                AppPenalRenumberElement.myFormRenumberElement.comboBoxParameterRenumerElement.Items.Clear();
                foreach (Element el in listOther)
                {
                    foreach(Parameter para in el.Parameters)
                    {
                        string name = para.Definition.Name;
                        try
                        {
                            Parameter paraIstan = el.LookupParameter(name);
                            if (paraIstan != null&paraIstan.StorageType==StorageType.String)
                            {
                                if(!listParaName.Exists(x=>x==name))listParaName.Add(name);
                                
                            }
                        }
                        catch { continue; }
                    }                    
                }
                foreach(string text in listParaName.OrderBy(x=>x))
                {
                    AppPenalRenumberElement.myFormRenumberElement.comboBoxParameterRenumerElement.Items.Add(new { Text = text, Value = text });
                }

            }

        }

        public string GetName()
        {
            return "ParameterEleGetHandler";
        }
    }
}
