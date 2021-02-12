using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary.DI
{
    public interface IOperation
    {
        string Name { get; set; }
        Dictionary<string, string> NameAndDataForAction { get; set; }

    }
}
