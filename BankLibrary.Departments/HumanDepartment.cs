using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.DI;
using BankLibrary.DI.BankAccounts;
using BankLibrary.DI.Operations;
using BankLibrary.Accounts;
using BankLibrary.DI.Client;
using BankLibrary.DI.FutureDatabase;


namespace BankLibrary.Departments
{
    public abstract class HumanDepartment : Department, IAddCard, IAddDeposit, IAddLoan
    {
        public HumanDepartment(ICollection<IBankAccount> aAccounts, string aName = "HumanDepartment") : base(aAccounts, aName)
        {

        }

        public virtual bool AddCard(ICard card, IClient client)
        {
            IHumanAccount account; 
            if (FindCastToHumanAccount(client, out account))
            {
                account.AddCard(card);
                return true;
            }
            return false;
        }

        public virtual bool AddDeposit(IDeposit deposit, IClient client)
        {
            IHumanAccount account;
            if (FindCastToHumanAccount(client, out account))
            {
                account.AddDeposit(deposit);
                return true;
            }
            return false;
        }

        public virtual bool AddLoan(ILoan loan, IClient client)
        {
            IHumanAccount account;

            if(FindCastToHumanAccount(client, out account))
            {
                account.AddLoan(loan);
                return true;
            }
            return false;
        }

        protected virtual bool FindCastToHumanAccount(IClient client, out IHumanAccount findedAccount)//TODO разделить логику
        {
            findedAccount = null;
            IBankAccount iBankAccount = null;

            if (FindClientAccount(client, out iBankAccount))
            {
                IHumanAccount iHumanAccount = null;
                if ((iHumanAccount = (iBankAccount as IHumanAccount)) == null)
                {
                    throw new NullReferenceException("Ошибка, не удалось привести найденный аккаунт к IHumanAccount");
                }
                else
                {
                    findedAccount = iHumanAccount;
                    return true;
                }
            }

            return false;
        }
    }
}
