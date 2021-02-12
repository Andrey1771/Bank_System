using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentLibrary
{
    class Employee : Worker
    {
        decimal salary;

        /// <summary>
        /// Возвращает зарплату за месяц, а устанавливает почасовую ставку
        /// </summary>
        public override decimal Salary { get => TotalTime * salary; set => salary = value; }

        public Employee(uint aId = 0, string aName = "None", uint aAge = 18, decimal asalary = 100) : base(aId, aName, aAge)
        {
            if (aName == "None") 
                Name = $"Employee_{Id}";

            salary = asalary;
        }

        public override object Clone()
        {
            var newEmployee = new Employee(Id/*У нас не может содержаться 2 человека с одинаковым Id, поэтому Id будет другим*/, Name, Age);
            newEmployee.Salary = Salary;
            newEmployee.TotalTime = TotalTime;
            return newEmployee;
        }
    }
}
