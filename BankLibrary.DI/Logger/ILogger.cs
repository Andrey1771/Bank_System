using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary.DI.Logger
{
    public interface ILogger
    {
        string NameFile { get; set; }
        string PathToFolder { get; set; }
        ICollection<IRecord> Records { get; }
        IFileController<IRecord> FileController { get; set; }
        void AddRecord(IRecord record);
        void SaveLogs();
        void LoadLogs();

    }
}
