using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.DI;
using BankLibrary.Utilities.IdValues;
using BankLibrary.DI.BankAccounts;
using BankLibrary.DI.Client;

namespace BankLibrary.Accounts
{
    public abstract class BankAccount : IBankAccount
    {
        public IClient Client { get; set; }

        public string Name { get { return Client.Name; } }

        public abstract decimal Money { get; }
        public abstract decimal Debt { get; }

        public BankAccount(IClient aclient)
        {
            Client = aclient;
        }
    }
}
