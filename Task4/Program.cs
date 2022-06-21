using System;
using System.Threading;

namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Method();
        }
        static void Method()
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            (new Thread(Method)).Start();
        }
    }
}
