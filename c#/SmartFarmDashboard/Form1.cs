using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SmartFarmDashboard
{
    public partial class Form1 : Form
    {

        int r_value = 0;
        int g_value = 0;
        int b_value = 0;

        Random random = new Random();
        int sensor = 0;
        bool change = false;

        public Form1()
        {
            InitializeComponent();
            chart1.ChartAreas[0].AxisY.Minimum = 100;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            r_value = trackBar1.Value;
            this.BackColor = Color.FromArgb(r_value, g_value, b_value);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            g_value = trackBar2.Value;
            this.BackColor = Color.FromArgb(r_value, g_value, b_value);
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            b_value = trackBar3.Value;
            this.BackColor = Color.FromArgb(r_value, g_value, b_value);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // int a = random.Next(1, 300);
            if (!change)
            {
                ++sensor;
                if (sensor > 300)
                {
                    change = true;
                }
            }

            if (change)
            {
                --sensor;
                if (sensor < 0)
                {
                    change = false;
                }
            }


            chart1.Series[0].Points.AddY(sensor);

            if (chart1.Series[0].Points.Count > 100)
            {
                // chart1.Series[0].Points.Clear();
                chart1.Series[0].Points.RemoveAt(0);
            }
        }
    }
}
