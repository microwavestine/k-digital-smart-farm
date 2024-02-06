using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsFirst
{
    public partial class Form1 : Form

    {
        private int deltaY = 5;
        public Form1()
        {

            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int newTop = pictureBox4.Top + deltaY;

            // Check if the image is going out of the form's bounds
            if (newTop < 0)
            {
                newTop = 0;
                deltaY = -deltaY; // Reverse the direction when reaching the top
            }
            else if (newTop + pictureBox4.Height > ClientSize.Height)
            {
                newTop = ClientSize.Height - pictureBox4.Height;
                deltaY = -deltaY; // Reverse the direction when reaching the bottom
            }
            pictureBox4.Top = newTop;
        }
    }
}
