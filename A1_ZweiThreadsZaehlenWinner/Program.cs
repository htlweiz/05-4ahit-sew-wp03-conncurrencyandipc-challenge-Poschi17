using System;
using System.Threading;

namespace A1_ZweiThreadsZaehlenWinner;

class Program
{


    public static void Main(string[] args)
    {
        Console.WriteLine("Übung 1: Zwei Threads – Zählen & Winner");
        Thread threadA = new Thread(CountUpThreadA);
        Thread threadB = new Thread(CountDownThreadB);
        threadA.Start();
        threadB.Start();
        threadA.Join();
        threadB.Join();
    }

    private static void CountUpThreadA()
    {
        int count = 1;
        while (count < 100)
        {
            count++;
            Thread.Sleep(100);
        }
    }

    private static void CountDownThreadB()
    {
        int count = 100;
        while (count > 1)
        {
            count--;
            Thread.Sleep(100);
        }
    }
}
