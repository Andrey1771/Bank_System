using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.DI;
using BankLibrary.DI.BankAccounts;
using BankLibrary.DI.Operations;
using BankLibrary.DI.Department;
using BankLibrary.Accounts;
using BankLibrary.DI.FutureDatabase;
using BankLibrary.DI.Client;

namespace BankLibrary.Departments
{
    public class LegalDepartment : Department, ILegalDepartment
    {

        public LegalDepartment(List<IBankAccount> bankAccounts = null, string aName = "LegalDepartment") : base(bankAccounts ??= new List<IBankAccount>(), aName)
        {

            
        }
        public LegalDepartment(string aName = "LegalDepartment") : this(new List<IBankAccount>(), aName)
        {

        }


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
