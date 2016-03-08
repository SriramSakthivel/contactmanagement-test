using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace ContactManagement.Persistance
{
    public class SerializationHelper
    {
        //private static readonly ILog logger = LogManager.GetLogger(typeof(SerializationHelper));

        public static T BinaryDeserializeObject<T>(Stream stream)
        {
            if (stream == null)
            {
                return default(T);
            }
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return (T)formatter.Deserialize(stream);
            }
            catch (Exception ex)
            {
                LogError("BinaryDeserializeObject:", ex );
                return default(T);
            }
        }

        public static void BinarySerializeObject(object graph, Stream stream)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, graph);
        }

        private static void LogError(string message, Exception ex)
        {

        }
    }
}
