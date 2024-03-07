using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFourthServerClient;

namespace WindowsFourthServerClient
{
    public class Client
    {
        public Form1 form1;
        public TcpClient tc;         

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

        void ClientRead()
        {
            sw = new StreamWriter(tc.GetStream());
            sr = new StreamReader(tc.GetStream());

            Console.WriteLine("SC1 종료 합니다");
            while (true)
            {
                try
                {
                    Console.WriteLine("SC2 종료 합니다");
                    String str = sr.ReadLine();                   
                    Console.WriteLine("SC3 종료 합니다");
                    Console.WriteLine("S Client Connect:" + tc.Client.RemoteEndPoint + "\r\n");
                    // Console.WriteLine(str);


                    //foreach (Client _client in Form1.clientList)
                    //{
                    //  // _client.SendData("LED ON");
                    //}

                    form1.Message_SndAll(str);

                    // sw.WriteLine(str);
                    // sw.Flush();

                    str += "\r\n";

                    if (form1.txt_ChatS.InvokeRequired)
                    {
                        //   form1.txt_Chat.BeginInvoke(
                        //    (MethodInvoker)delegate ()
                        //       {
                        //           form1.txt_Chat.Text += str;
                        //       }
                        //    );

                        form1.txt_Chat.BeginInvoke(new Action(() =>
                        {
                            // form1.txt_ChatS.Text += str;
                            form1.txt_ChatS.AppendText(str);
                        }));
                    }
                    else
                    {
                        // form1.txt_ChatS.Text = str;
                        form1.txt_Chat.AppendText(str);
                    }

                    Console.WriteLine("SC5 종료 합니다");
                }
                catch (Exception ex)
                {
                    sw.Close();
                    tc.Close();
                    sr.Close();
                    form1.Remove_Client(this);
                    form1.Message_SndAll(" 퇴장했습니다.");                    
                 
                    Console.WriteLine("S Client Error ~~~: ", ex);
                    break;  //스레드 종료
                }

            }

        }

        public void ClientRun()
        {
            Thread clientReadThread = new Thread(new ThreadStart(ClientWrite));
            clientReadThread.Start();
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

                    if (str == "LED=ON")
                    {
                        MessageBox.Show(str);
                    }
                    str += "\r\n";
                    Console.WriteLine(str);

                    if (form1.txt_Chat.InvokeRequired)
                    {
                        //   form1.txt_Chat.BeginInvoke(
                        //    (MethodInvoker)delegate ()
                        //       {
                        //           form1.txt_Chat.Text += str;
                        //       }
                        //    );

                        form1.txt_Chat.BeginInvoke(new Action(() =>
                        {
                            //form1.txt_Chat.Text += str;
                            form1.txt_Chat.AppendText(str);
                        }));
                    }
                    else
                    {
                        form1.txt_Chat.AppendText(str); 
                    }
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
