using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data;

namespace AMSX
{
    class CChartControl
    {
        

        public static void ChartShow(Chart pChart, Series pSeries, string strChartName)
        {
            pChart.Titles.Clear();

            pChart.Titles.Add(strChartName);

            pChart.Series.Clear();

            pChart.Series.Add(pSeries);

        }
     

    }
}
