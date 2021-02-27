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
        public VipDepartment() : base(new List<IBankAccount>(), "VipDepartment")
        {

        }
    }
}
