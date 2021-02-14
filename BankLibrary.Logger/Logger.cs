using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.DI;


namespace BankLibrary.Logger
{
    public class Logger : ILogger
    {
        public string PathToFolder { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IEnumerable<IRecord> records => throw new NotImplementedException();

        public IFileController FileController { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void AddRecord(IRecord record)
        {
            throw new NotImplementedException();
        }

        public void LoadLogs(string nameFile)
        {
            throw new NotImplementedException();
        }

        public void SaveLogs()
        {
            throw new NotImplementedException();
        }
    }
}
