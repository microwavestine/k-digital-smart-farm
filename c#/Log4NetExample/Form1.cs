using log4net.Config;
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

namespace Log4NetExample
{
    public partial class Form1 : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public Form1()
        {
            InitializeComponent();
            // BasicConfigurator.Configure();
            XmlConfigurator.Configure(new FileInfo("../../LoggerConfig.xml"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            log.Info("Testing logger");
        }
    }
}
