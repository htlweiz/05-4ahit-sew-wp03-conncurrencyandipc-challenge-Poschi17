using System;
using System.Threading;

namespace A1_ZweiThreadsZaehlenWinner;

class Program
{


    public static void Main(string[] args)
    {
        int countA = 1;
        int countB = 100;
        Console.WriteLine("Übung 1: Zwei Threads – Zählen & Winner");
        Thread threadA = new Thread(() => CountUpThreadA(countA));
        Thread threadB = new Thread(() => CountDownThreadB(countB));
        Thread threadCheck = new Thread(() => CheckCount(countA, countB, threadA, threadB));
        threadA.Start();
        threadB.Start();
        threadCheck.Start();
        Console.WriteLine(countA);
    }

    private static void CountUpThreadA(int countA)
    {
        while (countA < 100)
        {
            countA++;
            Thread.Sleep(100);
        }
    }

    private static void CountDownThreadB(int countB)
    {
        while (countB > 1)
        {
            countB--;
            Thread.Sleep(100);
        }
    }

    private static int CheckCount(int countA, int countB, Thread threadA, Thread threadB)
    {
        while (countA != countB)
        {
            if (countA == countB)
            {
                threadA.Join();
                threadB.Join();
                return countA;
            }
        }
        return 0;
    }

}
