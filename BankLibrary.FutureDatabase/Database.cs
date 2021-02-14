using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.DI.FutureDatabase;
using BankLibrary.DI;


namespace BankLibrary.FutureDatabase
{
    public class Database : IDatabase
    {
        public string Name => throw new NotImplementedException();

        public decimal Money => throw new NotImplementedException();

        public void AddCard(uint bim, int secretNumber, DateTime validDate = default)
        {
            throw new NotImplementedException();
        }

        public void AddDeposit(decimal procentDeposit, int secretNumber, DateTime closingDate, DateTime openingDate = default)
        {
            throw new NotImplementedException();
        }

        public void AddLoan(decimal procentDeposit, DateTime closingDate, DateTime openingDate = default)
        {
            throw new NotImplementedException();
        }
    }
}
