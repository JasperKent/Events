using System;

namespace Events
{
    public class BankAccountManualEvent
    {
        public decimal Balance { get; private set; }

        private EventHandler<AccountArgs> _withdrawn;

        public event EventHandler<AccountArgs> Withdrawn
        {
            add => _withdrawn += value;
            remove => _withdrawn -= value;
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            Balance -= amount;

            if (Balance < 0)
                _withdrawn?.Invoke(this, new AccountArgs { Message = "You are going overdrawn" });
        }
    }
}
