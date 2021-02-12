using System;
using System.Collections.Generic;
using BankLibrary.DI;

namespace DepartmentLibrary
{
    public class Department : IDepartment
    {
        static SortedSet<string> busyNameSortedSet;
        string name;
        public string Name { get { return name; } set { if (busyNameSortedSet.Add(value)) { var temp = name; name = value; busyNameSortedSet.Remove(temp); } } }
        public int CountWorkers { get { return Chief.Subordinates.Count + 1; } }

        private IChief chief;
        public IChief Chief { 
            get
            { 
                return chief;
            }
            set 
            {
                chief = value;
            } 
        }

        //List<Person> persons;
        List<Department> departments;
        public IEnumerable<IDepartment> Departments { get { return departments; } set { departments = value; } }

        static Department()
        {
            busyNameSortedSet = new SortedSet<string>();
        }

        ~Department()
        {
            busyNameSortedSet.Remove(name);
        }


        public static void ClearBusyNameSortedSet()//Bad
        {
            busyNameSortedSet.Clear();
        }

        public Department(string aname, Chief achief, List<Department> adepartments = null)
        {
            if (!busyNameSortedSet.Add(aname))//O(log(n))
            {
                while (!busyNameSortedSet.Add(Utilities.RandomString(16))) ;//В худшем O(n * log(n)) :(((    хочу n :)
            }
            Chief = achief;
            departments = adepartments ?? new List<Department>();
            Name = aname;
        }

        public void MakeSomeDepartment(int number)
        {
            var rand = new Random();
            uint count = (uint)rand.Next(0, 2);
            Name = Utilities.RandomString(16);
            for (uint i = 0; i < count; ++i)
            {
                Chief newChief = null;
                switch (number)
                {
                    case 0:
                        newChief = new DeputyDirector((uint)rand.Next(0, int.MaxValue/*и так пойдет*/), Utilities.RandomString(3), (uint)rand.Next(18, 110));
                        break;
                    case 1:
                        newChief = new HeadDepartment((uint)rand.Next(0, int.MaxValue/*и так пойдет*/), Utilities.RandomString(16), (uint)rand.Next(18, 110));
                        break;

                }
                newChief.MakeSomeWorkers();
                departments.Add(new Department(Utilities.RandomString(16),
                    newChief, new List<Department>()));
                departments[departments.Count - 1].MakeSomeDepartment(1);
            }

        }
    }
}
