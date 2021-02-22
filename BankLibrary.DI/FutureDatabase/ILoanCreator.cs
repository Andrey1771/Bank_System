using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary.DI.FutureDatabase
{
    public interface ILoanCreator
    {
        ILoan CreateLoan(string ownerName, decimal procentLoan, DateTime closingDate, DateTime openingDate);
    }
}
