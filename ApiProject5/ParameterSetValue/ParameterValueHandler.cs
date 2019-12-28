using ApiProject5.Helper;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ApiProject5.ParameterSetValue
{
    public class ParameterValueHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            bool elementInProject = AppPanalParameterSet.myFormParameterSet.radioButtonInEntireProject.Checked;
            string typeText = Constant.Normal;
            string valueSet = AppPanalParameterSet.myFormParameterSet.textBoxValueParameterEle.Text;
            string nameParameter = AppPanalParameterSet.myFormParameterSet.comboBoxNameParameterEle
                .GetItemText(AppPanalParameterSet.myFormParameterSet.comboBoxNameParameterEle.SelectedItem);
            if (AppPanalParameterSet.myFormParameterSet.radioButtonLowerText.Checked) typeText = Constant.Lower;
            else if (AppPanalParameterSet.myFormParameterSet.radioButtonSentenceText.Checked) typeText = Constant.Sentense;
            else if (AppPanalParameterSet.myFormParameterSet.radioButtonTitleText.Checked) typeText = Constant.Title;
            else if (AppPanalParameterSet.myFormParameterSet.radioButtonUpperText.Checked) typeText = Constant.Upper;
            var allSelectionIds = app.ActiveUIDocument.Selection.GetElementIds();
            if (allSelectionIds.Count == 0)
            {
                MessageBox.Show("You must choose element to set parameter");
                return;
            }
            Element elementFirst = doc.GetElement(allSelectionIds.First());
            var listParameters = elementFirst.Parameters;
            List<Element> listElementSetParameter = new List<Element>();
            if (elementInProject)
            {
                ElementCategoryFilter filter = new ElementCategoryFilter(elementFirst.Category.Id);
                listElementSetParameter = new FilteredElementCollector(doc).WhereElementIsNotElementType().WherePasses(filter).ToList();
            }
            else
            {
                foreach (ElementId id in allSelectionIds)
                {
                    Element el = doc.GetElement(id);
                    listElementSetParameter.Add(el);
                }
            }
            foreach (Element elementSet in listElementSetParameter)
            {
                Parameter paraSet = null;
                try
                {
                    paraSet = elementSet.LookupParameter(nameParameter);
                }
                catch { continue; }
                if (paraSet != null)
                {
                    string newString = string.Empty;
                    if (!string.IsNullOrEmpty(valueSet) && valueSet != " ")
                    {
                        newString = SetTextFormat(typeText, valueSet);
                    }
                    else
                    {
                        string oldString = ParameterRevit.ParameterToString(paraSet);
                        if (!string.IsNullOrEmpty(oldString) && oldString != " ")
                        {
                            newString = SetTextFormat(typeText, oldString);
                        }
                    }
                    if (!string.IsNullOrEmpty(newString))
                    {
                        using (Transaction t = new Transaction(doc, "SetParameterValue1"))
                        {
                            t.Start();
                            try
                            {
                                if (paraSet.StorageType == StorageType.Integer) paraSet.Set(int.Parse(newString));
                                else if (paraSet.StorageType == StorageType.Double) paraSet.SetValueString(newString);
                                //else if (paraSet.StorageType == StorageType.ElementId) paraSet.SetValueString(newString);
                                else if (paraSet.StorageType == StorageType.String) paraSet.Set(newString);
                                t.Commit();
                            }
                            catch
                            {
                                t.Commit();
                            }
                        }
                    }
                }
            }
        }

        public string GetName()
        {
            return "ParameterSetValue";
        }

        private string SetTextFormat(string typeFormat, string textValue)
        {
            textValue = Regex.Replace(textValue, @"^\s+", "");
            string stringFormat = textValue;
            switch (typeFormat)
            {
                case Constant.Normal:
                    stringFormat = textValue;
                    break;

                case Constant.Upper:
                    stringFormat = textValue.ToUpper();
                    break;

                case Constant.Lower:
                    stringFormat = textValue.ToLower();
                    break;

                case Constant.Sentense:
                    stringFormat = textValue.First().ToString().ToUpper() + textValue.Remove(0, 1).ToLower();
                    break;

                case Constant.Title:
                    stringFormat = Regex.Replace(textValue, @"(^\w)|(\s\w)", m => m.Value.ToUpper());
                    break;
            }
            return stringFormat;
        }
    }
}