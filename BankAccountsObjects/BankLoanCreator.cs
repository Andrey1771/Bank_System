using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.DI.FutureDatabase;

namespace BankLibrary.BankAccountsObjects
{
    public class BankLoanCreator : ILoanCreator
    {
        public ILoan CreateLoan(string ownerName, decimal procentLoan, DateTime closingDate, DateTime openingDate = default(DateTime))
        {
            return new BankLoan(ownerName, procentLoan, closingDate, openingDate);
        }
    }
}
