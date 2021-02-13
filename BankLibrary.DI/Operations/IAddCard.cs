using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary.DI.Operations
{
    public interface IAddCard
    {
        void AddCard(ICard card, IClient client);
    }
}
