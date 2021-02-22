using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.DI.Client;

namespace BankLibrary.DI.BankAccounts
{
    public interface IHumanAccountCreator
    {
        IHumanAccount CreateHumanAccount(IHumanClient humanClient);
    }
}
