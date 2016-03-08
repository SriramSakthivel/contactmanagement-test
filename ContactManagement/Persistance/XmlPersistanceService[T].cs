using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using ContactManagement.Services;

namespace ContactManagement.Persistance
{
    public class XmlPersistanceService<T> : IPersistanceService<T>
    {
        private readonly ILogService logService;

        public XmlPersistanceService(ILogService logService)
        {
            this.logService = logService;
        }

        public List<T> Load(string fileName)
        {
            if (!File.Exists(fileName))
            {
                return null;
            }
            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
                    return (List<T>)serializer.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
                HandleError("Load:", ex);
                return null;
            }
        }

        public void Save(string fileName, List<T> list)
        {
            try
            {
                string directory = Path.GetDirectoryName(fileName);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                using (FileStream stream = File.OpenWrite(fileName))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
                    serializer.Serialize(stream, list);
                }
            }
            catch (Exception ex)
            {
                HandleError("Save:", ex);
            }
        }

        private void HandleError(string message, Exception ex)
        {
            logService.LogError(message, ex);
        }
    }
}
