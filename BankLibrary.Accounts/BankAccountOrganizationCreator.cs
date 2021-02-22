using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.DI.BankAccounts;
using BankLibrary.DI.Client;

namespace BankLibrary.Accounts
{
    public class BankAccountOrganizationCreator : IOrganizationAccountCreator
    {
        public IOrganizationAccount CreateOrganizationAccount(IOrganizationClient organizationClient)
        {
            return new BankAccountOrganization(organizationClient);
        }
    }
}
