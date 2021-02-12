using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.Utilities.IdValues;
using BankLibrary.DI;

namespace BankLibrary.FutureDatabase
{
    class BankLoan : ILoan
    {

        public LoanId LoanId { get; set; }
        public string OwnerName { get; }
        public DateTime OpeningDate { get; }
        public DateTime ClosingDate { get; }
        public decimal Money { get; set; }

        decimal procentLoan;
        public decimal ProcentLoan
        {
            get
            {
                return procentLoan;
            }
            set
            {
                if (procentLoan < 0)
                    value = 0;

                procentLoan = value;
            }

        }

        public BankLoan(string aOwnerName, decimal aProcentLoan, DateTime aClosingDate, DateTime aOpeningDate = default(DateTime))
        {
            OwnerName = aOwnerName;
            LoanId.ID = LoanId.GetUniqueIndividualNumber();
            ProcentLoan = aProcentLoan;
            ClosingDate = aClosingDate.Date;
            OpeningDate = aOpeningDate.Date;
            if (OpeningDate.Date == default(DateTime).Date)
            {
                OpeningDate = DateTime.Now.Date;
            }

        }
    }
}
