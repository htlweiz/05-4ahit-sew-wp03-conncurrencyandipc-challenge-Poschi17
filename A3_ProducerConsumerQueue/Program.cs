using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace A3_ProducerConsumerQueue;

class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("Übung 3: Producer-Consumer");
        Console.WriteLine("==========================================\n");

        // TODO
        ConcurrentQueue<int> queue = new ConcurrentQueue<int>();
        List<Producer> producers = new List<Producer>();
        Consumer consumer = new Consumer(queue);

        Console.WriteLine("Producer und Consumer gestartet...\n");

        // Überwachung: Jede Sekunde Queue-Füllstand ausgeben und auf >50 prüfen


        // TODO
        for (int i = 0; i < 5; i++)
        {
            int id = i;
            producers.Add(new Producer(id, queue));
        }

        while (queue.Count() < 50)
        {
            Thread.Sleep(10);
        }

        // Alle Producer stoppen
        foreach (Producer p in producers)
        {
            p.Stop();
        }
        consumer.Stop();


        Console.WriteLine(consumer.GetSum());

        // Consumer stoppen


    }
}
