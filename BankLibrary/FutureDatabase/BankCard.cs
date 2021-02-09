using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.Client;

namespace BankLibrary.FutureDatabase
{
    class BankCard 
    {
        static SortedSet<ulong> busyIdSortedSet;

        ulong id;
        public ulong ID { get { return id; }
            set
            {
                if (!TryAddId(value))
                    throw new Exception("Все плохо, newVal == uint.MaxValue");
                id = value;
            }
        }

        public string CardholderName { get; }
        public DateTime ValidDate { get; }
        public int SecretNumber { get; }


        public BankCard(string aCardholderName, uint abim, uint individualNumber, int aSecretNumber, DateTime aValidDate = default(DateTime))
        {
            CardholderName = aCardholderName;
            ID = abim * (ulong)Math.Pow(10, 6) + individualNumber;
            SecretNumber = aSecretNumber;
            ValidDate = aValidDate.Date;
            if (aValidDate == default(DateTime))
            {
                ValidDate = DateTime.Now.Date;
            }
            
        }

        public bool TryAddId(ulong id)
        {
            if (!busyIdSortedSet.Add(id))//SortedSet.Add - O(log(k))
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
            }
            return true;
        }

        public static uint GetUniqueIndividualNumber(uint bim)
        {
            var newIndividualNumber = uint.MinValue;
            while (!busyIdSortedSet.Add(newIndividualNumber))//В худшем O(n * log(n))
            {
                if (newIndividualNumber == 100_000_000)
                {
                    throw new Exception("Все ключи заняты, newIndividualNumber == 100_000_000");//Добавить тесты
                }
                ++newIndividualNumber;
            }

            return newIndividualNumber;
        }

        ~BankCard()
        {
            busyIdSortedSet.Remove(ID); ;
        }
    }
}
