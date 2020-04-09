using System;

namespace Events
{
    public class BankAccountWithValidator
    {
        private IAccountValidator _validator;

        public BankAccountWithValidator()
        {
            _validator = new SimpleValidator(1000000);
        }

        public decimal Balance { get; private set; }

        public event EventHandler<AccountArgs> Withdrawn
        {
            add => _validator.Validated += value;
            remove => _validator.Validated -= value;
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;

            _validator.Validate(Balance);
        }

        public void Withdraw(decimal amount)
        {
            Balance -= amount;

            _validator.Validate(Balance);
        }
    }
}
