using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetworkingExample
{
    internal class Client
    {
        public Form1 form1;
        public TcpClient tc;
        bool flag = false;

        Thread clientReadThread;

        public StreamWriter sw;
        public StreamReader sr;

        public Client(TcpClient tc, Form1 form1)
        {
            this.tc = tc;
            this.form1 = form1;
        }

        public void ServerRun()
        {
            Thread clientReadThread = new Thread(new ThreadStart(ClientRead));
            clientReadThread.Start();
        }

        public void ClientRun()
        {
            Thread clientReadThread = new Thread(new ThreadStart(ClientWrite));
            clientReadThread.Start();
        }


        void ClientRead()
        {
            sw = new StreamWriter(tc.GetStream());
            sr = new StreamReader(tc.GetStream());

            Console.WriteLine("1 종료 합니다");
            while (true)
            {
                try
                {
                    Console.WriteLine("2 종료 합니다");
                    String str = sr.ReadLine();
                    Console.WriteLine("3 종료 합니다");

                    Console.WriteLine(str);
                    sw.WriteLine("서버 : " + str + " 입니다");
                    sw.Flush();

                    Console.WriteLine("5 종료 합니다");
                }
                catch (Exception ex)
                {
                    sw.Close();
                    tc.Close();
                    sr.Close();
                    Console.WriteLine("S Client Error ~~~: ", ex);
                    break;  //스레드 종료
                }

            }

        }

        void ClientWrite()
        {
            sw = new StreamWriter(tc.GetStream());
            sr = new StreamReader(tc.GetStream());
            Console.WriteLine("C1 ");
            while (true)
            {
                try
                {
                    String str = sr.ReadLine();
                    Console.WriteLine(str);
                }
                catch (Exception ex)
                {
                    sw.Flush();
                    sw.Close();
                    tc.Close();
                    Console.WriteLine("~~~ Client Error ~~~: ", ex);
                    break;
                }
            }
        }
    }

}
