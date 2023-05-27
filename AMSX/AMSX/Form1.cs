using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Globalization;

using System.IO;

using System.Windows.Forms.DataVisualization.Charting;

using static AMSX.CIniFile;
using static AMSX.CTextFile;
//using static AMSX.CDataBase;
using static AMSX.CDataGridViewControl;
using static AMSX.CDataTypeTransform;
using static AMSX.CChartControl;


namespace AMSX
{
    public partial class AMSX : Form
    {
        private Timer timer;

        const string PathInitData        = @"Init\InitData.INI";
        const string PathCateExpense     = @"Init\CateExpense.TXT";
        const string PathCateIncome      = @"Init\CateIncome.TXT";
        const string PathCateInvest      = @"Init\CateInvest.TXT";

        CTextFile   ExpeData    =   new CTextFile(PathCateExpense);
        CTextFile   IncoData    =   new CTextFile(PathCateIncome);
        CTextFile   InvesData   =   new CTextFile(PathCateInvest);

        CDataBase   DataBase;

        string[] RecordCat          = { "INCOME", "EXPENSE", "INVESMENT" };
        string[] ChartExpense       = { "EXPENSE", "INVESMENT" };
        string[] GraphCat           = { "ALL","INCOME", "EXPENSE", "INVESMENT" };
        string[] RecordTable        = { "DATE", "TYPE", "CATE", "AMOUNT", "REMARK", "GUID" };


        Dictionary<string, Color> RowColor = new Dictionary<string, Color>();


        public AMSX()
        {

            InitializeComponent();

            this.dateTimePickerStart.Value = new DateTime(DateTime.Now.Year, 01, 01);

            InitDataTable();
            CComboBoxControl.AddDataToComboBox(this.comboBoxType, RecordCat);

            CComboBoxControl.AddDataToComboBox(this.comboBoxChart, RecordCat);

            CDataGridViewControl.InitialDataGridView(this.dataGridViewRecord, RecordTable,"RECORD");
            CDataGridViewControl.DataGridViewDisplayInTimeRange(this.dataGridViewRecord, MakeMainHeader(), this.DataBase,this.dateTimePickerStart.Value, this.dateTimePickerEnd.Value);


            RowColor.Add("INCOME",      Color.LightGreen);
            RowColor.Add("EXPENSE",     Color.LightCoral);
            RowColor.Add("INVESMENT",   Color.LightGoldenrodYellow);
            this.timer = new Timer();
            this.timer.Interval = 100;
            this.timer.Tick += OnTimerTick;
            this.timer.Start();

  

        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            string[] strChartCat = ChartExpense;
            string strColTarget = "TYPE";

            CDataGridViewControl.SetColorRow(this.dataGridViewRecord, "TYPE", RowColor);

            Dictionary<string, Color> ColorPair = RowColor;
            

            if (this.comboBoxChart.Text == "EXPENSE")
            {
                strChartCat = CDataTypeTransform.StringToArrayString(ExpeData.Read(), '\n', true);
                strColTarget = "CATE";
                ColorPair = null;
            }
            else if(this.comboBoxChart.Text == "INVESMENT")
            {
                strChartCat = CDataTypeTransform.StringToArrayString(InvesData.Read(), '\n', true);
                strColTarget = "CATE";
                ColorPair = null;
            }

            CChartControl.ChartShow(this.chartSum,
                        DataTableToSeriesPie(this.DataBase.dataTable, strChartCat, strColTarget, ColorPair),
                        this.dateTimePickerStart.Value.ToShortDateString()
                        + " - " + this.dateTimePickerEnd.Value.ToShortDateString());
        }

        private void InitDataTable()
        {
            string strFilePath = $"Data\\{DateTime.Now.Year}\\";

            if (!Directory.Exists(strFilePath))
            {
                Directory.CreateDirectory(strFilePath);
            }

            strFilePath += $"{DateTime.Now.ToString("MMMM")}.xml";

            this.DataBase = new CDataBase(strFilePath, MakeMainHeader());
        }

