using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.DI.Client;
using BankLibrary.DI.BankAccounts;
using BankLibrary.DI.Logger;
using BankLibrary.DI;
using BankLibrary.DI.Department;
using BankLibrary.DI.FutureDatabase;

namespace BankLibrary.DI
{

    public interface IBank 
    {
        ICollection<IClient> Clients { get; }
        ICollection<IBankAccount> Accounts { get; }
        ICollection<ILoan> Loans { get; }
        ICollection<IDeposit> Deposits { get; }
        ICollection<ICard> Cards { get; }

        ILogger Logger { get; set; }
        //IFileController<> FileController { get; set; }//TODO Добавить реализацию для данных

        IClient GetClient(uint id);
        IBankAccount GetAccount(IClient client);

        bool AddCardToClientInDepartment(ICard card, IClient client);
        bool AddLoanToClientInDepartment(ILoan loan, IClient client);
        bool AddDepositToClientInDepartment(IDeposit deposit, IClient client);



    }
}
