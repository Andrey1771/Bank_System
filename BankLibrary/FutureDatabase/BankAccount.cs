using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.Client;
using BankLibrary.DI;
using BankLibrary.Utilities.IdValues;
using BankLibrary.DI.BankAccounts;

namespace BankLibrary.FutureDatabase
{
    abstract class BankAccount : IBankAccount
    {
        protected readonly IClient client;

        public string Name { get { return client.Name; } }

        public abstract decimal Money { get; }
        public abstract decimal Debt { get; }

        public BankAccount(IClient aclient)
        {
            client = aclient;
        }

       /* public void AddCard(uint bim, int secretNumber, DateTime validDate = default(DateTime))
        {
            var newCard = new BankCard(client.Name, bim, secretNumber, validDate);
            bankCards.Add(newCard);
        }

        public void AddDeposit(decimal procentDeposit, int secretNumber,
            DateTime closingDate, DateTime openingDate = default(DateTime))
        {
            var newDeposit = new BankDeposit(client.Name, procentDeposit, closingDate, openingDate);
            bankDeposits.Add(newDeposit);
        }

        public void AddLoan(decimal procentDeposit,
            DateTime closingDate, DateTime openingDate = default(DateTime))
        {
            var newLoan = new BankLoan(client.Name, procentDeposit, closingDate, openingDate);
            bankLoans.Add(newLoan);
        }*/

    }
}
