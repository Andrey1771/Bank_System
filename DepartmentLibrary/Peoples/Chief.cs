using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using BankLibrary.DI;

namespace DepartmentLibrary
{
    public abstract class Chief : Person, IEnumerable, IChief
    {

        const decimal MinPayroll = 1300;
        decimal procentPayroll = (decimal)0.15;
        public List<Worker> subordinates;
        public ICollection<IWorker> Subordinates {
            get
            {
                return (ICollection<IWorker>)subordinates;//TODO 
            }
        }

        decimal allEarnedMoney = 0;
        public override decimal Salary { get => allEarnedMoney; set => procentPayroll = value; }

        public Chief(uint aId = uint.MinValue, string aName = "None", uint aAge = 18, List<Worker> aSubordinates = null) : base(aId, aName, aAge)
        {
            subordinates = aSubordinates ?? new List<Worker>();
        }

        public virtual void Manage()
        {
            //Они же ничего не делают xd
        }

        public virtual void MonthPassed()
        {
            allEarnedMoney = Payroll();
        }

        private decimal Payroll()
        {
            decimal pay = 0;
            foreach(var worker in subordinates) {
                pay += worker.Salary * procentPayroll;
            }

            if (pay < MinPayroll) {
                pay = MinPayroll;
            }

            return pay;
        }

        public virtual void MakeSomeWorkers()
        {
            var rand = new Random();
            uint count = (uint)rand.Next(3, 10);
            for (uint i = 0; i < count; ++i)
            {
                switch (rand.Next(1, 3))
                {
                    case 1:
                        subordinates.Add(new Intern());
                        break;

                    case 2:
                        subordinates.Add(new Employee());
                        break;

                    default: Console.WriteLine("Error MakeSomeWorkers"); return;
                }
            }
        }

        public IEnumerator GetEnumerator()//Так не интересно 
        {
            return ((IEnumerable)subordinates).GetEnumerator();
        }
    }
}
