using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.DI;
using BankLibrary.FutureDatabase;
using BankLibrary.DI.BankAccounts;

namespace BankLibrary.Client
{
    class VIPClient : ClientAbstract, IOrganizationClient
    {
        public DateTime FoundationDate { get; set; }
        public decimal Income { get; set; }
        public string NameOwner { get; set; }

        public override IBankAccount MakeAccount()
        {
            return new BankAccountHuman(this);//TODO это фабрика? Даже если не так, то можно до нее расширить, вроде
        }
    }
}
