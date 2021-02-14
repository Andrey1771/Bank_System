using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.DI.BankAccounts;

namespace BankLibrary.DI.Client
{
    public interface IClient
    {
        string Name { get; set; }
        IBankAccount MakeAccount();
    }
}
