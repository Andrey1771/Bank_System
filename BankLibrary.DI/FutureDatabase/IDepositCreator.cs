using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary.DI.FutureDatabase
{
    public interface IDepositCreator
    {
        IDeposit CreateDeposit(string ownerName, decimal procentDeposit, DateTime closingDate, DateTime openingDate);
    }
}
