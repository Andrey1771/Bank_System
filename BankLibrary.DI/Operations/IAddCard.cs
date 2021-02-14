using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.DI.Client;
using BankLibrary.DI.FutureDatabase;

namespace BankLibrary.DI.Operations
{
    public interface IAddCard
    {
        void AddCard(ICard card, IClient client);
    }
}
