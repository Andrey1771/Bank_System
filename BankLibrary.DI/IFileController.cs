using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary.DI
{
    public interface IFileController
    {
        void Save(ICollection<IOperation> data, string path);
        ICollection<IOperation> Load(string path);
    }
}
