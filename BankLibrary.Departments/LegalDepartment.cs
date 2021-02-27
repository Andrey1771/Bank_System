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

        public LegalDepartment() : base(new List<IBankAccount>(), "LegalDepartment")
        {
            
        }

        public bool AddDeposit(IDeposit deposit, IClient client)
        {
            IOrganizationAccount account;
            if (FindCastToOrganizationAccount(client, out account))
            {
                account.AddDeposit(deposit);
                return true;
            }
            return false;
        }

        public bool AddLoan(ILoan loan, IClient client)
        {
            IOrganizationAccount account;
            if (FindCastToOrganizationAccount(client, out account))
            {
                account.AddLoan(loan);
                return true;
            }
            return false;
        }

        private bool FindCastToOrganizationAccount(IClient client, out IOrganizationAccount findedAccount)//TODO Разделить логику
        {
            findedAccount = null;
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
                    findedAccount = iOrganizationAccount;
                    return true;
                }
            }

            return false;
        }
    }


}
