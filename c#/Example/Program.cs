// A very simple event demonstration.
using System;
// Declare a delegate type for an event.
delegate void MyEventHandler();
// Declare a class that contains an event.
class MyEvent
{
    // public MyEventHandler SomeEvent;
    public event MyEventHandler SomeEvent;
    // This is called to raise the event.
    public void OnSomeEvent()
    {
        if (SomeEvent != null)
            SomeEvent();
    }
}
class EventDemo
{
    // An event handler.
    static void Handler()
    {
        Console.WriteLine("Event occurred");
    }

    static void Handler2()
    {
        Console.WriteLine("Event occured2");
    }

    static void Handler3()
    {
        Console.WriteLine("Event occured3");
    }

    static void Main()
    {
        MyEvent evt = new MyEvent();
        // Add Handler() to the event list.
        evt.SomeEvent += Handler;
        // Raise the event.
        //evt.SomeEvent();
        evt.OnSomeEvent();
    }
}