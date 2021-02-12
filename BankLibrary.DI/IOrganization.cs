using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary.DI
{
    public interface IOrganization
    {
        string Name { get; set; }
        DateTime FoundationDate { get; set; }
        decimal Income { get; set; } 
        string NameOwner { get; set; }
    }
}
