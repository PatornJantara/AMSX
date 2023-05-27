using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;

namespace AMSX
{
    class CDataTypeTransform
    {
        public static string[] StringToArrayString(string strData,char Splitter,bool IgnoreNull = true)
        {
            if(IgnoreNull)
            {
                return strData.Split(Splitter).ToArray().Where(s => !string.IsNullOrEmpty(s)).ToArray();
            }
            return strData.Split(Splitter).ToArray();
        }


        public static Series DataTableToSeriesPie(DataTable dataTable , string[] RecordCat,string TargetCol , Dictionary<string,Color> ColorPair = null)
        {
            Series series = new Series("");

            series.ChartType = SeriesChartType.Pie;


            Dictionary<string, int> PieChartData = new Dictionary<string, int>();

            foreach(string Type in RecordCat)
            {
                PieChartData.Add(Type, 0);

            }

            foreach (DataRow row  in dataTable.Rows)
            {
                string  Type    = row.Field<string>(TargetCol);
                int     Amount  = row.Field<int>("AMOUNT");

                if (PieChartData.ContainsKey(Type))
                {
                    PieChartData[Type] += Amount;
                }

            }

            series.IsValueShownAsLabel = true;

            series["PieLabelStyle"] = "Outside";

            // add Series
            foreach (var kvp in PieChartData)
            {
                series.Points.AddXY(kvp.Key, kvp.Value);

                if (ColorPair != null)
                {
                    series.Points[series.Points.Count-1].Color = ColorPair[kvp.Key];
                }
            }

            return series;
        }
    }
}
