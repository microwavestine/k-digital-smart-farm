using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace NetworkingExample
{
    public partial class Form1 : Form
    {
        int PORT = 800;

        string hn = Dns.GetHostName();
        IPHostEntry ih;

        Thread serverThread = null;
        public bool IsSystemExit = true;

        TcpListener tl;
        TcpClient tc;
        Client client;
        Client clientC;

        public Form1()
        {
            InitializeComponent();
            KnowIP();
        }

        void KnowIP()
        {
            ih = Dns.GetHostEntry(hn);
            for (int i = 0; i < ih.AddressList.Length; i++)
            {
                Console.WriteLine(ih.AddressList[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IsSystemExit = true;

            if (serverThread == null)
            {
                serverThread = new Thread(new ThreadStart(ServerdThread));
                serverThread.Start();
            }

        }

        private void ServerdThread()
        {
            // 써버 프로그램 입니다
            try
            {
                tl = new TcpListener(ih.AddressList[6], PORT);
                tl.Start();
                Console.WriteLine("대기 합니다");
                while (IsSystemExit)
                {
                    tc = tl.AcceptTcpClient();
                    Console.WriteLine("S Client Connect:" + tc.Client.RemoteEndPoint);

                    client = new Client(tc, this);
                    client.ServerRun();
                    Console.WriteLine("B 대기 합니다");
                }
                Console.WriteLine("S 종료 합니다");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Server Socket Error : ", ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 클라이언트 프로그램 입니다
            /*            try
                        {
                            Console.WriteLine("Client button");
                            TcpClient tc = new TcpClient();
                            tc.Connect(ih.AddressList[6], PORT);

                            client = new Client(tc, this);

                            StreamReader sr = new StreamReader(tc.GetStream());
                            StreamWriter sw = new StreamWriter(tc.GetStream());

                            sw.WriteLine(" 데이터를 보냅니다 방가방가 ");
                            sw.Flush();
                            String str = sr.ReadLine();
                            Console.WriteLine(str);

                            sr.Close();
                            tc.Close();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Receive Socket Error~~", ex);
                        }*/
            try
            {
                TcpClient tc = new TcpClient();
                tc.Connect(ih.AddressList[6], PORT);

                clientC = new Client(tc, this);
                clientC.ClientRun();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Receive Socket Error~~", ex);
                tc.Close();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            IsSystemExit = false;

            if (tc != null)
            {
                tc.Close();
            }

            if (tl != null)
            {
                tl.Stop();
            }
            serverThread = null;


            // 종료 작업시에 필요 
            // Process[] mProcess = Process.GetProcessesByName(Application.ProductName);            
            // foreach (System.Diagnostics.Process p in mProcess)
            // {
            //     p.Kill();
            // }
            // Application.Exit();
        }

        private void txt_Msg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)   // Enter key
            {
                string str = "<" + txt_Name.Text + "> " + txt_Msg.Text;
                Console.WriteLine(str);
                // txt_Chat.Text = str;
                txt_Chat.AppendText(str + "\r\n");
                txt_Msg.Text = "";
                e.Handled = true;

                clientC.sw.WriteLine(str);
                clientC.sw.Flush();
            }
        }
    }
}
