using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int ivar;
            double dvar;
            ivar = 100;
            dvar = 100.0;
            Console.WriteLine("Original value of ivar: " + ivar);
            Console.WriteLine("Original value of dvar: " + dvar);

            ivar = ivar / 3;
            dvar = dvar / 3.0;
            Console.WriteLine("New value of ivar: " + ivar);
            Console.WriteLine("New value of ivar: " + dvar);
        }
    }
}
