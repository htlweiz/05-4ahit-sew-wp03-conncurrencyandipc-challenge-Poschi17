using System;
using System.Threading;

namespace A1_ZweiThreadsZaehlenWinner;

class Program
{
    static int countA = 1;
    static int countB = 100;

    public static void Main(string[] args)
    {

        Console.WriteLine("Übung 1: Zwei Threads – Zählen & Winner");
        Thread threadA = new Thread(CountUpThreadA);
        Thread threadB = new Thread(CountDownThreadB);
        threadA.Start();
        threadB.Start();
        threadA.Join();
        threadB.Join();

        Console.WriteLine(countA);
        if (countA < 50)
        {
            Console.WriteLine("thread1");
        }
        else if (countA == 50)
        {
            Console.WriteLine("Draw");
        }
        else
        {
            Console.WriteLine("thread2");
        }
    }

    private static void CountUpThreadA()
    {
        while (countA < 100)
        {
            if (countA == countB)
            {
                break;
            }
            countA++;
            Thread.Sleep(100);
        }
    }

    private static void CountDownThreadB()
    {
        while (countB > 1)
        {
            if (countA == countB)
            {
                break;
            }
            countB--;
            Thread.Sleep(100);
        }
    }

}
