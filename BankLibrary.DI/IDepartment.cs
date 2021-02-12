using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary.DI
{
    public interface IDepartment
    {
        string Name { get; set; } 
        int CountWorkers { get; }

        IChief Chief { get; set; }

        IEnumerable<IDepartment> Departments { get; set; }

    }
}
