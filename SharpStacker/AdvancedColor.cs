using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SharpStacker
{
    public partial class AdvancedColor : Form
    {
        private ChartArea area;
        private Series bar;

        public AdvancedColor()
        {
            InitializeComponent();

            area = new ChartArea("Intensity");
            colorChart.ChartAreas.Add(area);
            bar = new Series
            {
                ChartType = SeriesChartType.Column,
                ChartArea = "Intensity"
            };
        }

        public void UpdateChart(int[] data, int frameNumber)
        {
            bar.Points.DataBindY(data);
            
            bar.Name = "Frame " + (frameNumber + 1).ToString();
            colorChart.Series.Clear();
            colorChart.Series.Add(bar);
            colorChart.Update();
        }

        private void AdvancedColor_Load(object sender, EventArgs e)
        {

        }
    }
}
