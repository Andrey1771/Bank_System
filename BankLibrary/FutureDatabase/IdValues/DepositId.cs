using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary.FutureDatabase.IdValues
{
    class DepositId : ValueID
    {
        const uint maxIdValue = uint.MaxValue;
        private static SortedSet<ulong> bussyIdSortedSet;

        public DepositId(uint aid) : base(aid)
        {
        }

        protected override ref SortedSet<ulong> GetRefBusyIdSortedSet()
        {
            return ref bussyIdSortedSet;
        }

        public static uint GetUniqueIndividualNumber()
        {
            return ValueID.GetUniqueIndividualNumber(bussyIdSortedSet, maxIdValue);
        }
    }
}
