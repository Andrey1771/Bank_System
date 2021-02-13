﻿using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.DI;
using BankLibrary.DI.BankAccounts;

namespace BankLibrary.Client
{
    abstract class ClientAbstract : IClient
    {
        public string Name { get; set; }

        public abstract IBankAccount MakeAccount();
    }
}
