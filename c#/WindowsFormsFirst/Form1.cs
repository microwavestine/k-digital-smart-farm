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
        private bool visible = true;
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

        private void Form1_Activated(object sender, EventArgs e)
        {
            while(visible == true)
            {
                for (int c = 0; c < 254 && visible == true; ++c)
                {
                    this.BackColor = System.Drawing.Color.FromArgb(c, 255 - c, 0);
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(3);
                }

                for (int c = 254; c >= 0 && visible == true; --c)
                {
                    this.BackColor = System.Drawing.Color.FromArgb(c, 255 - c, 0);
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(3);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            visible = true;
            while (visible == true)
            {
                for (int c = 0; c < 254 && visible == true; ++c)
                {
                    this.BackColor = System.Drawing.Color.FromArgb(c, 255 - c, 0);
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(3);
                }

                for (int c = 254; c >= 0 && visible == true; --c)
                {
                    this.BackColor = System.Drawing.Color.FromArgb(c, 255 - c, 0);
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(3);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form myForm = new Form();
            myForm.Width = this.Width;
            myForm.Height = this.Height;
            myForm.StartPosition = this.StartPosition;
            myForm.ShowDialog();
        }
    }
}
