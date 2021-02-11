using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.Client;

namespace BankLibrary.Recording
{
    interface IRecord
    {
        IOperation Operation { get; set; }
        DateTime DateOperation { get; set; }
        IClient Client { get; set; }
    }

}
