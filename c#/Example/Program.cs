using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
namespace Building
{
    class TwoDShape
    {
        public double Width;
        public double Height;

        // Constructor for TwoDShape.
        public TwoDShape(double w, double h)
        {
            Width = w;
            Height = h;
        }
    }
    class Triangle : TwoDShape
    {
        public string Style;
        // Call the base class constructor.
        public Triangle(string s, double w, double h) : base(w, h)
        {
            Style = s;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Triangle t1 = new Triangle("isosceles", 4.0, 4.0);
            Console.WriteLine(t1.Width + " " + t1.Height + " " + t1.Style);
        }
    }
}
[출처] Base 클래스에 초기값 전달하기 (IT메카닉스) | 작성자 eljet