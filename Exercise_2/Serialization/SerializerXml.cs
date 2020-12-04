using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using Data;
using System.Xml.Schema;
using System.Xml.Xsl;

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

        public static void Validate()
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Schemas.Add("http://www.cpandl.com", "C:\\Users\\krzys\\Politechnika\\Semestr_5\\technologie_programowania\\GitHub\\TP\\TPR2020\\Exercise_2\\Data\\LibrarySchema.xsd");
            settings.ValidationType = ValidationType.Schema;

            XmlReader reader = XmlReader.Create("serializationXmlLibraryTest.xml", settings);
            XmlDocument document = new XmlDocument();
            document.Load(reader);

            ValidationEventHandler eventHandler = new ValidationEventHandler(ValidationEventHandler);

            document.Validate(eventHandler);
        }

        static void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            switch (e.Severity)
            {
                case XmlSeverityType.Error:
                    Console.WriteLine("Error: {0}", e.Message);
                    break;
                case XmlSeverityType.Warning:
                    Console.WriteLine("Warning {0}", e.Message);
                    break;
            }
        }

        public static void TransformToXHTML(Stream serializationStream)
        {
            XslCompiledTransform transform = new XslCompiledTransform();
            using (XmlReader reader = XmlReader.Create("C:\\Users\\krzys\\Politechnika\\Semestr_5\\technologie_programowania\\GitHub\\TP\\TPR2020\\Exercise_2\\Data\\XSLTLibrary.xslt"))
            {
                transform.Load(reader);
            }
            StringWriter results = new StringWriter();
            using (XmlReader reader = XmlReader.Create("serializationXmlLibraryTest.xml"))
            {
                transform.Transform(reader, null, results);
            }
            using (StreamWriter writer = new StreamWriter(serializationStream))
            {
                writer.Write(results);                
            }
        }
    }
        
}
