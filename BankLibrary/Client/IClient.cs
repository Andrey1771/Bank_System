﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary.Client
{
    interface IClient
    {
        string Name { get; set; }
        DateTime DateBirth { get; set; }
        string[] JobTitles { get; set; }
        decimal MonthlyIncome { get; set; }

        /*public static T GetClient<T>()
        {

        }*/
    }
}
