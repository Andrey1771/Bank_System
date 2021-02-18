using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.DI;
using BankLibrary.DI.BankAccounts;
using BankLibrary.Accounts;
using BankLibrary.DI.Client;

namespace BankLibrary.Client
{
    public class LegalClient : ClientAbstract, IOrganizationClient
    {
        public DateTime FoundationDate { get; set; }
        public decimal Income { get; set; }
        public string NameOwner { get; set; }

        public override IBankAccount MakeAccount()
        {
            return new BankAccountOrganization(this);//TODO это фабрика? Даже если не так, то можно до нее расширить, вроде
        }
    }
}
