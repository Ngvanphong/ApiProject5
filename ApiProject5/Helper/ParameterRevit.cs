using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using System.IO;
namespace ApiProject5.Helper
{
  public  class ParameterRevit
    {
        UIApplication _uiApp;
        Document _doc;
        Application _app;
        public ParameterRevit(UIApplication uiApp)
        {
            _uiApp = uiApp;
            _doc = uiApp.ActiveUIDocument.Document;
            _app = uiApp.Application;
        }

        //set parameter
        public void SetValueParameter(Parameter parameter, string value)
        {
            using (Transaction t = new Transaction(_uiApp.ActiveUIDocument.Document, "Set value parameter"))
            {
                t.Start();
                try { parameter.Set(value); }
                catch (Exception ex) { };
                t.Commit();
            }
        }
        //Create parameter
        public void CreateParameterRevit(string groupName, string parameterName, BuiltInCategory category, BuiltInParameterGroup gruopInstance)
        {
            DefinitionFile definitionFile = _app.OpenSharedParameterFile();
            string path = @"C:\Autodesk\ShareParameterArmo.txt";
            if (definitionFile == null)
            {
                StreamWriter stream = new StreamWriter(path);
                stream.Close();
                _app.SharedParametersFilename = path;
                definitionFile = _app.OpenSharedParameterFile();
            }
            using (Transaction t = new Transaction(_doc, "CreateParamater"))
            {
                t.Start();
                SetNewParamatertoInstance(definitionFile, category, groupName, parameterName, gruopInstance);
                t.Commit();
            }
        }
        public bool SetNewParamatertoInstance(DefinitionFile myDefitionfile, BuiltInCategory category, string groupName, string parameter, BuiltInParameterGroup groupInstance)
        {
            try
            {
                DefinitionGroups myGroups = myDefitionfile.Groups;
                DefinitionGroup myGroup = null;
                Definition myDefination_ProductDate = null;
                myGroup = myGroups.get_Item(groupName);
                if (myGroup == null)
                {
                    myGroup = myDefitionfile.Groups.Create(groupName);
                }

                myDefination_ProductDate = myGroup.Definitions.get_Item(parameter);
                if (myDefination_ProductDate == null)
                {
                    ExternalDefinitionCreationOptions option = new ExternalDefinitionCreationOptions(parameter, ParameterType.Text);
                    myDefination_ProductDate = myGroup.Definitions.Create(option);
                }

                CategorySet categorySet = _uiApp.Application.Create.NewCategorySet();
                Category myCategory = _uiApp.ActiveUIDocument.Document.Settings.Categories.get_Item(category);
                categorySet.Insert(myCategory);
                InstanceBinding instantBinding = _uiApp.Application.Create.NewInstanceBinding(categorySet);
                BindingMap bindingMap = _uiApp.ActiveUIDocument.Document.ParameterBindings;

                bool instanceBindOk = bindingMap.Insert(myDefination_ProductDate, instantBinding, groupInstance);

                return instanceBindOk;

            }
            catch
            {
                return false;
            }
        }
        public static string ParameterToString(Parameter param)
        {
            string val = "none";

            if (param == null)
            {
                return val;
            }

            // To get to the parameter value, we need to pause it depending on its storage type 

            switch (param.StorageType)
            {
                case StorageType.Double:
                    double dVal = param.AsDouble() * 0.3048 * 1000;
                    val = dVal.ToString();
                    break;
                case StorageType.Integer:
                    int iVal = param.AsInteger();
                    val = iVal.ToString();
                    break;
                case StorageType.String:
                    string sVal = param.AsString();
                    val = sVal;
                    break;
                case StorageType.ElementId:
                    ElementId idVal = param.AsElementId();
                    val = idVal.IntegerValue.ToString();
                    break;
                case StorageType.None:
                    break;
            }
            return val;
        }
    }
}
