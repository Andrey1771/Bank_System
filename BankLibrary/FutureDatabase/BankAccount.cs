using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.Client;
namespace BankLibrary.FutureDatabase
{
    class BankAccount
    {
        readonly IClient client;
        List<BankCard> bankCards;
        List<BankDeposit> bankDeposits;
        List<BankLoan> bankLoans;

        public string Name { get { return client.Name; } }
        public decimal Money
        {
            get
            {
                decimal allMoney = 0;
                foreach(var card in bankCards)
                {
                    allMoney += card.Money;
                }
                foreach (var deposit in bankDeposits)
                {
                    allMoney += deposit.Money;
                }
                return allMoney;
            }
        }

        public void AddCard(uint bim, int secretNumber, DateTime validDate = default(DateTime))
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

        public void AddLoans(decimal procentDeposit,
            DateTime closingDate, DateTime openingDate = default(DateTime))
        {
            var newLoan = new BankLoan(client.Name, procentDeposit, closingDate, openingDate);
            bankLoans.Add(newLoan);
        }
    }
}
