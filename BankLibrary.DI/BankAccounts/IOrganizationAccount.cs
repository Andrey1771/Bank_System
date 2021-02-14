using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.DI.FutureDatabase;

namespace BankLibrary.DI.BankAccounts
{
    public interface IOrganizationAccount : IBankAccount
    {
        void AddDeposit(IDeposit deposit);
        void AddLoan(ILoan loan);

    }
}
