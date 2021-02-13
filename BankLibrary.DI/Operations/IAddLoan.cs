using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary.DI.Operations
{
    public interface IAddLoan
    {
        void AddLoan(ILoan loan, IClient client);
    }
}
