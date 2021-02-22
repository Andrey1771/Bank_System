using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.DI.FutureDatabase;

namespace BankLibrary.BankAccountsObjects
{
    public class BankDepositCreator : IDepositCreator
    {
        public IDeposit CreateDeposit(string ownerName, decimal procentDeposit, DateTime closingDate, DateTime openingDate = default(DateTime))
        {
            return new BankDeposit(ownerName, procentDeposit, closingDate, openingDate);
        }
    }
}
