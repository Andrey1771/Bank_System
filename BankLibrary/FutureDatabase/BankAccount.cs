using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.Client;
namespace BankLibrary.FutureDatabase
{
    class BankAccount
    {
        IClient client;
        List<BankCard> bankCards;
        List<BankDeposit> bankDeposits;
        List<BankLoan> bankLoans;


        decimal Money
        {
            get
            {

            }
        }
    }
}
