using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.DI.Client;

namespace BankLibrary.DI.BankAccounts
{
    public interface IOrganizationAccountCreator
    {
        IOrganizationAccount CreateOrganizationAccount(IOrganizationClient organizationClient);
    }
}
