using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary.DI
{
    public interface ILogger
    {
        string PathToFolder { get; set; }
        IEnumerable<IRecord> records { get; }
        IFileController FileController { get; set; }
        void AddRecord(IRecord record);
        void SaveLogs();
        void LoadLogs(string nameFile);

    }
}
