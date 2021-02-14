using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.DI.Operations;

namespace BankLibrary.DI.Department
{
    public interface IVipDepartment : IDepartment, IAddCard, IAddDeposit, IAddLoan
    {
    }
}
