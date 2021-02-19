using System;
using System.Collections.Generic;
using System.Text;
using BankLibrary.DI;
using BankLibrary.DI.Logger;

namespace BankLibrary.Logger
{
    public class Logger : ILogger
    {
        public string NameFile { get; set; }
        public string PathToFolder { get; set; }//TODO Добавить проверку на существования папки
        public ICollection<IRecord> Records { get; private set; }

        public IFileController<IRecord> FileController { get; set; }

        public void AddRecord(IRecord record)
        {
            Records.Add(record);//TODO добавить проверки или перенести в авто
        }

        public void LoadLogs()
        {
            Records = FileController.Load($@"{PathToFolder}\{NameFile}");
        }

        public void SaveLogs()
        {
            FileController.Save(Records, $@"{PathToFolder}\{NameFile}");
        }
    }
}
