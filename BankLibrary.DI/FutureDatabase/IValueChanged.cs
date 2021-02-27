using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary.DI.FutureDatabase
{
    public interface IValueChanged
    {
        event EventHandler ValueChanged;
    }
}
