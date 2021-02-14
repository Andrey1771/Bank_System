using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.DI.FutureDatabase;

namespace BankLibrary.DI.BankAccounts
{
    public interface IHumanAccount : IBankAccount
    {
        void AddCard(ICard card);
        void AddDeposit(IDeposit deposit);
        void AddLoan(ILoan loan);

    }
}
