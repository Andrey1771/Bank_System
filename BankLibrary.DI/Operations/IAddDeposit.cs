using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.DI.Client;
using BankLibrary.DI.FutureDatabase;

namespace BankLibrary.DI.Operations
{
    public interface IAddDeposit
    {
        void AddDeposit(IDeposit deposit, IClient client);
    }
}
