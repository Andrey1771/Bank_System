using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.DI;
using BankLibrary.Accounts;
using BankLibrary.DI.BankAccounts;
using BankLibrary.DI.Client;

namespace BankLibrary.Client
{
    public class VIPClient : ClientAbstract, IVipClient
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
