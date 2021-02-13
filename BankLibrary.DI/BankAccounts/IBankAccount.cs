using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary.DI.BankAccounts
{
    public interface IBankAccount
    {
        string Name { get; }
        decimal Money { get; }
        decimal Debt { get; }
    }
}
