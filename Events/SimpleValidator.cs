using System;

namespace Events
{
    public class SimpleValidator : IAccountValidator
    {
        private decimal _top;

        public SimpleValidator(decimal top)
        {
            _top = top;
        }

        public event EventHandler<AccountArgs> Validated;

        public void Validate(decimal balance)
        {
            if (balance > _top)
                Validated?.Invoke(this, new AccountArgs { Message = "Try opening a savings account" });
            else if (balance < 0)
                Validated?.Invoke(this, new AccountArgs { Message = "You are going overdrawn" });
        }
    }
}
