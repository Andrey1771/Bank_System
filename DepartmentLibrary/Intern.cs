using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentLibrary
{
    class Intern : Worker
    {
        decimal salaryMonth;
        public override decimal Salary { get => salaryMonth; set => salaryMonth = value; }

        public Intern(uint aId = 0, string aName = "None", uint aAge = 18, decimal asalaryMonth = 50) : base(aId, aName, aAge)
        {
            if (aName == "None") 
                Name = $"Intern_{Id}";

            salaryMonth = asalaryMonth;
        }

        public override object Clone()
        {
            var newIntern = new Intern(Id/*У нас не может содержаться 2 человека с одинаковым Id, поэтому Id будет другим*/, Name, Age);
            newIntern.Salary = Salary;
            newIntern.TotalTime = TotalTime;
            return newIntern;
        }
    }
}
