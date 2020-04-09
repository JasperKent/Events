using System;

namespace Events
{
    public class BankAccountAutoEvent
    {
        public decimal Balance { get; private set; }

        public event EventHandler<AccountArgs> Withdrawn;

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            Balance -= amount;

            if (Balance < 0)
                Withdrawn?.Invoke(this, new AccountArgs { Message = "You are going overdrawn" });
        }
    }
}
