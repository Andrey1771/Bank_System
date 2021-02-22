using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.Utilities.IdValues;

namespace BankLibrary.DI.FutureDatabase
{
    public interface IDeposit
    {
        DepositId DepositId { get; set; }

        string OwnerName { get; }
        DateTime OpeningDate { get; }
        DateTime ClosingDate { get; }
        decimal Money { get; set; }
        decimal ProcentDeposit { get; set; }

    }
}
