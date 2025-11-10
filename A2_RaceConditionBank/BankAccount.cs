using System;
using System.Threading;

namespace A2_RaceConditionBank;

public class BankAccount
{
    private int balance;
    static object lockObj = new object();

    public BankAccount(int initial)
    {
        balance = initial;
    }

    public void Deposit(int amount)
    {
        lock (lockObj)
        {
            balance += amount;
        }
    }

    public void Withdraw(int amount)
    {
        lock (lockObj)
        {
            balance -= amount;
        }
    }

    public int GetBalance()
    {
        return balance;
    }
}
