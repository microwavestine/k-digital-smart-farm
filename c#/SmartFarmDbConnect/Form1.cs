
using MySql.Data.MySqlClient;
using Renci.SshNet;
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
using static System.Net.WebRequestMethods;

namespace SmartFarmDbConnect
{
    public partial class Form1 : Form
    {
        static string SshHostName = "127.0.0.1";
        static string SshUserName = "vagrant";
        static string SshKeyFile = @"C:/Users/code/dbworks/.vagrant/machines/dbworks-01/virtualbox/private_key";

        static string Server = "***.eu-west-1.rds.amazonaws.com";
        static uint Port = 3306;
        static string UserID = "root";
        static string Password = "***";
/*        static string DataBase = "***";*/

        public Form1()
        {
            InitializeComponent();

            ConnectionInfo cnnInfo;
            using (var stream = new FileStream(SshKeyFile, FileMode.Open, FileAccess.Read))
            {
                var file = new PrivateKeyFile(stream);
                var authMethod = new PrivateKeyAuthenticationMethod(SshUserName, file);
                cnnInfo = new ConnectionInfo(SshHostName, 22, SshUserName, authMethod);
            }

            using (var client = new SshClient(cnnInfo))
            {
                client.Connect();
                if (client.IsConnected)
                {
                    var forwardedPort = new ForwardedPortLocal("127.0.0.1", Server, Port);
                    client.AddForwardedPort(forwardedPort);
                    forwardedPort.Start();

                    string connStr = $"Server = {forwardedPort.BoundHost};Port = {forwardedPort.BoundPort};Uid = {UserID};Pwd = {Password};";

                    using (MySqlConnection cnn = new MySqlConnection(connStr))
                    {
                        cnn.Open();

                        MySqlCommand cmd = new MySqlCommand("SELECT * FROM PostalCodes LIMIT 25;", cnn);

                        MySqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                            Console.WriteLine($"{reader.GetString(1)}, {reader.GetString(2)}, {reader.GetString(3)}");

                        Console.WriteLine("Ok");

                        cnn.Close();
                    }

                    client.Disconnect();
                }

            }


            /*            PasswordConnectionInfo sshConnInfo = new PasswordConnectionInfo("111.222.333.444", 22, "server-id", "server-pw"); 
                        sshConnInfo.Timeout = TimeSpan.FromSeconds(30); 
                        SshClient sshClient = new SshClient(sshConnInfo);

                        try
                        {
                            sshClient.Connect();

                            if (sshClient.IsConnected)
                            {
                                // tunnel job
                                ForwardedPortLocal tunnel = new ForwardedPortLocal("127.0.0.1", 8008, "127.0.0.1", 3306);
                                sshClient.AddForwardedPort(tunnel);
                                tunnel.Start();

                                // Mysql job
                                MySqlConnection mycon = new MySqlConnection("Server=127.0.0.1;Database=db-name;Uid=db-id;Pwd=db-pw;SslMode=none;Port=8008;");
                                mycon.Open();
                                MySqlCommand mycmd = new MySqlCommand("sql statement");
                                MySqlDataAdapter da = new MySqlDataAdapter();
                                mycmd.Connection = mycon;
                                da.SelectCommand = mycmd;
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                            }
                            else
                            {

                            }

                        } catch (Exception ex)
                        {

                        }*/


        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}

// credits to https://walkingfox.tistory.com/73

/*Host dbworks-01
  HostName 127.0.0.1
  User vagrant
  Port 2222
  UserKnownHostsFile /dev/null
  StrictHostKeyChecking no
  PasswordAuthentication no
  IdentityFile C:/ Users / code / dbworks /.vagrant / machines / dbworks - 01 / virtualbox / private_key
  IdentitiesOnly yes
  LogLevel FATAL
  PubkeyAcceptedKeyTypes +ssh-rsa
  HostKeyAlgorithms +ssh-rsa*/