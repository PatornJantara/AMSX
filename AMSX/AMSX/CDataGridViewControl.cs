using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Drawing;

using static AMSX.CDataBase;

namespace AMSX
{
    class CDataGridViewControl
    {

        public static void InitialDataGridView(DataGridView dataGridView, string[] strHeader, string strTableName)
        {
            //dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            //dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            //dataGridView.ColumnHeadersDefaultCellStyle.Font =
            //    new Font(dataGridView.Font, FontStyle.Bold);

            dataGridView.Name = strTableName;
            dataGridView.RowHeadersVisible = false;

            dataGridView.ColumnCount = strHeader.Length;

            for (int iCol = 0; iCol < dataGridView.ColumnCount; iCol++)
            {
                dataGridView.Columns[iCol].Name = strHeader[iCol];
                dataGridView.Columns[iCol].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }


            for (int i = 0; i <= dataGridView.Columns.Count - 1; i++)
            {
                int colw = dataGridView.Columns[i].Width;
                dataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridView.Columns[i].Width = colw;
            }
        }

        public static void DataGridViewDisplayInTimeRange(DataGridView dataGridView, Dictionary<string, Type> HeaderDefine, CDataBase dataBase, DateTime dateTimeStart, DateTime dateTimeEnd)
        {
            for (int iYear = dateTimeStart.Year; iYear <= dateTimeEnd.Year; iYear++)
            {
                string folderPath = $"Data\\{iYear}\\";

                string extension = ".xml";

                if (!Directory.Exists(folderPath))
                {
                    continue;
                }

                string[] files = Directory.GetFiles(folderPath, "*" + extension);

                if (files == null)
                {
                    continue;
                }

                foreach (string file in files)
                {

                    dataBase = new CDataBase(file, HeaderDefine);

                    GetDataTableInTimeRange(dataGridView, dataBase, dateTimeStart, dateTimeEnd);

                }

            }
        }

        public static void GetDataTableInTimeRange(DataGridView dataGridView, CDataBase DataBase, DateTime dateTimeStart, DateTime dateTimeEnd)
        {
            for (int i = 0; i < DataBase.dataTable.Rows.Count; i++)
            {
                DataRow row = DataBase.dataTable.Rows[i];

                string[] InsertData = new string[DataBase.dataTable.Columns.Count];

                for (int j = 0; j < DataBase.dataTable.Columns.Count; j++)
                {
                    InsertData[j] = row[j].ToString();
                }

                if (DateTime.Parse(InsertData[0]).CompareTo(dateTimeStart) >= 0 &&
                    DateTime.Parse(InsertData[0]).CompareTo(dateTimeEnd) <= 0)
                {
                    dataGridView.Rows.Add(InsertData);
                }
            }
        }

        public static void AddDataGridViewRowHeader(DataGridView dataGridView, string[] strHeader , bool bFreez = false)
        {

            foreach(string header in strHeader)
            {
                int iRow = dataGridView.Rows.Add();
                dataGridView.Rows[iRow].Cells[0].Value = header;
            }


            if(bFreez)
            {
                dataGridView.Columns[0].Frozen = true;
            }
            
        }

        public static void RefreshDataGridView(DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
        }

        public static void SetColorRow( DataGridView dataGridView,string ColumnName,Dictionary<string,Color> Criteria)
        {


            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                foreach(string Column in Criteria.Keys)
                {
                    if(row.Cells[ColumnName].Value ==null)
                    {
                        continue;
                    }
                    row.DefaultCellStyle.BackColor = Criteria[row.Cells[ColumnName].Value.ToString()];
                }

            }
        }
    }
}
