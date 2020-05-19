using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ImageReader
{
    

    public partial class Form5 : Form
    {
        public Form5(string[] imageName, byte[] value, int cnt)
        {
            InitializeComponent();

            chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;

            chart.ChartAreas[0].AxisX.Title = "波段";
            chart.ChartAreas[0].AxisY.Title = "灰度/反射率";

            chart.ChartAreas[0].Area3DStyle.Enable3D = false;

            chart.Series[0].ChartType = SeriesChartType.Line;
            chart.Series[0].XValueType = ChartValueType.String;
            chart.Series[0].IsValueShownAsLabel = true;
            chart.Series[0].MarkerStyle = MarkerStyle.Cross;
            chart.Series[0].Color = Color.Green;
            chart.Series[0].BorderWidth = 3;

            for(int i=1;i<=cnt;i++)
            {
                chart.Series[0].Points.AddXY(i, value[i - 1]);
            }
        }

    }
}
