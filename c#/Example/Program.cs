// Demonstrate the Counter namespace.
using System;
class NSDemo
{
    static void Main()
    {
        // Notice how CountDown is qualified by Counter.
        Counter.CountDown cd1 = new Counter.CountDown(10);
        int i;
        do
        {
            i = cd1.Count();
            Console.Write(i + " ");
        } while (i > 0);
        Console.WriteLine();
        // Again, notice how CountDown is qualified by Counter.
        Counter.CountDown cd2 = new Counter.CountDown(20);
        do
        {
            i = cd2.Count();
            Console.Write(i + " ");
        } while (i > 0);
        Console.WriteLine();
        cd2.Reset(4);
        do
        {
            i = cd2.Count();
            Console.Write(i + " ");
        } while (i > 0);
        Console.WriteLine();
    }
}