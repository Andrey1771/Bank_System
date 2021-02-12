using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary.Utilities.IdValues
{
    public abstract class ValueID //: IIDValue
    {
        //protected abstract SortedSet<ulong> BusyIdSortedSet { get; set; }
        protected abstract ref SortedSet<ulong> GetRefBusyIdSortedSet();

        ulong id;
        public ulong ID
        {
            get { return id; }
            set
            {
                if (!TryAddId(value, this))
                    throw new Exception("Все плохо, newVal == uint.MaxValue");
            }
        }

        public ValueID(uint aid)
        {
            if (!TryAddId(aid, this))
                throw new Exception("Все плохо, newVal == uint.MaxValue");
        }

        public static bool TryAddId(ulong inId, ValueID valueID)
        {
            var busyIdSortedSet = valueID.GetRefBusyIdSortedSet();
            if (!busyIdSortedSet.Add(inId))//SortedSet.Add - O(log(k))
            {
                var newId = ulong.MinValue;
                while (!busyIdSortedSet.Add(newId))//В худшем O(n * log(n)) 
                {
                    if (newId == ulong.MaxValue)
                    {
                        return false;
                    }
                    ++newId;
                }
                inId = newId;
            }
            var oldId = valueID.id;
            busyIdSortedSet.Remove(oldId);
            valueID.id = inId;
            return true;
        }

        protected static uint GetUniqueIndividualNumber(SortedSet<ulong> BusyIdSortedSet, uint maxNumberValue)
        {
            var newIndividualNumber = uint.MinValue;
            while (!BusyIdSortedSet.Add(newIndividualNumber))//В худшем O(n * log(n))
            {
                if (newIndividualNumber == maxNumberValue)
                {
                    throw new Exception($"Все ключи заняты, newIndividualNumber == {maxNumberValue}");//Добавить тесты
                }
                ++newIndividualNumber;
            }
            BusyIdSortedSet.Remove(newIndividualNumber);

            return newIndividualNumber;
        }
    }
}
