using System;
using System.Collections.Generic;
using System.Text;

namespace Events
{
    public class AccountArgs : EventArgs
    {
        public string Message { get; set; }
    }
}
