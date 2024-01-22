using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
namespace Building
{
    class FailSoftArray
    {
        int[] a;
        public FailSoftArray(int size)
        {
            a = new int[size];
        }
        public int this[int index]
        {
            get
            {
                return a[index] + 3;
            }
            set
            {
                a[index] = value * 10;
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            FailSoftArray fs = new FailSoftArray(5);
            int x;
            fs[0] = 500;
            x = fs[0];
            Console.WriteLine(x);
        }
    }
}