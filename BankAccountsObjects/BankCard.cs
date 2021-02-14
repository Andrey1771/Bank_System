using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.Utilities.IdValues;
using BankLibrary.DI;
using BankLibrary.DI.FutureDatabase;

namespace BankLibrary.BankAccountsObjects
{
    public class BankCard : ICard
    {
        readonly static TimeSpan workingTime = TimeSpan.FromDays(365 * 4);
        public CardId CardId { get; }

        public string CardholderName { get; }
        public DateTime ValidDate { get; }
        public int SecretNumber { get; }
        public decimal Money { get; set; }

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
