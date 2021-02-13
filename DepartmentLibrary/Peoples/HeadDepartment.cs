using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentLibrary
{
    class HeadDepartment : Chief
    {
        public HeadDepartment(uint aId = 0, string aName = "None", uint aAge = 18, List<Worker> aSubordinates = null) : base(aId, aName, aAge, aSubordinates)
        {
            Name = $"HeadDepartment_{Id}";
        }
    }
}
