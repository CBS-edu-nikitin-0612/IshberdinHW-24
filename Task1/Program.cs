using System;
using System.Text;
using System.Threading;

namespace Task2
{

    internal class Program
    {
        static Random rnd = new Random();
        static object flag = new object();

        static void Main(string[] args)
        {
            int length = 120;

            Console.CursorVisible = false;
            new Thread(new ThreadStart(RefreshRnd)).Start();

            for (int i = 0; i < length; i++)
            {
                Line line = new Line(i);
                new Thread(new ThreadStart(line.Start)).Start();
            }

        }
        static void RefreshRnd()
        {
            while (true)
            {
                Thread.Sleep(120000);
                rnd = new Random();
            }
        }

        public class Line
        {
            public int x;
            public int y;
            public int count;

            void PrintChar(int x, int y, char val, ConsoleColor color)
            {
                lock (flag)
                {
                    if (y >= 0 & y < 30)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.ForegroundColor = color;
                        Console.Write(val);
                    }
                }
            }
            void PrintChar(int x, int y, ConsoleColor color) { PrintChar(x, y, (char)rnd.Next('A', 'Z'), color); }



            public void Start()
            {
                Thread.Sleep(rnd.Next(10, 6000));
                while (true)
                {
                    while (y < 40)
                    {
                        Print();
                        Thread.Sleep(100);
                        y++;
                    }
                    count = rnd.Next(3, 10);
                    y = 0;
                }
            }
            public void Print()
            {
                for (int i = 0; i < count; i++)
                {
                    switch (i)
                    {
                        case 0:
                            PrintChar(x, y - i, ConsoleColor.White);
                            break;
                        case 1:
                            PrintChar(x, y - i, ConsoleColor.Green);
                            break;
                        default:
                            PrintChar(x, y - i, ConsoleColor.DarkGreen);
                            break;
                    }
                }
                PrintChar(x, y - count, ' ', ConsoleColor.DarkGreen);
            }

            public Line(int x)
            {
                y = 0;
                this.x = x;
                count = rnd.Next(3, 10);
            }
        }
    }
}
