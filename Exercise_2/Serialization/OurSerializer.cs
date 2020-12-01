using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;
using System.Threading;

namespace Serialization
{
    public partial class OurSerializer : Formatter
    {
        public override SerializationBinder Binder { get; set ; }
        public override StreamingContext Context { get; set; }
        public override ISurrogateSelector SurrogateSelector { get; set; }
        private string SingleObjectData { get; set; }
        private List<string> AllObjectsData { get; }
        private List<string> ObjectsToDeserialize { get; }
        private Dictionary<string, object> References { get; }

        public OurSerializer()
        {
            Binder = new OurBinder();
            Context = new StreamingContext(StreamingContextStates.File);
            SingleObjectData = "";
            AllObjectsData = new List<string>();
            ObjectsToDeserialize = new List<string>();
            References = new Dictionary<string, object>();

            setCultureInfo();
        }

        public override void Serialize(Stream serializationStream, object obj)
        {
            if (obj is ISerializable objectToSerialize)
            {
                SerializationInfo infoAboutObject = new SerializationInfo(obj.GetType(), new FormatterConverter());
                Binder.BindToName(obj.GetType(), out string assemblyName, out string typeName);

                SingleObjectData += assemblyName + ";"
                                        + typeName + ";"
                                        + m_idGenerator.GetId(obj, out bool firstTime);

                objectToSerialize.GetObjectData(infoAboutObject, Context);

                foreach (SerializationEntry singleObjectField in infoAboutObject)
                {
                    WriteMember(singleObjectField.Name, singleObjectField.Value);
                }

                AllObjectsData.Add(SingleObjectData + "\n");
                SingleObjectData = "";

                while (m_objectQueue.Count != 0)
                {
                    Serialize(null, m_objectQueue.Dequeue());
                }

                if (serializationStream != null)
                {
                    using (StreamWriter writer = new StreamWriter(serializationStream))
                    {
                        foreach (string row in AllObjectsData)
                        {
                            writer.Write(row);
                        }
                    }
                }
            }
            else
            {
                throw new ArgumentException("Object is not Serializable");
            }        
        }

        public override object Deserialize(Stream serializationStream)
        {
            if (serializationStream != null)
            {
                String row;
                using (StreamReader reader = new StreamReader(serializationStream))
                {
                    while ((row = reader.ReadLine()) != null)
                    {
                        ObjectsToDeserialize.Add(row);
                    }
                }

                foreach (string singleObject in ObjectsToDeserialize)
                {
                    string[] splits = singleObject.Split(';');
                    References.Add(splits[2], FormatterServices.GetSafeUninitializedObject(Binder.BindToType(splits[0], splits[1])));
                }
            }

            foreach (string singleObject in ObjectsToDeserialize)
            {
                string[] splits = singleObject.Split(';');
                Type typeOfDeserializedObject = Binder.BindToType(splits[0], splits[1]);

                if (typeOfDeserializedObject != null)
                {
                    SerializationInfo serializationInfo = new SerializationInfo(typeOfDeserializedObject, new FormatterConverter());
                    GetInfoFromDeserializedObject(serializationInfo, splits);
                    Type[] constructorTypes = { serializationInfo.GetType(), Context.GetType() };
                    object[] constructorArguments = { serializationInfo, Context };
                    References[splits[2]]
                        .GetType()
                        .GetConstructor(constructorTypes)
                        ?.Invoke(References[splits[2]],
                            constructorArguments);
                }
            }
            return References["1"];
        }

        private void GetInfoFromDeserializedObject(SerializationInfo info, string[] splitedInfoAboutDeserializedObject)
        {
            for (int i = 3; i < splitedInfoAboutDeserializedObject.Length; i++)
            {
                string[] singleFieldData = splitedInfoAboutDeserializedObject[i].Split('=');
                Type typeToSave = Binder.BindToType(splitedInfoAboutDeserializedObject[0], singleFieldData[0]);

                if (typeToSave == null)
                {
                    if (!singleFieldData[0].Equals("null"))
                    {
                        SaveValueToSerializationInfo(info, Type.GetType(singleFieldData[0]), singleFieldData[1], singleFieldData[2]);
                    }
                    else
                    {
                        info.AddValue(singleFieldData[1], null);
                    }
                }
                else
                {
                    if (!singleFieldData[2].Equals("-1"))
                    {
                        info.AddValue(singleFieldData[1], References[singleFieldData[2]], typeToSave);
                    }
                }
            }
        }

        private void SaveValueToSerializationInfo(SerializationInfo info, Type type, string name, string value)
        {
            switch (type.ToString())
            {
                case "System.Double":
                    info.AddValue(name, Double.Parse(value, CultureInfo.InvariantCulture));
                    break;
                case "System.Boolean":
                    info.AddValue(name, Boolean.Parse(value));
                    break;
                case "System.DateTime":
                    info.AddValue(name, DateTime.Parse(value, null));
                    break;
                case "System.String":
                    info.AddValue(name, value);
                    break;
            }
        }

        protected override void WriteBoolean(bool val, string name)
        {
            SingleObjectData += ";" + val.GetType() + "=" + name + "=" + val.ToString();
        }

        protected override void WriteDateTime(DateTime val, string name)
        {
            SingleObjectData +=";" + val.GetType() + "=" + name + "=" + val;
        }

        protected override void WriteDouble(double val, string name)
        {
            SingleObjectData += ";" + val.GetType() + "=" + name + "=" + val.ToString("0.00", CultureInfo.InvariantCulture);
        }

        protected override void WriteObjectRef(object obj, string name, Type memberType)
        {
            if (memberType == typeof(String))
            {
                WriteString(obj, name);
            }
            else
            {
                WriteObject(obj, name, memberType);
            }
        }

        protected void WriteString(object obj, string name)
        {
            SingleObjectData += ";" + obj.GetType() + "=" + name + "=" + (String)obj;
        }

        protected void WriteObject(object obj, string name, Type type)
        {
            if (obj != null)
            {
                SingleObjectData += ";" + obj.GetType() + "=" + name + "=" + m_idGenerator.GetId(obj, out bool firstTime);
                if (firstTime)
                {
                    m_objectQueue.Enqueue(obj);
                }
            }
            else
            {
                SingleObjectData += ";" + "null" + "=" + name + "=-1";
            }
        }        
        public void setCultureInfo()
        {
            CultureInfo ourCultureInfoSettings = new CultureInfo("pl-PL", false);
            ourCultureInfoSettings.DateTimeFormat.DateSeparator = "-";
            ourCultureInfoSettings.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd";
            Thread.CurrentThread.CurrentCulture = ourCultureInfoSettings;
            Thread.CurrentThread.CurrentUICulture = ourCultureInfoSettings;
        }
    }
}
