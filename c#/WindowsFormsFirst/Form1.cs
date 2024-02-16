using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsFirst
{
    public partial class Form1 : Form

    {
        private List<Point> ls;

        public Form1()
        {

            InitializeComponent();
            ls = new List<Point>();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Point p = new Point(e.X, e.Y);
            ls.Add(p);
            this.Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Console.WriteLine("이벤트 발생");
            Graphics g = e.Graphics;
            Pen dp = new Pen(Color.Black, 1);
            foreach (Point p in ls)
            {
                g.DrawEllipse(dp, p.X, p.Y, 20, 20);
                Rectangle rt = new Rectangle();
                rt.X = p.X;
                rt.Y = p.Y;
                rt.Width = 150;
                rt.Height = 50;
                g.DrawRectangle(dp, rt);
            }
        }
    }
}
