using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    public class ParcelXmlHandler : IParcelFileHandler
    {
        public Container Deserialize(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Container));
            using var reader = new StreamReader(filePath);
            return (Container)serializer.Deserialize(reader);
        }
    }
}
