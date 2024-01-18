using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.IO;
namespace Building
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] strs = { "one", "two", "three", "two", "one" };

            foreach (string s in strs)
            {
                switch (s)
                {
                    case "one":
                        Console.Write(1);
                        break;
                    case "two":
                        Console.Write(2);
                        break;
                    case "three":
                        Console.Write(3);
                        break;
                }
            }
            Console.WriteLine();
        }
    }

}