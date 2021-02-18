using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary.DI.Client
{
    public interface IHumanClient : IClient
    {
        DateTime DateBirth { get; set; }
        string[] JobTitles { get; set; }
        decimal MonthlyIncome { get; set; }

    }
}
