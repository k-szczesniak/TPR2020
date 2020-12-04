using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using Data;

namespace Serialization
{
    public class SerializerXml
    {
        public static void Serialize(Stream serializationStream, object obj)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Library));
            serializer.Serialize(serializationStream, obj);
        }

        public static Library Deserialize(Stream serializationStream)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Library));
            return (Library)serializer.Deserialize(serializationStream);
        }
    }
}
