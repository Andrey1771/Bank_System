using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.DI.BankAccounts;

namespace BankLibrary.DI
{
    public interface IDepartment
    {
        string Name { get; set; } 
        ICollection<IBankAccount> Accounts { get; set; }

        bool AddClientAccount(IClient client);
        bool RemoveClientAccount(IClient client);
        bool FindClientAccount(IClient client, out IBankAccount findedAccount);
    }
}
