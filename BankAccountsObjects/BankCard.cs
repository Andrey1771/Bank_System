using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.Utilities.IdValues;
using BankLibrary.DI;
using BankLibrary.DI.FutureDatabase;

namespace BankLibrary.BankAccountsObjects
{
    public class BankCard : ICard, IValueChanged
    {

        public class BankCardEventArgs : EventArgs
        {
            public enum TypeValue
            {
                Money
            }
            public TypeValue ModifiedValue { get; private set; }
            public object OldValue { get; set; }
            public BankCardEventArgs(TypeValue modifiedValue, object oldVal)
            {
                ModifiedValue = modifiedValue;
                OldValue = oldVal;
            }
        }


        readonly static TimeSpan workingTime = TimeSpan.FromDays(365 * 4);

        public event EventHandler ValueChanged;

        public CardId CardId { get; }

        public string CardholderName { get; }
        public DateTime ValidDate { get; }
        public int SecretNumber { get; }
        private decimal money;
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
                ValueChanged?.Invoke(this, new BankCardEventArgs(BankCardEventArgs.TypeValue.Money, oldVal));
            }
        }

        public BankCard(string aCardholderName, uint abim, int aSecretNumber, DateTime aValidDate = default(DateTime))
        {
            CardholderName = aCardholderName;
            CardId.ID = abim * (ulong)Math.Pow(10, 6) + CardId.GetUniqueIndividualNumber();
            SecretNumber = aSecretNumber;
            ValidDate = aValidDate.Date;
            if (ValidDate.Date == default(DateTime).Date)
            {
                ValidDate = DateTime.Now.Date + workingTime;
            }
        }
    }
}
