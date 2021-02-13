using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.DI;

namespace DepartmentLibrary
{

    public class WorkerComparer : IComparer<Worker>
    {
        public int Compare(Worker x, Worker y)
        {
            return x.CompareTo(y);
        }
    }


    public abstract class Worker : Person, IWorker, IEquatable<Worker>, IComparable, IComparable<uint>, IComparable<Worker>, ICloneable
    {
        public uint TotalTime { get; protected set; }

        protected Worker(uint aId = 0, string aName = "None", uint aAge = 18) : base(aId, aName, aAge)
        {
        }

        public virtual void Work(uint time)
        {
            TotalTime += time;
        }

        public void MonthPassed()
        {
            TotalTime = 0;
        }

        public bool Equals(Worker other)
        {
            if (other == null)
                return false;

            var otherTuple = (other.Id, other.Name, other.Age, other.Salary, other.TotalTime);
            var thisTuple = (Id, Name, Age, Salary, TotalTime);
            return otherTuple.Equals(thisTuple);
        }

        public int CompareTo(object obj)
        {
            Worker workerRight = obj as Worker;
            if (workerRight == null)
                throw new Exception("Невозможно сравнить два объекта в Worker");
            return CompareTo(workerRight);
            
        }

        public int CompareTo(uint other)
        {
            return Id.CompareTo(other);
        }

        public int CompareTo(Worker other)
        {
            switch (Id.CompareTo(other.Id))
            {
                case 1: return 1;
                case -1: return -1;
            }
            switch (Name.CompareTo(other.Name))
            {
                case 1: return 1;
                case -1: return -1;
            }
            switch (Age.CompareTo(other.Age))
            {
                case 1: return 1;
                case -1: return -1;
            }
            switch (Salary.CompareTo(other.Salary))
            {
                case 1: return 1;
                case -1: return -1;
            }
            switch (TotalTime.CompareTo(other.TotalTime))
            {
                case 1: return 1;
                case -1: return -1;
            }
            return 0;
        }

        public abstract object Clone();
    }
}
