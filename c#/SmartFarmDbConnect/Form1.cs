
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using Renci.SshNet;
using DotNetEnv;
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
        public static Tuple<SshClient, uint> ConnectSsh(string sshHostName, string sshUserName, string sshPassword = null,
            string sshKeyFile = null, string sshPassPhrase = null, int sshPort = 2222, string databaseServer = "localhost", int databasePort = 3306)
        {
            // check arguments
            if (string.IsNullOrEmpty(sshHostName))
                throw new ArgumentException($"{nameof(sshHostName)} must be specified.", nameof(sshHostName));
            if (string.IsNullOrEmpty(sshHostName))
                throw new ArgumentException($"{nameof(sshUserName)} must be specified.", nameof(sshUserName));
            if (string.IsNullOrEmpty(sshPassword) && string.IsNullOrEmpty(sshKeyFile))
                throw new ArgumentException($"One of {nameof(sshPassword)} and {nameof(sshKeyFile)} must be specified.");
            if (string.IsNullOrEmpty(databaseServer))
                throw new ArgumentException($"{nameof(databaseServer)} must be specified.", nameof(databaseServer));

            // define the authentication methods to use (in order)
            var authenticationMethods = new List<AuthenticationMethod>();
            if (!string.IsNullOrEmpty(sshKeyFile))
            {
                authenticationMethods.Add(new PrivateKeyAuthenticationMethod(sshUserName,
                    new PrivateKeyFile(sshKeyFile, string.IsNullOrEmpty(sshPassPhrase) ? null : sshPassPhrase)));
            }
            if (!string.IsNullOrEmpty(sshPassword))
            {
                authenticationMethods.Add(new PasswordAuthenticationMethod(sshUserName, sshPassword));
            }

            // connect to the SSH server
            var sshClient = new SshClient(new ConnectionInfo(sshHostName, sshPort, sshUserName, authenticationMethods.ToArray()));
            sshClient.Connect();

            // forward a local port to the database server and port, using the SSH server
            var forwardedPort = new ForwardedPortLocal("127.0.0.1", databaseServer, (uint)databasePort);
            sshClient.AddForwardedPort(forwardedPort);
            forwardedPort.Start();

            return new Tuple<SshClient, uint>(sshClient, forwardedPort.BoundPort);
        }

        public Form1()
        {
            DotNetEnv.Env.TraversePath().Load();
            InitializeComponent();

        }


        public void InsertUpdate()
        {
            var server = "127.0.0.1";
            var sshUserName = "vagrant";
            var sshKeyFile = System.Environment.GetEnvironmentVariable("SSH_KEY_FILE");
            var databaseUserName = System.Environment.GetEnvironmentVariable("DB_USERNAME");
            var databasePassword = System.Environment.GetEnvironmentVariable("DB_PASSWORD");

            Tuple<SshClient, uint> sshResult = ConnectSsh(server, sshUserName, null, sshKeyFile);
            SshClient sshClient = sshResult.Item1;
            uint localPort = sshResult.Item2;

            using (sshClient)
            {
                MySqlConnectionStringBuilder csb = new MySqlConnectionStringBuilder
                {
                    Server = "127.0.0.1",
                    Port = localPort,
                    Database = "smartfarm",
                    UserID = databaseUserName,
                    Password = databasePassword,
                };

                using (MySqlConnection connection = new MySqlConnection(csb.ConnectionString))
                {
                    string date = DateTime.Now.ToString();
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO gp2y10(dust, date) VALUES('" + 23.234 + "', '" + date + "')", connection);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            InsertUpdate();

        }
    }
}