        private Dictionary<string, Type> MakeMainHeader()
        {
            Dictionary< string, Type > Header = new Dictionary<string, Type>();

            Header.Add("DATE", typeof(DateTime));
            Header.Add("TYPE", typeof(string));
            Header.Add("CATE", typeof(string));
            Header.Add("AMOUNT", typeof(int));
            Header.Add("REMARK", typeof(string));
            Header.Add("GUID", typeof(string));

            return Header;
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBoxCat.Items.Clear();

            string strRead;

            if (this.comboBoxType.GetItemText(comboBoxType.SelectedItem) == GraphCat[1])
            {
                strRead = this.IncoData.Read();
            }
            else if(this.comboBoxType.GetItemText(comboBoxType.SelectedItem) == GraphCat[2])
            {
                strRead = this.ExpeData.Read();
            }
            else
            {
                strRead = this.InvesData.Read();
            }

            CComboBoxControl.AddDataToComboBox(comboBoxCat, CDataTypeTransform.StringToArrayString(strRead,'\n'));

        }



        private void comboBoxChartCat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void buttonSave_Click(object sender, EventArgs e)
        {
            string strPath = $"Data\\{this.dateTimePickerSave.Value.Year}\\{this.dateTimePickerSave.Value.ToString("MMMM")}.xml";
            
            DataBase = new CDataBase(strPath, MakeMainHeader());
           
            if (this.textBoxAmount.Text == string.Empty)
            {
                return;
            }

            if (this.dateTimePickerSave.Value.CompareTo(DateTime.Now) > 0)
            {
                MessageBox.Show("Invalid Time Range");
                return;
            }


            RowData rowData = new RowData(   this.dateTimePickerSave.Value,
                                             this.comboBoxType.GetItemText(comboBoxType.SelectedItem),
                                             this.comboBoxCat.GetItemText(comboBoxCat.SelectedItem),
                                             Convert.ToInt32(this.textBoxAmount.Text),
                                             this.textBoxRemark.Text,
                                             Guid.NewGuid().ToString());

            DataBase.AddDataToDataTable(rowData);

            this.textBoxAmount.Text = string.Empty;
            this.textBoxRemark.Text = string.Empty;

            RefreshDataGridView(this.dataGridViewRecord);

            DataGridViewDisplayInTimeRange(this.dataGridViewRecord, MakeMainHeader(), this.DataBase, this.dateTimePickerStart.Value, this.dateTimePickerSave.Value);

        }


        private void buttonShowRecord_Click(object sender, EventArgs e)
        {
            if(this.dateTimePickerStart.Value.CompareTo(dateTimePickerEnd.Value)    > 0
                || this.dateTimePickerEnd.Value.CompareTo(DateTime.Now)             > 0)
            {
                MessageBox.Show("Invalid Time Range");
                return;
            }

            RefreshDataGridView(this.dataGridViewRecord);
            DataGridViewDisplayInTimeRange(this.dataGridViewRecord, MakeMainHeader(), this.DataBase, this.dateTimePickerStart.Value, this.dateTimePickerEnd.Value);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = this.dataGridViewRecord.CurrentRow;

            if (selectedRow == null)
            {
                return;
            }

            if (selectedRow.Cells["DATE"].Value == null)
            {
                return;
            }

            DateTime SelectTime = DateTime.Parse(selectedRow.Cells["DATE"].Value.ToString());

            string strPath = $"Data\\{SelectTime.Year}\\{SelectTime.ToString("MMMM")}.xml";

            this.DataBase = new CDataBase(strPath, MakeMainHeader());

            string[] searchCriteria = {
                selectedRow.Cells["DATE"].Value.ToString(),
                selectedRow.Cells["TYPE"].Value.ToString(),
                selectedRow.Cells["CATE"].Value.ToString(),
                selectedRow.Cells["AMOUNT"].Value.ToString(),
                selectedRow.Cells["REMARK"].Value.ToString(),
                selectedRow.Cells["GUID"].Value.ToString()
            };

            int iRowIndex = this.DataBase.SearchMatchRow(searchCriteria);

            this.DataBase.DeleteDataFromDataTable(iRowIndex);

            RefreshDataGridView(this.dataGridViewRecord);

            DataGridViewDisplayInTimeRange(this.dataGridViewRecord, MakeMainHeader(), this.DataBase, this.dateTimePickerStart.Value, this.dateTimePickerSave.Value);

        }


    }
}
