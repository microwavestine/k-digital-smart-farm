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
using WindowsDataGridView.Properties;

namespace WindowsDataGridView
{
    public partial class Form1 : Form
    {
        DataTable dt = new DataTable();
        string[] defaultTimetable = _24HourTable();

        public Form1()
        {
            InitializeComponent();
            
            dt.Columns.Add("Time");
            dt.Columns.Add("ON/OFF");
            dataGridView1.DataSource = dt;
        }

        public static string[] _24HourTable()
        {
            int mulminute = 0;
            List<string> timetable = new List<string>();
            for (int hour = 0; hour < 24; ++hour)
            {
                string strHour = hour.ToString("00");
                for (int minute = 0; minute < 12; ++minute)
                {
                    mulminute = minute * 5;
                    string strminute = mulminute.ToString("00");
                    // Console.WriteLine(strHour + ":" + strminute + "=" + "ON");
                    timetable.Add(strHour + ":" + strminute + "=" + "ON");
                }
            }
            String[] timetableArray = timetable.ToArray();
            // Console.WriteLine(timetableArray.Length);
            return timetableArray;
        }

        public void parseTimetableIntoDataView(string[] timetable)
        {

            List<string> parsedTimetable = new List<string>();

            for (int i = 0; i < timetable.Length; i++) {
                string[] arr = timetable[i].Split('=');
                parsedTimetable.Add(arr[0]);
                parsedTimetable.Add(arr[1]);
            }

            String[] parsedTimetableArray = parsedTimetable.ToArray();

            Console.WriteLine(parsedTimetableArray.ToString());

            DataRow dr = dt.NewRow();

            for (int i = 0; i < parsedTimetableArray.Length; i++)
            {
                dr[i] = parsedTimetableArray[i];
            }

            dt.Rows.Add(dr);
            dataGridView1.DataSource = dt;
        }


        private void resetButton_Click(object sender, EventArgs e)
        {
            parseTimetableIntoDataView(_24HourTable());
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("DefaultTable.dat");

            int mulminute = 0;
            for (int hour = 0; hour < 24; ++hour)
            {
                string strHour = hour.ToString("00");
                for (int minute = 0; minute < 12; ++minute)
                {
                    mulminute = minute * 5;
                    string strMinute = mulminute.ToString("00");
                    Console.WriteLine(strHour + ":" + strMinute + "=" + "ON");
                    sw.WriteLine(strHour + ":" + strMinute + "=" + "ON");
                }
            }
            sw.Close();
        }
    }

}
