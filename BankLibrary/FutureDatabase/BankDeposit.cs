using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.FutureDatabase.IdValues;

namespace BankLibrary.FutureDatabase
{
    class BankDeposit
    {
        public DepositId BankId { get; }

        public string OwnerName { get; }
        public DateTime OpeningDate { get; }
        public DateTime ClosingDate { get; }
        public decimal Money { get; set; }

        decimal procentDeposit;
        public decimal ProcentDeposit 
        {
            get
            {
                return procentDeposit;
            }
            set
            {
                if (procentDeposit < 0)
                    value = 0;

                procentDeposit = value;
            }

        }

        public BankDeposit(string aOwnerName, decimal aprocentDeposit, DateTime aClosingDate, DateTime aOpeningDate = default(DateTime))
        {
            OwnerName = aOwnerName;
            BankId.ID = DepositId.GetUniqueIndividualNumber();
            ProcentDeposit = aprocentDeposit;
            ClosingDate = aClosingDate.Date;
            OpeningDate = aOpeningDate.Date;
            if (OpeningDate.Date == default(DateTime).Date)
            {
                OpeningDate = DateTime.Now.Date;
            }

        }
    }
}
