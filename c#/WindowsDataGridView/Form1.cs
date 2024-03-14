using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using WindowsDataGridView.Properties;

namespace WindowsDataGridView
{
    public partial class Form1 : Form
    {

        [DllImport("kernel32")]
        public static extern bool WritePrivateProfileString(string AppName, string KeyName, string KeyData, string FileName);

        [DllImport("kernel32")]
        public static extern int GetPrivateProfileString(string AppName, string KeyName, string Default, StringBuilder ReturnValue, int nSize, string FileName);

        public string MY_HOUSE_DAT = Environment.CurrentDirectory + "\\house.dat";

        public const string DELIM = "_";

        
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

            List<string> parsedTimetable = new List<string>(timetable);
            String[] parsedTimetableArray = parsedTimetable.ToArray();

            Dictionary<string, string> timeKeyOnOffSettingValuePairs = new Dictionary<string, string>();

            for (int i = 0; i < parsedTimetableArray.Length; i++)
            {
                String[] arr = parsedTimetableArray[i].Split('=');
                timeKeyOnOffSettingValuePairs.Add(arr[0], arr[1]);
            }

            foreach(string time  in timeKeyOnOffSettingValuePairs.Keys)
            {
                DataRow dr = dt.NewRow();
                dr[0] = time;
                dr[1] = timeKeyOnOffSettingValuePairs[time];
                dt.Rows.Add(dr);
            }
            dataGridView1.DataSource = dt;
        }


        private void resetButton_Click(object sender, EventArgs e)
        {
            parseTimetableIntoDataView(_24HourTable());
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
/*            StreamWriter sw = new StreamWriter("DefaultTable.dat");

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
            sw.Close();*/
        }

        private void loadButton_Click(object sender, EventArgs e)
        {

        }
    }

}
