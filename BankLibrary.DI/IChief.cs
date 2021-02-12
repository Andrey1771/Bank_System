using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary.DI
{
    public interface IChief
    {
        ICollection<IWorker> Subordinates { get; }

        decimal Salary { get; set; }
    }
}
