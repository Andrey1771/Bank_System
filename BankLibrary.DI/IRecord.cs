using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary.DI
{
    public interface IRecord
    {
        IOperation Operation { get; set; }
        DateTime DateRecord { get; set; }
        IClient Client { get; set; }
    }

}
