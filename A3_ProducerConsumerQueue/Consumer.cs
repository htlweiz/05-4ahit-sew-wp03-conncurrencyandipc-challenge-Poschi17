using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace A3_ProducerConsumerQueue;

public class Consumer
{
    private volatile bool shouldStop = false;
    private Thread? consumerThread;
    private int sum = 0;
    private ConcurrentQueue<int> queue;
    static object lockObj = new object();

    public Consumer(ConcurrentQueue<int> queue)
    {
        lock (lockObj)
        {
            this.queue = queue;
        }
        // Thread im Konstruktor starten
        consumerThread = new Thread(ConsumeNumbers);
        consumerThread.Start();
    }

    private void ConsumeNumbers()
    {
        int number = 0;
        while (!shouldStop)
        {
            queue.TryDequeue(out number);
            sum = sum + number;
            Console.WriteLine(queue.Count());

            Thread.Sleep(250); // 250ms Takt
        }
    }

    public void Stop()
    {
        shouldStop = true;
    }

    public int GetSum()
    {
        return sum;
    }
}
