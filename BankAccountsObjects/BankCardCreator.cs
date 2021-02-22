using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.DI.FutureDatabase;

namespace BankLibrary.BankAccountsObjects
{
    public class BankCardCreator : ICardCreator
    {
        public ICard CreateCard(string cardholderName, uint bim, int secretNumber, DateTime validDate = default(DateTime))
        {
            return new BankCard(cardholderName, bim, secretNumber, validDate);
        }
    }
}
