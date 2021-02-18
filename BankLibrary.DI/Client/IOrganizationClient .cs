using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary.DI.Client
{
    public interface IOrganizationClient : IClient
    {
        DateTime FoundationDate { get; set; }
        decimal Income { get; set; } 
        string NameOwner { get; set; }
    }
}
