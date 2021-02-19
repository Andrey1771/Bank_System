using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary.DI
{
    public interface IFileController <T>
    {
        void Save(ICollection<T> data, string path);
        ICollection<T> Load(string path);
    }
}
