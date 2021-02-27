using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.Utilities.IdValues;
using BankLibrary.DI;
using BankLibrary.DI.FutureDatabase;

namespace BankLibrary.BankAccountsObjects
{
    public class BankLoan : ILoan, IValueChanged
    {
        public class BankLoanEventArgs : EventArgs
        {
            public enum TypeValue
            {
                Money, ProcentLoan
            }
            public TypeValue ModifiedValue { get; private set; }
            public object OldValue { get; private set; }
            public BankLoanEventArgs(TypeValue modifiedValue, object oldValue)
            {
                ModifiedValue = modifiedValue;
                OldValue = oldValue;
            }
        }

        public LoanId LoanId { get; }

        public string OwnerName { get; }
        public DateTime OpeningDate { get; }
        public DateTime ClosingDate { get; }

        decimal money;
        public decimal Money 
        { 
            get
            {
                return money;
            }
            set
            {
                var oldVal = money;
                money = value;
                ValueChanged?.Invoke(this, new BankLoanEventArgs(BankLoanEventArgs.TypeValue.Money, oldVal));
            }
        }

        decimal procentLoan;

        public event EventHandler ValueChanged;

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

                var oldValue = procentLoan;
                procentLoan = value;

                ValueChanged?.Invoke(this, new BankLoanEventArgs(BankLoanEventArgs.TypeValue.ProcentLoan, oldValue));
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
