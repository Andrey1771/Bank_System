using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.DI.BankAccounts;
using BankLibrary.DI.Client;

namespace BankLibrary.Accounts
{
    public class BankAccountHumanCreator : IHumanAccountCreator
    {
        public IHumanAccount CreateHumanAccount(IHumanClient humanClient)
        {
            return new BankAccountHuman(humanClient);
        }
    }
}
