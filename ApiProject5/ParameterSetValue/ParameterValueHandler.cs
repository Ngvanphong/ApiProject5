using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
namespace ApiProject5.ParameterSetValue
{
    public class ParameterValueHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            bool elementInProject = AppPanalParameterSet.myFormParameterSet.radioButtonInEntireProject.Checked;
            string typeText = Constant.Normal;
            if (AppPanalParameterSet.myFormParameterSet.radioButtonLowerText.Checked) typeText = Constant.Lower;
            else if (AppPanalParameterSet.myFormParameterSet.radioButtonSentenceText.Checked) typeText = Constant.Sentense;
            else if (AppPanalParameterSet.myFormParameterSet.radioButtonTitleText.Checked) typeText = Constant.Title;
            else if (AppPanalParameterSet.myFormParameterSet.radioButtonUpperText.Checked) typeText = Constant.Upper;


        }

        public string GetName()
        {
            return "ParameterSetValue";
        }
        private string SetTextFormat(string typeFormat,string textValue)
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
                    stringFormat= textValue.First().ToString().ToUpper() + textValue.Remove(0, 1).ToLower();
                    break;
                case Constant.Title:
                    stringFormat= Regex.Replace(textValue, @"(^\w)|(\s\w)", m => m.Value.ToUpper());
                    break;
            }
            return stringFormat;
        }
    }
}
