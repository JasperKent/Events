using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Events
{
    public class BankAccountMultiEvents
    {
        public decimal Balance { get; private set; }

        private Dictionary<string, EventHandler<AccountArgs>> _events = new Dictionary<string, EventHandler<AccountArgs>>();

        private void Add (EventHandler<AccountArgs> handler, [CallerMemberName]string name = null)
        {
            if (_events.ContainsKey(name))
                _events[name] += handler;
            else
                _events[name] = handler;
        }

        private void Remove(EventHandler<AccountArgs> handler, [CallerMemberName]string name = null)
        {
            if (_events.ContainsKey(name))
            {
                _events[name] -= handler;

                if (_events[name] == null)
                    _events.Remove(name);
            }
        }

        private void Invoke(string name, AccountArgs args)
        {
            if (_events.ContainsKey(name))
                _events[name].Invoke(this, args);
        }

        public event EventHandler<AccountArgs> Withdrawn
        {
            add => Add(value);
            remove => Remove(value);
        }

        public event EventHandler<AccountArgs> Deposited
        {
            add => Add(value);
            remove => Remove(value);
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;

            if (Balance > 1000000)
                Invoke(nameof(Deposited),new AccountArgs { Message = "Get a deposit account" });
        }

        public void Withdraw(decimal amount)
        {
            Balance -= amount;

            if (Balance < 0)
                Invoke(nameof(Withdrawn), new AccountArgs { Message = "Going overdrawn" });
        }
    }
}
