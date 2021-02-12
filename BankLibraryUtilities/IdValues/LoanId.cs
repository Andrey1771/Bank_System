using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary.Utilities.IdValues
{
    public class LoanId : ValueID
    {
        const uint maxLoanIdNumber = uint.MaxValue;
        private static SortedSet<ulong> bussyIdSortedSet;

        public LoanId(uint aid) : base(aid)
        {
        }

        protected override ref SortedSet<ulong> GetRefBusyIdSortedSet()
        {
            return ref bussyIdSortedSet;
        }

        public static uint GetUniqueIndividualNumber()
        {
            return ValueID.GetUniqueIndividualNumber(bussyIdSortedSet, maxLoanIdNumber);
        }
    }
}
