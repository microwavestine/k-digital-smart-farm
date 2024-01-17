using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Building
{
    class Building
    {
        public int Area;
        public int BuildingArea()
        {
            return Area * 10;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Building house = new Building();
            house.Area = 1000;
            Console.WriteLine(house.BuildingArea());
        }
    }
}