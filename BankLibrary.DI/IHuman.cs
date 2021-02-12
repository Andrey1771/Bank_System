using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary.DI
{
    public interface IHuman
    {
        string Name { get; set; }
        DateTime DateBirth { get; set; }
        string[] JobTitles { get; set; }
        decimal MonthlyIncome { get; set; }

    }
}
