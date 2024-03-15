using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Windows.Forms;
using System.Xml;
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

            foreach(var time in timeKeyOnOffSettingValuePairs.Keys.Select((val, index) => (val, index)))
            {
                DataRow dr = dt.NewRow();
                dr[0] = time.val; // 00:00
                dr[1] = timeKeyOnOffSettingValuePairs[time.val]; // ON/OFF
                dt.Rows.Add(dr);
                if ((string)dr[1] == "ON")
                {
                    dataGridView1.Rows[time.index].Cells[1].Value = "ON";
                    dataGridView1.Rows[time.index].Cells[1].Style.BackColor = Color.Green;
                }
                if ((string)dr[1] == "OFF")
                {
                    dataGridView1.Rows[time.index].Cells[1].Value = "OFF";
                    dataGridView1.Rows[time.index].Cells[1].Style.BackColor = Color.DarkGray;
                }
            }
            
            dataGridView1.DataSource = dt;
        }


        private void resetButton_Click(object sender, EventArgs e)
        {
            parseTimetableIntoDataView(_24HourTable());
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string house_name = textBox1.Text;

            StreamWriter sw = new StreamWriter(house_name + ".dat");

            for(int i =0; i < dt.Rows.Count; i++)
            {
                sw.WriteLine(dt.Rows[i][0] + "=" + dt.Rows[i][1]);
            }

            sw.Close();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {

            List<string> savedInfo = new List<string>();
            try
            {
                // Create a StreamReader
                using (StreamReader reader = new StreamReader(textBox1.Text+".dat"))
                {
                    string line;
                    // Read line by line
                    while ((line = reader.ReadLine()) != null)
                    {
                        savedInfo.Add(line);
                    }
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }

            string[] savedInfoArray = savedInfo.ToArray();
            parseTimetableIntoDataView(savedInfoArray);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string arg = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

            if (arg == "ON") { dataGridView1.Rows[e.RowIndex].Cells[1].Value = "OFF"; dataGridView1.Rows[e.RowIndex].Cells[1].Style.BackColor = Color.DarkGray; }
            if (arg == "OFF") { dataGridView1.Rows[e.RowIndex].Cells[1].Value = "ON"; dataGridView1.Rows[e.RowIndex].Cells[1].Style.BackColor = Color.Green; }
        }
    }

}
