using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary.DI
{
    public interface IDatabase
    {
        string Name { get; }
        decimal Money { get; }

        void AddCard(uint bim, int secretNumber, DateTime validDate = default(DateTime));

        void AddDeposit(decimal procentDeposit, int secretNumber,
            DateTime closingDate, DateTime openingDate = default(DateTime));

        void AddLoan(decimal procentDeposit,
            DateTime closingDate, DateTime openingDate = default(DateTime));
    }
}
