using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary.DI
{
    public interface IBankAccount
    {
        string Name { get; }
        decimal Money { get; }

        void AddCard(ICard card);
        void AddDeposit(IDeposit deposit);
        void AddLoan(ILoan loan);

    }
}
