using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.UI;
using OfficeOpenXml;

namespace ApiProject5.DynamoModel
{
    public partial class frmDynamoModel : Form
    {
        private AppPanelDynamoHandler _handler;
        private ExternalEvent _eventDynamo;
        public frmDynamoModel(ExternalEvent eventDynamo, AppPanelDynamoHandler handler)
        {
            InitializeComponent();
            _handler = handler;
            _eventDynamo = eventDynamo;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSelectLinepoint_Click(object sender, EventArgs e)
        {
            _eventDynamo.Raise();
        }

        private void btnContinueMainLine_Click(object sender, EventArgs e)
        {
            AppPanelDynamoModel.chooseMainLine = true;
            _eventDynamo.Raise();
        }

        private void buttonExportExcelPoint_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel File|*.xlsx";
            save.Title = "Save an Excel File";
            save.ShowDialog();

            if (save.FileName != "")
            {
                FileInfo file = new FileInfo(save.FileName);
                using (ExcelPackage package = new ExcelPackage(file))
                {
                    List<int> listRowBreak = new List<int>();
                    int indexRow = 0;
                    foreach (DataGridViewRow row in AppPanelDynamoModel.myFormDynamoModel.dataGridViewPoint.Rows)
                    {
                        try
                        {
                            int index = int.Parse(row.Cells["Index"].Value.ToString());
                            if (index == 0)
                            {
                               listRowBreak.Add(indexRow);
                            }
                            indexRow += 1;
                        }
                        catch { indexRow += 1; continue; }
                    }
                    listRowBreak.Add(AppPanelDynamoModel.myFormDynamoModel.dataGridViewPoint.Rows.Count - 1);
                    AppPanelDynamoModel.listBreak = listRowBreak;
                    int countInt = AppPanelDynamoModel.listBreak.Count();
                    int indexnext = 1;
                    for (int g = 0; g < countInt - 1; g++)
                    {
                        DataTable datatable = new DataTable();
                        datatable.Columns.Add("X");
                        datatable.Columns.Add("Y");
                        datatable.Columns.Add("Z");
                        datatable.Columns.Add("Length");
                        datatable.Columns.Add("Index");
                        DataRow dr = null;

                        int startIndex = AppPanelDynamoModel.listBreak[g];
                        int endIndex = AppPanelDynamoModel.listBreak[g + 1];

                        for (int mn = startIndex; mn < endIndex; mn++)
                        {
                            DataGridViewRow row = AppPanelDynamoModel.myFormDynamoModel.dataGridViewPoint.Rows[mn];
                            try
                            {
                                dr = datatable.NewRow();
                                dr["X"] = row.Cells[0].Value;
                                dr["Y"] = row.Cells[1].Value;
                                dr["Z"] = row.Cells[2].Value;
                                dr["Length"] = row.Cells[3].Value;
                                dr["Index"] = row.Cells[4].Value;
                                datatable.Rows.Add(dr);
                            }
                            catch { continue; }
                        }
                        string workSheet = "DynamoPoint" + indexnext;
                        indexnext += 1;
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(workSheet);
                        worksheet.Cells["A1"].LoadFromDataTable(datatable, true);
                    }
                    foreach (ExcelWorksheet worksheet2 in package.Workbook.Worksheets)
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            worksheet2.Column(i + 1).AutoFit();
                        }
                        foreach (var cell in worksheet2.Cells["A:A"])
                        {
                            try
                            {
                                cell.Value = Convert.ToDecimal(cell.Value);
                            }
                            catch { continue; }
                        }
                        foreach (var cell in worksheet2.Cells["B:B"])
                        {
                            try
                            {
                                cell.Value = Convert.ToDecimal(cell.Value);
                            }
                            catch{continue;}
                        }
                        foreach (var cell in worksheet2.Cells["C:C"])
                        {
                            try
                            {
                                cell.Value = Convert.ToDecimal(cell.Value);
                            }
                            catch { continue; }
                        }
                        foreach (var cell in worksheet2.Cells["D:D"])
                        {
                            try
                            {
                                cell.Value = Convert.ToDecimal(cell.Value);
                            }
                            catch{ continue; }                           
                        }
                    }
                    package.Save();
                    MessageBox.Show("Exporting is success.");
                }
            }
        }

        private void frmDynamoModel_Load(object sender, EventArgs e)
        {

        }
    }
    }

