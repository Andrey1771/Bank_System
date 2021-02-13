using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary.DI.Operations
{
    public interface IAddDeposit
    {
        void AddDeposit(IDeposit deposit, IClient client);
    }
}
