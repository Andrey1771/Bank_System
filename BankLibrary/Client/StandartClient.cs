using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.DI;
using BankLibrary.FutureDatabase;
using BankLibrary.DI.BankAccounts;

namespace BankLibrary.Client
{
    class StandartClient : ClientAbstract, IHumanClient
    {
        public DateTime DateBirth { get; set; }
        public string[] JobTitles { get; set; }
        public decimal MonthlyIncome { get; set; }

        public override IBankAccount MakeAccount()
        {
            return new BankAccountHuman(this);//TODO это фабрика? Даже если не так, то можно до нее расширить, вроде
        }
    }
}
