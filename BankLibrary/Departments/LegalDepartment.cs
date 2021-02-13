using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.DI;
using BankLibrary.DI.BankAccounts;
using BankLibrary.DI.Operations;

namespace BankLibrary.Departments
{
    public class LegalDepartment : Department, IAddDeposit, IAddLoan
    {
        public void AddDeposit(IDeposit deposit, IClient client)
        {
            FindCastToOrganizationAccount(client).AddDeposit(deposit);
        }

        public void AddLoan(ILoan loan, IClient client)
        {
            FindCastToOrganizationAccount(client).AddLoan(loan);
        }

        private IOrganizationAccount FindCastToOrganizationAccount(IClient client)//TODO Разделить логику
        {
            IBankAccount iBankAccount = null;
            if (FindClientAccount(client, out iBankAccount))
            {
                IOrganizationAccount iOrganizationAccount = null;
                if ((iOrganizationAccount = (iBankAccount as IOrganizationAccount)) == null)
                {
                    throw new NullReferenceException("Ошибка, не удалось привести найденный аккаунт к IOrganizationAccount");
                }
                else
                {
                    return iOrganizationAccount;
                }
            }
            else
            {
                throw new ArgumentException("Ошибка, не удалось найти данного пользователя");
            }
        }
    }


}
