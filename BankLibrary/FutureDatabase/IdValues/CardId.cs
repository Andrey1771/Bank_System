using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary.FutureDatabase.IdValues
{
    class CardId : ValueID
    {
        const uint maxIndividualNumber = 100_000_000;
        private static SortedSet<ulong> bussyIdSortedSet;

        public CardId(uint aid) : base(aid)
        {
        }

        protected override ref SortedSet<ulong> GetRefBusyIdSortedSet()
        {
            return ref bussyIdSortedSet;
        }

        public static uint GetUniqueIndividualNumber()
        {
            return ValueID.GetUniqueIndividualNumber(bussyIdSortedSet, maxIndividualNumber);
        }
    }
}
