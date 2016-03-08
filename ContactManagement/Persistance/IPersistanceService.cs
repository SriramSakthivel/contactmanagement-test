using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ContactManagement.Persistance
{
    public interface IPersistanceService<T>
    {
        List<T> Load(string fileName);
        void Save(string fileName, List<T> list);
    }
}
