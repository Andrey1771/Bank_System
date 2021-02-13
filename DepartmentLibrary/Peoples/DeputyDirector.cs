using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentLibrary
{
    class DeputyDirector : Chief
    {
        public DeputyDirector(uint aId = 0, string aName = "None", uint aAge = 18, List<Worker> aSubordinates = null) : base(aId, aName, aAge, aSubordinates)
        {
            Name = $"DeputyDirector_{Id}";
        }
    }
}
