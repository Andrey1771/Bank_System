using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentLibrary
{
    public abstract class Person
    {
        static SortedSet<uint> busyIdSortedSet;
        uint id;
        public uint Id { get { return id; } set { if (busyIdSortedSet.Add(value)) { var temp = id; id = value; busyIdSortedSet.Remove(temp); }  } }
        public string Name { get; set; }
        uint age;
        public uint Age { get { return age; } set 
            { if(value >= 14 && value < 200/*Вообще, я оптимист, может человечество победит смерть и тогда это ограничение будет только мешать :)*/)
                    age = value; } }
        abstract public decimal Salary { get; set; }

        static Person()
        {
            busyIdSortedSet = new SortedSet<uint>();
        }

        static public void clearBusyIdSortedSet()
        {
            busyIdSortedSet.Clear();
        }

        public Person(uint aId = uint.MinValue, string aName = "None", uint aAge = 18)
        {
            if(!busyIdSortedSet.Add(aId))//O(log(n))
            {
                var first = busyIdSortedSet.GetEnumerator().Current;
                aId = uint.MinValue;
                if(first == uint.MinValue)
                {
                    ++aId;
                }
                while(!busyIdSortedSet.Add(aId))//В худшем O(n * log(n)) :(((    хочу n :)
                {
                    if (aId == uint.MaxValue )
                    {
                        throw new Exception("Все плохо, newVal == uint.MaxValue");
                    }
                    ++aId;
                }
            }

            id = aId;
            Name = aName;
            Age = aAge;

        }

        ~Person()
        {
            busyIdSortedSet.Remove(Id);
        }
    }
}
