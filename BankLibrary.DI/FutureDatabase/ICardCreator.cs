using System;
using System.Collections.Generic;
using System.Text;
namespace BankLibrary.DI.FutureDatabase
{
    public interface ICardCreator
    {
        ICard CreateCard(string cardholderName, uint bim, int secretNumber, DateTime validDate);
    }
}
