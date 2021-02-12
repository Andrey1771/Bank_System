using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using BankLibrary.DI;

namespace BankLibrary.SaverAndLoader
{
    class JSONSaveLoader<T> : IFileController<T> where T : new()
    {
        public T Load(string path)
        {
            return Deserialize(path);
        }

        public void Save(T data, string path)
        {
            Serialize(data, path);
        }

        private void Serialize(T data, string path)
        {
            Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
            serializer.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            serializer.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto;
            serializer.Formatting = Newtonsoft.Json.Formatting.Indented;

            using (StreamWriter sw = new StreamWriter(path))
            using (Newtonsoft.Json.JsonWriter writer = new Newtonsoft.Json.JsonTextWriter(sw))
            {
                serializer.Serialize(writer, data, typeof(T));
            }
        }

        private T Deserialize(string path)
        {
            if (File.Exists(path))
            {
                var settings = new Newtonsoft.Json.JsonSerializerSettings
                {
                    TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto,
                    NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore
                };
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(File.ReadAllText(path), settings);
            }
            return new T();
        }
    }
}
