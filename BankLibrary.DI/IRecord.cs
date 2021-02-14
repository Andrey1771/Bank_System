using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.DI.Client;

namespace BankLibrary.DI
{
    public interface IRecord
    {
        IOperation Operation { get; set; }
        DateTime DateRecord { get; set; }
        IClient Client { get; set; }
    }

}
