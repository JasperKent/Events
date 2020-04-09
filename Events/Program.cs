using System;

namespace Events
{
    class Program
    {
        static void Main()
        {
            //BankAccountAutoEvent ba = new BankAccountAutoEvent();
            //BankAccountManualEvent ba = new BankAccountManualEvent();
            //BankAccountWithValidator ba = new BankAccountWithValidator();
            BankAccountMultiEvents ba = new BankAccountMultiEvents();

            ba.Withdrawn += (s, e) => Console.WriteLine($"Withdrawal message from bank: {e.Message}.");
            ba.Deposited += (s, e) => Console.WriteLine($"Deposit message from bank: {e.Message}.");

            ba.Deposit(500);
            ba.Withdraw(1000);
            ba.Deposit(2000000);

            Console.WriteLine($"Balance is {ba.Balance}.");
        }
    }
}
