using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using static System.Net.Mime.MediaTypeNames;
using log4net;
using System.Runtime.InteropServices;
using log4net.Config;

namespace WindowsFourthServerClient
{
    public partial class Form1 : Form
    {

        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        int PORT = 7000;

        string hn = Dns.GetHostName();
        IPHostEntry ih;

        Thread serverThread = null;
        public bool IsSystemExit = true;

        TcpListener tl;
        TcpClient tcS;
        TcpClient tcC = null;
        Client clientS;
        Client clientC;

        List<Client> clientList = new List<Client>();

        public Form1()
        {
            InitializeComponent();
            XmlConfigurator.Configure(new FileInfo("../../LoggerConfig.xml"));
            log.Info("hello");
            KnowIP();
            file_read();
        }

        void KnowIP()
        {
            ih = Dns.GetHostEntry(hn);
        }

        void file_read()
        {
            FileInfo file = new FileInfo("IP.txt");

            int line = 0;

            if (file.Exists)
            {
                StreamReader sr = new StreamReader("IP.txt");

                while (!sr.EndOfStream)    // 화일의 끝에 도달하면 -1을 반환
                {
                    if (line == 0) txt_Server_IP.Text = sr.ReadLine().Trim();
                    if (line == 1) txt_Client_IP.Text = sr.ReadLine().Trim();
                    if (line == 2) txt_Name.Text = sr.ReadLine().Trim();
                    ++line;
                }
                sr.Close();
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
                IPAddress ipaAddress = IPAddress.Parse(txt_Server_IP.Text);

                tl = new TcpListener(ipaAddress, PORT);
                tl.Start();

                // log.Debug("SThA 대기 합니다");

                txt_ChatS.Text = "SThA 대기 합니다";

                while (IsSystemExit)
                {
                    tcS = tl.AcceptTcpClient();
                    log.Debug("S Client Connect:" + tcS.Client.RemoteEndPoint + "\r\n");


                    if (txt_ChatS.InvokeRequired)
                    {
                        txt_Chat.BeginInvoke(new Action(() =>
                        {
                            txt_ChatS.AppendText("\r\nClient Connect:" + tcS.Client.RemoteEndPoint + "\r\n");
                        }));
                    }
                    else
                    {
                        txt_Chat.AppendText("\r\nClient Connect:" + tcS.Client.RemoteEndPoint + "\r\n");
                    }

                    // txt_ChatS.Text += "\r\nClient Connect:" + tcS.Client.RemoteEndPoint + "\r\n";

                    clientS = new Client(tcS, this);

                    clientList.Add(clientS);

                    clientS.ServerRun();
                    log.Debug("SThB 대기 합니다");
                }
                IsSystemExit = false;
                log.Debug("SThB 종료 합니다");
            }
            catch (Exception ex)
            {
                log.Debug("Server Socket Error : ", ex);
            }
        }

        public void Message_SndAll(string lstMessage)
        {
            foreach (Client _client in clientList)
            {
                try
                {
                    _client.sw.WriteLine(lstMessage);
                    _client.sw.Flush();
                }
                catch (Exception ex)
                {
                    log.Debug("error " + ex.Message);
                }
            }
        }

        public void Remove_Client(Client _client)
        {
            clientList.Remove(_client);
        }

        void Message_SndS(string lstMessage)
        {
            try
            {
                clientS.sw.WriteLine(lstMessage);
                clientS.sw.Flush();
            }
            catch (Exception ex)
            {
                log.Debug("error " + ex.Message);
                tcS.Close();
            }
        }

        private void txt_MsgS_KeyPress(object sender, KeyPressEventArgs e)
        {
            // log.Debug(((int)e.KeyChar));
            if (e.KeyChar == 13)   // Enter key
            {
                string str = "[" + txt_NameS.Text + "]" + txt_MsgS.Text;
                log.Debug(str);
                // txt_Chat.Text = str;
                // txt_Chat.AppendText(str + "\r\n");
                txt_MsgS.Text = "";
                e.Handled = true;
                Message_SndAll(str);
            }

        }



        //================   클라이언트 관련   ================// 
        private void button2_Click(object sender, EventArgs e)
        {
            // 클라이언트 프로그램 입니다
            try
            {
                //IP Address 할당
                IPAddress ipaAddress = IPAddress.Parse(txt_Client_IP.Text);

                log.Debug(ipaAddress);

                if (tcC == null)
                {
                    tcC = new TcpClient();

                    log.Debug(" B " + tcC);

                    tcC.Connect(ipaAddress, PORT);

                    clientC = new Client(tcC, this);
                    clientC.ClientRun();
                }
                // string str = "<" + txt_Name.Text + ">  접속 하셨습니다. \r\n";
                // log.Debug(str);

                // Thread.Sleep(3000);    //  clientC.ClientRun() 처리하는 시간을 기다린다

                // Message_Snd(str);
            }
            catch (Exception ex)
            {
                log.Debug("Receive Socket Error~~", ex);
                if (tcC != null)
                {
                    tcC.Close();
                    tcC = null;
                }                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IsSystemExit = false;

            if (tcS != null)
            {
                tcS.Close();
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
            // log.Debug(((int)e.KeyChar));
            if (e.KeyChar == 13)   // Enter key
            {
                string str = txt_Msg.Text;
                log.Debug(str);
                // txt_Chat.Text = str;
                // txt_Chat.AppendText(str + "\r\n");
                txt_Msg.Text = "";
                e.Handled = true;
                Message_Snd(str);
            }
        }
        void Message_Snd(string lstMessage)
        {
            try
            {
                clientC.sw.WriteLine(lstMessage);
                clientC.sw.Flush();
            }
            catch (Exception ex)
            {
                log.Debug("error " + ex.Message);
                tcC.Close();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("IP.txt");
            sw.WriteLine(txt_Server_IP.Text.Trim());
            sw.WriteLine(txt_Client_IP.Text.Trim());
            sw.WriteLine(txt_Name.Text.Trim());
            sw.Close();
        }
    }
}
