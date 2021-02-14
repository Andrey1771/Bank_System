using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.Utilities.IdValues;

namespace BankLibrary.DI.FutureDatabase
{
    public interface ICard
    {
        CardId CardId { get; }
        decimal Money { get; set; }
    }
}
