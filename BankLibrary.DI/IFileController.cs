using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary.DI
{
    public interface IFileController<T>
    {
        void Save(T data, string path);
        T Load(string path);
    }
}
