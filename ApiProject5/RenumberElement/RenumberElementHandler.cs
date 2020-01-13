using ApiProject5.Helper;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System.Collections.Generic;

namespace ApiProject5.RenumberElement
{
    public class RenumberElementHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            string mainString = AppPenalRenumberElement.myFormRenumberElement.textBoxMainRenumber.Text;
            int mainNumber = int.Parse(AppPenalRenumberElement.myFormRenumberElement.textBoxMainRenumber.Text);
            string prefixNumber = AppPenalRenumberElement.myFormRenumberElement.textBoxPrefitRenumber.Text;
            string subffixNumber = AppPenalRenumberElement.myFormRenumberElement.textBoxSubffixRenumber.Text;
            int step = int.Parse(AppPenalRenumberElement.myFormRenumberElement.numericUpDownStepRenumber.Value.ToString());
            string nameCategory = AppPenalRenumberElement.myFormRenumberElement.comboBoxTypeElementRenumber
                .GetItemText(AppPenalRenumberElement.myFormRenumberElement.comboBoxTypeElementRenumber.SelectedItem);
            string nameParameter = AppPenalRenumberElement.myFormRenumberElement.comboBoxParameterRenumerElement
                .GetItemText(AppPenalRenumberElement.myFormRenumberElement.comboBoxParameterRenumerElement.SelectedItem);

            if (nameCategory == Constants.Room)
            {
                Category cate = doc.Settings.Categories.get_Item(BuiltInCategory.OST_Rooms);
                SelectionFilterCategory filterCate = new SelectionFilterCategory(cate);
                if (AppPenalRenumberElement.myFormRenumberElement.radioButtonManualSelect.Checked)
                {
                    while (!AppPenalRenumberElement.StopRenumber)
                    {
                        try
                        {
                            var referElement = app.ActiveUIDocument.Selection.PickObject(ObjectType.Element, filterCate);
                            Element elementSet = doc.GetElement(referElement);
                            string inputMain = mainString;
                            if (mainString.Length > mainNumber.ToString().Length)
                            {
                                inputMain = mainString.Substring(0, mainString.Length - mainNumber.ToString().Length) + mainNumber.ToString();
                            }
                            else
                            {
                                inputMain = mainNumber.ToString();
                            }
                            string newStringSet = prefixNumber + inputMain + subffixNumber;
                            Parameter paraSet = elementSet.LookupParameter(nameParameter);
                            using (Transaction t4 = new Transaction(doc, "SetRenumberV1"))
                            {
                                t4.Start();
                                try
                                {
                                    paraSet.Set(newStringSet);
                                    mainNumber += step;
                                    t4.Commit();
                                }
                                catch { t4.RollBack(); }
                            }
                        }
                        catch { break; }
                    }
                }
                else
                {
                    MyOrder myOrder = new MyOrder();
                    var allSelect = app.ActiveUIDocument.Selection.PickObjects(ObjectType.Element, filterCate);
                    List<Room> listRoom = new List<Room>();
                    foreach (var item in allSelect)
                    {
                        Room room = doc.GetElement(item) as Room;
                        listRoom.Add(room);
                    }
                    listRoom.Sort(myOrder);
                    foreach (Room elementSet in listRoom)
                    {
                        string inputMain = mainString;
                        if (mainString.Length > mainNumber.ToString().Length)
                        {
                            inputMain = mainString.Substring(0, mainString.Length - mainNumber.ToString().Length) + mainNumber.ToString();
                        }
                        else
                        {
                            inputMain = mainNumber.ToString();
                        }
                        string newStringSet = prefixNumber + inputMain + subffixNumber;
                        Parameter paraSet = elementSet.LookupParameter(nameParameter);
                        using (Transaction t3 = new Transaction(doc, "SetRenumberV2"))
                        {
                            t3.Start();
                            try
                            {
                                paraSet.Set(newStringSet);
                                mainNumber += step;
                                if (mainString.Length > mainNumber.ToString().Length)
                                {
                                    inputMain = mainString.Substring(0, mainString.Length - mainNumber.ToString().Length) + mainNumber.ToString();
                                }
                                else
                                {
                                    inputMain = mainNumber.ToString();
                                }
                                AppPenalRenumberElement.myFormRenumberElement.textBoxMainRenumber.Text = inputMain;
                                t3.Commit();
                            }
                            catch { t3.RollBack(); }
                        }
                    }
                }
            }
        }

        public string GetName()
        {
            return "RenumberElementRev1";
        }
    }
}