using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.DI.Client;

namespace BankLibrary.DI.BankAccounts
{
    public interface IBankAccount
    {
        IClient Client { get; set; }
        string Name { get; }
        decimal Money { get; }
        decimal Debt { get; }
    }
}
