using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FDCApp.Contracts.Core
{
    public static class ModelExtensions
    {
        public static T CloneObject<T>(this object source)
        {
            T result = Activator.CreateInstance<T>();            
            return result;
        }

        public static T DeepClone<T>(this T obj)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, obj);
                stream.Position = 0;

                return (T)formatter.Deserialize(stream);
            }
        }
    }
}
