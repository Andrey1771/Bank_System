using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentLibrary
{
    public class Director : Chief
    {
        private new List<Worker> Subordinates = null;
        public Director(uint aId = 0, string aName = "None", uint aAge = 18, List<Worker> aSubordinates = null) : base(aId, aName, aAge, aSubordinates)
        {
            Name = $"Director_{Id}";
        }

        public override void MakeSomeWorkers()
        {
            //base.MakeSomeWorkers();
        }
        
    }
}
