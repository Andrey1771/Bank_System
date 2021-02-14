using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.DI;
using BankLibrary.DI.BankAccounts;
using BankLibrary.DI.FutureDatabase;
using BankLibrary.DI.Client;

namespace BankLibrary.Accounts
{
    public class BankAccountHuman : BankAccount, IHumanAccount
    {
        List<ICard> bankCards;
        List<IDeposit> bankDeposits;
        List<ILoan> bankLoans;

         public override decimal Money
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

        public override decimal Debt 
        {
            get
            {
                decimal allMoney = 0;
                foreach (var loans in bankLoans)
                {
                    allMoney += loans.Money;
                }
                return allMoney;
            }
        }

        public BankAccountHuman(IClient client) : base(client)
        {

        }

        public void AddCard(ICard card)
        {
            if(!bankCards.Contains(card))//TODO Добавить проверку на наличие пользователя
            {
                bankCards.Add(card);
            }
        }

        public void AddDeposit(IDeposit deposit)
        {
            if (!bankDeposits.Contains(deposit))//TODO Добавить проверку на наличие пользователя
            {
                bankDeposits.Add(deposit);
            }
        }

        public void AddLoan(ILoan loan)
        {
            if (!bankLoans.Contains(loan))//TODO Добавить проверку на наличие пользователя
            {
                bankLoans.Add(loan);
            }
        }
    }
}
