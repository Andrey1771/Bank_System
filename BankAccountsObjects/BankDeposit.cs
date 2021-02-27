using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.Utilities.IdValues;
using BankLibrary.DI;
using BankLibrary.DI.FutureDatabase;

namespace BankLibrary.BankAccountsObjects
{
    public class BankDeposit : IDeposit, IValueChanged
    {
        public class BankDepositEventArgs : EventArgs
        {
            public enum TypeValue
            {
                Money, ProcentDeposit
            }
            public TypeValue ModifiedValue { get; private set; }
            public object OldValue { get; private set; }
            public BankDepositEventArgs(TypeValue modifiedValue, object oldValue)
            {
                ModifiedValue = modifiedValue;
                OldValue = oldValue;
            }
        }

        public DepositId DepositId { get; }

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
                ValueChanged?.Invoke(this, new BankDepositEventArgs(BankDepositEventArgs.TypeValue.Money, oldVal));
            }
        }

        decimal procentDeposit;

        public event EventHandler ValueChanged;

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

                var oldVal = procentDeposit;
                procentDeposit = value;
                ValueChanged?.Invoke(this, new BankDepositEventArgs(BankDepositEventArgs.TypeValue.ProcentDeposit, oldVal));
            }
        }

        public BankDeposit(string aOwnerName, decimal aprocentDeposit, DateTime aClosingDate, DateTime aOpeningDate = default(DateTime))
        {
            OwnerName = aOwnerName;
            DepositId.ID = DepositId.GetUniqueIndividualNumber();
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
