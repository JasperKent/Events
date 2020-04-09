using System;

namespace Events
{
    public interface IAccountValidator
    {
        event EventHandler<AccountArgs> Validated;

        void Validate(decimal balance);
    }
}
