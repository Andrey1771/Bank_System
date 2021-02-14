using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.DI.Operations;

namespace BankLibrary.DI.Department
{
    public interface ILegalDepartment : IDepartment, IAddDeposit, IAddLoan
    {
    }
}
