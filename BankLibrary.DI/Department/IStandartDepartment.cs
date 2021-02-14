using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.DI.Operations;

namespace BankLibrary.DI.Department
{
    public interface IStandartDepartment : IDepartment, IAddCard, IAddDeposit, IAddLoan
    {
    }
}
