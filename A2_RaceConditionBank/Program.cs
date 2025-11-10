using System;
using System.Threading;

namespace A2_RaceConditionBank;

class Program
{
    public static void Main(string[] args)
    {
        List<Thread> threads = new List<Thread>();
        Console.WriteLine("Übung 2: Race Condition – Bankkonto");
        Console.WriteLine("==========================================\n");

        // Bankkonto mit Startwert 1000 EUR erstellen
        BankAccount account = new BankAccount(1000);
        Console.WriteLine($"Startkontostand: {account.GetBalance()} EUR\n");
        for (int i = 0; i < 10; i++)
        {
            threads.Add(new Thread(() => PerformBankOperations(account)));
        }

        foreach (Thread t in threads)
        {
            t.Start();
        }
        foreach (Thread t in threads)
        {
            t.Join();
        }

        Console.WriteLine(account.GetBalance());
    }

    private static void PerformBankOperations(BankAccount account)
    {
        account.Deposit(100);
        Thread.Sleep(100);
        account.Withdraw(100);
        Thread.Sleep(100);
    }
}

