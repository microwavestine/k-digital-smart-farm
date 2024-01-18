using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.IO;
namespace Building
{
    internal class Program
    {
        static int count = 0;
        static void Main(string[] args)
        {
            SerialPort sp = new SerialPort("COM3", 9600);
          
            sp.DtrEnable = true;

            // Source: https://www.youtube.com/watch?v=PwT2KwJkMKQ

            sp.DataReceived += new SerialDataReceivedEventHandler(ShowArduinoMsg);
            sp.Open();

            Console.WriteLine("Press any key to stop...");
            Console.WriteLine();
            Console.ReadKey();
            sp.Close();
        }

        private static void ShowArduinoMsg(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            if (count == 0)
            {
                count++;
                sp.DiscardInBuffer();
                return;
            }
            string indata = sp.ReadLine();
            Console.WriteLine($"{DateTime.Now.ToString()}, {count}, {indata.Trim('\r')}");
            count++;
        }
    }
}