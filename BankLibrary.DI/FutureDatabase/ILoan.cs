using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.Utilities.IdValues;

namespace BankLibrary.DI.FutureDatabase
{
    public interface ILoan
    {
        LoanId LoanId { get; set; }
        DateTime OpeningDate { get; }
        decimal Money { get; set; }

    }
}
