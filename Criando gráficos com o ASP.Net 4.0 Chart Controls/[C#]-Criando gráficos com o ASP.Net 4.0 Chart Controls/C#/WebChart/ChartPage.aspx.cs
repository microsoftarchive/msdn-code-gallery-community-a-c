using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;

namespace WebChart
{
    public partial class ChartPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CleanChart(this.ColumnChart);
            CleanChart(this.PieChart);

            var data = CreateSampleData();

            BindColumnChart(this.ColumnChart, SeriesChartType.Column, data);
            BindPieChart(this.PieChart, SeriesChartType.Pie, data);
        }

        private static void BindPieChart(Chart currentChart, SeriesChartType chartType, params ChartData[] data)
        {
            int serieIndex = 0;

            var xValues = data.Select(d => d.Legend).ToList();
            var yValues = data.Select(d => d.Y).ToList();
            
            currentChart.Series[serieIndex].Points.DataBindXY(xValues, yValues);

            currentChart.Series[serieIndex].ChartType = chartType;
            
            currentChart.ChartAreas[0].Area3DStyle.Enable3D = true;
            
            currentChart.DataBind();
        }

private static void BindColumnChart(Chart currentChart, SeriesChartType chartType, params ChartData[] data)
{
    for (int i = 0; i < data.Length; i++)
    {
        if (currentChart.Series.Count <= i)
            break;

        ChartData currentChartData = data[i];
                                
        // Largura da barra
        currentChart.Series[i]["PointWidth"] = "1.5";

        currentChart.Series[i].XValueType = ChartValueType.Double;
        currentChart.Series[i].YValueType = ChartValueType.Double;

        currentChart.Series[i].Points.AddXY(currentChartData.X, currentChartData.Y);
        currentChart.Series[i].Label = currentChartData.Y.ToString("F");
        currentChart.Series[i].ChartType = chartType;                
        currentChart.Series[i].LegendText = currentChartData.Legend;
    }
                        
    currentChart.DataBind();
}

    private static ChartData[] CreateSampleData()
    {
        ChartData[] data = new ChartData[8];

        Random rnd = new Random(DateTime.Now.Millisecond);

        for (int i = 0; i < data.Length; i++)            
        {                
            int index = i + 1;
                
            ChartData currentChartData = data[i] = new ChartData();
            currentChartData.X = index;
            currentChartData.Y =  rnd.Next(25) + rnd.NextDouble();
            currentChartData.Legend = string.Format("Legend {0}", index);
        }

        return data;
    }

        private static void FormatLegend(Chart currentChart, params ChartData[] data)
        {
            currentChart.Legends[0].Enabled = true;
            currentChart.Legends[0].LegendStyle = LegendStyle.Row;
            currentChart.Legends[0].IsTextAutoFit = false;
            currentChart.Legends[0].Docking = Docking.Bottom;
            currentChart.Legends[0].IsDockedInsideChartArea = false;
            currentChart.Legends[0].BackColor = Color.Transparent;
            currentChart.Legends[0].Alignment = StringAlignment.Center;

            if (data != null)
            {
                for (int i = 0; i < data.Length; i++)
                {
                    if (currentChart.Series.Count <= i)
                        break;

                    currentChart.Series[i].LegendText = data[i].Legend;
                }
            }
        }

        private static void CleanChart(Chart currentChart)
        {
            foreach (var itemSerie in currentChart.Series)
            {
                if (itemSerie.Points != null)
                    itemSerie.Points.Clear();
            }
        }
    }
}