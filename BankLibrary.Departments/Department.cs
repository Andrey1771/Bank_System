using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.DI;
using BankLibrary.DI.BankAccounts;
using BankLibrary.DI.Department;
using BankLibrary.DI.Client;

namespace BankLibrary.Departments
{
    public abstract class Department : IDepartment
    {
        public string Name { get; set; }
        public ICollection<IBankAccount> Accounts { get; set; }//TOOD реализовать свою коллекцию?

        public Department(ICollection<IBankAccount> aAccounts, string aName = "Department")
        {
            Name = aName;
            Accounts = aAccounts;
        }

        public bool AddClientAccount(IClient client)
        {
            var tempAccount = client.MakeAccount();
            if (!Accounts.Contains(tempAccount))
                Accounts.Add(tempAccount);
            else
                return false;
            return true;
        }

        public bool FindClientAccount(IClient client, out IBankAccount findedAccount)
        {
            findedAccount = null;
            foreach (var account in Accounts)
            {
                if(account == client)
                {
                    findedAccount = account;//TODO Fix that
                    return true;
                }
            }
            return false;
        }

        public bool RemoveClientAccount(IClient client)
        {
            var tempAccount = client.MakeAccount();
            if (Accounts.Contains(tempAccount))
                Accounts.Remove(tempAccount);
            else
                return false;
            return true;
        }
    }
}
