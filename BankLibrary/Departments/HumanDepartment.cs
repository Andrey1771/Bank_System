using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.DI;
using BankLibrary.DI.BankAccounts;
using BankLibrary.DI.Operations;

namespace BankLibrary.Departments
{
    public abstract class HumanDepartment : Department, IAddCard, IAddDeposit, IAddLoan
    {
        public virtual void AddCard(ICard card, IClient client)
        {
            FindCastToHumanAccount(client).AddCard(card);
        }

        public virtual void AddDeposit(IDeposit deposit, IClient client)
        {
            FindCastToHumanAccount(client).AddDeposit(deposit);
        }

        public virtual void AddLoan(ILoan loan, IClient client)
        {
            FindCastToHumanAccount(client).AddLoan(loan);
        }

        protected virtual IHumanAccount FindCastToHumanAccount(IClient client)//TODO разделить логику
        {
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
                    return iHumanAccount;
                }
            }
            else
            {
                throw new ArgumentException("Ошибка, не удалось найти данного пользователя");
            }
        }
    }
}
