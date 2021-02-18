using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.DI;
using BankLibrary.DI.Operations;
using BankLibrary.DI.BankAccounts;
using BankLibrary.DI.Department;

namespace BankLibrary.Departments
{
    public class StandartDepartment : HumanDepartment, IStandartDepartment
    {
        public StandartDepartment(List<IBankAccount> bankAccounts = null, string aName = "StandartDepartment") : base(bankAccounts ??= new List<IBankAccount>(), aName)
        {

        }

        public StandartDepartment(string aName = "StandartDepartment") : this(new List<IBankAccount>(), aName)
        {

        }
    }
}
