using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary.Recording
{
    interface IOperation
    {
        string Name { get; set; }
        Dictionary<string, string> NameAndDataForAction { get; set; }
    }
}
