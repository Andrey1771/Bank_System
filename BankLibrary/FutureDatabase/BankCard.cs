using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.Client;

namespace BankLibrary.FutureDatabase
{
    class BankCard
    {
        ulong id;
        public ulong ID { get { return id; } private set { id = value; } }
        string name;
        public string CardholderName { get { return name; } }
        public DateTime ValidDate { get; }
        public int SecretNumber { get; }

        public BankCard(string aName, uint bim, uint individualNumber, int aSecretNumber, DateTime aValidDate = default(DateTime))
        {
            name = aName;
            ID = bim * (ulong)Math.Pow(10, 6) + individualNumber;
            SecretNumber = aSecretNumber;
            ValidDate = aValidDate.Date;
            if (aValidDate == default(DateTime))
            {
                ValidDate = DateTime.Now.Date;
            }

        }
    }
}
