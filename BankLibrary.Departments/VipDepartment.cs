using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.DI;
using BankLibrary.DI.Operations;
using BankLibrary.DI.Department;
using BankLibrary.DI.BankAccounts;

namespace BankLibrary.Departments
{
    public class VipDepartment : HumanDepartment, IVipDepartment
    {
        public VipDepartment(List<IBankAccount> bankAccounts = null, string aName = "VipDepartment") : base(bankAccounts ??= new List<IBankAccount>(), aName)
        {

        }
    }
}
