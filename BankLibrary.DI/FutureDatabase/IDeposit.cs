using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.Utilities.IdValues;

namespace BankLibrary.DI.FutureDatabase
{
    public interface IDeposit
    {
        DepositId BankId { get; }
        DateTime OpeningDate { get; }
        decimal Money { get; set; }

    }
}
