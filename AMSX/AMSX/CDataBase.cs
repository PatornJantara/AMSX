using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

using System.Data;
using System.Data.SqlClient;

namespace AMSX
{
    struct RowData
    {
        public DateTime dateTime;
        public string Type;
        public string Cate;
        public int Amount;
        public string Remark;
        public string GUID;

        public RowData(DateTime dateTime, string Type, string Cate, int Amount, string Remark,string GUID)
        {
            this.dateTime   = dateTime;
            this.Type       = Type;
            this.Cate       = Cate;
            this.Amount     = Amount;
            this.Remark     = Remark;
            this.GUID       = GUID;
        }
    }

    class CDataBase
    {

        string Path;
        string EXE = Assembly.GetExecutingAssembly().GetName().Name;
        Dictionary<string, Type> dicHeader;


        public DataTable dataTable = new DataTable("AMSX");

        public CDataBase(string DataTablePath = null, Dictionary<string,Type> ps = null)
        {
            Path = new FileInfo(DataTablePath ?? EXE ).FullName;

            dicHeader = ps;

            if (!File.Exists(Path))
            {
                if (!Directory.Exists(Path))
                {
                    Directory.CreateDirectory(System.IO.Path.GetDirectoryName(Path));
                }

                this.Create();
            }
            else
            {
                this.Read();
            }
        }


        public void Create()
        {
            foreach(KeyValuePair<string, System.Type> Header in dicHeader)
            {
                this.dataTable.Columns.Add( Header.Key.ToString(), Header.Value);
            }

            this.dataTable.WriteXmlSchema(Path);

        }

        public void Read()
        {

            foreach (KeyValuePair<string, System.Type> Header in dicHeader)
            {
                this.dataTable.Columns.Add(Header.Key.ToString(), Header.Value);
            }

            this.dataTable.ReadXml(Path);
        }


        public void AddDataToDataTable(RowData rowData)
        {
            DataRow newRow = this.dataTable.NewRow();
            
            newRow["DATE"]      = rowData.dateTime;
            newRow["TYPE"]      = rowData.Type;
            newRow["CATE"]      = rowData.Cate;
            newRow["AMOUNT"]    = rowData.Amount;
            newRow["REMARK"]    = rowData.Remark;
            newRow["GUID"]      = rowData.GUID;

            this.dataTable.Rows.Add(newRow);

            this.dataTable.WriteXml(Path);
        }

        public void DeleteDataFromDataTable(int iRowIndex)
        {

            DataRow rowToDelete = this.dataTable.Rows[iRowIndex];

            rowToDelete.Delete();

            this.dataTable.WriteXml(Path);
        }

        public int SearchMatchRow(string[] searchCriteria)
        {

            int iRowIndex = -1;

            for (int rowIndex = 0; rowIndex < dataTable.Rows.Count; rowIndex++)
            {
                iRowIndex = rowIndex;

                DataRow row = dataTable.Rows[rowIndex];

                bool isMatch = true;

                for (int columnIndex = 0; columnIndex < searchCriteria.Length; columnIndex++)
                {

                    if (row[columnIndex].ToString() != searchCriteria[columnIndex])
                    {

                        isMatch = false;
                        break;
                    }
                }

                if (isMatch)
                {
                    break;
                }
            }

            return iRowIndex;
        }


    }
    
}
